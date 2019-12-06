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

        public void FermerConnexion()
        {
            this.cn.Close();
        }

        public DataTable connexionEmploye(string login, string mdp)
        {
            String req = "select prenom, nom, service from employe E inner join personne P on E.id_personne = P.id where login=@leLogin and mdp=@leMdp";
            this.cde = new SqlCommand(req, cn);
            this.cde.Parameters.Add("@leLogin", SqlDbType.VarChar).Value = login;
            this.cde.Parameters.Add("@leMdp", SqlDbType.VarChar).Value = mdp;
            da = new SqlDataAdapter();
            da.SelectCommand = this.cde;
            dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
