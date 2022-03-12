# About Project

**This challenge developed for how to use Dapper with CQRS design pattern**.

This project is an **ASP.NET Core Web Api** project which is developed with **Dapper** and **Mssql Server.** 

Two main tasks :
1. Get person by email from this 3 tables (Person, ContactPoint, HumanName). Database name "[ManagePerson]" ,  result -> Name, Family, Given , Email, Phone
2. Edit the Family, Given, mobile number.

 ### Get Started
1. Clone repository in Visual Studio 2019.
2. Execute T-SQL script file at **ManagePerson.Entity/Assests/ManagePersonDatabase.sql** with **Microsoft SQL Server Management Studio** or
**Command Prompt Window** check here how to do => https://docs.microsoft.com/en-us/sql/ssms/scripting/sqlcmd-run-transact-sql-script-files?view=sql-server-ver15#run-the-script-file  
3. Run project with **F5**.
4. Manage **GET** and **PUT** methods via **Swagger.UI** or use **Postman** with using **ManagePerson.Entity/Assests/ManagePerson.postman_collection.json** file.
5. POST and DELETE methods can be created.
6. Unit Tests can be developed.


