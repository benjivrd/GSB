﻿namespace GSB
{
    partial class connexion
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_connexion = new System.Windows.Forms.Button();
            this.tb_login = new System.Windows.Forms.TextBox();
            this.tb_mdp = new System.Windows.Forms.TextBox();
            this.lb_login = new System.Windows.Forms.Label();
            this.lb_mdp = new System.Windows.Forms.Label();
            this.lb_erreurConnexion = new System.Windows.Forms.Label();
            this.btn_mission1 = new System.Windows.Forms.Button();
            this.btn_mission2 = new System.Windows.Forms.Button();
            this.btn_mission3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_connexion
            // 
            this.btn_connexion.Location = new System.Drawing.Point(198, 334);
            this.btn_connexion.Name = "btn_connexion";
            this.btn_connexion.Size = new System.Drawing.Size(75, 23);
            this.btn_connexion.TabIndex = 0;
            this.btn_connexion.Text = "Connexion";
            this.btn_connexion.UseVisualStyleBackColor = true;
            this.btn_connexion.Click += new System.EventHandler(this.btn_connexion_Click);
            // 
            // tb_login
            // 
            this.tb_login.Location = new System.Drawing.Point(221, 207);
            this.tb_login.Name = "tb_login";
            this.tb_login.Size = new System.Drawing.Size(100, 20);
            this.tb_login.TabIndex = 1;
            // 
            // tb_mdp
            // 
            this.tb_mdp.Location = new System.Drawing.Point(221, 243);
            this.tb_mdp.Name = "tb_mdp";
            this.tb_mdp.Size = new System.Drawing.Size(100, 20);
            this.tb_mdp.TabIndex = 2;
            // 
            // lb_login
            // 
            this.lb_login.AutoSize = true;
            this.lb_login.Location = new System.Drawing.Point(146, 210);
            this.lb_login.Name = "lb_login";
            this.lb_login.Size = new System.Drawing.Size(62, 13);
            this.lb_login.TabIndex = 3;
            this.lb_login.Text = "Identifiant : ";
            // 
            // lb_mdp
            // 
            this.lb_mdp.AutoSize = true;
            this.lb_mdp.Location = new System.Drawing.Point(146, 246);
            this.lb_mdp.Name = "lb_mdp";
            this.lb_mdp.Size = new System.Drawing.Size(77, 13);
            this.lb_mdp.TabIndex = 4;
            this.lb_mdp.Text = "Mot de passe :";
            // 
            // lb_erreurConnexion
            // 
            this.lb_erreurConnexion.AutoSize = true;
            this.lb_erreurConnexion.Location = new System.Drawing.Point(227, 297);
            this.lb_erreurConnexion.Name = "lb_erreurConnexion";
            this.lb_erreurConnexion.Size = new System.Drawing.Size(19, 13);
            this.lb_erreurConnexion.TabIndex = 5;
            this.lb_erreurConnexion.Text = "__";
            // 
            // btn_mission1
            // 
            this.btn_mission1.Location = new System.Drawing.Point(124, 104);
            this.btn_mission1.Name = "btn_mission1";
            this.btn_mission1.Size = new System.Drawing.Size(75, 23);
            this.btn_mission1.TabIndex = 6;
            this.btn_mission1.Text = "Mission 1";
            this.btn_mission1.UseVisualStyleBackColor = true;
            this.btn_mission1.Click += new System.EventHandler(this.btn_mission1_Click);
            // 
            // btn_mission2
            // 
            this.btn_mission2.Location = new System.Drawing.Point(205, 104);
            this.btn_mission2.Name = "btn_mission2";
            this.btn_mission2.Size = new System.Drawing.Size(75, 23);
            this.btn_mission2.TabIndex = 7;
            this.btn_mission2.Text = "Mission 2";
            this.btn_mission2.UseVisualStyleBackColor = true;
            this.btn_mission2.Click += new System.EventHandler(this.btn_mission2_Click);
            // 
            // btn_mission3
            // 
            this.btn_mission3.Location = new System.Drawing.Point(286, 104);
            this.btn_mission3.Name = "btn_mission3";
            this.btn_mission3.Size = new System.Drawing.Size(75, 23);
            this.btn_mission3.TabIndex = 8;
            this.btn_mission3.Text = "Mission 3";
            this.btn_mission3.UseVisualStyleBackColor = true;
            this.btn_mission3.Click += new System.EventHandler(this.btn_mission3_Click);
            // 
            // connexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 512);
            this.Controls.Add(this.btn_mission3);
            this.Controls.Add(this.btn_mission2);
            this.Controls.Add(this.btn_mission1);
            this.Controls.Add(this.lb_erreurConnexion);
            this.Controls.Add(this.lb_mdp);
            this.Controls.Add(this.lb_login);
            this.Controls.Add(this.tb_mdp);
            this.Controls.Add(this.tb_login);
            this.Controls.Add(this.btn_connexion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "connexion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.connexion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_connexion;
        private System.Windows.Forms.TextBox tb_login;
        private System.Windows.Forms.TextBox tb_mdp;
        private System.Windows.Forms.Label lb_login;
        private System.Windows.Forms.Label lb_mdp;
        private System.Windows.Forms.Label lb_erreurConnexion;
        private System.Windows.Forms.Button btn_mission1;
        private System.Windows.Forms.Button btn_mission2;
        private System.Windows.Forms.Button btn_mission3;
    }
}

