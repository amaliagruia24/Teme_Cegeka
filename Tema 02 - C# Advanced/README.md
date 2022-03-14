# Tema 02 - C# Advanced

This project is an implementation of a REST Api for a minimal car dealership. It provides the following actions: listing all the available cars, adding, removing, 
updating and removing a car. Also, it has some customer actions: listing the customers, buying a car and listing all the customers filtered by a car model that they bought. 
I added register and login actions for the users, using jwt authentication.

All the data about the cars and customers are stored in the local memory. In the beggining of my implementation, I noticed a problem. Everytime I made an update on my list
of cars/customers and then I tried to list again all the data, the updates weren't there because new instances of the car class were made. In order to fix this problem, I created 
a repository folder containing a list object containing the data. In Program.cs I added a dependency injection to make my classes in this repository behave like a singleton
(one instance is permitted).

A REST Api uses HTTP requests to access and use data. I used GET methods to list data, POST, DELETE, PUT to add, remove and update a car. Also, the user can view a car by
introducing its ID. Same way to the customer controller. I tested all these functionalities using Swagger, the project doesn't have an interface yet. 

I implemeneted user authentication with jwt tokens. I used an encryption algorithm provided by a C# library to encript the password and make user authentication safe.
When an user is created, the information about the password is stored in a password hash(the encoding) and a password salt(an array of characters that is added to make the 
encription unique). Everytime an user logs in, it generates a token that has in the list of claims the name of the user. The generarted tokens can be checked using the site 
jwt.io.
