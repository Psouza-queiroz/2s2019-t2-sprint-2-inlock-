USE T_InLock

SELECT * FROM Usuarios
INSERT INTO Usuarios (Email, Senha, PermissaoUsuario) VALUES ('admin@admin.com','admin','ADMINISTRADOR')
															,('cliente@cliente.com','cliente','CLIENTE');

SELECT * FROM Estudios
INSERT Estudios(NomeEstudio, PaisOrigem,DataCriacao,UsuarioId) VALUES ('Steam','França','07-11-2004',1)
																	 ,('Rockstar Games','Inglaterra','06-11-2003',1)
																	 ,('Blizzard','EUA','05-11-2002',1)


SELECT * FROM Jogos
INSERT INTO Jogos(NomeJogo,Descricao,DataLancamento,Valor,EstudioId) VALUES ('Diablo','É um jogo que contém bastante ação e é viciante, seja você um novato ou um fã.','15-05-2012','99.00',1)
																			,('Red Dead Redemption','jogo eletrônico de ação-aventura western','26-10-2018','120.00',2)
