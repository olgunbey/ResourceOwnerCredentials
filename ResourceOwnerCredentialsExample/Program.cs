using IdentityServer4.Services;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using ResourceOwnerCredentialsExample;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddIdentityServer()
    .AddInMemoryClients(Config.GetClients)
    .AddInMemoryApiResources(Config.GetApiResources)
    .AddInMemoryApiScopes(Config.GetApiScopes)
    .AddInMemoryIdentityResources(Config.GetIdentities)
    .AddProfileService<ProfileService>().AddResourceOwnerValidator<ResourceOwnerControl>().AddDeveloperSigningCredential();

builder.Services.AddTransient<IProfileService,ProfileService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseIdentityServer();
app.UseAuthentication();
app.UseAuthorization();


app.MapRazorPages();

app.Run();
