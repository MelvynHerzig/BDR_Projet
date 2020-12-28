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
( "Benayachi", "Amine", "itachi@giantsgaming.com", "itachi", "2003-08-13" );


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
( "GIA", "Giants Gaming", 28 );


INSERT INTO Equipe_Joueur
VALUES 
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


INSERT INTO Tournoi (dateHeureDebut, nom, nbEquipesMax)
VALUES 
( "2021-02-01 20:00:00", "Le Franco-Suisse", 4),
( "2021-03-01 20:00:00", "IEM", 8 );


INSERT INTO Tour
VALUES 
( 2, 1, 1 ),
( 1, 3, 1 ),
( 3, 1, 2 ),
( 2, 1, 2 ),
( 1, 3, 2 );

INSERT INTO Serie
VALUES 
( 1, 2, 1 ),
( 2, 2, 1 ),
( 1, 1, 1 ),
( 1, 3, 2 ),
( 2, 3, 2 ),
( 3, 3, 2 ),
( 4, 3, 2 ),
( 1, 2, 2 ),
( 2, 2, 2 ),
( 1, 1, 2 );


INSERT INTO `Match`
VALUES 
( 1, 1, 2, 1 ),
( 1, 2, 2, 1 ),
( 1, 1, 1, 1 ),
( 2, 1, 1, 1 ),
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

( 1, 6, 1, 2, 1, 1, 1 ),
( 2, 2, 3, 2, 1, 1, 1 ),
( 3, 4, 2, 2, 1, 1, 1 ),
( 13, 1, 5, 2, 1, 1, 1 ),
( 14, 0, 1, 2, 1, 1, 1 ),
( 15, 1, 4, 2, 1, 1, 1 ),

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


INSERT INTO Serie_Equipe
VALUES 
( "ROC", 1, 2, 1 ),
( "SLY", 1, 2, 1 ),
( "EE", 2, 2, 1 ),
( "VIT", 2, 2, 1 ),
( "ROC", 1, 1, 1 ),
( "EE", 1, 1, 1 ),
( "ROC", 1, 3, 2 ),
( "TL", 1, 3, 2 ),
( "EE", 2, 3, 2 ),
( "VIT", 2, 3, 2 ),
( "DIG", 3, 3, 2 ),
( "LSE", 3, 3, 2 ),
( "FCB", 4, 3, 2 ),
( "SLY", 4, 3, 2 ),
( "ROC", 1, 2, 2 ),
( "EE", 1, 2, 2 ),
( "LSE", 2, 2, 2 ),
( "SLY", 2, 2, 2 ),
( "ROC", 1, 1, 2 ),
( "LSE", 1, 1, 2 );
