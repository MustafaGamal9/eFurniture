

# eFurniture - ASP.NET Core MVC E-commerce Platform

  

![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white) ![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white) ![ASP.NET MVC](https://img.shields.io/badge/ASP.NET%20MVC-512BD4?style=for-the-badge&logo=.net&logoColor=white) ![Entity Framework Core](https://img.shields.io/badge/EF%20Core-512BD4?style=for-the-badge&logo=c-sharp&logoColor=white) ![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)

  
eFurniture is a simple  e-commerce web application built with the classic **ASP.NET Core MVC** pattern. It serves as a showcase for building a modern, data-driven online store for furniture products, demonstrating key principles of web development with the .NET stack.

 
[View live demo](http://efurn.runasp.net/)

  [![Screenshot-7.jpg](https://i.postimg.cc/vTQH4xc5/Screenshot-7.jpg)](https://postimg.cc/XGz0hJKv)

## ✨ Key Features

  

-  **User Authentication:** Secure user registration and login system using ASP.NET Core Identity with cookie-based authentication.

-  **Product Catalog:**

- Browse products by `Category` (e.g., Desks & Chairs, Sofas).

- Browse products by `Room` (e.g., Living Room, Bedroom, Office).

- View detailed information for each product.

-  **Shopping Cart:** A fully functional session-based shopping cart allowing users to add, view, and manage items before purchase.

-  **Checkout Process:** A streamlined checkout flow to finalize orders.


-  **Homepage:** A dynamic homepage featuring hero sections, featured products, and special offers.


  

## 🚀 Technology Stack

  

-  **Framework:**  **ASP.NET Core 9**

-  **Language:**  **C#**

-  **Architecture:**  **Model-View-Controller (MVC)**

-  **Database:**  **SQL Server**

-  **Object-Relational Mapper (ORM):**  **Entity Framework Core**

-  **Authentication:**  **ASP.NET Core Identity** with Cookie Authentication.

-  **Frontend:**  **Razor Views** with server-side rendering, styled with **Bootstrap** and enhanced with **jQuery**.

  



## ⚙️ Getting Started

Follow these instructions to get a copy of the project up and running on your local machine for development and testing.

 

### Installation & Setup

  

1. **Clone the repository:**

```sh

git clone https://github.com/mustafagamal9/eFurniture.git

cd eFurniture

```

  

2. **Configure the Database Connection:**

- Open the `eFurniture/appsettings.json` file.

- Locate the `ConnectionStrings` section.

- Update the `EFurnitureDbContext` value to point to your local SQL Server instance.

  

**Example for local SQL Server Express:**

```json

"ConnectionStrings": {

"EFurnitureDbContext": "Server=.\SQLEXPRESS;Database=eFurnitureDB;Trusted_Connection=True;TrustServerCertificate=True"

}

```

  

3. **Apply Database Migrations:**

- Open a terminal or command prompt in the `eFurniture/` directory (the one containing the `.csproj` file).

- Run the following command. This will create the database and apply the table schemas based on the existing migrations.

```sh

dotnet ef database update

```

  

4. **Run the Application:**

- You can run the project from Visual Studio by pressing `F5`, or by using the .NET CLI:

```sh

dotnet run

```

