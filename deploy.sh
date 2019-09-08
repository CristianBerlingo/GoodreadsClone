echo "##########################################################################################"
echo "Deleting older publish folder"
echo "rm -r API/publish"
rm -r API/publish

echo "##########################################################################################"
echo "Executing dotnet publish"
echo "dotnet publish -c Release -f netcoreapp2.1 -o ./publish/release API/GoodreadsCloneAPI.csproj"
dotnet publish -c Release -f netcoreapp2.1 -o ./publish/release API/GoodreadsCloneAPI.csproj

echo "##########################################################################################"
echo "Deleting older containers"
echo "docker rm --force grc_api grc_sql_server"
docker rm --force grc_api grc_sql_server

echo "##########################################################################################"
echo "Deleting older images"
echo "docker image rm --force goodreadsclone/api goodreadsclone/sql_server"
docker image rm --force goodreadsclone/api goodreadsclone/sql_server

echo "##########################################################################################"
echo "Compose containers"
echo "docker-compose up -d --force-recreate"
docker-compose up -d --force-recreate

echo "##########################################################################################"

echo "Wait for caution before connect to database"
echo "sleep 15s"
sleep 15s

echo "##########################################################################################"

echo "Creation database structure"
echo "docker exec -it /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Piazzolla2019 -d master -i setup_ddl.sql"
docker exec -it grc_sql_server /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Piazzolla2019 -d master -i setup_ddl.sql

echo "##########################################################################################"

echo "Populate Book table"
echo "docker exec -it grc_sql_server python3 import_initial_data.py"
docker exec -it grc_sql_server python3 import_initial_book_data.py

echo "##########################################################################################"

echo "Populate remain tables"
echo "docker exec -it /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Piazzolla2019 -d master -i setup_dml.sql"
docker exec -it grc_sql_server /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Piazzolla2019 -d GoodreadsClone -i setup_dml.sql

echo "##########################################################################################"

echo "Deploy finished"