CREATE DATABASE Jogo;
USE Jogo;

CREATE TABLE Arma (
    ID INT PRIMARY KEY,
    nome VARCHAR (50),
    dano FLOAT,  
    descricao VARCHAR (350),
    possui INT,
	imagem VARCHAR(50)
);

CREATE TABLE Monstro (
    ID INT PRIMARY KEY,
    nome VARCHAR (50),
    vidaMax INT,
    vidaAtual INT,
    forca INT,
    agilidade INT,
	imagem VARCHAR(50)
);

CREATE TABLE Pocao (
    ID INT PRIMARY KEY,
    nome VARCHAR (50),
    ganho_vida INT,
    ganho_nivel INT,
    possui INT,
	imagem VARCHAR(50),
	descricao VARCHAR (350)
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
);

-------------- inserts, são coisas que a api vai só puxar do banco
INSERT INTO Arma (ID,nome,dano,descricao,possui,imagem) VALUES (1, 'Espada de Madeira', 1.05, 'Uma simples espada de madeira...', 1, 'espadamadeira.png')
INSERT INTO Arma (ID,nome,dano,descricao,possui,imagem) VALUES (2, 'Espada de Prata', 1.2, 'Uma simples espada de Ferro...', null, 'espadaferro.png')
INSERT INTO Arma (ID,nome,dano,descricao,possui,imagem) VALUES (3, 'Espada de Ouro', 1.4, 'Uma bela espada de Ouro', null, 'espadaouro.png')
INSERT INTO Arma (ID,nome,dano,descricao,possui,imagem) VALUES (4, 'Espada de Rubi', 1.8, 'Uma espada forjada inteiramente do rubi mais brilhante', null, 'espadarubi.png')
INSERT INTO Arma (ID,nome,dano,descricao,possui,imagem) VALUES (5, 'Tridente de Netuno', 5, 'O tridente de Netuno, majestoso e imponente, brilha com uma aura celestial. Forjado nos abismos do oceano, suas três pontas cortam as ondas e dominam o reino das profundezas, refletindo o poder supremo do deus dos mares.', null, 'tridentenetuno.png')
INSERT INTO Arma (ID,nome,dano,descricao,possui,imagem) VALUES (6, 'Trovão de Júpiter', 99, 'O raio de Júpiter, forjado no coração dos céus, relampeja com uma fúria celestial. Este dardo de pura energia divina, envolto em chamas e eletricidade, descerra os céus e domina os trovões com um estrondo primordial. Seu brilho é o selo do poder supremo e a marca da soberania do rei dos deuses.', null, 'trovao.png')
INSERT INTO Arma (ID,nome,dano,descricao,possui,imagem) VALUES (7, 'Arco Simples', 1.2, 'Um simples arco de madeira', null, 'arcosimples.png')
INSERT INTO Arma (ID,nome,dano,descricao,possui,imagem) VALUES (8, 'Arco de Caçador', 1.4, 'Um arco especialmente feito para caça', null, 'arcocacador.png')
INSERT INTO Arma (ID,nome,dano,descricao,possui,imagem) VALUES (9, 'Arco Encantado', 2, 'Um arco misterioso com propriedades mágicas, seus tiros se dividem em dois ao serem lançados', null, 'arcoencantado.png')
INSERT INTO Arma (ID,nome,dano,descricao,possui,imagem) VALUES (10, 'Cajado da Floresta', 1.4, 'Um cajado de madeira, encantado pelos espiritos da floresta', null, 'cajadofloresta.png')
INSERT INTO Arma (ID,nome,dano,descricao,possui,imagem) VALUES (11, 'Cajado dos Ventos', 1.7, 'Um reluzendte cajado de prata, infundido com os ventos dos quatro cantos do mundo', null, 'cajadoventos.png')
INSERT INTO Arma (ID,nome,dano,descricao,possui,imagem) VALUES (12, 'Cajado do Vulcão', 2.3, 'Um cajado de obsidiana, encantado nas profundezas do maior dos vulcões, capaz de destruir um vilarejo com apenas uma de suas bolas de fogo', null, 'cajadovulcao.png')

INSERT INTO Pocao (ID,nome,ganho_vida,ganho_nivel,imagem,possui,descricao) VALUES (1, 'Poção de vida pequena', 10, 0, 'pocaovpequena.png', null,'Uma pequena poção de regeneração, ajuda aventureiros(as) inicantes a curar leves ferimentos')
INSERT INTO Pocao (ID,nome,ganho_vida,ganho_nivel,imagem,possui,descricao) VALUES (2, 'Poção de vida média', 30, 0, 'pocaovmedia.png', null,'Uma poção de regeneração comum, utilizada por curandeiros em ferimentos e doenças gerais')
INSERT INTO Pocao (ID,nome,ganho_vida,ganho_nivel,imagem,possui,descricao) VALUES (3, 'Poção de vida grande', 50, 0, 'pocaovgrande.png', null,'Uma grande poção de regeneração, cura quase todos os ferimentos e doenças')
INSERT INTO Pocao (ID,nome,ganho_vida,ganho_nivel,imagem,possui,descricao) VALUES (4, 'Poção de nivel pequena', 0, 2, 'pocaonpequena.png', null,'Uma pequena poção de experiencia, melhora pequenas habilidades dos aventureiros(as)')
INSERT INTO Pocao (ID,nome,ganho_vida,ganho_nivel,imagem,possui,descricao) VALUES (5, 'Poção de nivel média', 0, 4, 'pocaonmedia.png', null,'Uma poção de experiencia média, ajuda aventureiros(as) a desenvolverem habiilidades com muito mais facilidade')
INSERT INTO Pocao (ID,nome,ganho_vida,ganho_nivel,imagem,possui,descricao) VALUES (6, 'Poção de nivel grande', 0, 8, 'pocaongrande.png', null,'Uma poção de experiencia grande, desenvolce qualquer habilidade de maneira significativa')
INSERT INTO Pocao (ID,nome,ganho_vida,ganho_nivel,imagem,possui,descricao) VALUES (7, 'Poção mista', 30, 3, 'pocaom.png', null,'Uma mistura de poções, cura e aumenta as habilidades do aventureiro(a)')
INSERT INTO Pocao (ID,nome,ganho_vida,ganho_nivel,imagem,possui,descricao) VALUES (8, 'Lágrima de Plutão', 999, 999, 'lagrimaplutao.png', null,'Em um frasco de cristal lapidado, a Lagrima de Plutão brilha com um brilho etéreo, capturando a essência da morte e renascimento. Seu azul profundo lembra o céu noturno onde as almas se perdem. Ao consumi-la, o aventureiro sente um poder ancestral, capaz de reviver os caídos e conceder visões do além, selando seu destino com a sabedoria dos mortos.')

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
INSERT INTO Bau (ID,pocao_ID,arma_ID) VALUES (16, null, 7)
INSERT INTO Bau (ID,pocao_ID,arma_ID) VALUES (17, null, 8)
INSERT INTO Bau (ID,pocao_ID,arma_ID) VALUES (18, null, 9)
INSERT INTO Bau (ID,pocao_ID,arma_ID) VALUES (19, null, 10)
INSERT INTO Bau (ID,pocao_ID,arma_ID) VALUES (20, null, 11)
INSERT INTO Bau (ID,pocao_ID,arma_ID) VALUES (21, null, 12)

Insert into Monstro (ID, nome, vidaMax, vidaAtual, forca, agilidade,imagem) values (1, 'Górgona', 10, 10, 5, 10, 'gorgona.png')
Insert into Monstro (ID, nome, vidaMax, vidaAtual, forca, agilidade,imagem) values (2, 'Laelaps', 15, 15, 7, 6, 'laelaps.png')
Insert into Monstro (ID, nome, vidaMax, vidaAtual, forca, agilidade,imagem) values (3, 'Minerva', 20, 20, 6, 12, 'minerva.png')
Insert into Monstro (ID, nome, vidaMax, vidaAtual, forca, agilidade,imagem) values (4, 'Gigante', 15, 15, 7, 2, 'gigante.png')
Insert into Monstro (ID, nome, vidaMax, vidaAtual, forca, agilidade,imagem) values (5, 'Polifemo', 15, 15, 7, 4, 'polifemo.png')
Insert into Monstro (ID, nome, vidaMax, vidaAtual, forca, agilidade,imagem) values (6, 'Netuno', 25, 25, 10, 10, 'netuno.png')
Insert into Monstro (ID, nome, vidaMax, vidaAtual, forca, agilidade,imagem) values (7, 'Empousa', 10, 10, 4, 6, 'empousa.png')
Insert into Monstro (ID, nome, vidaMax, vidaAtual, forca, agilidade,imagem) values (8, 'Cerbero', 20, 20, 10, 4, 'cerbero.png')
Insert into Monstro (ID, nome, vidaMax, vidaAtual, forca, agilidade,imagem) values (9, 'Plutão', 25, 25, 10, 14, 'plutao.png')
Insert into Monstro (ID, nome, vidaMax, vidaAtual, forca, agilidade,imagem) values (10, 'Gegenes', 10, 10, 5, 7, 'gegenes.png')
Insert into Monstro (ID, nome, vidaMax, vidaAtual, forca, agilidade,imagem) values (11, 'Hidra', 10,10,6,8, 'hidra.png')
Insert into Monstro (ID, nome, vidaMax, vidaAtual, forca, agilidade,imagem) values (12, 'Quimera', 10,10,8,7, 'quimera.png')
Insert into Monstro (ID, nome, vidaMax, vidaAtual, forca, agilidade,imagem) values (13, 'Jupiter', 50, 50, 15, 10, 'jupiter.png')
INSERT INTO Monstro (ID, nome, vidaMax, vidaAtual, forca, agilidade,imagem) VALUES (14, 'Correx', 100, 100, 100, 100, 'correx.png')

-- salad.png  vai só para diretia
-- saladf.png   vai para direita e frent
-- salae.png   vai para esquerda
-- salaed.png   é só olhar a terminação
-- salaedf.png
-- salaef.png
-- salaf.png
-- salan.png   não vai para lugar nenhum, só volta bb

--esses são de um nível bem pequeno e chato mais funciona
/*
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (1, null, null, null, null, 2, null, 'salaf.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (2, null, null, 3, 9, null, 1, 'salaed.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (3, null, null, null, null, 4, 2, 'salaf.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (4, null, 11, null, 5, null, 3, 'salad.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (5, null, null, null, null, 6, 4, 'salaf.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (6, 1, null, null, 7, 8, 5, 'saladf.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (7, null, 13, null, null, null, 6, 'salan.png') --salan sera uma sala sem nd, só vai dar para andar para trás
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (8, null, 9, null, null, null, 6, 'salan.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (9, 1, null, 11, null, 10, 2, 'salaef.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (10, null, 2, null, null, null, 9, 'salan.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (11, null, null, null, null, 12, 9, 'salaf.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (12, null, null, 13, null, null, 11, 'salae.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (13, null, null, null, 14, null, 12, 'salad.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (14, null, 14, null, null, 15, 13, 'salaf.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (15, 13, null, null, null, null, 14, 'salan.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (16, 1, null, null, null, null, 5, 'salan.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (17, 12, null, null, null, null, 13, 'salan.png')
*/


--aqui é um nivel grande mais legalsinho
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (1, null, null, null, null, 2, null, 'salaf.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (2, null, null, 11, 3, null, 1, 'salaed.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (3, null, null, 6, null, 4, 2, 'salaef.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (4, 1, null, 5, null, null, 3, 'salae.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (5, null, 12, null, null, null, 4, 'salan.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (6, null, 2, null, null, 7, 3, 'salaf.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (7, 4, null, 9, 8, null, 6, 'salaed.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (8, null, 17, null, null, null, 7, 'salan.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (9, null, null, null, 10, null, 7, 'salad.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (10, null, 3, null, null, 19, 9, 'salaf.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (11, null, null, null, 12, null, 2, 'salad.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (12, 7, null, 15, null, 13, 11, 'salaef.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (13, null, 2, null, null, 14, 12, 'salaf.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (14, null, 7, null, null, null, 13, 'salan.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (15, null, null, null, null, 16, 12, 'salaf.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (16, null, 4, null, 17, null, 15, 'salad.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (17, 11, null, null, null, 18, 16, 'salaf.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (18, null, 13, null, null, null, 17, 'salan.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (19, 7, null, 22, 20, 23, 10, 'salaedf.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (20, null, null, 25, null, 21, 19, 'salaef.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (21, null, 7, null, 32, null, 20, 'salad.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (22, null, 12, null, null, null, 19, 'salan.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (23, null, 3, null, null, 24, 19, 'salaf.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (24, 8, null, null, null, null, 23, 'salan.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (25, null, null, null, null, 26, 20, 'salaf.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (26, null, null, null, 27, null, 25, 'salad.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (27, null, null, null, null, 28, 26, 'salaf.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (28, null, 3, null, 29, null, 27, 'salad.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (29, 13, null, null, null, 30, 28, 'salaf.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (30, null, 15, null, null, 31, 29, 'salaf.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (31, null, 8, null, null, null, 30, 'salaf.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (32, 6, null, null, null, 33, 21, 'salaf.png')
INSERT INTO Sala (ID,monstro_ID,bau_id,esquerda,direita,frente,tras,imagem) VALUES (33, null, 14, null, null, null, 32, 'salaf.png')

delete from Sala
INSERT INTO Personagem (ID,nome,vidaMax,vidaAtual,forca,agilidade,nivel,equipamento,imagem) VALUES (1, 'Eneias', 20, 20, 5, 4, 0, 1, 'p1.png')
INSERT INTO Personagem (ID,nome,vidaMax,vidaAtual,forca,agilidade,nivel,equipamento,imagem) VALUES (2, 'Réia', 25, 25, 3, 6, 0, 1, 'p2.png')
INSERT INTO Personagem (ID,nome,vidaMax,vidaAtual,forca,agilidade,nivel,equipamento,imagem) VALUES (3, 'Jasão', 15, 15, 4, 8, 0, 1, 'p3.png')

