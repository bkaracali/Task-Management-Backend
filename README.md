# Sequential-Task-Management-System
ITU C# Semester Project


API Veri Çekme:

Belirli aralıklarla bir API'den veri alıp sisteminize işlemek.
Örnek: "Her saat döviz kurlarını API'den çek ve güncelle."

Şifre Hatırlatmaları:

Kullanıcılara düzenli olarak şifrelerini güncelleme hatırlatması gönderme.
Örnek: "Her 6 ayda bir tüm kullanıcılara şifre yenileme bildirimi gönder."

  Kullanıcıyı bilgilendirmek amacıyla verilen tüm tasklarin basarılı olma durumuna gore taskları kontrol eden baska bır task 
  API'den alınan döviz verileri ile kullanıcılara belirli döviz aralıklarında bildirim gönderme.
Şifre güncelleme hatırlatması yapan bir job, sadece döviz kurlarında anormal bir değişim olduğunda (örneğin %10'luk bir artış) ek bir uyarı gönderebilir.


# ITU C# Semester Project - Notification and Task Management System

Welcome to the **Notification and Task Management System**, a project developed as part of our Object-Oriented Programming with C# class at Istanbul Technical University. This system combines API data retrieval, task scheduling, and notifications to manage various user tasks effectively.

### Project Overview

This project consists of a backend built with .NET and PostgreSQL, along with a notification system for users. The core features include:
- **API Data Retrieval**: Periodic retrieval of data from an external API (currency exchange rates) to update the system.
- **Password Reminder Notifications**: Sending reminders to users to update their passwords at regular intervals.
- **Task-based Notification System**: Based on conditions like currency exchange rate fluctuations or password update reminders, the system sends notifications to users.

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
   The backend periodically fetches currency exchange rates from a specified API. It updates the database every hour with the latest rates.

2. Password Reminder:
   Users receive a password update reminder every 6 months. The system keeps track of user last password change dates and sends notifications when the next reminder is due.

3. Task-based Notifications:
   The system triggers notifications based on task success or failure, including updates from the API.
   Additionally, when an anomaly is detected in the currency exchange rate (e.g., a 10% increase), users will receive an alert about the significant change.
