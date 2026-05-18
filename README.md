# 1. Activityual Identity Service README

````md
# Activityual Identity Service

## Overview

The Identity Service is responsible for authentication and authorization within the Activityual platform.

Features:
- User Registration
- User Login
- JWT Authentication
- Secure Password Handling
- Stateless Authentication

---

## Tech Stack

- ASP.NET Core Web API
- JWT Authentication
- PostgreSQL
- Docker
- Kubernetes

---

## GitHub Repository

https://github.com/anurag29310/activityual-identity-service

---

## API Endpoints

### Register User

POST /api/Auth/register

Request:

```json
{
  "email": "user@test.com",
  "password": "Password@123"
}
````

---

### Login User

POST /api/Auth/login

Request:

```json
{
  "email": "user@test.com",
  "password": "Password@123"
}
```

---

## Run Locally

```bash
 git clone https://github.com/anurag29310/activityual-identity-service
 cd activityual-identity-service
 dotnet restore
 dotnet run
```

---

## Docker Build

```bash
 docker build -t activityual-identity-service .
```

---

## Kubernetes Deployment

```bash
 kubectl apply -f k8s/
```

---

## Environment Variables

| Key               | Description                  |
| ----------------- | ---------------------------- |
| JWT_SECRET        | JWT Secret Key               |
| CONNECTION_STRING | PostgreSQL Connection String |

---

## Features

* JWT Token Generation
* Secure Authentication
* Cloud Native Ready
* Kubernetes Deployable

````
