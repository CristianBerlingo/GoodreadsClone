rm -r API/publish

dotnet publish -c Release -f netcoreapp2.1 -o ./publish/release API/GoodreadsCloneAPI.csproj

docker image rm goodreadsclone/api

docker image rm goodreadsclone/sql_server

docker-compose up -d --force-recreate

# Wait for caution
echo "Wait for caution"
echo "sleep 30s"
sleep 30s

echo "##########################################################################################"

# Creation Book table
echo "Creation database structure"
echo "docker exec -it /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Piazzolla2019 -d master -i setup_ddl.sql"
docker exec -it grc_sql_server /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Piazzolla2019 -d master -i setup_ddl.sql

echo "##########################################################################################"

# Populate Book table
echo "Populate Book table"
echo "docker exec -it grc_sql_server python3 import_initial_data.py"
docker exec -it grc_sql_server python3 import_initial_book_data.py

echo "##########################################################################################"

# Populate remain tables
echo "Populate remain tables"
echo "docker exec -it /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Piazzolla2019 -d master -i setup_dml.sql"
docker exec -it grc_sql_server /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Piazzolla2019 -d GoodreadsClone -i setup_dml.sql

echo "##########################################################################################"

echo "Deploy finished"