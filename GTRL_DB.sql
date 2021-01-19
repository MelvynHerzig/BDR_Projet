-- MySQL Script Gestionnaire de tournois rocket League
-- Sat 16 Jan 2021
-- Model: New Model    Version: 1.0
-- Berney Alec, Forestier Quentin, Herzig Melvyn
-- Structure:
-- 		* Création des tables
-- 	  	* Ajout des contraintes et des indexs
-- 		* Création des fonctions
-- 		* Création des procédures
-- 		* Création des triggers
-- 		* Création des events
-- 		* Création du user

DROP SCHEMA IF EXISTS GestionnaireDeTournoisRocketLeague ;

CREATE SCHEMA IF NOT EXISTS GestionnaireDeTournoisRocketLeague DEFAULT CHARACTER SET utf8mb4;
USE GestionnaireDeTournoisRocketLeague;


CREATE TABLE Prix 
(
  id INT AUTO_INCREMENT,
  montantArgent DOUBLE NOT NULL,
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
  nbButs INT UNSIGNED NOT NULL DEFAULT 0,
  nbArrets INT UNSIGNED NOT NULL DEFAULT 0,
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
CREATE FUNCTION aUneInscriptionEnCours(pAcronymeEquipe VARCHAR(3))
RETURNS BOOLEAN
DETERMINISTIC
BEGIN

	DECLARE vIdSerie, vNoTour, vIdtournoi INT;
    
	SELECT Tournoi.id  INTO  vIdtournoi
    FROM Tournoi 
    INNER JOIN Tournoi_Equipe
		ON Tournoi.id = Tournoi_Equipe.idTournoi
	WHERE Tournoi_Equipe.acronymeEquipe = pAcronymeEquipe AND Tournoi.dateHeureFin IS NULL;

        
	-- Pour la dernière série trouvé dans l'arbre du tournoi
	IF vIdtournoi IS NOT NULL
	THEN      
		IF NOT estEnAttente(vIdtournoi)
        THEN
			SELECT id, noTour, idTournoi INTO vIdSerie, vNoTour, vIdTournoi
			FROM Serie WHERE (acronymeEquipe1 = pAcronymeEquipe OR acronymeEquipe2 = pAcronymeEquipe) AND 
							 idTournoi = vIdTournoi AND noTour = ( SELECT MIN(noTour) 
																   FROM Serie
																   WHERE acronymeEquipe1 = pAcronymeEquipe OR acronymeEquipe2 = pAcronymeEquipe AND idTournoi = vIdTournoi);
                                        
			-- Si il n'y a pas de vainqueur la serie est en cours et l'équipe participe donc toujours à un tournoi.
			IF vainqueurSerie(vIdSerie, vNoTour, vIdTournoi, FALSE) IS NULL
			THEN
				RETURN TRUE;
			END IF;
		ELSE
			RETURN TRUE;
        END IF;
	END IF;

	RETURN FALSE;

END $$


-- Calcul le nombre de tour en fonction du nombre d'équipes maximal.
CREATE FUNCTION calculerNbTours(pNbEquipeMax INT)
RETURNS INT
DETERMINISTIC
BEGIN
	DECLARE nbTour DOUBLE;
    SET nbTour = LOG2(pNbEquipeMax);
     
    -- Vérification si nombre entier et valeur correcte. 
	IF  CEIL(nbTour) = nbTour AND nbTour <= 8 AND nbTour >= 1
    THEN
		RETURN nbTour;
	ELSE 
		RETURN 0;
	END IF;
END $$


-- Compte pour une équipe sont nombre de victoire dans une série.
CREATE FUNCTION compterVictoireDansSerie(pAcronymeEquipe VARCHAR(3), pIdSerie INT, pNoTour INT, pIdTournoi INT, pSignalerErreurMatch BOOLEAN)
RETURNS INT
DETERMINISTIC
BEGIN
	DECLARE nbVictoires INT;
    SET nbVictoires = (SELECT COUNT(1)  
						FROM (SELECT `Match`.id  AS idMatch, Serie.id AS idSerie, Serie.noTour, Serie.idTournoi, vainqueurMatch(`Match`.id, Serie.id, Serie.noTour, Serie.idTournoi, pSignalerErreurMatch) AS vainqueur 
							  FROM Serie
							  INNER JOIN `Match`
								 ON `Match`.idSerie = Serie.id AND `Match`.noTour = Serie.noTour AND `Match`.idTournoi = Serie.idTournoi
							  WHERE Serie.id = pIdSerie AND Serie.noTour = pNoTour AND Serie.idTournoi = pIdTournoi) AS vainqueurs
					    WHERE vainqueurs.Vainqueur = pAcronymeEquipe);
    
    RETURN nbVictoires;
END $$

-- Retourne le nom de l'équipe pour un joueur à une date.
CREATE FUNCTION equipeDuJoueurLorsDu(pIdJoueur INT, pDate DATETIME)
RETURNS VARCHAR(3)
DETERMINISTIC
BEGIN
	DECLARE nomEquipe VARCHAR(3);
	SELECT acronymeEquipe INTO nomEquipe
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
	IF  3 = (SELECT COUNT(1) 
			 FROM Equipe_Joueur 
			 WHERE acronymeEquipe = pAcronymeEquipe AND dateHeureDepart IS NULL AND dateHeureArrivee <> '0001-01-01 00:00:00')
	THEN RETURN 1;
    ELSE RETURN 0;
    END IF;
END $$

-- Vérifie si le tournoi est en "Attente"
CREATE FUNCTION estEnAttente(pIdTournoi INT)
RETURNS BOOLEAN
DETERMINISTIC
BEGIN
	RETURN NOW() < (SELECT dateHeureDebut FROM Tournoi WHERE id = pIdTournoi);
END $$

-- Vérifie si les deux équipes peuvent jouer la série. 
CREATE FUNCTION seedingCorrect(pAcronymeEquipe1 VARCHAR(3), pAcronymeEquipe2 VARCHAR(3), pIdSerie INT, pNoTour INT, pIdTournoi INT)
RETURNS BOOLEAN
DETERMINISTIC
BEGIN
	DECLARE equipe1OK BOOLEAN DEFAULT FALSE;
    DECLARE equipe2OK BOOLEAN DEFAULT FALSE;
    DECLARE nbEquipe INT;
	-- Si premier tour du tournoi on vérifie que l'équipe ne soit pas déjà inscrite dans le tour.
    SET nbEquipe = (SELECT nbEquipesMax FROM Tournoi WHERE id = pIdTournoi);
    IF  calculerNbTours(nbEquipe) = pNoTour
    THEN
		IF NOT EXISTS (SELECT id FROM Serie WHERE noTour = pNoTour AND idTournoi = pIdTournoi AND
												 ( acronymeEquipe1 = pAcronymeEquipe1 OR acronymeEquipe2 = pAcronymeEquipe1 OR
												   acronymeEquipe1 = pAcronymeEquipe2 OR acronymeEquipe2 = pAcronymeEquipe2 ))
		THEN
			RETURN TRUE;
		ELSE
			RETURN FALSE;
		END IF;
	END IF;
   
    IF  pAcronymeEquipe1 IS NULL OR pAcronymeEquipe1 = vainqueurSerie( (pIdSerie * 2) - 1, pNoTour + 1, pIdTournoi, TRUE)
    THEN 
		SET equipe1OK = TRUE;
	END IF;
    
    IF  pAcronymeEquipe2 IS NULL OR  pAcronymeEquipe2 = vainqueurSerie( pIdSerie * 2, pNoTour + 1, pIdTournoi, TRUE)
    THEN 
		SET equipe2OK = TRUE;
	END IF;
    
    RETURN equipe1OK AND equipe2OK;
END $$

-- Retourne le vainqueur d'une série donnée si terminée sinon NULL.
CREATE FUNCTION vainqueurSerie(pIdSerie INT, pNoTour INT, pIdTournoi INT, pSignalerErreurMatch BOOLEAN)
RETURNS VARCHAR(3)
DETERMINISTIC
BEGIN
    
    DECLARE ae1, ae2 VARCHAR(3); -- Acronymes des équipes de la série
    DECLARE maxVictoire, nbVictoireE1, nbVictoireE2, taux INT;
    SELECT acronymeEquipe1, acronymeEquipe2 INTO ae1, ae2 FROM Serie WHERE id = pIdSerie AND noTour = pNoTour AND idTournoi = pIdTournoi;
    
    IF ae1 IS NULL OR ae2 IS NULL
    THEN
		RETURN NULL;
	END IF;
    
    SELECT longueurMaxSerie INTO maxVictoire FROM Tour WHERE no = pNoTour AND idTournoi = pIdTournoi;
	SET nbVictoireE1 = compterVictoireDansSerie(ae1, pIdSerie, pNoTour, pIdTournoi, pSignalerErreurMatch);
    SET nbVictoireE2 = compterVictoireDansSerie(ae2, pIdSerie, pNoTour, pIdTournoi, pSignalerErreurMatch);
	
    SET taux = (maxVictoire + 1) / 2;
    
    IF nbVictoireE1 = taux
    THEN
		RETURN ae1;
	END IF;
    
    IF nbVictoireE2 = taux
    THEN
		RETURN ae2;
	END IF;
    
	RETURN NULL;
END $$

-- Retourne le nom du vainqueur d'un match.
CREATE FUNCTION vainqueurMatch(pIdMatch INT, pIdSerie INT, pNoTour INT, pIdTournoi INT, pSignalerErreurMatch BOOLEAN)
RETURNS VARCHAR(3)
DETERMINISTIC
BEGIN
	DECLARE dateDuTournoi DATETIME;
    DECLARE be1, be2, nbe1, nbe2 INT; -- nb but et nb d'enregistrements par équipe
    DECLARE ae1, ae2 VARCHAR(3);
    
    SELECT dateHeureDebut INTO dateDuTournoi FROM Tournoi WHERE id = pIdTournoi;
    SELECT acronymeEquipe1, acronymeEquipe2 INTO ae1, ae2 FROM Serie WHERE id = pIdSerie AND noTour = pNoTour AND idTournoi = pIdTournoi;
    
	SELECT SUM(nbButs), COUNT(nbButs) INTO be1, nbe1 FROM Match_Joueur 
		WHERE idMatch = pIdMatch AND idSerie = pIdSerie AND noTour = pNoTour AND idTournoi = pIdTournoi AND equipeDuJoueurLorsDu(idJoueur, dateDuTournoi) = ae1;
    SELECT SUM(nbButs), COUNT(nbButs) INTO be2, nbe2 FROM Match_Joueur
		WHERE idMatch = pIdMatch AND idSerie = pIdSerie AND noTour = pNoTour AND idTournoi = pIdTournoi AND equipeDuJoueurLorsDu(idJoueur, dateDuTournoi) = ae2;
        
	IF ( nbe1 <> 3 OR nbe2 <> 3 )
    THEN    
		IF pSignalerErreurMatch
        THEN
			SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Une équipe n\'a pas obtenu trois performances de ses joueurs dans un match présent de la série.';
		ELSE
			RETURN NULL;
		END IF;
	END IF;
	 
    IF be1 = be2 AND pSignalerErreurMatch
    THEN
         IF pSignalerErreurMatch
        THEN
			SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Les équipes sont à égalité, résultat impossible.';
		ELSE
			RETURN NULL;
		END IF;
   END IF;
    
    IF be1 > be2 THEN
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
	DECLARE maxEquipe, nbEquipe INT;
	-- Nombre d'équipes max atteint ? 
    SET maxEquipe = (SELECT nbEquipesMax FROM Tournoi WHERE id = pIdTournoi );
    SET nbEquipe = (SELECT COUNT(1) FROM Tournoi_Equipe WHERE idTournoi = pIdTournoi);
	RETURN maxEquipe = nbEquipe;
END $$

-- Vérifie si le seeding du premier tour du tournoi (tour avec le plus d'équipe) est fait.
CREATE FUNCTION seedingEffectue(pIdTournoi INT)
RETURNS BOOLEAN
DETERMINISTIC
BEGIN
	DECLARE nbEquipes, premierTour INT;
	SET nbEquipes = (SELECT nbEquipesMax FROM Tournoi WHERE id = pIdTournoi);
	SET premierTour = calculerNbTours(nbEquipes);
    
    RETURN POW(2, premierTour)/2 = (SELECT COUNT(1) FROM Serie WHERE idTournoi = pIdTournoi AND noTour = premierTour AND acronymeEquipe1 IS NOT NULL AND acronymeEquipe2 IS NOT NULL);
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
	IF  pDateHeureFin IS NOT NULL AND pDateHeureDebut > pDateHeureFin
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
	IF NOT estComplete(pAcronymeEquipe)
	THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'L\'équipe n\'a pas trois joueur et ne peut donc pas s\'inscrire.';
	END IF;
END $$

-- Vérifie si l'équipe est inscrite au tournoi en paramètre 
CREATE PROCEDURE verifierInscription(pAcronyme VARCHAR(3), pIdTournoi INT)
BEGIN
	 IF pAcronyme IS NOT NULL AND  NOT EXISTS( SELECT * FROM Tournoi_Equipe WHERE idTournoi = pIdTournoi AND pAcronyme = acronymeEquipe)
     THEN 
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'L\'equipe n\'est pas inscrite au tournoi';
	 END IF;
END $$

-- Vérifie si le joueur appartient à l'équipe donnée au moment du tournoi et que l'équipe fasse partie de la série.
CREATE PROCEDURE verifierJoueurEstDansEquipeSerie(pIdJoueur INT, pIdSerie INT, pNoTour INT, pIdTournoi INT)
BEGIN
    DECLARE e1, e2, equipe VARCHAR(3);
    DECLARE dateTournoi DATETIME;
	SET dateTournoi = (SELECT dateHeureDebut FROM Tournoi WHERE id = pIdTournoi);
	SET equipe = equipeDuJoueurLorsDu(pIdJoueur, dateTournoi);
    IF equipe IS NULL
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Le joueur n\'appartient pas à équipe au moment du tournoi.';
	END IF;
	
    SELECT acronymeEquipe1, acronymeEquipe2 INTO e1, e2
    FROM Serie
    WHERE id = pIdSerie AND noTour = pNoTour AND idTournoi = pIdTournoi;
    
    IF  e1 <> equipe AND e2 <> equipe
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
	IF NOT seedingCorrect(pAcronymeEquipe1, pAcronymeEquipe2, pIdSerie, pNoTour, pIdTournoi )
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
	DECLARE vIdSerie, vNoTour INT;
	-- Curseurs
    DECLARE done INT DEFAULT FALSE;
	DECLARE equipe1Inscrite VARCHAR(3);
    DECLARE equipe2Inscrite VARCHAR(3);
	DECLARE curInscription CURSOR FOR SELECT acronymeEquipe FROM Tournoi_Equipe WHERE idTournoi = pIdTournoi ORDER BY dateInscription ASC;
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
    SET vIdSerie = 1; 
    SET vNoTour = calculerNbTours( (SELECT nbEquipesMax FROM Tournoi WHERE id = pIdTournoi) );
    OPEN curInscription;
    inscription_loop : LOOP
		FETCH curInscription INTO equipe1Inscrite;
        FETCH curInscription INTO equipe2Inscrite;
        
        IF done 
			THEN LEAVE inscription_loop; 
		END IF;
        
        UPDATE Serie SET acronymeEquipe1 = equipe1Inscrite,  acronymeEquipe2 = equipe2Inscrite WHERE id = vIdSerie AND noTour = vNoTour AND idTournoi = pIdTournoi;
        SET vIdSerie = vIdSerie + 1;
        
    END LOOP;
    CLOSE curInscription;
    COMMIT;
END $$

-- Après insertion du 6ème joueur, vérifie si la série est finie et fait progresser l'arbre de tournoi
CREATE PROCEDURE tenterPromotion(pIdMatch INT, pIdSerie INT, pNoTour INT, pIdTournoi INT)
BEGIN
	DECLARE nextSerie INT;
    DECLARE vainqueur VARCHAR(3);

	-- Promotion impossible en finale ou si les 6 joueurs n'ont pas de résultats
	IF pNoTour <> 1 AND 6 = (SELECT COUNT(1) FROM Match_Joueur WHERE idMatch = pIdMatch AND idSerie = pIdSerie AND noTour = pNoTour AND idTournoi = pIdTournoi)
    THEN 
		SET nextSerie = CEIL(pIdSerie / 2);
		SET vainqueur = vainqueurSerie(pIdSerie, pNoTour, pIdTournoi, TRUE);
        
        -- La série est terminée on promeut le vainqueur
        IF vainqueur IS NOT NULL
        THEN
			-- Si la serie était impair -> acronymeEquipe1 dans la suivante sinon acronymeEquipe2
            IF pIdSerie % 2 <> 0
            THEN
				UPDATE Serie SET acronymeEquipe1 = vainqueur WHERE id = nextSerie AND noTour = pNoTour - 1 AND idTournoi = pIdTournoi;
            ELSE
				UPDATE Serie SET acronymeEquipe2 = vainqueur WHERE id = nextSerie AND noTour = pNoTour - 1 AND idTournoi = pIdTournoi;
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

CREATE PROCEDURE verifierPrixNegatif(pPrix DOUBLE)
BEGIN
	IF pPrix < 0
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Le prix ne peux pas être négatif';
	END IF;
END $$


CREATE PROCEDURE accepterJoueur(pAcronymeEquipe VARCHAR(3), pIdJoueur INT)
BEGIN
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK; 
        RESIGNAL;
    END;

	START TRANSACTION;
	UPDATE Equipe_Joueur SET dateHeureArrivee = NOW(), dateHeureDepart = NULL WHERE idJoueur = pIdJoueur AND acronymeEquipe = pAcronymeEquipe AND  dateHeureArrivee = '0001-01-01 00:00:00';
    DELETE FROM Equipe_Joueur WHERE idJoueur = pIdJoueur AND dateHeureArrivee = '0001-01-01 00:00:00';
    COMMIT;
END $$
-----------------------------------------------------
-- TRIGGER
-----------------------------------------------------

-------------------- TOURNOI ----------------------
CREATE TRIGGER before_insert_Tournoi
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

CREATE TRIGGER before_update_Tournoi
BEFORE UPDATE ON Tournoi
FOR EACH ROW
BEGIN
	
    -- On empêche de change la taille du tournoi afin de ne pas avoir besoin de modifier le nombre de tour "dynamiquement"
	IF OLD.nbEquipesMax <> NEW.nbEquipesMax 
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Impossible de modifier le nombre maximal d\'équipes.';
	END IF;
    
    -- Si modification de la date de début
    IF NEW.dateHeureDebut <> OLD.dateHeureDebut
    THEN
		IF NOT estEnAttente(OLD.id)
        THEN
			SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Impossible de modifié la date de début d\'un tournoi déjà commencé.';
		ELSE
			CALL verifierDatePassee(NEW.dateHeureDebut);
		END IF;
	END IF;
    
    -- Si le tournoi est terminé, on empêche les mauvaises manipulations de la date de fin
    IF vainqueurSerie(1,1,NEW.id, FALSE) IS NOT NULL
    THEN
		IF  NEW.dateHeureFin IS NULL 
		THEN
			SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Impossiblede retirer la date de fin d\'un tournoi terminé.';
        END IF;
    ELSE
		IF  NEW.dateHeureFin IS NOT NULL AND NEW.dateHeureFin <> NEW.dateHeureDebut 
        THEN
			SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Impossible de terminer le tournoi tant que la finale n\'a pas de vainqueur.';
        END IF;
    END IF;
    
    CALL verifierDatePlusPetite(NEW.dateHeureDebut, NEW.dateHeureFin);
END $$

CREATE TRIGGER before_delete_Tournoi
BEFORE DELETE ON Tournoi
FOR EACH ROW
BEGIN
	-- Si la date de départ est dépassées et qu'il n'est pas complet il sera supprimé automatiquement par 
    -- les événements annuler_tournoi et supprimer_tournoi_annule
	IF (OLD.dateHeureDebut < NOW() AND OLD.dateHeureFin IS NULL) OR OLD.dateHeureDebut <> OLD.dateHeureFin
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Impossible de supprimer un tournoi commencé ou non annulé';
	END IF;
END $$

CREATE TRIGGER generer_arbre_Tournoi
AFTER INSERT ON Tournoi
FOR EACH ROW
BEGIN

	DECLARE vNoTour INT DEFAULT 1;
    DECLARE vNoSerie INT DEFAULT 1;
    DECLARE maxSerieDuTour INT;
    
    WHILE vNoTour <= calculerNbTours(NEW.nbEquipesMAx) DO
		INSERT INTO Tour VALUES (vNoTour, 1, NEW.id);
        SET maxSerieDuTour = POWER(2, vNoTour - 1);
        WHILE vNoSerie <= maxSerieDuTour DO
			INSERT INTO Serie VALUES (vNoSerie, vNoTour, NEW.id, NULL, NULL);
            SET vNoSerie = vNoSerie + 1;
        END WHILE;
        SET vNoSerie = 1;
        SET vNoTour = vNoTour + 1;
	END WHILE;
END $$

-------------------- TOURNOI_EQUIPE ----------------------
CREATE TRIGGER before_insert_Tournoi_Equipe
BEFORE INSERT ON Tournoi_Equipe
FOR EACH ROW
BEGIN
	CALL verifierInscriptionEquipe(NEW.acronymeEquipe, NEW.idTournoi);
	SET NEW.dateInscription = NOW();
END $$

CREATE TRIGGER before_update_Tournoi_Equipe
BEFORE UPDATE ON Tournoi_Equipe
FOR EACH ROW
BEGIN
   CALL verifierInscriptionEquipe(NEW.acronymeEquipe, NEW.idTournoi);
   SET NEW.dateInscription = NOW();
END $$

CREATE TRIGGER before_delete_Tournoi_Equipe
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
CREATE TRIGGER before_insert_Tour
BEFORE INSERT ON Tour
FOR EACH ROW
BEGIN
	DECLARE maxTeam, dernierNoTour INT;

	-- Verification du numéro de tour
	SET maxTeam = (SELECT nbEquipesMax FROM Tournoi WHERE id = NEW.idTournoi);
    SET dernierNoTour = (SELECT MAX(no) FROM Tour WHERE idTournoi = NEW.idTournoi);
	IF NEW.no <> 1 AND (NEW.no < 0 OR NEW.no > calculerNbTours(maxTeam) OR NEW.no <> dernierNoTour + 1)
	THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Nouvel id de tour invalide';
	END IF;
    CALL verifierLongueurMaxSerie(NEW.longueurMaxSerie);
END $$

CREATE TRIGGER before_update_Tour
BEFORE UPDATE ON Tour
FOR EACH ROW
BEGIN
	DECLARE debutTournoi DATETIME;
	
	-- Blocage de la modification du numéro
    IF OLD.no <> NEW.no 
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Impossible de modifier le numero de tour';
	END IF;
    
	-- Si le tournoi a débuté on ne modifie pas
    SET debutTournoi = (SELECT dateHeureDebut FROM Tournoi WHERE id = NEW.idTournoi);
    IF debutTournoi < NOW()
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Mise à jour du tour impossible, le tournoi a débuté';
	END IF;
    
    CALL verifierLongueurMaxSerie(NEW.longueurMaxSerie);
END $$

CREATE TRIGGER before_delete_Tour
BEFORE DELETE ON Tour
FOR EACH ROW
BEGIN
	-- cas cascade, le tournoi a été supprimé, pas de problème
    -- cas manuel, le tournoi est il encore présent 
	IF EXISTS (SELECT id FROM Tournoi WHERE id = OLD.idTournoi)
	THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Suppression du tour impossible';
	END IF;
END $$

----------------------- SERIE --------------------
CREATE TRIGGER before_insert_Serie
BEFORE INSERT ON serie
FOR EACH ROW
BEGIN
	DECLARE dernierIdSerie INT;
	SET dernierIdSerie = (SELECT MAX(id) FROM Serie WHERE noTour = NEW.noTour AND idTournoi = NEW.idTournoi);
	IF NEW.id <> 1 AND ( NEW.id <= 0 OR NEW.id > POWER(2, NEW.noTour - 1) OR NEW.id <> dernierIdSerie + 1)
	THEN 
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Nouvel id de série invalide';
	END IF;
    
	CALL verifierInscription(NEW.acronymeEquipe1, new.idTournoi);
    CALL verifierInscription(NEW.acronymeEquipe2, new.idTournoi);
	CALL verifierMemeEquipe(NEW.acronymeEquipe1, NEW.acronymeEquipe2);
    CALL verifierSeedingIncorrect(NEW.acronymeEquipe1, NEW.acronymeEquipe2, NEW.id, NEW.noTour, NEW.idTournoi);
END $$

CREATE TRIGGER before_update_Serie
BEFORE UPDATE ON serie
FOR EACH ROW
BEGIN
	-- Blocage de la modification du numéro
    IF OLD.id <> NEW.id OR OLD.noTour <> NEW.noTour OR OLD.idTournoi <> NEW.idTournoi 
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Impossible de modifier le numero de la série';
	END IF;

	-- Si la série a déjà commencé, qu'elle a déjà des performances de joueurs
	IF NEW.noTour <> 1 AND 0 <> (SELECT COUNT(1) FROM Match_Joueur WHERE idSerie = NEW.id AND noTour = NEW.noTour AND idTournoi = NEW.idTournoi)
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = ' Modification de la série impossible, les matchs ont déjà débutés.';
	END IF;
	CALL verifierInscription(NEW.acronymeEquipe1, new.idTournoi);
    CALL verifierInscription(NEW.acronymeEquipe2, new.idTournoi);
	CALL verifierMemeEquipe(NEW.acronymeEquipe1, NEW.acronymeEquipe2);
    CALL verifierSeedingIncorrect(NEW.acronymeEquipe1, NEW.acronymeEquipe2, NEW.id, NEW.noTour, NEW.idTournoi);
END $$

CREATE TRIGGER before_delete_Serie
BEFORE DELETE ON Serie
FOR EACH ROW
BEGIN
	-- cas cascade, le tournoi a été supprimé, pas de problème
    -- cas manuel, le tournoi est il encore présent 
	IF EXISTS (SELECT no FROM Tour WHERE no = OLD.noTour AND idTournoi = OLD.idTournoi)
	THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Suppression de la série impossible';
	END IF;
END $$
----------------------- EQUIPE --------------------
CREATE TRIGGER before_insert_Equipe
AFTER INSERT ON Equipe
FOR EACH ROW
BEGIN
	CALL verifierAcronyme(NEW.acronyme);
END $$

CREATE TRIGGER after_insert_Equipe
AFTER INSERT ON Equipe
FOR EACH ROW
BEGIN
	-- La vérification qui affirme que le responsable n''est pas déjà dans une équie s'effectue au moment de l'insertion dans equipe_joueur.
	INSERT INTO Equipe_Joueur (acronymeEquipe, idJoueur, dateHeureArrivee, dateHeureDepart)
    VALUE(NEW.acronyme, NEW.idResponsable, '0001-01-01 00:00:00', NULL);
	
    -- Comme call accepterJoueur();
	UPDATE Equipe_Joueur SET dateHeureArrivee = NOW(), dateHeureDepart = NULL WHERE idJoueur = NEW.idResponsable AND acronymeEquipe = NEW.acronyme AND  dateHeureArrivee = '0001-01-01 00:00:00';
    DELETE FROM Equipe_Joueur WHERE idJoueur = NEW.idResponsable AND dateHeureArrivee = '0001-01-01 00:00:00';
END $$

CREATE TRIGGER before_update_Equipe
BEFORE UPDATE ON Equipe
FOR EACH ROW
BEGIN
    CALL verifierAcronyme(NEW.acronyme);
	IF OLD.idresponsable <> NEW.idResponsable
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Le responsable de l\'équipe ne peut être changé';
	END IF;
END $$

----------------------- JOUEUR --------------------
CREATE TRIGGER before_insert_Joueur
BEFORE INSERT ON Joueur
FOR EACH ROW
BEGIN
    CALL verifierDateFuture(NEW.dateNaissance);
    CALL verifierEmail(NEW.email);
END $$

CREATE TRIGGER before_update_Joueur
BEFORE UPDATE ON Joueur
FOR EACH ROW
BEGIN
    CALL verifierDateFuture(NEW.dateNaissance);
    CALL verifierEmail(NEW.email);
END $$

----------------------- EQUIPE_JOUEUR --------------------
CREATE TRIGGER before_insert_Equipe_Joueur
BEFORE INSERT ON Equipe_Joueur
FOR EACH ROW
BEGIN
	IF NEW.dateHeureArrivee <> '0001-01-01 00:00:00'
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Seul une demande peut être insérée dans la table equipe_joueur.';
	END IF;
    
    CALL verifierDejaDansUneEquipe(NEW.idJoueur);
END $$

CREATE TRIGGER before_update_Equipe_Joueur
BEFORE UPDATE ON Equipe_Joueur
FOR EACH ROW
BEGIN
	IF OLD.idJoueur <> NEW.idJoueur
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Impossible de modifier l\'id du joueur dans un enregistrement Equipe_joueur';
	END IF;
    
    IF OLD.acronymeEquipe <> NEW.acronymeEquipe
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Impossible de modifier l\'équipe du joueur dans un enregistrement Equipe_joueur';
	END IF;
    
    IF OLD.dateHeureArrivee <> NEW.dateHeureArrivee AND OLD.dateHeureArrivee <> '0001-01-01 00:00:00'
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Impossible de modifier la date d\'arrivée, risque d\'incohérence.';
	END IF;
    
    -- Si on tente de lui le re-refaire rejoindre l'équipe avec le même enregistrement
    IF NEW.dateHeureDepart IS NULL AND OLD.dateHeureDepart IS NOT NULL 
	THEN 
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Impossible de rejoindre a nouveau l\'équipe avec le même enregistrement';
	END IF;
    
    CALL verifierDatePlusPetite(NEW.dateHeureArrivee,NEW.dateHeureDepart);
    
	IF OLD.dateHeureArrivee = '0001-01-01 00:00:00' AND NEW.dateHeureArrivee <> OLD.dateHeureArrivee
    THEN
		IF estComplete(NEW.acronymeEquipe)
        THEN
			SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = ' Le joueur ne peut pas être accepté, équipe pleine.';
		END IF;
        SET NEW.dateHeureArrivee = NOW();
    END IF;
    
    -- Si on tente de lui faire quitter l'équipe
    IF NEW.dateHeureDepart IS NOT NULL AND OLD.dateHeureDepart IS NULL
    THEN
		-- Est-ce que son équipe participe à un tournoi.
        IF aUneInscriptionEnCours(OLD.acronymeEquipe) 
        THEN 
			SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Le joueur ne peut pas quitter une équipe inscrite à un tournoi.';
        END IF;
        SET NEW.dateHeureDepart = NOW();
	END IF;
    
    -- Impossible de destituer le responsable
    IF OLD.idJoueur = (SELECT idResponsable FROM Equipe WHERE acronyme = OLD.acronymeEquipe) AND NEW.dateHeureDepart IS NOT NULL
    THEN 
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Le responsable ne peut pas quitter son équiper, on a besoin de lui.';
	END IF;
END $$

------------------------- MATCH --------------------
CREATE TRIGGER before_insert_Match
BEFORE INSERT ON `Match`
FOR EACH ROW
BEGIN
	-- La serie du match contient elle deux équipes ? 
	DECLARE e1 VARCHAR(3);
    DECLARE e2 VARCHAR(3);
    DECLARE maxMatch, noDernierMatch INT;
    SELECT AcronymeEquipe1, AcronymeEquipe2 INTO e1, e2 FROM Serie WHERE id = NEW.idSerie AND noTour = NEW.noTour AND idTournoi = NEW.idTournoi;
    IF e1 IS NULL OR e2 IS NULL
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Impossible de créer un match tant que la série n\'a pas deux équipes';
	END IF;
    
    -- Vérification de l'id
	SET maxMatch = (SELECT longueurMaxSerie FROM Tour WHERE idTournoi = NEW.idTournoi AND no = NEW.noTour);
	SET noDernierMatch = (SELECT MAX(id) FROM `Match` WHERE idSerie = NEW.idSerie AND noTour = NEW.noTour AND idTournoi = NEW.idTournoi);
	IF NEW.id <> 1 AND ( NEW.id > maxMatch OR NEW.id <= 0 OR NEW.id <> (noDernierMatch + 1) )
	THEN
 		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Nouvel id de match invalide';
	END IF;
    
    -- Si la serie connait déjà un vainqueur.
	IF vainqueurSerie(NEW.idSerie, NEW.noTour, NEW.idTournoi, TRUE) IS NOT NULL
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Serie terminée, ajout de match impossible';
    END IF;
END $$

CREATE TRIGGER before_update_Match
BEFORE UPDATE ON `Match`
FOR EACH ROW
BEGIN
	SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Impossible de modifier la clé du tournoi.';
END $$

CREATE TRIGGER before_delete_Match
BEFORE DELETE ON `Match`
FOR EACH ROW
BEGIN
	-- Cas cascade aucun problème.
    -- Cas manuel, blocage si série supprimée, 
    IF EXISTS (SELECT id FROM Serie WHERE id = OLD.idSerie AND noTour = OLD.noTour AND idTournoi = OLD.idTournoi)
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Impossible de supprimer un match';
    END IF;
END $$

----------------------- MATCH_JOUEUR --------------------
CREATE TRIGGER before_insert_Match_Joueur
BEFORE INSERT ON Match_Joueur
FOR EACH ROW
BEGIN
    CALL verifierJoueurEstDansEquipeSerie(NEW.idJoueur, NEW.idSerie, NEW.noTour, NEW.idTournoi);
END $$

CREATE TRIGGER after_insert_Match_Joueur
AFTER INSERT ON Match_Joueur
FOR EACH ROW
BEGIN
	-- Est ce que la finale est terminée
	IF NEW.noTour = 1
 	THEN 
		IF 6 = (SELECT COUNT(1) FROM Match_Joueur WHERE idMatch = NEW.idMatch AND idSerie = NEW.idSerie AND noTour = NEW.noTour AND idTournoi = NEW.idTournoi)
		THEN 
 			IF vainqueurSerie(NEW.idSerie, NEW.noTour, NEW.idTournoi, TRUE) IS NOT NULL
			THEN
				UPDATE Tournoi SET dateHeureFin = NOW() WHERE id = NEW.idTournoi;
			END IF;
		END IF;
	ELSE
		CALL tenterPromotion(NEW.idMatch, NEW.idSerie, NEW.noTour, NEW.idTournoi);
    END IF;
END $$

CREATE TRIGGER before_update_Match_Joueur
BEFORE UPDATE ON Match_Joueur
FOR EACH ROW
BEGIN
	DECLARE serieSuivante INT;

	-- Blocage de la modification de la clé.
    IF OLD.idJoueur <> NEW.idJoueur OR OLD.idMatch <> NEW.idMatch OR OLD.idSerie <> NEW.idSerie OR NEW.noTour <> OLD.noTour OR OLD.idTournoi <> NEW.idTournoi
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = ' Modification de la clé du match impossible.';
	END IF;

	-- Si la série suivante a déjà commencé on bloque la modification des performances
	SET serieSuivante = CEIL(NEW.idSerie / 2);
	IF NEW.noTour <> 1 AND 0 <> (SELECT COUNT(1) FROM Match_Joueur WHERE idSerie = serieSuivante AND noTour = NEW.noTour - 1 AND idTournoi = NEW.idTournoi)
    THEN
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = ' Modification/insertion du score du joueur impossible, la serie suivante a déjà commencée.';
	END IF;
END $$

CREATE TRIGGER after_update_Match_Joueur
AFTER UPDATE ON Match_Joueur
FOR EACH ROW
BEGIN
	CALL tenterPromotion(NEW.idMatch, NEW.idSerie, NEW.noTour, NEW.idTournoi);
END $$

----------------------- PRIX --------------------
CREATE TRIGGER before_insert_Prix
BEFORE INSERT ON Prix
FOR EACH ROW
BEGIN
	CALL verifierPrixNegatif(NEW.montantArgent);
END $$

CREATE TRIGGER before_update_Prix
BEFORE UPDATE ON Prix
FOR EACH ROW
BEGIN
	CALL verifierPrixNegatif(NEW.montantArgent);
END $$

-----------------------------------------------------
-- EVENTS
-----------------------------------------------------
-- Chaque 6 heure, vérifie si la date de début d'un tournoi a été dépassée, si c'est le cas termine le tournoi.alter
CREATE EVENT annuler_tournoi
ON SCHEDULE EVERY 1 HOUR 
STARTS CURRENT_TIMESTAMP
DO
BEGIN 
	DECLARE done INT DEFAULT FALSE;
	DECLARE vIdTournoi INT;
    DECLARE tournoiCursor CURSOR FOR SELECT id 
									 FROM Tournoi 
									 WHERE dateHeureDebut < NOW() AND nbEquipesMax > (SELECT COUNT(1) 
																					  FROM Tournoi_Equipe
																					  WHERE idTournoi = id);
	OPEN tournoiCursor ;
    read_loop : LOOP
		
        FETCH tournoiCursor INTO vIdTournoi;
		
        IF done THEN
			LEAVE read_loop;
		END IF;
        
		UPDATE Tournoi 
		SET dateHeureFin = dateHeureDebut
		WHERE id = vIdTournoi;
    
	END LOOP;
    CLOSE tournoiCursor;
END $$

-- Chaque 7 jour vérifie si le un tournoi de plus de 7 jour peut être supprimé.
CREATE EVENT supprimer_tournoi_annule
ON SCHEDULE EVERY 7 DAY
STARTS CURRENT_TIMESTAMP + INTERVAL 10 MINUTE
DO
BEGIN 
	DECLARE done INT DEFAULT FALSE;
	DECLARE vIdTournoi INT;
    DECLARE tournoiCursor CURSOR FOR SELECT id 
									 FROM Tournoi 
									 WHERE dateHeureDebut = dateHeureFin;
	OPEN tournoiCursor ;
    read_loop : LOOP
		
        FETCH tournoiCursor INTO vIdTournoi;
		
        IF done THEN
			LEAVE read_loop;
		END IF;
        
		DELETE FROM Tournoi WHERE id = vIdTournoi AND DATEDIFF( NOW(), dateHeureFin) >= 7;
    
	END LOOP;
    CLOSE tournoiCursor;
END $$

DELIMITER ;

DROP USER IF EXISTS 'GDTRL_Manager';
CREATE USER 'GDTRL_Manager' IDENTIFIED BY 'P@$$w0rd1sHArDt0F1nd';
GRANT DELETE, INSERT, SELECT, UPDATE, EXECUTE ON GestionnaireDeTournoisRocketLeague.* TO 'GDTRL_Manager';

