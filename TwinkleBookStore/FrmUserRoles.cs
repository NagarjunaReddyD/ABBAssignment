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
    public partial class FrmUserRoles : Form
    {
        dynamic objBLUserRole;
        public FrmUserRoles()
        {
            InitializeComponent();
            Program.Bootstrap();
            objBLUserRole = Program.container.Resolve<BLUserRole>();
        }

        private void FrmUserRoles_Load(object sender, EventArgs e)
        {
          
            Reset();
          
        }

        private void LoadUsers()
        {
            List<ModelBookStore.Login> objLoginList = objBLUserRole.LoadUsers();
            Dictionary<string, string> lstUsers= new Dictionary<string, string>();

            foreach (var item in objLoginList)
            {
                lstUsers.Add(item.id.ToString(), item.UserId.ToString());
               
            }

            cmbUserName.DataSource = new BindingSource(lstUsers, null);
            cmbUserName.DisplayMember = "Value";
            cmbUserName.ValueMember = "Key";
        }
        private void LoadRoles()
        {
            List<ModelBookStore.Role> objRolesList = objBLUserRole.LoadRoles();
            Dictionary<string, string> lstRoles = new Dictionary<string, string>();

            foreach (var item in objRolesList)
            {
                lstRoles.Add(item.id.ToString(), item.Name.ToString());

            }
            if (objRolesList.Count > 0)
            {
                cmbRoleType.DataSource = new BindingSource(lstRoles, null);
                cmbRoleType.DisplayMember = "Value";
                cmbRoleType.ValueMember = "Key";
            }

            else {

                MessageBox.Show("Please Add Any one role in Roles screen before to User Mapping");
                this.Hide();
                FrmRoles roles = new FrmRoles();
                roles.Show();
            }

           
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            ModelBookStore.UserRole objUserRole = new ModelBookStore.UserRole();
            {
                objUserRole.UserId = Convert.ToInt32(cmbUserName.SelectedValue.ToString());
                objUserRole.RoleId = Convert.ToInt32(cmbRoleType.SelectedValue.ToString()); 
            }



            Update(objUserRole);
            Reset();
            MessageBox.Show("Updated Successfully");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }
        private void Update(ModelBookStore.UserRole objUserRole)
        {
            //var login = objcontainer.Resolve<BLLogin>();
            // login.Register(objLogin);
            objBLUserRole.Update(objUserRole);
        }
        private void Reset()
        {
            LoadUsers();
            LoadRoles();
            if (cmbUserName.Items.Count > 0)
                cmbUserName.SelectedIndex = 0;
            if (cmbRoleType.Items.Count > 0)
                cmbRoleType.SelectedIndex = 0;
           
        }
    }
}
