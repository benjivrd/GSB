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
        internal BDD bdd;
        private DataTable dt = new DataTable();

        //Constructeur
        public connexion()
        {
            InitializeComponent();
            lb_connexion_message.Text = "";
        }

        private void connexion_Load(object sender, EventArgs e)
        {
            bdd = new BDD(); //Ouverture de la connexion à la bdd
        }

        private void btn_connexion_Click(object sender, EventArgs e)
        {
            dt = bdd.connexionEmploye(this.tb_login.Text, this.tb_mdp.Text);
            if (dt.Rows.Count == 0){
                lb_connexion_message.Text = "Erreur..";
                return;
            }
            string prenom = dt.Rows[0][0].ToString();
            string nom = dt.Rows[0][1].ToString();
            string service = dt.Rows[0][2].ToString();
            string poste = dt.Rows[0][3].ToString();

            mission1 m1 = new mission1();
            mission2 m2 = new mission2();
            mission3 m3 = new mission3();

            switch (service){
                case "partenariat":
                    m3.Show();
                    this.Hide();
                    break;
                case "communication":
                    m1.Show();
                    this.Hide();
                    break;
                case "securite":
                    m2.Show();
                    this.Hide();
                    break;
                case "financier":
                    if (poste == "directeur"){
                        lb_connexion_message.Text = "Erreur : votre espace est en cour de développement.";
                    }
                    else{
                        lb_connexion_message.Text = "Erreur : vous n'avez pas les droits suffisants.";
                    }
                    break;
                case "production":
                    if (poste == "directeur"){
                        m2.Show();
                        this.Hide();
                    }
                    else{
                        lb_connexion_message.Text = "Erreur : vous n'avez pas les droits suffisants.";
                    }
                    break;
            }
        }

        //***************************** PRÉREMPLISSAGE **************************************

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

        //***************************** FOCUS TEXTBOX **************************************

        private void tb_login_Enter(object sender, EventArgs e)
        {
            if (tb_login.Text == "Identifiant"){
                tb_login.Text = "";
            }
        }

        private void tb_login_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_login.Text))
                tb_login.Text = "Identifiant";
        }

        private void tb_mdp_Enter(object sender, EventArgs e)
        {
            if (tb_mdp.Text == "Mot de passe"){
                tb_mdp.Text = "";
            }
        }

        private void tb_mdp_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_mdp.Text))
                tb_mdp.Text = "Mot de passe";
        }
    }
}
