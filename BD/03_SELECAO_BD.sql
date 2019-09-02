use T_InLock

SELECT * FROM Usuarios
SELECT * FROM Estudios
SELECT * FROM Jogos

SELECT Jogos.NomeJogo, Estudios.NomeEstudio
FROM Jogos
JOIN Estudios
ON Jogos.EstudioId = Estudios.EstudioId;

SELECT Jogos.NomeJogo, Estudios.NomeEstudio
FROM Jogos
RIGHT JOIN Estudios
ON Jogos.EstudioId = Estudios.EstudioId;

SELECT * FROM Usuarios 
WHERE Email = 'admin@admin.com' AND Senha = 'admin'


SELECT * FROM Jogos WHERE JogoId = 1; 
SELECT * FROM Estudios WHERE EstudioId = 1; 