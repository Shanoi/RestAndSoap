namespace ClientGUIAsync
{
    partial class App
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtStation = new System.Windows.Forms.TextBox();
            this.lblVille = new System.Windows.Forms.Label();
            this.lblStation = new System.Windows.Forms.Label();
            this.listItems = new System.Windows.Forms.ListBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cBoxVilles = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtStation
            // 
            this.txtStation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStation.Location = new System.Drawing.Point(330, 88);
            this.txtStation.Name = "txtStation";
            this.txtStation.Size = new System.Drawing.Size(210, 26);
            this.txtStation.TabIndex = 1;
            // 
            // lblVille
            // 
            this.lblVille.AutoSize = true;
            this.lblVille.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVille.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblVille.Location = new System.Drawing.Point(178, 53);
            this.lblVille.Name = "lblVille";
            this.lblVille.Size = new System.Drawing.Size(44, 24);
            this.lblVille.TabIndex = 2;
            this.lblVille.Text = "City";
            // 
            // lblStation
            // 
            this.lblStation.AutoSize = true;
            this.lblStation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStation.Location = new System.Drawing.Point(156, 88);
            this.lblStation.Name = "lblStation";
            this.lblStation.Size = new System.Drawing.Size(73, 24);
            this.lblStation.TabIndex = 3;
            this.lblStation.Text = "Station";
            // 
            // listItems
            // 
            this.listItems.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.listItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listItems.FormattingEnabled = true;
            this.listItems.ItemHeight = 20;
            this.listItems.Location = new System.Drawing.Point(25, 218);
            this.listItems.Name = "listItems";
            this.listItems.Size = new System.Drawing.Size(645, 264);
            this.listItems.Sorted = true;
            this.listItems.TabIndex = 4;
            this.listItems.SelectedIndexChanged += new System.EventHandler(this.listItems_SelectedIndexChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(228, 146);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(212, 47);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cBoxVilles
            // 
            this.cBoxVilles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxVilles.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxVilles.FormattingEnabled = true;
            this.cBoxVilles.Location = new System.Drawing.Point(330, 54);
            this.cBoxVilles.Name = "cBoxVilles";
            this.cBoxVilles.Size = new System.Drawing.Size(210, 28);
            this.cBoxVilles.Sorted = true;
            this.cBoxVilles.TabIndex = 6;
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(727, 518);
            this.Controls.Add(this.cBoxVilles);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.listItems);
            this.Controls.Add(this.lblStation);
            this.Controls.Add(this.lblVille);
            this.Controls.Add(this.txtStation);
            this.Name = "App";
            this.Text = "App";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtStation;
        private System.Windows.Forms.Label lblVille;
        private System.Windows.Forms.Label lblStation;
        private System.Windows.Forms.ListBox listItems;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cBoxVilles;
    }
}