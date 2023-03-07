# SQLminiprojekt

This is a SQL project to practice ineraction with SQL database.

This console app written in C# is a simple time reporting tool which store data in a PostgreSQL database.

## ⚙ Tech stack
![Postgres](https://img.shields.io/badge/postgres-%23316192.svg?style=for-the-badge&logo=postgresql&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)



## 🗝 Key features

  - Users
    - Add new user
    - Rename existing user
  - Projects
    - Add new project
    - Rename existing project
  - Report
    - Add new report
    - Change existing report (User, Project and time)
    - Remove an incorrect record (this will also happen if tipe is changed to 0)

🏗 Things that could be improved

-   New names is formatted with upper first letter. But if user accidently enter nAme it will be formatted as NAme. 
    -   If all letters beyond first letter should be lower, it will create problem for people with double name.
-  Error handling if DB is down.