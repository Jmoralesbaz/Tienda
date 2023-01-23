create database Examen;
GO
use Examen;

create table Clientes(
Id int primary key identity not null,
Nombre VARCHAR(50),
Apellidos VARCHAR(50),
Direccion VARCHAR(50),
CONSTRAINT UQ_NOMBRE UNIQUE(Nombre,Apellidos)
);

create table Tiendas(
Id int primary key identity not null,
Sucursal VARCHAR(100) UNIQUE not null,
Direccion VARCHAR(250) not null
);

create table Articulos(
Id int primary key identity not null,
Codigo VARCHAR(50),
Descripcion VARCHAR(250),
Precio DECIMAL(15,2),
Imagen VARCHAR(MAX),
Stock INT
);

create table Articulos_En_Tiendas(
Tiendas int references Tiendas(Id) not null,
Articulo int references Articulos(Id) not null,
Fecha Date not null,
CONSTRAINT UQ_TAR  UNIQUE(Tiendas,Articulo)
);

create table Cliente_Con_Articulos(
Cliente int references Clientes(Id) not null,
Articulo int references Articulos(Id) not null,
Fecha Date not null,
CONSTRAINT UQ_CAR  UNIQUE(Cliente,Articulo)
);

create table AccountClient(
Id int primary key identity not null,
Cliente int references Clientes(Id) not null unique,
Usuario VARCHAR(20) not null unique,
Clave VARCHAR(MAX) not null,
Activo bit default 1
);

create table Ventas(
Id int primary key identity not null,
Cliente int references Clientes(Id) not null unique,
Importe decimal(15,2) not null,
TotalArticulos int not null,
FechaHora datetime not null
);
create table Sesiones(
Id int primary key identity not null,
Usuario int references AccountClient(Id) not null,
Sesion varchar(max) not null,
Activa bit default 1,
);