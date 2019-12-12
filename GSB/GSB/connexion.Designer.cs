namespace GSB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(connexion));
            this.btn_connexion = new System.Windows.Forms.Button();
            this.tb_login = new System.Windows.Forms.TextBox();
            this.tb_mdp = new System.Windows.Forms.TextBox();
            this.lb_connexion_message = new System.Windows.Forms.Label();
            this.btn_mission1 = new System.Windows.Forms.Button();
            this.btn_mission2 = new System.Windows.Forms.Button();
            this.btn_mission3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_connexion
            // 
            this.btn_connexion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(192)))), ((int)(((byte)(203)))));
            this.btn_connexion.FlatAppearance.BorderSize = 0;
            this.btn_connexion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_connexion.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_connexion.ForeColor = System.Drawing.Color.White;
            this.btn_connexion.Location = new System.Drawing.Point(80, 290);
            this.btn_connexion.Name = "btn_connexion";
            this.btn_connexion.Size = new System.Drawing.Size(185, 40);
            this.btn_connexion.TabIndex = 0;
            this.btn_connexion.Text = "Connexion";
            this.btn_connexion.UseVisualStyleBackColor = false;
            this.btn_connexion.Click += new System.EventHandler(this.btn_connexion_Click);
            // 
            // tb_login
            // 
            this.tb_login.BackColor = System.Drawing.Color.White;
            this.tb_login.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_login.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_login.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(65)))), ((int)(((byte)(79)))));
            this.tb_login.Location = new System.Drawing.Point(80, 170);
            this.tb_login.Name = "tb_login";
            this.tb_login.Size = new System.Drawing.Size(185, 27);
            this.tb_login.TabIndex = 1;
            this.tb_login.Text = "Identifiant";
            this.tb_login.Enter += new System.EventHandler(this.tb_login_Enter);
            this.tb_login.Leave += new System.EventHandler(this.tb_login_Leave);
            // 
            // tb_mdp
            // 
            this.tb_mdp.BackColor = System.Drawing.Color.White;
            this.tb_mdp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_mdp.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_mdp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(65)))), ((int)(((byte)(79)))));
            this.tb_mdp.Location = new System.Drawing.Point(80, 220);
            this.tb_mdp.Name = "tb_mdp";
            this.tb_mdp.Size = new System.Drawing.Size(185, 27);
            this.tb_mdp.TabIndex = 2;
            this.tb_mdp.Text = "Mot de passe";
            this.tb_mdp.Enter += new System.EventHandler(this.tb_mdp_Enter);
            this.tb_mdp.Leave += new System.EventHandler(this.tb_mdp_Leave);
            // 
            // lb_connexion_message
            // 
            this.lb_connexion_message.AutoSize = true;
            this.lb_connexion_message.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_connexion_message.ForeColor = System.Drawing.Color.White;
            this.lb_connexion_message.Location = new System.Drawing.Point(140, 355);
            this.lb_connexion_message.Name = "lb_connexion_message";
            this.lb_connexion_message.Size = new System.Drawing.Size(64, 16);
            this.lb_connexion_message.TabIndex = 5;
            this.lb_connexion_message.Text = "[message]";
            // 
            // btn_mission1
            // 
            this.btn_mission1.FlatAppearance.BorderSize = 0;
            this.btn_mission1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.btn_mission1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_mission1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_mission1.ForeColor = System.Drawing.Color.White;
            this.btn_mission1.Location = new System.Drawing.Point(0, 82);
            this.btn_mission1.Name = "btn_mission1";
            this.btn_mission1.Size = new System.Drawing.Size(115, 30);
            this.btn_mission1.TabIndex = 6;
            this.btn_mission1.Text = "Mission 1";
            this.btn_mission1.UseVisualStyleBackColor = true;
            this.btn_mission1.Click += new System.EventHandler(this.btn_mission1_Click);
            // 
            // btn_mission2
            // 
            this.btn_mission2.FlatAppearance.BorderSize = 0;
            this.btn_mission2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.btn_mission2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_mission2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_mission2.ForeColor = System.Drawing.Color.White;
            this.btn_mission2.Location = new System.Drawing.Point(115, 82);
            this.btn_mission2.Name = "btn_mission2";
            this.btn_mission2.Size = new System.Drawing.Size(115, 30);
            this.btn_mission2.TabIndex = 7;
            this.btn_mission2.Text = "Mission 2";
            this.btn_mission2.UseVisualStyleBackColor = true;
            this.btn_mission2.Click += new System.EventHandler(this.btn_mission2_Click);
            // 
            // btn_mission3
            // 
            this.btn_mission3.FlatAppearance.BorderSize = 0;
            this.btn_mission3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(55)))), ((int)(((byte)(69)))));
            this.btn_mission3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_mission3.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_mission3.ForeColor = System.Drawing.Color.White;
            this.btn_mission3.Location = new System.Drawing.Point(230, 82);
            this.btn_mission3.Name = "btn_mission3";
            this.btn_mission3.Size = new System.Drawing.Size(115, 30);
            this.btn_mission3.TabIndex = 8;
            this.btn_mission3.Text = "Mission 3";
            this.btn_mission3.UseVisualStyleBackColor = true;
            this.btn_mission3.Click += new System.EventHandler(this.btn_mission3_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(192)))), ((int)(((byte)(203)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(345, 80);
            this.panel1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(53, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Authentification";
            // 
            // connexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(65)))), ((int)(((byte)(79)))));
            this.ClientSize = new System.Drawing.Size(345, 400);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_mission3);
            this.Controls.Add(this.btn_mission2);
            this.Controls.Add(this.btn_mission1);
            this.Controls.Add(this.lb_connexion_message);
            this.Controls.Add(this.tb_mdp);
            this.Controls.Add(this.tb_login);
            this.Controls.Add(this.btn_connexion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "connexion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.connexion_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_connexion;
        private System.Windows.Forms.TextBox tb_login;
        private System.Windows.Forms.TextBox tb_mdp;
        private System.Windows.Forms.Label lb_connexion_message;
        private System.Windows.Forms.Button btn_mission1;
        private System.Windows.Forms.Button btn_mission2;
        private System.Windows.Forms.Button btn_mission3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}

