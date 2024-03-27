-- Tabla de usuarios
CREATE TABLE Users (
    ID_User INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
	Lastname VARCHAR(50) NOT NULL,
    Email VARCHAR(100) UNIQUE NOT NULL,
    Password VARCHAR(100) NOT NULL,
    Registration_Date DATETIME NOT NULL
);

-- Tabla de roles
CREATE TABLE Roles (
    ID_Role INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(50) NOT NULL
);

-- Tabla de asignación de roles a usuarios
CREATE TABLE User_Role (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    ID_User INT,
    ID_Role INT,
    FOREIGN KEY (ID_User) REFERENCES Users(ID_User),
    FOREIGN KEY (ID_Role) REFERENCES Roles(ID_Role)
);

-- Tabla de clientes
CREATE TABLE Clients (
    ID_Client INT IDENTITY(1,1) PRIMARY KEY ,
    ID_User INT,
    Name VARCHAR(50),
    Lastname VARCHAR(50),
    Email VARCHAR(100),
    Phone VARCHAR(15),
    FOREIGN KEY (ID_User) REFERENCES Users(ID_User)
);

-- Tabla de barberos
CREATE TABLE Barbers (
    ID_Barber INT IDENTITY(1,1) PRIMARY KEY,
    ID_User INT,
    Name VARCHAR(50),
    Lastname VARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Phone VARCHAR(15) NULL,
    FOREIGN KEY (ID_User) REFERENCES Users(ID_User)
);

-- Tabla de citas
CREATE TABLE Appointments (
    ID_Appointment INT IDENTITY(1,1) PRIMARY KEY,
    ID_Client INT,
    ID_Barber INT,
    Date_Time DATETIME,
    Service VARCHAR(100),
    Notes TEXT,
    FOREIGN KEY (ID_Client) REFERENCES Clients(ID_Client),
    FOREIGN KEY (ID_Barber) REFERENCES Barbers(ID_Barber)
);
