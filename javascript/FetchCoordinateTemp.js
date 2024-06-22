// Import the fetchWeatherApi function from the 'openmeteo' package
const { fetchWeatherApi } = require('openmeteo');

// Define an asynchronous function to fetch and process weather data
async function fetchAndProcessWeatherData() {
    // Parameters for the API request
    const params = {
        latitude: 52.52, // Latitude for Berlin, Germany
        longitude: 13.41, // Longitude for Berlin, Germany
        hourly: "temperature_2m" // Request hourly temperature data 2 meters above ground
    };
    // The base URL for the Open-Meteo API
    const url = "https://api.open-meteo.com/v1/forecast";
    
    try {
        // Await the response from the fetchWeatherApi function with the specified URL and parameters
        const responses = await fetchWeatherApi(url, params);
        // Assuming responses is an array of response objects, process the first response
        const response = responses[0]; // For multiple locations or models, iterate over responses

        // Helper function to create an array representing a range of numbers
        const range = (start, stop, step) =>
            Array.from({ length: (stop - start) / step }, (_, i) => start + i * step);

        // Extract timezone and location attributes from the response
        const utcOffsetSeconds = response.utcOffsetSeconds(); // UTC offset in seconds
        const timezone = response.timezone(); // Timezone ID (e.g., Europe/Berlin)
        const timezoneAbbreviation = response.timezoneAbbreviation(); // Timezone abbreviation (e.g., CEST)
        const latitude = response.latitude(); // Latitude from the response
        const longitude = response.longitude(); // Longitude from the response

        // Extract hourly weather data from the response
        const hourly = response.hourly();

        // Construct weather data object with time and temperature arrays
        const weatherData = {
            hourly: {
                time: range(Number(hourly.time()), Number(hourly.timeEnd()), hourly.interval()).map(
                    (t) => new Date((t + utcOffsetSeconds) * 1000) // Convert each time to a Date object, adjusting for UTC offset
                ),
                temperature2m: hourly.variables(0).valuesArray(), // Extract temperature values as an array
            },
        };

        // Iterate over the weather data to log each time and corresponding temperature
        for (let i = 0; i < weatherData.hourly.time.length; i++) {
            console.log(
                weatherData.hourly.time[i].toISOString(), // Convert time to ISO string format
                weatherData.hourly.temperature2m[i] // Log the corresponding temperature
            );
        }
    } catch (error) {
        // Log any errors that occur during the fetch or processing
        console.error("Failed to fetch weather data:", error);
    }
}

// Execute the asynchronous function to fetch and process the weather data
fetchAndProcessWeatherData();