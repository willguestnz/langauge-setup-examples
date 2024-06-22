// This Rust program fetches hourly weather data using the Open-Meteo API and prints it.
// It demonstrates the use of asynchronous programming, HTTP GET requests, and JSON deserialization.

// Dependencies required in Cargo.toml for this program to work:
// reqwest for making HTTP requests and working with async features.
// serde for serializing and deserializing data (JSON in this case).
// tokio as the async runtime for Rust.

use reqwest::Error; // Import Error from reqwest for handling request errors.
use serde::Deserialize; // Import Deserialize to automatically convert JSON into Rust data structures.
//use std::collections::HashMap; // HashMap is not used in this snippet but is a common import for handling key-value data.

// Define a struct to deserialize the JSON response for weather data.
#[derive(Deserialize)]
struct WeatherData {
    hourly: HourlyData, // Nested struct for hourly data.
}

// Define a struct for the nested hourly data part of the JSON response.
#[derive(Deserialize)]
struct HourlyData {
    time: Vec<String>, // List of times as strings.
    temperature_2m: Vec<f32>, // List of temperatures 2 meters above ground as floats.
}

// The main async function where execution starts.
#[tokio::main]
async fn main() -> Result<(), Error> {
    let client = reqwest::Client::new(); // Create a new reqwest client instance for making requests.
    // Parameters for the GET request to specify the location and data type (hourly temperature).
    let params = [
        ("latitude", "52.52"),
        ("longitude", "13.41"),
        ("hourly", "temperature_2m"),
    ];
    let url = "https://api.open-meteo.com/v1/forecast"; // API endpoint for fetching weather data.

    // Make an asynchronous GET request to the API with the specified parameters.
    let response = client.get(url)
        .query(&params)
        .send()
        .await? // Send the request and await the response.
        .json::<WeatherData>() // Deserialize the JSON response into the WeatherData struct.
        .await?;

    // Check if the hourly time and temperature data are not empty.
    if !response.hourly.time.is_empty() && !response.hourly.temperature_2m.is_empty() {
        // Iterate over the time and temperature data, zipping them together for paired iteration.
        for (time, temp) in response.hourly.time.iter().zip(response.hourly.temperature_2m.iter()) {
            println!("Time: {}, Temperature: {}", time, temp); // Print each time and corresponding temperature.
        }
    } else {
        println!("Weather data is incomplete."); // Print an error message if data is missing.
    }

    Ok(()) // Return Ok to indicate success.
}