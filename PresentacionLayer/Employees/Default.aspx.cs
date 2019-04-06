using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionLayer.Employees
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadTable();
        }

        public void loadTable()
        {
            EmployeeModel em = new EmployeeModel();
            GridView1.DataSource = em.getAll();
            GridView1.DataBind();
        }
    }
}