# Apexfit - fitness tracker

## Description

* App to track Your diet, trainings and sleep.
* UI language: Estonian
* Successor of my team's uni project "Toitumispaevik".
* Languages and technologies: **C#, .NET framework & Microsoft Azure SQL**

## How to run

* The app itself is a Windows desktop application which was developed in Visual Studio, so it is just executable from VS.
* It requires connection to an Azure database to run, since access is secured, contact me for an access to DB.

## Explanation of the structure

### Frontend/UI
As it is Windows application which was created as Visual Studio solution, the UI is completely made in VS itself, using Windows Forms.
No external UI elements were used in this project. I did my best to create a user-friendly UI which looks as aesthetic as it possibly can.

### Structure of the backend
The application uses component-based architecture which means that the app is divided into 8 parts. Each part is a project on its own and has an interface.

**UI component** - contains and implements both login and main window and the logic behind UI elements.
**Core component** - implements different functions for calculations and connecting to database.
**Security layer** - implements functions which help to keep user data secure.
**Analysis component** - performs analysis specifically related to fitness functionality.
**Foods'/recipes' component** - handles food and recipe data. 
**User profile component** - handles user data.
**Trainings' component** - handles training data.
**Sleep component** - handles sleep data.

### Data management
The application uses Microsoft Azure SQL database as database server. Predecessor ("Toitumispaevik") used SQLite and, therefore, stored data locally. However this application can be used in any modern Windows system and data will be always within reach.
Database is secured with username and password. Both are set as environmental variables in systems that use this application.

Data is separated between 11 tables. Each table has its own use.

**user_data** - stores information about user. Sensitive info is protected by using my own encryption methods and salted hash.
**user_daily_data** - stores daily information about user (ig. their calorie daily intake, consumption).
**food_data** - stores all foods (and their nutritional information) that are available to select. User can also add their own foods.
**recipe_data** - stores all recipes (and their nutritional information) that are available to select. User can also add their own recipes.
**recipe_ingredients** - stores ingredients (foods) of recipes that are created.
**user_food_history** - stores all history related to user's meals.
**training_data** - stores all training styles (and fitness related information) that are available to select. User can also add their own training styles.
**user_training_plan** - stores all future plans related to user's training sessions.
**user_training_history** - stores all history related to user's training sessions.
**user_sleep_history** - stores all history related to user's sleeping sessions.
**recovery_questions** - stores all app's security questions used to recover forgotten password.

## Scaling possibilities

### Client-server application
Client application contains only UI and logic behind UI elements. API exchanges information between frontend(UI) and backend which runs on a server.

### Web application
UI is on a web page that runs on a server and backend runs on a different server. This opens a door for larger scalability between different operating systems and platforms.

### iOS/Android application
It is possible to create a phone application which contains UI. Backend still runs on a different server.
