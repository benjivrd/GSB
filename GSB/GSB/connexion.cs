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
            btn_connexion.Text = dt.Rows[0][1].ToString(); 
        }
    }
}
