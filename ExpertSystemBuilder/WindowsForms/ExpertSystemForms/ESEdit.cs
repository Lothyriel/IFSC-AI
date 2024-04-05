using RuleEngine.Domain;

namespace WindowsForms.ExpertSystemForms
{
    public partial class ESEdit : Form
    {
        public ESEdit(EsBuilder eSBuilder)
        {
            InitializeComponent();
            ESBuilder = eSBuilder;
            lb_Rules.DataSource = eSBuilder.Rules;
            lb_Variables.DataSource = eSBuilder.Variables;
        }

        public EsBuilder ESBuilder { get; }

        private void bt_AddRule_Click(object sender, EventArgs e)
        {
            if (!ESBuilder.Variables.Any())
            {
                MessageBox.Show($"You need at least a variable to create a new Rule", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MainScreen.Instance!.OpenFormPanel(new RuleCreate(ESBuilder));
        }

        private void bt_AddVariable_Click(object sender, EventArgs e)
        {
            MainScreen.Instance!.OpenFormPanel(new VariableCreate(ESBuilder));
        }
    }
}