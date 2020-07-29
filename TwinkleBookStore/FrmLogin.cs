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
    public partial class FrmLogin : Form
    {
        //IUnityContainer objcontainer = new UnityContainer();
        //BLLogin obj;
        dynamic objBLLogin;
        public FrmLogin()
        {
          
            InitializeComponent();
            Program.Bootstrap();
            objBLLogin = Program.container.Resolve<BLLogin>();
            lblValidation.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)

        {
            if (validate(txtUserName.Text, txtPassword.Text) == true)
            {
                List<ModelBookStore.LoginUserRoles> objRoleList = objBLLogin.Search(txtUserName.Text, txtPassword.Text);


                GloabalClass.UserId = objRoleList[0].UserId;
                GloabalClass.LogId = objRoleList[0].LogId;
                //GloabalClass.FirstName = objRoleList[0].FirstName;
                //GloabalClass.LastName = objRoleList[0].LastName;
                GloabalClass.RoleId = objRoleList[0].RoleId;
                GloabalClass.RoleName = objRoleList[0].RoleName;


                FrmMaster objMaster = new FrmMaster();
                objMaster.Text = "Welcome " + GloabalClass.UserId + " to TwinkleBookStore";
                //objLogin.label1.Text ="welcome" + GloabalClass.LoginName +" to twinklestore";
                objMaster.Show();
                this.Hide();
            }
            else
            {
                lblValidation.Text = "Invalid Credentials and Please Provide Valid Credentials";
                lblValidation.Visible = true;
            }
        }

        private bool validate(string UserName,string Password)
        { 
           
            bool objValidate = objBLLogin.LoginUser(UserName, Password);

            return objValidate;
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            FrmLoginRegistration objRegister = new FrmLoginRegistration();
            objRegister.Show();
            this.Hide();
        }
        private void Reset()
        {

            txtUserName.Clear();
            txtPassword.Clear();
            txtUserName.Focus();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
