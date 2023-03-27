using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Licenta_Kovacs_Adela.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Licenta_Kovacs_AdelaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Licenta_Kovacs_AdelaContext") ?? throw new InvalidOperationException("Connection string 'Licenta_Kovacs_AdelaContext' not found.")));

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
