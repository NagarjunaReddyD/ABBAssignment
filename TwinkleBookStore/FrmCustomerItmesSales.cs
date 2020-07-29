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
    public partial class FrmCustomerItmesSales : Form
    {

        //IUnityContainer objcontainer = new UnityContainer();
        // BLLogin objBLLogin;
        dynamic objBLLogin;

        public readonly string MatchEmailPattern;
    
        public readonly string PhoneNoPattern;
       

        public readonly string UserIdPattern;
       

        int SelectedId = 0;
        public FrmCustomerItmesSales()
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
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["UserId"].Visible = false;
            dataGridView1.Columns["Address"].Visible = false;
            dataGridView1.Columns["DOB"].Visible = false;
            dataGridView1.Columns["city"].Visible = false;
            dataGridView1.Columns["state"].Visible = false;
            dataGridView1.Columns["Login"].Visible = false;
            Dictionary<string, string> Stateinfo = LoadState();
           
            cmbState.DataSource = new BindingSource(Stateinfo, null);
            cmbState.DisplayMember = "Value";
            cmbState.ValueMember = "Key";
           

        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                string ControlFocus=string.Empty;
               
                if (ValidateMandUserFields())
                {
                  
                    lblEmailExpression.Visible = false;
                    lblPhoneNoExpression.Visible = false;
                  
                    if (ValidaeUserFields( txtEmailId.Text, txtPhoneNo.Text ,out ControlFocus))
                    {


                       

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
                            if (chkMembership.Checked == true)
                            {
                                objUserDetail.IsMembership = "Y";
                            }
                            else {
                                objUserDetail.IsMembership ="N";
                            }
                            objUserDetail.id = SelectedId;
                          
                            // objUserDetail.Login = objLogin;
                        };






                        //objLogin.UserDetails.Add(objUserDetail);
                        if (SelectedId > 0)
                        {
                            Update(objUserDetail);
                            MessageBox.Show("Customer Updated Successfully");
                            Reset();
                        }
                        else
                        {
                            Save(objUserDetail);
                            MessageBox.Show("Customer Added Successfully");
                            Reset();
                        }
                      
                      
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
                       
                         if (ControlFocus == "Email") {
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

        private List<ModelBookStore.UserDetail> LoadData()
        {
            List<ModelBookStore.UserDetail> objUserItemList = objBLLogin.Load();

            return objUserItemList;
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
           
            txtEmailId.Text = "";
            txtPhoneNo.Text = "";
          
            lblFirstMand.Visible = false;
            lblLastMand.Visible = false;
           
            lblPhoneNoMand.Visible = false;
            lblEmailMand.Visible = false;
            lblValidationSummary.Visible = false;
            lblPhoneNoExpression.Visible = false;
            lblEmailExpression.Visible = false;
          
            txtFirstName.Focus();
            dtpDOB.Value = DateTime.Now;
            txtAddress.Text = "";
            if (cmbState.Items.Count > 0)
                cmbState.SelectedIndex = 0;
            if (cmbCity.Items.Count > 0)
                cmbCity.SelectedIndex = 0;
            dtpDOB.CustomFormat = "yyyy-MM-dd";
            chkMembership.Checked = false;

            List<ModelBookStore.UserDetail> objUserDetailList = LoadData();
            dataGridView1.DataSource = objUserDetailList;

        }
        private void Save(ModelBookStore.UserDetail objUserDetail)
        {
           
            objBLLogin.Add(objUserDetail);
        }
        private void Update(ModelBookStore.UserDetail objUserDetail)
        {
            objBLLogin.Update(objUserDetail);
        }
        private void Delete(ModelBookStore.UserDetail objUserDetail)
        {
            objBLLogin.Delete(objUserDetail);
        }
        private bool ValidateMandUserFields()
        {
            bool ValidateUser=true;
            bool tabIndex = false;
            lblFirstMand.Visible = false;
            lblLastMand.Visible = false;
            
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
        private bool ValidaeUserFields(string Email,string PhoneNo,out string ControlFocus)
        {
              
         
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                SelectedId = Convert.ToInt32(row.Cells[0].Value);
                txtFirstName.Text = Convert.ToString( row.Cells[2].Value ?? "");
                txtLastName.Text = Convert.ToString(row.Cells[3].Value ?? "");
                txtPhoneNo.Text = Convert.ToString(row.Cells[4].Value ?? "");
                txtEmailId.Text = Convert.ToString(row.Cells[5].Value ?? "");
                txtAddress.Text = Convert.ToString(row.Cells[6].Value ?? "");

                //var stringValue = row.Cells[7].Value.ToString();


                //var dateValue = string.IsNullOrEmpty(Convert.ToString(stringValue)) ? DateTime.MinValue : Convert.ToDateTime("2018-01-01 00:00:00");
               
                if (Convert.ToDateTime(row.Cells[7].Value.ToString()) != DateTime.MinValue)
                {
                    dtpDOB.Text = row.Cells[7].Value.ToString();
                }
              
                var state= Convert.ToString(row.Cells[9].Value ?? "");
                if (! String.IsNullOrEmpty(state))
                cmbState.Text = row.Cells[9].Value.ToString();

                var City = Convert.ToString(row.Cells[8].Value ?? "");
                if (!String.IsNullOrEmpty(City))
                    cmbCity.Text = row.Cells[8].Value.ToString();

                var Member = Convert.ToString(row.Cells[10].Value ?? "");
                if (Member == "Y")
                {
                    chkMembership.Checked = true;
                }
                else
                {
                    chkMembership.Checked = false;
                }
               

                //SelectedName= row.Cells[1].Value.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ValidateMandUserFields())
            {
                if (SelectedId > 0)
                {
                    ModelBookStore.UserDetail objUserDetail = new ModelBookStore.UserDetail();
                    {


                        objUserDetail.id = SelectedId;
                    }



                    Delete(objUserDetail);
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
    }
}