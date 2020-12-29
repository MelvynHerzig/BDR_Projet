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

-----------------------------------------------------
-- FONCTIONS ET PROCEDURES STOCKEES
-----------------------------------------------------

-- Pour un tournoi données vérifie si la limite d'équipe est valide.
DELIMITER $$
CREATE PROCEDURE verifierNbEquipesMax(pNbEquipe INT)
BEGIN
	 IF FIND_IN_SET( LOG2(pNbEquipe) , "1,2,3,4,5,6,7,8") = 0 THEN 
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'nbEquipesMax doit être une puissance de 2 entre 2 et 256.';
	 END IF;
END
$$

-- Vérifie que la date en paramètre est plus petite que la date courante.
DELIMITER $$
CREATE PROCEDURE verifierDatePassee(pDate DATETIME)
BEGIN
	 IF pDate <= NOW() THEN 
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Le début du tournoi ne peut être plus petit que le temps présent.';
	END IF;
END
$$

-- Vérifie que la date en paramètre est plus grande que la date courante.
DELIMITER $$
CREATE PROCEDURE verifierDateFuture(pDate DATETIME)
BEGIN
	 IF pDate > NOW() THEN 
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'La date de naissance est dans le future.';
	END IF;
END
$$

-- Vérification que la date de début du tournoi soit plus petite que la date de fin 
ALTER TABLE Tournoi ADD CONSTRAINT CHK_Tournoi_datesDebutFin CHECK (dateHeureDebut <= dateHeureFin);

-- Vérifie si la date d'inscription est cohérente pour le tournoi en paramètre
DELIMITER $$
CREATE PROCEDURE verifierDateInscriptionTournoi(pDateToCompare DATETIME, pIdTournoi INT)
BEGIN
	 IF pDateToCompare >= (SELECT dateHeureDebut FROM Tournoi WHERE id = pIdTournoi) THEN 
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Le tournoi a déjà commencé au moment de l\'inscription';
	END IF;
END
$$

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
END
$$

-- Vérifier si la longueur maximale d'une série est bonne.
DELIMITER $$
CREATE PROCEDURE verifierLongueurMaxSerie(pLongueurSerie INT)
BEGIN
	 IF FIND_IN_SET( pLongueurSerie , "1,3,5,7") = 0 
     THEN 
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Une série ne peut se dérouler qu\'en 3,5 ou 7 matchs';
	 END IF;
END
$$

-- Vérifie si l'équipe est inscrite au tournoi en paramètre
DELIMITER $$
CREATE PROCEDURE verifierInscription(pAcronyme VARCHAR(3), pIdTournoi INT)
BEGIN
	 IF NOT EXISTS( SELECT * FROM Tournoi_Equipe WHERE idTournoi = pIdTournoi AND pAcronyme = acronymeEquipe) 
     THEN 
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'L\'equipe n\'est pas inscrite au tournoi';
	 END IF;
END
$$

-- Vérifie si deux équipe sont les mêmes
DELIMITER $$
CREATE PROCEDURE verifierMemeEquipe(pAcronymeEquipe1 VARCHAR(3), pAcronymeEquipe2 VARCHAR(3))
BEGIN
	 IF pAcronymeEquipe1 IS NOT NULL AND pAcronymeEquipe2 IS NOT NULL AND pAcronymeEquipe1 = pAcronymeEquipe2  
     THEN 
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Une equipe ne peut pas s\'affronter elle même';
	 END IF;
END
$$

-- Compte pour une équipe sont nombre de victoire dans une série.
DELIMITER $$
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
					    WHERE vainqueurs.Vainqueur = acronymeEquipeParam);
    
    RETURN @nbVictoires;
END
$$

-- Retourne le vainqueur d'une série donnée si terminée sinon NULL.
DELIMITER $$
CREATE FUNCTION vainqueurSerie(pIdSerie INT, pNoTour INT, pIdTournoi INT)
RETURNS VARCHAR(3)
DETERMINISTIC
BEGIN
    
    DECLARE ae1, ae2 VARCHAR(3); -- Acronymes des équipes de la série
    DECLARE maxVictoire INT;
    SELECT Serie.acronymeEquipe1, Serie.acronymeEquipe2 INTO ae1, ae2 FROM Serie WHERE Serie.id = pIdSerie AND Serie.noTour = pNoTour AND Serie.idTournoi = pIdTournoi;
    SELECT longueurMaxSerie INTO maxVictoire FROM Tour WHERE Tour.no = pNoTour AND Tour.idTournoi = pIdTournoi;
	SET @nbVictoireE1 = compterVictoireDansSerie(ae1, pIdSerie, pNoTour, pIdTournoi);
    SET @nbVictoireE2 = compterVictoireDansSerie(ae2, pIdSerie, pNoTour, pIdTournoi);
	
    SET @taux = (maxVictoire + 1) / 2;
    
    IF(@nbVictoireE1 + @nbVictoireE2 > maxVictoire OR @nbVictoireE1 > @taux OR @nbVictoireE2 > @taux )
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Une erreur est survenue, trop de match on été gagné pour cette série.';
    END IF;
    
    IF(@nbVictoireE1 = @taux)
    THEN
		RETURN ae1;
	END IF;
    
    IF(@nbVictoireE2 = @taux)
    THEN
		RETURN ae2;
	END IF;
    
	RETURN NULL;
END
$$

-- Vérifie si l'équipe a perdu un match dans le tournoi
DELIMITER $$
CREATE FUNCTION aPerduUneSerie(pAcronymeEquipe VARCHAR(3), pIdTournoi INT)
RETURNS BOOLEAN
DETERMINISTIC
BEGIN
    SET @nbDefaites = (SELECT COUNT(vainqueurs.vainqueur) 
    FROM ( SELECT vainqueurSerie(Serie.id, Serie.noTour, Serie.idTournoi) AS vainqueur
		   FROM Serie
		   WHERE Serie.idTournoi = pIdTournoi AND (Serie.acronymeEquipe1 = pAcronymeEquipe OR Serie.acronymeEquipe2 = pAcronymeEquipe)) AS vainqueurs
	WHERE vainqueurs.vainqueur <> acronymeEquipeParam);
    
    IF(@nbDefaites > 0)
    THEN
		RETURN 1;
	ELSE
		RETURN 0;
	END IF;
END
$$

-- Retourne le nom du vainqueur d'un match.
DELIMITER $$
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
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Une équipe n\'a pas obtenu trois performances de ses joueurs.';
    END IF;
    
    IF(be1 = be2) THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Les équipes sont égalité résultat impossible.';
    END IF;
    
    IF(be1 > be2) THEN
        RETURN ae1;
    ELSE 
        RETURN ae2;
    END IF;
END
$$

-- Retourne vrai si l'équip est complète sinon faux
DELIMITER $$
CREATE FUNCTION estComplete(pAcronymeEquipe VARCHAR(3))
RETURNS BOOLEAN
DETERMINISTIC
BEGIN
	IF ( 3 = (SELECT COUNT(*) 
			  FROM Equipe_Joueur 
              WHERE Equipe_Joueur.acronymeEquipe = pAcronymeEquipe AND Equipe_Joueur.dateHeureDepart IS NULL AND Equipe_Joueur.dateHeureArrivee <> '0000-00-00 00:00:00'))
	THEN RETURN 1;
    ELSE RETURN 0;
    END IF;
END
$$

-- Retourne le nom de l'équipe pour un joueur à une date.
DELIMITER $$
CREATE FUNCTION equipeDuJoueurLorsDu(pIdJoueur INT, pDate DATETIME)
RETURNS VARCHAR(3)
DETERMINISTIC
BEGIN
	DECLARE nomEquipe VARCHAR(3);
	SELECT Equipe_Joueur.acronymeEquipe INTO nomEquipe
	FROM Equipe_Joueur
	WHERE idJoueur = pIdJoueur AND dateHeureArrivee = (SELECT MAX(dateHeureArrivee) 
													   FROM Equipe_Joueur 
                                                       WHERE idJoueur = pIdJoueur AND dateHeureArrivee < pDate AND (dateHeureDepart IS NULL OR dateHeureDepart > pDate));
    RETURN nomEquipe;
END
$$

-- Vérifier que la première date soit plus petite que la seconde
DELIMITER $$
CREATE PROCEDURE verifierDateArriveeDepart(pArrivee DATETIME, pDepart DATETIME)
BEGIN
	 IF pArrivee > pDepart THEN 
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'La date d\'arrivée ne peut être plus grande que la date de départ de l\´équipe.';
	 END IF;
END
$$

-- Vérifie si la joueur en paramètre a déjà une équipe
DELIMITER $$
CREATE PROCEDURE estDejaDansUneEquipe(pIdJoueur INT)
BEGIN
	 IF EXISTS( SELECT * 
				FROM Equipe_Joueur 
                WHERE idJoueur = pIdJoueur AND dateHeureDepart IS NULL AND dateHeureArrivee <> '0000-00-00 00:00:00') 
	THEN 
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Le joueur est déjà dans une équipe';
	END IF;
END
$$

-- Vérifie si le joueur appartient à l'équipe donnée au moment du tournoi et que l'équipe fasse partie de la série.
DELIMITER $$
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
END
$$

-----------------------------------------------------
-- TRIGGER
-----------------------------------------------------

-------------------- TOURNOI ----------------------
DELIMITER $$
CREATE TRIGGER tournoiInsertion
BEFORE INSERT
ON Tournoi
FOR EACH ROW
BEGIN
    CALL verifierNbEquipesMax(NEW.nbEquipesMax);
    CALL verifierDatePassee(NEW.dateHeureDebut);
END
$$
DELIMITER $$
CREATE TRIGGER tournoiMiseAJour
BEFORE INSERT
ON Tournoi
FOR EACH ROW
BEGIN
    CALL verifierNbEquipesMax(NEW.nbEquipesMax);
    CALL verifierDatePassee(NEW.dateHeureDebut);
END
$$
DELIMITER $$
CREATE TRIGGER tournoiSuppression
BEFORE DELETE
ON Tournoi
FOR EACH ROW
BEGIN
	IF ((OLD.dateHeureDebut < NOW() AND old.dateHeureFin IS NULL) OR OLD.dateHeureDebut <> OLD.dateHeureFin)
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = "Impossible de supprimer un tournoi déjà commencé et non annulé";
	END IF;
END
$$

-------------------- TOURNOI_EQUIPE ----------------------
DELIMITER $$
CREATE TRIGGER TournoiEquipeInsertion
BEFORE INSERT
ON Tournoi_Equipe
FOR EACH ROW
BEGIN
    CALL verifierDateInscriptionTournoi(NEW.dateInscription, NEW.idTournoi);
    IF (aUneInscriptionEnCours(NEW.acronymeEquipe))
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'L\'équipe participe déjà à un tournoi';
    END IF;
    IF( NOT estComplete(NEW.acronymeEquipe))
	THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'L\'équipe n\'a pas trois joueur et ne peut donc pas s\'inscrire.';
	END IF;
END
$$
DELIMITER $$
CREATE TRIGGER TournoiEquipeMiseAJour
BEFORE UPDATE
ON Tournoi_Equipe
FOR EACH ROW
BEGIN
    CALL verifierDateInscriptionTournoi(NEW.dateInscription, new.idTournoi);
     IF (NEW.acronymeEquipe <> OLD.acronymeEquipe AND aUneInscriptionEnCours(NEW.acronymeEquipe))
		THEN SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'L\'equipe participe déjà à un tournoi';
    END IF;
END
$$

-------------------- TOUR ----------------------
DELIMITER $$
CREATE TRIGGER tourInsertion
BEFORE INSERT
ON Tour
FOR EACH ROW
BEGIN
    CALL verifierLongueurMaxSerie(NEW.longueurMaxSerie);
END
$$
DELIMITER $$
CREATE TRIGGER tourSerieMiseAJour
BEFORE INSERT
ON Tour
FOR EACH ROW
BEGIN
    CALL verifierLongueurMaxSerie(NEW.longueurMaxSerie);
END
$$

-- --------------------- SERIE --------------------
DELIMITER $$
CREATE TRIGGER serieInsertion
BEFORE INSERT
ON serie
FOR EACH ROW
BEGIN
	CALL verifierMemeEquipe(NEW.acronymeEquipe1, NEW.acronymeEquipe2);
END
$$
DELIMITER $$
CREATE TRIGGER serieMiseAJour
BEFORE UPDATE
ON serie
FOR EACH ROW
BEGIN
	CALL verifierMemeEquipe(NEW.acronymeEquipe1, NEW.acronymeEquipe2);
END
$$

----------------------- EQUIPE --------------------
DELIMITER $$
CREATE TRIGGER equipeMiseAJour
BEFORE UPDATE
ON Equipe
FOR EACH ROW
BEGIN
	IF(OLD.idresponsable <> NEW.idResponsable)
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Le responsable de l\'équipe ne peut être changé';
	END IF;
END
$$

----------------------- JOUEUR --------------------
DELIMITER $$
CREATE TRIGGER joueurInsertion
BEFORE INSERT
ON Joueur
FOR EACH ROW
BEGIN
    CALL  verifierDateFuture(NEW.dateNaissance);
END
$$

DELIMITER $$
CREATE TRIGGER joueurMiseAJour
BEFORE UPDATE
ON Joueur
FOR EACH ROW
BEGIN
    CALL verifierDateFuture(NEW.dateNaissance);
END
$$

----------------------- EQUIPE_JOUEUR --------------------
DELIMITER $$
CREATE TRIGGER equipeJoueurInsertion
BEFORE INSERT
ON Equipe_Joueur
FOR EACH ROW
BEGIN
    CALL  verifierDateArriveeDepart(NEW.dateHeureArrivee,NEW.dateHeureDepart);
    IF ( estComplete(NEW.acronymeEquipe) )
    THEN 
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Impossible de rejoindre l\'equipe, elle est complète';
    END IF;
    CALL estDejaDansUneEquipe(NEW.idJoueur);
END
$$

DELIMITER $$
CREATE TRIGGER equipeJoueurMiseAJour
BEFORE UPDATE
ON Equipe_Joueur
FOR EACH ROW
BEGIN
    CALL verifierDateArriveeDepart(NEW.dateHeureArrivee,NEW.dateHeureDepart);
    -- Si on tente de lui le re-refaire rejoindre l'équipe avec le même enregistrement
    IF (NEW.dateHeureDepart IS NULL AND OLD.dateHeureDepart IS NOT NULL) 
	THEN 
		CALL estDejaDansUneEquipe(OLD.idJoueur);
	END IF;
    -- Si on tente de lui faire quitter l'équipe
    IF (NEW.dateHeureDepart IS NOT NULL AND OLD.dateHeureDepart IS NULL)
    THEN
		-- Est-ce que son équipe participe à un tournoi.
        IF( aUneInscriptionEnCours(OLD.acronymeEquipe) ) THEN 
			SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Le joueur ne peut pas quitter une équipe inscrite à un tournoi.';
        END IF;
	END IF;
    IF(OLD.idJoueur = (SELECT idResponsable FROM Equipe WHERE Equipe.acronyme = OLD.acronymeEquipe) AND NEW.dateHeureDepart IS NOT NULL)
    THEN 
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Le responsable ne peut pas quitter son équiper, on a besoin de lui.';
	END IF;
END
$$

----------------------- MATCH_JOUEUR --------------------

DELIMITER $$
CREATE TRIGGER matchJoueurInsertion
BEFORE INSERT
ON Match_Joueur
FOR EACH ROW
BEGIN
    CALL verifierJoueurEstDansEquipeSerie(NEW.idJoueur, NEW.idSerie, NEW.noTour, NEW.idTournoi);
END
$$

DELIMITER $$
CREATE TRIGGER ematchJoueurMiseAJour
BEFORE UPDATE
ON Match_Joueur
FOR EACH ROW
BEGIN
    CALL verifierJoueurEstDansEquipeSerie(NEW.idJoueur, NEW.idSerie, NEW.noTour, NEW.idTournoi);
END
$$

-----------------------------------------------------
-- EVENTS
-----------------------------------------------------
-- Chaque 6 heure, vérifie si la date de début d'un tournoi a été dépassée, si c'est le cas termine le tournoi.alter
DELIMITER $$
CREATE EVENT annuler_tournoi
ON SCHEDULE EVERY 6 HOUR 
DO
BEGIN 
	UPDATE Tournoi 
    SET Tournoi.dateHeureFin = Tournoi.dateHeureDebut
    WHERE Tournoi.dateHeureFin IS NULL AND Tournoi.dateHeureDebut < NOW();
END
$$

-- Chaque 7 jour vérifie si le un tournoi de plus de 7 jour peut être supprimé.
DELIMITER $$
CREATE EVENT supprimer_tournoi_annule
ON SCHEDULE EVERY 7 DAY 
DO
BEGIN 
	DELETE FROM Tournoi 
    WHERE Tournoi.dateHeureFin = Tournoi.dateHeureDebut AND DATEDIFF(NOW(), Tournoi.dateHeureDebut) >= 7;
END
$$



-----------------------------------------------------
-- DONNEES
------------------------------------------------------
INSERT INTO Objet (nom)
VALUES 
( "Clavier Roccat" ),
( "Souris Roccat" ),
( "Casque Logitec" ),
( "Ecran BenQ" ),
( "PC  Alienware" );

INSERT INTO Prix (montantArgent)
VALUES 
( 50.00 ),
( 100.00 ),
( 150.00 ),
( 500.00 ),
( 1500.00 ),
( 200.00 ),
( 300.00 );

INSERT INTO Prix_Objet 
VALUES 
( 1, 1 ),
( 2, 2 ),
( 3, 3 ),
( 4, 4 ),
( 5, 5 );

INSERT INTO Joueur (nom, prenom, email, pseudo, dateNaissance)
VALUES 
( "Forestier", "Qunetin", "quentin.forestier@heig-vd.ch", "Dudude", "2001-05-16" ),
( "Herzig", "Melvyn", "melvyn.herzig@heig-vd.ch", "Wheald", "1997-09-11" ),
( "Crausaz", "Nicolas", "nicolas.crausaz@heig-vd.ch", "itsaboi", "1999-08-03" ),
( "Brescard", "Julien", "Jujuju@lse.ch", "Jujuju", "2002-09-16" ),
( "Baggiolini", "Jonas", "Arcko0o@lse.ch", "Arcko0o", "2000-11-15" ),
( "Eggenberger", "Kevin", "Keever@lse.ch", "Keever", "1999-01-10" ),
( "Candolfi", "Kérian", "Kerian@solary.fr", "Kérian", "2003-08-21" ),
( "Bigeard", "Brice", "ExoTiiK@solary.fr", "ExoTiiK", "2002-10-31" ),
( "Schäfer", "Damian", "Tox@solary.fr", "Tox", "2003-06-08" ),
( "Packwood-Clarke", "Jack", "Speed@teamliquid.com", "Speed", "2001-02-26" ),
( "Moselund", "Emil", "fruity@teamliquid.com", "fruity", "1996-02-22" ),
( "Hodzic", "Aldin", "Ronaky@teamliquid.com", "Ronaky", "2000-09-21" ),
( "Jakober", "Lukas", "Zaphare@eldelweiss.ch", "Zaphare", "2000-04-07" ),
( "Lentz", "Quentin", "Mirror@eldelweiss.ch", "Mirror", "2002-09-05" ),
( "Sauvey", "Baptiste", "BatOu@eldelweiss.ch", "BatOu", "2001-10-28" ),
( "Courant", "Alexandre", "Kaydop@vitality.fr", "Kaydop", "1998-05-22" ),
( "Champenois", "Yanis", "Alpha54@vitality.fr", "Alpha54", "2003-05-27" ),
( "Loquet", "Victor", "Fairy_Peak@vitality.fr", "Fairy Peak!", "1998-05-26" ),
( "Van Meurs", "Jos", "ViolentPanda@dignitas.com", "ViolentPanda", "1998-11-02" ),
( "Robben", "Joris", "Joreuz@dignitas.com", "Joreuz", "2005-03-08" ),
( "Benton", "Jack", "ApparentlyJack@dignitas.com", "ApparentlyJack", "2003-09-23" ),
( "Oosting", "Ronald", "Tahz@fcbarcelona.com", "Tahz", "1999-08-03" ),
( "Lazarus", "Fredi", "Blurry@fcbarcelona.com", "Blurry", "2004-06-30" ),
( "Gimenez", "Nacho", "Nachitow@fcbarcelona.com", "Nachitow", "2000-06-20" ),
( "Driessen", "Mitchell", "Mittaen@galaxyracer.com", "Mittaen", "2000-06-20" ),
( "Pickering", "Dylan", "eekso@galaxyracer.com", "eekso", "2002-06-29" ),
( "Berdin", "Ario", "arju@galaxyracer.com", "arju", "2002-11-04" ),
( "Bosch", "Marc", "Stake@giantsgaming.com", "Stake", "2000-07-20" ),
( "Cortés", "Samuel", "Zamué@giantsgaming.com", "Zamué", "2000-10-19" ),
( "Benayachi", "Amine", "itachi@giantsgaming.com", "itachi", "2003-08-13" ),
( "Benayachi2", "Amine", "itachi@giantsgaming2.com", "itachi", "2003-08-13" );

INSERT INTO Equipe
VALUES 
( "ROC", "Real Original Cracks", 1 ),
( "LSE", "Lausanne eSports", 4 ),
( "SLY", "Solary", 7 ),
( "TL", "Team Liquid", 10 ),
( "EE", "Eldelweiss ESports", 13 ),
( "VIT", "Renault Vitality", 16 ),
( "DIG", "Dignitas", 19 ),
( "FCB", "FC Barcelona", 22 ),
( "GAR", "Galaxy Racer", 25 ),
( "GIA", "Giants Gaming", 28 ),
( "TRC", "Truc",  31);


INSERT INTO Equipe_Joueur
VALUES 
( "EE", 3,  "2016-01-01 00-00-00","2016-02-01 00-00-00"),
( "ROC", 1,  "2020-01-01 00-00-00", NULL),
( "ROC", 2,  "2020-01-01 00-00-00", NULL),
( "ROC", 3,  "2020-01-01 00-00-00", NULL),
( "LSE", 4,  "2020-01-01 00-00-00", NULL),
( "LSE", 5,  "2020-01-01 00-00-00", NULL),
( "LSE", 6,  "2020-01-01 00-00-00", NULL),
( "SLY", 7,  "2020-01-01 00-00-00", NULL),
( "SLY", 8,  "2020-01-01 00-00-00", NULL),
( "SLY", 9,  "2020-01-01 00-00-00", NULL),
( "TL", 10,  "2020-01-01 00-00-00", NULL),
( "TL", 11,  "2020-01-01 00-00-00", NULL),
( "TL", 12,  "2020-01-01 00-00-00", NULL),
( "EE", 13,  "2020-01-01 00-00-00", NULL),
( "EE", 14,  "2020-01-01 00-00-00", NULL),
( "EE", 15,  "2020-01-01 00-00-00", NULL),
( "VIT", 16,  "2020-01-01 00-00-00", NULL),
( "VIT", 17,  "2020-01-01 00-00-00", NULL),
( "VIT", 18,  "2020-01-01 00-00-00", NULL),
( "DIG", 19,  "2020-01-01 00-00-00", NULL),
( "DIG", 20,  "2020-01-01 00-00-00", NULL),
( "DIG", 21,  "2020-01-01 00-00-00", NULL),
( "FCB", 22,  "2020-01-01 00-00-00", NULL),
( "FCB", 23,  "2020-01-01 00-00-00", NULL),
( "FCB", 24,  "2020-01-01 00-00-00", NULL),
( "GAR", 25,  "2020-01-01 00-00-00", NULL),
( "GAR", 26,  "2020-01-01 00-00-00", NULL),
( "GAR", 27,  "2020-01-01 00-00-00", NULL),
( "GIA", 28,  "2020-01-01 00-00-00", NULL),
( "GIA", 29,  "2020-01-01 00-00-00", NULL),
( "GIA", 30,  "2020-01-01 00-00-00", NULL);


INSERT INTO Tournoi (dateHeureDebut, nom, nbEquipesMax, dateHeureFin)
VALUES 
( "2021-02-01 20:00:00", 'Le Franco-Suisse', 4, '2021-02-01 23:00:00' ),
( "2021-03-01 20:00:00", 'IEM', 8, NULL );

INSERT INTO Tour
VALUES 
( 2, 1, 1 ),
( 1, 3, 1 ),
( 3, 1, 2 ),
( 2, 1, 2 ),
( 1, 3, 2 );

INSERT INTO Serie
VALUES 
( 1, 2, 1, 'ROC', 'SLY' ),
( 2, 2, 1, 'EE', 'VIT' ),
( 1, 1, 1, 'ROC', 'EE'),
( 1, 3, 2, 'ROC', 'TL'),
( 2, 3, 2, 'EE', 'VIT' ),
( 3, 3, 2, 'DIG', 'LSE' ),
( 4, 3, 2, 'FCB', 'SLY' ),
( 1, 2, 2, 'ROC', 'EE' ),
( 2, 2, 2, 'LSE', 'SLY' ),
( 1, 1, 2, 'ROC', 'LSE' );


INSERT INTO `Match`
VALUES 
( 1, 1, 2, 1 ),
( 1, 2, 2, 1 ),
( 1, 1, 1, 1 ),
( 2, 1, 1, 1 ),
( 3, 1, 1, 1 ),
( 1, 1, 3, 2 ),
( 1, 2, 3, 2 ),
( 1, 3, 3, 2 ),
( 1, 4, 3, 2 ),
( 1, 1, 2, 2 ),
( 1, 2, 2, 2 ),
( 1, 1, 1, 2 ),
( 2, 1, 1, 2 );


INSERT INTO Match_Joueur (idJoueur, nbButs, nbArrets, idMatch, idSerie, noTour, idTournoi)
VALUES 
( 1, 3, 1, 1, 1, 2, 1 ),
( 2, 0, 3, 1, 1, 2, 1 ),
( 3, 1, 2, 1, 1, 2, 1 ),
( 7, 0, 2, 1, 1, 2, 1 ),
( 8, 1, 0, 1, 1, 2, 1 ),
( 9, 1, 4, 1, 1, 2, 1 ),

( 13, 3, 1, 1, 2, 2, 1 ),
( 14, 0, 3, 1, 2, 2, 1 ),
( 15, 4, 2, 1, 2, 2, 1 ),
( 16, 1, 2, 1, 2, 2, 1 ),
( 17, 1, 0, 1, 2, 2, 1 ),
( 18, 1, 4, 1, 2, 2, 1 ),

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
( 13, 12, 5, 3, 1, 1, 1 ),
( 14, 0, 1, 3, 1, 1, 1 ),
( 15, 1, 4, 3, 1, 1, 1 ),

( 1, 0, 5, 1, 1, 3, 2 ),
( 2, 3, 1, 1, 1, 3, 2 ),
( 3, 4, 2, 1, 1, 3, 2 ),
( 10, 0, 1, 1, 1, 3, 2 ),
( 11, 1, 3, 1, 1, 3, 2 ),
( 12, 2, 0, 1, 1, 3, 2 ),

( 13, 2, 8, 1, 2, 3, 2 ),
( 14, 3, 2, 1, 2, 3, 2 ),
( 15, 1, 0, 1, 2, 3, 2 ),
( 16, 1, 4, 1, 2, 3, 2 ),
( 17, 0, 1, 1, 2, 3, 2 ),
( 18, 1, 3, 1, 2, 3, 2 ),

( 19, 0, 0, 1, 3, 3, 2 ),
( 20, 0, 3, 1, 3, 3, 2 ),
( 21, 1, 0, 1, 3, 3, 2 ),
( 4, 3, 3, 1, 3, 3, 2 ),
( 5, 6, 2, 1, 3, 3, 2 ),
( 6, 1, 9, 1, 3, 3, 2 ),

( 22, 3, 1, 1, 4, 3, 2 ),
( 23, 0, 4, 1, 4, 3, 2 ),
( 24, 1, 1, 1, 4, 3, 2 ),
( 7, 4, 1, 1, 4, 3, 2 ),
( 8, 2, 2, 1, 4, 3, 2 ),
( 9, 0, 7, 1, 4, 3, 2 ),

( 1, 3, 4, 1, 1, 2, 2 ),
( 2, 2, 0, 1, 1, 2, 2 ),
( 3, 1, 5, 1, 1, 2, 2 ),
( 13, 0, 4, 1, 1, 2, 2 ),
( 14, 2, 1, 1, 1, 2, 2 ),
( 15, 1, 3, 1, 1, 2, 2 ),

( 4, 3, 2, 1, 2, 2, 2 ),
( 5, 0, 7, 1, 2, 2, 2 ),
( 6, 5, 1, 1, 2, 2, 2 ),
( 7, 1, 3, 1, 2, 2, 2 ),
( 8, 1, 6, 1, 2, 2, 2 ),
( 9, 2, 2, 1, 2, 2, 2 ),

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


INSERT INTO Tournoi_Equipe
VALUES 
( 1, "ROC", "2020-01-01 20-00-00" ),
( 1, "SLY", "2020-01-01 20-01-00" ),
( 1, "EE", "2020-01-01 20-02-00" ),
( 1, "VIT", "2020-01-01 20-02-00" ),

( 2, "ROC", "2020-02-01 20-00-00" ),
( 2, "TL", "2020-02-01 20-01-00" ),
( 2, "EE", "2020-02-01 20-02-00" ),
( 2, "VIT", "2020-02-01 20-03-00" ),
( 2, "DIG", "2020-02-01 20-04-00" ),
( 2, "LSE", "2020-02-01 20-05-00" ),
( 2, "FCB", "2020-02-01 20-05-00" ),
( 2, "SLY", "2020-02-01 20-06-00" );

