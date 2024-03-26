-- Tabla de tipos de usuario
CREATE TABLE UserType (
    ID_UserType INT PRIMARY KEY identity(1,1),
    Type VARCHAR(50) UNIQUE NOT NULL
);

-- Tabla de usuarios
CREATE TABLE Users (
    ID_User INT PRIMARY KEY identity(1,1),
    Name VARCHAR(50) NOT NULL,
    Email VARCHAR(100) UNIQUE NOT NULL,
    Password VARCHAR(100) NOT NULL,
    Registration_Date DATETIME,
	ID_UserType INT,
	FOREIGN KEY(ID_UserType) REFERENCES UserType(ID_UserType)
);

-- Tabla de roles
CREATE TABLE Roles (
    ID_Role INT PRIMARY KEY identity(1,1),
    Name VARCHAR(50) UNIQUE NOT NULL
);

-- Tabla de asignación de roles a usuarios
CREATE TABLE User_Role (
    ID INT PRIMARY KEY identity(1,1),
    ID_User INT,
    ID_Role INT,
    FOREIGN KEY (ID_User) REFERENCES Users(ID_User),
    FOREIGN KEY (ID_Role) REFERENCES Roles(ID_Role)
);

-- Tabla de clientes
CREATE TABLE Clients (
    ID_Client INT PRIMARY KEY identity(1,1),
    ID_User INT,
    Name VARCHAR(50),
    Lastname VARCHAR(50),
    Email VARCHAR(100),
    Phone VARCHAR(15),
    FOREIGN KEY (ID_User) REFERENCES Users(ID_User)
);

-- Tabla de barberos
CREATE TABLE Barbers (
    ID_Barber INT PRIMARY KEY identity(1,1),
    ID_User INT,
    Name VARCHAR(50),
    Lastname VARCHAR(50),
    Email VARCHAR(100),
    Phone VARCHAR(15),
    FOREIGN KEY (ID_User) REFERENCES Users(ID_User)
);

-- Tabla de citas
CREATE TABLE Appointments (
    ID_Appointment INT PRIMARY KEY identity(1,1),
    ID_Client INT,
    ID_Barber INT,
    Date_Time DATETIME,
    Service VARCHAR(100),
    Notes TEXT,
    FOREIGN KEY (ID_Client) REFERENCES Clients(ID_Client),
    FOREIGN KEY (ID_Barber) REFERENCES Barbers(ID_Barber)
);
