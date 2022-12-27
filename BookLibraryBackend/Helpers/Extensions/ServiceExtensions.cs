using BookLibraryBackend.Helpers.Seeders;
using BookLibraryBackend.Repositories.LibraryRepository;
using BookLibraryBackend.Repositories.LocationRepository;
using BookLibraryBackend.Services.LibraryService;
using BookLibraryBackend.Services.LocationService;

namespace BookLibraryBackend.Helpers.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ILibraryRepository, LibraryRepository>();
            services.AddTransient<ILocationRepository, LocationRepository>();


            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ILibraryService, LibraryService>();
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
    }
}
