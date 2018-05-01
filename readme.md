# Co-op Student Technology Stack Assessment

**Table of Contents**

- [Meridian Technology Stack Assessment](#meridian-technology-stack-assessment)
- [Introduction](#introduction)
- [How to get started.](#how-to-get-started)
- [Questions](#questions)
    - [SQL Server](#sql-server)
    - [C# - Windows Console](#c---windows-console)
    - [C# - WebAPI](#c---webapi)
    - [Angular](#angular)

# Introduction

The purpose of this exercise is simply evaluating your knowledge, problem solving, and critical thinking when it comes to using a range of technology stacks.

While you follow through the exercises below, we ask you to keep a few things in mind.

- We don't expect you to know all the answers by heart. Technology is changing so quickly that it is almost impossible to complete a programming task without taking advantage of online resouces. But, we do ask that whenever you use these resources - such as SO - to please leave the link as a comment in your code.
- We will be logging on to your account on the machine provided to you, so please refrain from saving any personal data there. Please clear github cache as well once you are done. Please make sure you've pushed your code to your forked repository. 
- Make sure you have the proper .gitignore. Although this is not critical, it'd be good not to have to download gigabytes of packages with the repo.

# How to get started.

- You can RDP into our azure machine. the IP, username, and password has been emailed to you. Your environment is set up with VS 2017 Community, SQL Server Express 2016, SQL Server Management Studio 2017, NodeJS LTS, Angular 5, and dotnet Core 2 framework. Feel free to install any other packages your may need.
- Fork this repository, and then clone it in C:\Users\\[your_login]\Repos. Create a folder for each exercise below, and create your solutions, projects, and scripts in there.
- Make sure to commit after your done each item, with a proper commit comment.

# Questions

## SQL Server

1. Create a database, and name it `ProductsDB`.
1. Create a `Product` table with columns:
    - `ID (int)` as `Primary Key`. Self generated, increment by 1.
    - `Name (string)` to hold name of the product.
    - `Price (double)` to hold price of the product.
    - `Description (string)` to hold a description of the product.
2. Create the following products:

    | name | price | description |
    | :---: | :---: | :---: |
    | Dog Shampoo | 10.57 | shampoo for long hair dogs |
    | WD Red 4 TB | 150.99 | NAS hard drive |
    | 2018 Nissan Mourano | 37866.99 | Nissan Mourano AWD with Tech Package? |

3. Create a copy of `Product` table with all of its data into table `Product_Copy`
4. Delete the second row of `Product_Copy` table. 
5. Save all above queries in `Product.sql` under `SQL_Server` folder in your repo and commit.

## C# - Windows Console

1. Create a windows console project and name it `GuessTheFood` - .net version doesn't matter.
2. Program workflow:
    1. On start, the program will have a list of 5 foods:
        - Pizza
        - Pasta
        - Salmon
        - Steak
        - Miso
    2. The program then shows foods available to the user in the console.
    3. It then picks one of the foods randomly, and waits for user input to guess the name of the food.
    4. The user gets 3 tries.
    5. After each failed trial, a _Failure_ message will warn the user of the remaining trials left.
    6. Once the user has guessed correctly, show a _Congratulations_ message.
    7. Save your work under folder `C#_Windows`, and commit.

## C# - WebAPI

1. Create an ASP.NET Web API named `ProductAPI` - _.net core or framework 4.6+_.
2. Use No Authentication.
3. Ensure it runs on port `4201`.
4. Using `EntityFrameWork`, create the `Product` table as stated early in `#SQL Server.2` with database name `ProductsDBEF`
5. Create a `Migration`, and apply to the database. 
6. Create conroller `ProductsController` with following actions:
    1. `Get` will expect a _product id_, and if found, return the product.
    2. `GetAll` will return all products.
    3. `Edit` will get a _product id_, and the _updated prodct_. It'll then update the record in the database, and append `_editted` at the end of the _product name_. Once saved, will return _success message_.
    4. `Delete` will simply delete the product.
    5. `Add` will get a _product object_ from the user, and saves it into the database.
    6. Use `NLog` to log every time a product is added or removed. In the log, ensure the **Name** of the Product, its **ID**, and the **Action** taken is recorded. Have the log file saved to c:\logs\\[your_login_name]\
    7. Using the API create the three products mentioned in `#SQL Server.3`.
    8. Save your work under folder `C#_WebAPI`, and commit.

        **Note: Please do not use visual studio scaffolding.**

## Angular

1. Create a new angular project using _@angular/cli_, name it `ProductDashboard`.
2. Create an `HttpInterceptor` for all app web requests. The interceptor simply adds the following property to all responses:

    ```json
    {
        "httpInterceptor" : "DummyInterceptor"
    }
3. Create a service that calls to _http<nolink>://localhost:4201/api/products_
4. Implemenet Get, GetAll, Edit, Delete, and Add calls in this service. `ProductService`.
5. Create a component `ProductComponent`, import `ProductService`, and create the following _pages / partial_pages_
    1. Show list of all products. -  _this will be the main page_
    2. Allow user to submit an _id_, and return the product if found. - _do not use angular filter, rather utilize the server created earlier_
    3. On the product list page, add a _delete_ button for each product allowing the use to delete the product. On delete, let user know if _delete_ was successful, and ensure product list is updated.
    4. On the Product List page, add an _add_ button on top of the page. This button will open a dialogue / go to a different page where user can input _name, price, and description_ of the new product. On submit, let user know the new product as been successfully created. Redirect to product list page, and ensure the list of the products are updated.
6. Save your work under `Angular` folder, and commit. 
