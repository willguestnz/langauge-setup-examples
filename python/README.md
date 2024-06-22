
# Weather Data Processing Script (Python)

This document provides a comprehensive guide on setting up the environment and running the Python script designed for fetching and processing weather data.

## 1. Installation Guide

### Installing `Python 3.10`,  `python3.10-venv`, and  `pip`

#### On Ubuntu/Debian-based systems:

1.  **Update Package List:**
    ```
    sudo apt update
    ```
2.  **Install Python 3.10:**
    ```
    sudo apt install python3.10
    ```
3.  **Install  `python3.10-venv`:**  This package is necessary for creating virtual environments.
    ```
    sudo apt install python3.10-venv
    ```
4.  **Install  `pip`:**  Pip is the package installer for Python. You can install it by:
    ```
    sudo apt install python3-pip
    ```

#### On Windows:

Download and install Python 3.10 from the official Python website (https://www.python.org/downloads/). During the installation, ensure to select the option to Add Python 3.10 to PATH. The installer includes  `pip`  and the virtual environment (`venv`) module by default.

### Creating a Virtual Environment and Installing Libraries

1.  **Create a Virtual Environment:**  Navigate to your project directory and run:
    ```
    python3.10 -m venv venv
    ```
    This command creates a new directory named  `venv`  in your project directory, containing the virtual environment.
    
2.  **Activate the Virtual Environment:**
    
    -   On Linux or macOS:
        ```
        source venv/bin/activate
        ```
    -   On Windows:
        ```
        .\venv\Scripts\activate
        ```
3.  **Install Required Libraries:**  With the virtual environment activated, install the required libraries using  `pip`:
    ```
    pip install requests_cache pandas retry_requests openmeteo-requests
    ```
4.  **Freeze Installed Libraries to  `requirements.txt`:**  To keep track of the installed packages and their versions, you can freeze the current state of the environment:
    ```
    pip freeze > requirements.txt
    ```

## 2. Script Overview

The provided Python script is designed to fetch and process weather data using the Open-Meteo API. It performs the following operations:

-   Sets up an API client with caching and retry mechanisms to handle requests efficiently.
-   Constructs a request to fetch weather data based on specified parameters such as latitude, longitude, and the type of data required (e.g., hourly temperature).
-   Processes the response to extract and print out relevant information such as coordinates, elevation, timezone, and temperature data.
-   Converts the hourly temperature data into a pandas DataFrame for easy manipulation and visualization, then prints it out.

## 3. Running the Script

To run the script, ensure that your virtual environment is activated and that all dependencies are installed. Then, execute the script using Python:
```
python __init__.py
```
Make sure you are in the same directory as the  `__init__.py`  script when you run this command. The script will output the weather data fetched from the Open-Meteo API to the console.
