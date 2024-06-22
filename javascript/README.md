
# Weather Data Processing Script (JavaScript)

This document outlines the steps to set up the environment and run the JavaScript script designed for fetching and processing weather data using the Open-Meteo API.

## 1. Installation Guide

### Installing Node.js and npm

`Node.js` is a runtime environment that allows you to run JavaScript on the server side. `npm` is the `Node.js` package manager and is used to install JavaScript packages.

#### On Ubuntu/Debian-based systems:

1.  **Install Node.js:**  You can install `Node.js` from the *NodeSource* repository which includes both `Node.js` and `npm`. To install Node.js version 18.x, run:
    ```
    curl -sL https://deb.nodesource.com/setup_18.x | sudo -E bash -
    ```
    ```
    sudo apt-get install -y nodejs
    ```
2.  **Verify Installation:**  Check that Node.js and npm are installed by running:
    ```
    node -v
    ```
    ```
    npm -v
    ```

#### On Windows:

Download the Windows installer from the official Node.js website (https://nodejs.org/en/download/). This installer will install both `Node.js` and `npm`.

### Setting Up the Environment

1.  **Initialize a New npm Project:**  In your project directory, run:
    ```
    npm init -y
    ```
    This command creates a  `package.json`  file in your project directory.
    
2.  **Install Required Packages:**  Install the  `openmeteo`  package (or the correct package for fetching weather data if  `openmeteo`  is a placeholder name) by running:
    ```
    npm install openmeteo
    ```
    If your script depends on other packages, install them in a similar manner.
    

## 2. Script Overview

The  `FetchCoordinateTemp.js`  script is designed to fetch hourly weather data for a specified location (Berlin, Germany, in this case) and log the time and corresponding temperature to the console. It makes use of the  `openmeteo`  package to send requests to the Open-Meteo API and processes the response to extract and display the weather data.

## 3. Running the Script

To run the script, ensure that `Node.js` and `npm` are installed and that you have set up your project environment as described above. Then, execute the script using `Node.js`:
```
node FetchCoordinateTemp.js
```
Make sure you are in the same directory as the  `FetchCoordinateTemp.js`  script when you run this command. The script will output the fetched weather data to the console.
