# Database System for Insurance Company
## Overview
The following database model in SQL is for an insurance company. Additionally, it provides a Windows Forms application written in C#. The system will let different users log in as a client, agent, or administrator to use the database. Based on their role, they can do a number of operations: manage client data, operations concerning insurance policies, and administrative functions.

## Features
**Role-Based Login**: The user can log in as one of three roles: Client, Agent, or Administrator.

**Client Operations**: A client can view and manage their policies, claims, and personal information.

**Agent Operations**: An agent performs activities such as managing insurance policies and claims of clients.

**Administrator Operations**: An administrator can access the database completely and manages all users, policies, agents, and clients.

The system is powered by an SQL database at its backend, which would be formatted to store the key data for clients, policies, agents, and claims.

## Technologies Used
**C#**: Windows Forms application for the user interface.

**SQL Server**: SQL database to store and manage the insurance data.

## Installation
### Prerequisites
**Microsoft Visual Studio**: To run and develop the C# Windows Forms application.

**SQL Server**: This can be a local or remote setup of the database.
### Steps
**Clone the Repository**

Clone this repository into your local machine.

**Set Up the SQL Database**

Create the SQL database using the provided SQL scripts.

Execute the SQL scripts on your SQL Server to create tables, functions, views and triggers.

**Configure the Connection String**

Update the connection string in the App.config file (within the Windows Forms project) to point to your local or remote SQL Server instance.

**Build the Project**

Open the solution in Visual Studio and build the project. Ensure that all dependencies are properly referenced.

**Run the Application**

Launch the application from Visual Studio or build the executable and run it. You’ll be prompted to log in as either a client, agent, or administrator.

