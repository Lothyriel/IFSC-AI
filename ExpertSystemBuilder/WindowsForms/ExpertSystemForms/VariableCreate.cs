﻿using RuleEngine.Domain;
using RuleEngine.Domain.ValueTypes;

namespace WindowsForms.ExpertSystemForms
{
    public partial class VariableCreate : Form
    {
        private Builder Builder { get; }

        public VariableCreate(Builder sBuilder)
        {
            InitializeComponent();
            cb_Type.Items.Add(VariableType.Numeric);
            cb_Type.Items.Add(VariableType.Bool);
            cb_Type.Items.Add(VariableType.Objective);
            cb_Type.SelectedIndex = 0;

            bt_AddObjectiveValue.Enabled = false;
            Builder = sBuilder;
            ChangeObjectiveValuesVisibility(false);
        }

        private void ChangeObjectiveValuesVisibility(bool visible)
        {
            var tagControls = new List<Control>();
            foreach (Control control in Controls)
            {
                if ((string)control.Tag == "ObjectiveValue")
                    tagControls.Add(control);
            }
            tagControls.ForEach(control => control.Visible = visible);
        }

        private void bt_Create_Click(object sender, EventArgs e)
        {
            (Value? value, string message) = Builder.CreateValue((VariableType)cb_Type.SelectedItem, tb_Name.Text, tb_Value.Text, cb_UserInputable.Checked, ObjectiveValuesToHashSet());
            if (value == null)
            {
                Utils.ShowErrorMessage(message);
                return;
            }
            Builder.Variables.Add(value);
            MainScreen.Instance!.OpenFormPanel(new EsEdit(Builder));
        }

        private HashSet<string> ObjectiveValuesToHashSet()
        {
            var hashSet = new HashSet<string>();
            foreach (string item in lb_ObjectiveValues.Items)
            {
                hashSet.Add(item);
            }
            return hashSet;
        }

        private void cb_Type_SelectedValueChanged(object sender, EventArgs e)
        {
            ChangeObjectiveValuesVisibility(cb_Type.SelectedItem is VariableType.Objective);
        }

        private void bt_AddObjectiveValue_Click(object sender, EventArgs e)
        {
            lb_ObjectiveValues.Items.Add(tb_ObjectiveNewValue.Text);
            tb_ObjectiveNewValue.Clear();
            SyncObjectiveValuesDataSouce();
        }

        private void SyncObjectiveValuesDataSouce()
        {
            cb_ObjectiveValues.Items.Clear();
            foreach (var item in lb_ObjectiveValues.Items)
                cb_ObjectiveValues.Items.Add(item);
        }

        private void bt_RemoveObjectiveValue_Click(object sender, EventArgs e)
        {
            lb_ObjectiveValues.Items.Remove(lb_ObjectiveValues.SelectedItem);
            SyncObjectiveValuesDataSouce();
        }

        private void lb_ObjectiveValues_SelectedValueChanged(object sender, EventArgs e)
        {
            bt_RemoveObjectiveValue.Enabled = lb_ObjectiveValues.SelectedItem != null;
        }

        private void tb_ObjectivNewValue_TextChanged(object sender, EventArgs e)
        {
            bt_AddObjectiveValue.Enabled = tb_ObjectiveNewValue.Text != "";
        }
    }
}