<!--> Overall Site Purpose and Functionality <--!>
Using MVC, Web API, EF Core, and middleware, this site aims to simulate an indexing for registered professional cyclists.
There are five main entities linked to the navigation bar called Clients, Places, Feed, Bookings, and Itineraries.
Each entity is able to perform CRUD operations, with additonal swagger testing after linking the URL to /swagger.
In order to create a Client, a name, email, phone number, birthdate, and home address is required.
For Places, it requires name, location, description, and terrain difficulty.
For Fees, it requires TotalDue, PaymentReason, and Date of issuance.
For Booking, it requires Residency Address, Check in date, Check out date, and Booking Status.
For Itineraries, it requires the ClientId, PlaceId, FeeId, and BookingId.

<!--> Key dependencies and setup instructions <--!>
For Key dependencies, the following NuGet Packages are needed to be installed before running:
	Microsoft.EntityFrameworkCore
	Microsoft.EntityFrameworkCore.SqlServer
	Microsoft.EntityFrameworkCore.Tools
	Swashbuckle.AspNetCore (for Swagger)
Other dependencies exist like:
	using Microsoft.AspNetCore.Mvc;
For setup:
	-Open the solution and ensure you have this when managing User Secrets:
	~~~~~~~~~~~~~~~~~~
	{
    "ConnectionStrings": {
        "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ApplicationDbContext;Trusted_Connection=True;MultipleActiveResultSets=true"
    }
	~~~~~~~~~~~~~~~~~~
	-Secondly, you must download dependencies, update database, and then run the app using these commands in respective order: 
		dotnet tool install --global dotnet-ef
		dotnet ef database update --project "COMP003B.SP25.FinalProject.TanM"
<!--> Design inspirations and feature descriptions <--!>
Partial views are used to display cards of the data that are already registered.
The ApiClientsController is used to test swagger endpoints when redirecting the URL to /swagger.
}