﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymApp
{
    public partial class Trainers : Form
    {
        Functions Con;

        public Trainers()
        {
            InitializeComponent();
            Con = new Functions();
            ShowTrainers();
            GridViewTrainers.SelectionChanged += GridViewTrainers_SelectionChanged;
        }
        private void Reset()
        {
            TrainerFName.Text = string.Empty;
            TrainerLName.Text = string.Empty;
            TrainerDOB.Text = string.Empty;
            TrainerPhone.Text = string.Empty;
            Experience.Text = string.Empty;
            Address.Text = string.Empty;
            Gender.Text = string.Empty;
            BloodType.Text = string.Empty;
        }

        private void ShowTrainers()
        {
            string Query = "Select TrainersTable.TrainerID, TrainersTable.TrainerFName , TrainersTable.TrainerLName , TrainersTable.TrainerDOB, TrainersTable.TrainerPhone, TrainersTable.Experience, TrainersTable.Address, TrainersTable.Gender, TrainersTable.BloodType from TrainersTable";
            GridViewTrainers.DataSource = Con.GetData(Query);
            GridViewTrainers.ClearSelection();
        }
        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (TrainerFName.Text == "" || TrainerLName.Text == "" || TrainerPhone.Text == "" || Experience.SelectedIndex == -1 || Address.Text == "" || Gender.SelectedIndex == -1 || BloodType.SelectedIndex == -1)
                {
                    MessageBox.Show("Please enter the required fields!!");
                }
                else
                {
                    string FirstName = TrainerFName.Text;
                    string LastName = TrainerLName.Text;
                    string Number = TrainerPhone.Text;
                    int Exp = Convert.ToInt32(Experience.SelectedItem.ToString());
                    string Add = Address.Text;
                    string Gen = Gender.Text;
                    string Blood = BloodType.Text;
                    string Query = "Insert into TrainersTable Values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')";
                    Query = string.Format(Query, FirstName, LastName, TrainerDOB.Value.Date, Number, Exp, Add, Gen, Blood);
                    Con.setData(Query);
                    ShowTrainers();
                    MessageBox.Show("New Trainer Added");
                    Reset();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            try
            {
                if (TrainerFName.Text == "" || TrainerLName.Text == "" || TrainerPhone.Text == "" || Experience.SelectedIndex == -1 || Address.Text == "" || Gender.SelectedIndex == -1 || BloodType.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select the row!!");
                }
                else
                {
                    int Key = int.Parse(GridViewTrainers.CurrentRow.Cells[0].Value.ToString());
                    string FirstName = TrainerFName.Text;
                    string LastName = TrainerLName.Text;
                    string Number = TrainerPhone.Text;
                    int Exp = Convert.ToInt32(Experience.SelectedItem.ToString());
                    string Add = Address.Text;
                    string Gen = Gender.Text;
                    string Blood = BloodType.Text;
                    string Query = "Update TrainersTable set TrainerFName = '{0}', TrainerLName = '{1}', TrainerDOB = '{2}', TrainerPhone = '{3}', Experience = '{4}', Address = '{5}', Gender = '{6}', BloodType = '{7}' Where TrainerID = {8}";
                    Query = string.Format(Query, FirstName, LastName, TrainerDOB.Value.Date, Number, Exp, Add, Gen, Blood, Key);
                    Con.setData(Query);
                    ShowTrainers();
                    MessageBox.Show("Trainer Updated");
                    Reset();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (TrainerFName.Text == "" || TrainerLName.Text == "" || TrainerPhone.Text == "" || Experience.SelectedIndex == -1 || Address.Text == "" || Gender.SelectedIndex == -1 || BloodType.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select the row!!");
                }
                else
                {
                    int Key = int.Parse(GridViewTrainers.CurrentRow.Cells[0].Value.ToString());
                    string Query = "Delete from TrainersTable where TrainerID = {0}";
                    Query = string.Format(Query, Key);
                    Con.setData(Query);
                    ShowTrainers();
                    MessageBox.Show("Trainer Deleted");
                    Reset();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void GridViewTrainers_SelectionChanged(object sender, EventArgs e)
        {
            if (GridViewTrainers.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = GridViewTrainers.SelectedRows[0];
              
                    //string[] Trainer = dataGridView1.SelectedRows[0].Cells[1].Value.ToString().Split(' ');
                    //TrainerFName.Text = Trainer[0];
                    //TrainerLName.Text = Trainer[1];

                TrainerFName.Text = GridViewTrainers.SelectedRows[0].Cells[1].Value.ToString();
                TrainerLName.Text = GridViewTrainers.SelectedRows[0].Cells[2].Value.ToString();
                TrainerDOB.Text = GridViewTrainers.SelectedRows[0].Cells[3].Value.ToString();
                TrainerPhone.Text = GridViewTrainers.SelectedRows[0].Cells[4].Value.ToString();
                Experience.Text = GridViewTrainers.SelectedRows[0].Cells[5].Value.ToString();
                Address.Text = GridViewTrainers.SelectedRows[0].Cells[6].Value.ToString();
                Gender.Text = GridViewTrainers.SelectedRows[0].Cells[7].Value.ToString();
                BloodType.Text = GridViewTrainers.SelectedRows[0].Cells[8].Value.ToString();
            }
        }

        private void Trainers_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetTrainers.TrainersTable' table. You can move, or remove it, as needed.
            this.trainersTableTableAdapter.Fill(this.dataSetTrainers.TrainersTable);
        }

        private void TrainersLbl_Click(object sender, EventArgs e)
        {
            Payments Obj = new Payments();
            Obj.Show();
            this.Hide();
        }

        private void MemberLbl_Click(object sender, EventArgs e)
        {
            Members Obj = new Members();
            Obj.Show();
            this.Hide();
        }

        private void MemberShipLbl_Click(object sender, EventArgs e)
        {
            Memberships Obj = new Memberships();
            Obj.Show();
            this.Hide();
        }

        private void PaymentLbl_Click(object sender, EventArgs e)
        {
            Payments Obj = new Payments();
            Obj.Show();
            this.Hide();
        }

        private void BillsLbl_Click(object sender, EventArgs e)
        {
            Bills Obj = new Bills();
            Obj.Show();
            this.Hide();
        }
    }
}