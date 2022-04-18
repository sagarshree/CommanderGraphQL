using CommanderGraphQL.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
var sqliteConnectionString = builder.Configuration.GetConnectionString("SqliteDb");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(sqliteConnectionString));
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();