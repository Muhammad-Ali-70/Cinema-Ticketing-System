# 🎬 Cinema Ticketing System

## 📖 Overview

The Cinema Ticketing System is a comprehensive desktop application developed in C# designed to streamline the process of booking movie tickets. It provides distinct interfaces and functionalities for both administrators and customers, ensuring a smooth and efficient user experience for managing cinema operations and ticket purchases.

## ✨ Features

### 🛠️ Admin Features
- **🔐 Admin Login**: Secure login interface for administrators to access the admin dashboard.
- **🎥 Manage Movies**: Add, edit, and remove movie details, including title, genre, duration, and screening times.
- **🎟️ Manage Tickets**: View and manage all ticket bookings, including the ability to cancel or modify bookings.
- **👥 Manage Users**: Access a list of all registered users and their details.
- **💰 Update Pricing**: Modify ticket pricing based on movie, time, or other criteria.

### 🧑‍💻 Customer Features
- **🔐 Customer Login**: Secure login for customers to access their personal accounts.
- **📋 Movie Details**: Browse and view detailed information about available movies, including synopsis, cast, and screening schedule.
- **🛒 Ticket Booking**: Book tickets for selected movies, choose seats, and select showtimes.
- **💳 Payment Selection**: Choose from multiple payment methods for booking tickets.
- **📜 Ticket History**: View history of past bookings and transactions.
- **🛠️ Account Management**: Edit personal details, change password, and manage account settings.

## 📂 Database
The project includes an MDF database file (`CinemaTicketing_DBS.mdf`) to store all essential data such as:
- Movie details
- User information
- Booking records

## 🛠️ Getting Started
1. **Clone the Repository**: Download or clone the repository to your local machine.
    ```bash
    git clone https://github.com/Muhammad-Ali-70/Cinema-Ticketing-System.git
    ```
2. **Open Solution in Visual Studio**: Open the solution file (`CinemaTicketingSystem.sln`) in Visual Studio.
3. **Configure Database**: Ensure that the database connection string in the application matches your local SQL Server configuration.
4. **Build and Run**: Build the solution and run the application.

## 🛠️ Technologies Used
- **Programming Language**: C#
- **Framework**: Windows Forms
- **Database**: SQL Server (MDF file)

## 📂 Project Structure
- **`/Admin`**: Contains forms and functionalities related to admin operations such as managing movies, tickets, and users.
- **`/Customer`**: Includes forms and functionalities for customer activities like browsing movies, booking tickets, and managing their account.
- **`/Database`**: Contains the MDF file for database operations.
