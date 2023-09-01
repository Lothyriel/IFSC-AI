namespace WindowsForms
{
    public partial class MainScreen : Form
    {
        public static MainScreen? Instance { get; private set; }

        private List<Form> Forms { get; }
        public MainScreen()
        {
            Instance = this;
            Forms = new();
            InitializeComponent();
            OpenFormPanel(new ExpertSystemsView());
        }
        public void OpenFormPanel(Form panelForm)
        {
            Forms.Add(panelForm);
            panelForm.TopLevel = false;
            panelForm.FormBorderStyle = FormBorderStyle.None;
            panelForm.Dock = DockStyle.Fill;

            Panel.Controls.Clear();
            Panel.Controls.Add(panelForm);

            panelForm.BringToFront();
            panelForm.Show();
        }
        public bool GetBack()
        {
            var index = Forms.Count - 1;
            var lastForm = Forms.ElementAt(index);
            if (lastForm is not ExpertSystemsView && index != 0)
            {
                OpenFormPanel(lastForm);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void MainScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = GetBack();
        }
    }
}
