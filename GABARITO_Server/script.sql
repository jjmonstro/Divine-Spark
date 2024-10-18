CREATE DATABASE Jogo;
USE Jogo;

CREATE TABLE Arma (
    ID INT PRIMARY KEY,
    nome VARCHAR (50),
    dano DECIMAL,  
    descricao VARCHAR (350),
    possui BIT
);
 

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
    agilidade INT
);

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
    posicao INT FOREIGN KEY
    REFERENCES Sala(ID)
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
INSERT INTO Arma (ID,nome,dano,descricao) VALUES (1, 'Espada de Madeira', 1.05, 'Uma simples espada de madeira...')
INSERT INTO Arma (ID,nome,dano,descricao) VALUES (2, 'Espada de Prata', 1.09, 'Uma simples espada de Ferro...')
INSERT INTO Arma (ID,nome,dano,descricao) VALUES (3, 'Espada de Ouro', 1.12, 'Uma bela espada de Ouro')
INSERT INTO Arma (ID,nome,dano,descricao) VALUES (4, 'Espada de Rubi', 1.2, 'Uma espada forjada inteiramente do rubi mais brilhante')
INSERT INTO Arma (ID,nome,dano,descricao) VALUES (5, 'Tridente de Netuno', 5, 'O tridente de Netuno, majestoso e imponente, brilha com uma aura celestial. Forjado nos abismos do oceano, suas três pontas cortam as ondas e dominam o reino das profundezas, refletindo o poder supremo do deus dos mares.')
INSERT INTO Arma (ID,nome,dano,descricao) VALUES (6, 'Trovão de Júpiter', 99, 'O raio de Júpiter, forjado no coração dos céus, relampeja com uma fúria celestial. Este dardo de pura energia divina, envolto em chamas e eletricidade, descerra os céus e domina os trovões com um estrondo primordial. Seu brilho é o selo do poder supremo e a marca da soberania do rei dos deuses.')
INSERT INTO Arma (ID,nome,dano,descricao) Values (0, Null,Null,Null)

--esses inserts de monstro serão decididos pelo caderno da marina


INSERT INTO Pocao (ID,nome,ganho_vida,ganho_nivel) VALUES (1, 'Poção de vida pequena', 10, 0)
INSERT INTO Pocao (ID,nome,ganho_vida,ganho_nivel) VALUES (2, 'Poção de vida média', 30, 0)
INSERT INTO Pocao (ID,nome,ganho_vida,ganho_nivel) VALUES (3, 'Poção de vida grande', 50, 0)
INSERT INTO Pocao (ID,nome,ganho_vida,ganho_nivel) VALUES (4, 'Poção de nivel pequena', 0, 2)
INSERT INTO Pocao (ID,nome,ganho_vida,ganho_nivel) VALUES (5, 'Poção de nivel média', 0, 4)
INSERT INTO Pocao (ID,nome,ganho_vida,ganho_nivel) VALUES (6, 'Poção de nivel grande', 0, 8)
INSERT INTO Pocao (ID,nome,ganho_vida,ganho_nivel) VALUES (7, 'Poção mista', 30, 3)
INSERT INTO Pocao (ID,nome,ganho_vida,ganho_nivel) VALUES (8, 'Lágrima de Plutão', 999, 999)
INSERT INTO Pocao (ID,nome,ganho_vida,ganho_nivel) VALUES (0, Null, Null, Null)

INSERT INTO Bau (ID,pocao_ID,arma_ID) VALUES (1, 1, 0)
INSERT INTO Bau (ID,pocao_ID,arma_ID) VALUES (2, 2, 0)
INSERT INTO Bau (ID,pocao_ID,arma_ID) VALUES (3, 3, 0)
INSERT INTO Bau (ID,pocao_ID,arma_ID) VALUES (4, 4, 0)
INSERT INTO Bau (ID,pocao_ID,arma_ID) VALUES (5, 5, 0)
INSERT INTO Bau (ID,pocao_ID,arma_ID) VALUES (6, 6, 0)
INSERT INTO Bau (ID,pocao_ID,arma_ID) VALUES (7, 7, 0)
INSERT INTO Bau (ID,pocao_ID,arma_ID) VALUES (8, 8, 0)
INSERT INTO Bau (ID,pocao_ID,arma_ID) VALUES (9, 0, 1)
INSERT INTO Bau (ID,pocao_ID,arma_ID) VALUES (10, 0, 2)
INSERT INTO Bau (ID,pocao_ID,arma_ID) VALUES (11, 0, 2)
INSERT INTO Bau (ID,pocao_ID,arma_ID) VALUES (12, 0, 3)
INSERT INTO Bau (ID,pocao_ID,arma_ID) VALUES (13, 0, 4)
INSERT INTO Bau (ID,pocao_ID,arma_ID) VALUES (14, 0, 5)
INSERT INTO Bau (ID,pocao_ID,arma_ID) VALUES (15, 0, 6)
INSERT INTO Bau (ID,pocao_ID,arma_ID) VALUES (16, 0, 6)
INSERT INTO Bau (ID,pocao_ID,arma_ID) VALUES (0, null, null)

INSERT INTO Monstro (ID,nome,vidaMax,vidaAtual,forca,agilidade) VALUES (0,Null,Null,Null,Null,Null)
Insert into Monstro (ID, nome, vidaMax, vidaAtual, forca, agilidade) values (1, 'Górgona', 10, 10, 5, 10)
Insert into Monstro (ID, nome, vidaMax, vidaAtual, forca, agilidade) values (2, 'Laelaps', 15, 15, 7, 6)
Insert into Monstro (ID, nome, vidaMax, vidaAtual, forca, agilidade) values (3, 'Minerva', 20, 20, 6, 12)
Insert into Monstro (ID, nome, vidaMax, vidaAtual, forca, agilidade) values (4, 'Gigante', 10, 10, 7, 2)
Insert into Monstro (ID, nome, vidaMax, vidaAtual, forca, agilidade) values (5, 'Polifemo', 15, 15, 7, 4)
Insert into Monstro (ID, nome, vidaMax, vidaAtual, forca, agilidade) values (6, 'Netuno', 25, 25, 10, 10)
Insert into Monstro (ID, nome, vidaMax, vidaAtual, forca, agilidade) values (7, 'Empousa', 10, 10, 4, 6)
Insert into Monstro (ID, nome, vidaMax, vidaAtual, forca, agilidade) values (8, 'Cerbero', 15, 15, 7, 4 )
Insert into Monstro (ID, nome, vidaMax, vidaAtual, forca, agilidade) values (9, 'Plutão', 25, 25, 10, 14)
Insert into Monstro (ID, nome, vidaMax, vidaAtual, forca, agilidade) values (10, 'Gegenes', 10, 10, 5, 7)
Insert into Monstro (ID, nome, vidaMax, vidaAtual, forca, agilidade) values (11, 'Hidra', 10,10,6,8)
Insert into Monstro (ID, nome, vidaMax, vidaAtual, forca, agilidade) values (12, 'Quimera', 10,10,8,7)
Insert into Monstro (ID, nome, vidaMax, vidaAtual, forca, agilidade) values (13, 'Jupiter', 25, 25, 15, 10)
INSERT INTO Monstro (ID,nome,vidaMax,vidaAtual,forca,agilidade) VALUES (14, 'Correx', 100, 100, 100, 100)

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
