using RuleEngine.Domain;
using WindowsForms.ExpertSystemForms;

namespace WindowsForms
{
    public partial class ExpertSystemsView : Form
    {
        public static ExpertSystemsView? Instance { get; set; }

        public ExpertSystemsView()
        {
            Instance = this;
            InitializeComponent();
            bt_RunSystem.Enabled = false;
        }

        #region Events

        private void bt_RunSystem_Click(object sender, EventArgs e)
        {
            MainScreen.Instance!.OpenFormPanel(new ESRun((ExpertSystem)lb_ExpertSystems.SelectedItem));
        }

        private void lb_ExpertSystems_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = lb_ExpertSystems.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                MainScreen.Instance!.OpenFormPanel(new ESEdit(new ESBuilder((ExpertSystem)lb_ExpertSystems.SelectedItem)));
            }
        }

        private void lb_ExpertSystems_MouseClick(object sender, MouseEventArgs e)
        {
            if (lb_ExpertSystems.SelectedItem != null)
            {
                bt_RunSystem.Enabled = true;
            }
        }

        private void bt_CreateSystem_Click(object sender, EventArgs e)
        {
            MainScreen.Instance!.OpenFormPanel(new ESEdit(new ESBuilder()));
        }

        #endregion
    }
}