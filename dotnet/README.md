
# Weather Data Processing Script (C#)

  

This document outlines the setup and execution process for a C# console application designed to fetch and process weather data.

  

## Environment Setup

  

### Installing .NET SDK

  

The .NET SDK is required to build and run C# applications. Follow the instructions below to install it on your system.

  

#### On Windows:

1.  **Download the .NET SDK Installer:**

Visit the [.NET download page](https://dotnet.microsoft.com/download) and download the .NET SDK installer for Windows.

2.  **Run the Installer:**

Execute the downloaded installer and follow the on-screen instructions to complete the installation.

3.  **Verify Installation:**

Open a command prompt and run the following command to verify that .NET has been installed correctly:
```
dotnet --version
```
This command should display the installed .NET version.

#### On Ubuntu/Debian-based Linux Distributions:

1.  **Add Microsoft Package Signing Key to Your List of Trusted Keys and Add the Package Repository:**  Open a terminal and run the following commands:
	```  
	 wget https://packages.microsoft.com/config/ubuntu/$(lsb_release -rs)/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
	 ```
	 ```
    sudo dpkg -i packages-microsoft-prod.deb
	  ```  
2.  **Install the SDK:**  Update the package list and install the .NET SDK with the following commands:
    ```
    sudo apt-get update; \
    
    sudo apt-get install -y apt-transport-https && \
    
    sudo apt-get update && \
    
    sudo apt-get install -y dotnet-sdk-8.0
    ```
    Replace  `dotnet-sdk-8.0`  with the version you wish to install.
    
3.  **Verify Installation:**  To ensure the .NET SDK was installed correctly, type the following command:
    ```
    dotnet --version
    ```
    This will display the version of .NET that was installed.
    

### Setting Up the Project

1.  **Create a New Console Project:**  Open your terminal or command prompt and run the following command to create a new console project:
    ```
    dotnet new console -n WeatherApp
    ```  
    This command creates a new directory named  `WeatherApp`  with a simple "Hello World" C# project.
    
2.  **Navigate to Your Project Directory:**
    ```
    cd WeatherApp
    ```
3.  **Add Newtonsoft.Json Package:**  To deserialize the JSON response from the weather API, add the  `Newtonsoft.Json`  package to your project:
	``` 
    dotnet add package Newtonsoft.Json
	```
### Getting Started
1. **Start writing your program:** To start writing your C# program start to add your desired code base to the `program.cs` file created (you can copy the existing `program.cs` in this repo)

2. **Build your Project:** Before running the application, it's essential to build the project to ensure all dependencies are correctly resolved and the application is compiled. Follow these steps to build your project:

	1.  **_Open a Terminal or Command Prompt:_**

		Navigate to the root directory of your project where the `.csproj` file is located.

	2.  **_Run the Build Command:_**

		Execute the following command to build your project:
			```
			dotnet build
			```
## Application Overview

The C# application is structured to perform the following tasks:

-   Utilize a static  `HttpClient`  instance to make asynchronous GET requests to a weather API.
-   Pass query parameters to the API to fetch weather data for a specific location and data type (e.g., hourly temperature).
-   Deserialize the JSON response into a  `WeatherData`  object.
-   Check for null values in the deserialized object and print the hourly weather data (time and temperature) to the console.
-   Handle exceptions that may occur during the HTTP request.

## Running the Application

To run the application, ensure you are in the project directory (`WeatherApp`) and use the following command:
```
dotnet run
```
This command compiles and executes the application. The output will display the fetched weather data, including time and temperature, in the console.

## Code Structure

-   **Program.cs:**  Contains the main entry point of the application, the  `Main`  method, and the  `FetchAndProcessWeatherData`  asynchronous method for fetching and processing the weather data.
-   **WeatherData Class:**  Represents the structure of the weather data with properties for hourly data.
-   **HourlyData Class:**  Represents the hourly weather data, including time and temperature.

The application makes use of the  `Newtonsoft.Json`  library to deserialize the JSON response from the weather API into these classes. 
