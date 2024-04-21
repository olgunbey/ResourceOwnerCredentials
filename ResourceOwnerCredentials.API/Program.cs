using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using ResourceOwnerCredentials.API;
using ResourceOwnerCredentials.API.Requirements;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = "https://localhost:7001";
    opt.Audience = "ApiResource";
    opt.RequireHttpsMetadata = false;
});

builder.Services.AddSingleton<IAuthorizationHandler, Handler>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("policy1", policybuilder =>
    {
        policybuilder.AddRequirements(new Requirements());
    });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthentication()
    .AddScheme<JwtBearerOptions, WriteJwtBearer>("JwtBearerWrite", options => { options.Authority = "https://localhost:7001"; options.Audience = "ApiResource"; })
    .AddScheme<JwtBearerOptions, ReadJwtBearer>("JwtBearerRead", options => { options.Authority = "https://localhost:7001"; options.Audience = "ApiResource"; })
    .AddScheme<JwtBearerOptions, AdminJwtBearer>("JwtBearerAdmin", options => { options.Authority = "https://localhost:7001"; options.Audience = "ApiResource"; });
builder.Services.AddTransient<CustomJwtBearerHandler>();


builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
//app.UseExceptionHandler(options =>
//{
//    options.Run(async context =>
//    {
        
//        var exceptionObject = context.Features.Get<IExceptionHandlerFeature>();
//        if (exceptionObject.Error.Message=="Unauthorized")
//        {
//            context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
//            context.Response.ContentType = "application/json";
//            var errorMessage = $"{exceptionObject.Error.Message}";
//            await context.Response.WriteAsync(errorMessage).ConfigureAwait(false);
//        }
//    });

//});
app.UseAuthorization();

app.MapControllers();

app.Run();
