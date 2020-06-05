dotnet ef migrations add PersistedGrantDbMigration -c PersistedGrantDbContext -o Migrations/PersistedGrantDb

dotnet ef database update -c PersistedGrantDbContext