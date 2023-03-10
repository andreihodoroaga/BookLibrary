using BookLibraryBackend.Helpers.Jwt;
using BookLibraryBackend.Helpers.Seeders;
using BookLibraryBackend.Repositories.AuthorRepository;
using BookLibraryBackend.Repositories.BookRepository;
using BookLibraryBackend.Repositories.LibraryRepository;
using BookLibraryBackend.Repositories.LocationRepository;
using BookLibraryBackend.Repositories.UserRepository;
using BookLibraryBackend.Services.LibraryService;
using BookLibraryBackend.Services.LocationService;
using BookLibraryBackend.Services.Users;

namespace BookLibraryBackend.Helpers.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ILibraryRepository, LibraryRepository>();
            services.AddTransient<ILocationRepository, LocationRepository>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ILibraryService, LibraryService>();
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<ILocationService, LocationService>();

            return services;
        }

        public static IServiceCollection AddSeeders(this IServiceCollection services)
        {
            services.AddTransient<LibrariesSeeder>();
            //services.AddTransient<LibraryLocationsSeeder>();
            //services.AddTransient<AuthorsSeeder>();
            //services.AddTransient<BooksSeeder>();
            return services;
        }

        public static IServiceCollection AddUtils(this IServiceCollection services)
        {
            services.AddScoped<IJwtUtils, JwtUtils>();

            return services;
        }
    }
}
