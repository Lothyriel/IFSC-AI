namespace WindowsForms.ExpertSystemForms
{
    partial class ESEdit
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
            this.lb_Variables = new System.Windows.Forms.ListBox();
            this.lb_Rules = new System.Windows.Forms.ListBox();
            this.bt_AddRule = new System.Windows.Forms.Button();
            this.bt_AddVariable = new System.Windows.Forms.Button();
            this.lab_Variables = new System.Windows.Forms.Label();
            this.lab_Rules = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_Variables
            // 
            this.lb_Variables.FormattingEnabled = true;
            this.lb_Variables.ItemHeight = 20;
            this.lb_Variables.Location = new System.Drawing.Point(45, 42);
            this.lb_Variables.Name = "lb_Variables";
            this.lb_Variables.Size = new System.Drawing.Size(208, 104);
            this.lb_Variables.TabIndex = 0;
            // 
            // lb_Rules
            // 
            this.lb_Rules.FormattingEnabled = true;
            this.lb_Rules.ItemHeight = 20;
            this.lb_Rules.Location = new System.Drawing.Point(315, 42);
            this.lb_Rules.Name = "lb_Rules";
            this.lb_Rules.Size = new System.Drawing.Size(217, 104);
            this.lb_Rules.TabIndex = 1;
            // 
            // bt_AddRule
            // 
            this.bt_AddRule.Location = new System.Drawing.Point(497, 152);
            this.bt_AddRule.Name = "bt_AddRule";
            this.bt_AddRule.Size = new System.Drawing.Size(35, 29);
            this.bt_AddRule.TabIndex = 2;
            this.bt_AddRule.Text = "+";
            this.bt_AddRule.UseVisualStyleBackColor = true;
            this.bt_AddRule.Click += new System.EventHandler(this.bt_AddRule_Click);
            // 
            // bt_AddVariable
            // 
            this.bt_AddVariable.Location = new System.Drawing.Point(45, 152);
            this.bt_AddVariable.Name = "bt_AddVariable";
            this.bt_AddVariable.Size = new System.Drawing.Size(35, 29);
            this.bt_AddVariable.TabIndex = 3;
            this.bt_AddVariable.Text = "+";
            this.bt_AddVariable.UseVisualStyleBackColor = true;
            this.bt_AddVariable.Click += new System.EventHandler(this.bt_AddVariable_Click);
            // 
            // lab_Variables
            // 
            this.lab_Variables.AutoSize = true;
            this.lab_Variables.Location = new System.Drawing.Point(45, 9);
            this.lab_Variables.Name = "lab_Variables";
            this.lab_Variables.Size = new System.Drawing.Size(69, 20);
            this.lab_Variables.TabIndex = 4;
            this.lab_Variables.Text = "Variables";
            // 
            // lab_Rules
            // 
            this.lab_Rules.AutoSize = true;
            this.lab_Rules.Location = new System.Drawing.Point(488, 9);
            this.lab_Rules.Name = "lab_Rules";
            this.lab_Rules.Size = new System.Drawing.Size(44, 20);
            this.lab_Rules.TabIndex = 5;
            this.lab_Rules.Text = "Rules";
            // 
            // ESEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 309);
            this.Controls.Add(this.lab_Rules);
            this.Controls.Add(this.lab_Variables);
            this.Controls.Add(this.bt_AddVariable);
            this.Controls.Add(this.bt_AddRule);
            this.Controls.Add(this.lb_Rules);
            this.Controls.Add(this.lb_Variables);
            this.Name = "ESEdit";
            this.Text = "ES";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox lb_Variables;
        private ListBox lb_Rules;
        private Button bt_AddRule;
        private Button bt_AddVariable;
        private Label lab_Variables;
        private Label lab_Rules;
    }
}