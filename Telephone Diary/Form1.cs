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
            Clear();
            FNameTextBox.Focus();
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            if (FNameTextBox.Text != "" && LNameTextBox.Text != "" && mobileTextBox.Text != "" && mailTextBox.Text != "" && categoryComboBox.SelectedIndex >= 0)
            {
                dataGridView1.Rows.Add(FNameTextBox.Text, LNameTextBox.Text, mobileTextBox.Text, mailTextBox.Text, categoryComboBox.Text);

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
            FNameTextBox.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            LNameTextBox.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            mobileTextBox.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            mailTextBox.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            categoryComboBox.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                if (dataGridView1.CurrentCell.RowIndex > -1)
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        dataGridView1.Rows.RemoveAt(row.Index);
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

                        dataGridView1.Rows[index].Cells[0].Value = FNameTextBox.Text;
                        dataGridView1.Rows[index].Cells[1].Value = LNameTextBox.Text;
                        dataGridView1.Rows[index].Cells[2].Value = mobileTextBox.Text;
                        dataGridView1.Rows[index].Cells[3].Value = mailTextBox.Text;
                        dataGridView1.Rows[index].Cells[4].Value = categoryComboBox.Text;

                        Clear();

                        MessageBox.Show("Record has been updated!");
                    }
                }
            }
        }
    }
}
