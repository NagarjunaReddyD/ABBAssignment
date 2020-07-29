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
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.IO;
namespace TwinkleBookStore
{
    public partial class FrmCustomerItem : Form
    {
        dynamic objBLUserItem;
        dynamic objBLUserRole;
        dynamic objBLItems;
        int SelectedId = 0;
        // string SelectedName = "";
        public FrmCustomerItem()
        {
            InitializeComponent();
            Program.Bootstrap();
            objBLUserItem = Program.container.Resolve<BLUserItem>();
            objBLUserRole = Program.container.Resolve<BLUserRole>();
            objBLItems = Program.container.Resolve<BLItem>();
            lblValidationSummary.Visible = false;
        }

        private void FrmItem_Load(object sender, EventArgs e)
        {
            if (GloabalClass.RoleName.Contains("Sales"))
            {
                btnDelete.Enabled = false;
            }
            Reset();

            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["UserId"].Visible = false;
            dataGridView1.Columns["ItemId"].Visible = false;
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateMandUserFields())
                {

                    if (String.IsNullOrEmpty(txtNoOfItems.Text))
                    {
                        txtNoOfItems.Text = "0.0";
                    }


                    bool IsMember = objBLUserItem.IsMember(Convert.ToInt32(cmbCustomer.SelectedValue));
                    string CustomerType = objBLUserItem.CustomerType(Convert.ToInt32(cmbCustomer.SelectedValue));
                    DateTime DOB = objBLUserItem.DOB(Convert.ToInt32(cmbCustomer.SelectedValue));
                    Decimal TotlalPurAmount = objBLUserItem.TotlalPurchaseAmount(Convert.ToInt32(cmbCustomer.SelectedValue));
                    int NoOfPurchases = objBLUserItem.NoOfPurchases(Convert.ToInt32(cmbCustomer.SelectedValue));

                    Decimal ItemPrice = objBLUserItem.ItemPrice(Convert.ToInt32(cmbItemName.SelectedValue));
                    Decimal BillAmount = ItemPrice * Convert.ToInt32(txtNoOfItems.Text);
                    DateTime SinceFrom = objBLUserItem.MemberSince(Convert.ToInt32(cmbCustomer.SelectedValue));

                    decimal discAmt = objBLUserItem.Discount(IsMember, CustomerType, BillAmount, DateTime.Now, DOB, NoOfPurchases, TotlalPurAmount, SinceFrom);
                    //Discount(IsMember, CustomerType,BillAmount, DateTime.Now, DOB, NoOfPurchases, TotlalPurAmount, SinceFrom);
                    txtDiscount.Text = Convert.ToString(discAmt);

                    txtNetAmt.Text = Convert.ToString((ItemPrice * Convert.ToDecimal(txtNoOfItems.Text)) - discAmt);

                    ModelBookStore.UserItem objUserItem = new ModelBookStore.UserItem();
                    {
                        objUserItem.NoOfItems = Convert.ToInt32(txtNoOfItems.Text);
                        objUserItem.ItemId = Convert.ToInt32(cmbItemName.SelectedValue);
                        objUserItem.UserId = Convert.ToInt32(cmbCustomer.SelectedValue);
                        objUserItem.DiscAmmount = Convert.ToDecimal(txtDiscount.Text);
                        objUserItem.NetAmount = Convert.ToDecimal(txtNetAmt.Text);
                        objUserItem.DateOfPurchase = Convert.ToDateTime(dtpDOP.Value);
                        objUserItem.id = SelectedId;
                    }



                    Update(objUserItem);
                    Reset();
                    MessageBox.Show("Updated Successfully");



                }
                else
                {
                    lblValidationSummary.Visible = true;

                }
            }
            catch(Exception ex) {

               
            }
 }
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ValidateMandUserFields())
            {
                if (SelectedId > 0)
                {
                    ModelBookStore.UserItem objUserItem = new ModelBookStore.UserItem();
                    {
                        objUserItem.NoOfItems = Convert.ToInt32(txtNoOfItems.Text);
                        objUserItem.ItemId = Convert.ToInt32(cmbItemName.SelectedValue);
                        objUserItem.UserId = Convert.ToInt32(cmbCustomer.SelectedValue);

                        objUserItem.id = SelectedId;
                    }



                    Delete(objUserItem);
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
        private void Save(ModelBookStore.UserItem objUserItem)
        {

            objBLUserItem.Add(objUserItem);
        }
        private void Update(ModelBookStore.UserItem objUserItem)
        {

            objBLUserItem.Update(objUserItem);
        }
        private void Delete(ModelBookStore.UserItem objUserItem)
        {

            objBLUserItem.Delete(objUserItem);
        }
        private bool ValidateMandUserFields()
        {
            bool ValidateUser = true;

            lblItemPriceMand.Visible = false;


            lblValidationSummary.Visible = false;
            if (string.IsNullOrEmpty(txtNoOfItems.Text))
            {
                lblItemPriceMand.Visible = true;
                txtNoOfItems.Focus();

                //return "Please Enter FirstName";
                ValidateUser = false;
            }
            if (string.IsNullOrEmpty(txtNoOfItems.Text))
            {
                lblItemPriceMand.Visible = true;
                txtNoOfItems.Focus();

                //return "Please Enter FirstName";
                ValidateUser = false;
            }

            return ValidateUser;
        }
        private void Reset()
        {
            LoadItems();
            LoadCustomers();
            txtNoOfItems.Text = "0";
            if (cmbItemName.Items.Count > 0)
                cmbItemName.SelectedIndex = 0;
            if (cmbCustomer.Items.Count > 0)
                cmbCustomer.SelectedIndex = 0;
            dtpDOP.Value = DateTime.Today;

            SelectedId = 0;

            List<ModelBookStore.UserItem> objUserItemList = LoadData();
            dataGridView1.DataSource = objUserItemList;

        }
        private void LoadCustomers()
        {
            List<ModelBookStore.UserDetail> objCustomerList = objBLUserRole.LoadCustomers();
            Dictionary<string, string> lstCustomers = new Dictionary<string, string>();

            foreach (var item in objCustomerList)
            {
                lstCustomers.Add(item.id.ToString(), item.FirstName.ToString());

            }

            cmbCustomer.DataSource = new BindingSource(lstCustomers, null);
            cmbCustomer.DisplayMember = "Value";
            cmbCustomer.ValueMember = "Key";
        }
        private void LoadItems()
        {
            List<ModelBookStore.Item> objItemList = objBLItems.Load();
            Dictionary<string, string> lstItems = new Dictionary<string, string>();

            foreach (var item in objItemList)
            {
                lstItems.Add(item.id.ToString(), item.Name.ToString());

            }

            cmbItemName.DataSource = new BindingSource(lstItems, null);
            cmbItemName.DisplayMember = "Value";
            cmbItemName.ValueMember = "Key";
        }
        private List<ModelBookStore.UserItem> LoadData()
        {
            List<ModelBookStore.UserItem> objUserItemList = objBLUserItem.Load();

            return objUserItemList;
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

                SelectedId = Convert.ToInt32(row.Cells[0].Value);
                cmbCustomer.SelectedValue = row.Cells[1].Value.ToString();
                cmbItemName.SelectedValue = row.Cells[2].Value.ToString();
                dtpDOP.Text = row.Cells[5].Value.ToString();
                txtNoOfItems.Text = row.Cells[6].Value.ToString();

                //SelectedName= row.Cells[1].Value.ToString();
            }

        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private Decimal Discount(bool IsMember, string TypeOfCust, decimal BillAmount, DateTime BillDate, DateTime DOB, int NoOfPurchases, Decimal TotalPurAmt, DateTime SinceFrom)
        {
            Decimal DiscAmount = 0;

            if (IsMember)
            {
                //Discount 5%
                DiscAmount = BillAmount * Convert.ToDecimal(0.05);

            }
            if (TypeOfCust == "New")
            {
                if (TypeOfCust == "New" && BillAmount <= 5000)
                {
                    //Discount 2%
                    DiscAmount = BillAmount * Convert.ToDecimal(0.02);
                }

                if (TypeOfCust == "New" && BillAmount > 5000)
                {
                    //Discount 3%
                    DiscAmount = BillAmount * Convert.ToDecimal(0.03);
                }


            }

            if (TypeOfCust == "Old")
            {
                if (TypeOfCust == "Old" && BillDate.Month == DOB.Month)
                {
                    // Discount  20%
                    DiscAmount = BillAmount * 2;
                }


                if (TypeOfCust == "Old" && NoOfPurchases > 5)
                {
                    // Discount  3%
                    DiscAmount = BillAmount * (Convert.ToDecimal(0.03));
                }
                if (TypeOfCust == "Old" && TotalPurAmt > 6000)
                {
                    // Discount  5%
                    DiscAmount = BillAmount * Convert.ToDecimal(0.05);
                }
                if (TypeOfCust == "Old" && SinceFrom.AddYears(5).Year == DateTime.Now.Year)
                {
                    // Discount  20%
                    DiscAmount = BillAmount * 2;
                }

            }

            return DiscAmount;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                FrmMaster objMaster = new FrmMaster();
                objMaster.ExportToPDF(dataGridView1,false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        }
   
        }
    

