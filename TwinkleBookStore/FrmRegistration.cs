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
    public partial class FrmRegistration : Form
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

       
        public FrmRegistration()
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
            Dictionary<string, string> Stateinfo = LoadState();
           
            cmbState.DataSource = new BindingSource(Stateinfo, null);
            cmbState.DisplayMember = "Value";
            cmbState.ValueMember = "Key";
            //Dictionary<string, List<string>> CityInfo = LoadCity();
            //cmbCity.DataSource = new BindingSource(CityInfo, null);
            //cmbCity.DisplayMember = "Value";
            //cmbCity.ValueMember = "Key";
            //cmbState.DisplayMember=lo


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
                    lblEmailExpression.Visible = false;
                    lblPhoneNoExpression.Visible = false;
                  
                    if (ValidaeUserFields( txtUserId.Text, txtPassword.Text, txtConfirmPassword.Text, txtEmailId.Text, txtPhoneNo.Text ,out ControlFocus))
                    {

                        ModelBookStore.Login objLogin = new ModelBookStore.Login();
                        {
                           
                            objLogin.UserId = txtUserId.Text;
                            objLogin.Password = txtPassword.Text;

                            ModelBookStore.UserDetail objUserDetail = new ModelBookStore.UserDetail();
                            {
                               // objUserDetail.UserId = objLogin.id;
                                objUserDetail.FirstName = txtFirstName.Text;
                                objUserDetail.LastName = txtLastName.Text;

                                objUserDetail.PhoneNumber = txtPhoneNo.Text;
                                objUserDetail.EmailId = txtEmailId.Text;
                                objUserDetail.DOB = dtpDOB.Value;
                                objUserDetail.Address = txtAddress.Text;
                                objUserDetail.state = cmbState.Text;
                                objUserDetail.city = cmbCity.Text;

                               // objUserDetail.Login = objLogin;
                            };

                            List<ModelBookStore.UserDetail> userDetails = new List<ModelBookStore.UserDetail>();
                            userDetails.Add(objUserDetail);
                            objLogin.UserDetails = userDetails;
                           
                        };
                       
                        //objLogin.UserDetails.Add(objUserDetail);

                        Save(objLogin);
                      
                        DialogResult dialogResult = MessageBox.Show("You have added successfully and Would you like to add new customer , please click yes else no to login","",MessageBoxButtons.YesNo);

                        if (dialogResult == DialogResult.No)
                        {
                            FrmLogin objLoginfrm = new FrmLogin();
                            objLoginfrm.Show();
                            this.Hide();
                        }
                        if (dialogResult == DialogResult.Yes)
                        {
                            Reset();
                        }


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
                        else if (ControlFocus == "Email") {
                            txtEmailId.Focus();
                            lblEmailExpression.Visible = true;
                        }
                        else if (ControlFocus == "PhoneNo") {
                            txtPhoneNo.Focus();
                            lblPhoneNoExpression.Visible = true;
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
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtEmailId.Text = "";
            txtPhoneNo.Text = "";
            txtUserId.Text = "";
            lblFirstMand.Visible = false;
            lblLastMand.Visible = false;
            lblPasswordMand.Visible = false;
            lblConfirmPassMand.Visible = false;
            lblUserIdMand.Visible = false;
            lblPhoneNoMand.Visible = false;
            lblEmailMand.Visible = false;
            lblValidationSummary.Visible = false;
            lblPhoneNoExpression.Visible = false;
            lblEmailExpression.Visible = false;
            lblConfPasswordExpression.Visible = false;
            lblUserIdExpression.Visible = false;
            lblPasswordExpression.Visible = false;
            txtFirstName.Focus();
            dtpDOB.Value = DateTime.Now;
            txtAddress.Text = "";
            if (cmbState.Items.Count > 0)
                cmbState.SelectedIndex = 0;
            if (cmbCity.Items.Count > 0)
                cmbCity.SelectedIndex = 0;
            dtpDOB.CustomFormat = "yyyy-MM-dd";
          
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
            lblFirstMand.Visible = false;
            lblLastMand.Visible = false;
            lblPasswordMand.Visible = false;
            lblConfirmPassMand.Visible = false;
            lblUserIdMand.Visible = false;
            lblPhoneNoMand.Visible = false;
            lblEmailMand.Visible = false;
            lblValidationSummary.Visible = false;

            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                lblFirstMand.Visible = true;
                txtFirstName.Focus();
                tabIndex = true;
                //return "Please Enter FirstName";
                ValidateUser = false;
            }
            
             if (String.IsNullOrEmpty(txtLastName.Text))
            {
                lblLastMand.Visible = true;
                if(tabIndex==false)
                {
                    txtLastName.Focus();
                    tabIndex = true;
                }
               
                //return "Pleasse Enter LastName";
                ValidateUser = false;

            }
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
             if (String.IsNullOrEmpty(txtPhoneNo.Text))
            {
                if (tabIndex == false)
                {
                    txtPhoneNo.Focus();
                    tabIndex = true;
                }
                    
                lblPhoneNoMand.Visible = true;
                // return "Please Enter PhoneNumber";
                ValidateUser = false;
            }
             if (String.IsNullOrEmpty(txtEmailId.Text))
            {
                if (tabIndex == false)
                {
                    txtEmailId.Focus();
                    tabIndex = true;
                }
                   
                lblEmailMand.Visible = true;
                // return "Please Enter EmailId";
                ValidateUser = false;
            }

            return ValidateUser;

        }
        private bool ValidaeUserFields( string UserId, string Password,string ConfirmPassword,string Email,string PhoneNo,out string ControlFocus)
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
         
            if (Regex.IsMatch(PhoneNo, PhoneNoPattern)== false)
            {
                ControlFocus = "PhoneNo";
                return false;
            }
            if (Regex.IsMatch(Email, MatchEmailPattern) == false)
            {
                ControlFocus = "Email";
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

        private Dictionary<string,string> LoadState()
        {
            Dictionary<string,string> lstState = new Dictionary<string,string>();
            lstState.Add("NA", "Please Selecte State");
            lstState.Add("KA","Karnataka");
            lstState.Add("TN","TamilNadu");
            lstState.Add("TS","Telangana");
            lstState.Add("AP","AndhraPradesh");
            return lstState;
        }

        private Dictionary<string, List<String>> LoadCity()
        {
            Dictionary<string, List<String>> lstCity = new Dictionary<string, List<String>>();

            List<string> valKA = new List<string>();
            valKA.Add("Banglore");
            valKA.Add("Mysore");

            List<string> valTN = new List<string>();
            valTN.Add("Chennai");
            valTN.Add("Coimbotore");

            List<string> valTS = new List<string>();
            valTS.Add("Hyderabad");
            valTS.Add("Warangle");

            List<string> valAP = new List<string>();
            valAP.Add("Vijayawada");
            valAP.Add("Vizag");

            lstCity.Add("KA", valKA);
            lstCity.Add("TN", valTN);
            lstCity.Add("TS", valTS);
            lstCity.Add("AP", valAP);

            return lstCity;
        }
        private Dictionary<string, string> LoadCityByState(string Key)
        {
            Dictionary<string, string> lstCity = new Dictionary<string, string>();

            if (Key.ToString() == "KA")
            { 
                lstCity.Add("blr","Banglore");
            lstCity.Add("msr","Mysore");
            }
            if (Key.ToString() == "TN")
            {
                lstCity.Add("CN", "Chennai");
                lstCity.Add("CMB", "Coimbotore");
            }
            if (Key.ToString() == "TS")
            {

                lstCity.Add("HYD", "Hyderabad");
                lstCity.Add("WRG", "Warangle");
            }

            if (Key.ToString() == "AP")
            {

                lstCity.Add("VJA", "Vijayawada");
                lstCity.Add("VZA", "Vizag");
            }
           

            return lstCity;
        }

     
   
      

        private void cmbState_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbState.SelectedValue.ToString() != "NA" && cmbState.SelectedValue.ToString() != "[NA, Please Selecte State]")
            {

                Dictionary<string, string> CityInfo = LoadCityByState(cmbState.SelectedValue.ToString());
                cmbCity.DataSource = new BindingSource(CityInfo, null);
                cmbCity.DisplayMember = "Value";
                cmbCity.ValueMember = "Key";
            }
            else
            {
                cmbCity.DataSource = null;
                cmbCity.Items.Clear();
            }
        }
    }
}