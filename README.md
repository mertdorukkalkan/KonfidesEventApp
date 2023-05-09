# KonfidesEventApp

Migration Command
-------------
cd DataAccess
---------------
 dotnet ef migrations add initial23 --context KonfidesContext --output-dir Migrations --startup-project ../WebAPI
-----------------------------
dotnet ef database update  --startup-project ../WebAPI

