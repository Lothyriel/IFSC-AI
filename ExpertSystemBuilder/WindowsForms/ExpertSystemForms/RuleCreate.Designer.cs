namespace WindowsForms.ExpertSystemForms
{
    partial class RuleCreate
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
            this.tb_TargetValue = new System.Windows.Forms.TextBox();
            this.cb_Variables = new System.Windows.Forms.ComboBox();
            this.cb_OperationTypes = new System.Windows.Forms.ComboBox();
            this.bt_Create = new System.Windows.Forms.Button();
            this.tb_Name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_complexRules = new System.Windows.Forms.ListBox();
            this.cb_ObjectiveTargetValue = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // tb_TargetValue
            // 
            this.tb_TargetValue.Location = new System.Drawing.Point(377, 106);
            this.tb_TargetValue.Name = "tb_TargetValue";
            this.tb_TargetValue.Size = new System.Drawing.Size(125, 27);
            this.tb_TargetValue.TabIndex = 0;
            this.tb_TargetValue.TextChanged += new System.EventHandler(this.tb_TargetValue_TextChanged);
            // 
            // cb_Variables
            // 
            this.cb_Variables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Variables.FormattingEnabled = true;
            this.cb_Variables.Location = new System.Drawing.Point(26, 105);
            this.cb_Variables.Name = "cb_Variables";
            this.cb_Variables.Size = new System.Drawing.Size(151, 28);
            this.cb_Variables.TabIndex = 1;
            this.cb_Variables.SelectedValueChanged += new System.EventHandler(this.cb_Variables_SelectedValueChanged);
            // 
            // cb_OperationTypes
            // 
            this.cb_OperationTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_OperationTypes.FormattingEnabled = true;
            this.cb_OperationTypes.Location = new System.Drawing.Point(200, 105);
            this.cb_OperationTypes.Name = "cb_OperationTypes";
            this.cb_OperationTypes.Size = new System.Drawing.Size(151, 28);
            this.cb_OperationTypes.TabIndex = 2;
            // 
            // bt_Create
            // 
            this.bt_Create.Location = new System.Drawing.Point(228, 163);
            this.bt_Create.Name = "bt_Create";
            this.bt_Create.Size = new System.Drawing.Size(94, 29);
            this.bt_Create.TabIndex = 3;
            this.bt_Create.Text = "Create";
            this.bt_Create.UseVisualStyleBackColor = true;
            this.bt_Create.Click += new System.EventHandler(this.bt_Create_Click);
            // 
            // tb_Name
            // 
            this.tb_Name.Location = new System.Drawing.Point(33, 47);
            this.tb_Name.Name = "tb_Name";
            this.tb_Name.Size = new System.Drawing.Size(125, 27);
            this.tb_Name.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(377, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Target Value:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Rule Name:";
            // 
            // lb_complexRules
            // 
            this.lb_complexRules.FormattingEnabled = true;
            this.lb_complexRules.ItemHeight = 20;
            this.lb_complexRules.Location = new System.Drawing.Point(388, 144);
            this.lb_complexRules.Name = "lb_complexRules";
            this.lb_complexRules.Size = new System.Drawing.Size(207, 164);
            this.lb_complexRules.TabIndex = 7;
            // 
            // cb_ObjectiveTargetValue
            // 
            this.cb_ObjectiveTargetValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ObjectiveTargetValue.FormattingEnabled = true;
            this.cb_ObjectiveTargetValue.Location = new System.Drawing.Point(377, 105);
            this.cb_ObjectiveTargetValue.Name = "cb_ObjectiveTargetValue";
            this.cb_ObjectiveTargetValue.Size = new System.Drawing.Size(151, 28);
            this.cb_ObjectiveTargetValue.TabIndex = 8;
            // 
            // RuleCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 326);
            this.Controls.Add(this.cb_ObjectiveTargetValue);
            this.Controls.Add(this.lb_complexRules);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_Name);
            this.Controls.Add(this.bt_Create);
            this.Controls.Add(this.cb_OperationTypes);
            this.Controls.Add(this.cb_Variables);
            this.Controls.Add(this.tb_TargetValue);
            this.Name = "RuleCreate";
            this.Text = "RuleCreate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox tb_TargetValue;
        private ComboBox cb_Variables;
        private ComboBox cb_OperationTypes;
        private Button bt_Create;
        private TextBox tb_Name;
        private Label label1;
        private Label label2;
        private ListBox lb_complexRules;
        private ComboBox cb_ObjectiveTargetValue;
    }
}