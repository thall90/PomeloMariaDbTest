# PomeloMariaDbTest

Proof-of-concept for MariaDb code-first migrations in .NET 6 Web API using Pomelo EF Provider.

### How To Run This Project

1. Clone this repository

2. [Install Docker](https://docs.docker.com/get-docker/) if not already installed 

3. Navigate to the cloned repository directory in your terminal of choice

4. Install dotnet ef core tools by running `dotnet tool install --global dotnet-ef`

5. Run `docker compose up -d` to initialize the MariaDb database Docker container
    
   - **Optional:** Database configurations can be updated as necessary via edit to the `docker-compose.yml` file

6. From the terminal, start the MariaDB console within the Docker containter via `docker exec -it mariadb mariadb --user root -p{YOUR_DB_PASSWORD_HERE}`

7. Provide `admin` user with grants to everything by running `GRANT SELECT ON *.* TO 'admin';` (must include semicolon for statement to execute)

8. Open the PomeloMariaDbTest solution in your preferred .NET IDE (Rider, Visual Studio, etc.)

   - **Optional:** Any changes made to the DB configuration in the `docker-compose.yml` file should be copied to the connection string in the `appsettings.development.json` file

9. Running the solution will run the test migrations located in the `PomeloMariaDbTest.Data.Migrations` project

Additional migrations can be added using the `CreateMigration.ps1` PowerShell script provided in the `powershell` directory.
