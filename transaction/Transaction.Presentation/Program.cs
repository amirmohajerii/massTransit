using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using Transaction.Application;
using Transaction.Application.Mapster;
using TransactionMS.Infrastracture.Data;
using Grpc.Net.ClientFactory;
using Transaction.Infrastracture.http;
using MassTransit;
using Transaction.Application.Consumers;
using Transaction.Application.Features.Request.Commands;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TransactionsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add gRPC client
builder.Services.AddGrpcClient<Customer.Grpc.Protos.CustomerService.CustomerServiceClient>(o =>
{
    o.Address = new Uri("https://localhost:5001"); // Address of the Customer gRPC server
});

// Register the CustomerService
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<GrpcCustomerService>();
builder.Services.AddScoped<CreateRequestCommandHandler>();

// Configure RabbitMQ with appsettings
var rabbitMqSettings = builder.Configuration.GetSection("RabbitMQ");
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<CustomerExistsResponseConsumer>();
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(new Uri($"amqp://{rabbitMqSettings["HostName"]}:{rabbitMqSettings["Port"]}"), h =>
        {
            h.Username(rabbitMqSettings["UserName"]);
            h.Password(rabbitMqSettings["Password"]);
        });

        // Configure the endpoint for the consumer and declare the queue
        cfg.ReceiveEndpoint(rabbitMqSettings["Queue"], e =>
        {
            e.ConfigureConsumer<CustomerExistsResponseConsumer>(context);
            e.SetQueueArgument("durable", true);
            e.SetQueueArgument("exclusive", false);
            e.SetQueueArgument("auto-delete", false);
        });
    });
});
builder.Services.AddMassTransitHostedService();

builder.Services.AddHttpClient<ICustomerService, CustomerService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:7023"); // Adjust base address as necessary
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});

builder.Services.AddControllers();
MapsterConfig.RegisterMappings();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Transactions API", Version = "v1" });
});

builder.Services.AddApplicationServices();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Transactions API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
