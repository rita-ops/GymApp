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
    public partial class Payments : Form
    {
        Functions Con;
        public Payments()
        {
            InitializeComponent();
            Con = new Functions();
            ShowPayments();
            GridViewPayments.SelectionChanged += GridViewPayments_SelectionChanged;
        }

        private void ShowPayments()
        {
            string Query = "Select PaymentID, ClientName, Date, Phone, Amount, Currency from PaymentsTable";
            GridViewPayments.DataSource = Con.GetData(Query);
            GridViewPayments.ClearSelection();
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

        private void TrainersLbl_Click(object sender, EventArgs e)
        {
            Trainers Obj = new Trainers();
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

        private void Reset()
        {
            ClientName.Text = string.Empty;
            Phone.Text = string.Empty;
            Amount.Text = string.Empty;
            Currency.Text = string.Empty;
        }


        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClientName.SelectedIndex == -1 ||  Amount.Text=="" || Currency.SelectedIndex == -1)
                {
                    MessageBox.Show("Please fill required fields!!");
                }
                else
                {
                    string Client = ClientName.SelectedItem.ToString();
                    string date = Date.Value.Date.ToString();
                    string Number = Phone.Text;
                    string Amoun = Amount.Text;
                    string Curr = Currency.SelectedItem.ToString();
                    string Query = "Insert into PaymentsTable Values('{0}','{1}','{2}','{3}','{4}')";
                    Query = string.Format(Query, Client, date, Number, Amoun, Curr);
                    Con.setData(Query);
                    ShowPayments();
                    MessageBox.Show("Payment Added");
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
                if (ClientName.SelectedIndex == -1 || Phone.Text == "" || Amount.Text == "" || Currency.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a row!!");
                }
                else
                {
                    int Key = int.Parse(GridViewPayments.CurrentRow.Cells[0].Value.ToString());
                    string Client = ClientName.SelectedItem.ToString();
                    string date = Date.Value.Date.ToString();
                    string Number = Phone.Text;
                    string Amoun = Amount.Text;
                    string Curr = Currency.SelectedItem.ToString();
                    string Query = "Update PaymentsTable set ClientName = '{0}', Date = '{1}', Phone = '{2}', Amount = '{3}', Currency = '{4}' Where PaymentID = {5}";
                    Query = string.Format(Query, Client, Date.Value.Date, Number, Amoun, Curr, Key);
                    Con.setData(Query);
                    ShowPayments();
                    MessageBox.Show("Payment Updated");
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
                if (ClientName.SelectedIndex == -1 || Phone.Text == "" || Amount.Text == "" || Currency.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select the row!!");
                }
                else
                {
                    int Key = int.Parse(GridViewPayments.CurrentRow.Cells[0].Value.ToString());
                    string Query = "Delete from PaymentsTable where PaymentID = {0}";
                    Query = string.Format(Query, Key);
                    Con.setData(Query);
                    ShowPayments();
                    MessageBox.Show("Payment Deleted");
                    Reset();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void Payments_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetPayments.PaymentsTable' table. You can move, or remove it, as needed.
            this.paymentsTableTableAdapter.Fill(this.dataSetPayments.PaymentsTable);

        }

        private void GridViewPayments_SelectionChanged(object sender, EventArgs e)
        {
            if (GridViewPayments.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = GridViewPayments.SelectedRows[0];

                ClientName.Text = GridViewPayments.CurrentRow.Cells[1].Value.ToString();
                Date.Text = GridViewPayments.CurrentRow.Cells[2].Value.ToString();
                Phone.Text = GridViewPayments.CurrentRow.Cells[3].Value.ToString();
                Amount.Text = GridViewPayments.CurrentRow.Cells[4].Value.ToString();
                Currency.Text = GridViewPayments.CurrentRow.Cells[5].Value.ToString();
            }
        }

  
    }
}
