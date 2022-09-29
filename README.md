
# CMPG 323 Project 3 : IoT Device Management Web APP
<img src="https://github.com/ChiefMonk/CMPG-323-Overview-37016776/blob/main/nwu_logo.jpg" width="200px" style="text-align:center;float:center;" />

### Table of Contents
1. [Introduction](#intro) 
2. [Project Structure and Controller Endpoints](#struc)
3. [Dependencies](#nuget)
4. [Contributors](#cont)
5. [References](#refs)

<a name="intro"></a>
## 1. Introduction
This is the third project of the CMPG 323 module deliverables. Smart devices such as voice controllers, security lights, smart locks and Wi-Fi-enabled devices can communicate and exchange data over the Internet. Devices form distributed ecosystems that can perform environmental monitoring of homes and buildings.

IoT device management is defined as the collection of processes, tools, and technologies that help you provision, monitor, and maintain the growing sprawl of connected objects (also called the Internet of Things endpoints or edge devices) in your home or enterprise network

An IoT Device Management System keeps track of the whereabouts of all IoT devices deployed by the organisation. Depending on the type of organisation, different categories of devices are used. Each IoT device is initially categorised and registered. Then, IoT devices are deployed throughout the organisation's buildings in predefined zones. Administrators can view all IoT devices, update their properties, add new devices and move them to other zones.


### 1.1 Entity Information
Therefore, for the complete and satisfactory operations of the IoT Device Management System, the following information is stored in the database about each entity:
* System User
    * User Name (Email Address)
    * Password 

* Category
    * Category ID
    * Category Name
    * Category Description
    * Date and Time Created

* Zone
    * Zone ID
    * Zone Name
    * Zone Description
    * Date and Time Created

* Device
    * Device ID
    * Device Name
    * Category ID
    * Zone ID
    * Status
    * Is Active
    * Date and Time Created


### 1.2 Entity Rules and Restrictions
The above entity information is stored in a relational database. The database tables do not have a complete set of constraints that could prevent or limit, for example the deletion of mandatory information.
Therefore most of the data integrity rules are enforced with the application (WebAPI), and the following are some of the applicable rules:

* System User
    * Must have a non-empty email address
    * Must have a non-empty strong password   

* Category
    * Must have a valid and unique GUID as a category id
    * Must have a non-empty category name
    * Must have a non-empty category description
    * Must have a valid creation date and time 
    * On creation, the category id is checked for uniqueness
    * A category with linked devices can not be deleted

* Zone
    * Must have a valid and unique GUID as a zone id
    * Must have a non-empty zone name
    * Must have a non-empty zone description
    * Must have a valid creation date and time 
    * On creation, the zone id is checked for uniqueness
    * A zone with linked devices can not be deleted

* Device
    * Must have a valid and unique GUID as a device id
    * Must have a non-empty device name
    * Must be assigned to a valid a category
    * Must be assigned to a valid a zone
    * Must have a valid and current status
    * Can be set to be active or not
    * Must have a valid creation date and time 
    * On creation, the zone id is checked for uniqueness
    * On creation or update, the zone id is checked if valid
    * On creation or update, the category id is checked if valid

<a name="struc"></a>
## 2. Project Structure and Controller Endpoints
The whole solution, named Project3.DeviceManagement.sln, is created using Visual Studio 2019 community edition. The solution has 2 projects:
* Project3.DeviceManagement.Data.csproj - has the Data Access Layer (DAL) functionality such as Entities, Repositories, and the DbContext.
* Project3.DeviceManagement.WebAPP.csproj - has any User Interface (UI) related functionalities such as Models, Views, Controllers, etc. 

The Web APP for this project is deployed at https://cmpg323-37016776-project3-webapp.azurewebsites.net. 

Just like the WebAPI, the WebAPP also has controllers that the Views communicate with to get and send data to the database:
* After registration and login with a valid email address and password
* All the following controller methods are marked with the [Authorize] tag, hence they an authenticated user to access.

 The following are the endpoints exposed, grouped per applicable controller:
* CategoryController (categories)
    * categories/index
        * Action: GET
        * Description: Gets all categories
        * Request: None
        * Response: IList<ModelCategory>
        * Authorize: Yes 
    * categories/details/{id} 
        * Action: GET
        * Description: Gets a particular category by its id
        * Request: GUID as id
        * Response: ModelCategory
        * Authorize: Yes      
    * categories/create 
        * Action: POST
        * Description: Creates a new category
        * Request: ModelCategory
        * Response: ModelCategory
        * Authorize: Yes 
    * categories/update/{id} 
        * Action: POST
        * Description: Updates or patches an existing category
        * Request: GUID as id and ModelCategory
        * Response: ModelCategory
        * Authorize: Yes
    * categories/delete/{id} 
        * Action: POST
        * Description: Deletes an existing category if no linked devices
        * Request: GUID as id
        * Response: Id of the deleted category
        * Authorize: Yes       

* ZoneController (zones)
   * zones/index
        * Action: GET
        * Description: Gets all zones
        * Request: None
        * Response: IList<ModelZone>
        * Authorize: Yes 
    * zones/details/{id} 
        * Action: GET
        * Description: Gets a particular zone by its id
        * Request: GUID as id
        * Response: ModelZone
        * Authorize: Yes      
    * zones/create 
        * Action: POST
        * Description: Creates a new zone
        * Request: ModelZone
        * Response: ModelZone
        * Authorize: Yes 
    * zones/update/{id} 
        * Action: POST
        * Description: Updates an existing zone
        * Request: GUID as id and ModelZone
        * Response: ModelZone
        * Authorize: Yes
    * zones/delete/{id} 
        * Action: POST
        * Description: Deletes an existing zone if no linked devices
        * Request: GUID as id
        * Response: Id of the deleted zone
        * Authorize: Yes

* DeviceController (devices)
    * devices/index
        * Action: GET
        * Description: Gets all devices
        * Request: None
        * Response: IList<ModelDevice>
        * Authorize: Yes 
    * devices/details/{id} 
        * Action: GET
        * Description: Gets a particular device by its id
        * Request: GUID as id
        * Response: ModelDevice
        * Authorize: Yes      
    * devices/create 
        * Action: POST
        * Description: Creates a new device
        * Request: ModelDevice
        * Response: ModelDevice
        * Authorize: Yes 
    * devices/update/{id} 
        * Action: POST
        * Description: Updates an existing device
        * Request: GUID as id and ModelDevice
        * Response: ModelDevice
        * Authorize: Yes
    * devices/delete/{id} 
        * Action: POST
        * Description: Deletes an existing device
        * Request: GUID as id
        * Response: Id of the deleted device
        * Authorize: Yes

<a name="nuget"></a>
## 3. Dependencies
The following nuget packages are referenced by the Project2.WebAPI project.

 | Package  |  Version  |  License  |
 | ---  |  ---  |  ---  |
 | [Microsoft.AspNetCore.Identity.EntityFrameworkCore](https://www.nuget.org/packages/Microsoft.AspNetCore.Identity.EntityFrameworkCore/3.1.28/)  |  3.1.28  |  [Apache 2.0](https://licenses.nuget.org/Apache-2.0)  |
 | [Microsoft.AspNetCore.Identity.UI](https://www.nuget.org/packages/Microsoft.AspNetCore.Identity.UI/3.1.28/)  |  3.1.28  |  [Apache 2.0](https://licenses.nuget.org/Apache-2.0)  |
 | [Microsoft.EntityFrameworkCore.Design](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Design/3.1.28/)  |  3.1.28  |  [Apache 2.0](https://licenses.nuget.org/Apache-2.0)  |
 | [Microsoft.EntityFrameworkCore.SqlServer](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/3.1.28/)  |  3.1.28  |  [Apache 2.0](https://licenses.nuget.org/Apache-2.0)  |
 | [Microsoft.EntityFrameworkCore.Tools](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools/3.1.28/)  |  3.1.28  |  [Apache 2.0](https://licenses.nuget.org/Apache-2.0)  |
 | [Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore](https://www.nuget.org/packages/Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore/3.1.28/)  |  3.1.28  |  [Apache 2.0](https://licenses.nuget.org/Apache-2.0)  |

<a name="cont"></a>
## 4. Contributors
* [Chipo Hamayobe (37016776)](https://github.com/ChiefMonk) - Project Lead

<a name="refs"></a>
## 5. References
### ASP.NET Core MVC
* [Get started with ASP.NET Core MVC](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-6.0&tabs=visual-studio)
* [Build web apps with ASP.NET Core for beginners](https://learn.microsoft.com/en-us/training/paths/aspnet-core-web-app/)
* [Choose an ASP.NET Core web UI](https://learn.microsoft.com/en-us/aspnet/core/tutorials/choose-web-ui?view=aspnetcore-6.0)
* [Tutorial: Get started with Razor Pages in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/razor-pages-start?view=aspnetcore-6.0&tabs=visual-studio)
* [Overview of ASP.NET Core MVC](https://learn.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-6.0)
* [ASP.NET MVC Overview](https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/overview/asp-net-mvc-overview)
* [Secure a .NET web app with the ASP.NET Core Identity framework](https://learn.microsoft.com/en-us/training/modules/secure-aspnet-core-identity)
* [Model in ASP.NET MVC](https://www.tutorialsteacher.com/mvc/mvc-model)
* [CMPG-323-IOT-Device-Management](https://github.com/JacquiM/CMPG-323-IOT-Device-Management)


### Design Patterns
* [Architectural principles](https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/architectural-principles#separation-of-concerns) 
* [Common web application architectures](https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures)
* [Architectural Patterns in .NET](https://www.c-sharpcorner.com/uploadfile/babu_2082/architectural-patterns-in-net/)
* [Dependency injection in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-3.1) 
* [C# Design Patterns](https://www.dofactory.com/net/design-patterns)
* [Design Patterns In C# .NET](https://www.c-sharpcorner.com/UploadFile/bd5be5/design-patterns-in-net/)


### Repository Pattern
* [Implementing the Repository and Unit of Work Patterns in an ASP.NET MVC Application](https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application)
* [Repository Pattern in ASP.NET Core – Ultimate Guide](https://codewithmukesh.com/blog/repository-pattern-in-aspnet-core/)
* [Repository Design Pattern in C# with Examples](https://dotnettutorials.net/lesson/repository-design-pattern-csharp/)
* [ASP.NET Core Web API – Repository Pattern](https://code-maze.com/net-core-web-development-part4/)
* [Repository Pattern in ASP.NET Core REST API](https://www.pragimtech.com/blog/blazor/rest-api-repository-pattern/)
* [Repository Pattern Implementation in ASP.NET Core](https://medium.com/net-core/repository-pattern-implementation-in-asp-net-core-21e01c6664d7)


### Microsoft Azure
* [Microsoft Azure Fundamentals: Describe cloud concepts](https://docs.microsoft.com/en-us/learn/paths/microsoft-azure-fundamentals-describe-cloud-concepts/)
* [The development process for Azure](https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/development-process-for-azure)
* [Azure hosting recommendations for ASP.NET Core web apps](https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/azure-hosting-recommendations-for-asp-net-web-apps)
* [Web App for Containers](https://azure.microsoft.com/en-us/products/app-service/containers/#overview)
* [Azure App Service](https://azure.microsoft.com/en-us/products/app-service/#overview)



