/* Datos de prueba para APIDemoLabDB
   Ejecutar DESPUES de Update-Database y una sola vez. */
USE APIDemoLabDB;
GO

SET NOCOUNT ON;

IF EXISTS (SELECT 1 FROM Grades)
BEGIN
    PRINT 'Ya existen datos; no se inserto nada.';
    RETURN;
END

INSERT INTO Grades (Name, Description, IsActive) VALUES
    ('Primero', 'Primer grado', 1),
    ('Segundo', 'Segundo grado', 1),
    ('Tercero', 'Tercer grado', 1);

INSERT INTO Courses (Name, Credit, IsActive) VALUES
    ('Matematica', 5, 1),
    ('Comunicacion', 4, 1),
    ('Historia', 3, 1),
    ('Ciencias', 4, 1);

INSERT INTO Students (GradeId, FirstName, LastName, Phone, Email) VALUES
    (1, 'Ana',    'Torres',  '999111222', 'ana.torres@correo.com'),
    (1, 'Luis',   'Quispe',  '999333444', 'luis.quispe@correo.com'),
    (2, 'Maria',  'Rojas',   '999555666', 'maria.rojas@correo.com'),
    (2, 'Carlos', 'Vargas',  '999777888', 'carlos.vargas@correo.com'),
    (3, 'Sofia',  'Mendoza', '999999000', 'sofia.mendoza@correo.com'),
    (3, 'Jorge',  'Alarcon', '988111222', 'jorge.alarcon@correo.com');

INSERT INTO Enrollments (StudentId, CourseId, [Date]) VALUES
    (1, 1, '2026-03-15'),
    (1, 2, '2026-03-15'),
    (2, 1, '2026-03-16'),
    (3, 3, '2026-03-16'),
    (4, 2, '2026-03-17'),
    (5, 4, '2026-03-17'),
    (5, 1, '2026-03-18'),
    (6, 3, '2026-03-18');
GO
