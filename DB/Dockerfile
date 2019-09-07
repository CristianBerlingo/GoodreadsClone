FROM mcr.microsoft.com/mssql/server:2017-latest

RUN mkdir -p /usr/src/db
WORKDIR /usr/src/db

RUN apt update && apt install python3-pip unixodbc-dev -y

RUN pip3 install --no-cache-dir pyodbc

COPY ./res .

ENV ACCEPT_EULA="Y"
ENV SA_PASSWORD="Piazzolla2019"

ENTRYPOINT ["/opt/mssql/bin/sqlservr"]
