# Image building from dockerfile
echo "Image building from dockerfile"
echo "docker build -t goodreadsclone/sql_server ."
docker build -t goodreadsclone/sql_server .

echo "##########################################################################################"

# Container building and first run from image
echo "Container building and first run from image"
echo "docker run -d --name grc_sql_server -p 1433:1433 goodreadsclone/sql_server"
docker run -d --name grc_sql_server -p 1433:1433 goodreadsclone/sql_server

echo "##########################################################################################"

# Wait for caution
echo "Precaution waiting for container"
echo "sleep 30s"
sleep 30s

echo "##########################################################################################"

# Creation Book table
echo "Creation Book table"
echo "docker exec -it /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Piazzolla2019 -d master -i setup.sql"
docker exec -it grc_sql_server /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Piazzolla2019 -d master -i setup.sql

echo "##########################################################################################"

# Populate Book
echo "Populate Book"
echo "docker exec -it grc_sql_server python3 import_initial_data.py"
docker exec -it grc_sql_server python3 import_initial_data.py

echo "##########################################################################################"

echo "Deploy finished"