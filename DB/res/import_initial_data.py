import pyodbc
import csv
import os

CONNECTION_STRING_SQL_LOGIN = 'DRIVER={};SERVER={};DATABASE={};UID={};PWD={}'

driver = '{ODBC Driver 17 for SQL Server}'
server = 'localhost'
database = 'GoodreadsClone'
uid = 'sa'
pwd = 'Piazzolla2019'

connection_string = CONNECTION_STRING_SQL_LOGIN.format(driver, server, database, uid, pwd)

connection = pyodbc.connect(connection_string)

csv_path = os.path.join(os.path.dirname(os.path.realpath(__file__)), 'books_clean.csv')

with open (csv_path, 'r', encoding='utf-8') as f:
    reader = csv.reader(f, delimiter=';')
    columns = next(reader) 
    query = 'INSERT INTO Book({0}) VALUES ({1})'
    query = query.format(','.join(columns), ','.join('?' * len(columns)))
    cursor = connection.cursor()
    
    for data in reader:
        cursor.execute(query, data)
    
    cursor.commit()
