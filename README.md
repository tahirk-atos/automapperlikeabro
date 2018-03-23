# AutoMapper like a bro!

This is a collection of projects demonstrating the common ways to use the latest version of AutoMapper including best practice patterns and examples.

#### The solution is split into several projects:
* **SQL Scripts** - SQL Scripts to be executed for creating demo data
* **AmDemo.WinApp** - WinForms applicaiton demo (AutoMapper, Autofac DI)
* **AmDemo.ConsoleApp** - Console Application demo (AutoMapper, Autofac DI)
* **AmDemo.Mvc**  - Model View Controller web application demo (Autonmapper, Autofac DI)
* **AmDemo.Core** - Contains common functions used across all projects
* **AmDemo.Data** - Data layer using Repository Pattern & EF Code First
* **AmDemo.Service** - Services common to all the demo applications
* **AmDemo.Test** - Contains the unit and integration tests (AutoMapper, Autofac DI, nunit)

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
The test project contains several different unit & integration tests which demonstrate some best practice patterns for Autofac and AutoMapper usage.

#### Demo projects

The following demo projects are available:

* AmDemo.ConsoleApp
* AmDemo.Mvc
* AmDemo.WinApp

##### AmDemo.WinApp:

This a WinForms demo built using C# & .NET Framework version 4.7 and features Autofac Dependancy Injection library, AutoMapper object-object mapper library and Entity Framework (Code First approach) with a Repository pattern for data access.

<ins>**Points of interest**</ins>

For the purpose of this demo several classes were created to provide the DI and mapping features:

* `Classes\AmDemoModule.cs` - Module registration class for Autofac DI
* `Classes\CustomerProfile.cs` - This is a profile instance used by AutoMapper (a way to organise mappings between layers)
* `Classes\FormHelper.cs` - A utility class that can be injected at runtime (provides support to the windows form class)
* `Classes\IFormHelper.cs` - A contract for the FormHelper.cs class (required for Autofac DI to work)
* `ViewModels\CustomerViewModel.cs` - A View Model for the UI presentation (also used for mapping)

The project also makes use of the AmDemo.Service project which provides a service class (_CustomerService.cs_) to interact with the data layer (AmDemo.Data project).

<ins>**Application flow:**</ins>

The main Windows Forms UI class (Form1.cs) has an event called btnGo_Click which is triggered when the UI button is pressed.
This event method first creates an IContainer object that contains the registered modules (telling Autofac what dependancies to register at runtime), these modules are registered inside the Classes\AmDemoModule.cs class using the
ContainerBuilder assembly that contains Register() methods to register various objects (types, services etc):
```csharp
            builder.RegisterType<CustomerService>().As<ICustomerService>();
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>();
            builder.RegisterType<FormHelper>().As<IFormHelper>();
            builder.RegisterType<AmDataContext>();
            builder.RegisterType<Form1>().AsSelf();
```
For further details on Autofac please review the documentation found here [readthedocs.io: Autofac](http://autofaccn.readthedocs.io).

The following line calls a custom method that registers the AutoMapper profile instances:
```csharp
            RegisterAutomapper(builder);
```
This method does the following:

* Gets a collection of the runtime assemblies
* Registers with the builder those assembly types that have a type of AutoMapper.Profile
* Next a complex registration is done using lambda expression (a delegate that points to a function which loops through the collection of assemblies found earlier and creates the relevant mapper configuration at runtime).

The `AsSelf()` extension simply tells Autofac that this component provides its own concrete registration service and the `SingleInstance()` ensures all registered components share the instance and finally the MapperConfiguration
class itself is registered as with the `InstancePerLifetimeScope()` applied to ensure all dependant components share the same shared instance (this greatly simplifies the DI registration process).

**Form1.cs** _continued_:

After registering the dependencies a new nested scope is created with the *using* code block.  This is a simple way of working with Autofac DI inside a WinForms or Console Application where you need to manually create the DI component
instances. Inside the using block the FormHelper class is retrieving from the scope (_provided the class type was registered in the Module class earlier the instance becomes available in the context of the scope_) and then the `GetCustomer()` 
method is called from the instance of the FormHelper.cs class:
```csharp
            var _formHelper = scope.Resolve<IFormHelper>();
            var customer = _formHelper.GetCustomer();
```
The FormHelper.cs class provides utility services to the Form1.cs class and is simply a pattern used to seperate code out (allowing for unit testing etc). The FormHelper.cs class uses constructor injection to satisfy dependencies so access
is made available to the CustomerService & Mapper classes.

The `GetCustomer()` method calls the customer service that provides a single cusotmer record obtained from the database (via the data layer and associated repository class); Finally an instance of CustomerViewModel is inflated dynamically by 
executing the mapping that has been configured, from the source to the destination (see the `CustomerProfile.cs` class) and this object is returned back to the calling point (Form1.cs):
```csharp
            var customer = _customerSerice.GetCustomers().FirstOrDefault();

            return  _mapper.Map<CustomerViewModel>(customer);
```
The CustomerViewModel object is checked to contain values and these values are then assigned to the appropriate UI elements:
```csharp
            tbFirstname.Text = customer.Firstname;
            tbLastname.Text = customer.Lastname;
            tbAge.Text = customer.Age.ToString();
            tbGender.Text = customer.Gender.ToString();
```
<ins>**Data layer:**</ins>

The data layer is found in the AmDemo.Data project and uses out of the box Entity Framework 6.2.0 package with Code First models and a repository pattern.

<ins>Points of interest</ins>

The repository class are derived from a generic base class (`BaseRepository.cs`) and use a constructor to pass an instance of the data context to the base 
class which removes the need to repeatedly instantiate the data context; The base class also takes care of disposing of the data context object.

#### References

* [AutoMapper documentation](http://docs.automapper.org)
* [Autofac documentation](http://autofaccn.readthedocs.io)
* [Implementing the Repository and Unit of Work Patterns in an ASP.NET MVC Application](https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application)
