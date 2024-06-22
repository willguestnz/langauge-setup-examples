
# Weather Data Processing Script (Rust)

This Rust script fetches hourly weather data using the Open-Meteo API and demonstrates asynchronous programming, HTTP GET requests, and JSON deserialization in Rust.

## Prerequisites

### Installing Rust and Cargo

-   **Windows:**
    
    1.  Download and run the Rust installer from  rustup.rs.
    2.  Follow the on-screen instructions to complete the installation.
    3.  Restart your terminal and verify the installation by running  `rustc --version`.
-   **Linux:**
    
    1.  Open a terminal and run the following command:  
    ```
    curl --proto '=https' --tlsv1.2 -sSf https://sh.rustup.rs | sh`
    ```
    2.  Follow the on-screen instructions to complete the installation.
    3.  Source your profile (usually  `~/.profile`  or  `~/.bash_profile`) to update your current session, or simply restart your terminal.
    ```
    export  OPENSSL_DIR=/path/to/openssl
    ```
    4.  Verify the installation by running  
	   ```
	   rustc -v
	```
	```
	cargo -v
	```
	
		
### Setting Up OpenSSL

-   **Windows:**
    
    1.  Download and install OpenSSL from  this page.
    2.  Add the OpenSSL bin directory to your system's PATH environment variable.
    3.  Restart your terminal or IDE to apply the changes.
-   **Linux:**
    
    1. For Ubuntu/Debian-based systems, use  `sudo apt-get install libssl-dev pkg-config`. 
	2. For Fedora/Red Hat-based systems, use  `sudo dnf install openssl-devel pkg-config`.

## Setting Up a New Rust Project

1.  Open a terminal or command prompt.
2.  Navigate to the directory where you want to create your new project.
3.  Run  `cargo new weather_data`  to create a new Rust project named  `weather_data`.
4.  Navigate into your project directory by running  `cd weather_data`.
5.  Open the  `Cargo.toml`  file and add the necessary dependencies under  `[dependencies]`:

```toml
[dependencies]
reqwest = { version = "0.11", features = ["json"] }
serde = { version = "1.0", features = ["derive"] }
tokio = { version = "1", features = ["full"] }
```

6.  Replace the content of  `src/main.rs`  with your desired Rust script.

## Script Overview

This script makes an asynchronous GET request to the Open-Meteo API to fetch hourly weather data for a specified location. It then deserializes the JSON response into Rust data structures and prints the hourly time and temperature data to the console.

## Building the Script

1.  Clone or download the script to your local machine.
2.  Navigate to the script's directory in your terminal or command prompt.
3.  Run  `cargo build`  to compile the script. This command also fetches and builds the script's dependencies.

## Running the Script

After building the script, you can run it using Cargo:
```
cargo  run
```
This command compiles the script (if not already compiled) and executes it, printing the fetched weather data to the console.

## Dependencies

Ensure your  `Cargo.toml`  includes the following dependencies:
```
[dependencies]
reqwest = { version = "0.11", features = ["json"] }
serde = { version = "1.0", features = ["derive"] }
tokio = { version = "1", features = ["full"] }
```
## Note

This script uses the Open-Meteo API, which is free and does not require an API key. However, please respect the API's usage policies and limitations.
