namespace WindowsForms.ExpertSystemForms
{
    partial class VariableCreate
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
            this.bt_Create = new System.Windows.Forms.Button();
            this.cb_Type = new System.Windows.Forms.ComboBox();
            this.lb_Name = new System.Windows.Forms.Label();
            this.tb_Name = new System.Windows.Forms.TextBox();
            this.tb_Value = new System.Windows.Forms.TextBox();
            this.lb_ObjectiveValues = new System.Windows.Forms.ListBox();
            this.bt_AddObjectiveValue = new System.Windows.Forms.Button();
            this.bt_RemoveObjectiveValue = new System.Windows.Forms.Button();
            this.lb_Value = new System.Windows.Forms.Label();
            this.cb_ObjectiveValues = new System.Windows.Forms.ComboBox();
            this.tb_ObjectiveNewValue = new System.Windows.Forms.TextBox();
            this.cb_UserInputable = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // bt_Create
            // 
            this.bt_Create.Location = new System.Drawing.Point(42, 203);
            this.bt_Create.Name = "bt_Create";
            this.bt_Create.Size = new System.Drawing.Size(94, 29);
            this.bt_Create.TabIndex = 0;
            this.bt_Create.Text = "Create";
            this.bt_Create.UseVisualStyleBackColor = true;
            this.bt_Create.Click += new System.EventHandler(this.bt_Create_Click);
            // 
            // cb_Type
            // 
            this.cb_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Type.FormattingEnabled = true;
            this.cb_Type.Location = new System.Drawing.Point(42, 79);
            this.cb_Type.Name = "cb_Type";
            this.cb_Type.Size = new System.Drawing.Size(192, 28);
            this.cb_Type.TabIndex = 1;
            this.cb_Type.SelectedValueChanged += new System.EventHandler(this.cb_Type_SelectedValueChanged);
            // 
            // lb_Name
            // 
            this.lb_Name.AutoSize = true;
            this.lb_Name.Location = new System.Drawing.Point(42, 28);
            this.lb_Name.Name = "lb_Name";
            this.lb_Name.Size = new System.Drawing.Size(52, 20);
            this.lb_Name.TabIndex = 2;
            this.lb_Name.Text = "Name:";
            // 
            // tb_Name
            // 
            this.tb_Name.Location = new System.Drawing.Point(109, 25);
            this.tb_Name.Name = "tb_Name";
            this.tb_Name.Size = new System.Drawing.Size(125, 27);
            this.tb_Name.TabIndex = 3;
            // 
            // tb_Value
            // 
            this.tb_Value.Location = new System.Drawing.Point(109, 125);
            this.tb_Value.Name = "tb_Value";
            this.tb_Value.Size = new System.Drawing.Size(125, 27);
            this.tb_Value.TabIndex = 4;
            // 
            // lb_ObjectiveValues
            // 
            this.lb_ObjectiveValues.FormattingEnabled = true;
            this.lb_ObjectiveValues.ItemHeight = 20;
            this.lb_ObjectiveValues.Location = new System.Drawing.Point(272, 25);
            this.lb_ObjectiveValues.Name = "lb_ObjectiveValues";
            this.lb_ObjectiveValues.Size = new System.Drawing.Size(193, 104);
            this.lb_ObjectiveValues.TabIndex = 5;
            this.lb_ObjectiveValues.Tag = "ObjectiveValue";
            this.lb_ObjectiveValues.SelectedValueChanged += new System.EventHandler(this.lb_ObjectiveValues_SelectedValueChanged);
            // 
            // bt_AddObjectiveValue
            // 
            this.bt_AddObjectiveValue.Location = new System.Drawing.Point(272, 145);
            this.bt_AddObjectiveValue.Name = "bt_AddObjectiveValue";
            this.bt_AddObjectiveValue.Size = new System.Drawing.Size(33, 29);
            this.bt_AddObjectiveValue.TabIndex = 6;
            this.bt_AddObjectiveValue.Tag = "ObjectiveValue";
            this.bt_AddObjectiveValue.Text = "+";
            this.bt_AddObjectiveValue.UseVisualStyleBackColor = true;
            this.bt_AddObjectiveValue.Click += new System.EventHandler(this.bt_AddObjectiveValue_Click);
            // 
            // bt_RemoveObjectiveValue
            // 
            this.bt_RemoveObjectiveValue.Location = new System.Drawing.Point(432, 145);
            this.bt_RemoveObjectiveValue.Name = "bt_RemoveObjectiveValue";
            this.bt_RemoveObjectiveValue.Size = new System.Drawing.Size(33, 29);
            this.bt_RemoveObjectiveValue.TabIndex = 7;
            this.bt_RemoveObjectiveValue.Tag = "ObjectiveValue";
            this.bt_RemoveObjectiveValue.Text = "-";
            this.bt_RemoveObjectiveValue.UseVisualStyleBackColor = true;
            this.bt_RemoveObjectiveValue.Click += new System.EventHandler(this.bt_RemoveObjectiveValue_Click);
            // 
            // lb_Value
            // 
            this.lb_Value.AutoSize = true;
            this.lb_Value.Location = new System.Drawing.Point(42, 132);
            this.lb_Value.Name = "lb_Value";
            this.lb_Value.Size = new System.Drawing.Size(48, 20);
            this.lb_Value.TabIndex = 8;
            this.lb_Value.Text = "Value:";
            // 
            // cb_ObjectiveValues
            // 
            this.cb_ObjectiveValues.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ObjectiveValues.FormattingEnabled = true;
            this.cb_ObjectiveValues.Location = new System.Drawing.Point(109, 125);
            this.cb_ObjectiveValues.Name = "cb_ObjectiveValues";
            this.cb_ObjectiveValues.Size = new System.Drawing.Size(125, 28);
            this.cb_ObjectiveValues.TabIndex = 9;
            this.cb_ObjectiveValues.Tag = "ObjectiveValue";
            // 
            // tb_ObjectiveNewValue
            // 
            this.tb_ObjectiveNewValue.AcceptsReturn = true;
            this.tb_ObjectiveNewValue.Location = new System.Drawing.Point(311, 147);
            this.tb_ObjectiveNewValue.Name = "tb_ObjectiveNewValue";
            this.tb_ObjectiveNewValue.Size = new System.Drawing.Size(114, 27);
            this.tb_ObjectiveNewValue.TabIndex = 10;
            this.tb_ObjectiveNewValue.Tag = "ObjectiveValue";
            this.tb_ObjectiveNewValue.TextChanged += new System.EventHandler(this.tb_ObjectivNewValue_TextChanged);
            // 
            // cb_UserInputable
            // 
            this.cb_UserInputable.AutoSize = true;
            this.cb_UserInputable.Location = new System.Drawing.Point(158, 208);
            this.cb_UserInputable.Name = "cb_UserInputable";
            this.cb_UserInputable.Size = new System.Drawing.Size(127, 24);
            this.cb_UserInputable.TabIndex = 11;
            this.cb_UserInputable.Text = "User Inputable";
            this.cb_UserInputable.UseVisualStyleBackColor = true;
            // 
            // VariableCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 296);
            this.Controls.Add(this.cb_UserInputable);
            this.Controls.Add(this.tb_ObjectiveNewValue);
            this.Controls.Add(this.cb_ObjectiveValues);
            this.Controls.Add(this.lb_Value);
            this.Controls.Add(this.bt_RemoveObjectiveValue);
            this.Controls.Add(this.bt_AddObjectiveValue);
            this.Controls.Add(this.lb_ObjectiveValues);
            this.Controls.Add(this.tb_Value);
            this.Controls.Add(this.tb_Name);
            this.Controls.Add(this.lb_Name);
            this.Controls.Add(this.cb_Type);
            this.Controls.Add(this.bt_Create);
            this.Name = "VariableCreate";
            this.Text = "VariableCreate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button bt_Create;
        private ComboBox cb_Type;
        private Label lb_Name;
        private TextBox tb_Name;
        private TextBox tb_Value;
        private ListBox lb_ObjectiveValues;
        private Button bt_AddObjectiveValue;
        private Button bt_RemoveObjectiveValue;
        private Label lb_Value;
        private ComboBox cb_ObjectiveValues;
        private TextBox tb_ObjectiveNewValue;
        private CheckBox cb_UserInputable;
    }
}