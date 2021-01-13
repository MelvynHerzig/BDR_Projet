-- MySQL Script Gestionnaire de tournois rocket League
-- Fri Dec 11 11:16:36 2020
-- Model: New Model    Version: 1.0
-- Berney Alec, Forestier Quentin, Herzig Melvyn

DROP SCHEMA IF EXISTS GestionnaireDeTournoisRocketLeague ;

CREATE SCHEMA IF NOT EXISTS GestionnaireDeTournoisRocketLeague DEFAULT CHARACTER SET utf8mb4;
USE GestionnaireDeTournoisRocketLeague;


CREATE TABLE Prix 
(
  id INT AUTO_INCREMENT,
  montantArgent INT UNSIGNED NOT NULL,
  CONSTRAINT PK_Prix PRIMARY KEY (id)
);


CREATE TABLE Tournoi
(
  id INT AUTO_INCREMENT,
  dateHeureDebut DATETIME NOT NULL,
  dateHeureFin DATETIME,
  nom VARCHAR(50) NOT NULL,
  nbEquipesMax INT NOT NULL,
  idPrixPremier INT NULL,
  idPrixSecond INT NULL,
  CONSTRAINT PK_Tournoi PRIMARY KEY (id)
);


CREATE TABLE Tour
(
  no INT,
  longueurMaxSerie INT NOT NULL,
  idTournoi INT NOT NULL,
  CONSTRAINT PK_Tour PRIMARY KEY (no, idTournoi)
);


CREATE TABLE Serie
(
  id INT,
  noTour INT NOT NULL,
  idTournoi INT NOT NULL,
  acronymeEquipe1 VARCHAR(3),
  acronymeEquipe2 VARCHAR(3),
  CONSTRAINT PK_Serie PRIMARY KEY (id, noTour, idTournoi)
);


CREATE TABLE `Match`
(
  id INT,
  idSerie INT NOT NULL,
  noTour INT NOT NULL,
  idTournoi INT NOT NULL,
  CONSTRAINT PK_Match PRIMARY KEY (id, idSerie, noTour, idTournoi)
);


CREATE TABLE Objet 
(
  id INT AUTO_INCREMENT,
  nom VARCHAR(100) NOT NULL,
  CONSTRAINT PK_Objet PRIMARY KEY (id)
);


CREATE TABLE Joueur
(
  id INT AUTO_INCREMENT,
  nom VARCHAR(50) NOT NULL,
  prenom VARCHAR(50) NOT NULL,
  email VARCHAR(250) NOT NULL,
  pseudo VARCHAR(50) NOT NULL,
  dateNaissance DATE NOT NULL,
  CONSTRAINT PK_Joueur PRIMARY KEY (id)
);


CREATE TABLE Equipe
(
  acronyme VARCHAR(3),
  nom VARCHAR(100) NOT NULL,
  idResponsable INT NOT NULL,
  CONSTRAINT PK_Equipe PRIMARY KEY (acronyme)
);


CREATE TABLE Equipe_Joueur
(
  acronymeEquipe VARCHAR(3) NOT NULL,
  idJoueur INT NOT NULL,
  dateHeureArrivee DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  dateHeureDepart DATETIME,
  CONSTRAINT PK_Equipe_Joueur PRIMARY KEY (acronymeEquipe, idJoueur, dateHeureArrivee)
);


CREATE TABLE Match_Joueur 
(
  idJoueur INT NOT NULL,
  nbButs INT UNSIGNED NOT NULL,
  nbArrets INT UNSIGNED NOT NULL,
  idMatch INT NOT NULL,
  idSerie INT NOT NULL,
  noTour INT NOT NULL,
  idTournoi INT NOT NULL,
  CONSTRAINT PK_Match_Joueur PRIMARY KEY (idJoueur, idMatch, idSerie, noTour, idTournoi)
);


CREATE TABLE Tournoi_Equipe
(
  idTournoi INT NOT NULL,
  acronymeEquipe VARCHAR(3) NOT NULL,
  dateInscription DATETIME NOT NULL,
  CONSTRAINT PK_Tournoi_Equipe PRIMARY KEY (idTournoi, acronymeEquipe)
);

CREATE TABLE Prix_Objet 
(
  idPrix INT NOT NULL,
  idObjet INT NOT NULL,
  CONSTRAINT PK_Prix_Objet PRIMARY KEY (idPrix, idObjet)
);


-----------------------------------------------------
-- Ajout de contraintes + index pour la table Tournoi
-----------------------------------------------------
ALTER TABLE Tournoi ADD CONSTRAINT FK_Tournoi_idPrixPremier
	FOREIGN KEY (idPrixPremier) 
	REFERENCES Prix (id)
    ON DELETE RESTRICT
    ON UPDATE CASCADE;

ALTER TABLE Tournoi ADD CONSTRAINT FK_Tournoi_idPrixSecond 
	FOREIGN KEY (idPrixSecond) 
	REFERENCES Prix (id)
	ON DELETE RESTRICT
    ON UPDATE CASCADE;

ALTER TABLE Tournoi ADD INDEX FK_Tournoi_idPrixPremier_idx (idPrixPremier);
ALTER TABLE Tournoi ADD INDEX FK_Tournoi_idPrixSecond_idx (idPrixSecond);

---------------------------------------------------
-- Ajout de contraintes + index  pour la table Tour
---------------------------------------------------

ALTER TABLE Tour ADD CONSTRAINT FK_Tour_idTournoi
    FOREIGN KEY (idTournoi)
    REFERENCES Tournoi (id)
    ON DELETE CASCADE
    ON UPDATE CASCADE;

ALTER TABLE Tour ADD INDEX FK_Tour_idTournoi_idx (idTournoi);

---------------------------------------------------
-- Ajout de contraintes + index pour la table Serie
---------------------------------------------------
ALTER TABLE Serie ADD CONSTRAINT FK_Serie_idTour
    FOREIGN KEY (noTour , idTournoi)
    REFERENCES Tour (no , idTournoi)
    ON DELETE CASCADE
    ON UPDATE CASCADE;

ALTER TABLE Serie ADD CONSTRAINT FK_Serie_acronymeEquipe1
    FOREIGN KEY (acronymeEquipe1)
    REFERENCES Equipe (acronyme)
    ON DELETE RESTRICT
    ON UPDATE CASCADE;

ALTER TABLE Serie ADD CONSTRAINT FK_Serie_acronymeEquipe2
    FOREIGN KEY (acronymeEquipe2)
    REFERENCES Equipe (acronyme)
    ON DELETE RESTRICT
    ON UPDATE CASCADE;

ALTER TABLE Serie ADD INDEX FK_Serie_idTour_idx (noTour, idTournoi);
ALTER TABLE Serie ADD INDEX FK_Serie_acronymeEquipe1_idx (acronymeEquipe1);
ALTER TABLE Serie ADD INDEX FK_Serie_acronymeEquipe2_idx (acronymeEquipe2);

---------------------------------------------------
-- Ajout de contraintes + index pour la table Match
---------------------------------------------------
ALTER TABLE `Match` ADD CONSTRAINT FK_Match_idSerie
    FOREIGN KEY (idSerie , noTour , idTournoi)
    REFERENCES Serie (id , noTour , idTournoi)
    ON DELETE CASCADE
    ON UPDATE CASCADE;

ALTER TABLE `Match` ADD INDEX FK_Match_idSerie_idx (idSerie, noTour, idTournoi);

-----------------------------------------------------
-- Ajout de contraintes + index  pour la table Equipe
-----------------------------------------------------
ALTER TABLE Equipe ADD  CONSTRAINT FK_Equipe_idJoueur
    FOREIGN KEY (idResponsable)
    REFERENCES Joueur (id)
    ON DELETE RESTRICT
    ON UPDATE CASCADE;

ALTER TABLE Equipe ADD INDEX FK_Equipe_idResponsable_idx (idResponsable);
ALTER TABLE Equipe ADD UNIQUE INDEX UC_Equipe_idResponsable_idx (idResponsable);

------------------------------------------------------------
-- Ajout de contraintes + index  pour la table Equipe_Joueur
------------------------------------------------------------
ALTER TABLE Equipe_Joueur ADD CONSTRAINT FK_Equipe_Joueur_acronymeEquipe
    FOREIGN KEY (acronymeEquipe)
    REFERENCES Equipe (acronyme)
    ON DELETE RESTRICT
    ON UPDATE CASCADE;

ALTER TABLE Equipe_Joueur ADD CONSTRAINT FK_Equipe_Joueur_idJoueur
    FOREIGN KEY (idJoueur)
    REFERENCES Joueur (id)
    ON DELETE RESTRICT
    ON UPDATE CASCADE;

ALTER TABLE Equipe_Joueur ADD INDEX FK_Equipe_Joueur_idJoueur_idx (idJoueur);
ALTER TABLE Equipe_Joueur ADD INDEX FK_Equipe_Joueur_acronymeEquipe_idx (acronymeEquipe);
ALTER TABLE Equipe_Joueur ADD INDEX FK_Equipe_Joueur_dateHeureArrivee_idx (dateHeureArrivee);

-----------------------------------------------------------
-- Ajout de contraintes + index  pour la table Match_Joueur
-----------------------------------------------------------
ALTER TABLE Match_Joueur ADD CONSTRAINT FK_Match_Joueur_idJoueur
    FOREIGN KEY (idJoueur)
    REFERENCES Joueur (id)
    ON DELETE RESTRICT
    ON UPDATE CASCADE;

ALTER TABLE Match_Joueur ADD CONSTRAINT FK_Match_Joueur_idMatch
    FOREIGN KEY (idMatch , idSerie , noTour , idTournoi)
    REFERENCES `Match` (id , idSerie , noTour , idTournoi)
    ON DELETE RESTRICT
    ON UPDATE CASCADE;

ALTER TABLE Match_Joueur ADD INDEX FK_Match_Joueur_idJoueur_idx (idJoueur);
ALTER TABLE Match_Joueur ADD INDEX FK_Match_Joueur_idMatch_idx (idMatch, idSerie, noTour, idTournoi);

-------------------------------------------------------------
-- Ajout de contraintes + index  pour la table Tournoi_Equipe
-------------------------------------------------------------
ALTER TABLE Tournoi_Equipe ADD CONSTRAINT FK_Tournoi_Equipe_idTournoi
    FOREIGN KEY (idTournoi)
    REFERENCES Tournoi (id)
    ON DELETE CASCADE
    ON UPDATE CASCADE;

ALTER TABLE Tournoi_Equipe ADD CONSTRAINT FK_Tournoi_Equipe_acronymeEquipe
    FOREIGN KEY (acronymeEquipe)
    REFERENCES Equipe (acronyme)
    ON DELETE RESTRICT
    ON UPDATE CASCADE;

ALTER TABLE Tournoi_Equipe ADD INDEX FK_Tournoi_Equipe_acronymeEquipe_idx (acronymeEquipe);
ALTER TABLE Tournoi_Equipe ADD INDEX FK_Tournoi_Equipe_idTournoi_idx (idTournoi);

---------------------------------------------------------
-- Ajout de contraintes + index  pour la table Prix_Objet
---------------------------------------------------------
ALTER TABLE Prix_Objet ADD CONSTRAINT FK_Prix_Objet_idPrix
    FOREIGN KEY (idPrix)
    REFERENCES Prix (id)
    ON DELETE CASCADE
    ON UPDATE CASCADE;

ALTER TABLE Prix_Objet ADD CONSTRAINT FK_Prix_Objet_idObjet
    FOREIGN KEY (idObjet)
    REFERENCES Objet (id)
    ON DELETE RESTRICT
    ON UPDATE CASCADE;

ALTER TABLE Prix_Objet ADD INDEX FK_Prix_Objet_idObjet_idx (idObjet);
ALTER TABLE Prix_Objet ADD INDEX FK_Prix_Objet_idPrix_idx (idPrix);

---------------------------------------------------------
-- Ajout de contraintes + index  pour la table Objet
---------------------------------------------------------
ALTER TABLE Objet ADD UNIQUE INDEX UC_Objet_nom_idx (nom);

------------------------------------------------------
-- Ajout de contraintes + index  pour la table Joueur
-----------------------------------------------------
ALTER TABLE Joueur ADD UNIQUE INDEX UC_Joueur_email_idx (email);

-----------------------------------------------------
-- DONNEES
------------------------------------------------------
INSERT INTO Objet (nom)
VALUES 
( 'Clavier Roccat' ),
( 'Souris Roccat' ),
( 'Casque Logitec' ),
( 'Ecran BenQ' ),
( 'PC  Alienware' );

INSERT INTO Prix (montantArgent)
VALUES 
( 50 ),
( 100 ),
( 150 ),
( 200 ),
( 250 ),
( 300 ),
( 350 ),
( 500 ),
( 1000 ),
( 1500 ),
( 2000 );

INSERT INTO Prix_Objet 
VALUES 
( 1, 1 ),
( 2, 2 ),
( 3, 3 ),
( 4, 4 ),
( 5, 5 );

INSERT INTO Joueur (nom, prenom, email, pseudo, dateNaissance)
VALUES 
( 'Forestier', 'Quentin', 'quentin.forestier@heig-vd.ch', 'Dudude', '2001-05-16' ),
( 'Herzig', 'Melvyn', 'melvyn.herzig@heig-vd.ch', 'Wheald', '1997-09-11' ),
( 'Crausaz', 'Nicolas', 'nicolas.crausaz@heig-vd.ch', 'itsaboi', '1999-08-03' ),
( 'Brescard', 'Julien', 'Jujuju@lse.ch', 'Jujuju', '2002-09-16' ),
( 'Baggiolini', 'Jonas', 'Arcko0o@lse.ch', 'Arcko0o', '2000-11-15' ),
( 'Eggenberger', 'Kevin', 'Keever@lse.ch', 'Keever', '1999-01-10' ),
( 'Candolfi', 'Kérian', 'Kerian@solary.fr', 'Kérian', '2003-08-21' ),
( 'Bigeard', 'Brice', 'ExoTiiK@solary.fr', 'ExoTiiK', '2002-10-31' ),
( 'Schäfer', 'Damian', 'Tox@solary.fr', 'Tox', '2003-06-08' ),
( 'Packwood-Clarke', 'Jack', 'Speed@teamliquid.com', 'Speed', '2001-02-26' ),
( 'Moselund', 'Emil', 'fruity@teamliquid.com', 'fruity', '1996-02-22' ),
( 'Hodzic', 'Aldin', 'Ronaky@teamliquid.com', 'Ronaky', '2000-09-21' ),
( 'Jakober', 'Lukas', 'Zaphare@eldelweiss.ch', 'Zaphare', '2000-04-07' ),
( 'Lentz', 'Quentin', 'Mirror@eldelweiss.ch', 'Mirror', '2002-09-05' ),
( 'Sauvey', 'Baptiste', 'BatOu@eldelweiss.ch', 'BatOu', '2001-10-28' ),
( 'Courant', 'Alexandre', 'Kaydop@vitality.fr', 'Kaydop', '1998-05-22' ),
( 'Champenois', 'Yanis', 'Alpha54@vitality.fr', 'Alpha54', '2003-05-27' ),
( 'Loquet', 'Victor', 'Fairy_Peak@vitality.fr', 'Fairy Peak!', '1998-05-26' ),
( 'Van Meurs', 'Jos', 'ViolentPanda@dignitas.com', 'ViolentPanda', '1998-11-02' ),
( 'Robben', 'Joris', 'Joreuz@dignitas.com', 'Joreuz', '2005-03-08' ),
( 'Benton', 'Jack', 'ApparentlyJack@dignitas.com', 'ApparentlyJack', '2003-09-23' ),
( 'Oosting', 'Ronald', 'Tahz@fcbarcelona.com', 'Tahz', '1999-08-03' ),
( 'Lazarus', 'Fredi', 'Blurry@fcbarcelona.com', 'Blurry', '2004-06-30' ),
( 'Gimenez', 'Nacho', 'Nachitow@fcbarcelona.com', 'Nachitow', '2000-06-20' ),
( 'Driessen', 'Mitchell', 'Mittaen@galaxyracer.com', 'Mittaen', '2000-06-20' ),
( 'Pickering', 'Dylan', 'eekso@galaxyracer.com', 'eekso', '2002-06-29' ),
( 'Berdin', 'Ario', 'arju@galaxyracer.com', 'arju', '2002-11-04' ),
( 'Bosch', 'Marc', 'Stake@giantsgaming.com', 'Stake', '2000-07-20' ),
( 'Cortés', 'Samuel', 'Zamué@giantsgaming.com', 'Zamué', '2000-10-19' ),
( 'Benayachi', 'Amine', 'itachi@giantsgaming.com', 'itachi', '2003-08-13' ),
( 'Doe', 'John', 'johnny@uc1.com', 'johnny', '2000-01-01' ),
( 'Kiroule', 'Pierre', 'pierre@uc2.com', 'pierre', '1990-02-01' ),
( 'Kévin', 'Jean', 'kevin@uc2.com', 'kévin', '1990-03-01' ),
( 'Gabin', 'Jean', 'gabin@sansequipe.com', 'gabin', '1990-04-01' ),
( 'Berset', 'Alin', 'theking@sansequipe.com', 'theking', '1980-04-01' ),
( 'Maxime', 'Berthoud', 'max@sansequipe.com', 'max', '2005-04-01' );


INSERT INTO Equipe
VALUES 
( 'ROC', 'Real Original Cracks', 1 ),
( 'LSE', 'Lausanne eSports', 4 ),
( 'SLY', 'Solary', 7 ),
( 'TL', 'Team Liquid', 10 ),
( 'EE', 'Eldelweiss ESports', 13 ),
( 'VIT', 'Renault Vitality', 16 ),
( 'DIG', 'Dignitas', 19 ),
( 'FCB', 'FC Barcelona', 22 ),
( 'GAR', 'Galaxy Racer', 25 ),
( 'GIA', 'Giants Gaming', 28 ),
( 'UC1', 'Uncomplete1',  31),
( 'UC2', 'Uncomplete2',  33);


INSERT INTO Equipe_Joueur
VALUES 
( 'SLY', 1,  '2014-01-01 00:00:00','2018-03-01 00:00:00' ),
( 'SLY', 2,  '2015-01-01 00:00:00','2018-04-01 00:00:00' ),
( 'SLY', 3,  '2016-01-01 00:00:00','2018-02-01 00:00:00' ),

('ROC', 34, '0001-01-01 00:00:00', NULL ),
('SLY', 35, '0001-01-01 00:00:00', NULL ),

( 'ROC', 1,  '2020-01-01 00:00:00', NULL ),
( 'ROC', 2,  '2020-01-01 00:00:00', NULL ),
( 'ROC', 3,  '2020-01-01 00:00:00', NULL ),
( 'LSE', 4,  '2020-01-01 00:00:00', NULL ),
( 'LSE', 5,  '2020-01-01 00:00:00', '2020-12-25 11:00:00' ),
( 'LSE', 6,  '2020-01-01 00:00:00', NULL ),
( 'SLY', 7,  '2020-01-01 00:00:00', NULL ),
( 'SLY', 8,  '2020-01-01 00:00:00', NULL ),
( 'SLY', 9,  '2020-01-01 00:00:00', NULL ),
( 'TL', 10,  '2020-01-01 00:00:00', NULL ),
( 'TL', 11,  '2020-01-01 00:00:00', NULL ),
( 'TL', 12,  '2020-01-01 00:00:00', NULL ),
( 'EE', 13,  '2020-01-01 00:00:00', NULL ),
( 'EE', 14,  '2020-01-01 00:00:00', NULL ),
( 'EE', 15,  '2020-01-01 00:00:00', '2020-12-28 17:00:00' ),
( 'VIT', 16,  '2020-01-01 00:00:00', NULL ),
( 'VIT', 17,  '2020-01-01 00:00:00', '2020-12-27 20:00:00' ),
( 'VIT', 18,  '2020-01-01 00:00:00', NULL ),
( 'DIG', 19,  '2020-01-01 00:00:00', NULL ),
( 'DIG', 20,  '2020-01-01 00:00:00', '2020-12-26 19:00:00' ),
( 'DIG', 21,  '2020-01-01 00:00:00', NULL ),
( 'FCB', 22,  '2020-01-01 00:00:00', NULL ),
( 'FCB', 23,  '2020-01-01 00:00:00', NULL ),
( 'FCB', 24,  '2020-01-01 00:00:00', NULL ),
( 'GAR', 25,  '2020-01-01 00:00:00', NULL ),
( 'GAR', 26,  '2020-01-01 00:00:00', NULL ),
( 'GAR', 27,  '2020-01-01 00:00:00', NULL ),
( 'GIA', 28,  '2020-01-01 00:00:00', NULL ),
( 'GIA', 29,  '2020-01-01 00:00:00', NULL ),
( 'GIA', 30,  '2020-01-01 00:00:00', NULL ),

( 'VIT', 20,  '2020-12-28 00:00:00', NULL ),
( 'DIG', 17,  '2020-12-29 00:00:00', NULL ),

( 'EE', 5,  '2020-12-30 00:00:00', NULL ),
( 'LSE', 15,  '2020-12-30 00:00:00', NULL ),

( 'UC1', 31,  '2020-01-30 00:00:00', NULL ),
( 'UC1', 32,  '2020-01-30 00:00:00', NULL ),
( 'UC2', 33,  '2020-01-30 00:00:00', NULL ),
( 'UC2', 36,  '2020-01-30 00:00:00', '2021-01-01 20:00:00' );


INSERT INTO Tournoi (dateHeureDebut, nom, nbEquipesMax, dateHeureFin, idPrixPremier, idPrixSecond)
VALUES 
( '2020-02-01 20:00:00', 'Le Franco-Suisse', 4, '2020-02-01 23:00:00', 2, 1),
( '2020-03-01 20:00:00', 'IEM', 8, '2020-04-01 23:00:00', 3, 2),
( '2020-12-02', 'Tournoi de préparation en cours', 2, NULL, 4, 3),
( '2020-12-01', 'Tournoi de préparation annulé', 2, '2020-12-01', 5, 4),
( '2020-12-03', 'Tournoi 4 équipe en cours séries en cours', 4, NULL, 6, 5),
( '2020-12-04', 'Tournoi 4 équipe en cours tour 1 terminé', 4, NULL, 7, 6 ),
( '2022-02-01', 'Tournoi 4 équipe en attente 3/4', 4, NULL, 8, 7 ),
( '2022-03-01', 'Tournoi 4 équipe en attente 4/4', 4, NULL, 9, 8 ),
( Now(), 'Tournoi 4 équipe en attente prêt 4/4', 4, NULL, 10, 9 );


INSERT INTO Tour
VALUES 
( 2, 1, 1 ),
( 1, 3, 1 ),

( 3, 1, 2 ),
( 2, 1, 2 ),
( 1, 3, 2 ),

( 1, 3, 3 ),

( 1, 3, 4 ),

( 2, 3, 5 ),
( 1, 3, 5 ),

( 2, 1, 6 ),
( 1, 3, 6 ),

( 2, 1, 7 ),
( 1, 1, 7 ),

( 2, 1, 8 ),
( 1, 1, 8 ),

( 2, 1, 9 ),
( 1, 1, 9 );

INSERT INTO Tournoi_Equipe
VALUES 
( 1, 'ROC', '2020-01-01 20-00-00' ),
( 1, 'SLY', '2020-01-01 20-01-00' ),
( 1, 'EE', '2020-01-01 20-02-00' ),
( 1, 'VIT', '2020-01-01 20-02-00' ),

( 2, 'ROC', '2020-02-01 20-00-00' ),
( 2, 'TL', '2020-02-01 20-01-00' ),
( 2, 'EE', '2020-02-01 20-02-00' ),
( 2, 'VIT', '2020-02-01 20-03-00' ),
( 2, 'DIG', '2020-02-01 20-04-00' ),
( 2, 'LSE', '2020-02-01 20-05-00' ),
( 2, 'FCB', '2020-02-01 20-05-00' ),
( 2, 'SLY', '2020-02-01 20-06-00' ),

( 3, 'ROC', '2020-01-12 20-00-00' ),
( 3, 'SLY', '2020-02-12 20-01-00' ),

( 4, 'ROC', '2020-10-12 20-00-00' ),

( 5, 'GAR', '2020-11-05 20-04-00' ),
( 5, 'LSE', '2020-11-06 20-05-00' ),
( 5, 'GIA', '2020-11-07 20-05-00' ),
( 5, 'SLY', '2020-11-08 20-06-00' ),

( 6, 'ROC', '2020-09-01 20-00-00' ),
( 6, 'SLY', '2020-10-02 20-01-00' ),
( 6, 'LSE', '2020-11-03 20-02-00' ),
( 6, 'VIT', '2020-12-01 20-02-00' ),

( 7, 'GIA', '2020-09-01 20-00-00' ),
( 7, 'EE', '2020-10-02 20-01-00' ),
( 7, 'LSE', '2020-11-03 20-02-00' ),

( 8, 'ROC', '2020-09-01 20-00-00' ),
( 8, 'SLY', '2020-10-02 20-01-00' ),
( 8, 'LSE', '2020-11-03 20-02-00' ),
( 8, 'VIT', '2020-12-01 20-02-00' ),

( 9, 'TL', '2020-08-01 20-00-00' ),
( 9, 'FCB', '2020-09-02 20-01-00' ),
( 9, 'GAR', '2020-09-03 20-02-00' ),
( 9, 'GIA', '2020-10-01 20-02-00' );


-- Tournoi 1
INSERT INTO Serie
VALUES ( 1, 2, 1, 'ROC', 'SLY' );

INSERT INTO `Match`
VALUES 
( 1, 1, 2, 1 );

INSERT INTO Match_Joueur
VALUES 
( 1, 3, 1, 1, 1, 2, 1 ),
( 2, 0, 3, 1, 1, 2, 1 ),
( 3, 1, 2, 1, 1, 2, 1 ),
( 7, 0, 2, 1, 1, 2, 1 ),
( 8, 1, 0, 1, 1, 2, 1 ),
( 9, 1, 4, 1, 1, 2, 1 );

INSERT INTO Serie
VALUES ( 2, 2, 1, 'EE', 'VIT' );

INSERT INTO `Match`
VALUES 
( 1, 2, 2, 1 );

INSERT INTO Match_Joueur
VALUES 
( 13, 3, 1, 1, 2, 2, 1 ),
( 14, 0, 3, 1, 2, 2, 1 ),
( 15, 4, 2, 1, 2, 2, 1 ),
( 16, 1, 2, 1, 2, 2, 1 ),
( 17, 1, 0, 1, 2, 2, 1 ),
( 18, 1, 4, 1, 2, 2, 1 );

INSERT INTO Serie
VALUES ( 1, 1, 1, 'ROC', 'EE');

INSERT INTO `Match`
VALUES 
( 1, 1, 1, 1 ),
( 2, 1, 1, 1 ),
( 3, 1, 1, 1 );

INSERT INTO Match_Joueur
VALUES 
( 1, 1, 5, 1, 1, 1, 1 ),
( 2, 0, 3, 1, 1, 1, 1 ),
( 3, 1, 2, 1, 1, 1, 1 ),
( 13, 0, 2, 1, 1, 1, 1 ),
( 14, 0, 3, 1, 1, 1, 1 ),
( 15, 0, 4, 1, 1, 1, 1 ),

( 1, 0, 1, 2, 1, 1, 1 ),
( 2, 2, 3, 2, 1, 1, 1 ),
( 3, 1, 2, 2, 1, 1, 1 ),
( 13, 8, 5, 2, 1, 1, 1 ),
( 14, 0, 1, 2, 1, 1, 1 ),
( 15, 1, 4, 2, 1, 1, 1 ),

( 1, 6, 1, 3, 1, 1, 1 ),
( 2, 2, 3, 3, 1, 1, 1 ),
( 3, 4, 2, 3, 1, 1, 1 ),
( 13, 1, 5, 3, 1, 1, 1 ),
( 14, 0, 1, 3, 1, 1, 1 ),
( 15, 1, 4, 3, 1, 1, 1 );


-- Tournoi 2
INSERT INTO Serie
VALUES ( 1, 3, 2, 'ROC', 'TL');

INSERT INTO `Match`
VALUES 
( 1, 1, 3, 2 );

INSERT INTO Match_Joueur
VALUES 
( 1, 0, 5, 1, 1, 3, 2 ),
( 2, 3, 1, 1, 1, 3, 2 ),
( 3, 4, 2, 1, 1, 3, 2 ),
( 10, 0, 1, 1, 1, 3, 2 ),
( 11, 1, 3, 1, 1, 3, 2 ),
( 12, 2, 0, 1, 1, 3, 2 );

INSERT INTO Serie
VALUES ( 2, 3, 2, 'EE', 'VIT' );

INSERT INTO `Match`
VALUES 
( 1, 2, 3, 2 );

INSERT INTO Match_Joueur
VALUES 
( 13, 2, 8, 1, 2, 3, 2 ),
( 14, 3, 2, 1, 2, 3, 2 ),
( 15, 1, 0, 1, 2, 3, 2 ),
( 16, 1, 4, 1, 2, 3, 2 ),
( 17, 0, 1, 1, 2, 3, 2 ),
( 18, 1, 3, 1, 2, 3, 2 );

INSERT INTO Serie
VALUES ( 3, 3, 2, 'DIG', 'LSE' );

INSERT INTO `Match`
VALUES 
( 1, 3, 3, 2 );

INSERT INTO Match_Joueur
VALUES 
( 19, 0, 0, 1, 3, 3, 2 ),
( 20, 0, 3, 1, 3, 3, 2 ),
( 21, 1, 0, 1, 3, 3, 2 ),
( 4, 3, 3, 1, 3, 3, 2 ),
( 5, 6, 2, 1, 3, 3, 2 ),
( 6, 1, 9, 1, 3, 3, 2 );

INSERT INTO Serie
VALUES ( 4, 3, 2, 'FCB', 'SLY' );

INSERT INTO `Match`
VALUES 
( 1, 4, 3, 2 );

INSERT INTO Match_Joueur
VALUES 
( 22, 3, 1, 1, 4, 3, 2 ),
( 23, 0, 4, 1, 4, 3, 2 ),
( 24, 1, 1, 1, 4, 3, 2 ),
( 7, 4, 1, 1, 4, 3, 2 ),
( 8, 2, 2, 1, 4, 3, 2 ),
( 9, 0, 7, 1, 4, 3, 2 );

INSERT INTO Serie
VALUES ( 1, 2, 2, 'ROC', 'EE' );

INSERT INTO `Match`
VALUES 
( 1, 1, 2, 2 );

INSERT INTO Match_Joueur
VALUES 
( 1, 3, 4, 1, 1, 2, 2 ),
( 2, 2, 0, 1, 1, 2, 2 ),
( 3, 1, 5, 1, 1, 2, 2 ),
( 13, 0, 4, 1, 1, 2, 2 ),
( 14, 2, 1, 1, 1, 2, 2 ),
( 15, 1, 3, 1, 1, 2, 2 );

INSERT INTO Serie
VALUES ( 2, 2, 2, 'LSE', 'SLY' );

INSERT INTO `Match`
VALUES 
( 1, 2, 2, 2 );

INSERT INTO Match_Joueur
VALUES 
( 4, 3, 2, 1, 2, 2, 2 ),
( 5, 0, 7, 1, 2, 2, 2 ),
( 6, 5, 1, 1, 2, 2, 2 ),
( 7, 1, 3, 1, 2, 2, 2 ),
( 8, 1, 6, 1, 2, 2, 2 ),
( 9, 2, 2, 1, 2, 2, 2 );

INSERT INTO Serie
VALUES ( 1, 1, 2, 'ROC', 'LSE' );

INSERT INTO `Match`
VALUES 
( 1, 1, 1, 2 ),
( 2, 1, 1, 2 );

INSERT INTO Match_Joueur
VALUES 
( 1, 1, 3, 1, 1, 1, 2 ),
( 2, 1, 4, 1, 1, 1, 2 ),
( 3, 0, 5, 1, 1, 1, 2 ),
( 4, 0, 2, 1, 1, 1, 2 ),
( 5, 1, 3, 1, 1, 1, 2 ),
( 6, 0, 4, 1, 1, 1, 2 ),
( 1, 1, 1, 2, 1, 1, 2 ),
( 2, 1, 5, 2, 1, 1, 2 ),
( 3, 1, 2, 2, 1, 1, 2 ),
( 4, 0, 1, 2, 1, 1, 2 ),
( 5, 1, 3, 2, 1, 1, 2 ),
( 6, 1, 6, 2, 1, 1, 2 );


-- Tournoi 3
INSERT INTO Serie
VALUES ( 1, 1, 3, 'ROC', 'SLY' );

INSERT INTO `Match`
VALUES 
( 1, 1, 1, 3 );

INSERT INTO Match_Joueur
VALUES 
( 1, 2, 2, 1, 1, 1, 3 ),
( 2, 4, 1, 1, 1, 1, 3 ),
( 3, 1, 5, 1, 1, 1, 3 ),
( 7, 2, 0, 1, 1, 1, 3 ),
( 8, 1, 1, 1, 1, 1, 3 ),
( 9, 1, 5, 1, 1, 1, 3 );


-- Tournoi 4
INSERT INTO Serie
VALUES ( 1, 1, 4, NULL, NULL );


-- Tournoi 5
INSERT INTO Serie
VALUES ( 1, 2, 5, 'GAR', 'LSE');

INSERT INTO `Match`
VALUES 
( 1, 1, 2, 5 );

INSERT INTO Match_Joueur
VALUES 
( 4, 1, 5, 1, 1, 2, 5 ),
( 5, 3, 1, 1, 1, 2, 5 ),
( 6, 2, 2, 1, 1, 2, 5 ),
( 25, 0, 1, 1, 1, 2, 5 ),
( 26, 1, 3, 1, 1, 2, 5 ),
( 27, 2, 0, 1, 1, 2, 5 );

INSERT INTO Serie
VALUES ( 2, 2, 5, 'GIA', 'SLY' );

INSERT INTO `Match`
VALUES 
( 1, 2, 2, 5 ),
( 2, 2, 2, 5 );

INSERT INTO Match_Joueur
VALUES 
( 7, 2, 8, 1, 2, 2, 5 ),
( 8, 3, 2, 1, 2, 2, 5 ),
( 9, 1, 0, 1, 2, 2, 5 ),
( 28, 1, 4, 1, 2, 2, 5 ),
( 29, 0, 1, 1, 2, 2, 5 ),
( 30, 1, 3, 1, 2, 2, 5 );

INSERT INTO Match_Joueur
VALUES 
( 7, 1, 3, 2, 2, 2, 5 ),
( 8, 0, 2, 2, 2, 2, 5 ),
( 9, 2, 0, 2, 2, 2, 5 ),
( 28, 3, 5, 2, 2, 2, 5 ),
( 29, 2, 2, 2, 2, 2, 5 ),
( 30, 0, 3, 2, 2, 2, 5 );

INSERT INTO Serie
VALUES ( 1, 1, 5, NULL, NULL );


-- Tournoi 6
INSERT INTO Serie
VALUES ( 1, 2, 6, 'ROC', 'SLY' );

INSERT INTO `Match`
VALUES 
( 1, 1, 2, 6 );

INSERT INTO Match_Joueur
VALUES 
( 1, 6, 1, 1, 1, 2, 6 ),
( 2, 0, 6, 1, 1, 2, 6 ),
( 3, 2, 5, 1, 1, 2, 6 ),
( 7, 2, 2, 1, 1, 2, 6 ),
( 8, 1, 3, 1, 1, 2, 6 ),
( 9, 1, 1, 1, 1, 2, 6 );

INSERT INTO Serie
VALUES ( 2, 2, 6, 'LSE', 'VIT' );

INSERT INTO `Match`
VALUES 
( 1, 2, 2, 6 );

INSERT INTO Match_Joueur
VALUES 
( 4, 2, 1, 1, 2, 2, 6 ),
( 5, 0, 3, 1, 2, 2, 6 ),
( 6, 1, 5, 1, 2, 2, 6 ),
( 16, 0, 2, 1, 2, 2, 6 ),
( 17, 0, 1, 1, 2, 2, 6 ),
( 18, 1, 4, 1, 2, 2, 6 );

INSERT INTO Serie
VALUES ( 1, 1, 6, NULL, NULL );

-- Tournoi 7
INSERT INTO Serie
VALUES 
( 1, 2, 7, NULL, NULL ),
( 2, 2, 7, NULL, NULL ),
( 1, 1, 7, NULL, NULL );

-- Tournoi 8
INSERT INTO Serie
VALUES 
( 1, 2, 8, NULL, NULL ),
( 2, 2, 8, NULL, NULL ),
( 1, 1, 8, NULL, NULL );

-- Tournoi 9
INSERT INTO Serie
VALUES 
( 1, 2, 9, NULL, NULL ),
( 2, 2, 9, NULL, NULL ),
( 1, 1, 9, NULL, NULL );

-----------------------------------------------------
-- FONCTIONS ET PROCEDURES STOCKEES
-----------------------------------------------------
-- Vérifie si l'équipe en paramètre est inscrite à un trounoi
DELIMITER $$
CREATE FUNCTION aUneInscriptionEnCours(pAcronymeParam VARCHAR(3))
RETURNS BOOLEAN
DETERMINISTIC
BEGIN
	 IF EXISTS (SELECT Tournoi.id FROM Tournoi
				INNER JOIN Tournoi_Equipe
					ON Tournoi.id = Tournoi_Equipe.idTournoi AND Tournoi_Equipe.acronymeEquipe = pAcronymeParam
				WHERE Tournoi.dateHeureFin IS NULL)
	THEN RETURN 1;
    ELSE RETURN 0;
    END IF;
END $$


-- Calcul le nombre de tour en fonction du nombre d'équipes maximal.
CREATE FUNCTION calculerNbTours(pNbEquipeMax INT)
RETURNS INT
DETERMINISTIC
BEGIN
	 SET @nbTour = LOG2(pNbEquipeMax);
     
     -- Vérification si nombre entier et valeur correcte. 
	 IF ( CEIL(@nbTour) = @nbTour AND @nbTour <= 8 AND @nbTour >= 1)
     THEN
		RETURN @nbTour;
	 ELSE 
		RETURN 0;
	 END IF;
END $$


-- Compte pour une équipe sont nombre de victoire dans une série.
CREATE FUNCTION compterVictoireDansSerie(pAcronymeEquipe VARCHAR(3), pIdSerie INT, pNoTour INT, pIdTournoi INT)
RETURNS INT
DETERMINISTIC
BEGIN
    SET @nbVictoires = (SELECT COUNT(1)  
						FROM (SELECT `Match`.id  AS idMatch, Serie.id AS idSerie, Serie.noTour, Serie.idTournoi, vainqueurMatch(`Match`.id, Serie.id, Serie.noTour, Serie.idTournoi) AS vainqueur 
							  FROM Serie
							  INNER JOIN `Match`
								 ON `Match`.idSerie = Serie.id AND `Match`.noTour = Serie.noTour AND `Match`.idTournoi = Serie.idTournoi
							  WHERE Serie.id = pIdSerie AND Serie.noTour = pNoTour AND Serie.idTournoi = pIdTournoi) AS vainqueurs
					    WHERE vainqueurs.Vainqueur = pAcronymeEquipe);
    
    RETURN @nbVictoires;
END $$

-- Retourne le nom de l'équipe pour un joueur à une date.
CREATE FUNCTION equipeDuJoueurLorsDu(pIdJoueur INT, pDate DATETIME)
RETURNS VARCHAR(3)
DETERMINISTIC
BEGIN
	DECLARE nomEquipe VARCHAR(3);
	SELECT Equipe_Joueur.acronymeEquipe INTO nomEquipe
	FROM Equipe_Joueur
	WHERE idJoueur = pIdJoueur AND dateHeureArrivee = (SELECT MAX(dateHeureArrivee) 
													   FROM Equipe_Joueur 
                                                       WHERE idJoueur = pIdJoueur AND dateHeureArrivee <> '0001-01-01 00:00:00' 
																				  AND dateHeureArrivee < pDate 
																				  AND (dateHeureDepart IS NULL OR dateHeureDepart > pDate));
    RETURN nomEquipe;
END $$

-- Retourne vrai si l'équip est complète sinon faux
CREATE FUNCTION estComplete(pAcronymeEquipe VARCHAR(3))
RETURNS BOOLEAN
DETERMINISTIC
BEGIN
	IF ( 3 = (SELECT COUNT(*) 
			  FROM Equipe_Joueur 
              WHERE Equipe_Joueur.acronymeEquipe = pAcronymeEquipe AND Equipe_Joueur.dateHeureDepart IS NULL AND Equipe_Joueur.dateHeureArrivee <> '0001-01-01 00:00:00'))
	THEN RETURN 1;
    ELSE RETURN 0;
    END IF;
END $$

-- Vérifie si le tournoi est en "Attente"
CREATE FUNCTION estEnAttente(pIdTournoi INT)
RETURNS BOOLEAN
DETERMINISTIC
BEGIN
	RETURN NOW() < (SELECT Tournoi.dateHeureDebut FROM Tournoi WHERE Tournoi.id = pIdTournoi);
END $$

-- Vérifie si les deux équipes peuvent jouer la série. 
CREATE FUNCTION seedingCorrect(pAcronymeEquipe1 VARCHAR(3), pAcronymeEquipe2 VARCHAR(3), pIdSerie INT, pNoTour INT, pIdTournoi INT)
RETURNS BOOLEAN
DETERMINISTIC
BEGIN
	DECLARE equipe1OK BOOLEAN DEFAULT FALSE;
    DECLARE equipe2OK BOOLEAN DEFAULT FALSE;
	-- Si premier tour du tournoi aucune vérification n'est nécessaire
    SET @nbEquipe = (SELECT Tournoi.nbEquipesMax FROM Tournoi WHERE Tournoi.id = pIdTournoi);
    IF ( calculerNbTours(@nbEquipe) = pNoTour)
    THEN
		RETURN TRUE;
	END IF;
   
    IF ( pAcronymeEquipe1 IS NULL OR pAcronymeEquipe1 = vainqueurSerie( (pIdSerie * 2) - 1, pNoTour + 1, pIdTournoi))
    THEN 
		SET equipe1OK = TRUE;
	END IF;
    
    IF ( pAcronymeEquipe2 IS NULL OR  pAcronymeEquipe2 = vainqueurSerie( pIdSerie * 2, pNoTour + 1, pIdTournoi))
    THEN 
		SET equipe2OK = TRUE;
	END IF;
    
    RETURN equipe1OK AND equipe2OK;
END $$

-- Retourne le vainqueur d'une série donnée si terminée sinon NULL.
CREATE FUNCTION vainqueurSerie(pIdSerie INT, pNoTour INT, pIdTournoi INT)
RETURNS VARCHAR(3)
DETERMINISTIC
BEGIN
    
    DECLARE ae1, ae2 VARCHAR(3); -- Acronymes des équipes de la série
    DECLARE maxVictoire INT;
    SELECT Serie.acronymeEquipe1, Serie.acronymeEquipe2 INTO ae1, ae2 FROM Serie WHERE Serie.id = pIdSerie AND Serie.noTour = pNoTour AND Serie.idTournoi = pIdTournoi;
    
    IF(ae1 IS NULL OR ae2 IS NULL)
    THEN
		RETURN NULL;
	END IF;
    
    SELECT longueurMaxSerie INTO maxVictoire FROM Tour WHERE Tour.no = pNoTour AND Tour.idTournoi = pIdTournoi;
	SET @nbVictoireE1 = compterVictoireDansSerie(ae1, pIdSerie, pNoTour, pIdTournoi);
    SET @nbVictoireE2 = compterVictoireDansSerie(ae2, pIdSerie, pNoTour, pIdTournoi);
	
    SET @taux = (maxVictoire + 1) / 2;
    
    IF(@nbVictoireE1 = @taux)
    THEN
		RETURN ae1;
	END IF;
    
    IF(@nbVictoireE2 = @taux)
    THEN
		RETURN ae2;
	END IF;
    
	RETURN NULL;
END $$

-- Retourne le nom du vainqueur d'un match.
CREATE FUNCTION vainqueurMatch(pIdMatch INT, pIdSerie INT, pNoTour INT, pIdTournoi INT)
RETURNS VARCHAR(3)
DETERMINISTIC
BEGIN
	DECLARE dateDuTournoi DATETIME;
    DECLARE be1, be2, nbe1, nbe2 INT; -- nb but et nb d'enregistrements par équipe
    DECLARE ae1, ae2 VARCHAR(3);
    SELECT Tournoi.dateHeureDebut INTO dateDuTournoi FROM Tournoi WHERE Tournoi.id = pIdTournoi;
    SELECT Serie.acronymeEquipe1, Serie.acronymeEquipe2 INTO ae1, ae2 FROM Serie WHERE Serie.id = pIdSerie AND Serie.noTour = pNoTour AND Serie.idTournoi = pIdTournoi;
    
	SELECT SUM(Match_Joueur.nbButs), COUNT(Match_Joueur.nbButs) INTO be1, nbe1 FROM Match_Joueur 
		WHERE Match_Joueur.idMatch = pIdMatch AND Match_Joueur.idSerie = pIdSerie AND Match_Joueur.noTour = pNoTour AND Match_Joueur.idTournoi = pIdTournoi AND equipeDuJoueurLorsDu(Match_Joueur.idJoueur, dateDuTournoi) = ae1;
    SELECT SUM(Match_Joueur.nbButs), COUNT(Match_Joueur.nbButs) INTO be2, nbe2 FROM Match_Joueur
		WHERE Match_Joueur.idMatch = pIdMatch AND Match_Joueur.idSerie = pIdSerie AND Match_Joueur.noTour = pNoTour AND Match_Joueur.idTournoi = pIdTournoi AND equipeDuJoueurLorsDu(Match_Joueur.idJoueur, dateDuTournoi) = ae2;
        
	IF(nbe1 <> 3 OR nbe2 <> 3) 
    THEN    
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Une équipe n\'a pas obtenu trois performances de ses joueurs dans un match présent de la série.';
    END IF;
    
    IF(be1 = be2) THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Les équipes sont à égalité, résultat impossible.';
    END IF;
    
    IF(be1 > be2) THEN
        RETURN ae1;
    ELSE 
        RETURN ae2;
    END IF;
END $$

-- Vérifie si toutes les inscriptions sont faites.
CREATE FUNCTION estComplet(pIdTournoi INT)
RETURNS BOOLEAN
DETERMINISTIC
BEGIN
	-- Nombre d'équipes max atteint ? 
    SET @maxEquipe = (SELECT Tournoi.nbEquipesMax FROM Tournoi WHERE Tournoi.id = pIdTournoi );
    SET @nbEquipe = (SELECT COUNT(1) FROM Tournoi_Equipe WHERE Tournoi_Equipe.idTournoi = pIdTournoi);
	RETURN @maxEquipe = @nbEquipe;
END $$

-- Vérifie si le seeding du premier tour du tournoi (tour avec le plus d'équipe) est fait.
CREATE FUNCTION seedingEffectue(pIdTournoi INT)
RETURNS BOOLEAN
DETERMINISTIC
BEGIN
	SET @nbEquipes = (SELECT Tournoi.nbEquipesMax FROM Tournoi WHERE Tournoi.id = pIdTournoi);
	SET @premierTour = calculerNbTours(@nbEquipes);
    
    RETURN POW(2, @premierTour)/2 = (SELECT COUNT(1) FROM Serie WHERE Serie.idTournoi = pIdTournoi AND Serie.noTour = @premierTour AND acronymeEquipe1 IS NOT NULL AND acronymeEquipe2 IS NOT NULL);
END $$

-- Vérifie que la date en paramètre est plus grande que la date courante.
CREATE PROCEDURE verifierDateFuture(pDate DATETIME)
BEGIN
	 IF pDate > NOW() THEN 
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'La date de naissance est dans le future.';
	END IF;
END $$

-- Vérifie que la date en paramètre est plus petite que la date courante.
CREATE PROCEDURE verifierDatePassee(pDate DATETIME)
BEGIN
	 IF pDate <= NOW() THEN 
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Le début du tournoi ne peut être plus petit que le temps présent.';
	END IF;
END $$


CREATE PROCEDURE verifierDatePlusPetite (pDateHeureDebut DATETIME, pDateHeureFin DATETIME)
BEGIN
	IF( pDateHeureFin IS NOT NULL AND pDateHeureDebut > pDateHeureFin)
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'La date de début ne peut être plus grande que la date de fin';
	END IF;
END $$

-- Vérifie si la joueur en paramètre a déjà une équipe
CREATE PROCEDURE verifierDejaDansUneEquipe(pIdJoueur INT)
BEGIN
	 IF EXISTS( SELECT * 
				FROM Equipe_Joueur 
                WHERE idJoueur = pIdJoueur AND dateHeureDepart IS NULL AND dateHeureArrivee <> '0001-01-01 00:00:00') 
	THEN 
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Le joueur est déjà dans une équipe';
	END IF;
END $$

-- Vérifie si une équipe est complète
CREATE PROCEDURE verifierEquipeComplete(pAcronymeEquipe VARCHAR(3))
BEGIN
	IF( NOT estComplete(pAcronymeEquipe))
	THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'L\'équipe n\'a pas trois joueur et ne peut donc pas s\'inscrire.';
	END IF;
END $$

-- Vérifie si l'équipe est inscrite au tournoi en paramètre 
CREATE PROCEDURE verifierInscription(pAcronyme VARCHAR(3), pIdTournoi INT)
BEGIN
	 IF (pAcronyme IS NOT NULL AND  NOT EXISTS( SELECT * FROM Tournoi_Equipe WHERE idTournoi = pIdTournoi AND pAcronyme = acronymeEquipe))
     THEN 
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'L\'equipe n\'est pas inscrite au tournoi';
	 END IF;
END $$

-- Vérifie si le joueur appartient à l'équipe donnée au moment du tournoi et que l'équipe fasse partie de la série.
CREATE PROCEDURE verifierJoueurEstDansEquipeSerie(pIdJoueur INT, pIdSerie INT, pNoTour INT, pIdTournoi INT)
BEGIN
    DECLARE e1, e2 VARCHAR(3);
	SET @dateTournoi = (SELECT Tournoi.dateHeureDebut FROM Tournoi WHERE Tournoi.id = pIdTournoi);
	SET @equipe = equipeDuJoueurLorsDu(pIdJoueur, @dateTournoi);
    IF (@equipe IS NULL)
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Le joueur n\'appartient pas à équipe au moment du tournoi.';
	END IF;
	
    SELECT Serie.acronymeEquipe1, Serie.acronymeEquipe2 INTO e1, e2
    FROM Serie
    WHERE Serie.id = pIdSerie AND Serie.noTour = pNoTour AND Serie.idTournoi = pIdTournoi;
    
    IF ( e1 <> @equipe AND e2 <> @equipe)
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'L\'équipe associée ne joue pas la série.';
	END IF;
END $$

-- Vérifier si la longueur maximale d'une série est bonne.
CREATE PROCEDURE verifierLongueurMaxSerie(pLongueurSerie INT)
BEGIN
	 IF FIND_IN_SET( pLongueurSerie , '1,3,5,7') = 0 
     THEN 
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Une série ne peut se dérouler qu\'en 3,5 ou 7 matchs';
	 END IF;
END $$

-- Vérifie si deux équipe sont les mêmes
CREATE PROCEDURE verifierMemeEquipe(pAcronymeEquipe1 VARCHAR(3), pAcronymeEquipe2 VARCHAR(3))
BEGIN
	 IF pAcronymeEquipe1 IS NOT NULL AND pAcronymeEquipe2 IS NOT NULL AND pAcronymeEquipe1 = pAcronymeEquipe2  
     THEN 
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Une equipe ne peut pas s\'affronter elle même';
	 END IF;
END $$

-- Vérifie si le seeding est correct sinon lève une exception.
CREATE PROCEDURE verifierSeedingIncorrect(pAcronymeEquipe1 VARCHAR(3), pAcronymeEquipe2 VARCHAR(3), pIdSerie INT, pNoTour INT, pIdTournoi INT)
BEGIN
	IF (seedingCorrect(pAcronymeEquipe1, pAcronymeEquipe2, pIdSerie, pNoTour, pIdTournoi ) = FALSE) 
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'L\'équipe ne peut pas occuper cette position dans cette série';
	END IF;
END $$

-- Vérifie si le tournoi est en attente.
CREATE PROCEDURE verifierTournoiEnAttente(pIdTournoi INT)
BEGIN
	 IF NOT estEnAttente(pIdTournoi) THEN 
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Le tournoi a déjà commencé inscription/modification d\'inscription impossible';
	END IF;
END $$

-- Vérifie que le nom de l'équipe ait au moins 1 caractère.
CREATE PROCEDURE verifierAcronyme(pAcronymeEquipe VARCHAR(3))
BEGIN
	IF LENGTH(pAcronymeEquipe) = 0
    THEN 
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Minimum 1 caractère pour l\'équipe';
	END IF;
END $$

-- Démarre le tournoi
CREATE PROCEDURE demarrerTournoi(pIdTournoi INT)
BEGIN
	-- Curseurs
    DECLARE done INT DEFAULT FALSE;
	DECLARE equipe1Inscrite VARCHAR(3);
    DECLARE equipe2Inscrite VARCHAR(3);
	DECLARE curInscription CURSOR FOR SELECT Tournoi_Equipe.acronymeEquipe FROM Tournoi_Equipe WHERE Tournoi_Equipe.idTournoi = pIdTournoi ORDER BY Tournoi_Equipe.dateInscription ASC;
	DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;
    
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK; 
        RESIGNAL;
    END;

	START TRANSACTION;
	IF estEnAttente(pIdTournoi) 
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Il est trop tôt pour démarrer le tournoi';
	END IF;
    
    IF NOT estComplet(pIdTournoi)
	THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Pas suffisament d\'équipes inscrites pour lancer le tournoi';
	END IF; 

	-- création du seeding 
    SET @noSerie = 1; 
    SET @noTour = calculerNbTours( (SELECT Tournoi.nbEquipesMax FROM Tournoi WHERE Tournoi.id = pIdTournoi) );
    OPEN curInscription;
    inscription_loop : LOOP
		FETCH curInscription INTO equipe1Inscrite;
        FETCH curInscription INTO equipe2Inscrite;
        
        IF done 
			THEN LEAVE inscription_loop; 
		END IF;
        
        UPDATE Serie SET Serie.acronymeEquipe1 = equipe1Inscrite,  Serie.acronymeEquipe2 = equipe2Inscrite WHERE Serie.id = @noSerie AND Serie.noTour = @noTour AND Serie.idTournoi = pIdTournoi;
        SET @noSerie = @noSerie + 1;
        
    END LOOP;
    CLOSE curInscription;
    COMMIT;
END $$

-- Après insertion du 6ème joueur, vérifie si la série est finie et fait progresser l'arbre de tournoi
CREATE PROCEDURE tenterPromotion(pIdMatch INT, pIdSerie INT, pNoTour INT, pIdTournoi INT)
BEGIN
	-- Promotion impossible en finale ou si les 6 joueurs n'ont pas de résultats
	IF pNoTour <> 1 AND 6 = (SELECT COUNT(1) FROM Match_Joueur WHERE Match_Joueur.idMatch = pIdMatch AND Match_Joueur.idSerie = pIdSerie AND Match_Joueur.noTour = pNoTour AND Match_Joueur.idTournoi = pIdTournoi)
    THEN 
		SET @nextSerie = CEIL(pIdSerie / 2);
		SET @vainqueur = vainqueurSerie(pIdSerie, pNoTour, pIdTournoi);
        
        -- La série est terminée on promeut le vainqueur
        IF @vainqueur IS NOT NULL
        THEN
			-- Si la serie était impair -> acronymeEquipe1 dans la suivante sinon acronymeEquipe2
            IF (pIdSerie % 2 <> 0)
            THEN
				UPDATE Serie SET Serie.acronymeEquipe1 = @vainqueur WHERE Serie.id = @nextSerie AND Serie.noTour = pNoTour - 1 AND Serie.idTournoi = pIdTournoi;
            ELSE
				UPDATE Serie SET Serie.acronymeEquipe2 = @vainqueur WHERE Serie.id = @nextSerie AND Serie.noTour = pNoTour - 1 AND Serie.idTournoi = pIdTournoi;
            END IF;
        END IF;
    END IF;
END $$

-- Vérifie si un email a un format valable
CREATE PROCEDURE verifierEmail(pEmail VARCHAR(250))
BEGIN
	IF pEmail NOT REGEXP '^[a-zA-Z0-9][a-zA-Z0-9._-]*@[a-zA-Z0-9][a-zA-Z0-9._-]*\.[a-zA-Z]{2,4}$'
    THEN 
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Format de l\'email invalide';
	END IF;
END $$

-- Effectue les vérifications d'inscription à un tournoi pour l'équipe donnée.
CREATE PROCEDURE verifierInscriptionEquipe(pAcronymeEquipe VARCHAR(3), pIdTournoi INT)
BEGIN
	IF estComplet(pIdTournoi)
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Les inscriptions du tournoi sont complètes';
	END IF;

	-- Le tournoi est-il encore en attente
    CALL verifierTournoiEnAttente(pIdTournoi);
    
    -- Equipe déjà inscrite à un autre tournoi ? 
    IF aUneInscriptionEnCours(pAcronymeEquipe)
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'L\'équipe participe déjà à un tournoi';
    END IF;
    
    -- Equipe complète ? 
	CALL verifierEquipeComplete(pAcronymeEquipe); 
END $$

-----------------------------------------------------
-- TRIGGER
-----------------------------------------------------

-------------------- TOURNOI ----------------------
CREATE TRIGGER before_insert_tournoi
BEFORE INSERT ON Tournoi
FOR EACH ROW
BEGIN
	-- Vérification du nombre max d'équipe.
	IF calculerNbTours(NEW.nbEquipesMax) = 0 
    THEN 
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'nbEquipesMax doit être une puissance de 2 entre 2 et 256.';
	END IF;
    
    CALL verifierDatePassee(NEW.dateHeureDebut);
   
	IF NEW.dateHeureFin IS NOT NULL
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Le tournoi doit être créé sans date de fin, elle doit être nulle.';
    END IF;
END $$

CREATE TRIGGER before_update_tournoi
BEFORE UPDATE ON Tournoi
FOR EACH ROW
BEGIN
	
    -- On empêche de change la taille du tournoi afin de ne pas avoir besoin de modifier le nombre de tour "dynamiquement"
	IF (OLD.nbEquipesMax <> NEW.nbEquipesMax) 
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Impossible de modifier le nombre maximal d\'équipes.';
	END IF;
    
    -- Si modification de la date de début
    IF(NEW.dateHeureDebut <> OLD.dateHeureDebut)
    THEN
		IF NOT estEnAttente(OLD.id)
        THEN
			SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Impossible de modifié la date de début d\'un tournoi déjà commencé.';
		ELSE
			CALL verifierDatePassee(NEW.dateHeureDebut);
		END IF;
	END IF;
    
    -- Si le tournoi est terminé, on empêche les mauvaises manipulations de la date de fin
    IF vainqueurSerie(1,1,NEW.id) IS NOT NULL
    THEN
		IF  NEW.dateHeureFin IS NULL 
		THEN
			SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Impossiblede retirer la date de fin d\'tournoi terminé.';
        END IF;
    ELSE
		IF  NEW.dateHeureFin IS NOT NULL 
        THEN
			SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Impossible de terminer le tournoi tant que la finale n\'a pas de vainqueur.';
        END IF;
    END IF;
    
    CALL verifierDatePlusPetite(NEW.dateHeureDebut, NEW.dateHeureFin);
END $$

CREATE TRIGGER before_delete_tournoi
BEFORE DELETE ON Tournoi
FOR EACH ROW
BEGIN
	-- Si la date de départ est dépassées et qu'il n'est pas complet il sera supprimé automatiquement par 
    -- les événements annuler_tournoi et supprimer_tournoi_annule
	IF ((OLD.dateHeureDebut < NOW() AND OLD.dateHeureFin IS NULL) OR OLD.dateHeureDebut <> OLD.dateHeureFin)
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Impossible de supprimer un tournoi commencé ou non annulé';
	END IF;
END $$

CREATE TRIGGER generer_arbre_tournoi
AFTER INSERT ON Tournoi
FOR EACH ROW
BEGIN

	DECLARE vNoTour INT DEFAULT 1;
    DECLARE vNoSerie INT DEFAULT 1;
    
    WHILE vNoTour <= calculerNbTours(NEW.nbEquipesMAx) DO
		INSERT INTO Tour VALUES (vNoTour, 1, NEW.id);
        SET @maxSerieDuTour = POWER(2, vNoTour - 1);
        WHILE vNoSerie <= @maxSerieDuTour DO
			INSERT INTO Serie VALUES (vNoSerie, vNoTour, NEW.id, NULL, NULL);
            SET vNoSerie = vNoSerie + 1;
        END WHILE;
        SET vNoSerie = 1;
        SET vNoTour = vNoTour + 1;
	END WHILE;
END $$

-------------------- TOURNOI_EQUIPE ----------------------
CREATE TRIGGER before_insert_tournoi_equipe
BEFORE INSERT ON Tournoi_Equipe
FOR EACH ROW
BEGIN
	CALL verifierInscriptionEquipe(NEW.acronymeEquipe, NEW.idTournoi);
	SET NEW.dateInscription = NOW();
END $$

CREATE TRIGGER before_update_tournoi_equipe
BEFORE UPDATE ON Tournoi_Equipe
FOR EACH ROW
BEGIN
   CALL verifierInscriptionEquipe(NEW.acronymeEquipe, NEW.idTournoi);
   SET NEW.dateInscription = NOW();
END $$

CREATE TRIGGER before_delete_tournoi_equipe
BEFORE DELETE ON Tournoi_Equipe
FOR EACH ROW
BEGIN
	-- cas cascade, le tournoi a été supprimé, pas de problème
    -- cas manuel, le tournoi est encore présent
	IF NOT estEnAttente(OLD.idTournoi)
	THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Impossible de désinscrire une équipe quand le tournoi a débuté.';
	END IF;
END $$

-------------------- TOUR ----------------------
CREATE TRIGGER before_insert_tour
BEFORE INSERT ON Tour
FOR EACH ROW
BEGIN
	-- Verification du numéro de tour
	SET @maxTeam = (SELECT Tournoi.nbEquipesMax FROM Tournoi WHERE Tournoi.id = NEW.idTournoi);
    SET @dernierNoTour = (SELECT MAX(Tour.no) FROM Tour WHERE Tour.idTournoi = NEW.idTournoi);
	IF NEW.no <> 1 AND (NEW.no < 0 OR NEW.no > calculerNbTours(@maxTeam) OR NEW.no <> @dernierNoTour + 1)
	THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Nouvel id de tour invalide';
	END IF;
    CALL verifierLongueurMaxSerie(NEW.longueurMaxSerie);
END $$

CREATE TRIGGER before_update_tour
BEFORE UPDATE ON Tour
FOR EACH ROW
BEGIN
	-- Blocage de la modification du numéro
    IF OLD.no <> NEW.no 
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Impossible de modifier le numero de tour';
	END IF;
    
	-- Si le tournoi a débuté on ne modifie pas
    SET @debutTournoi = (SELECT Tournoi.dateHeureDebut FROM Tournoi WHERE Tournoi.id = NEW.idTournoi);
    IF(@debutTournoi < NOW())
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Mise à jour du tour impossible, le tournoi a débuté';
	END IF;
    
    CALL verifierLongueurMaxSerie(NEW.longueurMaxSerie);
END $$

CREATE TRIGGER before_delete_tour
BEFORE DELETE ON Tour
FOR EACH ROW
BEGIN
	-- cas cascade, le tournoi a été supprimé, pas de problème
    -- cas manuel, le tournoi est il encore présent 
	IF EXISTS (SELECT Tournoi.id FROM Tournoi WHERE Tournoi.id = OLD.idTournoi)
	THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Suppression du tour impossible';
	END IF;
END $$

----------------------- SERIE --------------------
CREATE TRIGGER before_insert_serie
BEFORE INSERT ON serie
FOR EACH ROW
BEGIN
	SET @dernierIdSerie = (SELECT MAX(Serie.id) FROM Serie WHERE Serie.noTour = NEW.noTour AND Serie.idTournoi = NEW.idTournoi);
	IF NEW.id <> 1 AND ( NEW.id <= 0 OR NEW.id > POWER(2, NEW.noTour - 1) OR NEW.id <> @dernierIdSerie + 1)
     THEN 
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Nouvel id de série invalide';
	 END IF;
    
	CALL verifierInscription(NEW.acronymeEquipe1, new.idTournoi);
    CALL verifierInscription(NEW.acronymeEquipe2, new.idTournoi);
	CALL verifierMemeEquipe(NEW.acronymeEquipe1, NEW.acronymeEquipe2);
    CALL verifierSeedingIncorrect(NEW.acronymeEquipe1, NEW.acronymeEquipe2, NEW.id, NEW.noTour, NEW.idTournoi);
END $$

CREATE TRIGGER before_update_serie
BEFORE UPDATE ON serie
FOR EACH ROW
BEGIN
	-- Blocage de la modification du numéro
    IF OLD.id <> NEW.id OR OLD.noTour <> NEW.noTour OR OLD.idTournoi <> NEW.idTournoi 
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Impossible de modifier le numero de la série';
	END IF;

	-- Si la série a déjà commencé, qu'elle a déjà des performances de joueurs
	IF NEW.noTour <> 1 AND 0 <> (SELECT COUNT(1) FROM Match_Joueur WHERE Match_Joueur.idSerie = NEW.id AND Match_Joueur.noTour = NEW.noTour AND Match_Joueur.idTournoi = NEW.idTournoi)
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = ' Modification de la série impossible, les matchs ont déjà débutés.';
	END IF;
	CALL verifierInscription(NEW.acronymeEquipe1, new.idTournoi);
    CALL verifierInscription(NEW.acronymeEquipe2, new.idTournoi);
	CALL verifierMemeEquipe(NEW.acronymeEquipe1, NEW.acronymeEquipe2);
    CALL verifierSeedingIncorrect(NEW.acronymeEquipe1, NEW.acronymeEquipe2, NEW.id, NEW.noTour, NEW.idTournoi);
END $$

CREATE TRIGGER before_delete_serie
BEFORE DELETE ON Serie
FOR EACH ROW
BEGIN
	-- cas cascade, le tournoi a été supprimé, pas de problème
    -- cas manuel, le tournoi est il encore présent 
	IF EXISTS (SELECT Tour.no FROM Tour WHERE Tour.no = OLD.noTour AND Tour.idTournoi = OLD.idTournoi)
	THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Suppression de la série impossible';
	END IF;
END $$
----------------------- EQUIPE --------------------
CREATE TRIGGER before_insert_equipe
AFTER INSERT ON Equipe
FOR EACH ROW
BEGIN
	CALL verifierAcronyme(NEW.acronyme);
END $$

CREATE TRIGGER after_insert_equipe
AFTER INSERT ON Equipe
FOR EACH ROW
BEGIN
	-- La vérification qui affirme que le responsable n''est pas déjà dans une équie s'effectue au moment de l'insertion dans equipe_joueur.
	INSERT INTO Equipe_Joueur (acronymeEquipe, idJoueur, dateHeureArrivee, dateHeureDepart)
    VALUE(NEW.acronyme, NEW.idResponsable, NOW(), NULL);
END $$

CREATE TRIGGER before_update_equipe
BEFORE UPDATE ON Equipe
FOR EACH ROW
BEGIN
    CALL verifierAcronyme(NEW.acronyme);
	IF(OLD.idresponsable <> NEW.idResponsable)
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Le responsable de l\'équipe ne peut être changé';
	END IF;
END $$

----------------------- JOUEUR --------------------
CREATE TRIGGER before_insert_joueur
BEFORE INSERT ON Joueur
FOR EACH ROW
BEGIN
    CALL verifierDateFuture(NEW.dateNaissance);
    CALL verifierEmail(NEW.email);
END $$

CREATE TRIGGER before_update_joueur
BEFORE UPDATE ON Joueur
FOR EACH ROW
BEGIN
    CALL verifierDateFuture(NEW.dateNaissance);
    CALL verifierEmail(NEW.email);
END $$

----------------------- EQUIPE_JOUEUR --------------------
CREATE TRIGGER before_insert_equipe_joueur
BEFORE INSERT ON Equipe_Joueur
FOR EACH ROW
BEGIN
    CALL  verifierDatePlusPetite(NEW.dateHeureArrivee,NEW.dateHeureDepart);
    IF ( estComplete(NEW.acronymeEquipe) )
    THEN 
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Impossible de rejoindre l\'equipe, elle est complète';
    END IF;
    CALL verifierDejaDansUneEquipe(NEW.idJoueur);
END $$

CREATE TRIGGER before_update_equipe_joueur
BEFORE UPDATE ON Equipe_Joueur
FOR EACH ROW
BEGIN
	IF(OLD.idJoueur <> NEW.idJoueur)
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Impossible de modifier l\'id du joueur dans un enregistrement Equipe_joueur';
	END IF;
    
    IF(OLD.acronymeEquipe <> NEW.acronymeEquipe)
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Impossible de modifier l\'équipe du joueur dans un enregistremen Equipe_joueur';
	END IF;
    
    CALL verifierDatePlusPetite(NEW.dateHeureArrivee,NEW.dateHeureDepart);
    
    -- Le joueur rejoint l'équipe, supression des autres demandes
    IF(OLD.dateHeureArrivee = '0001-01-01 00:00:00' AND NEW.dateHeureArrivee <> OLD.dateHeureArrivee AND NOT estComplete(NEW.acronymeEquipe))
    THEN
		DELETE FROM Equipe_Joueur WHERE Equipe_Joueur.dateHeureArrivee = '0001-01-01 00:00:00' AND Equipe_Joueur.idJoueur = NEW.idJoueur;
    END IF;
    
    -- Si on tente de lui le re-refaire rejoindre l'équipe avec le même enregistrement
    IF (NEW.dateHeureDepart IS NULL AND OLD.dateHeureDepart IS NOT NULL) 
	THEN 
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Impossible de rejoindre a nouveau l\'équipe avec le même enregistrement';
	END IF;
    
    -- Si on tente de lui faire quitter l'équipe
    IF (NEW.dateHeureDepart IS NOT NULL AND OLD.dateHeureDepart IS NULL)
    THEN
		-- Est-ce que son équipe participe à un tournoi.
        IF( aUneInscriptionEnCours(OLD.acronymeEquipe) ) 
        THEN 
			SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Le joueur ne peut pas quitter une équipe inscrite à un tournoi.';
        END IF;
        SET NEW.dateHeureDepart = NOW();
	END IF;
    
    -- Impossible de destituer le responsable
    IF(OLD.idJoueur = (SELECT idResponsable FROM Equipe WHERE Equipe.acronyme = OLD.acronymeEquipe) AND NEW.dateHeureDepart IS NOT NULL)
    THEN 
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Le responsable ne peut pas quitter son équiper, on a besoin de lui.';
	END IF;
END $$

------------------------- MATCH --------------------
CREATE TRIGGER before_insert_match
BEFORE INSERT ON `Match`
FOR EACH ROW
BEGIN
	-- La serie du match contient elle deux équipes ? 
	DECLARE e1 VARCHAR(3);
    DECLARE e2 VARCHAR(3);
    SELECT Serie.AcronymeEquipe1, Serie.AcronymeEquipe2 INTO e1, e2 FROM Serie WHERE Serie.id = NEW.idSerie AND Serie.noTour = NEW.noTour AND Serie.idTournoi = NEW.idTournoi;
    IF (e1 IS NULL OR e2 IS NULL)
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Impossible de créer un match tant que la série n\'a pas deux équipes';
	END IF;
    
    -- Vérification de l'id
	SET @maxMatch = (SELECT Tour.longueurMaxSerie FROM Tour WHERE Tour.idTournoi = NEW.idTournoi AND Tour.no = NEW.noTour);
	SET @noDernierMatch = (SELECT MAX(`Match`.id) FROM `Match` WHERE `Match`.idSerie = NEW.idSerie AND `Match`.noTour = NEW.noTour AND `Match`.idTournoi = NEW.idTournoi);
	IF NEW.id <> 1 AND ( NEW.id > @maxMatch OR NEW.id <= 0 OR NEW.id <> (@noDernierMatch + 1) )
	THEN
 		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Nouvel id de match invalide';
	END IF;
    
    -- Si la serie connait déjà un vainqueur.
	IF(vainqueurSerie(NEW.idSerie, NEW.noTour, NEW.idTournoi) IS NOT NULL)
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Serie terminée, ajout de match impossible';
    END IF;
END $$

CREATE TRIGGER before_update_match
BEFORE UPDATE ON `Match`
FOR EACH ROW
BEGIN
	SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Impossible de modifier la clé du tournoi.';
END $$

CREATE TRIGGER before_delete_match
BEFORE DELETE ON `Match`
FOR EACH ROW
BEGIN
	-- Cas cascade aucun problème.
    -- Cas manuel, blocage si série supprimée, 
    IF( EXISTS (SELECT Serie.id FROM Serie WHERE Serie.id = OLD.idSerie AND Serie.noTour = OLD.noTour AND Serie.idTournoi = OLD.idTournoi))
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Impossible de supprimer un match';
    END IF;
END $$

----------------------- MATCH_JOUEUR --------------------
CREATE TRIGGER before_insert_match_joueur
BEFORE INSERT ON Match_Joueur
FOR EACH ROW
BEGIN
    CALL verifierJoueurEstDansEquipeSerie(NEW.idJoueur, NEW.idSerie, NEW.noTour, NEW.idTournoi);
END $$

CREATE TRIGGER after_insert_match_joueur
AFTER INSERT ON Match_Joueur
FOR EACH ROW
BEGIN
	-- Est ce que la finale est terminée
	IF NEW.noTour = 1
 	THEN 
		IF 6 = (SELECT COUNT(1) FROM Match_Joueur WHERE Match_Joueur.idMatch = NEW.idMatch AND Match_Joueur.idSerie = NEW.idSerie AND Match_Joueur.noTour = NEW.noTour AND Match_Joueur.idTournoi = NEW.idTournoi)
		THEN 
 			IF vainqueurSerie(NEW.idSerie, NEW.noTour, NEW.idTournoi) IS NOT NULL
			THEN
				UPDATE Tournoi SET Tournoi.dateHeureFin = NOW() WHERE Tournoi.id = NEW.idTournoi;
			END IF;
		END IF;
	ELSE
		CALL tenterPromotion(NEW.idMatch, NEW.idSerie, NEW.noTour, NEW.idTournoi);
    END IF;
END $$

CREATE TRIGGER before_update_match_joueur
BEFORE UPDATE ON Match_Joueur
FOR EACH ROW
BEGIN
	-- Blocage de la modification de la clé.
    IF OLD.idJoueur <> NEW.idJoueur OR OLD.id <> NEW.id OR OLD.idSerie <> NEW.idSerie OR NEW.noTour <> OLD.noTour OR OLD.idTournoi <> NEW.idTournoi
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = ' Modification de la clé du match impossible.';
	END IF;

	-- Si la série suivante a déjà commencé on bloque la modification des performances
	SET @serieSuivante = CEIL(NEW.idSerie / 2);
	IF NEW.noTour <> 1 AND 0 <> (SELECT COUNT(1) FROM Match_Joueur WHERE Match_Joueur.idSerie = @serieSuivante AND Match_Joueur.noTour = NEW.noTour - 1 AND Match_Joueur.idTournoi = NEW.idTournoi)
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = ' Modification/insertion du score du joueur impossible, la serie suivante a déjà commencée.';
	END IF;
END $$

CREATE TRIGGER after_update_match_joueur
AFTER UPDATE ON Match_Joueur
FOR EACH ROW
BEGIN
	CALL tenterPromotion(NEW.idMatch, NEW.idSerie, NEW.noTour, NEW.idTournoi);
END $$

-----------------------------------------------------
-- EVENTS
-----------------------------------------------------
-- Chaque 6 heure, vérifie si la date de début d'un tournoi a été dépassée, si c'est le cas termine le tournoi.alter
CREATE EVENT annuler_tournoi
ON SCHEDULE EVERY 1 HOUR DO
BEGIN 
	UPDATE Tournoi 
    SET Tournoi.dateHeureFin = Tournoi.dateHeureDebut
    WHERE Tournoi.dateHeureFin IS NULL AND Tournoi.dateHeureDebut < NOW() 
		  AND Tournoi.nbEquipesMax > (SELECT COUNT(1) FROM Tournoi_Equipe
									  WHERE Tournoi_Equipe = Tournoi.id);
END $$

-- Chaque 7 jour vérifie si le un tournoi de plus de 7 jour peut être supprimé.
CREATE EVENT supprimer_tournoi_annule
ON SCHEDULE EVERY 7 DAY STARTS NOW() + INTERVAL 15 MINUTE DO

BEGIN 
	DELETE FROM Tournoi 
    WHERE Tournoi.dateHeureFin = Tournoi.dateHeureDebut AND DATEDIFF(NOW(), Tournoi.dateHeureDebut) >= 7;
END $$

DELIMITER ;

