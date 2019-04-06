using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using EntitiesLayer;
namespace PresentacionLayer.Departments
{
    public partial class Default : System.Web.UI.Page
    {
        ListItem list;
        protected void Page_Load(object sender, EventArgs e)
        {
            llenar("01"); llenar("02"); llenar("03"); llenar("04"); llenar("05"); llenar("06"); llenar("07"); llenar("08"); llenar("09"); llenar("10");
            llenar("11"); llenar("12"); llenar("13"); llenar("14"); llenar("15"); llenar("16"); llenar("17"); llenar("18"); llenar("19"); llenar("20");
            llenar("21"); llenar("22"); llenar("23"); llenar("24"); llenar("25"); llenar("26"); llenar("27"); llenar("28"); llenar("29"); llenar("30");
            llenar("31"); llenar("32"); llenar("33"); llenar("34"); llenar("35"); llenar("36"); llenar("37"); llenar("38"); llenar("39"); llenar("40");
            llenar("41"); llenar("42"); llenar("43"); llenar("44"); llenar("45"); llenar("46"); llenar("47"); llenar("48"); llenar("49"); llenar("50");

            consulta("query19");
        }

        public void llenar(string num)
        {
            list = new ListItem("query"+num, num);
            DropDownList1.Items.Add(list);
        }

        private void consulta(string query)
        {
            DepartmentModel dm = new DepartmentModel();
            switch (query)
            {
                case "query01": GridView1.DataSource = dm.query01(); break;
                case "query02": GridView1.DataSource = dm.query02(); break;
                case "query03": GridView1.DataSource = dm.query03(); break;
                case "query04": GridView1.DataSource = dm.query04(); break;
                case "query05": GridView1.DataSource = dm.query05(); break;
                case "query06": GridView1.DataSource = dm.query06(); break;
                case "query07": GridView1.DataSource = dm.query07(); break;
                case "query08": GridView1.DataSource = dm.query08(); break;
                case "query09": GridView1.DataSource = dm.query09(); break;
                case "query10": GridView1.DataSource = dm.query10(); break;
                case "query11": GridView1.DataSource = dm.query11(); break;
                case "query12": GridView1.DataSource = dm.query12(); break;
                case "query13": GridView1.DataSource = dm.query13(); break;
                case "query14": GridView1.DataSource = dm.query14(); break;
                case "query15": GridView1.DataSource = dm.query15(); break;
                case "query16": GridView1.DataSource = dm.query16(); break;
                case "query17": GridView1.DataSource = dm.query17(); break;
                case "query18": GridView1.DataSource = dm.query18(); break;
                case "query19": GridView1.DataSource = dm.query19(); break;
                case "query20": GridView1.DataSource = dm.query20(); break;
                case "query21": GridView1.DataSource = dm.query21(); break;
                case "query22": GridView1.DataSource = dm.query22(); break;
                case "query23": GridView1.DataSource = dm.query23(); break;
                case "query24": GridView1.DataSource = dm.query24(); break;
                case "query25": GridView1.DataSource = dm.query25(); break;
                case "query26": GridView1.DataSource = dm.query26(); break;
                case "query27": GridView1.DataSource = dm.query27(); break;
                case "query28": GridView1.DataSource = dm.query28(); break;
                case "query29": GridView1.DataSource = dm.query29(); break;
                case "query30": GridView1.DataSource = dm.query30(); break;
                case "query31": GridView1.DataSource = dm.query31(); break;
                case "query32": GridView1.DataSource = dm.query32(); break;
                case "query33": GridView1.DataSource = dm.query33(); break;
                case "query34": GridView1.DataSource = dm.query34(); break;
                case "query35": GridView1.DataSource = dm.query35(); break;
                case "query36": GridView1.DataSource = dm.query36(); break;
                case "query37": GridView1.DataSource = dm.query37(); break;
                case "query38": GridView1.DataSource = dm.query38(); break;
                case "query39": GridView1.DataSource = dm.query39(); break;
                case "query40": GridView1.DataSource = dm.query40(); break;
                case "query41": GridView1.DataSource = dm.query41(); break;
                case "query42": GridView1.DataSource = dm.query42(); break;
                case "query43": GridView1.DataSource = dm.query43(); break;
                case "query44": GridView1.DataSource = dm.query44(); break;
                case "query45": GridView1.DataSource = dm.query45(); break;
                case "query46": GridView1.DataSource = dm.query46(); break;
                case "query47": GridView1.DataSource = dm.query47(); break;
                case "query48": GridView1.DataSource = dm.query48(); break;
                case "query49": GridView1.DataSource = dm.query49(); break;
                case "query50": GridView1.DataSource = dm.query50(); break;
            }
            GridView1.DataBind();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            consulta(DropDownList1.SelectedItem.Text);
        }
    }
}