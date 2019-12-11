using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSB
{
    public partial class mission1 : Form
    {
        internal BDD bdd;
        private DataTable dt = new DataTable();
        //Liste des noms des boutons des onglets
        string[] listeBoutons = {
            "btn_agence_consulter",
            "btn_agence_ajouter",
            "btn_campagne_consulter",
            "btn_campagne_ajouter",
            "btn_evenement_consulter",
            "btn_evenement_ajouter",
            "btn_vip_consulter",
            "btn_vip_ajouter",
            "btn_vip_invitation",
            "btn_artiste_consulter",
            "btn_artiste_ajouter",
            "btn_artiste_reservation"
        };

        public mission1()
        {
            InitializeComponent();
            //Suppression du menu du TabControl
            tc_mission1.Appearance = TabAppearance.FlatButtons;
            tc_mission1.ItemSize = new Size(0, 1);
            tc_mission1.SizeMode = TabSizeMode.Fixed;
            foreach (TabPage tab in tc_mission1.TabPages)
            {
                tab.Text = "";
            }
        }

        private void mission1_Load(object sender, EventArgs e)
        {
            bdd = new BDD(); //Ouverture de la connexion à la bdd
            Button objBtnAgence = this.Controls.Find("btn_agence_consulter", true).FirstOrDefault() as Button;
            btn_agence_consulter_Click(objBtnAgence, e); //Ouverture de l'onglet par défault
        }

        //***************************** BOUTONS COIN HAUT DROITE **************************************

        private void btn_quitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_reduire_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //***************************** GESTION DU MENU GAUCHE **************************************

        private void selectionBouton(Button btn)
        {
            btn.BackColor = Color.FromArgb(43,55,69);
            foreach(string nom_boutons in listeBoutons)
            {
                Button btns = this.Controls.Find(nom_boutons,true).FirstOrDefault() as Button;
                if (btns != btn)
                {
                    btns.BackColor = Color.FromArgb(53, 65, 79);
                }
            }
        }

        private void btn_agence_consulter_Click(object sender, EventArgs e)
        {
            // Sélection permanente du bouton
            Button senderBtn = sender as Button;
            selectionBouton(senderBtn);
            tc_mission1.SelectedIndex = 0; // Ouverture de l'onglet
            lb_titre.Text = "Consultation des agences"; // Changement du titre
            // Remplissage du DataGridView
            dt = bdd.obtenirAgences();
            this.dgv_agence.DataSource = dt;
            this.dgv_agence.DataMember = dt.TableName;
            this.dgv_agence.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            this.dgv_agence.Refresh();
            dgv_agence.Rows[0].Selected = false;
            // Remplissage de la ComboBox
            cb_agence_recherche_type.Items.Clear();
            cb_agence_recherche_type.Items.Add("Tous les types d'activité");
            dt = bdd.obtenirTypesAgences();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cb_agence_recherche_type.Items.Add(dt.Rows[i][0].ToString());
            }
            cb_agence_recherche_type.SelectedIndex = 0;
            
        }

        private void btn_agence_ajouter_Click(object sender, EventArgs e)
        {
            Button senderBtn = sender as Button;
            selectionBouton(senderBtn);
            tc_mission1.SelectedIndex = 1;
            lb_titre.Text = "Ajout d'une agences";
        }

        private void btn_campagne_consulter_Click(object sender, EventArgs e)
        {
            Button senderBtn = sender as Button;
            selectionBouton(senderBtn);
            tc_mission1.SelectedIndex = 2;
            lb_titre.Text = "Consultation des campagnes";
        }

        private void btn_campagne_ajouter_Click(object sender, EventArgs e)
        {
            Button senderBtn = sender as Button;
            selectionBouton(senderBtn);
            tc_mission1.SelectedIndex = 3;
            lb_titre.Text = "Ajout d'une campagne";
        }

        private void btn_evenement_consulter_Click(object sender, EventArgs e)
        {
            Button senderBtn = sender as Button;
            selectionBouton(senderBtn);
            tc_mission1.SelectedIndex = 4;
            lb_titre.Text = "Consultation des événements";
        }

        private void btn_evenement_ajouter_Click(object sender, EventArgs e)
        {
            Button senderBtn = sender as Button;
            selectionBouton(senderBtn);
            tc_mission1.SelectedIndex = 5;
            lb_titre.Text = "Ajout d'un événement";
        }

        private void btn_vip_consulter_Click(object sender, EventArgs e)
        {
            Button senderBtn = sender as Button;
            selectionBouton(senderBtn);
            tc_mission1.SelectedIndex = 6;
            lb_titre.Text = "Consultation des vips";
        }

        private void btn_vip_ajouter_Click(object sender, EventArgs e)
        {
            Button senderBtn = sender as Button;
            selectionBouton(senderBtn);
            tc_mission1.SelectedIndex = 7;
            lb_titre.Text = "Ajout d'un vip";
        }

        private void btn_vip_invitation_Click(object sender, EventArgs e)
        {
            Button senderBtn = sender as Button;
            selectionBouton(senderBtn);
            tc_mission1.SelectedIndex = 8;
            lb_titre.Text = "Invitation des vips";
        }

        private void btn_artiste_consulter_Click(object sender, EventArgs e)
        {
            Button senderBtn = sender as Button;
            selectionBouton(senderBtn);
            tc_mission1.SelectedIndex = 9;
            lb_titre.Text = "Consultation des artistes";
        }

        private void btn_artiste_ajouter_Click(object sender, EventArgs e)
        {
            Button senderBtn = sender as Button;
            selectionBouton(senderBtn);
            tc_mission1.SelectedIndex = 10;
            lb_titre.Text = "Ajout d'un artiste";
        }

        private void btn_artiste_reservation_Click(object sender, EventArgs e)
        {
            Button senderBtn = sender as Button;
            selectionBouton(senderBtn);
            tc_mission1.SelectedIndex = 11;
            lb_titre.Text = "Réservation des artistes";
        }

        //***************************** AGENCE **************************************

        private void cb_agence_recherche_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cb_agence_recherche_type.Text == "Tous les types d'activité"){
                dt = bdd.obtenirAgences();
            }
            else{
                dt = bdd.obtenirAgencesParType(cb_agence_recherche_type.Text);
            }
            this.dgv_agence.DataSource = dt;
            this.dgv_agence.DataMember = dt.TableName;
            this.dgv_agence.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            this.dgv_agence.Refresh();
            dgv_agence.Rows[0].Selected = false;
        }

        private void tb_agence_recherche_nom_Enter(object sender, EventArgs e)
        {
            cb_agence_recherche_type.SelectedIndex = 0;
            if (tb_agence_recherche_nom.Text == "Rechercher une agence"){
                tb_agence_recherche_nom.Text = "";
            }
        }

        private void tb_agence_recherche_nom_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_agence_recherche_nom.Text))
                tb_agence_recherche_nom.Text = "Rechercher une agence";
        }

        private void tb_agence_recherche_nom_TextChanged(object sender, EventArgs e)
        {
            if (tb_agence_recherche_nom.Text != "Rechercher une agence"){
                dt = bdd.obtenirAgencesParNom(tb_agence_recherche_nom.Text);
                if (dt.Rows.Count > 0)
                {
                    this.dgv_agence.DataSource = dt;
                    this.dgv_agence.DataMember = dt.TableName;
                    this.dgv_agence.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    this.dgv_agence.Refresh();
                    this.dgv_agence.Rows[0].Selected = false;
                }
                else{
                    var dt = dgv_agence.DataSource as DataTable;
                    dt.Rows.Clear();
                    dgv_agence.DataSource = dt;
                }
            }
        }

        private void dgv_agence_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int noLigne = e.RowIndex;
            this.dgv_agence.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.tb_agence_modifier_nom.Text = this.dgv_agence[0, noLigne].Value.ToString();
            this.tb_agence_modifier_type.Text = this.dgv_agence[1, noLigne].Value.ToString();
            this.tb_agence_modifier_ville.Text = this.dgv_agence[2, noLigne].Value.ToString();
            this.tb_agence_modifier_cp.Text = this.dgv_agence[3, noLigne].Value.ToString();
            this.tb_agence_modifier_rue.Text = this.dgv_agence[4, noLigne].Value.ToString();
            this.tb_agence_modifier_tel.Text = this.dgv_agence[5, noLigne].Value.ToString();
            this.tb_agence_modifier_email.Text = this.dgv_agence[6, noLigne].Value.ToString();
            this.tb_agence_modifier_site.Text = this.dgv_agence[7, noLigne].Value.ToString();
            
        }

        private void btn_agence_modifier_Click(object sender, EventArgs e)
        {
            int selectedRowsIndex = this.dgv_agence.CurrentCell.RowIndex;
            bdd.modifierAgence(
                this.tb_agence_modifier_nom.Text, 
                this.tb_agence_modifier_type.Text, 
                this.tb_agence_modifier_ville.Text, 
                this.tb_agence_modifier_cp.Text, 
                this.tb_agence_modifier_rue.Text, 
                this.tb_agence_modifier_tel.Text, 
                this.tb_agence_modifier_email.Text, 
                this.tb_agence_modifier_site.Text, 
                int.Parse(bdd.obtenirIdAgenceAvecNom(this.dgv_agence["nom", selectedRowsIndex].Value.ToString()).Rows[0][0].ToString())
            );
            btn_agence_consulter_Click(sender, e);
        }

        private void btn_agence_supprimer_Click(object sender, EventArgs e)
        {
            dt = bdd.obtenirNombreDeCampagnesConcerneeParUneAgence(this.tb_agence_modifier_nom.Text);
            int nbCampagne = int.Parse(dt.Rows[0][0].ToString());
            if (nbCampagne == 0){
                bdd.supprimerAgence(this.tb_agence_modifier_nom.Text);
                btn_agence_consulter_Click(sender, e);
            }
            else{
                MessageBox.Show("Vous ne pouvez pas supprimer cette agence car une ou plusieurs campagnes sont concernées par celle-ci.", "Suppression impossible", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
