using System;
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
    public partial class Members : Form
    {
        Functions Con;
        public Members()
        {
            InitializeComponent();
            Con = new Functions();
            ShowMembers();
            GetTrainers();
            GetMemberships();
            GridViewMembers.Columns[0].Visible = false;
            GridViewMembers.Columns[4].Visible = false;
            GridViewMembers.Columns[10].Visible = false;
            GridViewMembers.Columns[2].HeaderText = "Date Of Birth";
            GridViewMembers.SelectionChanged += GridViewMembers_SelectionChanged;
        }

        private void ShowMembers()
        {
            string Query = " SELECT MembersTable.MembersID, CONCAT(MembersTable.MemberFName ,' ', MembersTable.MemberLName ,' ') AS Member, MembersTable.MemberDOB, MembersTable.JoinDate, MembershipsTable.MembershipID , MembershipsTable.MembershipType, MembersTable.Phone, MembersTable.Timing, MembersTable.BloodType, MembersTable.Gender,  TrainersTable.TrainerID , Concat(TrainersTable.TrainerFName ,' ' , TrainersTable.TrainerLName) AS Trainer  FROM MembersTable JOIN MembershipsTable ON MembersTable.MembershipID = MembershipsTable.MembershipID JOIN TrainersTable ON MembersTable.TrainerID = TrainersTable.TrainerID ";
            GridViewMembers.DataSource = Con.GetData(Query);
            GridViewMembers.ClearSelection();
        }

        private void GetTrainers()
        {
            string Query = "Select TrainerID , TrainerFName +' '+ TrainerLName +' ' as Trainer from TrainersTable";
            Trainer.DisplayMember = Con.GetData(Query).Columns["Trainer"].ToString();
            Trainer.ValueMember = Con.GetData(Query).Columns["TrainerID"].ToString();
            Trainer.DataSource = Con.GetData(Query);
        }

        private void GetMemberships()
        {
            string Query = "Select MembershipID, MembershipType from MembershipsTable";
            MembershipType.DisplayMember = Con.GetData(Query).Columns["MembershipType"].ToString();
            MembershipType.ValueMember = Con.GetData(Query).Columns["MembershipID"].ToString();
            MembershipType.DataSource = Con.GetData(Query);
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

        private void ChangePassLbl_Click(object sender, EventArgs e)
        {
            ChangePassword Obj = new ChangePassword();
            Obj.Show();
            this.Hide();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void Reset()
        {
            MemberFName.Text = string.Empty;
            MemberLName.Text = string.Empty;
            MembershipType.Text = string.Empty;
            Phone.Text = string.Empty;
            Timing.Text = string.Empty;
            BloodType.Text = string.Empty;
            Gender.Text = string.Empty;
            Trainer.Text = string.Empty;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (MemberFName.Text == "" || MemberLName.Text == "" || MembershipType.SelectedIndex == -1 || Phone.Text == "" || Timing.SelectedIndex == -1 || BloodType.SelectedIndex == -1 || Gender.SelectedIndex == -1 || Trainer.SelectedIndex == -1)
                {
                    MessageBox.Show("Please enter the required fields!!");
                }

                // Assuming txtMemberDOB is a TextBox for entering date of birth
                if (DateTime.TryParse(MemberDOB.Text, out DateTime memberDOB))
                {
                    // Validate if memberDOB is greater than the system date
                    if (memberDOB > DateTime.Now || memberDOB == DateTime.Now)
                    {
                        MessageBox.Show(" Please enter a date of birth less than the current date.!");
                    }
                    else
                    {

                        if (DateTime.TryParse(JoinDate.Text, out DateTime memberJoin))
                        {
                            if (memberJoin > DateTime.Now)
                            {
                                MessageBox.Show(" Join date should be less or equal the current date.!");
                            }

                            else
                            {
                                string MemFName = MemberFName.Text;
                                string MemLName = MemberLName.Text;
                                string BirthDate = MemberDOB.Value.Date.ToString();
                                string JoinedDate = JoinDate.Value.Date.ToString();
                                int Memship = Convert.ToInt32(MembershipType.SelectedValue.ToString());
                                string Number = Phone.Text;
                                string Time = Timing.SelectedItem.ToString();
                                string Blood = BloodType.SelectedItem.ToString();
                                string Gen = Gender.SelectedItem.ToString();
                                string TrainerName = Trainer.SelectedValue.ToString();
                                string Query = "Insert into MembersTable values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')";
                                Query = string.Format(Query, MemFName, MemLName, MemberDOB.Value.Date, JoinDate.Value.Date, Memship, Number, Time, Blood, Gen, TrainerName);
                                Con.setData(Query);
                                ShowMembers();
                                MessageBox.Show("Member added");
                                Reset();
                            }
                        }
                    }
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
                if (MemberFName.Text == "" || MemberLName.Text == "" || MembershipType.SelectedIndex == -1 || Phone.Text == "" || Timing.SelectedIndex == -1 || BloodType.SelectedIndex == -1 || Gender.SelectedIndex == -1 || Trainer.SelectedIndex == -1)
                {
                    MessageBox.Show("Please enter the required fields!!");
                }

                if (DateTime.TryParse(MemberDOB.Text, out DateTime memberDOB))
                {
                    // Validate if memberDOB is greater than the system date
                    if (memberDOB > DateTime.Now || memberDOB == DateTime.Now)
                    {
                        MessageBox.Show(" Please enter a date of birth less than the current date.!");
                    }

                    else
                    {

                        if (DateTime.TryParse(JoinDate.Text, out DateTime memberJoin))
                        {
                            if (memberJoin > DateTime.Now)
                            {
                                MessageBox.Show(" Join date should be less or equal the current date.!");
                            }
                            else
                            {
                                int Key = int.Parse(GridViewMembers.CurrentRow.Cells[0].Value.ToString());
                                string MemFName = MemberFName.Text;
                                string MemLName = MemberLName.Text;
                                string BirthDate = MemberDOB.Value.Date.ToString();
                                string JoinedDate = JoinDate.Value.Date.ToString();
                                string Memship = MembershipType.SelectedValue.ToString();
                                string Number = Phone.Text;
                                string Time = Timing.SelectedItem.ToString();
                                string Blood = BloodType.SelectedItem.ToString();
                                string Gen = Gender.SelectedItem.ToString();
                                string TrainerName = Trainer.SelectedValue.ToString();
                                string Query = "Update MembersTable set MemberFName = '{0}', MemberLName = '{1}', MemberDOB = '{2}', JoinDate = '{3}', MembershipID = {4}, Phone = '{5}' , Timing = '{6}', BloodType = '{7}', Gender = '{8}' , TrainerID = {9} Where MembersID = {10}";
                                Query = string.Format(Query, MemFName, MemLName, MemberDOB.Value.Date, JoinDate.Value.Date, Memship, Number, Time, Blood, Gen, TrainerName, Key);
                                Con.setData(Query);
                                ShowMembers();
                                MessageBox.Show("Member Updated");
                                Reset();
                            }
                        }
                    }
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
                if (MemberFName.Text == "" || MemberLName.Text == "" || MembershipType.SelectedIndex == -1 || Phone.Text == "" || Timing.SelectedIndex == -1 || BloodType.SelectedIndex == -1 || Gender.SelectedIndex == -1 || Trainer.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select the row!!");
                }
                else
                {
                    int Key = int.Parse(GridViewMembers.CurrentRow.Cells[0].Value.ToString());
                    string Query = "Delete from MembersTable where MembersID = {0}";
                    Query = string.Format(Query, Key);
                    Con.setData(Query);
                    ShowMembers();
                    MessageBox.Show("Member Deleted");
                    Reset();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void GridViewMembers_SelectionChanged(object sender, EventArgs e)
        {
            if (GridViewMembers.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = GridViewMembers.SelectedRows[0];

                string[] Member = GridViewMembers.SelectedRows[0].Cells[1].Value.ToString().Split(' ');
                MemberFName.Text = Member[0];
                MemberLName.Text = Member[1];

                MemberDOB.Text = GridViewMembers.CurrentRow.Cells[2].Value.ToString();
                JoinDate.Text = GridViewMembers.CurrentRow.Cells[3].Value.ToString();
                MembershipType.Text = GridViewMembers.CurrentRow.Cells[5].Value.ToString();
                Phone.Text = GridViewMembers.CurrentRow.Cells[6].Value.ToString();
                Timing.Text = GridViewMembers.CurrentRow.Cells[7].Value.ToString();
                BloodType.Text = GridViewMembers.CurrentRow.Cells[8].Value.ToString();
                Gender.Text = GridViewMembers.CurrentRow.Cells[9].Value.ToString();
                Trainer.Text = GridViewMembers.CurrentRow.Cells[11].Value.ToString();

            }
        }
    }
}
