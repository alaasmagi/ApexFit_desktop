# Apexfit - fitness tracker

## Description

* App to track Your diet, trainings and sleep.
* Successor of my team's uni project "Toitumispaevik".

## How to run

* The app itself is a Windows desktop application which was developed in Visual Studio, so it is just executable from VS.
* It requires connection to an Azure database to run, since access is secured, contact me for an access to DB.

## Explanation of the structure

### Frontend/UI
As it is Windows application which was created as Visual Studio solution, the UI is completely made in VS itself, using Windows Forms.
No external UI elements were used in this project. I did my best to create a user-friendly UI which looks as aesthetic as it possibly can.

### Structure of the backend
The application uses component-based architecture which means that the app is divided into 8 parts. Each part is a project on its own and has an interface.
