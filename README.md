# Passkeeper

## Purpose:

Passkeeper is an application for storing passwords securely.

## Prerequisites

* .NET Core v1.1: https://www.microsoft.com/net/core

## Getting Started

Use the following commands to get started:

```
dotnet restore
```

```
dotnet build
```

```
dotnet run
```

## Components

### Storage

Manages the storage for the application. Items contained in storage include:

* List of encrypted passwords and associated service names (i.e. Amazon, Facebook, etc)
* An Encrypted Secret for unlocking all passwords

### Application Features

Features include:

* List all stored service names
* Retrieve a password for a give service
* Store a new password

### Application Driver

The application driver is the main iterface for interacting with the application features. 
