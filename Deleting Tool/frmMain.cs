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
    public partial class frmMain : Form
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


        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            OdbcCommand sqlCmd = new OdbcCommand();
            string sql = "update ac_role set role_description = 'IGR Audit' where role_description = 'LIC'";
            sqlCmd.Connection = Connect();
            sqlCmd.CommandText = sql;
            sqlCmd.ExecuteNonQuery();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DeedParameter dp = new DeedParameter();
            dp.ShowDialog();
        }
    }
}
