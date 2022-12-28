using BookLibraryBackend.Data;
using BookLibraryBackend.Helpers;
using BookLibraryBackend.Helpers.Extensions;
using BookLibraryBackend.Helpers.Middleware;
using BookLibraryBackend.Helpers.Seeders;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<BooksLibraryContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddSeeders();
builder.Services.AddUtils();

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

var app = builder.Build();
//SeedData(app);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.Run();

//void SeedData(IHost app)
//{
//    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
//    using (var scope = scopedFactory.CreateScope())
//    {
//        var service = scope.ServiceProvider.GetService<LibrariesSeeder>();
//        service.SeedIntialLibraries();
        //var service2 = scope.ServiceProvider.GetService<LibraryLocationsSeeder>();
        //service2.SeedInitialLibraryLocations();
        //var service3 = scope.ServiceProvider.GetService<AuthorsSeeder>();
        //service3.SeedInitialAuthors();
        //var service4 = scope.ServiceProvider.GetService<BooksSeeder>();
        //service4.SeedInitialBooks();
//    }
//}