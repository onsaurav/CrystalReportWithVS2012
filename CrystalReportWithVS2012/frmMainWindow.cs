using CrystalReportWithVS2012.ReportClasses.ReportData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrystalReportWithVS2012
{
    public partial class frmMainWindow : Form
    {
        public frmMainWindow()
        {
            InitializeComponent();
        }

        private void frmMainWindow_Load(object sender, EventArgs e)
        {

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            string strSelection = "";
            CrystalDecisions.CrystalReports.Engine.ReportClass ReportObject;

            //To Select the data by parameters you shound add here
            if (!txtSearchingParameter1.Text.Trim().Equals(string.Empty))
            {
                strSelection = strSelection + (strSelection == "" ? "" : " And ");
                strSelection = strSelection + "{CrystalReportWithVS2012_ReportClasses_ReportData_AMIN_ITEMS.NAME}='" + txtSearchingParameter1.Text.Trim() + "'";
            }

            List<AMIN_ITEMS> list = new List<AMIN_ITEMS>();

            list = LoadData();

            ReportObject = new TestCrystalReport();
            ReportObject.SetDataSource(list);

            //To show value directly in the crystal report you should add a parameter and submet data like this
            CrystalDecisions.Shared.ParameterDiscreteValue crParameter1 = new CrystalDecisions.Shared.ParameterDiscreteValue();
            crParameter1.Value = txtShowValue1.Text;
            ReportObject.SetParameterValue("FirstParameter", crParameter1);

            CrystalDecisions.Shared.ParameterDiscreteValue crParameter2 = new CrystalDecisions.Shared.ParameterDiscreteValue();
            crParameter2.Value = txtShowValue2.Text;
            ReportObject.SetParameterValue("SecondParameter", crParameter2);
                        
            ReportAccess.ShowReport(ReportObject, strSelection);
        }

        private List<AMIN_ITEMS> LoadData()
        {
            List<AMIN_ITEMS> list = new List<AMIN_ITEMS>();

            SqlConnection _SqlConnection = new SqlConnection(@"Data Source=tcp:cydehlfdvp.database.windows.net,1433;Database=amin_db;User ID=amin_username@cydehlfdvp;Password=Password1!;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;");
            if (_SqlConnection.State.ToString().Equals("Closed")) _SqlConnection.Open();

            DataSet DS = new DataSet();
            string query = @"SELECT * FROM AMIN_ITEMS";
            SqlDataAdapter _SqlDataAdapter = new SqlDataAdapter();
            _SqlDataAdapter.SelectCommand = new SqlCommand(query, _SqlConnection);
            _SqlDataAdapter.Fill(DS);

            for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
            {
                AMIN_ITEMS _AMIN_ITEMS = new AMIN_ITEMS();

                _AMIN_ITEMS.Id = int.Parse(DS.Tables[0].Rows[i][0].ToString());
                _AMIN_ITEMS.CATEGORY = DS.Tables[0].Rows[i][1].ToString();
                _AMIN_ITEMS.NAME = DS.Tables[0].Rows[i][2].ToString();
                _AMIN_ITEMS.COLOUR = DS.Tables[0].Rows[i][3].ToString();
                _AMIN_ITEMS.BRAND = DS.Tables[0].Rows[i][4].ToString();
                _AMIN_ITEMS.SIZE = DS.Tables[0].Rows[i][5].ToString();
                _AMIN_ITEMS.UNITS = DS.Tables[0].Rows[i][6].ToString();
                _AMIN_ITEMS.REMARKS = DS.Tables[0].Rows[i][7].ToString();
                _AMIN_ITEMS.USERID = DS.Tables[0].Rows[i][8].ToString();
                _AMIN_ITEMS.RECORD_INSERTED_DATE = DateTime.Parse(DS.Tables[0].Rows[i][9].ToString());
                _AMIN_ITEMS.RECORD_UPDATED_DATE = DateTime.Parse(DS.Tables[0].Rows[i][10].ToString());

                list.Add(_AMIN_ITEMS);
            }

            return list;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
