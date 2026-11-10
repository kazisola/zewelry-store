# Zewelry Store

A small jewelry store web app built with C# and ASP.NET Core MVC. Customers browse products, add them to a cart and place orders. Store staff manage the product catalog and materials.

## Stack

- C# / .NET 10
- ASP.NET Core MVC with Razor views
- Entity Framework Core 10 (code-first, SQL Server)
- ASP.NET Core Identity for registration and login

## Features

- Browse products and add them to a cart (cart is kept in session)
- Place an order and view your order history (login required)
- Create, edit and delete products, with category, materials and image upload
- Create, edit and delete materials
- Seeded categories, materials and sample products

## Project layout

```
ZewelryStore/
├── Controllers/   Product, Order and Ingredient (materials) controllers
├── Models/        Entities, view models, generic repository, query options
├── Data/          DbContext, seed data, EF Core migrations
├── Views/         Razor views
└── Program.cs     Service registration and request pipeline
```

## Design notes

- **Generic repository.** `Repository<T>` wraps common data access (get, add, update, delete). `QueryOptions<T>` lets callers pass a filter, ordering and `Include` paths without writing a new method per entity.
- **Data model.** Products belong to a category and have many materials through a `ProductIngredient` join entity with a composite key. Orders have many order items, each tied to a product and a user.
- **Migrations and seeding.** The schema is managed with EF Core migrations, and starter data is seeded in `OnModelCreating`.
- **Cart.** The cart is stored as JSON in session through a small `ISession` extension.

## Running locally

Requirements: .NET 10 SDK and SQL Server LocalDB (installed with Visual Studio on Windows). To use another SQL Server instance, change `DefaultConnection` in `appsettings.json`.

```
git clone https://github.com/kazisola/zewelry-store.git
cd zewelry-store/ZewelryStore
dotnet tool install --global dotnet-ef
dotnet ef database update
dotnet run
```

Then open the URL printed in the console (`https://localhost:7041` by default). Registration requires account confirmation; in development the confirmation link is shown on the page after you register.

## Upcoming steps

- Role-based access so only admins can manage products and materials
- Inject repositories through dependency injection instead of creating them in controllers
- Reduce stock when an order is placed
- Unit tests for the repository and controllers
