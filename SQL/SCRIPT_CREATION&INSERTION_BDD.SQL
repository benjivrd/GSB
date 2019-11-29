create table ASSOCIATION
  (
     id int identity (1, 1) not null primary key,
     nom varchar(32) null,
     mission varchar(255) null,
     id_pays int not null,
     id_personne int not null
  )
go

create table TYPE_VIP
  (
     id int identity (1, 1) not null primary key,
     libelle varchar(32) null
  )
go

create table CONTROLE
  (
     id int identity (1, 1) not null primary key,
     "date" date null,
     resume_resultat varchar(255) null,
     montant_ht money null,
     id_entreprise int not null,
     id_type int not null,
     id_zone_stockage int not null
  )
go

create table TYPE_CONTROLE
  (
     id int identity (1, 1) not null primary key,
     libelle varchar(32) null
  )
go

create table ENTREPRISE
  (
     id int identity (1, 1) not null primary key,
     nom varchar(32) null,
     adr_ville varchar(32) null,
     adr_cp varchar(5) null,
     adr_rue varchar(255) null,
     email varchar(128) null
  )
go

create table PAYS
  (
     id int identity (1, 1) not null primary key,
     nom varchar(32) null
  )
go

create table CATEGORIE_PRODUIT
  (
     id int identity (1, 1) not null primary key,
     libelle varchar(32) null
  )
go

create table "ACTION"
  (
     id int identity (1, 1) not null primary key,
     libelle varchar(32) null,
     "description" varchar(255) null
  )
go

create table ANNEE
  (
     annee varchar(32) not null primary key
  )
go

create table "PUBLIC"
  (
     id int identity (1, 1) not null primary key,
     libelle varchar(32) null
  )
go

create table CAMPAGNE
  (
     id int identity (1, 1) not null primary key,
     intitule varchar(255) null,
     objectif varchar(255) null,
     date_debut date null,
     date_fin date null,
     id_employe int not null
  )
go

create table EVENEMENT
  (
     id int identity (1, 1) not null primary key,
     theme varchar(255) null,
     date_debut date null,
     date_fin date null,
     id_campagne int not null
  )
go

create table CONTRAT
  (
     id int identity (1, 1) not null primary key,
     "date" date null,
     budget money null,
     depense money null,
     id_association int not null,
     id_action int not null
  )
go

create table ERREUR
  (
     id int identity (1, 1) not null primary key,
     "date" date null,
     heure time null,
     titre varchar(128) null,
     code varchar(32) null,
     texte varchar(255) null
  )
go

create table ZONE_STOCKAGE
  (
     id int identity (1, 1) not null primary key,
     libelle varchar(32) null,
     adr_ville varchar(32) null,
     adr_cp varchar(5) null,
     adr_rue varchar(255) null,
     adr_etage int null,
     id_categorie_produit int not null
  )
go

create table COURANT_ARTISTIQUE
  (
     id int identity (1, 1) not null primary key,
     libelle varchar(32) null,
     "description" text null
  )
go

create table AGENCE
  (
     id int identity (1, 1) not null primary key,
     nom varchar(32) null,
     "type" varchar(255) null,
     adr_ville varchar(32) null,
     adr_cp varchar(5) null,
     adr_rue varchar(255) null,
     telephone varchar(10) null,
     email varchar(128) null,
     site_web varchar(255) null
  )
go

create table PERSONNE
  (
     id int identity (1, 1) not null primary key,
     prenom varchar(32) null,
     nom varchar(32) null,
     date_naissance date null,
     telephone varchar(10) null,
     email varchar(128) null
  )
go

create table EMPLOYE
  (
     id_personne int not null primary key,
     "login" varchar(32) null,
     mdp varchar(32) null,
     service varchar(255) null
  )
go

create table VIP
  (
     id_personne int not null primary key,
     adr_ville varchar(32) null,
     adr_cp varchar(5) null,
     adr_rue varchar(255) null,
     id_type_vip int not null
  )
go

create table ARTISTE
  (
     id_personne int not null primary key,
     pseudo varchar(32) null,
     site_web varchar(255) null,
     id_courant_artistique int not null
  )
go

create table PUBLIC_CAMPAGNE
  (
     id_campagne int not null,
     id_public int not null,
	 constraint PK_PUBLIC_CAMPAGNE primary key (id_campagne,id_public)
  )
go

create table VIP_EVENEMENT
  (
     id_vip int not null,
     id_evenement int not null,
     date date null,
	 constraint PK_VIP_EVENEMENT primary key (id_vip,id_evenement)
  )
go

create table ACTION_PAYS_ANNEE
  (
     annee varchar(32) not null,
     id_pays int not null,
     id_action int not null,
	 constraint PK_ACTION_PAYS_ANNEE primary key (annee,id_pays,id_action)
  )
go

create table TYPE_CONTROLE_ENTREPRISE
  (
     id_type_controle int not null,
     id_entreprise int not null,
	 constraint PK_TYPE_CONTROLE_ENTREPRISE primary key (id_type_controle,id_entreprise)
  )
go

create table ARTISTE_EVENEMENT
  (
     id_artiste int not null,
     id_evenement int not null,
     cachet money null,
	 constraint PK_ARTISTE_EVENEMENT primary key (id_artiste,id_evenement)
  )
go

create table AGENCE_CAMPAGNE
  (
     id_campagne int not null,
     id_agence int not null,
	 constraint PK_AGENCE_CAMPAGNE primary key (id_campagne,id_agence)
  )
go

create table TYPE_CONTROLE_ZONE_STOCKAGE
  (
     id_zone_stockage int not null,
     id_type_controle int not null,
     commentaire varchar(255) null,
	 constraint PK_TYPE_CONTROLE_ZONE_STOCKAGE primary key (id_zone_stockage,id_type_controle)
  )
go

alter table ASSOCIATION add constraint FK_ASSOCIATION_PAYS foreign key (id_pays) references PAYS (id)
go

alter table ASSOCIATION add constraint FK_ASSOCIATION_PERSONNE foreign key (id_personne) references PERSONNE (id)
go

alter table CONTROLE add constraint FK_CONTROLE_ENTREPRISE foreign key (id_entreprise) references ENTREPRISE (id)
go

alter table CONTROLE add constraint FK_CONTROLE_TYPE_CONTROLE foreign key (id_type) references TYPE_CONTROLE (id)
go

alter table CONTROLE add constraint FK_CONTROLE_ZONE_STOCKAGE foreign key (id_zone_stockage) references ZONE_STOCKAGE (id)
go

alter table ARTISTE add constraint FK_ARTISTE_COURANT_ARTISTIQUE foreign key (id_courant_artistique) references COURANT_ARTISTIQUE (id)
go

alter table ARTISTE add constraint FK_ARTISTE_PERSONNE foreign key (id_personne) references PERSONNE (id)
go

alter table CAMPAGNE add constraint FK_CAMPAGNE_EMPLOYE foreign key (id_employe) references EMPLOYE (id_personne)
go

alter table EVENEMENT add constraint FK_EVENEMENT_CAMPAGNE foreign key (id_campagne) references CAMPAGNE (id)
go

alter table CONTRAT add constraint FK_CONTRAT_ASSOCIATION foreign key (id_association) references ASSOCIATION (id)
go

alter table CONTRAT add constraint FK_CONTRAT_ACTION foreign key (id_action) references "ACTION" (id)
go

alter table ZONE_STOCKAGE add constraint FK_ZONE_STOCKAGE_CATEGORIE_PRODUIT foreign key (id_categorie_produit) references CATEGORIE_PRODUIT (id)
go

alter table VIP add constraint FK_VIP_TYPE_VIP foreign key (id_type_vip) references TYPE_VIP (id)
go

alter table VIP add constraint FK_VIP_PERSONNE foreign key (id_personne) references PERSONNE (id)
go

alter table EMPLOYE add constraint FK_EMPLOYE_PERSONNE foreign key (id_personne) references PERSONNE (id)
go

alter table PUBLIC_CAMPAGNE add constraint FK_PUBLIC_CAMPAGNE_PUBLIC foreign key (id_public) references "PUBLIC" (id)
go

alter table PUBLIC_CAMPAGNE add constraint FK_PUBLIC_CAMPAGNE_CAMPAGNE foreign key (id_campagne) references CAMPAGNE (id)
go

alter table VIP_EVENEMENT add constraint FK_VIP_EVENEMENT_VIP foreign key (id_vip) references VIP (id_personne)
go

alter table VIP_EVENEMENT add constraint FK_VIP_EVENEMENT_EVENEMENT foreign key (id_evenement) references EVENEMENT (id)
go

alter table ACTION_PAYS_ANNEE add constraint FK_ACTION_PAYS_ANNEE_ANNEE foreign key (annee) references ANNEE (annee)
go

alter table ACTION_PAYS_ANNEE add constraint FK_ACTION_PAYS_ANNEE_PAYS foreign key (id_pays) references PAYS (id)
go

alter table ACTION_PAYS_ANNEE add constraint FK_ACTION_PAYS_ANNEE_ACTION foreign key (id_action) references "ACTION" (id)
go

alter table TYPE_CONTROLE_ENTREPRISE add constraint FK_TYPE_CONTROLE_ENTREPRISE_ENTREPRISE foreign key (id_entreprise) references ENTREPRISE (id)
go

alter table TYPE_CONTROLE_ENTREPRISE add constraint FK_TYPE_CONTROLE_ENTREPRISE_TYPE_CONTROLE foreign key (id_type_controle) references TYPE_CONTROLE (id)
go

alter table ARTISTE_EVENEMENT add constraint FK_ARTISTE_EVENEMENT_ARTISTE foreign key (id_artiste) references ARTISTE (id_personne)
go

alter table ARTISTE_EVENEMENT add constraint FK_ARTISTE_EVENEMENT_EVENEMENT foreign key (id_evenement) references EVENEMENT (id)
go

alter table AGENCE_CAMPAGNE add constraint FK_AGENCE_CAMPAGNE_AGENCE foreign key (id_agence) references AGENCE (id)
go

alter table AGENCE_CAMPAGNE add constraint FK_AGENCE_CAMPAGNE_CAMPAGNE foreign key (id_campagne) references CAMPAGNE (id)
go

alter table TYPE_CONTROLE_ZONE_STOCKAGE add constraint FK_TYPE_CONTROLE_ZONE_STOCKAGE_ZONE_STOCKAGE foreign key (id_zone_stockage) references ZONE_STOCKAGE (id)
go

alter table TYPE_CONTROLE_ZONE_STOCKAGE add constraint FK_TYPE_CONTROLE_ZONE_STOCKAGE_TYPE_CONTROLE foreign key (id_type_controle) references TYPE_CONTROLE (id)
go

INSERT INTO PERSONNE(prenom,nom,date_naissance,telephone,email) 
VALUES("Mathieu","Renault","1976-10-15","0673512279","Nunc.sed@infelisNulla.co.uk"),
("Solene","Le goff","1978-09-04","0653284186","nonummy@fermentumconvallisligula.edu"),
("Lena","Remy","1968-11-23","0620760471","turpis.egestas.Aliquam@iaculisaliquetdiam.net"),
("Océane","Lefebre","1988-04-28","0646631377","penatibus@euismodin.edu"),
("Julia","Pons","1978-06-13","0633681142","ipsum@egetlacus.net"),
("Jade","Collin","1970-09-09","0636641859","molestie.in.tempus@malesuadavelvenenatis.ca"),
("Ethan","Noel","1968-11-15","0600122449","malesuada.fames.ac@sitamet.net"),
("Louise","Arnaud","1991-07-29","0627724338","urna.nec@non.ca"),
("Romane","Renault","1972-09-12","0681909140","sem.vitae.aliquam@Proin.co.uk"),
("Malo","Charpentier","1994-10-30","0624975419","nunc@tellusnon.co.uk"),
("Timothée","Jacob","1986-01-18","0645889849","elit.erat@est.ca"),
("Cédric","Vidal","1989-12-28","0693985550","enim.Nunc.ut@pedemalesuadavel.com"),
("Capucine","Carpentier","1991-10-22","0677979389","rutrum.Fusce@malesuada.ca"),
("Julien","Charles","1991-04-05","0658115062","erat@Suspendisse.ca"),
("Félix","Marechal","1968-03-13","0619379581","tellus.non.magna@miac.net"),
("Adrien","Laine","1989-06-09","0698931802","ut.cursus@adipiscing.net"),
("Bienvenue","Dufour","1969-10-21","0622786783","massa@lacusvestibulum.ca"),
("Yasmine","Barbier","1986-03-20","0614206567","non.arcu.Vivamus@at.net"),
("Mathilde","Daniel","1991-11-25","0605652621","velit.in.aliquet@dictumplacerataugue.ca"),
("Malik","Sanchez","1980-11-27","0626488197","parturient.montes.nascetur@eratvolutpat.com"),
("Anna","Nicolas","1972-08-27","0652005919","risus.Donec@velmauris.org"),
("Margot","Marchal","1977-11-20","0601585706","Etiam.imperdiet@velsapien.co.uk"),
("Marine","Menard","1966-03-27","0649657774","Morbi.sit.amet@congueelit.co.uk"),
("Corentin","Roy","1990-05-22","0676866510","Praesent.luctus@mattisornarelectus.net"),
("Léo","Weber","1965-05-29","0612096415","Sed@nequepellentesquemassa.org"),
("Evan","Lambert","1991-07-27","0633613256","natoque@NullaaliquetProin.org"),
("Anaël","Cordier","1988-04-12","0651895580","mollis.nec.cursus@etlibero.edu"),
("Thibault","Vasseur","1970-11-14","0604629625","velit.Aliquam.nisl@egestasurnajusto.org"),
("Adam","Blanc","1981-10-19","0610072799","ipsum@sodalesMaurisblandit.org"),
("Louna","Martinez","1981-05-14","0670068595","adipiscing@eutemporerat.net"),
("Quentin","Jacob","1992-11-24","0672171628","accumsan.interdum.libero@blanditmattisCras.ca"),
("Pierre","Humbert","1973-09-17","0683825201","rhoncus.id@nec.edu"),
("Yasmine","Collet","1985-01-23","0639466616","aliquet.odio@Cras.edu"),
("Océane","Remy","1965-08-29","0609063602","aliquet@eleifendvitae.org"),
("Yohan","Brunet","1982-03-02","0679976151","Cum.sociis.natoque@adipiscingnonluctus.edu"),
("Noémie","Clement","1965-07-05","0637807636","Mauris.blandit@Integertincidunt.com"),
("Elsa","Jean","1986-07-31","0635908972","imperdiet.nec.leo@nislMaecenasmalesuada.ca"),
("Guillaume","Gautier","1991-03-13","0624293137","Phasellus.convallis@aliquetPhasellusfermentum.co.uk"),
("Dylan","Evrard","1993-02-17","0689385609","lorem.Donec@imperdietdictum.net"),
("Tristan","Marty","1984-02-13","0670896995","convallis.in@luctuset.net"),
("Léa","Laine","1980-07-21","0650868001","at@actellus.com"),
("Chaïma","Bertrand","1986-03-12","0690269693","lacinia@ridiculusmus.com"),
("Louis","Gillet","1994-06-22","0672746756","purus@dolor.net"),
("Candice","Gerard","1991-06-05","0635542565","convallis.ante@enimnec.co.uk"),
("Margaux","Henry","1976-05-12","0641779267","nec@Fusce.org"),
("Émile","Berger","1987-05-16","0676680053","eu.augue@inconsectetuer.org"),
("Inès","Menard","1967-08-23","0659762466","vitae@ultricesposuerecubilia.com"),
("Arthur","Lambert","1978-01-01","0644871073","Cum@ultricesVivamusrhoncus.com"),
("Bruno","Garcia","1982-12-24","0686885199","lobortis@famesac.edu"),
("Lamia","Gerard","1978-09-05","0612431149","placerat.orci.lacus@aarcu.co.uk"),
("Catherine","Brun","1969-07-23","0614166053","eget@scelerisque.org"),
("Maïlé","Guerin","1972-12-05","0672284931","quam.quis@uterat.com"),
("Romain","Garnier","1984-12-19","0691268566","Integer@sociisnatoque.com"),
("Ambre","Marchal","1987-04-28","0605379785","In@dictumeu.org"),
("Célia","Jean","1989-09-05","0618829760","ultricies.dignissim@Classaptent.org"),
("Quentin","Herve","1977-07-16","0684389073","fringilla.est.Mauris@tellussem.com"),
("Théo","Chevallier","1993-04-26","0676619810","eu@actellus.ca"),
("Clément","Collin","1976-12-13","0621899038","suscipit.est@magnanecquam.net"),
("Léo","Marchand","1974-01-20","0666328528","feugiat.Sed.nec@eratinconsectetuer.co.uk"),
("Gaspard","Poirier","1973-11-22","0678571447","congue@orciconsectetuereuismod.ca"),
("Louise","Leroy","1994-04-09","0607368706","erat.vitae@erat.net"),
("Adam","Dufour","1991-09-03","0661758592","et.ipsum.cursus@nunc.edu"),
("Solene","Marchand","1993-10-21","0638858940","orci@cursusNunc.edu"),
("Romane","Benoit","1966-02-22","0681469848","sit.amet.lorem@Curabitur.org"),
("Ethan","Blanchard","1976-10-15","0636641618","quis@nullavulputate.edu"),
("Gabriel","Charles","1987-11-06","0639621283","neque@malesuadamalesuadaInteger.edu"),
("Éloïse","Nicolas","1989-05-16","0614802999","nulla.Cras.eu@penatibus.ca"),
("Julien","Benoit","1965-01-12","0661386431","Nulla.tincidunt.neque@erat.co.uk"),
("Adrien","Klein","1989-10-29","0661187127","felis.ullamcorper@orciluctus.com"),
("Salomé","Francois","1977-03-26","0682646355","vitae@Nuncquis.ca"),
("Lou","Sanchez","1994-08-03","0611183539","pede.Cras.vulputate@anteipsumprimis.net"),
("Tristan","Poirier","1995-12-21","0605487161","rutrum@risus.co.uk"),
("Ambre","Leclercq","1986-09-16","0632678531","lorem.ipsum.sodales@infaucibus.net"),
("Alexia","Lebrun","1975-05-11","0612761873","Aliquam.nisl.Nulla@convallis.net"),
("Jordan","Rousseau","1988-01-23","0602218861","ipsum.leo@sedpede.edu"),
("Loane","Robin","1978-01-11","0698210731","sagittis.Duis.gravida@acrisus.com"),
("Antonin","Evrard","1982-07-03","0660942600","ipsum.dolor@justoProin.edu"),
("Manon","Pasquier","1977-08-01","0697855208","sed.pede@vulputatelacus.com"),
("Alexandra","Faure","1976-09-29","0641174307","nunc.ullamcorper@accumsanlaoreetipsum.org"),
("Maïlé","Bailly","1965-03-15","0644572261","egestas.urna@dui.net"),
("Victor","Laurent","1972-01-19","0642171200","ornare.sagittis.felis@lacus.ca"),
("Macéo","Le gall","1968-05-24","0668023803","non.lacinia.at@eulacusQuisque.edu"),
("Samuel","Faure","1986-06-18","0601758717","eros@blanditmattis.org"),
("Bruno","David","1976-03-24","0635860359","eu.tellus.eu@vitae.com"),
("Nicolas","Pasquier","1988-12-06","0673514046","diam@commodoat.co.uk"),
("Jordan","Pons","1983-08-17","0636629929","vitae.dolor.Donec@idmagnaet.net"),
("Jeanne","Richard","1979-03-14","0669807275","amet.diam.eu@magna.co.uk"),
("Kyllian","Roy","1992-04-15","0602667654","Nullam@ornare.edu"),
("Sara","Morel","1984-02-22","0656357541","sed@odioAliquamvulputate.edu"),
("Bienvenue","Perrot","1966-10-03","0666539890","nonummy@venenatisamagna.com"),
("Catherine","Vincent","1984-06-13","0623575159","Mauris.nulla.Integer@risusaultricies.com"),
("Amélie","Renault","1967-11-23","0642666601","Donec@adipiscing.co.uk"),
("Jeanne","Durand","1985-07-04","0645029871","ipsum@parturientmontes.ca"),
("Renaud","Laurent","1979-04-24","0652692317","at@pedemalesuadavel.net"),
("Jordan","Blanchard","1990-11-22","0633703833","sed@scelerisque.edu"),
("Alexandra","Andre","1990-05-14","0673855799","erat@tempor.org"),
("Corentin","Gerard","1984-03-25","0686579285","dignissim.Maecenas@ullamcorper.ca"),
("Françoise","Deschamps","1977-08-28","0655831071","Sed.diam@Nullamvitaediam.ca"),
("Léon","Lucas","1979-10-26","0665623859","fames.ac.turpis@Phasellus.edu"),
("Dorian","Marie","1990-06-06","0623395395","arcu.Curabitur@lorem.ca")
go

INSERT INTO EMPLOYE(id_personne,login,mdp,service) 
VALUES(1,"Mathieu.Renault","1976apfy","communication"),
(2,"Solene.Legoff","1978amcq","partenariat"),
(3,"Lena.Remy","1968pmdr","financier"),
(4,"Oceane.Lefebre","1988azpt","securite"),
(5,"Julia.Pons","1978cget","production"),
(6,"Jade.Collin","1970qawx","communication"),
(7,"Ethan.Noel","1968mlpo","partenariat"),
(8,"Louise.Arnaud","1991treu","financier"),
(9,"Romane.Renault","1972mqpf","securite"),
(10,"Malo.Charpentier","1994cxua","production"),
(11,"Timothee.Jacob","1986ckqo","communication"),
(12,"Cedric.Vidal","1989mnhy","partenariat"),
(13,"Capucine.Carpentier","1991puxd","financier"),
(14,"Julien.Charles","1991eicr","securite"),
(15,"Felix.Marechal","1968mlre","production"),
(16,"Adrien.Laine","1989vgao","communication"),
(17,"Bienvenue.Dufour","1969mdfr","partenariat"),
(18,"Yasmine.Barbier","1986ojtr","financier"),
(19,"Mathilde.Daniel","1991mqze","securite"),
(20,"Malik.Sanchez","1980ruvg","production"),
(21,"Anna.Nicolas","1972xkaz","communication"),
(22,"Margot.Marchal","1977mloa","partenariat"),
(23,"Marine.Menard","1966cjet","financier"),
(24,"Corentin.Roy","1990mqdr","securite"),
(25,"Leo.Weber","1965ucjs","production")
go

INSERT INTO VIP(id_personne,adr_ville,adr_cp,adr_rue,id_type_vip) 
VALUES(26,"Huntsville","35772","2579 Lobortis. Rd."),
(27,"Macul","60742","2878 Eros St."),
(28,"Taber","42556","517-8303 Tortor, Ave"),
(29,"Tourinnes-la-Grosse","75519","P.O. Box 510, 695 A Av."),
(30,"Itapipoca","73462","774-9209 Orci. Avenue"),
(31,"Certaldo","09001","P.O. Box 285, 274 Dolor Avenue"),
(32,"Gjoa Haven","04511","265-5263 Euismod Av."),
(33,"Spresiano","18935","2347 Massa. Rd."),
(34,"Zwettl-Niederösterreich","46051","P.O. Box 630, 5080 Amet St."),
(35,"Esslingen","19133","Ap 941-7828 Odio. Avenue"),
(36,"Sint-Kruis","33251","6795 Facilisis Avenue"),
(37,"Embourg","21112","P.O. Box 718, 9939 Et Rd."),
(38,"Sassocorvaro","93499","5495 Auctor Road"),
(39,"Merchtem","96145","268-9649 Lorem Street"),
(40,"Wood Buffalo","07393","P.O. Box 607, 1115 Risus St."),
(41,"Yellowknife","89510","8459 Quam. Rd."),
(42,"Arras","57234","737-9089 Nec Ave"),
(43,"Jauchelette","68850","163-2768 Porttitor Rd."),
(44,"Rocca d""Arce","21912","958-495 Vitae Rd."),
(45,"Zonhoven","16629","903-7336 Feugiat. St."),
(46,"Cádiz","63596","4367 Amet Ave"),
(47,"Parrano","33012","P.O. Box 945, 3532 Ornare Street"),
(48,"Petorca","73714","Ap 763-4888 Orci. Avenue"),
(49,"Terneuzen","94881","Ap 858-2068 Libero St."),
(50,"Molino dei Torti","94129","8221 Lorem Road")
go

INSERT INTO ARTISTE(id_personne,pseudo,site_web,id_courant_artistique) 
VALUES(51,"Stacy","www.Stacy.fr",4),
(52,"Mollie","www.Mollie.fr",3),
(53,"Alisa","www.Alisa.fr",3),
(54,"Coby","www.Coby.fr",2),
(55,"Burke","www.Burke.fr",3),
(56,"Isabelle","www.Isabelle.fr",2),
(57,"Finn","www.Finn.fr",4),
(58,"Germaine","www.Germaine.fr",3),
(59,"Illiana","www.Illiana.fr",5),
(60,"Gavin","www.Gavin.fr",2),
(61,"Gabriel","www.Gabriel.fr",5),
(62,"Gregory","www.Gregory.fr",1),
(63,"Nero","www.Nero.fr",2),
(64,"Walker","www.Walker.fr",5),
(65,"Jackson","www.Jackson.fr",5),
(66,"Brenna","www.Brenna.fr",4),
(67,"Rhoda","www.Rhoda.fr",6),
(68,"Jerry","www.Jerry.fr",2),
(69,"Christine","www.Christine.fr",2),
(70,"Perry","www.Perry.fr",5),
(71,"Lunea","www.Lunea.fr",4),
(72,"Wynne","www.Wynne.fr",6),
(73,"Gretchen","www.Gretchen.fr",1),
(74,"Emily","www.Emily.fr",2),
(75,"Lacota","www.Lacota.fr",3)
go

INSERT INTO PAYS(nom) 
VALUES("Afghanistan"),
("Albania"),
("Algeria"),
("American Samoa"),
("Andorra"),
("Angola"),
("Anguilla"),
("Antarctica"),
("Antigua and Barbuda"),
("Argentina"),
("Armenia"),
("Aruba"),
("Australia"),
("Austria"),
("Azerbaijan"),
("Bahamas"),
("Bahrain"),
("Bangladesh"),
("Barbados"),
("Belarus"),
("Belgium"),
("Belize"),
("Benin"),
("Bermuda"),
("Bhutan"),
("Bolivia"),
("Bosnia and Herzegovina"),
("Botswana"),
("Bouvet Island"),
("Brazil"),
("British Indian Ocean Territory"),
("Brunei Darussalam"),
("Bulgaria"),
("Burkina Faso"),
("Burundi"),
("Cambodia"),
("Cameroon"),
("Canada"),
("Cape Verde"),
("Cayman Islands"),
("Central African Republic"),
("Chad"),
("Chile"),
("China"),
("Christmas Island"),
("Cocos (Keeling) Islands"),
("Colombia"),
("Comoros"),
("Democratic Republic of Congo"),
("Republic of Congo"),
("Cook Islands"),
("Costa Rica"),
("Croatia (Hrvatska)"),
("Cuba"),
("Cyprus"),
("Czech Republic"),
("Denmark"),
("Djibouti"),
("Dominica"),
("Dominican Republic"),
("East Timor"),
("Ecuador"),
("Egypt"),
("El Salvador"),
("Equatorial Guinea"),
("Eritrea"),
("Estonia"),
("Ethiopia"),
("Falkland Islands"),
("Faroe Islands"),
("Fiji"),
("Finland"),
("France"),
("France Metropolitan"),
("French Guiana"),
("French Polynesia"),
("French Southern Territories"),
("Gabon"),
("Gambia"),
("Georgia"),
("Germany"),
("Ghana"),
("Gibraltar"),
("Guernsey"),
("Greece"),
("Greenland"),
("Grenada"),
("Guadeloupe"),
("Guam"),
("Guatemala"),
("Guinea"),
("Guinea-Bissau"),
("Guyana"),
("Haiti"),
("Heard and Mc Donald Islands"),
("Honduras"),
("Hong Kong"),
("Hungary"),
("Iceland"),
("India"),
("Isle of Man"),
("Indonesia"),
("Islamic Republic of Iran"),
("Iraq"),
("Ireland"),
("Israel"),
("Italy"),
("Ivory Coast"),
("Jersey"),
("Jamaica"),
("Japan"),
("Jordan"),
("Kazakhstan"),
("Kenya"),
("Kiribati"),
("Democratic Republic of Korea"),
("Korea, Republic of"),
("Kosovo"),
("Kuwait"),
("Kyrgyzstan"),
("Lao Peoples Democratic Republic"),
("Latvia"),
("Lebanon"),
("Lesotho"),
("Liberia"),
("Libyan Arab Jamahiriya"),
("Liechtenstein"),
("Lithuania"),
("Luxembourg"),
("Macau"),
("North Macedonia"),
("Madagascar"),
("Malawi"),
("Malaysia"),
("Maldives"),
("Mali"),
("Malta"),
("Marshall Islands"),
("Martinique"),
("Mauritania"),
("Mauritius"),
("Mayotte"),
("Mexico"),
("Federated States of Micronesia"),
("Moldova, Republic of"),
("Monaco"),
("Mongolia"),
("Montenegro"),
("Montserrat"),
("Morocco"),
("Mozambique"),
("Myanmar"),
("Namibia"),
("Nauru"),
("Nepal"),
("Netherlands"),
("Netherlands Antilles"),
("New Caledonia"),
("New Zealand"),
("Nicaragua"),
("Niger"),
("Nigeria"),
("Niue"),
("Norfolk Island"),
("Northern Mariana Islands"),
("Norway"),
("Oman"),
("Pakistan"),
("Palau"),
("Palestine"),
("Panama"),
("Papua New Guinea"),
("Paraguay"),
("Peru"),
("Philippines"),
("Pitcairn"),
("Poland"),
("Portugal"),
("Puerto Rico"),
("Qatar"),
("Reunion"),
("Romania"),
("Russian Federation"),
("Rwanda"),
("Saint Kitts and Nevis"),
("Saint Lucia"),
("Saint Vincent the Grenadines"),
("Samoa"),
("San Marino"),
("Sao Tome and Principe"),
("Saudi Arabia"),
("Senegal"),
("Serbia"),
("Seychelles"),
("Sierra Leone"),
("Singapore"),
("Slovakia"),
("Slovenia"),
("Solomon Islands"),
("Somalia"),
("South Africa"),
("South Georgia Islands"),
("South Sudan"),
("Spain"),
("Sri Lanka"),
("St. Helena"),
("St. Pierre and Miquelon"),
("Sudan"),
("Suriname"),
("Svalbard and Jan Mayen Islands"),
("Swaziland"),
("Sweden"),
("Switzerland"),
("Syrian Arab Republic"),
("Taiwan"),
("Tajikistan"),
("Tanzania, United Republic of"),
("Thailand"),
("Togo"),
("Tokelau"),
("Tonga"),
("Trinidad and Tobago"),
("Tunisia"),
("Turkey"),
("Turkmenistan"),
("Turks and Caicos Islands"),
("Tuvalu"),
("Uganda"),
("Ukraine"),
("United Arab Emirates"),
("United Kingdom"),
("United States"),
("United States minor outlying islands"),
("Uruguay"),
("Uzbekistan"),
("Vanuatu"),
("Vatican City State"),
("Venezuela"),
("Vietnam"),
("Virgin Islands (British)"),
("Virgin Islands (U.S.)"),
("Wallis and Futuna Islands"),
("Western Sahara"),
("Yemen"),
("Zambia"),
("Zimbabwe")
go

INSERT INTO ENTREPRISE(nom,adr_ville,adr_cp,adr_rue,email) 
VALUES("Auctor Ullamcorper Institute","Mobile","71871","131-591 Augue St.","imperdiet.nec@ipsumdolor.ca"),
("Ultrices Mauris Ipsum Foundation","Alajuelita","73502","Ap #812-2760 Vitae Av.","eu.elit@diamSed.net"),
("Ligula Eu Ltd","Düsseldorf","93376","6250 Purus Road","ac.turpis.egestas@Curabiturdictum.org"),
("Ac Orci Associates","Feltre","69013","3415 Ut Rd.","Aliquam@sit.ca"),
("Ligula Eu Consulting","Mérignac","89486","1982 Luctus, Av.","luctus.ipsum.leo@vitaeodio.co.uk"),
("Pellentesque Sed Dictum Associates","Champdani","09976","354-9917 Accumsan St.","ultrices@co.uk"),
("Duis Elementum Corp.","Rennes","01281","671-6665 Interdum Avenue","quis.tristique@velitPellentesque.net"),
("Nec Ltd","Rollegem","13765","Ap #500-5010 Sem Street","Aliquam.vulputate@convallis.org"),
("Lacus Pede Sagittis LLC","Linton","09132","Ap #236-9564 Amet Rd.","dolor.vitae@nuncest.edu"),
("Donec Sollicitudin Institute","Veere","88217","1535 Nec Road","eu@ut.org"),
("Phasellus Consulting","San Clemente","30918","P.O. Box 868, 7588 A St.","nunc.id.enim@mollisnoncursus.ca"),
("Eu Elit Association","Landenne","16463","926-6504 Ac Road","Cras@volutpat.net"),
("Pellentesque Ultricies Inc.","Itter","64028","P.O. Box 166, 3492 Laoreet Rd.","risus@eratnonummy.com"),
("Molestie Tortor Nibh PC","Bochum","94528","P.O. Box 652, 4069 Facilisi. Avenue","gravida@primis.ca"),
("Quam PC","Quinta Normal","43026","Ap #892-330 Aenean St.","Lorem@accumsan.org"),
("Eu Tellus Consulting","Mandi Burewala","44672","P.O. Box 911, 3537 Massa. St.","magna@vitaesemper.ca"),
("Phasellus Elit Pede Corp.","Baie-Saint-Paul","80797","P.O. Box 422, 6024 Risus Av.","egestas@massarutrum.com"),
("Morbi Neque Inc.","LimerlŽ","29123","9899 Nibh Rd.","facilisis.magna@tusurna.edu"),
("Ac Incorporated","Funtua","48330","Ap #128-3531 Augue Street","lectus@temporestac.net"),
("Nec Mauris Associates","Verzegnis","05611","P.O. Box 441, 9945 Vestibulum St.","interdum.Nunc@ligula.co.uk"),
"Mauris Elit Dictum LLP","Buzet","54698","Ap #282-3598 Sed Av.","dolor.dolor.tempus@ipsumSuspendisse.net"),
("Euismod Et Incorporated","Carapicuíba","83629","112-7046 Dui. St.","malesuada.vel.venenatis@lacinia.co.uk"),
("Dapibus Industries","Corby","27478","220-1429 Ultrices Road","libero@sociis.ca"),
("Tempor Institute","Stratford-upon-Avon","67162","Ap #121-4540 Eu Avenue","consectetuer.ipsum@tellus.co.uk"),
("Purus Gravida Industries","South Portland","34267","Ap #720-8047 Faucibus Ave","molestie@Nunclaoreet.co.uk")
go

INSERT INTO ANNEE(annee) 
VALUES("1994"),
("1995"),
("1996"),
("1997"),
("1998"),
("1999"),
("2000"),
("2001"),
("2002"),
("2003"),
("2004"),
("2005"),
("2006"),
("2007"),
("2008"),
("2009"),
("2010"),
("2011"),
("2012"),
("2013"),
("2014"),
("2015"),
("2016"),
("2017"),
("2018")
go

INSERT INTO ZONE_STOCKAGE(libelle,adr_ville,adr_cp,adr_rue,adr_etage,id_categorie_produit) 
VALUES("UikhovenE1CAT1","Uikhoven","40119","Ap #243-4994 Venenatis St.",1,1),
("ThiaumontE2CAT14","Thiaumont","36426","4713 At Av.",2,14),
("InverbervieE2CAT12","Inverbervie","72257","P.O. Box 328, 4156 Non St.",2,12),
("Mörfelden-WalldorfE5CAT6","Mörfelden-Walldorf","07824","Ap #361-1648 Ac, Rd.",5,6),
("KlabbeekE2CAT10","Klabbeek","39777","Ap #620-4940 Metus St.",2,10),
("PremenoE5CAT8","Premeno","99262","996-3439 Mus. Street",5,8),
("LintE7CAT3","Lint","81280","P.O. Box 107, 4060 Neque. Av.",7,3),
("KakisaE1CAT4","Kakisa","91709","2125 Diam Rd.",1,4),
("WerderE4CAT11","Werder","95013","P.O. Box 130, 9965 Nunc St.",4,11),
("ChesterfieldE3CAT8","Chesterfield","78012","Ap #251-729 Aptent Av.",3,8),
("Hudson BayE3CAT9","Hudson Bay","95257","Ap #838-2000 Imperdiet Avenue",3,9),
("KotliE7CAT8","Kotli","84322","8761 A Road",7,8),
("GeleenE4CAT9","Geleen","49111","Ap #693-7988 Magna Avenue",4,9),
("AthensE6CAT14","Athens","79747","537-4511 Ligula Street",6,14),
("GattaticoE2CAT9","Gattatico","68097","266-5793 Eget St.",2,9),
("AlianoE5CAT12","Aliano","68977","P.O. Box 626, 1938 Ligula Street",5,12),
("JambesE7CAT3","Jambes","02262","7926 Lorem Street",7,3),
("RochesterE4CAT7","Rochester","11255","Ap #464-280 Tortor Avenue",4,7),
("SchwechatE5CAT3","Schwechat","22829","6396 Dictum Rd.",5,3),
("TäbyE6CAT4","Täby","56292","488-3755 Aliquet Ave",6,4),
("Forchies-la-MarcheE3CAT3","Forchies-la-Marche","08520","P.O. Box 665, 5187 Urna St.",3,3),
("SuncheonE7CAT5","Suncheon","30163","6715 Libero Road",7,5),
("StavorenE2CAT4","Stavoren","42470","9656 Dolor Rd.",2,4),
("MontjovetE5CAT14","Montjovet","36165","Ap #327-9499 Auctor St.",5,14),
("Vico nel LazioE2CAT3","Vico nel Lazio","59058","P.O. Box 163, 4089 Ipsum Avenue",2,3)
go

INSERT INTO AGENCE(nom,type,adr_ville, adr_cp, adr_rue,telephone,email, site_web)
VALUES('Riofluo','agence d’événement artistique','Bagnolet','93170','7 rue jules Ferry','0951028276','sophie.henry@riofluo.com','http://www.riofluo.com'),
('Novell’art','agence d’événement artistique','Paris','75017','6 rue Déodat de Severac','0686214715','stéphanie.novello@novellart.com','http://www.novellart.com'),
('LJ communication','agence de stratégie d’information','Paris','75008','16 rue de l\'arcade','0145038989','paul.pierrat@ljcom.net','http://www.ljcom.net'),
('Image & stratégie','agence de stratégie d’information','Paris','75017','30 rue Fortuny','0145896500','bruno.fuchs@image-strategie.com','http://www.image-strategie.com')
go



INSERT INTO COURANT_ARTISTIQUE(libelle,description)
VALUES("L'art brut","Il désigne les oeuvres faites par des personnes qui vivent à l'écart de la société, dans les hôpitaux psychiatriques. Utilisation de techniques et des matériaux variés : terre, ciment, colle, ailes de papillon, émail, chiffons…. Exemple de peintre : Dubuffet en 1945."),
("L'action painting","Cette attitude artistique privilégie l'acte physique de peindre. Les suggestions figuratives sont écartées. Les artistes réalisent ces oeuvres abstraites en peignant, égouttant ou projetant de la couleur sur la toile. Exemple : Pollock"),
("Op Art (Optical art)","Mouvement artistique né dans les années 1960 qui cherche à créer des effets d'optique en jouant sur le regard du spectateur. Il se caractérise par la superposition de lignes ou de trames, par un mouvement réel dans l'oeuvre, par les jeux de lumières , par les effets résultant de l'utilisation des couleurs (Vasarely, Soto)"),
("Bio art","Les bio-artistes (de « art » et « biologie ») travaillent sur l'être humain ou l'animal, sous l'angle de la modification des corps par un agent extérieur (ils travaillent sur le rapport de l'humain à l'inhumain). Ils privilégient les outils numériques et cinématographiques (Patricia Piccinini)"),
("Street art","Il regroupe toutes les formes d'art réalisées dans la rue, ou dans des endroits publics, et englobe diverses techniques telles que le graffiti, la réclame, le pochoir, la mosaïque, les stickers")
go

INSERT INTO PUBLIC(libelle)
VALUES("enfants"),
("adolescents,"),
("jeunes adultes"),
("tout public")
go

INSERT INTO CATEGORIE_PRODUIT(libelle)
VALUES("Médicaments classe I (aérosols)"),
("Médicaments classe II (solution buvable)"),
("Médicaments classe III (poudre)"),
("Médicaments classe IV (cachets)"),
("Vaccin classe I"),
("Vaccin classe II"),
("Vaccin classe III"),
("Gaz médical"),
("Composés sanguins"),
("Produit radiopharmaceutique"),
("Stupéfiants"),
("Poudre pour solution type A"),
("Poudre pour solution type B"),
("Poudre pour solution type C")
go

INSERT INTO TYPE_CONTROLE(libelle)
VALUES("poids"),
("humidité"),
("pression"),
("luminosité"),
("température"),
("propreté"),
("sécurité"),
("incendie")
go

INSERT INTO TYPE_VIP(libelle)
VALUES("journaliste"),
("médecin"),
("pharmacien"),
("ministre"),
("député")
go

INSERT INTO ASSOCIATION(nom,mission,id_pays,id_personne) 
VALUES ("Elementum Purus Accumsan Association","Aide au déplacement",49,76),
("Venenatis Consulting","Accompagnement scolaire",163,77),
("Ante Vivamus PC","Informatique",124,78),
("Orci Limited","Distribution",178,79),
("Id Sapien Cras Association","Défense des droits",19,80),
("Habitant Association","Alphabétisation",48,81),
("Felis Donec Tempor Association","Animation sportive",28,82),
("Est Association","Enseignement",120,83),
("Ut Nisi LLC","Visites en établissement",199,84),
("Est Mauris Ltd","Traduction",73,85),
("Elit Fermentum Risus PC","Aide aux démarches administratives",200,86),
("Tincidunt Aliquam Arcu Association","Visites en établissement",89,87),
("Donec Felis Orci Ltd","Commerce équitable",233,88),
("Risus Varius Association","Communication",131,89),
("Sem Molestie Association","Secourisme",8,90),
("Dui Fusce Association","Accompagnement social",204,91),
("Velit Cras Lorem Association","Visites en établissement",150,92),
("Cursus Integer Mollis Consulting","Alphabétisation",207,93),
("Nulla Association","Aide aux démarches administratives",184,94),
("Consectetuer Association","Alphabétisation",3,95),
("Placerat Augue PC","Informatique",40,96),
("Urna Justo Faucibus LLC","Gestion administrative",35,97),
("Laoreet Libero Association","Gestion financière",216,98),
("Suspendisse Non Association","Alphabétisation",123,99),
("Curabitur Consequat Lectus Association","Distribution",223,100)
go

INSERT INTO CONTROLE(date,resume_resultat,montant_ht,id_entreprise,id_type,id_zone_stockage) 
VALUES("2013-06-21","Correcte",769,24,3,19),
("2001-11-05","Mauvais",3209,21,8,3),
("2012-12-13","Mauvais",2722,10,7,12),
("2010-07-17","Parfait",757,9,5,23),
("2000-08-09","Parfait",4383,22,4,14),
("2012-11-15","Limite",1354,6,2,14),
("2003-04-16","Mauvais",1948,8,4,11),
("2015-04-15","Correcte",1605,14,2,12),
("2011-09-06","Correcte",3439,24,5,7),
("2014-09-25","Parfait",2222,7,3,9),
("2000-11-24","Limite",3558,12,5,12),
("2018-02-01","Limite",3784,24,1,1),
("2013-09-27","Limite",3193,19,2,4),
("2001-04-02","Limite",4057,25,4,24),
("2005-11-11","Correcte",2368,22,3,17),
("2008-11-08","Correcte",2304,22,1,22),
("2005-03-26","Correcte",1073,18,8,10),
("2002-05-12","Correcte",3347,14,3,12),
("2004-09-17","Correcte",4323,1,8,4),
("2007-02-17","Limite",3969,2,4,13),
("2013-07-23","Parfait",4219,17,1,22),
("2003-01-02","Correcte",2930,10,2,15),
("2004-03-09","Mauvais",3185,12,1,2),
("2001-09-21","Limite",1406,19,7,22),
("2018-01-11","Parfait",3683,21,1,10),
("2008-02-16","Mauvais",2721,7,1,2),
("2010-04-21","Mauvais",886,9,6,16),
("2002-02-20","Parfait",3788,16,7,11),
("2007-02-14","Mauvais",3027,9,6,19),
("2000-09-19","Mauvais",3896,22,2,14),
("2015-09-23","Correcte",4312,19,3,14),
("2013-05-26","Correcte",4368,10,8,6),
("2007-12-09","Parfait",4534,19,8,21),
("2018-04-02","Limite",2405,11,1,20),
("2002-04-24","Correcte",1851,10,5,17),
("2018-01-29","Limite",4583,13,2,16),
("2009-06-27","Parfait",2817,7,7,9),
("2013-12-09","Limite",3137,3,7,2),
("2003-06-09","Mauvais",2031,23,6,15),
("2013-07-17","Mauvais",3209,9,2,21),
("2005-01-06","Limite",834,19,3,17),
("2010-04-05","Limite",1503,13,8,6),
("2011-07-01","Parfait",3869,13,8,11),
("2016-06-18","Parfait",1379,4,5,13),
("2000-03-21","Correcte",4451,13,6,5),
("2012-12-19","Correcte",2496,17,1,25),
("2012-04-08","Limite",676,16,4,5),
("2015-03-19","Mauvais",4090,10,7,10),
("2014-11-12","Correcte",4198,17,3,11),
("2003-06-24","Mauvais",2389,1,8,21)
go

INSERT INTO ACTION(libelle,description) 
VALUES("don de médicaments","récolte de médicaments non utilisé afin de les distribuer dans les domaines de situations d’urgence humanitaire"),
("don de vaccins","récolte de médicaments non utilisé afin de les distribuer dans les domaines de situations d’urgence humanitaire"),
("intervention humanitaire","conduite de projets à long terme dans les domaines de situations d’urgence humanitaire"),
("programmes de prévention","prévention dans les pays n'ayant pas un accès facile à la connaissance"),
("programmes de formation","formation dans les pays n'ayant pas un accès facile à la connaissance"),
("programmes de soutien éducatif","soutien éducatif dans les pays n'ayant pas un accès facile à la connaissance"),
("programmes de soutien social","soutien social pour les enfants et les familles dans les domaines de situations d’urgence humanitaire"),
("amélioration de l’accès aux soins","aide à l'amélioration de l’accès aux soins dans les domaines de situations d’urgence humanitaire"),
("lutte contre l’exclusion","lutte contre l’exclusion pour les enfants dans les domaines de situations d’urgence humanitaire")
go

INSERT INTO EVENEMENT(theme,date_debut,date_fin,id_campagne)
VALUES("réalisation d'une oeuvre sur le sol","2020-01-10","2020-01-12",1),
("emballage d'un monument,","2018-10-15","2018-10-18",3),
("réalisation d'une sculture géante par plusieurs ado","2019-05-04","2019-05-06",2),
("réalisation d'une toile géante par plusieurs artistes","2016-12-02","2016-12-05",5),
("réalisation d'une peinture","2015-05-04","2015-05-06",6),
("réalisation d'une musique par des artistes locaux","2017-11-21","2017-11-23",4),
("compétition de foot avec des enfants","2014-07-13","2014-07-16",7),
("réalisation d'une fresque dans le gymnase","2012-02-27","2012-02-30",9),
("concours de chant avec des ados","2013-10-19","2013-10-22",8)
("réaliation d'une video pour une association","2009-03-14","2009-03-16",12)
("emballage d'un monument,","2013-06-11","2013-06-13",8),
("réalisation d'une sculture géante par plusieurs ado","2010-05-12","2010-05-14",11),
("réalisation d'une toile géante par plusieurs artistes","2011-01-03","2011-01-05",10),
("réalisation d'une peinture","2007-04-19","2007-04-21",14),
("réalisation d'une musique par des artistes locaux","2008-05-21","2008-05-23",13),
("compétition de foot avec des enfants","2006-07-01","2006-07-02",15),
("réalisation d'une fresque dans le gymnase","2019-02-11","2019-02-12",2),
("concours de chant avec des ados","2017-10-03","2017-10-05",4),
("réaliation d'une video pour une association","2015-03-14","2015-03-16",6)
("emballage d'un monument,","2016-07-05","2016-07-07",5),
("réalisation d'une sculture géante par plusieurs ado","2012-12-05","2012-12-07",9),
("réalisation d'une toile géante par plusieurs artistes","2008-03-15","2008-03-16",13),
("réalisation d'une peinture","2011-05-04","2011-05-06",10),
("réalisation d'une musique par des artistes locaux","2009-08-28","2009-08-30",12),
("réalisation d'une musique par des artistes locaux","2006-06-12","2006-06-14",15)
go

INSERT INTO TYPE_CONTROLE_ZONE_STOCKAGE(id_zone_stockage,id_type_controle,commentaire) 
VALUES (1,7,"sécurité: >=8/10tests"),
(1,4,"luminosité: <60lux"),
(1,6,"propreté: indice=1"),
(2,7,"sécurité: >=9/10tests"),
(3,1,"poids: <34g"),
(3,4,"luminosité: <40lux"),
(4,3,"pression: <1016hPa"),
(4,1,"poids: <17g"),
(4,8,"incendie: <4m2"),
(5,5,"température: <22°"),
(6,5,"température: <28°"),
(6,2,"humidité: <30%"),
(7,7,"sécurité: >=8/10tests"),
(8,4,"luminosité: <55lux"),
(8,5,"température: <22°"),
(8,7,"sécurité: >=9/10tests"),
(9,2,"humidité: <50%"),
(10,2,"humidité: <15%"),
(10,1,"poids: <8g"),
(10,4,"luminosité: <60lux"),
(11,5,"température: <20°"),
(12,8,"incendie: <3m2"),
(12,7,"sécurité: >=9/10tests"),
(13,5,"température: <18°"),
(13,5,"température: <20°"),
(13,6,"propreté: indice=2"),
(13,1,"poids: <54g"),
(13,2,"humidité: <45%"),
(14,5,"température: <26°"),
(15,2,"humidité: <30%"),
(15,5,"température: <22°"),
(15,6,"propreté: indice=1"),
(16,8,"incendie: <10m2"),
(17,8,"incendie: <8m2"),
(18,2,"humidité: <75%"),
(18,7,"sécurité: >=8/10tests"),
(19,4,"luminosité: <35lux"),
(20,3,"pression: <1015hPa"),
(20,8,"incendie: <4m2"),
(20,4,"luminosité: <50lux"),
(21,8,"incendie: <5m2"),
(22,7,"sécurité: >=9/10tests"),
(23,4,"luminosité: <55lux"),
(23,3,"pression: <1018hPa"),
(24,8,"incendie: <8m2"),
(24,6,"propreté: indice=1"),
(25,5,"température: <24°")
(25,6,"propreté: indice=2")
go

INSERT INTO EVENEMENT(theme,date_debut,date_fin,id_campagne)
VALUES("réalisation d'une oeuvre sur le sol","2020-01-10","2020-01-12",1),
("emballage d'un monument,","2018-10-15","2018-10-18",3),
("réalisation d'une sculture géante par plusieurs ado","2019-05-04","2019-05-06",2),
("réalisation d'une toile géante par plusieurs artistes","2016-12-02","2016-12-05",5),
("réalisation d'une peinture","2015-05-04","2015-05-06",6),
("réalisation d'une musique par des artistes locaux","2017-11-21","2017-11-23",4),
("compétition de foot avec des enfants","2014-07-13","2014-07-16",7),
("réalisation d'une fresque dans le gymnase","2012-02-27","2012-02-30",9),
("concours de chant avec des ados","2013-10-19","2013-10-22",8)
("réaliation d'une video pour une association","2009-03-14","2009-03-16",12)
("emballage d'un monument,","2013-06-11","2013-06-13",8),
("réalisation d'une sculture géante par plusieurs ado","2010-05-12","2010-05-14",11),
("réalisation d'une toile géante par plusieurs artistes","2011-01-03","2011-01-05",10),
("réalisation d'une peinture","2007-04-19","2007-04-21",14),
("réalisation d'une musique par des artistes locaux","2008-05-21","2008-05-23",13),
("compétition de foot avec des enfants","2006-07-01","2006-07-02",15),
("réalisation d'une fresque dans le gymnase","2019-02-11","2019-02-12",2),
("concours de chant avec des ados","2017-10-03","2017-10-05",4),
("réaliation d'une video pour une association","2015-03-14","2015-03-16",6)
("emballage d'un monument,","2016-07-05","2016-07-07",5),
("réalisation d'une sculture géante par plusieurs ado","2012-12-05","2012-12-07",9),
("réalisation d'une toile géante par plusieurs artistes","2008-03-15","2008-03-16",13),
("réalisation d'une peinture","2011-19-05-04","2011-05-06",10),
("réalisation d'une musique par des artistes locaux","2009-08-28","2009-08-30",12),
("réalisation d'une musique par des artistes locaux","2006-06-12","2006-06-14",15)
go


INSERT INTO CAMPAGENE(intitule,objectif,date_debut,date_fin,id_employe)
VALUES("DAMI","Les dangers de l’achat de médicaments sur Internet","2020-01-01","2020-12-01",1),
("CACBY","Coalition contre les agressions envers les enfants et la jeunesse","2019-01-01","2019-12-01",3),
("AMFE","L'association maladies foie enfants","2018-01-01","2018-12-01",2),
("NYRM","New York Rescue Mission","2017-01-01","2017-12-01",5),
("WWF","Agence Grey Brasil","2016-01-01","2016-12-01",4),
("PCDT","Parceria Contra Drogas et l'agence Talent","2015-01-01","2015-12-01",7),
("CNIL","Commission Nationale de l'informatique et des libertés","2014-01-01","2014-12-01",8),
("Snapzheimer","La campagne Snapzheimer a été conçue pour sensibiliser les jeunes à la maladie d'Alzheimer","2013-01-01","2013-12-01",6),
("RSF","Reporters Sans Frontières","2012-01-01","2012-08-01",12),
("APB","Agence Publicis Brussels","2011-01-01","2011-12-01",10),
("Unicef Suède","Cette campagne lancée par l’Unicef réagit sur les comportements incohérents que l’on peut trouver sur les réseaux sociaux.","2010-01-01","2010-12-01",9),
("NYRM","New York Rescue Mission","2009-01-01","2009-12-01",11),
("Laservision","Fatigue ou manque de vigilance sont la cause de nombreux accidents sur les routes.","2008-01-01","2008-12-01",15),
("WWF","Agence Grey Brasil","2007-01-01","2007-12-01",13),
("CRC","Campagne contre le rechauffement climatique","2006-01-01","2006-12-01",14)
go

INSERT INTO CONTRAT(date,budget_previsionnel,montant_depense,id_association,id_action) 
VALUES ("2018-09-07",13524,12171.6,1,4),
("2017-01-09",8074,7266.6,2,6),
("2016-11-23",32937,36230.7,3,2),
("2015-10-06",14893,13403.7,4,7),
("2014-02-24",29463,32409.3,5,3),
("2013-03-01",24708,27178.8,6,3),
("2012-05-29",18861,20747.1,7,2),
("2011-02-26",12713,11441.7,8,4),
("2010-06-06",12739,11465.1,9,1),
("2009-11-14",12596,11336.4,10,1),
("2008-11-25",14208,12787.2,11,1),
("2007-12-26",34447,37891.7,12,8),
("2006-10-08",14772,13294.8,13,1),
("2005-02-01",16482,14833.8,14,5),
("2004-12-16",17597,15837.3,15,6),
("2003-08-30",22476,24723.6,16,5),
("2002-09-16",15455,13909.5,17,1),
("2001-09-24",32626,35888.6,18,6),
("2000-07-20",24999,27498.9,19,4),
("1999-12-01",14870,13383,20,4),
("1998-12-07",33634,36997.4,21,5),
("1997-10-14",15962,14365.8,22,9),
("1996-12-22",10285,9256.5,23,7),
("1995-12-31",24069,26475.9,24,2),
("1994-08-26",23666,26032.6,25,2),
("2017-06-18",14162,12745.8,26,9),
("2018-05-01",26477,29124.7,27,6),
("1999-03-30",25695,28264.5,28,2),
("2008-09-04",18287,16458.3,29,6),
("2007-10-11",10474,9426.6,30,5),
("1993-12-29",5872,5284.8,31,5),
("1995-07-16",30659,33724.9,32,2),
("2006-09-08",11689,10520.1,33,5),
("2001-03-22",20598,22657.8,34,2),
("1995-10-18",20263,22289.3,35,7)
go

INSERT INTO PUBLIC_CAMPAGNE(id_campagne,id_public) 
VALUES (1,4),
(2,1),
(2,2),
(3,1),
(4,1),
(4,2),
(4,3),
(5,3),
(6,3),
(7,4),
(8,3),
(9,1),
(9,2),
(9,3),
(10,3),
(11,2),
(11,3),
(12,1),
(13,1),
(13,2),
(14,4),
(15,2)
go

INSERT INTO VIP_EVENEMENT(id_vip,id_evenement,date) 
VALUES (26,25,"2006-06-02"),
(50,25,"2006-06-02"),
(27,3,"2019-04-25"),
(49,3,"2019-04-25"),
(28,4,"2016-11-02"),
(48,5,"2015-04-04"),
(29,6,"2017-11-11"),
(47,6,"2017-11-11"),
(30,6,"2017-11-11"),
(46,9,"2013-10-09"),
(31,9,"2013-10-09"),
(45,10,"2009-04-14"),
(32,11,"2013-05-11"),
(44,15,"2008-05-11"),
(33,17,"2019-02-01"),
(43,17,"2019-02-01"),
(34,17,"2019-02-01"),
(42,17,"2019-02-01"),
(35,18,"2017-11-03"),
(41,19,"2015-02-04"),
(36,19,"2015-02-04"),
(39,23,"2011-04-04"),
(37,23,"2011-04-04"),
(38,23,"2011-04-04"),
(38,24,"2009-08-18")
go

INSERT INTO ACTION_PAYS_ANNEE(annee,id_pays,id_action) 
VALUES ("1994",47,9),
("1995",159,6),
("1996",200,8),
("1997",201,5),
("1998",124,5),
("1999",49,6),
("2000",238,9),
("2001",238,7),
("2002",3,2),
("2003",145,5),
("2004",161,7),
("2005",102,9),
("2006",155,7),
("2007",222,5),
("2008",194,7),
("2009",237,8),
("2010",199,9),
("2011",5,8),
("2012",216,9),
("2013",189,3),
("2014",220,3),
("2015",153,9),
("2016",118,5),
("2017",109,5),
("2018",57,6)
go

INSERT INTO TYPE_CONTROLE_ENTREPRISE(id_type_controle,id_entreprise) 
VALUES (4,1),
(5,1),
(8,1),
(3,2),
(3,3),
(2,3),
(5,3),
(2,4),
(4,5),
(1,6),
(8,6),
(5,6),
(6,6),
(5,7),
(1,8),
(4,8),
(8,8),
(6,9),
(7,9),
(2,10),
(7,11),
(6,12),
(8,13),
(7,13),
(1,13),
(2,13),
(5,14),
(1,14),
(5,15),
(6,15),
(7,15),
(8,16),
(6,16),
(4,17),
(5,18),
(2,19),
(7,19),
(3,20),
(4,21),
(5,21),
(7,21),
(8,22),
(2,22),
(2,23),
(3,24),
(5,25),
(8,25)
go

INSERT INTO ARTISTE_EVENEMENT(id_artiste,id_evenement,cachet) 
VALUES (51,1,2068),
(52,2,2378),
(53,3,619),
(54,4,798),
(55,5,2619),
(56,6,763),
(57,7,1965),
(58,8,2123),
(59,9,1971),
(60,10,934),
(61,11,1934),
(62,12,1456),
(63,13,1314),
(64,14,2385),
(65,15,1190),
(66,16,1576),
(67,17,2068),
(68,18,1954),
(69,19,566),
(70,20,749),
(71,21,2506),
(72,22,2088),
(73,23,1259),
(74,24,1258),
(75,25,1093)
go

INSERT INTO AGENCE_CAMPAGNE(id_campagne,id_agence) 
VALUES (1,4),
(1,1),
(2,3),
(3,3),
(3,4),
(4,4),
(4,1),
(5,2),
(6,3),
(7,1),
(8,1),
(8,3),
(9,1),
(9,2),
(10,4),
(11,1),
(11,2),
(12,3),
(12,4),
(13,3),
(14,3),
(15,1);
(15,2)
go