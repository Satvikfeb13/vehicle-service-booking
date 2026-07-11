@echo off
echo Running migration... > migration_log.txt
dotnet ef migrations add InitialCreate >> migration_log.txt 2>&1
echo Done. >> migration_log.txt
