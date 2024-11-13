using Common;
using AbstractHandlers.Structured;
using AbstractHandlers.Structured.CommandHandlers.Authors.AddAuthor;
using AbstractHandlers.Structured.Persistence;
using AbstractHandlers.Structured.Persistence.Repositories;
using AbstractHandlers.Structured.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using EventPublisher = Common.Messaging.EventPublisher;
using IEventPublisher = Common.Messaging.IEventPublisher;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddStructuredEventHandlersAndNecessaryWork(typeof(AddAuthorCommandHandler));
// Add Services

services.AddScoped<IEventPublisher, EventPublisher>();

services.AddScoped<IBookRepository, BookRepository>();

services.AddScoped<IAuthorRepository, AuthorRepository>();

services.AddScoped<IBookRequestRepository, BookRequestRepository>();

services.AddScoped<IUnitOfWork, UnitOfWork<ApplicationDbContext>>();


services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("HandlersDatabase")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.AddStructuredEndpoint();


app.Run();

// {
//  "source": "string",
//  "detailType": "AddCommand",
//  "detail": {
//      "body":{
//          "Value1":1
//      }
//  }
//  }


//{
// "source": "string",
// "detailType": "RemoveCommand",
// "detail": {
//     "body":{
//         "Value1":2
//     }
// }
// }

//{
// "source": "string",
// "detailType": "DividedEvent",
// "detail": {
//     "body":{
//         "Value1":3
//     }
// }
// }

// {
//  "source": "string",
//  "detailType": "MultipliedEvent",
//  "detail": {
//      "body":{
//          "Value1":4
//      }
//  }
//  }