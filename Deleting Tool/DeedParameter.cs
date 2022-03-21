using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.Odbc;
using NovaNet.Utils;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Deleting_Tool
{
    public partial class DeedParameter : Form
    {
        public static string INI_FILE_NAME = "EDMS.INI";
        public static string INI_SECTION = "DBCon";
        public static string INI_KEY = "EDMS";

        public OdbcConnection dbcon;
        public string err = null;

        //OdbcConnection sqlCon = null;
        private Credentials crd = new Credentials();

        private INIReader rd = null;
        private KeyValueStruct udtKeyValue;
        private FileorFolder fileExs = null;
        private IWin32Window parentWindow;
        private bool cancelNot = false;

        public DeedParameter()
        {
            InitializeComponent();
        }
        public OdbcConnection Connect()
        {
            string conString = null;
            string iniPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Remove(0, 6) + "\\" + INI_FILE_NAME;
            string err = null;
            fileExs = new FileorFolder();
            DialogResult result;
            INIFile ini = new INIFile();
            dbcon = new OdbcConnection(conString);


            try
            {
                if (File.Exists(iniPath) == true)
                {
                    conString = ini.ReadINI(INI_SECTION, INI_KEY, string.Empty, iniPath);
                    dbcon.ConnectionString = conString;
                    dbcon.Open();
                }
                else
                {
                    rd = new INIReader(Constants.EXCEPTION_INI_FILE_PATH);
                    udtKeyValue.Key = Constants.INI_FILE_EROR.ToString();
                    udtKeyValue.Section = Constants.COMMON_EXCEPTION_SECTION;
                    string ErrMsg = rd.Read(udtKeyValue);
                    //result = MessageBox.Show("Error while connect to the database...You want to create it?", "Connection error", MessageBoxButtons.YesNo);
                    //if (result == DialogResult.Yes)
                    //{
                    //    frmConnection frmConn = new frmConnection(iniPath);
                    //}
                    //else
                    //{
                    //    Application.Exit();
                    //}
                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
                //result = MessageBox.Show("Error while connect to the database...You want to create it?","Connection error",MessageBoxButtons.YesNo);
                //if (result == DialogResult.Yes)
                //{
                //    frmConnection frmConn = new frmConnection(iniPath);
                //}
                //else
                //{
                //    Application.Exit();
                //}
            }
            if (dbcon.State == ConnectionState.Closed)
            {
                rd = new INIReader(Constants.EXCEPTION_INI_FILE_PATH);
                udtKeyValue.Key = Constants.DB_CONNECTION_ERROR.ToString();
                udtKeyValue.Section = Constants.DB_CONNECTION_EXCEPTION_SECTION;
                string ErrMsg = rd.Read(udtKeyValue);
                result = MessageBox.Show("Error while connect to the database...You want to create it?", "Connection error", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    frmConnection frmConn = new frmConnection(iniPath);
                    if (parentWindow != null)
                    {
                        frmConn.ShowDialog(parentWindow);
                    }
                    else
                    {
                        frmConn.ShowDialog();
                    }
                    if ((File.Exists(iniPath) == true))
                    {
                        conString = ini.ReadINI(Constants.INI_SECTION, Constants.INI_KEY, string.Empty, iniPath);
                        dbcon.ConnectionString = conString;
                        dbcon.Open();
                    }
                }
                else
                {
                    Application.Exit();
                }
            }
            return dbcon;
        }

        private void DeedParameter_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        public AutoCompleteStringCollection GetSuggestionsYear(string fldName, string tblName, string fldDO, string fldRO, string fldBook)
        {
            AutoCompleteStringCollection x = new AutoCompleteStringCollection();
            string sql = "Select distinct " + fldName + " from " + tblName +" WHERE district_code = " + fldDO + " and ro_code = " + fldRO + " and book = "+ fldBook;
            DataSet ds = new DataSet();
            OdbcCommand cmd = new OdbcCommand(sql, Connect());
            OdbcDataAdapter odap = new OdbcDataAdapter(cmd);
            odap.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    x.Add(ds.Tables[0].Rows[i][0].ToString().Trim());
                }
            }
            //x.Add("Others");
            //x.Add("NA");
            return x;
        }

        public AutoCompleteStringCollection GetSuggestionsVolume(string fldName, string tblName, string fldDO, string fldRO, string fldBook, string fldYear)
        {
            AutoCompleteStringCollection x = new AutoCompleteStringCollection();
            string sql = "Select distinct " + fldName + " from " + tblName + " WHERE district_code = " + fldDO + " and ro_code = " + fldRO + " and book = " + fldBook + " and deed_year = " + fldYear;
            DataSet ds = new DataSet();
            OdbcCommand cmd = new OdbcCommand(sql, Connect());
            OdbcDataAdapter odap = new OdbcDataAdapter(cmd);
            odap.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    x.Add(ds.Tables[0].Rows[i][0].ToString().Trim());
                }
            }
            //x.Add("Others");
            //x.Add("NA");
            return x;
        }

        public AutoCompleteStringCollection GetSuggestionsDeed(string fldName, string tblName, string fldDO, string fldRO, string fldBook, string fldYear, string fldVol)
        {
            AutoCompleteStringCollection x = new AutoCompleteStringCollection();
            string sql = "Select distinct " + fldName + " from " + tblName + " WHERE district_code = " + fldDO + " and ro_code = " + fldRO + " and book = " + fldBook + " and deed_year = " + fldYear + " and volume_no = " + fldVol;
            DataSet ds = new DataSet();
            OdbcCommand cmd = new OdbcCommand(sql, Connect());
            OdbcDataAdapter odap = new OdbcDataAdapter(cmd);
            odap.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    x.Add(ds.Tables[0].Rows[i][0].ToString().Trim());
                }
            }
            //x.Add("Others");
            //x.Add("NA");
            return x;
        }

        private void DeedParameter_Load(object sender, EventArgs e)
        {
            DistrictCombo();
            ROCombo();
            BookCombo();



            //this.textBoxYear.AutoCompleteCustomSource = GetSuggestionsYear("deed_year", "deed_details", PopulateDis(), PopulateRO(), comboBoxBook.SelectedValue.ToString());
            //this.textBoxYear.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //this.textBoxYear.AutoCompleteSource = AutoCompleteSource.CustomSource;

            comboBoxBook.Focus();
            comboBoxBook.Select();

           
          
        }
        public string PopulateDis()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            string sqlquery = "select district_code from district where active = 'Y'";
            OdbcDataAdapter odap = new OdbcDataAdapter(sqlquery, Connect());
            odap.Fill(dt);
            string x= dt.Rows[0][0].ToString();
            return x;
        }
        public string PopulateRO()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            string sqlquery = "select ro_code from ro_master where active = 'Y'";
            OdbcDataAdapter odap = new OdbcDataAdapter(sqlquery, Connect());
            odap.Fill(dt);
        
            string x = dt.Rows[0][0].ToString();
            return x;
        }
        public string PopulateBook(string book)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            string sqlquery = "select value_book from tbl_book where key_book = '"+book+"'";
            OdbcDataAdapter odap = new OdbcDataAdapter(sqlquery, Connect());
            odap.Fill(dt);

            string x = dt.Rows[0][0].ToString();
            return x;

        }

        public void DistrictCombo()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            string sqlquery = "select district_code,district_name from district where active = 'Y'";
            OdbcDataAdapter odap = new OdbcDataAdapter(sqlquery, Connect());
            odap.Fill(dt);
            comboBoxDis.DataSource = dt;
            comboBoxDis.DisplayMember = "district_name";
            comboBoxDis.ValueMember = "district_code";
            comboBoxDis.Enabled = false;
        }

        public void ROCombo()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            string sqlquery = "select ro_code,ro_name from ro_master where active = 'Y'";
            OdbcDataAdapter odap = new OdbcDataAdapter(sqlquery, Connect());
            odap.Fill(dt);
            comboBoxRO.DataSource = dt;
            comboBoxRO.DisplayMember = "ro_name";
            comboBoxRO.ValueMember = "ro_code";
            comboBoxRO.Enabled = false;
        }

        public void BookCombo()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            string sqlquery = "select key_book,value_book from tbl_book "; //where value_book = '1' or value_book = '4'
            OdbcDataAdapter odap = new OdbcDataAdapter(sqlquery, Connect());
            odap.Fill(dt);
            comboBoxBook.DataSource = dt;
            comboBoxBook.DisplayMember = "key_book";
            comboBoxBook.ValueMember = "value_book";
            comboBoxBook.Enabled = true;
            
        }

        

        private void DeedParameter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void DeedParameter_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar = Keys.Escape.)
              //  this.Close();
            if (e.KeyChar == (char)Keys.Escape)
                this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxYear_Leave(object sender, EventArgs e)
        {
            if ((textBoxYear.Text != null) || (textBoxYear.Text != ""))
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                string sqlquery = "select deed_year from deed_details where district_code = '" + comboBoxDis.SelectedValue + "' and ro_code = '" + comboBoxRO.SelectedValue + "' and book = '" + PopulateBook(comboBoxBook.Text) + "' and deed_year = '"+textBoxYear.Text+"'";
                OdbcDataAdapter odap = new OdbcDataAdapter(sqlquery, Connect());
                odap.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    this.textBoxVol.AutoCompleteCustomSource = GetSuggestionsVolume("volume_no", "deed_details", PopulateDis(), PopulateRO(), PopulateBook(comboBoxBook.Text), textBoxYear.Text);
                    this.textBoxVol.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    this.textBoxVol.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
                else
                {
                    MessageBox.Show("~~ Please choose proper Year ~~");
                    //textBoxYear.Focus();
                    //textBoxYear.Select();
                }
            }
            else
            {
                MessageBox.Show("~~ You cannot leave the year field blank ~~");
                textBoxYear.Focus();
                textBoxYear.Select();
            }
        }

        private void textBoxVol_Leave(object sender, EventArgs e)
        {
                if ((textBoxVol.Text != null) || (textBoxVol.Text != ""))
                {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                string sqlquery = "select volume_no from deed_details where district_code = '" + comboBoxDis.SelectedValue + "' and ro_code = '" + comboBoxRO.SelectedValue + "' and book = '" + PopulateBook(comboBoxBook.Text) + "' and Deed_year = '" + textBoxYear.Text + "' and volume_no = '" + textBoxVol.Text + "'";
                OdbcDataAdapter odap = new OdbcDataAdapter(sqlquery, Connect());
                odap.Fill(dt);
                
                if (dt.Rows.Count > 0)
                {
                        this.textBoxDeed.AutoCompleteCustomSource = GetSuggestionsDeed("deed_no", "deed_details", PopulateDis(), PopulateRO(), PopulateBook(comboBoxBook.Text), textBoxYear.Text, textBoxVol.Text);
                        this.textBoxDeed.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        this.textBoxDeed.AutoCompleteSource = AutoCompleteSource.CustomSource;

                        textBoxDeed.Focus();
                        textBoxDeed.Select();
                 }
                 else
                    {
                        MessageBox.Show("~~ Please select correct Deed Number ~~");
                        //textBoxDeed.Focus();
                        //textBoxDeed.Select();
                    }       
                }
                
                else
                {
                    MessageBox.Show("~~ Please select correct Volume Number ~~");
                    textBoxVol.Focus();
                    textBoxVol.Select();
                }
            
        }

        private void textBoxDeed_Leave(object sender, EventArgs e)
        {
            DataSet ds1 = new DataSet();
            DataTable dt1 = new DataTable();
            string sqlquery1 = "select distinct deed_no from deed_details where district_code = '" + comboBoxDis.SelectedValue + "' and ro_code = '" + comboBoxRO.SelectedValue + "' and book = '" + PopulateBook(comboBoxBook.Text) + "' and Deed_year = '" + textBoxYear.Text + "' and volume_no = '"+textBoxVol.Text+"' and deed_no = '"+textBoxDeed.Text+"'";
            OdbcDataAdapter odap1 = new OdbcDataAdapter(sqlquery1, Connect());
            odap1.Fill(dt1);

            if (dt1.Rows.Count > 0)
            {
                MessageBox.Show("~~ Now you are ready to delete ~~");
                buttonDelete.Focus();
                
            }
            else
            {
                MessageBox.Show("~~ Please select correct Deed Number ~~");
                //textBoxDeed.Focus();
                //textBoxDeed.Select();
            }
        }

        private void textBoxDeed_Enter(object sender, EventArgs e)
        {
            
        }

        private void textBoxVol_Enter(object sender, EventArgs e)
        {
            
        }

        private void textBoxYear_Enter(object sender, EventArgs e)
        {

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            bool deleteflag = deleteFn();
           

            if (deleteflag == true)
            {
                MessageBox.Show(this, "Successfully deleted...", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show(this, "Ooops!!! There is an Error - Record not Saved...", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        public bool deleteFn()
        {
            bool retVal = false;
            if(retVal == false)
            {
                _DeleteDeed();
                _DeleteDeedExcp();
                _DeleteIndex1();
                _DeleteIndex1Excp();
                _DeleteIndex2();
                _DeleteIndex2Excp();
                _DeleteoutWB();
                _DeleteoutWBList();
                _DeletePlot();
                _DeleteKhatian();
                _DeleteImageMaster();
                _DeletePolicyMaster();
                _DeleteRawdata();

                retVal = true;
            }
            return retVal;
        }

        public bool _DeleteIndex1()
        {
            bool retVal = false;
            string sql = string.Empty;

            sql = "delete from index_of_name " +
                  "WHERE `District_Code` = '" + comboBoxDis.SelectedValue + "' AND `RO_code` = '" + comboBoxRO.SelectedValue + "' AND `Book` = '" + comboBoxBook.SelectedValue + "' AND `Deed_year` = '" + textBoxYear.Text + "' AND `Deed_no` = '" + textBoxDeed.Text + "'";
            OdbcCommand cmd = new OdbcCommand(sql, Connect());
            if (cmd.ExecuteNonQuery() >= 0)
            {
                retVal = true;
            }
            return retVal;
        }

        public bool _DeleteDeed()
        {
            bool retVal = false;
            string sql = string.Empty;

            sql = "delete from deed_details " +
                  "WHERE `District_Code` = '" + comboBoxDis.SelectedValue + "' AND `RO_code` = '" + comboBoxRO.SelectedValue + "' AND `Book` = '" + comboBoxBook.SelectedValue + "' AND `Deed_year` = '" + textBoxYear.Text + "' AND `Deed_no` = '" + textBoxDeed.Text + "' AND `volume_no` = '"+textBoxVol.Text+"'";
            OdbcCommand cmd = new OdbcCommand(sql, Connect());
            if (cmd.ExecuteNonQuery() >= 0)
            {
                retVal = true;
            }
            return retVal;
        }

        public bool _DeleteDeedExcp()
        {
            bool retVal = false;
            string sql = string.Empty;

            sql = "delete from deed_details_exception " +
                  "WHERE `District_Code` = '" + comboBoxDis.SelectedValue + "' AND `RO_code` = '" + comboBoxRO.SelectedValue + "' AND `Book` = '" + comboBoxBook.SelectedValue + "' AND `Deed_year` = '" + textBoxYear.Text + "' AND `Deed_no` = '" + textBoxDeed.Text + "'";
            OdbcCommand cmd = new OdbcCommand(sql, Connect());
            if (cmd.ExecuteNonQuery() >= 0)
            {
                retVal = true;
            }
            return retVal;
        }

        public bool _DeleteIndex1Excp()
        {
            bool retVal = false;
            string sql = string.Empty;

            sql = "delete from index_of_name_exception " +
                  "WHERE `District_Code` = '" + comboBoxDis.SelectedValue + "' AND `RO_code` = '" + comboBoxRO.SelectedValue + "' AND `Book` = '" + comboBoxBook.SelectedValue + "' AND `Deed_year` = '" + textBoxYear.Text + "' AND `Deed_no` = '" + textBoxDeed.Text + "'";
            OdbcCommand cmd = new OdbcCommand(sql, Connect());
            if (cmd.ExecuteNonQuery() >= 0)
            {
                retVal = true;
            }
            return retVal;
        }

        public bool _DeleteIndex2()
        {
            bool retVal = false;
            string sql = string.Empty;

            sql = "delete from index_of_property " +
                  "WHERE `District_Code` = '" + comboBoxDis.SelectedValue + "' AND `RO_code` = '" + comboBoxRO.SelectedValue + "' AND `Book` = '" + comboBoxBook.SelectedValue + "' AND `Deed_year` = '" + textBoxYear.Text + "' AND `Deed_no` = '" + textBoxDeed.Text + "'";
            OdbcCommand cmd = new OdbcCommand(sql, Connect());
            if (cmd.ExecuteNonQuery() >= 0)
            {
                retVal = true;
            }
            return retVal;
        }

        public bool _DeleteIndex2Excp()
        {
            bool retVal = false;
            string sql = string.Empty;

            sql = "delete from index_of_property_exception " +
                  "WHERE `District_Code` = '" + comboBoxDis.SelectedValue + "' AND `RO_code` = '" + comboBoxRO.SelectedValue + "' AND `Book` = '" + comboBoxBook.SelectedValue + "' AND `Deed_year` = '" + textBoxYear.Text + "' AND `Deed_no` = '" + textBoxDeed.Text + "'";
            OdbcCommand cmd = new OdbcCommand(sql, Connect());
            if (cmd.ExecuteNonQuery() >= 0)
            {
                retVal = true;
            }
            return retVal;
        }

        public bool _DeleteoutWB()
        {
            bool retVal = false;
            string sql = string.Empty;

            sql = "delete from index_of_property_out_wb " +
                  "WHERE `District_Code` = '" + comboBoxDis.SelectedValue + "' AND `RO_code` = '" + comboBoxRO.SelectedValue + "' AND `Book` = '" + comboBoxBook.SelectedValue + "' AND `Deed_year` = '" + textBoxYear.Text + "' AND `Deed_no` = '" + textBoxDeed.Text + "'";
            OdbcCommand cmd = new OdbcCommand(sql, Connect());
            if (cmd.ExecuteNonQuery() >= 0)
            {
                retVal = true;
            }
            return retVal;
        }

        public bool _DeleteoutWBList()
        {
            bool retVal = false;
            string sql = string.Empty;

            sql = "delete from tbloutsidewblist " +
                  "WHERE `District_Code` = '" + comboBoxDis.SelectedValue + "' AND `RO_code` = '" + comboBoxRO.SelectedValue + "' AND `Book` = '" + comboBoxBook.SelectedValue + "' AND `Deed_year` = '" + textBoxYear.Text + "' AND `Deed_no` = '" + textBoxDeed.Text + "'";
            OdbcCommand cmd = new OdbcCommand(sql, Connect());
            if (cmd.ExecuteNonQuery() >= 0)
            {
                retVal = true;
            }
            return retVal;
        }

        public bool _DeletePlot()
        {
            bool retVal = false;
            string sql = string.Empty;

            sql = "delete from tblother_plots " +
                  "WHERE `District_Code` = '" + comboBoxDis.SelectedValue + "' AND `RO_code` = '" + comboBoxRO.SelectedValue + "' AND `Book` = '" + comboBoxBook.SelectedValue + "' AND `Deed_year` = '" + textBoxYear.Text + "' AND `Deed_no` = '" + textBoxDeed.Text + "'";
            OdbcCommand cmd = new OdbcCommand(sql, Connect());
            if (cmd.ExecuteNonQuery() >= 0)
            {
                retVal = true;
            }
            return retVal;
        }

        public bool _DeleteKhatian()
        {
            bool retVal = false;
            string sql = string.Empty;

            sql = "delete from tbl_other_khatian " +
                  "WHERE `District_Code` = '" + comboBoxDis.SelectedValue + "' AND `RO_code` = '" + comboBoxRO.SelectedValue + "' AND `Book` = '" + comboBoxBook.SelectedValue + "' AND `Deed_year` = '" + textBoxYear.Text + "' AND `Deed_no` = '" + textBoxDeed.Text + "'";
            OdbcCommand cmd = new OdbcCommand(sql, Connect());
            if (cmd.ExecuteNonQuery() >= 0)
            {
                retVal = true;
            }
            return retVal;
        }

        public bool _DeletePolicyMaster()
        {
            bool retVal = false;
            string sql = string.Empty;

            sql = "delete from policy_master " +
                  "WHERE `DO_CODE` = '" + comboBoxDis.SelectedValue + "' AND `BR_code` = '" + comboBoxRO.SelectedValue + "' AND `YEAR` = '" + comboBoxBook.SelectedValue + "' AND `Deed_year` = '" + textBoxYear.Text + "' AND `Deed_no` = '" + textBoxDeed.Text + "' AND `deed_vol` = '"+textBoxVol.Text+"'";
            OdbcCommand cmd = new OdbcCommand(sql, Connect());
            if (cmd.ExecuteNonQuery() >= 0)
            {
                retVal = true;
            }
            return retVal;
        }

        public string FindPolicyImage_master()
        {
            string polno = comboBoxDis.SelectedValue.ToString() + comboBoxRO.SelectedValue.ToString() + comboBoxBook.SelectedValue.ToString() + textBoxYear.Text + "[" + textBoxDeed.Text + "]"; 
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            string sqlquery = "select policy_number from image_master where policy_number = '" + polno + "'";
            OdbcDataAdapter odap = new OdbcDataAdapter(sqlquery, Connect());
            odap.Fill(dt);
            string Final_polno="";
            if (dt.Rows.Count > 0)
            {
                Final_polno = dt.Rows[0][0].ToString();
            }
            return Final_polno;
        }

        public string FindPolicyRawdata()
        {
            string polno = comboBoxDis.SelectedValue.ToString() + comboBoxRO.SelectedValue.ToString() + comboBoxBook.SelectedValue.ToString() + textBoxYear.Text + "[" + textBoxDeed.Text + "]"; 
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            string sqlquery = "select policy_no from rawdata where policy_no = '"+polno+"'";
            OdbcDataAdapter odap = new OdbcDataAdapter(sqlquery, Connect());
            odap.Fill(dt);
            string Final_polno = "";
            if (dt.Rows.Count > 0)
            {
                Final_polno = dt.Rows[0][0].ToString();
            }
            return Final_polno;
        }

        public bool _DeleteImageMaster()
        {
            bool retVal = false;
            string sql = string.Empty;

            sql = "delete from image_master " +
                  "WHERE `policy_number` = '" + FindPolicyImage_master() + "'";
            OdbcCommand cmd = new OdbcCommand(sql, Connect());
            if (cmd.ExecuteNonQuery() >= 0)
            {
                retVal = true;
            }
            return retVal;
        }

        public bool _DeleteRawdata()
        {
            bool retVal = false;
            string sql = string.Empty;

            sql = "delete from rawdata " +
                  "WHERE `policy_no` = '" + FindPolicyRawdata() + "'";
            OdbcCommand cmd = new OdbcCommand(sql, Connect());
            if (cmd.ExecuteNonQuery() >= 0)
            {
                retVal = true;
            }
            return retVal;
        }
    }
}
