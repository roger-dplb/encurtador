Encurtador
A simple URL shortener API built with ASP.NET Core. This project allows users to create, manage, and redirect shortened links. It uses Entity Framework Core for data persistence and supports Docker for easy deployment.

Features
Create short links for long URLs
Redirect short links to original URLs
List and manage links
RESTful API endpoints
Docker and Compose support
Technologies Used
ASP.NET Core
Entity Framework Core
SQLite (default, can be changed)
Docker & Docker Compose
Getting Started
Prerequisites
.NET 9 SDK
Docker (optional)
Setup & Run (Development)
The API will start on the port defined in appsettings.json or launchSettings.json.

Docker & Compose
To run with Docker:

Or with Docker Compose:

API Endpoints
POST /links/shorten — Create a new short link
GET /links/{shortenCode} — Get link details

See encurtador.http for example requests.

Migrations
To add or update database migrations:

Migrations are stored in the Migrations/ folder.

Configuration
appsettings.json — Main configuration
appsettings.Development.json — Development overrides
Contributing
Pull requests are welcome! For major changes, please open an issue first to discuss what you would like to change.

License
This project is licensed under the MIT License.