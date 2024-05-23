# Price Parser - Product Price Tracking and Alert System

PriceParser is a web application designed to help you track product prices and receive timely alerts when there are price changes.

## Features

-   **Price Tracking:** Keep an eye on the price of your favorite products.
-   **Web Scraping:** Real-time data scraping from product websites.
-   **Price Alerts:** Receive notifications when a product price changes.
-   **Email Notifications:** Stay updated through email notifications.
-   **User-Friendly Interface:** An easy-to-navigate web application for all your tracking needs.

## Installation

### FE

1. **Install Dependencies:**

    ```bash
     npm install
    ```

2. **Set Up Environment Variables:**
   `Create a .env file and provide the necessary environment variables.`

3. **Run the Application:**

    ```bash
    npm run dev
    ```

### BE

1. **Install Dependencies:**

    ```bash
     dotnet restore
    ```

2. **Set Up Environment Variables:**
   `Create a appsettings.Development.json file and provide the necessary environment variables, including database connection and email configurations`

3. **Run Solution**

    ```bash
    dotnet run
    ```

## Tech Stack

PriceParser is built using the following technologies and tools:

-   **Frontend:** React.js, Typescript, Tailwind CSS, Bootstrap, MUI, Axios and more. (See [package.json])
-   **Backend:** .NET Web API, Twilio, Cosmos DB, Zenrows, Sendgrid and more. (See Nuget Packages)
-   **Database:** Azure Cosmos DB
-   **Email Service:** Sendgrid
-   **Web Scraping:** Zenrows, Html Agility Pack (HAP)
-   **Deployment and Hosting:** Azure App Service, Azure Functions, Azure Cosmos DB
-   **Version Control:** Git and GitHub
