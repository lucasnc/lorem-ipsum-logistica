using AutoMapper;
using lorem_ipsum_api;
using lorem_ipsum_api.Middleware;
using LoremIpsum.CrossCutting.DependencyInjection;
using LoremIpsum.CrossCutting.Mappings;
using FluentValidation;
using System;
using LoremIpsum.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using lorem_ipsum_api.Validators;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Azure;
using System.Text.Json;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var messages = context.ModelState.Values
            .Where(x => x.ValidationState == ModelValidationState.Invalid)
            .SelectMany(x => x.Errors)
            .Select(x => x.ErrorMessage)
            .ToList();

        return new BadRequestObjectResult(JsonSerializer.Serialize(new { message = string.Join($"{Environment.NewLine}", messages), code = (int)HttpStatusCode.BadRequest }));
    };
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


ConfigureService.ConfigureDependenciesService(builder.Services);
ConfigureRepository.ConfigureDependenciesRepository(builder.Services, builder.Configuration);

var config = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.AddProfile(new EntityToDtoProfile());
});

IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseMiddleware<ExceptionMiddleware>();


app.UseCors(option => option.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.Run();
