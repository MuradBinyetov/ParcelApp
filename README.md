# ParcelApp
Application is a delivery application.


The application was created with a microservice architecture. ApiGateway was used.

The redirects in the application are made through ApiGateway. All requests should be made to the url http://localhost:5112. Additionally, you can see how all requests are received in the ocelot.json file in the ApiGateway project.
There are 3 types of users in the application. (Admin, User, Courier). 
When the project starts, the Admin user is created by default.
Admin username - "Admin" password is "admin162134Ws!". 
Users can register and create orders. They can cancel orders. They can edit the destination of the order, view the details of the order. They can view the list of orders belonging to them. 

Admin user can see all orders. They can assign couriers to orders. They can see couriers. 

Courier user can see the orders assigned to them. They can change the status of the order. They can view the details of the order.