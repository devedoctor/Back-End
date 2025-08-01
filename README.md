Hotel Management System - ASP.NET Core MVC with SQL Server
Below is a complete implementation of a Hotel Management System using ASP.NET Core MVC and SQL Server. This solution includes models, views, controllers, database context, and professional styling with Bootstrap and CSS.

Project Structure
text
HotelManagementSystem/
├── Controllers/
│   ├── AccountController.cs
│   ├── BookingController.cs
│   ├── GuestController.cs
│   ├── HomeController.cs
│   ├── RoomController.cs
│   └── StaffController.cs
├── Data/
│   └── HotelDbContext.cs
├── Models/
│   ├── Booking.cs
│   ├── Guest.cs
│   ├── Room.cs
│   ├── Staff.cs
│   └── User.cs
├── Views/
│   ├── Shared/
│   │   ├── _Layout.cshtml
│   │   └── _ValidationScriptsPartial.cshtml
│   ├── Account/
│   ├── Booking/
│   ├── Guest/
│   ├── Home/
│   ├── Room/
│   └── Staff/
├── wwwroot/
│   ├── css/
│   │   └── site.css
│   ├── images/
│   │   ├── bg1.jpg
│   │   ├── bg2.jpg
│   │   └── logo.png
│   └── js/
│       └── site.js
└── appsettings.json

 we've implemented:

Admin-Only User Management:

Edit existing users (username, password, role)

Secure access with [Authorize(Roles = "Admin")]

Seamless Integration:

Added to your existing AccountController

Matches your current authentication system

Consistent with your application's styling

Complete CRUD Operations:

Create (Register)

Read (Manage Users list)

Update (Edit User)

Delete (Existing functionality)

To access these new features:

Log in as an admin

Navigate to "Manage Users" in the navigation bar

Click "Edit" on any user to modify their details
-------------------------------------------------------------------
