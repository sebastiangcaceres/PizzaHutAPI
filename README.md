# PizzaHutAPI

The project is a REST API for pizza delivery. The customer is the Pizza Hut company.

Contains the following entities:

- Client
  - Name
  - Surname
  - Email
  - Password
- Delivery address
- Order
  - Client
  - Delivery address
  - List of pizzas
  - Order cost
  - Order status
  - Date and time the order was created
  - Date and time of order delivery
  - A comment
- Order status
- Pizza

The customer must be logged in to place an order. JWT token is used for authorization.

The API must contain the following operations:
- Client registration. When registering, the client is assigned the "User" role. The client specifies the name, surname and mail. Mail must be unique. When registering, the client is assigned a unique identifier. Delivery addresses are specified during registration.
- Client authorization
- Create an order
- Getting a list of orders with the ability to filter by order status, customer, date and time of creation and date and time of delivery
- Getting an order by id
- Order update
- Deleting an order
- Getting a list of pizzas

## Implementation requirements

- Use Clean Architecture as the basis of the project architecture
- PostgreSQL must be used as a database
- To implement the API, use ASP.NET Core Web API 6
- Use JWT token for authorization
- For registration and authorization use Identity
- To implement data operations, use the Entity Framework Core (Repository pattern and Unit of Work). Database schema management must be implemented using migrations.
- Use Swagger to describe the API
- Use FluentValidation to validate input data
- For mapping Mapster
- For testing use xUnit
- List of orders must support pagination


In case of an error, the following JSON should be returned:

```json
{
   "type": "https://tools.ietf.org/html/rfc7231#section-6.6.1",
   "title": "An error occurred while processing your request.",
   "status": 400,
   "traceId": "00-9d236a912a0d8460a8ef4b8649160a07-2f1444c77fb87a77-00",
   "detailedMessage": "X-Code-Company Header is required"
}
```

Where:
detailedMessage - detailed error description, may contain additional information.

Nice to have:
- docker compose configuration for launching the project
