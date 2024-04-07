using RuleEngine.Domain;

namespace WindowsForms.ExpertSystemForms
{
    public partial class EsEdit : Form
    {
        public EsEdit(Builder sBuilder)
        {
            InitializeComponent();
            Builder = sBuilder;
            lb_Rules.DataSource = sBuilder.Rules;
            lb_Variables.DataSource = sBuilder.Variables;
        }

        public Builder Builder { get; }

        private void bt_AddRule_Click(object sender, EventArgs e)
        {
            if (!Builder.Variables.Any())
            {
                MessageBox.Show($"You need at least a variable to create a new Rule", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MainScreen.Instance!.OpenFormPanel(new RuleCreate(Builder));
        }

        private void bt_AddVariable_Click(object sender, EventArgs e)
        {
            MainScreen.Instance!.OpenFormPanel(new VariableCreate(Builder));
        }
    }
}