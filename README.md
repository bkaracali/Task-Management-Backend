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

You can set up PostgreSQL either manually or using Docker for convenience.

1. **Install Docker**:
   If you don’t already have Docker installed, download and install it from [Docker's website](https://www.docker.com/)

2. **Use Docker Compose**:
    A pre-configured docker-compose.yml file is provided in the repository to simplify setup. You can find it in the root directory of the project. To start PostgreSQL using Docker Compose, run:
     ```bash
    docker-compose up -d
    ```
    This will set up a PostgreSQL instance with default credentials specified in the docker-compose.yml file.

3. **Connect to PostgreSQL**:
    Use DBeaver or any PostgreSQL client to connect to the container with the following details:
   
    - Host: localhost

    - Port: 5432

    - User: Check docker-compose.yml for the username

    - Password: Check docker-compose.yml for the password

    - Database: Check docker-compose.yml for the database name

4. **Create the Schema and Sequences**:
   Use the following SQL script (ddl) to create the necessary schema, sequences, and tables for the project. You can execute this script in your PostgreSQL database management tool (e.g., DBeaver):
   [Download Database Setup SQL](./scripts/ddl.sql)

### Features

1. API Data Fetching:
   The backend periodically fetches stock data (e.g., AMZN for Amazon, AAPL for Apple) using the Yahoo Finance API. It updates the database every hour with the latest stock prices.
    To use the stock data feature:

    - Access Swagger UI.
    - Enter the stock code (e.g., AMZN for Amazon, AAPL for Apple) and your user ID (e.g., 1, 2) for created user.

2. Password Reminder:
   Users receive a password update reminder for specified interval. The system keeps track of user last password change dates and sends notifications when the next reminder is due.
    
    - Access Swagger UI.
    - Provide the following details:
        - User ID: The ID of the user who should receive the password reminder (e.g., 1, 2).
        - Password Task ID: The ID of the password reminder task.
        - Default Message: The message to be sent as a reminder (e.g., "Your password needs to be updated soon").
        - Reminder Interval: The time interval after which the user will be reminded to change the password (e.g., 0: 0: 30 meaning 30 seconds).

