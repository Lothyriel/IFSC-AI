namespace WindowsForms
{
    partial class ExpertSystemsView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lb_ExpertSystems = new System.Windows.Forms.ListBox();
            this.bt_CreateSystem = new System.Windows.Forms.Button();
            this.bt_RunSystem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_ExpertSystems
            // 
            this.lb_ExpertSystems.FormattingEnabled = true;
            this.lb_ExpertSystems.ItemHeight = 20;
            this.lb_ExpertSystems.Location = new System.Drawing.Point(31, 25);
            this.lb_ExpertSystems.Name = "lb_ExpertSystems";
            this.lb_ExpertSystems.Size = new System.Drawing.Size(303, 224);
            this.lb_ExpertSystems.TabIndex = 0;
            this.lb_ExpertSystems.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lb_ExpertSystems_MouseClick);
            this.lb_ExpertSystems.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lb_ExpertSystems_MouseDoubleClick);
            // 
            // bt_CreateSystem
            // 
            this.bt_CreateSystem.Location = new System.Drawing.Point(31, 265);
            this.bt_CreateSystem.Name = "bt_CreateSystem";
            this.bt_CreateSystem.Size = new System.Drawing.Size(33, 29);
            this.bt_CreateSystem.TabIndex = 1;
            this.bt_CreateSystem.Text = "+";
            this.bt_CreateSystem.UseVisualStyleBackColor = true;
            this.bt_CreateSystem.Click += new System.EventHandler(this.bt_CreateSystem_Click);
            // 
            // bt_RunSystem
            // 
            this.bt_RunSystem.Location = new System.Drawing.Point(252, 265);
            this.bt_RunSystem.Name = "bt_RunSystem";
            this.bt_RunSystem.Size = new System.Drawing.Size(82, 29);
            this.bt_RunSystem.TabIndex = 2;
            this.bt_RunSystem.Text = "Run";
            this.bt_RunSystem.UseVisualStyleBackColor = true;
            this.bt_RunSystem.Click += new System.EventHandler(this.bt_RunSystem_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 513);
            this.Controls.Add(this.bt_RunSystem);
            this.Controls.Add(this.bt_CreateSystem);
            this.Controls.Add(this.lb_ExpertSystems);
            this.Name = "MainScreen";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox lb_ExpertSystems;
        private Button bt_CreateSystem;
        private Button bt_RunSystem;
    }
}