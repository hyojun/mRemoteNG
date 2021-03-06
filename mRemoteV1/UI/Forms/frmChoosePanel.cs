using System.Windows.Forms;
using mRemoteNG.App;
using mRemoteNG.UI.Forms.Input;
using mRemoteNG.UI.Panels;

namespace mRemoteNG.UI.Forms
{
	public partial class frmChoosePanel
	{
	    private readonly PanelAdder _panelAdder;

		public frmChoosePanel()
		{
			InitializeComponent();
            _panelAdder = new PanelAdder();
		}
        public string Panel
		{
			get
			{
				return cbPanels.SelectedItem.ToString();
			}
			set
			{
				cbPanels.SelectedItem = value;
			}
		}

	    private void frmChoosePanel_Load(object sender, System.EventArgs e)
		{
			ApplyLanguage();
			
			AddAvailablePanels();
		}
		
		private void ApplyLanguage()
		{
			btnOK.Text = Language.strButtonOK;
			lblDescription.Text = Language.strLabelSelectPanel;
			btnNew.Text = Language.strButtonNew;
			btnCancel.Text = Language.strButtonCancel;
			Text = Language.strTitleSelectPanel;
		}
		
		private void AddAvailablePanels()
		{
			cbPanels.Items.Clear();
			
			for (int i = 0; i <= Runtime.WindowList.Count - 1; i++)
			{
                cbPanels.Items.Add(Runtime.WindowList[i].Text.Replace("&&", "&"));
			}
			
			if (cbPanels.Items.Count > 0)
			{
				cbPanels.SelectedItem = cbPanels.Items[0];
				cbPanels.Enabled = true;
				btnOK.Enabled = true;
			}
			else
			{
				cbPanels.Enabled = false;
				btnOK.Enabled = false;
			}
		}

	    private void btnNew_Click(object sender, System.EventArgs e)
		{
		    var pnlName = Language.strNewPanel;
			
			if (input.InputBox(Language.strNewPanel, Language.strPanelName + ":", ref pnlName) == DialogResult.OK && !string.IsNullOrEmpty(pnlName))
			{
                _panelAdder.AddPanel(pnlName);
				AddAvailablePanels();
				cbPanels.SelectedItem = pnlName;
				cbPanels.Focus();
			}
		}

	    private void btnOK_Click(object sender, System.EventArgs e)
		{
            DialogResult = DialogResult.OK;
		}

	    private void btnCancel_Click(object sender, System.EventArgs e)
		{
            DialogResult = DialogResult.Cancel;
		}
	}
}
