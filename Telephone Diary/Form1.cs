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
        DataTable table;

        public Form1()
        {
            InitializeComponent();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            Clear();
            FNameTextBox.Focus();
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            if (FNameTextBox.Text != "" && LNameTextBox.Text != "" && mobileTextBox.Text != "" && mailTextBox.Text != "" && categoryComboBox.SelectedIndex >= 0)
            {
                table.Rows.Add(FNameTextBox.Text, LNameTextBox.Text, mobileTextBox.Text, mailTextBox.Text, categoryComboBox.Text);

                Clear();
                FNameTextBox.Focus();

                MessageBox.Show("Record has been saved!");
            }
        }

        void Clear()
        {
            FNameTextBox.Text = "";
            LNameTextBox.Text = "";
            mobileTextBox.Text = "";
            mailTextBox.Text = "";
            categoryComboBox.SelectedIndex = -1;
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;

            FNameTextBox.Text = table.Rows[index].ItemArray[0].ToString();
            LNameTextBox.Text = table.Rows[index].ItemArray[1].ToString();
            mobileTextBox.Text = table.Rows[index].ItemArray[2].ToString();
            mailTextBox.Text = table.Rows[index].ItemArray[3].ToString();
            categoryComboBox.Text = table.Rows[index].ItemArray[4].ToString();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                if (dataGridView1.CurrentCell.RowIndex > -1)
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        table.Rows[row.Index].Delete();
                    }

                    Clear();

                    MessageBox.Show("Record has been deleted!");
                }
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (FNameTextBox.Text != "" && LNameTextBox.Text != "" && mobileTextBox.Text != "" && mailTextBox.Text != "" && categoryComboBox.SelectedIndex >= 0)
            {
                if (dataGridView1.Rows.Count != 0)
                {
                    if (dataGridView1.CurrentCell.RowIndex > -1)
                    {
                        int index = dataGridView1.CurrentCell.RowIndex;

                        table.Rows[index].SetField(0, FNameTextBox.Text);
                        table.Rows[index].SetField(1, LNameTextBox.Text);
                        table.Rows[index].SetField(2, mobileTextBox.Text);
                        table.Rows[index].SetField(3, mailTextBox.Text);
                        table.Rows[index].SetField(4, categoryComboBox.Text);

                        Clear();

                        MessageBox.Show("Record has been updated!");
                    }
                }
            }
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            DataView dv = table.DefaultView;
            dv.RowFilter = "LastName LIKE '" + searchBox.Text + "%'";
            dataGridView1.DataSource = dv;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            table = new DataTable();

            table.Columns.Add("FirstName", typeof(string));
            table.Columns.Add("LastName", typeof(string));
            table.Columns.Add("Mobile", typeof(string));
            table.Columns.Add("Mail", typeof(string));
            table.Columns.Add("Category", typeof(string));

            dataGridView1.DataSource = table;
        }
    }
}
