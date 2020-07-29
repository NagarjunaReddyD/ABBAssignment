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
    public partial class FrmItem : Form
    {
        dynamic objBLItem;
        int SelectedId = 0;
       // string SelectedName = "";
        public FrmItem()
        {
            InitializeComponent();
            Program.Bootstrap();
            objBLItem = Program.container.Resolve<BLItem>();
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
        }


        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //if (ValidateMandUserFields())
            //{
            //    ModelBookStore.Item objItem = new ModelBookStore.Item();
            //    {
            //        objItem.Name = txtItemName.Text;
            //        objItem.Price = Convert.ToDecimal(txtPrice.Text);
            //    }



            //    Save(objItem);
            //    Reset();
            //    MessageBox.Show("Added Successfully");
            //}
            //else
            //{
            //    lblValidationSummary.Visible = true;

            //}

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ValidateMandUserFields())
            {
                if (! String.IsNullOrEmpty(txtItemName.Text))
                {
                    if (String.IsNullOrEmpty(txtPrice.Text))
                    {
                        txtPrice.Text = "0.0";
                    }

                    ModelBookStore.Item objItem = new ModelBookStore.Item();
                    {
                        objItem.Name = txtItemName.Text;
                        objItem.Price = Convert.ToDecimal( txtPrice.Text);
                        objItem.id = SelectedId;
                    }



                    Update(objItem);
                    Reset();
                    MessageBox.Show("Updated Successfully");
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
                    ModelBookStore.Item objItem = new ModelBookStore.Item();
                    {
                        objItem.Name = txtItemName.Text;

                        objItem.id = SelectedId;
                    }



                    Delete(objItem);
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
        private void Save(ModelBookStore.Item objItem)
        {
         
            objBLItem.Add(objItem);
        }
        private void Update(ModelBookStore.Item objItem)
        {
           
            objBLItem.Update(objItem);
        }
        private void Delete(ModelBookStore.Item objItem)
        {
           
            objBLItem.Delete(objItem);
        }
        private bool ValidateMandUserFields()
        {
            bool ValidateUser = true;
          
            lblItemNameMand.Visible = false;
            lblItemPriceMand.Visible = false;
           
            lblValidationSummary.Visible = false;
            if (string.IsNullOrEmpty(txtItemName.Text))
            {
                lblItemNameMand.Visible = true;
                txtItemName.Focus();
               
                //return "Please Enter FirstName";
                ValidateUser = false;
            }
            if (string.IsNullOrEmpty(txtPrice.Text))
            {
                lblItemPriceMand.Visible = true;
                txtPrice.Focus();

                //return "Please Enter FirstName";
                ValidateUser = false;
            }

            return ValidateUser;
        }
            private void Reset()
        {
            txtItemName.Text = "";
            txtPrice.Text = "";
            SelectedId = 0;
           
            List<ModelBookStore.Item> objItemList = LoadData();
            dataGridView1.DataSource = objItemList;

        }
        private List<ModelBookStore.Item> LoadData()
        {
            List<ModelBookStore.Item> objItemList = objBLItem.Load();

            return objItemList;
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
                txtItemName.Text = row.Cells[1].Value.ToString();
                txtPrice.Text= row.Cells[2].Value.ToString();

                SelectedId = Convert.ToInt32( row.Cells[0].Value);
                //SelectedName= row.Cells[1].Value.ToString();
            }

        }

      
    }
}
