-------------------------------------------------------------------------------
-- DML

-- User
INSERT INTO [User] VALUES ('John', 'Doe', '1990-01-01')
INSERT INTO [User] VALUES ('Jane', 'Doe', '1990-01-02')

--Bookshelf
INSERT INTO [Bookshelf] VALUES ('Reading', 1) --John
INSERT INTO [Bookshelf] VALUES ('Wanted', 1)  --John
INSERT INTO [Bookshelf] VALUES ('Loved', 2)   --Jane
INSERT INTO [Bookshelf] VALUES ('Readed', 2)  --Jane

-- BookshelfBook
INSERT INTO [BookshelfBook] VALUES (1, 630)   --John A Tale of Two Cities
INSERT INTO [BookshelfBook] VALUES (2, 1376)  --John The Grapes of Wrath
INSERT INTO [BookshelfBook] VALUES (2, 3155)  --John Postscript to the Name of the Rose
INSERT INTO [BookshelfBook] VALUES (3, 3183)  --Jane The Three Musketeers
INSERT INTO [BookshelfBook] VALUES (3, 5065)  --Jane The Murder of Roger Ackroyd
INSERT INTO [BookshelfBook] VALUES (4, 11360) --Jane I Robot

-- Review
INSERT INTO Review 
    VALUES (1, 630, 
            'More than a ''tale'' where love inspires heroism, passionate feelings hurtling 
            violently against the brutality of history in the making, Dickens, above all, 
            offers us a cruel picture of the French Revolution. Reaction against the 
            ignominious unfairness of an immoral nobility, such revolution appears here 
            like an uncontrollable wave flooding a whole country, leaving chaos and 
            destruction in its wake. How the characters are portrayed, the looming and 
            menacing shadow of the Guillotine, blood flowing through the pages while 
            tricotteuses busy themselves, everything, even Revenge personified, serves here 
            as powerful symbols leaving a deep mark upon the reader.
            A book at the image of the era it depicts: a shock that cannot leave indifferent', 
            4, GETDATE())
INSERT INTO Review 
    VALUES (2, 11360, 
            'Perfect. We don''t have a lot of sci-fi classics that are both deep and page 
            turner, but Asimov does the fiction so incredibly great making the science so 
            interesting and easy to read. I, robot has a lot of psicology regarding men and 
            technology, and specially this days, it is so disturbing understand the fact that 
            Asimov wasn''t playing fun. We are becoming codependent to machines. A perfect 
            read for anyone who wants to read a classic of the genre.', 
            5, GETDATE())
