# InventoryManagement

## Overview

**InventoryManagement** is a professional Windows Forms application developed in C# for streamlined inventory, customer, category, product, and order management. Designed for small to medium-sized businesses, it provides an intuitive graphical interface that simplifies tracking, organizing, and analyzing all aspects of inventory management.

## Features

- **User Authentication**: Secure login system for authorized access.
- **User Management**: Add, update, and manage users.
- **Customer Management**: Manage customer records, including creation, updates, and search.
- **Category Management**: Organize products by categories for easy navigation and reporting.
- **Product Management**: Add, update, and delete products with detailed information.
- **Order Management**: Create and manage customer orders efficiently.
- **Search & Filter**: Quickly search for customers, products, and orders.
- **Data Persistence**: Uses SQL Server (LocalDB) for robust and reliable data storage.
- **Modular Design**: Each core function is separated into modules (User, Customer, Category, Product, Order).

## Technology Stack

- **Language**: C#
- **Framework**: .NET Framework 4.7.2
- **UI**: Windows Forms (WinForms)
- **Database**: SQL Server LocalDB (MSSQLLocalDB)
- **IDE**: Visual Studio

## Getting Started

### Prerequisites

- Visual Studio 2019 or newer
- .NET Framework 4.7.2
- SQL Server LocalDB

### Installation

1. **Clone the repository**:
   ```sh
   git clone https://github.com/Xhoangduy/InventoryManagement.git
   ```
2. **Open the solution** in Visual Studio.
3. **Restore NuGet packages** (if required).
4. **Update the connection string** in the code if your SQL Server LocalDB data path differs.
5. **Build and run** the application.

### Database Initialization

- The application uses a `.mdf` database file. Ensure the file path matches your environment.
- You may need to create or attach the database manually if it does not exist.

## Usage

- Launch the application.
- Login using authorized credentials.
- Use the sidebar to navigate between Users, Customers, Categories, Products, and Orders modules.
- Add, update, or search records as needed.

## Project Structure

```
HETHONGQUANLYKHO/
├── MainForm.cs                # Main interface
├── LoginForm.cs               # User authentication
├── UserModuleForm.cs          # User management
├── CustomerModuleForm.cs      # Customer management
├── CategoryModuleForm.cs      # Category management
├── ProductModuleForm.cs       # Product management
├── OrderModuleForm.cs         # Order management
├── Properties/                # App properties and resources
└── ...                        # Other source files
```

## Contributing

Contributions are welcome! Please fork the repository and submit a pull request for review.

## License

This project is currently unlicensed. Contact the repository owner for more details.

## Contact

- **GitHub**: [Xhoangduy](https://github.com/Xhoangduy)

---

*Professional Inventory Management System for efficient business operations.*
