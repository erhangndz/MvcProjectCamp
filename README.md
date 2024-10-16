# MvcProjectCamp

MvcProjectCamp is a comprehensive web application developed using the ASP.NET MVC framework. It is designed to simulate a real-world **technology dictionary** application, built with a layered architecture and adhering to **SOLID principles**. This project was developed as part of a camp education parallel to Murat Yücedağ’s MVC tutorials.

## Features

The project incorporates several key features:

- **Role-based access control**: Includes separate panels for **administrators** and **authors**.
- **Admin Panel**: Allows management of users, posts, categories, messages, and site statistics.
- **Author Panel**: Enables authors to create, edit, and manage their own content.
- **Responsive Design**: Built with **Bootstrap**, ensuring compatibility across devices.
- **CRUD Operations**: Full CRUD capabilities for managing dictionary entries and users.
- **Security**: Implemented authentication and authorization mechanisms.

## Technology Stack

The project leverages several modern technologies and design patterns:

- **ASP.NET MVC5**: The core framework for building the application.
- **Entity Framework (Code-First)**: ORM used to handle database operations and migrations.
- **SQL Server**: Relational database management system.
- **Bootstrap**: For responsive, mobile-first front-end development.
- **Fluent Validation**: For handling user input validations.
- **N-Tier Architecture**: Separating business logic, data access, and UI to create a modular, maintainable project.

## Project Architecture

This project follows the **N-Tier Architecture**, splitting the application into several layers:

1. **Presentation Layer (UI)**: Responsible for user interaction, developed using ASP.NET MVC and Bootstrap.
2. **Business Logic Layer (BLL)**: Contains business rules and validations.
3. **Data Access Layer (DAL)**: Manages database operations using Entity Framework.
4. **Entity Layer**: Contains model definitions representing the database structure.

## Installation

To get a copy of the project running locally, follow these steps:

1. **Clone the repository**:
   ```bash
   git clone https://github.com/your-username/MvcProjectCamp.git
