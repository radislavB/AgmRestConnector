using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hpe.Agm.RestConnector.Views
{
    public partial class NgaAppView : UserControl
    {
        bool firstInitDone = false;
        public NgaAppView()
        {
            InitializeComponent();
        }

        private void NgaAppView_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible && !firstInitDone)
            {
                initialLoad();
            }
        }

        private void initialLoad()
        {

        }


    }
}
