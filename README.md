# _Epic Hair Salon_
#### By _**Florin Mirica**_
GitHub link: https://github.com/florinmirica/HairSalon.Solution.git

## Description

_Hair Salon is a web app where the user will be able to add a stylist, specialist and a client to the database. You will be able to assign a client to a employee, specialties etc._
## Setup/Installation Requirements

* Clone this repository by using Terminal command:
    $ git clone https://github.com/florinmirica/HairSalon.Solution.git

* Create a database using the following SQL commands:
USE florin_mirica;

CREATE TABLE stylists (stylist_id serial PRIMARY KEY, stylist_name VARCHAR(255));

CREATE TABLE clients (client_id serial PRIMARY KEY, client_name VARCHAR(255), stylist_id INT(11));

CREATE TABLE specialties (specialty_id serial PRIMARY KEY, specialty_name VARCHAR(255));

CREATE TABLE stylists_specialties (id serial PRIMARY KEY, stylist_id INT(11), specialty_id INT(11));

* Navigate to the HairSalon folder in command shell and use the following commands:
dotnet restore
dotnet run

## Specifications

* The website can display a list of all stylists.	Input: View website	Output: List of all stylists
* The website allows user to select a stylist and see their clients. Input: Stylist 1 clicked; Output: Stylist 1's clients
* The website allows user to add new stylist; Input: New Stylist; Output: List of all stylists
* The website allows user to add new clients under a specific stylist; Input: New Client; Output: Clients of selected stylist plus the new added client
## Known bugs

No real styling.


## Support and contact details

miricaflorin@hotmail.com

## Technologies used:

C#
SQL


Copyright (c) 2019 Florin Mirica
