-- MySQL Script Gestionnaire de tournois rocket League
-- Fri Dec 11 11:16:36 2020
-- Model: New Model    Version: 1.0
-- Berney Alec, Forestier Quentin, Herzig Melvyn

USE GestionnaireDeTournoisRocketLeague ;

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
( 50.00 ),
( 100.00 ),
( 150.00 ),
( 200.00 ),
( 250.00 ),
( 300.00 ),
( 350.00 ),
( 500.00 ),
( 1000.00 ),
( 1500.00 ),
( 2000.00 );

INSERT INTO Prix_Objet 
VALUES 
( 1, 1 ),
( 2, 2 ),
( 3, 3 ),
( 4, 4 ),
( 5, 5 );

INSERT INTO Joueur (nom, prenom, email, pseudo, dateNaissance)
VALUES 
( 'Forestier', 'Qunetin', 'quentin.forestier@heig-vd.ch', 'Dudude', '2001-05-16' ),
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
