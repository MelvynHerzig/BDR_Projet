-- MySQL Script Gestionnaire de tournois rocket League
-- Fri Dec 11 11:16:36 2020
-- Model: New Model    Version: 1.0
-- Berney Alec, Forestier Quentin, Herzig Melvyn

DROP SCHEMA IF EXISTS GestionnaireDeTournoisRocketLeague ;

CREATE SCHEMA IF NOT EXISTS GestionnaireDeTournoisRocketLeague DEFAULT CHARACTER SET utf8mb4 ;
USE GestionnaireDeTournoisRocketLeague ;


CREATE TABLE Prix 
(
  id INT AUTO_INCREMENT,
  montantArgent DECIMAL(10,2) NOT NULL,
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
  acronymeEquipe1 VARCHAR(3) NOT NULL,
  acronymeEquipe2 VARCHAR(3) NOT NULL,
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