# StarWars Store
[![.NET](https://github.com/TheLe0/StarWars/actions/workflows/dotnet.yml/badge.svg)](https://github.com/TheLe0/StarWars/actions/workflows/dotnet.yml)

## INTRODUCTION
A REST API of an Star Wars Store. 
In this API you can do the following actions:

* Create a user;
* Authenticate a user;
* Insert a product;
* List all products;
* Create a transaction;
* List all purchases;
* List all purchases of a specific user;

## SPECIFICATIONS
This project was built using:

* .NET 5
* Docker
* PostgreSQL
* Redis
* Entity Framework Core
* JWT
* .ENV
* Bcrypt
* MS Test

## Routes

### POST `starstore/user/create`

This endpoint is for creating a new user. 

> Note:
> This action can only be done by a user with the Sysadmin 
> or the Moderator roles.

```json
{
   "username": "admin",
   "password": "admin"
}
```

The response for this request is going to be the JWT token of the created user.

```json
{
   "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c"
}
```

### POST `starstore/user/auth`

This endpoint is for authenticate an user 

> Note:
> This is the only endpoint that the user don't need
> to be authenticated to execute.

```json
{
   "username": "admin",
   "password": "admin"
}
```

The response for this request is going to be the JWT token of the authenticated user.

```json
{
   "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c"
}
```

### POST `/starstore/product`

This endpoint is for creating a new product, with the following structure.

```json
{
   "title":"Star Wars The Complete Saga - PC",
   "price": 35.99,
   "zipcode":"78993-000",
   "seller": "STEAM",
   "thumbnailHd":"https://cdn.akamai.steamstatic.com/steam/apps/32440/header.jpg?t=1604517910g",
   "date":"12/11/2009"
}

```
| Field       | Type   |
|-------------|--------|
| title       | String |
| price       | Double |
| zipcode     | String |
| seller      | String |
| thumbnailHd | String |
| date        | String |


### GET `/starstore/products`

This is going to return all the products registered. This request
uses cache, for reduce the query time. The cache is always update when
a new product is inserted.

```json
[
  {
      "title":"Star Wars The Complete Saga - PC",
      "price": 35.99,
      "zipcode":"78993-000",
      "seller": "STEAM",
      "thumbnailHd":"https://cdn.akamai.steamstatic.com/steam/apps/32440/header.jpg?t=1604517910g",
      "date":"12/11/2009"
  },
  {
    "title": "Funko Pop Star Wars Episode 9 Rise of Skywalker 308 Kylo Ren",
    "price": 151.98,
    "zipcode": "13500-110",
    "seller": "GameGames",
    "thumbnailHd": "https://m.media-amazon.com/images/I/71xdjltlMrL._AC_SL1300_.jpg",
    "date": "26/11/2015"
  },
  {
    "title": "Lightsaber",
    "price": 150000,
    "zipcode": "13537-000",
    "seller": "Mario Mota",
    "thumbnailHd": "http://www.obrigadopelospeixes.com/wp-content/uploads/2015/12/kalippe_lightsaber_by_jnetrocks-d4dyzpo1-1024x600.jpg",
    "date": "20/11/2015"
  }
]
```

| Field       | Type   |
|-------------|--------|
| title       | String |
| price       | Double |
| zipcode     | String |
| seller      | String |
| thumbnailHd | String |
| date        | String |


### POST `/starstore/buy`

This method receive the shopping cart of an user, with the total amount and
his credit card information

```json
{
   "client_id":"7e655c6e-e8e5-4349-8348-e51e0ff3072e",
   "client_name":"Luke Skywalker",
   "total_to_pay":1236,
   "credit_card":{
      "card_number":"1234123412341234",
      "cvv":"789",
      "card_holder_name":"Luke Skywalker",
      "exp_date":"12/24"
   }
}

```

+ Transaction

| Field        | Type       |
|--------------|------------|
| client_id    | Guid       |
| client_name  | Guid       |
| total_to_pay | Double     |
| credit_card  | CreditCard |

+ CreditCard

| Field            | Type   |
|------------------|--------|
| card_number      | String |
| card_holder_name | String |
| cvv              | String |
| exp_date         | String |

And the response is going to be:

```json
[
   {
      "client_id":"7e655c6e-e8e5-4349-8348-e51e0ff3072e",
      "purchase_id":"569c30dc-6bdb-407a-b18b-3794f9b206a8",
      "value":1234,
      "date":"19/08/2016",
      "card_number":"**** **** **** 1234"
   }
]
```

Every transaction successfully created, generates a purchase

### GET `/starstore/history`

This endpoint lists all the purchases made. Like the products one,
this uses cache for speed up the requests.

```json
[
   {
      "client_id":"7e655c6e-e8e5-4349-8348-e51e0ff3072e",
      "purchase_id":"569c30dc-6bdb-407a-b18b-3794f9b206a8",
      "value":1234,
      "date":"19/08/2016",
      "card_number":"**** **** **** 1234"
   },
   {
      "client_id":"7e655c6e-e8e5-4349-8348-e51e0ff3072e",
      "purchase_id":"569c30dc-6bdb-407a-b18b-3794f9b206a8",
      "value":1234,
      "date":"19/08/2016",
      "card_number":"**** **** **** 1234"
   },
   {
      "client_id":"7e655c6e-e8e5-4349-8348-e51e0ff3072e",
      "purchase_id":"569c30dc-6bdb-407a-b18b-3794f9b206a8",
      "value":1234,
      "date":"19/08/2016",
      "card_number":"**** **** **** 1234"
   }
]
```
| Campo            | Tipo   |
|------------------|--------|
| card_number      | String |
| cliend_id        | Guid   |
| value            | Double |
| date             | String |
| purchase_id      | Guid   |

### GET `/starstore/history/{clientId}`

This is like the last one request, but with the possibility to filter by client

```json
[
   {
      "client_id":"7e655c6e-e8e5-4349-8348-e51e0ff3072e",
      "purchase_id":"569c30dc-6bdb-407a-b18b-3794f9b206a8",
      "value":1234,
      "date":"19/08/2016",
      "card_number":"**** **** **** 1234"
   },
   {
      "client_id":"7e655c6e-e8e5-4349-8348-e51e0ff3072e",
      "purchase_id":"569c30dc-6bdb-407a-b18b-3794f9b206a8",
      "value":1234,
      "date":"19/08/2016",
      "card_number":"**** **** **** 1234"
   }
]
```
