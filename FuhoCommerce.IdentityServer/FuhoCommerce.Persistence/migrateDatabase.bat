@echo off
echo "The process is starting..."

SET persistenceDir=%cd%
SET migrationDir=%cd%\Migrations\

dir /b %migrationDir% | findstr "^" >nul && :UpdateDatabase || :CreateNewMigrations

:CreateNewMigrations

cd %persistenceDir%
Start /wait dotnet ef migrations add InitFuhoIdentityDbContext -c FuhoIdentityDbContext -o Migrations
Start /wait dotnet ef database update -c FuhoIdentityDbContext
Start /wait dotnet ef migrations add PersistedGrantDbMigration -c PersistedGrantDbContext -o Migrations/PersistedGrantDb
Start /wait dotnet ef database update -c PersistedGrantDbContext

:UpdateDatabase
Start /wait dotnet ef database update -c FuhoIdentityDbContext
Start /wait dotnet ef database update -c PersistedGrantDbContext

pause