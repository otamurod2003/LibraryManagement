using Microsoft.EntityFrameworkCore;
using LibraryManagement.Models;
using LibraryManagement.DataAccess;
using LibraryManagement.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("MyConnection");
builder.Services.AddMvc(options => options.EnableEndpointRouting=false );
builder.Services.AddDbContextPool<LibraryDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IGenericCRUDService<LibrarianModel>, LibrarianCRUDService>();
builder.Services.AddScoped<ILibrarianRepository, LibrarianRepository>();

var app = builder.Build();
app.UseFileServer();
app.UseMvcWithDefaultRoute();

app.Run();
