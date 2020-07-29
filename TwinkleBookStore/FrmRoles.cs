using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using InterfaceBookStore;
using BLBookStore;
using DLBookStore;
namespace TwinkleBookStore
{
    public partial class FrmRoles : Form
    {
        dynamic objBLRole;
        int SelectedId = 0;
        string SelectedName = "";
        public FrmRoles()
        {
            InitializeComponent();
            Program.Bootstrap();
            objBLRole = Program.container.Resolve<BLRole>();
            lblValidationSummary.Visible = false;
        }

        private void FrmUserRoles_Load(object sender, EventArgs e)
        {
            if (GloabalClass.RoleName.Contains("Sales"))
            {
                btnDelete.Enabled = false;
            }
            Reset();
          
            dataGridView1.Columns["id"].Visible = false;
          
           
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateMandUserFields())
            {
                ModelBookStore.Role objRole = new ModelBookStore.Role();
                {
                    objRole.Name = txtRoleName.Text;
                }
               
               

                Save(objRole);
                Reset();
                MessageBox.Show("Added Successfully");
            }
            else {
                lblValidationSummary.Visible = true;

            }
           
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ValidateMandUserFields())
            {
                if (SelectedId > 0)
                {

                    ModelBookStore.Role objRole = new ModelBookStore.Role();
                    {
                        objRole.Name = txtRoleName.Text;
                        objRole.id = SelectedId;
                    }



                    Update(objRole);
                    Reset();
                    MessageBox.Show("Updated Successfully");
                }
                else {
                    MessageBox.Show("No Data in Grid or please select any row from Grid");
                }

            }
            else
            {
                lblValidationSummary.Visible = true;

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ValidateMandUserFields())
            {
                if (SelectedId > 0)
                {
                    ModelBookStore.Role objRole = new ModelBookStore.Role();
                    {
                        objRole.Name = txtRoleName.Text;

                        objRole.id = SelectedId;
                    }



                    Delete(objRole);
                    Reset();
                    MessageBox.Show("Deleted Successfully");
                }
                else
                {
                    MessageBox.Show("No Data in Grid or please select any row from Grid");
                }
            }
            else
            {
                lblValidationSummary.Visible = true;

            }
        }
        private void Save(ModelBookStore.Role objRole)
        {
            //var login = objcontainer.Resolve<BLLogin>();
            // login.Register(objLogin);
            objBLRole.Add(objRole);
        }
        private void Update(ModelBookStore.Role objRole)
        {
            //var login = objcontainer.Resolve<BLLogin>();
            // login.Register(objLogin);
            objBLRole.Update(objRole);
        }
        private void Delete(ModelBookStore.Role objRole)
        {
            //var login = objcontainer.Resolve<BLLogin>();
            // login.Register(objLogin);
            objBLRole.Delete(objRole);
        }
        private bool ValidateMandUserFields()
        {
            bool ValidateUser = true;
          
            lblRoleNameMand.Visible = false;
           
            lblValidationSummary.Visible = false;
            if (string.IsNullOrEmpty(txtRoleName.Text))
            {
                lblRoleNameMand.Visible = true;
                txtRoleName.Focus();
               
                //return "Please Enter FirstName";
                ValidateUser = false;
            }
            
            return ValidateUser;
        }
            private void Reset()
        {
            txtRoleName.Text = "";
            SelectedId = 0;
            ModelBookStore.Role objRole = new ModelBookStore.Role();
            List<ModelBookStore.Role> objRoleList = LoadData();
            dataGridView1.DataSource = objRoleList;

        }
        private List<ModelBookStore.Role> LoadData()
        {
            List<ModelBookStore.Role> objRoleList = objBLRole.Load();

            return objRoleList;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtRoleName.Text = row.Cells[1].Value.ToString();
               
                SelectedId = Convert.ToInt32( row.Cells[0].Value);
                SelectedName= row.Cells[1].Value.ToString();
            }

        }

       
    }
}
