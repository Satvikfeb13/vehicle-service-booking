# 🚗 Vehicle Service Booking System

A full-stack web application for managing vehicle service bookings, mechanic assignments, and real-time job tracking. Built with **ASP.NET Core 7** and **React (Vite)**.

---

## ✨ Features

### 👤 Customer
- Register / Login with JWT-based authentication
- Browse available services with pricing
- Book a vehicle service by date, time, and vehicle details
- View active bookings and booking history
- Cancel or edit pending bookings

### 🔧 Mechanic
- View all assigned jobs via a dedicated dashboard
- Update job status (`ASSIGNED` → `IN_PROGRESS` → `COMPLETED`)
- Automatically assigned jobs based on skill level and workload

### 🛡️ Admin
- View system-wide statistics and revenue
- Full CRUD for services (add, edit, delete)
- Register and manage mechanics
- Monitor all customer bookings
- Toggle user account status (active / inactive)

### ⚙️ System
- **Automated Dispatch:** A background worker runs every 15 seconds to intelligently assign pending bookings to available mechanics based on skill match and current workload
- **Role-Based Access Control (RBAC):** Secured endpoints for Admin, Mechanic, and Customer roles
- **Global Exception Handling:** Centralized error middleware for clean API responses

---

## 🏗️ Tech Stack

| Layer | Technology |
|---|---|
| **Backend** | ASP.NET Core 7, Entity Framework Core |
| **Database** | MySQL |
| **Authentication** | JWT (JSON Web Tokens) |
| **Frontend** | React 18, Vite, React Bootstrap |
| **Background Jobs** | .NET IHostedService |
| **ORM** | Entity Framework Core (Code First) |

---

## 📂 Project Structure

```
vehicle-service-booking/
├── VehicleService.API/               # ASP.NET Core Backend
│   ├── BackgroundJobsScheduler/      # Mechanic allocation worker
│   ├── Controllers/                  # API endpoints
│   ├── Data/                         # DbContext & data seeder
│   ├── DTOs/                         # Request/response models
│   ├── Enums/                        # BookingStatus, SkillLevel, etc.
│   ├── Exceptions/                   # Global exception middleware
│   ├── Migrations/                   # EF Core database migrations
│   ├── Models/                       # Domain entities
│   ├── Repositories/                 # Data access layer
│   ├── Security/                     # JWT token service
│   ├── Services/                     # Business logic layer
│   └── appsettings.json              # Configuration
│
└── vehicle-service-frontend/         # React Frontend
    ├── src/
    │   ├── components/               # Reusable UI components
    │   ├── context/                  # Auth context
    │   ├── pages/                    # Page components
    │   └── services/                 # Axios API service layer
    └── index.html
```

---

## 🚀 Getting Started

### Prerequisites
- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- [Node.js](https://nodejs.org/) (v18+)
- [MySQL](https://www.mysql.com/) (v8+)

---

### 1. Clone the Repository

```bash
git clone https://github.com/your-username/vehicle-service-booking.git
cd vehicle-service-booking
```

---

### 2. Configure the Backend

Open `VehicleService.API/appsettings.json` and update the connection string and JWT secret:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=VehicleDb;User=root;Password=YOUR_PASSWORD;"
  },
  "Jwt": {
    "Key": "YOUR_SUPER_SECRET_KEY_MIN_32_CHARS",
    "Issuer": "VehicleServiceAPI",
    "Audience": "VehicleServiceClient"
  }
}
```

---

### 3. Run the Backend

```bash
cd VehicleService.API
dotnet run
```

The API will start at `http://localhost:5000`.

> **Note:** The database is created automatically on first run via EF Core migrations. Demo users are also seeded automatically.

---

### 4. Run the Frontend

```bash
cd vehicle-service-frontend
npm install
npm run dev
```

The frontend will start at `http://localhost:3000`.

---

## 🔑 Demo Credentials

| Role | Email | Password |
|---|---|---|
| **Admin** | admin2@vehicleservice.com | Admin@123 |
| **Customer** | customer@example.com | Customer@123 |
| **Mechanic** | mechanic@example.com | Mechanic@123 |

---

## 📡 Key API Endpoints

| Method | Endpoint | Description | Role |
|---|---|---|---|
| `POST` | `/api/auth/login` | Login | Public |
| `POST` | `/api/auth/register` | Register customer | Public |
| `GET` | `/api/services` | Get all services | Public |
| `POST` | `/api/bookings` | Create a booking | Customer |
| `GET` | `/api/bookings/my` | Get my bookings | Customer |
| `PUT` | `/api/bookings/{id}` | Update booking | Customer |
| `DELETE` | `/api/bookings/{id}/cancel` | Cancel booking | Customer |
| `GET` | `/api/mechanic/my-jobs` | Get mechanic's jobs | Mechanic |
| `PUT` | `/api/mechanic/jobs/{id}/status` | Update job status | Mechanic |
| `GET` | `/api/admin/bookings` | View all bookings | Admin |
| `POST` | `/api/admin/services` | Add a new service | Admin |

---

## 🔄 Booking Lifecycle

```
PENDING → ASSIGNED → IN_PROGRESS → COMPLETED
    ↓
CANCELLED
```

1. Customer creates a booking → status: `PENDING`
2. Background worker detects pending booking and assigns best available mechanic → `ASSIGNED`
3. Mechanic starts the job → `IN_PROGRESS`
4. Mechanic marks job complete → `COMPLETED`

---

## 🧑‍💻 Author

Built with ❤️ as a portfolio project demonstrating full-stack .NET and React development skills.
