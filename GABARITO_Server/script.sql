CREATE DATABASE Jogo;
USE Jogo;

CREATE TABLE Arma (
    ID INT PRIMARY KEY,
    nome VARCHAR (50),
    dano DECIMAL,  
    descricao VARCHAR (350),
    possui INT,
	imagem VARCHAR(50)
);
drop table Arma
drop table Bau
Drop table Sala


DELETE FROM Arma
DELETE FROM Bau
DELETE FROM Sala

/*
    eu (correia) coloquei o dano como decimal para que
    o dano que o personagem da seja determinado pela arma que ele usa,
    por exemplo, se ele usa uma arma que tem 1.1 de dano, 
    o dano que ele vai dar no monstro é a força do personagem * dano da arma,
    assim o dano escala com o nível e com a arma, acho que da certo
*/

CREATE TABLE Monstro (
    ID INT PRIMARY KEY,
    nome VARCHAR (50),
    vidaMax INT,
    vidaAtual INT,
    forca INT,
    agilidade INT,
	imagem VARCHAR(50)
);
Drop table Sala
DROP TABLE Monstro
select * from Monstro

CREATE TABLE Pocao (
    ID INT PRIMARY KEY,
    nome VARCHAR (50),
    ganho_vida INT,
    ganho_nivel INT,
    possui BIT
);

CREATE TABLE Bau (
    ID INT PRIMARY KEY,
    pocao_ID INT FOREIGN KEY
    REFERENCES Pocao(ID),
    arma_ID INT FOREIGN KEY
    REFERENCES Arma(ID)
);

CREATE TABLE Sala (
    ID INT PRIMARY KEY,
    monstro_ID INT FOREIGN KEY
    REFERENCES Monstro(ID),
    bau_id INT FOREIGN KEY
    REFERENCES Bau(ID),
    esquerda INT,
    direita INT,
    frente INT,
    tras INT,
    imagem VARCHAR(50)
);

CREATE TABLE Personagem (
    ID INT PRIMARY KEY,
    nome VARCHAR (50),
    vidaMax INT,
    vidaAtual INT,
    forca INT,
    agilidade INT,
    nivel INT,
	equipamento INT,
	imagem VARCHAR(50)
    --mana INT, é uma ideia boa mas por enquanto acho mais fácil tirar
);
-- por enquanto a questão da experiência não esta adicionada, vamos focar em fazer funcionar






-- CREATE TABLE Andar (
--     andar_ID INT PRIMARY KEY,
--     quantidade_salas INT,
--     andar_salas_ID FOREIGN KEY 
--     REFERENCES Sala(sala_ID) --aqui eu quis dizer que um andar tera várias salas, que seram representadas pelo id
-- );
-- resolvi que é melhor que só tenha a tabela sala mesmo,
-- ai se no primeiro andar tiver 3 salas, a primeira sala do próximo andar será a de id 4


-- CREATE TABLE Chave (
--     chave_ID INT PRIMARY KEY
-- );   
-- deixa esse conceito de bau trancado para depois







-------------- inserts, são coisas que a api vai só puxar do banco
INSERT INTO Arma (ID,nome,dano,descricao,possui,imagem) VALUES (1, 'Espada de Madeira', 1.05, 'Uma simples espada de madeira...', 1, 'espadamadeira.png')
INSERT INTO Arma (ID,nome,dano,descricao,possui,imagem) VALUES (2, 'Espada de Prata', 1.09, 'Uma simples espada de Ferro...', null, 'espadaferro.png')
INSERT INTO Arma (ID,nome,dano,descricao,possui,imagem) VALUES (3, 'Espada de Ouro', 1.12, 'Uma bela espada de Ouro', null, 'espadaouro.png')
INSERT INTO Arma (ID,nome,dano,descricao,possui,imagem) VALUES (4, 'Espada de Rubi', 1.2, 'Uma espada forjada inteiramente do rubi mais brilhante', null, 'espadarubi.png')
INSERT INTO Arma (ID,nome,dano,descricao,possui,imagem) VALUES (5, 'Tridente de Netuno', 5, 'O tridente de Netuno, majestoso e imponente, brilha com uma aura celestial. Forjado nos abismos do oceano, suas três pontas cortam as ondas e dominam o reino das profundezas, refletindo o poder supremo do deus dos mares.', null, 'tridentenetuno.png')
INSERT INTO Arma (ID,nome,dano,descricao,possui,imagem) VALUES (6, 'Trovão de Júpiter', 99, 'O raio de Júpiter, forjado no coração dos céus, relampeja com uma fúria celestial. Este dardo de pura energia divina, envolto em chamas e eletricidade, descerra os céus e domina os trovões com um estrondo primordial. Seu brilho é o selo do poder supremo e a marca da soberania do rei dos deuses.', null, 'trovao.png')

--esses inserts de monstro serão decididos pelo caderno da marina


INSERT INTO Pocao (ID,nome,ganho_vida,ganho_nivel) VALUES (1, 'Poção de vida pequena', 10, 0)
INSERT INTO Pocao (ID,nome,ganho_vida,ganho_nivel) VALUES (2, 'Poção de vida média', 30, 0)
INSERT INTO Pocao (ID,nome,ganho_vida,ganho_nivel) VALUES (3, 'Poção de vida grande', 50, 0)
INSERT INTO Pocao (ID,nome,ganho_vida,ganho_nivel) VALUES (4, 'Poção de nivel pequena', 0, 2)
INSERT INTO Pocao (ID,nome,ganho_vida,ganho_nivel) VALUES (5, 'Poção de nivel média', 0, 4)
INSERT INTO Pocao (ID,nome,ganho_vida,ganho_nivel) VALUES (6, 'Poção de nivel grande', 0, 8)
INSERT INTO Pocao (ID,nome,ganho_vida,ganho_nivel) VALUES (7, 'Poção mista', 30, 3)
INSERT INTO Pocao (ID,nome,ganho_vida,ganho_nivel) VALUES (8, 'Lágrima de Plutão', 999, 999)

INSERT INTO Bau (ID,pocao_ID,arma_ID) VALUES (1, 1, null)
INSERT INTO Bau (ID,pocao_ID,arma_ID) VALUES (2, 2, null)
INSERT INTO Bau (ID,pocao_ID,arma_ID) VALUES (3, 3, null)
INSERT INTO Bau (ID,pocao_ID,arma_ID) VALUES (4, 4, null)
INSERT INTO Bau (ID,pocao_ID,arma_ID) VALUES (5, 5, null)
INSERT INTO Bau (ID,pocao_ID,arma_ID) VALUES (6, 6, null)
INSERT INTO Bau (ID,pocao_ID,arma_ID) VALUES (7, 7, null)
INSERT INTO Bau (ID,pocao_ID,arma_ID) VALUES (8, 8, null)
INSERT INTO Bau (ID,pocao_ID,arma_ID) VALUES (9, null, 1)
INSERT INTO Bau (ID,pocao_ID,arma_ID) VALUES (10, null, 2)
INSERT INTO Bau (ID,pocao_ID,arma_ID) VALUES (11, null, 2)
INSERT INTO Bau (ID,pocao_ID,arma_ID) VALUES (12, null, 3)
INSERT INTO Bau (ID,pocao_ID,arma_ID) VALUES (13, null, 4)
INSERT INTO Bau (ID,pocao_ID,arma_ID) VALUES (14, null, 5)
INSERT INTO Bau (ID,pocao_ID,arma_ID) VALUES (15, null, 6)
INSERT INTO Bau (ID,pocao_ID,arma_ID) VALUES (16, null, 6)
delete from Bau
select * from Bau
select * from Arma
select * from Pocao


Insert into Monstro (ID, nome, vidaMax, vidaAtual, forca, agilidade,imagem) values (1, 'Górgona', 10, 10, 5, 10, 'gorgona.png')
Insert into Monstro (ID, nome, vidaMax, vidaAtual, forca, agilidade,imagem) values (2, 'Laelaps', 15, 15, 7, 6, 'laelaps.png')
Insert into Monstro (ID, nome, vidaMax, vidaAtual, forca, agilidade,imagem) values (3, 'Minerva', 20, 20, 6, 12, 'minerva.png')
Insert into Monstro (ID, nome, vidaMax, vidaAtual, forca, agilidade,imagem) values (4, 'Gigante', 10, 10, 7, 2, 'gigante.png')
Insert into Monstro (ID, nome, vidaMax, vidaAtual, forca, agilidade,imagem) values (5, 'Polifemo', 15, 15, 7, 4, 'polifemo.png')
Insert into Monstro (ID, nome, vidaMax, vidaAtual, forca, agilidade,imagem) values (6, 'Netuno', 25, 25, 10, 10, 'netuno.png')
Insert into Monstro (ID, nome, vidaMax, vidaAtual, forca, agilidade,imagem) values (7, 'Empousa', 10, 10, 4, 6, 'empousa.png')
Insert into Monstro (ID, nome, vidaMax, vidaAtual, forca, agilidade,imagem) values (8, 'Cerbero', 15, 15, 7, 4, 'cerbero.png')
Insert into Monstro (ID, nome, vidaMax, vidaAtual, forca, agilidade,imagem) values (9, 'Plutão', 25, 25, 10, 14, 'plutao.png')
Insert into Monstro (ID, nome, vidaMax, vidaAtual, forca, agilidade,imagem) values (10, 'Gegenes', 10, 10, 5, 7, 'gegenes.png')
Insert into Monstro (ID, nome, vidaMax, vidaAtual, forca, agilidade,imagem) values (11, 'Hidra', 10,10,6,8, 'hidra.png')
Insert into Monstro (ID, nome, vidaMax, vidaAtual, forca, agilidade,imagem) values (12, 'Quimera', 10,10,8,7, 'quimera.png')
Insert into Monstro (ID, nome, vidaMax, vidaAtual, forca, agilidade,imagem) values (13, 'Jupiter', 25, 25, 15, 10, 'jupiter.png')
INSERT INTO Monstro (ID, nome, vidaMax, vidaAtual, forca, agilidade,imagem) VALUES (14, 'Correx', 100, 100, 100, 100, 'correx.png')

-- salad.png  vai só para diretia
-- saladf.png   vai para direita e frent
-- salae.png   vai para esquerda
-- salaed.png   é só olhar a terminação
-- salaedf.png
-- salaef.png
-- salaf.png
-- salan.png   não vai para lugar nenhum, só volta bb


INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (1, null, null, null, null, 2, null, 'salaf.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (2, null, null, 3, 9, null, 1, 'salaed.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (3, null, null, null, null, 4, 2, 'salaf.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (4, null, 11, null, 5, null, 3, 'salad.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (5, null, null, null, null, 6, 4, 'salaf.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (6, 1, null, null, 7, 8, 5, 'saladf.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (7, null, 13, null, null, null, 6, 'salan.png') --salan sera uma sala sem nd, só vai dar para andar para trás
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (8, null, 9, null, null, null, 6, 'salan.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (9, 1, null, 11, null, 10, 2, 'salaed.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (10, null, 2, null, null, null, 9, 'salan.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (11, null, null, null, null, 12, 9, 'salaf.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (12, null, null, 13, null, null, 11, 'salae.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (13, null, null, null, 14, null, 12, 'salad.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (14, null, 14, null, null, 15, 13, 'salaf.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (15, 13, null, null, null, null, 14, 'salan.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (16, 1, null, null, null, null, 5, 'salan.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (17, 12, 0, null, null, null, 13, 'salan.png')

INSERT INTO Personagem (ID,nome,vidaMax,vidaAtual,forca,agilidade,nivel,equipamento,imagem) VALUES (1, 'Eneias', 10, 10, 10, 10, 10, 1, 'p1.png')
INSERT INTO Personagem (ID,nome,vidaMax,vidaAtual,forca,agilidade,nivel,equipamento,imagem) VALUES (2, 'Réia', 10, 10, 10, 10, 10, 1, 'p2.png')
INSERT INTO Personagem (ID,nome,vidaMax,vidaAtual,forca,agilidade,nivel,equipamento,imagem) VALUES (3, 'Jasão', 10, 10, 10, 10, 10, 1, 'p3.png')

--INSERT INTO Personagem(ID, nome, forca,agilidade, nivel, vidaAtual, vidaMax, imagem) VALUES(1, 'Eneias', 5, 2, 1, 3, 3, 'p1.png')
--INSERT INTO Personagem(ID, nome, forca,agilidade, nivel, vidaAtual, vidaMax, imagem) VALUES(2, 'Réia', 2, 3, 1, 5, 5, 'p2.png')
--INSERT INTO Personagem(ID, nome, forca,agilidade, nivel, vidaAtual, vidaMax, imagem) VALUES(3, 'Jasão', 3,5, 1, 2, 2, 'p3.png')
--o pessoal colocou esses commits de forma errada, colocaram qunatos pontos ele tem no status ao invés de quanto do status ele tem	
select * from Personagem
drop table Personagem
