using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hpe.Agm.RestConnector.Core
{
    public partial class GetNameDialog : Form
    {
        public GetNameDialog()
        {
            InitializeComponent();
            DisableOkOnEmptyName();
        }

        public String SelectedName
        {
            get
            {
                return txtName.Text;
            }
            set
            {
                txtName.Text = value;
            }
        }

        private void DisableOkOnEmptyName()
        {
            btnOk.Enabled = !String.IsNullOrEmpty(SelectedName);
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            DisableOkOnEmptyName();
        }
    }
}
