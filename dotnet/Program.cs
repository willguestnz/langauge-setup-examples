using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

// Define the namespace for the WeatherApp
namespace WeatherApp
{
    // Main Program class
    class Program
    {
        // Static HttpClient to be reused across requests to avoid socket exhaustion
        static readonly HttpClient client = new HttpClient();

        // Entry point of the program
        static async Task Main(string[] args)
        {
            // Call the method to fetch and process weather data
            await FetchAndProcessWeatherData();
        }

        // Asynchronous method to fetch and process weather data
        static async Task FetchAndProcessWeatherData()
        {
            // Dictionary to hold query parameters for the API request
            var parameters = new Dictionary<string, string>
            {
                ["latitude"] = "52.52", // Latitude for the location
                ["longitude"] = "13.41", // Longitude for the location
                ["hourly"] = "temperature_2m" // Parameter to specify the type of data requested
            };
            // Base URL of the weather API
            var url = "https://api.open-meteo.com/v1/forecast";

            try
            {
                // Asynchronously send a GET request with the query parameters
                HttpResponseMessage response = await client.GetAsync(url + "?" + await new FormUrlEncodedContent(parameters).ReadAsStringAsync());
                // Ensure the HTTP response status code is successful (200-299)
                response.EnsureSuccessStatusCode();
                // Asynchronously read the response content as a string
                string responseBody = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON string into a WeatherData object
                var weatherData = JsonConvert.DeserializeObject<WeatherData>(responseBody);

                // Check if the weather data and its nested properties are not null
                if (weatherData?.Hourly?.Time != null && weatherData.Hourly.Temperature_2m != null)
                {
                    // Iterate through the hourly weather data
                    for (int i = 0; i < weatherData.Hourly.Time.Count; i++)
                    {
                        // Print each time and corresponding temperature to the console
                        Console.WriteLine($"Time: {weatherData.Hourly.Time[i]}, Temperature: {weatherData.Hourly.Temperature_2m[i]}");
                    }
                }
                else
                {
                    // Print a message if the weather data is incomplete or null
                    Console.WriteLine("Weather data is incomplete.");
                }
            }
            catch (HttpRequestException e)
            {
                // Catch and print any HTTP request exceptions
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }

        // Class to represent the weather data structure
        public class WeatherData
        {
            // Property to hold hourly weather data
            // Initialize Hourly property directly to ensure it's never null
            public HourlyData Hourly { get; set; } = new HourlyData();
        }

        // Class to represent hourly weather data
        public class HourlyData
        {
            // List of DateTime objects representing the time of each data point
            // Initialize Time list directly to ensure they're never null
            public List<DateTime> Time { get; set; } = new List<DateTime>();
            // List of floats representing the temperature at each time point
            // Initialize Temperature_2m list directly to ensure they're never null
            public List<float> Temperature_2m { get; set; } = new List<float>();// Assuming this is the name in your JSON

            // Additional properties can be added here to match the JSON structure
        }
    }
}