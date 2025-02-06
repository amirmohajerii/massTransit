using Customer.Application;
using Customer.Infrastracture.Data;
using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Customer.Application.Mapster;
using MediatR;
using Grpc.Core;
using Customer.Application.Features.IndividualCustomer.Commands;
using Customer.Application.Features.IndividualCustomer.Queries;
using System.Reflection;
using Customer.Grpc.Services;
using MassTransit;
using Customer.Application.Consumers;
using Customer.Infrastracture.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
MapsterConfig.RegisterMappings(); // Register Mapster mappings

// DbContext configuration
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuration for MassTransit in Customer project
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<CustomerExistsConsumer>();
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("amqp://guest:guest@localhost:5672"); // Use AMQP protocol

        // Configure the endpoint for the consumer
        cfg.ReceiveEndpoint("customer_exists_queue", e =>
        {
            e.ConfigureConsumer<CustomerExistsConsumer>(context);
        });
    });
});
builder.Services.AddMassTransitHostedService();
builder.Services.AddGrpc(); // Register gRPC services

// Register MediatR and FluentValidation
builder.Services.AddApplicationServices();
builder.Services.AddValidatorsFromAssemblyContaining<CreateIndividualCustomerCommandValidator>();
builder.Services.AddFluentValidationAutoValidation();

// Swagger configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.MapGrpcService<CustomerService>(); // Map gRPC service

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
