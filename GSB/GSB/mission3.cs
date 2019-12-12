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
    public partial class mission3 : Form
    {


        internal BDD bdd;
        private DataTable dt = new DataTable();

        private DataTable dt2 = new DataTable();
        //Liste des noms des boutons des onglets
        string[] listeBoutons = {
            "btn_association_consulter",
            "btn_association_ajouter",
            "btn_action_consulter",
            "btn_action_ajouter",
            "btn_partenariat_consulter",
            "btn_partenanriat_ajouter"
            
        };

        public mission3()
        {
            InitializeComponent();
            //Suppression du menu du TabControl
            tc_mission3.Appearance = TabAppearance.FlatButtons;
            tc_mission3.ItemSize = new Size(0, 1);
            tc_mission3.SizeMode = TabSizeMode.Fixed;
            foreach (TabPage tab in tc_mission3.TabPages)
            {
                tab.Text = "";
            }
    
        }

        private void mission3_Load(object sender, EventArgs e)
        {
            bdd = new BDD(); //Ouverture de la connexion à la bdd
            Button objBtnAssoc = this.Controls.Find("btn_association_consulter", true).FirstOrDefault() as Button;
            btn_association_consulter_Click(objBtnAssoc, e); //Ouverture de l'onglet par défault
        }

        private void btn_association_ajouter_Click(object sender, EventArgs e)
        {
            tc_mission3.SelectedIndex = 1;
            lb_titre.Text = "Ajout d'une association";
        }

        private void btn_action_consulter_Click(object sender, EventArgs e)
        {
            tc_mission3.SelectedIndex = 2;
            lb_titre.Text = "Consultation des actions";
        }

        private void btn_action_ajouter_Click(object sender, EventArgs e)
        {
            tc_mission3.SelectedIndex = 3;
            lb_titre.Text = "Ajout d'une action";
        }

        private void btn_partenariat_consulter_Click(object sender, EventArgs e)
        {
            tc_mission3.SelectedIndex = 4;
            lb_titre.Text = "Consultation des partenariats";
        }

        private void btn_partenariat_ajouter_Click(object sender, EventArgs e)
        {
            tc_mission3.SelectedIndex = 5;
            lb_titre.Text = "Ajout d'un partenariat";
        }

        private void btn_quitter_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_reduire_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }



        //********************ASSOCIATION**************************************

        private void btn_association_consulter_Click(object sender, EventArgs e)
        {
           
            tc_mission3.SelectedIndex = 0; // Ouverture de l'onglet
            lb_titre.Text = "Consultation des associations"; // Changement du titre
            // Remplissage du DataGridView
            dt = bdd.obtenirAssociation();
            this.dgv_association.DataSource = dt;
            this.dgv_association.DataMember = dt.TableName;
            this.dgv_association.AutoGenerateColumns = true;
            this.dgv_association.Columns["nom1"].HeaderText = "pays";
            this.dgv_association.Columns["nom2"].HeaderText = "nom du dirigeant";
            this.dgv_association.Columns["prenom"].HeaderText = "prenom du dirigeant";
            this.dgv_association.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            this.dgv_association.Refresh();
            dgv_association.Rows[0].Selected = false;
            
            cb_association_recherche_type.Items.Clear();
            cb_association_recherche_type.Items.Add("Par nom");
            cb_association_recherche_type.Items.Add("Par pays");
            cb_association_recherche_type.SelectedIndex = 0;

        }

        
        private void tb_association_recherche_nom_TextChanged(object sender, EventArgs e)
        {

            if (tb_association_recherche_nom.Text != "Rechercher une agence")
            {

                if (cb_association_recherche_type.Text == "Par pays")
                {
                    dt = bdd.obtenirAssociationByPays(tb_association_recherche_nom.Text);
                }
                else if (cb_association_recherche_type.Text == "Par nom")
                {
                    dt = bdd.obtenirAssociationByNom(tb_association_recherche_nom.Text);
                }
                
                if (dt.Rows.Count > 0)
                {
                    this.dgv_association.DataSource = dt;
                    this.dgv_association.DataMember = dt.TableName;
                    this.dgv_association.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    this.dgv_association.Refresh();
                    this.dgv_association.Rows[0].Selected = false;
                }
                else
                {
                    var dt = dgv_association.DataSource as DataTable;
                    dt.Rows.Clear();
                    dgv_association.DataSource = dt;
                }
            }
        }

        private void tb_association_recherche_nom_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_association_recherche_nom.Text))
                tb_association_recherche_nom.Text = "Rechercher une association";
        }

        private void tb_association_recherche_nom_Enter(object sender, EventArgs e)
        {
           
            if (tb_association_recherche_nom.Text == "Rechercher une association")
            {
                tb_association_recherche_nom.Text = "";
            }
        }

        private void dgv_association_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int noLigne = e.RowIndex;
            this.dgv_association.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.tb_association_modifier_nom.Text = this.dgv_association[0, noLigne].Value.ToString();
            this.tb_association_modifier_mission.Text = this.dgv_association[1, noLigne].Value.ToString();
            dt = bdd.obtenirPays();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cb_association_modifier_pays.Items.Add(dt.Rows[i][0].ToString());
             
            }
            this.cb_association_modifier_pays.Text = this.dgv_association[2, noLigne].Value.ToString();
       
          
            dt2 = bdd.obtenirPersonne();
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                cb_association_modifier_nom_personne.Items.Add(dt2.Rows[i][0].ToString());
            }
            this.cb_association_modifier_nom_personne.Text = this.dgv_association[3, noLigne].Value.ToString();


        }

        private void btn_association_modifier_Click(object sender,EventArgs e)
        {
            
            int selectedRowsIndex = this.dgv_association.CurrentCell.RowIndex;
            dt = bdd.obtenirPaysByNom(cb_association_modifier_pays.Text);
            dt2 = bdd.obtenirPersonneByNom(cb_association_modifier_nom_personne.Text);
            int id_pays = int.Parse(dt.Rows[0][0].ToString());
            int id_personne = int.Parse(dt2.Rows[0][0].ToString());
            bdd.modifierAssociation(
                this.tb_association_modifier_nom.Text,
                this.tb_association_modifier_mission.Text,
                id_pays,
                id_personne,
                int.Parse(bdd.obtenirIdAssociationAvecNom(this.dgv_association["nom", selectedRowsIndex].Value.ToString()).Rows[0][0].ToString())
            );
            btn_association_consulter_Click(sender, e);
        }

        private void btn_association_supprimer_Click(object sender, EventArgs e)
        {

            dt = bdd.obtenirNombreDeContratConcerneeParUneAssociation(this.tb_association_modifier_nom.Text);
            int nbContrat = int.Parse(dt.Rows[0][0].ToString());
            if (nbContrat == 0)
            {
                bdd.supprimerAssociation(this.tb_association_modifier_nom.Text);
                MessageBox.Show("L'association " + tb_association_modifier_nom.Text + " à bien été supprimé.", "Suppression résussis", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btn_association_consulter_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Vous ne pouvez pas supprimer cette association car un ou plusieurs contrats sont concernées par celle-ci.", "Suppression impossible", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_association_ajouter_sub_Click(object sender, EventArgs e)
        {
            try
            {
                bdd.ajouterAssociation(this.tb_association_ajouter_nom.Text,
                    this.tb_association_ajouter_mission.Text,
                    cb_association_ajouter_personne.SelectedIndex + 1,
                    cb_association_ajouter_pays.SelectedIndex + 1);
                MessageBox.Show("L'association " + tb_association_ajouter_nom.Text + " à bien été ajouté.", "Ajout résussis", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex )
            {
                MessageBox.Show("Une erreur est survenue pour l'ajout d'une nouvelle association" + ex.Message , "Ajout impossible", MessageBoxButtons.OK, MessageBoxIcon.Error);
              
                
            }
        }

        private void cb_association_ajouter_personne_Click(object sender, EventArgs e)
        {
            dt = bdd.obtenirPersonne();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cb_association_ajouter_personne.Items.Add(dt.Rows[i][0].ToString() + "  " + dt.Rows[i][1].ToString());
            }
        }

        private void cb_association_ajouter_pays_Click(object sender, EventArgs e)
        {
            dt = bdd.obtenirPays();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cb_association_ajouter_pays.Items.Add(dt.Rows[i][0].ToString());
            }
        }

        private void tb_association_ajouter_nom_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_association_recherche_nom.Text))
                tb_association_ajouter_nom.Text = "Nom association";
        }

        private void tb_association_ajouter_nom_Enter(object sender, EventArgs e)
        {
            if (tb_association_ajouter_nom.Text == "Nom association")
            {
                tb_association_ajouter_nom.Text = "";
            }
        }

        private void tb_association_ajouter_mission_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(tb_association_ajouter_mission.Text))
                tb_association_ajouter_mission.Text = "Nom mission";
        }

        private void tb_association_ajouter_mission_Enter(object sender, EventArgs e)
        {

            if (tb_association_ajouter_mission.Text == "Nom mission")
            {
                tb_association_ajouter_mission.Text = "";
            }
        }
    }
}
