using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GSB
{
    public partial class connexion : Form
    {
        public connexion()
        {
            InitializeComponent();
        }

        internal BDD bdd;
        private DataTable dt = new DataTable();

        private void connexion_Load(object sender, EventArgs e)
        {
            bdd = new BDD();
        }

        private void btn_connexion_Click(object sender, EventArgs e)
        {
            dt = bdd.connexionEmploye(this.tb_login.Text, this.tb_mdp.Text);
            if (dt.Rows.Count == 0){
                lb_erreurConnexion.Text = "Erreur..";
                return;
            }
            string prenom = dt.Rows[0][0].ToString();
            string nom = dt.Rows[0][1].ToString();
            string service = dt.Rows[0][2].ToString();
            string poste = dt.Rows[0][3].ToString();

            mission1 mission1 = new mission1();
            mission2 mission2 = new mission2();
            mission3 mission3 = new mission3();

            switch (service){
                case "partenariat":
                    mission3.Show();
                    this.Hide();
                    break;
                case "communication":
                    mission1.Show();
                    this.Hide();
                    break;
                case "securite":
                    mission2.Show();
                    this.Hide();
                    break;
                case "financier":
                    if (poste == "directeur"){
                        lb_erreurConnexion.Text = "Erreur : votre espace est en cour de développement.";
                    }
                    else{
                        lb_erreurConnexion.Text = "Erreur : vous n'avez pas les droits suffisants.";
                    }
                    break;
                case "production":
                    if (poste == "directeur"){
                        mission2.Show();
                        this.Hide();
                    }
                    else{
                        lb_erreurConnexion.Text = "Erreur : vous n'avez pas les droits suffisants.";
                    }
                    break;
            }
        }

        private void btn_mission1_Click(object sender, EventArgs e)
        {
            tb_login.Text = "Mathieu.Renault";
            tb_mdp.Text = "1976apfy";
        }

        private void btn_mission2_Click(object sender, EventArgs e)
        {
            tb_login.Text = "Oceane.Lefebre";
            tb_mdp.Text = "1988azpt";
        }

        private void btn_mission3_Click(object sender, EventArgs e)
        {
            tb_login.Text = "Solene.Legoff";
            tb_mdp.Text = "1978amcq";
        }
    }
}
