
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Persona') --Crea la tabla personas si no existe
BEGIN
    CREATE TABLE Persona (
        id_persona INT IDENTITY(1,1) PRIMARY KEY,
        nombre NVARCHAR(100) NOT NULL,
        id_jefe INT NULL,

        CONSTRAINT FK_Persona_Jefe
            FOREIGN KEY (id_jefe)
            REFERENCES Persona(id_persona)
    );
END

IF NOT EXISTS (SELECT 1 FROM Persona) --Llena la tabla personas si esta vacia
BEGIN 
    INSERT INTO Persona (nombre, id_jefe) VALUES ('Jose', NULL); --ID 1
    INSERT INTO Persona (nombre, id_jefe) VALUES ('Marco', 1); --ID 2 
    INSERT INTO Persona (nombre, id_jefe) VALUES ('Pedro', 1); --ID 3

    INSERT INTO Persona (nombre, id_jefe) VALUES ('Araceli', 2); --ID 4
    INSERT INTO Persona (nombre, id_jefe) VALUES ('Antonio', 2);
    INSERT INTO Persona (nombre, id_jefe) VALUES ('Andrea', 2);

    INSERT INTO Persona (nombre, id_jefe) VALUES ('Josue', 3); --ID 7
    INSERT INTO Persona (nombre, id_jefe) VALUES ('Adriana', 3);

    INSERT INTO Persona (nombre, id_jefe) VALUES ('Abigail', 4);
    INSERT INTO Persona (nombre, id_jefe) VALUES ('Noemi', 4);

    INSERT INTO Persona (nombre, id_jefe) VALUES ('Victor', 7);
    INSERT INTO Persona (nombre, id_jefe) VALUES ('Monica', 7);
END

--SELECT * FROM Persona;

DECLARE @Nombre VARCHAR(100) = 'Noemi';

;WITH CTEJerarquia AS (
    SELECT id_persona, nombre, id_jefe, 0 AS jerarquia, 
    CAST(NULL AS VARCHAR(MAX)) AS linea
    FROM Persona 
    WHERE nombre = @Nombre

    UNION ALL

    SELECT p.id_persona, p.nombre, p.id_jefe, cte.jerarquia + 1, 
    CAST(CONCAT_WS(', ', NULLIF(cte.linea, ''), p.nombre) AS VARCHAR(MAX))
    FROM Persona p
    INNER JOIN CTEJerarquia cte ON cte.id_jefe = p.id_persona
)

SELECT CONCAT('Mando(''', @Nombre, ''') = [', linea, ']') AS 'Linea de Mando'
FROM CTEJerarquia WHERE id_jefe IS NULL



------------------------ TRAE TODOS LOS INDIVIDUOS ------------------------
--;WITH CTEJerarquia AS (
--    SELECT id_persona, nombre, id_jefe, 0 AS jerarquia, 
--    CAST('' AS VARCHAR(MAX)) AS linea
--    FROM Persona 
--    WHERE id_jefe IS NULL

--    UNION ALL

--    SELECT p.id_persona, p.nombre, p.id_jefe, cte.jerarquia + 1, 
--    CAST(CONCAT_WS(', ', NULLIF(cte.linea, ''), p.nombre) AS VARCHAR(MAX)) --USO CONCATWS para evitar una coma al principio cuando tenemos vacio
--    FROM Persona p
--    INNER JOIN CTEJerarquia cte ON p.id_jefe = cte.id_persona
--)

--SELECT CONCAT('Mando(''', nombre, ''') = [', linea, ']') AS 'Linea de Mando'
--FROM CTEJerarquia

-----------------------------------------------------------------------------