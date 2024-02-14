using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelExpertsGUI.PanelAction
{
    public static class OpenFormInPanel
    {
        public static void openFormInPanel(Form startForm, Form subForm, Panel panel)
        {
            if (subForm is not Form)//if input is not form object
            {
                return;
            }

            // Set TopLevel property to false to indicate that this form is a child form
            subForm.TopLevel = false;

            // Clear the panel before adding a new form to it
            panel.Controls.Clear();

            // Add the subForm to the panel's Controls collection
            panel.Controls.Add(subForm);

            // Set the subForm's Dock property to Fill to make it fill the panel
            subForm.Dock = DockStyle.Fill;

            // Show the subForm within the panel
            subForm.Show();
        }
    }
}
