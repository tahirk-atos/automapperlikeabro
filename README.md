# Automapper like a bro!

This is a collection of projects demonstrating the common ways to use the latest version of Automapper including best practice patterns and examples.

#### The solution is split into several projects:
* SQL Scripts - SQL Scripts to be executed for creating demo data
* AmDemo.WinApp - WinForms applicaiton demo (Automapper, Autofac DI)
* AmDemo.ConsoleApp - Console Application demo (Automapper, Autofac DI)
* AmDemo.Mvc  - Model View Controller web application demo (Autonmapper, Autofac DI)
* AmDemo.Core - Contains common functions used across all projects
* AmDemo.Data - Data layer using Repository Pattern & EF Code First
* AmDemo.Service - Services common to all the demo applications
* AmDemo.Test - Contains the unit and integration tests (Automapper, Autofac DI, nunit)

#### What you need to get started

This demo is best served up with a version of SQL Server and I recommend SQL Server Express Edition which can be found at the following location:

[Download SQL Server Express Editions](https://www.microsoft.com/en-gb/sql-server/sql-server-editions-express)

Run the installation and accept the standard SQL Express settings then either [download SQL Management Studio](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms) 
or use your favourite client to log into your instance of SQL Server and execute the following script:

`SQL Scripts\CreateAmDemoAndData.sql`

This script will create the demo database and populate the Customers table with some test data.

#### Working with the solution

Clone the repository to your local development environment (git bash example but you may use your favourite git client). 
Change to your solution directory and running the following command where you would like to clone the repository

`git clone https://github.com/tahirk-atos/automapperlikeabro.git`

Open the project in Visual Studio (2017 edition recommended) and then right-click the solution (top level) and left-click on the **Manage Nuget Pacakges for Solution..** option to display the
nuget package manager.  A restore button should appear on the top right of this dialog, left-click the restore button to start restoring any missing packages required by the solution.

You will need to modify the Application Configuraiton files reflecting your local SQL Server details, for example setting the correct database server and database details:
```
<connectionStrings>
<add name="Database1" connectionString="data source=DESKTOP-CFDHIP6\SQLEXPRESS;initial catalog=AmDemo;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework" providerName="System.Data.SqlClient" />
</connectionStrings>
```
Select the **AmDemo.Test** project and then using your preferred Test Runner execute the unit & integration tests.

#### Demo projects

Curently the following demo applications are active (more will be added to this list as they are completed & updated):

* AmDemo.WinApp

##### AmDemo.WinApp:

This a WinForms demo built using C# & .NET Framework version 4.7 and features Autofac Dependancy Injection library, AutoMapper object-object mapper library and Entity Framework (Code First approach) with an Repository pattern for data access.

<ins>Points of interest</ins>

For the purpose of this demo several classes were created to provide the DI and mapping features:

* Classes\AmDemoModule.cs - Module registration class for Autofac DI
* Classes\CustomerProfile.cs - This is a profile instance used by AutoMapper (a way to organise mappings between layers)
* Classes\FormHelper.cs - A utility class that can be injected at runtime (provides support to the windows form class)
* Classes\IFormHelper.cs - A contract for the FormHelper.cs class (required for Autofac DI to work)
* ViewModels\CustomerViewModel.cs - A View Model for the UI presentation (also used for mapping)



