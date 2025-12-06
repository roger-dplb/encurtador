# 🔗 Encurtador: Simple URL Shortener API

A **simple, fast, and feature-rich URL shortener API** built with **ASP.NET Core**. This project allows users to create, manage, and track shortened links via a robust RESTful interface.

---

## ✨ Features

* **Create** short links for any long URL.
* **Redirect** short codes seamlessly to the original URLs.
* **List and Manage** all created links.
* **RESTful API** endpoints for easy integration.
* **Docker & Docker Compose** support for quick deployment.

---

## 🛠️ Technologies Used

* **Backend:** ASP.NET Core
* **Database:** Entity Framework Core (with **SQLite** as the default provider)
* **Containerization:** Docker & Docker Compose
* **Language:** C#

---

## 🚀 Getting Started

### Prerequisites

Ensure you have the following installed:

* **.NET 9 SDK**
* **Docker** (Optional, but recommended for production deployment)

### Setup & Run (Development)

To run the API locally without Docker:

1.  **Clone the repository:**
    ```bash
    git clone [Your Repository URL Here]
    cd Encurtador
    ```
2.  **Run the application:**
    ```bash
    dotnet run
    ```
    The API will start on the port defined in `appsettings.json` or `launchSettings.json` (typically `http://localhost:5000` or `https://localhost:5001`).

### Docker & Compose

#### With Docker

To build and run the container directly:

```bash
# Build the image
docker build -t encurtador .

# Run the container (adjust port if needed)
docker run -d -p 8080:80 encurtador