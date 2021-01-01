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

-- Calcul le nombre de tour en fonction du nombre d'équipes maximal.
DELIMITER $$
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
					    WHERE vainqueurs.Vainqueur = pAcronymeEquipe);
    
    RETURN @nbVictoires;
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

-- Vérifie si le tournoi est en "Attente"
DELIMITER $$
CREATE FUNCTION estEnAttente(pIdTournoi INT)
RETURNS BOOLEAN
DETERMINISTIC
BEGIN
	RETURN NOW() < (SELECT Tournoi.dateHeureDebut FROM Tournoi WHERE Tournoi.id = pIdTournoi);
END
$$

-- Vérifie si les deux équipes peuvent jouer la série.
DELIMITER $$ 
CREATE FUNCTION seedingCorrect(pAcronymeEquipe1 VARCHAR(3), pAcronymeEquipe2 VARCHAR(3), pIdSerie INT, pNoTour INT, pIdTournoi INT)
RETURNS BOOLEAN
DETERMINISTIC
BEGIN
	-- Si premier tour du tournoi aucune vérification n'est nécessaire
    SET @nbEquipe = (SELECT Tournoi.nbEquipesMax FROM Tournoi WHERE Tournoi.id = pIdTournoi);
    IF ( calculerNbTours(@nbEquipe) = pNoTour)
    THEN
		RETURN TRUE;
	END IF;
    
    IF ( pAcronymeEquipe1 = vainqueurSerie( (pIdSerie * 2) - 1, pNoTour + 1, pIdTournoi) AND pAcronymeEquipe2 = vainqueurSerie( pIdSerie * 2, pNoTour + 1, pIdTournoi)  )
    THEN 
		RETURN TRUE;
	END IF;
    
    RETURN FALSE;
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

-- Vérifie que la date en paramètre est plus grande que la date courante.
DELIMITER $$
CREATE PROCEDURE verifierDateFuture(pDate DATETIME)
BEGIN
	 IF pDate > NOW() THEN 
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'La date de naissance est dans le future.';
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

DELIMITER $$
CREATE PROCEDURE verifierDatePlusPetite (pDateHeureDebut DATETIME, pDateHeureFin DATETIME)
BEGIN
	IF( pDateHeureFin IS NOT NULL AND pDateHeureDebut > pDateHeureFin)
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'La date de début ne peut être plus grande que la date de fin';
	END IF;
END
$$

-- Vérifie si la joueur en paramètre a déjà une équipe
DELIMITER $$
CREATE PROCEDURE verifierDejaDansUneEquipe(pIdJoueur INT)
BEGIN
	 IF EXISTS( SELECT * 
				FROM Equipe_Joueur 
                WHERE idJoueur = pIdJoueur AND dateHeureDepart IS NULL AND dateHeureArrivee <> '0000-00-00 00:00:00') 
	THEN 
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Le joueur est déjà dans une équipe';
	END IF;
END
$$

-- Vérifie si une équipe est complète
DELIMITER $$
CREATE PROCEDURE verifierEquipeComplete(pAcronymeEquipe VARCHAR(3))
BEGIN
	IF( NOT estComplete(pAcronymeEquipe))
	THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'L\'équipe n\'a pas trois joueur et ne peut donc pas s\'inscrire.';
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

-- Vérifie si le seeding est correct sinon lève une exception.
DELIMITER $$
CREATE PROCEDURE verifierSeedingIncorrect(pAcronymeEquipe1 VARCHAR(3), pAcronymeEquipe2 VARCHAR(3), pIdSerie INT, pNoTour INT, pIdTournoi INT)
BEGIN
	IF (seedingCorrect(pAcronymeEquipe1, pAcronymeEquipe2, pIdSerie, pNoTour, pIdTournoi ) = FALSE) 
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'L\'équipe ne peut pas occuper cette position dans cette série';
	END IF;
END
$$

-- Vérifie si le tournoi est en attente.
DELIMITER $$
CREATE PROCEDURE verifierTournoiEnAttente(pIdTournoi INT)
BEGIN
	 IF NOT estEnAttente(pIdTournoi) THEN 
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Le tournoi a déjà commencé inscription impossible';
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
	-- Vérification du nombre max d'équipe.
	IF calculerNbTours(NEW.nbEquipesMax) = 0 
    THEN 
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'nbEquipesMax doit être une puissance de 2 entre 2 et 256.';
	END IF;
    
    CALL verifierDatePassee(NEW.dateHeureDebut);
    CALL verifierDatePlusPetite(NEW.dateHeureDebut, NEW.dateHeureFin);
END
$$
DELIMITER $$
CREATE TRIGGER tournoiMiseAJour
BEFORE UPDATE
ON Tournoi
FOR EACH ROW
BEGIN
	IF (OLD.nbEquipesMax <> NEW.nbEquipesMax) 
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Impossible de modifier le nombre maximal d\'équipes.';
	END IF;
    CALL verifierDatePassee(NEW.dateHeureDebut);
    CALL verifierDatePlusPetite(NEW.dateHeureDebut, NEW.dateHeureFin);
    
    -- On vérifie si la finale est correcte en essayant de récupérer le vainqueur.
    IF (NEW.dateHeureFin IS NOT NULL AND NEW.dateHeureFin <> NEW.dateHeureDebut)
    THEN
		SET @try = vainqueurSerie(1, 1, NEW.id);
	END IF;
END
$$
DELIMITER $$
CREATE TRIGGER tournoiSuppression
BEFORE DELETE
ON Tournoi
FOR EACH ROW
BEGIN
	IF ((OLD.dateHeureDebut < NOW() AND OLD.dateHeureFin IS NULL) OR OLD.dateHeureDebut <> OLD.dateHeureFin)
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = "Impossible de supprimer un tournoi déjà commencé et non annulé";
	END IF;
END
$$
DELIMITER $$
CREATE TRIGGER gernerateTournamentTree
AFTER INSERT
ON Tournoi
FOR EACH ROW
BEGIN
	DECLARE vNoTour INT DEFAULT 1;
    
    WHILE vNoTour <= calculerNbTours(NEW.nbEquipesMAx) DO
		INSERT INTO Tour VALUES (vNoTour, 1, NEW.id);
        
        SET vNoTour = vNoTour + 1;
	END WHILE;
END
$$

-------------------- TOURNOI_EQUIPE ----------------------
DELIMITER $$
CREATE TRIGGER TournoiEquipeInsertion
BEFORE INSERT
ON Tournoi_Equipe
FOR EACH ROW
BEGIN
	-- Nombre d'équipes max atteint ? 
    SET @maxEquipe = (SELECT Tournoi.nbEquipesMax FROM Tournoi WHERE Tournoi.id = NEW.idTournoi);
    SET @nbEquipe = (SELECT COUNT(1) FROM Tournoi_Equipe WHERE Tournoi_Equipe.idTournoi = NEW.idTournoi);
	IF( @maxEquipe = @nbEquipe)
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Les inscriptions du tournoi sont complètes';
	END IF;

	-- Le tournoi est-il encore en attente
    CALL verifierTournoiEnAttente(NEW.idTournoi);
    
    -- Equipe déjà inscrite à un autre tournoi ? 
    IF (aUneInscriptionEnCours(NEW.acronymeEquipe))
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'L\'équipe participe déjà à un tournoi';
    END IF;
    
    -- Equipe complète ? 
	CALL verifierEquipeComplete(NEW.acronymeEquipe);
    
END
$$
DELIMITER $$
CREATE TRIGGER TournoiEquipeMiseAJour
BEFORE UPDATE
ON Tournoi_Equipe
FOR EACH ROW
BEGIN
    -- Le tournoi est-il encore en attente ?
    CALL verifierTournoiEnAttente(NEW.idTournoi);
	IF (NEW.acronymeEquipe <> OLD.acronymeEquipe AND aUneInscriptionEnCours(NEW.acronymeEquipe))
		THEN SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'L\'equipe participe déjà à un tournoi';
    END IF;
    
    CALL verifierEquipeComplete(NEW.acronymeEquipe);
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
BEFORE UPDATE
ON Tour
FOR EACH ROW
BEGIN
	-- Si le tournoi a débuté on ne modifie pas
    SET @debutTournoi = (SELECT Tournoi.dateHeureDebut FROM Tournoi WHERE Tournoi.id = NEW.idTournoi);
    IF(@debutTournoi < NOW())
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Mise à jour du tour impossible, le tournoi a débuté';
	END IF;
    CALL verifierLongueurMaxSerie(NEW.longueurMaxSerie);
END
$$

----------------------- SERIE --------------------
DELIMITER $$
CREATE TRIGGER serieInsertion
BEFORE INSERT
ON serie
FOR EACH ROW
BEGIN
	CALL verifierInscription(NEW.acronymeEquipe1, new.idTournoi);
    CALL verifierInscription(NEW.acronymeEquipe2, new.idTournoi);
	CALL verifierMemeEquipe(NEW.acronymeEquipe1, NEW.acronymeEquipe2);
    CALL verifierSeedingIncorrect(NEW.acronymeEquipe1, NEW.acronymeEquipe2, NEW.id, NEW.noTour, NEW.idTournoi);
END
$$
DELIMITER $$
CREATE TRIGGER serieMiseAJour
BEFORE UPDATE
ON serie
FOR EACH ROW
BEGIN
	CALL verifierInscription(NEW.acronymeEquipe1, new.idTournoi);
    CALL verifierInscription(NEW.acronymeEquipe2, new.idTournoi);
	CALL verifierMemeEquipe(NEW.acronymeEquipe1, NEW.acronymeEquipe2);
    CALL verifierSeedingIncorrect(NEW.acronymeEquipe1, NEW.acronymeEquipe2, NEW.id, NEW.noTour, NEW.idTournoi);
END
$$

----------------------- EQUIPE --------------------
DELIMITER $$
CREATE TRIGGER equipeInsertion
AFTER INSERT
ON Equipe
FOR EACH ROW
BEGIN
	INSERT INTO Equipe_Joueur (acronymeEquipe, idJoueur, dateHeureArrivee, dateHeureDepart)
    VALUE(NEW.acronyme, NEW.idResponsable, NOW(), NULL);
END
$$
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
    CALL  verifierDatePlusPetite(NEW.dateHeureArrivee,NEW.dateHeureDepart);
    IF ( estComplete(NEW.acronymeEquipe) )
    THEN 
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Impossible de rejoindre l\'equipe, elle est complète';
    END IF;
    CALL verifierDejaDansUneEquipe(NEW.idJoueur);
END
$$

DELIMITER $$
CREATE TRIGGER equipeJoueurMiseAJour
BEFORE UPDATE
ON Equipe_Joueur
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
    
    -- Le joueur rejoint l'équipe
    IF(OLD.dateHeureArrivee = '0000-00-00 00:00:00' AND NEW.dateHeureArrivee <> OLD.dateHeureArrivee)
    THEN
		DELETE FROM Equipe_Joueur WHERE Equipe_Joueur.dateHeureArrivee = '0000-00-00 00:00:00' AND Equipe_Joueur.idJoueur = NEW.idJoueur;
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

------------------------- MATCH --------------------
DELIMITER $$
CREATE TRIGGER matchInsertion
BEFORE INSERT
ON `Match`
FOR EACH ROW
BEGIN
	
	SET @maxMatchSerie = (SELECT Tour.longueurMaxSerie FROM Tour WHERE Tour.idTournoi = NEW.idTournoi AND Tour.no = NEW.noTour);
    SET @nbMatchSerie = (SELECT COUNT(1) FROM `Match` WHERE `Match`.idSerie = NEW.idSerie AND `Match`.noTour = NEW.noTour AND `Match`.idTournoi = NEW.idTournoi);
	IF( @maxMatchSerie = @nbMatchSerie)
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'La série est complète';
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
    WHERE Tournoi.dateHeureFin IS NULL AND Tournoi.dateHeureDebut < NOW() 
		  AND Tournoi.nbEquipesMax > (SELECT COUNT(1) FROM Tournoi_Equipe
									  WHERE Tournoi_Equipe = Tournoi.id);
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

