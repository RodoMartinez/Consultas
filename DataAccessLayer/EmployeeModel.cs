using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class EmployeeModel
    {
        public List<EMPLOYEE> getAll()
        {
            using (DB2LocalSQLEntities context = new DB2LocalSQLEntities())
            {
                return context.EMPLOYEE.ToList();
            }
        }
    }
}
