using EmployeeTrack.Models.Entities;

namespace EmployeeTrack.Data
{
    public class DbInitializer
    {
        private readonly HttpClient _httpClient;

        public DbInitializer(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task InitializeAsync(AppDbContext context)
        {
            context.Database.EnsureCreated();

            // Seed Positions
            if (!context.Positions.Any())
            {
                var positions = new Position[]
                {
                    new Position { Name = "Manager" },
                    new Position { Name = "Developer" },
                    new Position { Name = "Designer" },
                    new Position { Name = "QA Engineer" },
                    new Position { Name = "Receptionist" }
                };

                context.Positions.AddRange(positions);
            }

            // Seed Categories
            if (!context.Categories.Any())
            {
                var categories = new Category[]
                {
                    new Category { Name = "Full-Time" },
                    new Category { Name = "Part-Time" },
                    new Category { Name = "Contractor" },
                    new Category { Name = "Intern" }
                };

                context.Categories.AddRange(categories);
            }

            // Seed Countries from API
            if (!context.Countries.Any())
            {
                await SeedCountriesAsync(context);
            }

            await context.SaveChangesAsync();
        }

        private async Task SeedCountriesAsync(AppDbContext context)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<CountryApiResponse>>(
                    "https://restcountries.com/v3.1/all?fields=name");

                if (response != null)
                {
                    var countries = response
                        .Select(c => new Country { Name = c.Name.Common })
                        .OrderBy(c => c.Name)
                        .ToList();
                    Console.WriteLine($"Fetched {countries.Count} countries from API.");
                    context.Countries.AddRange(countries);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error seeding countries: {ex.Message}");
            }
        }

        private class CountryApiResponse
        {
            public required CountryName Name { get; set; }
        }

        private class CountryName
        {
            public required string Common { get; set; }
        }
    }
}