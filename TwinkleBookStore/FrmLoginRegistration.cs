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
using System.Text.RegularExpressions;
using System.Configuration;
using System.Collections;
namespace TwinkleBookStore
{
    public partial class FrmLoginRegistration : Form
    {

        //IUnityContainer objcontainer = new UnityContainer();
        // BLLogin objBLLogin;
        dynamic objBLLogin;

        public readonly string MatchEmailPattern;
    //        =
    //       @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
    //+ @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				//[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
    //+ @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				//[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
    //+ @"([a-zA-Z0-9]+[\w-]+\.)+[a-zA-Z]{1}[a-zA-Z0-9-]{1,23})$";

        public readonly string PhoneNoPattern;
        //= @"\+?\d[\d -]{8,12}\d";

        public readonly string UserIdPattern;
            //= "(?i)^(?=.*[a-z])[a-z0-9]{5,20}$";

       
        public FrmLoginRegistration()
        {
            InitializeComponent();
            Program.Bootstrap();
        
            objBLLogin = Program.container.Resolve<BLLogin>();
            MatchEmailPattern = ConfigurationSettings.AppSettings["MatchEmailPattern"].ToString();
            PhoneNoPattern = ConfigurationSettings.AppSettings["PhoneNoPattern"].ToString();
            UserIdPattern = ConfigurationSettings.AppSettings["UserIdPattern"].ToString();


        }
        private void FrmRegistration_Load(object sender, EventArgs e)
        {
            Reset();
           

        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                string ControlFocus=string.Empty;
               
                if (ValidateMandUserFields())
                {
                    lblUserIdExpression.Visible = false;
                    lblPasswordExpression.Visible = false;
                    lblConfPasswordExpression.Visible = false;
                  
                  
                    if (ValidaeUserFields( txtUserId.Text, txtPassword.Text, txtConfirmPassword.Text ,out ControlFocus))
                    {

                        ModelBookStore.Login objLogin = new ModelBookStore.Login();
                        {
                           
                            objLogin.UserId = txtUserId.Text;
                            objLogin.Password = txtPassword.Text;

                            //ModelBookStore.UserDetail objUserDetail = new ModelBookStore.UserDetail();
                            //{
                            //   // objUserDetail.UserId = objLogin.id;
                            //    objUserDetail.FirstName = txtFirstName.Text;
                            //    objUserDetail.LastName = txtLastName.Text;

                            //    objUserDetail.PhoneNumber = txtPhoneNo.Text;
                            //    objUserDetail.EmailId = txtEmailId.Text;
                            //    objUserDetail.DOB = dtpDOB.Value;
                            //    objUserDetail.Address = txtAddress.Text;
                            //    objUserDetail.state = cmbState.Text;
                            //    objUserDetail.city = cmbCity.Text;

                            //   // objUserDetail.Login = objLogin;
                            //};

                            //List<ModelBookStore.UserDetail> userDetails = new List<ModelBookStore.UserDetail>();
                            //userDetails.Add(objUserDetail);
                            //objLogin.UserDetails = userDetails;
                           
                        };
                       
                        //objLogin.UserDetails.Add(objUserDetail);

                        Save(objLogin);
                        MessageBox.Show("You have added successfully and Please Login");
                        FrmLogin objLoginfrm = new FrmLogin();
                        objLoginfrm.Show();
                        this.Hide();
                        //DialogResult dialogResult = MessageBox.Show("You have added successfully and Would you like to add new customer , please click yes else no to login","",MessageBoxButtons.YesNo);

                        //if (dialogResult == DialogResult.No)
                        //{
                        //    FrmLogin objLoginfrm = new FrmLogin();
                        //    objLoginfrm.Show();
                        //    this.Hide();
                        //}
                        //if (dialogResult == DialogResult.Yes)
                        //{
                        //    Reset();
                        //}


                    }
                    else
                    {
                        if (ControlFocus == "UserId")
                        {
                            txtUserId.Focus();
                            //  txtPassword.Focus();
                            lblUserIdExpression.Visible = true;
                        }
                       else if (ControlFocus.StartsWith("Password")) {
                            txtPassword.Focus();
                            //  txtPassword.Focus();
                            lblPasswordExpression.Text = ControlFocus;
                            lblPasswordExpression.Visible = true;
                        }
                        else if (ControlFocus.Contains("ConfPassword"))
                        {
                            txtConfirmPassword.Focus();
                            lblConfPasswordExpression.Visible = true;

                        }
                        
                    }
                }
                else
                {

                    lblValidationSummary.Visible = true;
                }
             
            }
            catch(Exception ex)
            {
               // throw new Exception(ex.Message);
                MessageBox.Show(ex.Message);
            }
            
        }
       

      

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                Reset();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
          
        }
        private void Reset()
        {
          
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
          
            txtUserId.Text = "";
           
            lblPasswordMand.Visible = false;
            lblConfirmPassMand.Visible = false;
            lblUserIdMand.Visible = false;
          
            lblValidationSummary.Visible = false;
           
            lblConfPasswordExpression.Visible = false;
            lblUserIdExpression.Visible = false;
            lblPasswordExpression.Visible = false;
          
          
        }
        private void Save(ModelBookStore.Login objLogin)
        {
            //var login = objcontainer.Resolve<BLLogin>();
           // login.Register(objLogin);
            objBLLogin.Register(objLogin);
        }

        private bool ValidateMandUserFields()
        {
            bool ValidateUser=true;
            bool tabIndex = false;
          
            lblPasswordMand.Visible = false;
            lblConfirmPassMand.Visible = false;
            lblUserIdMand.Visible = false;
            
            lblValidationSummary.Visible = false;

          
            
          
             if (String.IsNullOrEmpty(txtUserId.Text))
            {
                lblUserIdMand.Visible = true;
                if (tabIndex == false)
                {
                    txtUserId.Focus();
                    tabIndex = true;
                }
                //return "Pleae Enter UserId";
                ValidateUser = false;

            }
             if (String.IsNullOrEmpty(txtPassword.Text))
            {
                lblPasswordMand.Visible = true;
                if (tabIndex == false)
                {
                    txtPassword.Focus();
                    tabIndex = true;
                }
                   
                // return "Please Enter Password";
                ValidateUser = false;

            }
             if (String.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                if (tabIndex == false)
                {
                    txtConfirmPassword.Focus();
                    tabIndex = true;
                }
                   
                lblConfirmPassMand.Visible = true;
                //return "Pleae Enter ConfirmPassword";
                ValidateUser = false;

            }
           
           

            return ValidateUser;

        }
        private bool ValidaeUserFields( string UserId, string Password,string ConfirmPassword,out string ControlFocus)
        {
            if (Regex.IsMatch(UserId, UserIdPattern) == false)
            {
                ControlFocus = "UserId";
                return false;
            }
            if (ValidatePassword(Password,out ControlFocus)==false)
            {
                return false;
            }
            if (Password != ConfirmPassword)
            {
                ControlFocus = "ConfPassword";
                return false;
            }       
         
           
            ControlFocus = "";
            return true;
        }
        private bool ValidatePassword(string password,  out string ErrorMessage)
        {
            var input = password;
            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new Exception("Password should not be empty");
            }

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(input))
            {
                ErrorMessage = "Password should contain at least one lower case letter.";
                return false;
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                ErrorMessage = "Password should contain at least one upper case letter.";
                return false;
            }
            else if (!hasNumber.IsMatch(input))
            {
                ErrorMessage = "Password should contain at least one numeric value.";
                return false;
            }

            else if (!hasSymbols.IsMatch(input))
            {
                ErrorMessage = "Password should contain at least one special case character.";
                return false;
            }
            else if (!hasMiniMaxChars.IsMatch(input))
            {
                ErrorMessage = "Password should not be lesser than 8 or greater than 15 characters.";
                return false;
            }
           
            else
            {
                return true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     

     
   
      

      
    }
}