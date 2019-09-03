CREATE DATABASE GoodreadsClone;
GO

USE GoodreadsClone;
GO

CREATE TABLE Book (
    id INT IDENTITY(1, 1),
    title VARCHAR (MAX) NOT NULL,
    authors VARCHAR (MAX) NOT NULL,
    average_rating DECIMAL (3, 2) NOT NULL DEFAULT 0,
    isbn VARCHAR(13) NOT NULL,
    num_pages SMALLINT,
    ratings_count INT NOT NULL DEFAULT 0,
    text_reviews_count INT NOT NULL DEFAULT 0,
    CONSTRAINT PK_Book PRIMARY KEY (id)
);
GO

CREATE TABLE [User] (
    id INT IDENTITY(1, 1),
    first_name VARCHAR(200) NOT NULL,
    last_name VARCHAR(200) NOT NULL,
    birthday DATETIME NOT NULL
    CONSTRAINT PK_User PRIMARY KEY (id)
);
GO

CREATE TABLE Bookshelf (
    id INT IDENTITY(1, 1),
    [name] VARCHAR(200) NOT NULL,
    [user_id] INT NOT NULL,
    CONSTRAINT FK_BookshelfUser FOREIGN KEY ([user_id]) REFERENCES [User](id)
);
GO

CREATE TABLE BookshelfBook (
    bookshelf_id INT NOT NULL,
    book_id INT NOT NULL
);
GO
