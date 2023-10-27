# Asbjørn, Rasmus Skriver og Salim Jama - Web API + EF Mini Project

## Version 1.0

## Project Description
This project is a simple Reddit clone, developed as part of the Software Architecture course. Users can create new threads, consisting of either a URL or text, and engage in discussions by adding comments. Both threads and comments can be voted on (upvoted or downvoted) by users.

## Learning Objectives
The primary goal of this project is to apply and gain practical experience with various technologies and software architecture principles introduced in the Software Architecture course.

## Features

### Homepage
- Displays the 50 latest threads sorted by date.
- Allows users to click on individual threads for more details.

### Thread Page
- Displays a specific thread, including text or a URL.
- Shows metadata, including thread creation date, author's name, and the number of votes.
- Provides voting buttons (upvote/downvote).
- Displays comments with text, author's name, comment date, and vote buttons.

### New Thread Page
- Allows users to create a new thread with a title, text, or a URL.
- Requires the author's name.

### General
- All pages feature a link back to the homepage for easy navigation.

## Limitations
- No user login functionality; all actions are anonymous.
- Comments are linear, with no nesting.
- No option to delete data.
- There are no subreddits; all content is on the homepage.

## Optional Extensions
While not mandatory, you can attempt to address some limitations if time allows.

## Technical Requirements

### Technology and Architecture
- ASP.NET Core 6, with Minimal API for the Web API.
- Blazor WebAssembly.
- Entity Framework.

### Deployment
Deployment is optional, but you can consider platforms like Azure App Service and Azure Database for PostgreSQL.

### Build and Run
Use the following commands to build and run the project:
```bash
$ dotnet build
$ dotnet ef database update
$ dotnet run
