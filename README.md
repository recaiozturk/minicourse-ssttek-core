# MiniCourse

The mini course project, in its simplest definition, is a project where a web API and a web client communicate via REST services, the security of this communication is ensured using JWT tokens, and it also includes a fake payment system.

## Tech Stack 

### .Net Core
- I used **.NET Core 8** for the backend of the application
- I made an effort to utilize systems like **ViewComponents, TagHelpers, GlobalFilters, Extensions, and Interceptors (Handlers)** as much as possible.

### Database 
- I used **SQL Server** as the database and **EntityFramework** on the **ORM** side.
- I preferred the **Code First** approach.
- I used the **generic repository** pattern and **unit of work** pattern in managing the transaction operations

### Mapping 
- I used **AutoMapper** as the mapping library for transformations between ViewModel, DTO, and Entity.

### Validations 
- I used **FluentValidation** for validation processes, ensuring that input data is checked against predefined rules in a clean and maintainable manner.
- This approach enhances code readability and centralizes validation logic, making the system more robust and easier to extend.

### Error Management 
- I managed error handling by defining a GlobalFilter in the application.
- Encountered errors were logged using the **NLog library**.
- Additionally, I enabled users to view these logs with detailed information on the admin panel, providing transparency and easier debugging.

### Front-End
- I used **Bootstrap** for the overall design of the application and wrote custom **CSS** when necessary.
- For user notifications, I implemented **SweetAlert2**.
- The interaction between the server and client was facilitated using **AJAX** and **jQuery**.

## How to Use

Follow these steps to run the MiniCourse application after cloning the repository:

**1. Clone the Repository**
```
git clone https://github.com/your-repository-url  
cd MiniCourse
```

**2. Configure the Application Settings**

Navigate to the MiniCourse.API layer and open the appsettings.json file. Update the connection string with your database details:
```
"ConnectionStrings": {  
  "SqlServer": "Data Source=<Your Database Server>;Initial Catalog=<Your Database Name>;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"  
} 
```
- The admin login credentials are specified in the MiniCourse.Repository layer, inside the Shared - AppDbContext.cs file, and are set during database creation through the SeedData method. If you wish, you can change these credentials before creating the database.

**3. Set Up the Database**

Ensure the MiniCourse.Repository layer is selected in the Package Manager Console.
- Create the Initial Migration
Run the following command to create the first migration:
```
Add-Migration InitialCreate  
```
- Apply the Migration to the Database
Once the migration is successfully created, update the database with this command:
```
Update-Database  
```
- If you see a Success message, your database is ready to use.

**4. Configure the Logging System with NLog**

To ensure the logging system works properly with NLog, follow these steps:
- Open the nlog.config file in the MiniCourse.API layer.
- Modify the last target section of the file as follows:
```
<target name="database" xsi:type="Database">
  <connectionString>Data Source=<Your Database Server>;Initial Catalog=<YourDatabaseName>;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False</connectionString>
  <commandText>
    insert into dbo.Log (
      MachineName, Logged, Level, Message,
      Logger, Exception
    ) values (
      @MachineName, @Logged, @Level, @Message,
      @Logger, @Exception
    );
  </commandText>
</target>
```
- Execute the above SQL command on your SQL Server for the database specified in the connection string. This will create the necessary table for logging.

**5. Run the Application**

To run the application, you need to start both the API and the Web UI layers. Follow these steps:
- In Visual Studio, right-click the solution and select Set Startup Projects.
- Choose Multiple startup projects, and set both MiniCourse.API and MiniCourse.WebUI to Start.
- Once both projects are set to start, press F5 or click Start in Visual Studio to run the application.
  
