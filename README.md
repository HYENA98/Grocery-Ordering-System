# 🛒 Grocery Ordering System for Old Age Home

A comprehensive Windows Forms application built in VB.NET designed to streamline grocery ordering and management for an old age home. 

This practical project was developed as part of the ICT3715 (Information and Communication Technology Project) module at UNISA.

## Features

### Member Portal (Residents)
*   **Secure Access:** Members log in using their unique ID (e.g., `01-01`).
*   **Order Creation:** Browse available groceries and add them to a personal cart (with an automated limit of 12 items per order).
*   **Order Management:** Members can view and edit their existing order anytime before the Friday cutoff.
*   **Image Preview:** View images of grocery items before ordering.

### Admin Portal (Matrons)
*   **Secure Login:** Admin functions are protected by a master password.
*   **Inventory Management:** Add, update, or remove grocery items and set their availability.
*   **Member Management:** Register new residents and update their contact details.
*   **Consolidated Order Lists:** View a combined list of all items needed for the week based on member orders.
*   **PDF Reporting:** Generate and export bulk order lists and individual member summaries using **PDFsharp**. Files are automatically saved into dated folders.
*   **MIS Reporting:** Analyze ordering trends (Top/Low ordered items) and calculate member participation percentages over custom date ranges.

## Tech Stack
*   **Language:** VB.NET (.NET Windows Forms)
*   **Database:** Microsoft SQL Server (SSMS)
*   **Libraries:** 
    *   `Microsoft.Data.SqlClient` (Database connectivity)
    *   `PDFsharp` (PDF generation)

## Getting Started (Local Setup)

Follow these steps to run the project on your local machine.

### Prerequisites
*   Visual Studio (with **.NET desktop development** workload installed).
*   SQL Server Management Studio (SSMS).

### 1. Database Setup
1. Open SSMS and create a new database (e.g., `GrocerySystemDB`).
2. Open the `DatabaseSetup.sql` file included in this repository.
3. Run the script to generate the `tblMembers`, `tblGroceryItems`, and `tblMemberOrders` tables along with sample data.

### 2. Application Setup
1. Clone this repository to your local machine.
2. Open the solution file (`.sln`) in Visual Studio.
3. In *Solution Explorer*, right-click the project and select *Manage NuGet Packages*. Ensure `PDFsharp` and `Microsoft.Data.SqlClient` are installed.
4. Open `GModDatabase.vb` and update the `CONNECTION_STRING` with your SQL Server instance name:
   ```vb.net
   "Data Source=YOUR_SERVER_NAME;Initial Catalog=GrocerySystemDB;Integrated Security=True;TrustServerCertificate=True"