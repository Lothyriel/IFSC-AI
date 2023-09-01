using RuleEngine.Domain.Results;
using RuleEngine.Domain.Rules;
using RuleEngine.Domain.ValueTypes;

namespace WindowsForms.ExpertSystemForms
{
    public partial class RuleCreate : Form
    {
        public RuleCreate(ESBuilder eSBuilder)
        {
            InitializeComponent();
            ESBuilder = eSBuilder;

            cb_Variables.DataSource = eSBuilder.Variables;

            bt_Create.Enabled = false;
        }

        private void SyncOperationTypes(VariableType type)
        {
            cb_OperationTypes.Items.Clear();
            cb_OperationTypes.Items.Add(OperatorType.Equals);
            cb_OperationTypes.Items.Add(OperatorType.NotEquals);
            cb_OperationTypes.SelectedIndex = 0;

            if (type > VariableType.Numeric)
                return;

            cb_OperationTypes.Items.Add(OperatorType.Lesser);
            cb_OperationTypes.Items.Add(OperatorType.Greater);
            cb_OperationTypes.Items.Add(OperatorType.LesserOrEquals);
            cb_OperationTypes.Items.Add(OperatorType.GreaterOrEquals);
        }

        public ESBuilder ESBuilder { get; }

        private void bt_Create_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();

            //var variable = (ValueBase)cb_Variables.SelectedItem;

            //var result = Result.Create(variable, );

            //var targetValue = cb_Variables.SelectedItem is ObjectiveValue ? (string)cb_ObjectiveTargetValue.SelectedItem : tb_TargetValue.Text;
            //(ActionRule? value, string message) = ActionRule.Create(tb_Name.Text, (OperatorType)cb_OperationTypes.SelectedItem, variable, targetValue, result);

            //if (value is null)
            //{
            //    Utils.ShowErrorMessage(message);
            //    return;
            //}
            //ESBuilder.Rules.Add(value);
            //MainScreen.Instance!.OpenFormPanel(new ESEdit(ESBuilder));
        }

        private void tb_TargetValue_TextChanged(object sender, EventArgs e)
        {
            bt_Create.Enabled = tb_TargetValue.Text != "";
        }

        private void cb_Variables_SelectedValueChanged(object sender, EventArgs e)
        {
            SyncOperationTypes(((ValueBase)cb_Variables.SelectedItem).Type);

            cb_ObjectiveTargetValue.Visible = cb_Variables.SelectedItem is ObjectiveValue;
            if (cb_Variables.SelectedItem is ObjectiveValue objValue)
            {
                SyncObjectiveValues(objValue);
            }
        }

        private void SyncObjectiveValues(ObjectiveValue objValue)
        {
            cb_ObjectiveTargetValue.Items.Clear();
            foreach (var item in objValue.PossibleValues)
            {
                cb_ObjectiveTargetValue.Items.Add(item);
            }
        }
    }
}