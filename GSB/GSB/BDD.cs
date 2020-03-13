using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace GSB
{
    class BDD
    {
        private SqlConnection cn;
        private SqlCommand cde;
        private SqlDataAdapter da;
        private DataTable dt;

        //Constructeur
        public BDD()
        {
            try
            {
                string ch = ConfigurationManager.ConnectionStrings["MaConnection"].ConnectionString;
                cn = new SqlConnection(ch);
                cn.Open();
            }
            catch (SqlException)
            {
                throw new Exception("BDD : Erreur à la connexion");
            }
        }

        //Destructeur
        public void FermerConnexion()
        {
            this.cn.Close();
        }

        //***************************** CONNEXION **************************************

        public DataTable connexionEmploye(string login, string mdp)
        {
            try
            {
                String req = "select prenom, nom, service, poste from employe E inner join personne P on E.id_personne = P.id where login=@leLogin and mdp=@leMdp";
                this.cde = new SqlCommand(req, cn);
                this.cde.Parameters.Add("@leLogin", SqlDbType.VarChar).Value = login;
                this.cde.Parameters.Add("@leMdp", SqlDbType.VarChar).Value = mdp;
                da = new SqlDataAdapter();
                da.SelectCommand = this.cde;
                dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : [connexionEmploye] \n" + ex.Message);
            }
        }


        //***************************** MISSION 1 **************************************


        //***************************** AGENCE **************************************

        public DataTable obtenirAgences()
        {
            try
            {
                String req = "select nom,type,adr_ville,adr_cp,adr_rue,telephone,email,site_web from agence";
                this.cde = new SqlCommand(req, cn);
                da = new SqlDataAdapter();
                da.SelectCommand = this.cde;
                dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : [obtenirAgences] \n" + ex.Message);
            }
        }

        public DataTable obtenirTypesAgences()
        {
            try
            {
                String req = "select distinct(type) from agence";
                this.cde = new SqlCommand(req, cn);
                da = new SqlDataAdapter();
                da.SelectCommand = this.cde;
                dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : [obtenirTypesAgences] \n" + ex.Message);
            }
        }

        public DataTable obtenirAgencesParType(string type)
        {
            try
            {
                String req = "select nom,type,adr_ville,adr_cp,adr_rue,telephone,email,site_web from agence where type=@_type";
                this.cde = new SqlCommand(req, cn);
                this.cde.Parameters.Add("@_type", SqlDbType.VarChar).Value = type;
                da = new SqlDataAdapter();
                da.SelectCommand = this.cde;
                dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : [obtenirAgencesParType] \n" + ex.Message);
            }
        }

        public DataTable obtenirAgencesParNom(string nom)
        {
            try
            {
                String req = "select nom,type,adr_ville,adr_cp,adr_rue,telephone,email,site_web from agence where nom like @_nom";
                this.cde = new SqlCommand(req, cn);
                this.cde.Parameters.Add("@_nom", SqlDbType.VarChar).Value = "%" + nom + "%";
                da = new SqlDataAdapter();
                da.SelectCommand = this.cde;
                dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : [obtenirAgencesParType] \n" + ex.Message);
            }
        }

        public DataTable obtenirIdAgenceAvecNom(string nom)
        {
            try
            {
                String req = "select id from agence where nom=@_nom";
                this.cde = new SqlCommand(req, cn);
                this.cde.Parameters.Add("@_nom", SqlDbType.VarChar).Value = nom;
                da = new SqlDataAdapter();
                da.SelectCommand = this.cde;
                dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : [obtenirAgencesParType] \n" + ex.Message);
            }
        }

        public DataTable obtenirNombreDeCampagnesConcerneeParUneAgence(string nom)
        {
            try
            {
                String req = "select count(id_agence) from agence_campagne where id_agence=(select id from agence where nom=@_nom)";
                this.cde = new SqlCommand(req, cn);
                this.cde.Parameters.Add("@_nom", SqlDbType.VarChar).Value = nom;
                da = new SqlDataAdapter();
                da.SelectCommand = this.cde;
                dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : [obtenirAgencesParType] \n" + ex.Message);
            }
        }

        public void modifierAgence(string nom, string type, string ville, string cp, string rue, string tel, string email, string site, int id)
        {
            try
            {
                string req = "update agence set nom=@_nom, type=@_type, adr_ville=@_ville, adr_cp=@_cp, adr_rue=@_rue, telephone=@_tel, email=@_email, site_web=@_site where id=@_id";
                this.cde = new SqlCommand(req, cn);
                this.cde.Parameters.Add("@_nom", SqlDbType.VarChar).Value = nom;
                this.cde.Parameters.Add("@_type", SqlDbType.VarChar).Value = type;
                this.cde.Parameters.Add("@_ville", SqlDbType.VarChar).Value = ville;
                this.cde.Parameters.Add("@_cp", SqlDbType.VarChar).Value = cp;
                this.cde.Parameters.Add("@_rue", SqlDbType.VarChar).Value = rue;
                this.cde.Parameters.Add("@_tel", SqlDbType.VarChar).Value = tel;
                this.cde.Parameters.Add("@_email", SqlDbType.VarChar).Value = email;
                this.cde.Parameters.Add("@_site", SqlDbType.VarChar).Value = site;
                this.cde.Parameters.Add("@_id", SqlDbType.Int).Value = id;
                this.cde.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : [modifierAgence] \n" + ex.Message);
            }
        }

        public void supprimerAgence(string nom)
        {
            try
            {
                string req = "delete from agence where nom=@_nom";
                this.cde = new SqlCommand(req, cn);
                this.cde.Parameters.Add("@_nom", SqlDbType.VarChar).Value = nom;
                this.cde.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(" Erreur Suppr SqlServer \n" + ex.Message);
            }
        }


        //***************************** MISSION 3 **************************************

        //***************************** ASSOCIATION **************************************

        public DataTable obtenirAssociation()
        {
            try
            {
                String req = "select ASSOCIATION.nom, ASSOCIATION.mission,PAYS.nom,PERSONNE.nom,PERSONNE.prenom from ASSOCIATION inner join PERSONNE on ASSOCIATION.id_personne = PERSONNE.id inner join PAYS on ASSOCIATION.id_pays = PAYS.id ";
                this.cde = new SqlCommand(req, cn);
                da = new SqlDataAdapter();
                da.SelectCommand = this.cde;
                dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : [obtenirAssociation] \n" + ex.Message);
            }
        }

        public DataTable obtenirPays()
        {
            try
            {
                String req = "select PAYS.nom from PAYS ";
                this.cde = new SqlCommand(req, cn);
                da = new SqlDataAdapter();
                da.SelectCommand = this.cde;
                dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : [obtenirPays] \n" + ex.Message);
            }
        }
        public DataTable obtenirIdAssociationAvecNom(string nom)
        {
            try
            {
                String req = "select id from ASSOCIATION where nom = @_nom ";
                this.cde = new SqlCommand(req, cn);
                this.cde.Parameters.Add("@_nom", SqlDbType.VarChar).Value = nom;
                da = new SqlDataAdapter();
                da.SelectCommand = this.cde;
                dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : [obtenirPays] \n" + ex.Message);
            }
        }

        

        public DataTable obtenirPersonne()
        {
            try
            {
                String req = "select PERSONNE.nom,PERSONNE.prenom from PERSONNE ";
                this.cde = new SqlCommand(req, cn);
                da = new SqlDataAdapter();
                da.SelectCommand = this.cde;
                dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : [obtenirPersonne] \n" + ex.Message);
            }
        }


        public DataTable obtenirAssociationByPays(string pays)
        {
            try
            {
                String req = "select ASSOCIATION.nom, ASSOCIATION.mission,PAYS.nom,PERSONNE.nom,PERSONNE.prenom from ASSOCIATION inner join PERSONNE on ASSOCIATION.id_personne = PERSONNE.id inner join PAYS on ASSOCIATION.id_pays = PAYS.id where PAYS.nom like @_pays ";
                this.cde = new SqlCommand(req, cn);
                this.cde.Parameters.Add("@_pays", SqlDbType.VarChar).Value = "%" + pays + "%";
                da = new SqlDataAdapter();
                da.SelectCommand = this.cde;
                dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : [obtenirAssociationParPays] \n" + ex.Message);
            }
        }

        public DataTable obtenirAssociationByNom(string nom)
        {
            try
            {
                String req = "select ASSOCIATION.nom, ASSOCIATION.mission,PAYS.nom,PERSONNE.nom,PERSONNE.prenom from ASSOCIATION inner join PERSONNE on ASSOCIATION.id_personne = PERSONNE.id inner join PAYS on ASSOCIATION.id_pays = PAYS.id where ASSOCIATION.nom like @_nom ";
                this.cde = new SqlCommand(req, cn);
                this.cde.Parameters.Add("@_nom", SqlDbType.VarChar).Value = "%" + nom + "%";
                da = new SqlDataAdapter();
                da.SelectCommand = this.cde;
                dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : [obtenirAssociationParNom] \n" + ex.Message);
            }
        }

        public DataTable obtenirPersonneByNom(string nom)
        {
            try
            {
                String req = "select PERSONNE.id from PERSONNE  where PERSONNE.nom = @_nom";
                this.cde = new SqlCommand(req, cn);
                this.cde.Parameters.Add("@_nom", SqlDbType.VarChar).Value = nom;
                da = new SqlDataAdapter();
                da.SelectCommand = this.cde;
                dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : [obtenirPersonneByNom] \n" + ex.Message);
            }
        }
        public DataTable obtenirPaysByNom(string nom)
        {
            try
            {
                String req = "select PAYS.id from PAYS  where PAYS.nom = @_nom";
                this.cde = new SqlCommand(req, cn);
                this.cde.Parameters.Add("@_nom", SqlDbType.VarChar).Value = nom;
                da = new SqlDataAdapter();
                da.SelectCommand = this.cde;
                dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : [obtenirPaysByNom] \n" + ex.Message);
            }
        }

        public void modifierAssociation(string nom, string mission, int id_pays, int id_personne, int id)
        {
            try
            {
                string req = "update association set nom=@_nom, mission=@_mission, id_pays=@_pays, id_personne=@_personne where id=@_id";
                this.cde = new SqlCommand(req, cn);
                this.cde.Parameters.Add("@_nom", SqlDbType.VarChar).Value = nom;
                this.cde.Parameters.Add("@_mission", SqlDbType.VarChar).Value = mission;
                this.cde.Parameters.Add("@_pays", SqlDbType.Int).Value = id_pays ;
                this.cde.Parameters.Add("@_personne", SqlDbType.Int).Value = id_personne;
                this.cde.Parameters.Add("@_id", SqlDbType.Int).Value = id;
                this.cde.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : [modifierAssociation] \n" + ex.Message);
            }
        }

        public DataTable obtenirNombreDeContratConcerneeParUneAssociation(string nom)
        {
            try
            {
                string req = "select count(id) from CONTRAT where id_association = (select id from ASSOCIATION where nom = @_nom)";
                this.cde = new SqlCommand(req, cn);
                this.cde.Parameters.Add("@_nom", SqlDbType.VarChar).Value = nom;
                da = new SqlDataAdapter();
                da.SelectCommand = this.cde;
                dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {

                throw new Exception("Erreur : [ObtenirNbContratParAssociation] \n" + ex.Message);
            }
        }

        public void supprimerAssociation(string nom)
        {
            try
            {
                string req = "delete from ASSOCIATION where nom=@_nom";
                this.cde = new SqlCommand(req, cn);
                this.cde.Parameters.Add("@_nom", SqlDbType.VarChar).Value = nom;
                this.cde.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(" Erreur Suppr SqlServer \n" + ex.Message);
            }
        }

        public void ajouterAssociation(string nom, string mission, int id_personne , int id_pays)
        {
            try
            {
                string req = "insert into ASSOCIATION(nom,mission,id_personne,id_pays) values(@_nom,@_mission,@_personne,@_pays)";
                this.cde = new SqlCommand(req, cn);
                this.cde.Parameters.Add("@_nom", SqlDbType.VarChar).Value = nom;
                this.cde.Parameters.Add("@_mission", SqlDbType.VarChar).Value = mission;
                this.cde.Parameters.Add("@_pays", SqlDbType.Int).Value = id_pays;
                this.cde.Parameters.Add("@_personne", SqlDbType.Int).Value = id_personne;             
                this.cde.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : [ajouterrAssociation] \n" + ex.Message);
            }
        }

        //************************ACTION********************\\

        public DataTable obtenirAction()
        {
            try
            {
                String req = "SELECT ACTION.id, ACTION.libelle, ACTION_PAYS_ANNEE.annee, PAYS.nom, ACTION.description FROM ACTION INNER JOIN ACTION_PAYS_ANNEE on ACTION.id = ACTION_PAYS_ANNEE.id_action INNER JOIN PAYS on ACTION_PAYS_ANNEE.id_pays = PAYS.id ";
                this.cde = new SqlCommand(req, cn);
                da = new SqlDataAdapter();
                da.SelectCommand = this.cde;
                dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : [obtenirAction] \n" + ex.Message);
            }
        }

        public DataTable obtenirAnnee()
        {
            try
            {
                String req = "SELECT * FROM ANNEE";
                this.cde = new SqlCommand(req, cn);
                da = new SqlDataAdapter();
                da.SelectCommand = this.cde;
                dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur : [obtenirAnnee] \n" + ex.Message);
            }
        }


        public void supprimerAction(string id, string annee)
        {
            try
            {
                string req = "delete from ACTION INNER JOIN ACTION_PAYS_ANNEE on ACTION.id = ACTION_PAYS_ANNEE.id_action where ACTION.id = @_id and ACTION_PAYS_ANNEE = @_annee";
                this.cde = new SqlCommand(req, cn);
                this.cde.Parameters.Add("@_id", SqlDbType.Int).Value = id;
                this.cde.Parameters.Add("@_annee", SqlDbType.VarChar).Value = annee;
                this.cde.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(" Erreur Suppr SqlServer \n" + ex.Message);
            }
        }






    }
}
