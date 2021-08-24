using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telephone_Diary
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            FNameTextBox.Text = "";
            LNameTextBox.Text = "";
            mobileTextBox.Text = "";
            mailTextBox.Text = "";
            categoryComboBox.SelectedIndex = -1;

            FNameTextBox.Focus();
        }
    }
}
