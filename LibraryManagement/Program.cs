using Microsoft.EntityFrameworkCore;
using LibraryManagement.Models;
using LibraryManagement.DataAccess;
using LibraryManagement.Services;
using LibraryManagement.DataAccess.Data;
using LibraryManagement.DataAccess.Entities;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("MyConnection");
builder.Services.AddScoped<IGenericCRUDService<LibrarianModel>, LibrarianCRUDService>();
builder.Services.AddScoped<IGenericCRUDService<AdressModel>, AdressCRUDService>();
builder.Services.AddMvc(options => options.EnableEndpointRouting=false );
builder.Services.AddDbContextPool<LibraryDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IGenericRepository<Librarian>, LibrarianRepository>();
builder.Services.AddScoped<IGenericRepository<Adress>, AdressRepository>();

var app = builder.Build();
app.UseFileServer();
app.UseMvcWithDefaultRoute();
app.Run();
