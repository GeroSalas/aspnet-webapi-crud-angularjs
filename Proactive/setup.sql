
-- SetUp initial database tables after using ProactiveDB.mdf

CREATE TABLE [dbo].[Pais]
(
	[codigo] INT NOT NULL PRIMARY KEY, 
    [nombre] NVARCHAR(50) NOT NULL
)

CREATE TABLE [dbo].[Estado]
(
	[codigo] INT NOT NULL PRIMARY KEY, 
    [nombre] NVARCHAR(50) NOT NULL, 
    [codigo_pais] INT NOT NULL, 
    CONSTRAINT [FK_Estado_ToPais] FOREIGN KEY ([codigo_pais]) REFERENCES [Pais]([codigo])
)

CREATE TABLE [dbo].[Cliente]
(
	[codigo] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [numero_cuenta] INT NOT NULL, 
    [nombre_cliente] NVARCHAR(100) NOT NULL, 
    [codigo_pais] INT NOT NULL, 
    [codigo_estado] INT NOT NULL,
	CONSTRAINT [FK_Cliente_ToPais] FOREIGN KEY ([codigo_pais]) REFERENCES [Pais]([codigo]),
	CONSTRAINT [FK_Cliente_ToEstado] FOREIGN KEY ([codigo_estado]) REFERENCES [Estado]([codigo])
)


-- Generate inserts

INSERT INTO [Pais] (codigo, nombre) VALUES (1, 'Argentina')
INSERT INTO [Pais] (codigo, nombre) VALUES (2, 'Brasil')
INSERT INTO [Pais] (codigo, nombre) VALUES (3, 'Uruguay')

INSERT INTO [Estado] (codigo, nombre, codigo_pais )VALUES (21, 'Tucuman', 1)
INSERT INTO [Estado] (codigo, nombre, codigo_pais )VALUES (22, 'Cordoba', 1)
INSERT INTO [Estado] (codigo, nombre, codigo_pais )VALUES (23, 'Buenos Aires', 1)
INSERT INTO [Estado] (codigo, nombre, codigo_pais )VALUES (44, 'San Pablo', 2)
INSERT INTO [Estado] (codigo, nombre, codigo_pais )VALUES (58, 'Montevideo', 3)

INSERT INTO [Cliente] (numero_cuenta, nombre_cliente, codigo_pais, codigo_estado) VALUES (555, 'Juan Oliver', 1, 21)
INSERT INTO [Cliente] (numero_cuenta, nombre_cliente, codigo_pais, codigo_estado) VALUES (777, 'Geronimo Salas', 1, 22)
INSERT INTO [Cliente] (numero_cuenta, nombre_cliente, codigo_pais, codigo_estado) VALUES (999, 'Pablo Herrera', 1, 23)
INSERT INTO [Cliente] (numero_cuenta, nombre_cliente, codigo_pais, codigo_estado) VALUES (712, 'Pedro Gomez', 2, 44)


/*

SELECT c.codigo, c.numero_cuenta, c.nombre_cliente, e.nombre, p.nombre FROM [Cliente] c 
 JOIN [Estado] e ON c.codigo_estado=e.codigo
 JOIN [Pais] p ON c.codigo_pais=p.codigo  

 */