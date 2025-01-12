# ITU C# Semester Project - Notification and Task Management System

Welcome to the **Notification and Task Management System**, a project developed as part of our Object-Oriented Programming with C# class at Istanbul Technical University. This system combines API data retrieval, task scheduling, and notifications to manage various user tasks effectively.

### Project Overview

This project consists of a backend built with .NET and PostgreSQL, along with a notification system for users. The core features include:
- **API Data Retrieval**: Periodic retrieval of stock data from the Yahoo Finance API to update the system.
- **Password Reminder Notifications**: Sending reminders to users to update their passwords at regular intervals.

### Setup and Running Instructions

Follow the steps below to set up and run the project locally.

---

### Cloning the Repository

1. Open a terminal or command prompt.
2. Clone the repository:
    ```bash
    git clone https://github.com/kadrcankahvci/Sequential-Task-Management-System.git
    ```
3. Navigate to the cloned directory:
    ```bash
    cd SequentialTaskManager
    ```

---

### Setting Up PostgreSQL

1. **Install DBeaver**:  
   DBeaver is a free, universal database tool for developers and database administrators. Download and install it from [DBeaver's website](https://dbeaver.io/).

2. **Create a Database**:  
   Open DBeaver and connect to your PostgreSQL instance. Create a new database named `SequentialTaskManager`.

3. **Configure Database Connection**:  
   Navigate to the `appsettings.json` file in the backend directory.  
   Locate the **ConnectionStrings** section:
   ```json
   "ConnectionStrings": {
       "PostgreSql": "Host=localhost;Database=SequentialTaskManager;Username=your-username;Password=your-password"
   }

### Features

1. API Data Fetching:
   The backend periodically fetches stock data (e.g., AMZN for Amazon, AAPL for Apple) using the Yahoo Finance API. It updates the database every hour with the latest stock prices.
    To use the stock data feature:

    - Access Swagger UI.
    - Enter the stock code (e.g., AMZN for Amazon, AAPL for Apple) and your user ID (e.g., 1, 2) for created user.

2. Password Reminder:
   Users receive a password update reminder for specified interval. The system keeps track of user last password change dates and sends notifications when the next reminder is due.

