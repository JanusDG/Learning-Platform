-- /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P '&e!dXne}' -i db_setup.sql

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Courses') AND type = N'U')
BEGIN
    CREATE TABLE Courses (
        ID INT IDENTITY(1,1) PRIMARY KEY,
        Name NVARCHAR(255) NOT NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Users') AND type = N'U')
BEGIN
    CREATE TABLE Users (
        ID INT IDENTITY(1,1) PRIMARY KEY,
        Name NVARCHAR(255) NOT NULL
    );
END;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'UserCourses') AND type = N'U')
BEGIN
    CREATE TABLE UserCourses (
        UserID INT NOT NULL,
        CourseID INT NOT NULL,
        FOREIGN KEY (UserID) REFERENCES Users(ID),
        FOREIGN KEY (CourseID) REFERENCES Courses(ID),
        PRIMARY KEY (UserID, CourseID)
    );
END;
