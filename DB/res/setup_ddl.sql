-------------------------------------------------------------------------------
-- DDL

CREATE DATABASE GoodreadsClone;
GO

USE GoodreadsClone;
GO

CREATE TABLE Book (
    id INT IDENTITY(1, 1),
    title VARCHAR (MAX) NOT NULL,
    authors VARCHAR (MAX) NOT NULL,
    average_rating DECIMAL (3, 2) NOT NULL CHECK (average_rating >= 0 AND average_rating <= 5),
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
    birthday DATE NOT NULL
    CONSTRAINT PK_User PRIMARY KEY (id)
);
GO

CREATE TABLE Bookshelf (
    id INT IDENTITY(1, 1),
    [name] VARCHAR(200) NOT NULL,
    [user_id] INT NOT NULL,
    CONSTRAINT PK_Bookshelf PRIMARY KEY (id),
    CONSTRAINT FK_BookshelfUser FOREIGN KEY ([user_id]) REFERENCES [User](id)
);
GO

CREATE TABLE BookshelfBook (
    bookshelf_id INT NOT NULL,
    book_id INT NOT NULL,
    CONSTRAINT PK_BookshelfBook PRIMARY KEY (bookshelf_id, book_id),
    CONSTRAINT FK_BookshelfBook_Bookshelf FOREIGN KEY ([bookshelf_id]) REFERENCES [Bookshelf](id),
    CONSTRAINT FK_BookshelfBook_Book FOREIGN KEY ([book_id]) REFERENCES [Book](id)
);
GO

CREATE TABLE Review (
    id INT IDENTITY(1, 1),
    [user_id] INT NOT NULL,
    book_id INT NOT NULL,
    text_review VARCHAR(MAX) NOT NULL DEFAULT '',
    rating INT NOT NULL CHECK (rating >= 1 AND rating <= 5),
    published DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT PK_Review PRIMARY KEY (id),
    CONSTRAINT FK_ReviewUser FOREIGN KEY ([user_id]) REFERENCES [User](id),
    CONSTRAINT FK_ReviewBook FOREIGN KEY ([book_id]) REFERENCES [Book](id)
);
GO
