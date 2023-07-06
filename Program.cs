using Microsoft.EntityFrameworkCore;
using LibraryManagement.Data;
using LibraryManagement.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddMvc(options => options.EnableEndpointRouting=false );
builder.Services.AddDbContext<LibraryDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<ILibrarianRepository, LibrarianRepository>();
var app = builder.Build();

app.UseStaticFiles();
app.UseMvcWithDefaultRoute();

app.Run();
