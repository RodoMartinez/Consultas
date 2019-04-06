using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
namespace DataAccessLayer
{
    class Datos
    {
        public string EMPNO { get; set; }
        public string PROJNO { get; set; }
    }
    class Datos1
    {
        public short ACTNO { get; set; }
        public string MGRNO { get; set; }
        public string EMSTDATE { get; set; }
        public string PROJNO { get; set; }
        public string LASTNAME { get; set; }
    }
    public class DepartmentModel
    {
        DB2LocalSQLEntities context = new DB2LocalSQLEntities();

        public List<DEPARTMENT> query01() => context.DEPARTMENT.ToList();//retorna todo
        public List<DEPARTMENT> query02() => context.DEPARTMENT.Take(5).ToList(); //retorna 5
        public object query03() => (from d in context.DEPARTMENT
                                    orderby d.ADMRDEPT descending
                                    select new { d.DEPTNO, d.DEPTNAME, d.ADMRDEPT }).ToList();

        public object query04() => (from e in context.EMPLOYEE
                                    join d in context.DEPARTMENT
                                    on e.WORKDEPT equals (d.DEPTNO)
                                    select new { e.EMPNO, e.LASTNAME, e.WORKDEPT, d.DEPTNAME }).ToList();
        //001_EstructuraSQL.pdf
        //suprimiendo valores duplicados
        public object query05() => ((from e in context.EMPLOYEE
                                     orderby e.WORKDEPT, e.JOB
                                     select new { e.WORKDEPT, e.JOB }).Distinct()).ToList();

        //filtrando la cantidad de registros solicitados
        public object query06() => (from d in context.DEPARTMENT
                                    where d.ADMRDEPT == "A00"
                                    select new { d.DEPTNO, d.ADMRDEPT }).ToList();

        public object query07() => (from e in context.EMPLOYEE
                                    where e.EDLEVEL >= 19
                                    select new { e.LASTNAME, e.EDLEVEL }).ToList();

        //uso de operadores de comparacion y logicos
        public object query08() => (from e in context.EMPLOYEE
                                    where e.JOB == "ANALYST" && e.EDLEVEL == 16
                                    select new { e.EMPNO, e.JOB, e.EDLEVEL }).ToList();

        public object query09() => (from e in context.EMPLOYEE
                                    where e.JOB == "ANALYST" || e.EDLEVEL == 16
                                    select new { e.EMPNO, e.JOB, e.EDLEVEL }).ToList();

        //uso de operadores de comparacion, logicos y parentesis
        public object query10() => (from e in context.EMPLOYEE
                                    where e.JOB == "ANALYST" && e.EDLEVEL == 16 || e.EDLEVEL == 18
                                    select new { e.EMPNO, e.JOB, e.EDLEVEL }).ToList();

        public object query11() => (from e in context.EMPLOYEE
                                    where e.JOB == "ANALYST" && (e.EDLEVEL == 16 || e.EDLEVEL == 18)
                                    select new { e.EMPNO, e.JOB, e.EDLEVEL }).ToList();

        //uso del predicado IN
        List<int> list12 = new List<int>() { 14, 19, 20 };
        public object query12() => (from e in context.EMPLOYEE
                                    where list12.Contains(e.EDLEVEL)
                                    select new { e.LASTNAME, e.EDLEVEL }).ToList();

        //uso del predicado BETWEEN
        public object query13() => (from e in context.EMPLOYEE
                                    where (e.EDLEVEL >= 14 && e.EDLEVEL <= 20)
                                    select new { e.LASTNAME, e.EDLEVEL }).ToList();

        //uso del predicado NULL
        public object query14() => (from d in context.DEPARTMENT
                                    where d.MGRNO == null
                                    select new { d.DEPTNO, d.DEPTNAME, d.MGRNO }).ToList();

        //uso del predicado LIKE
        public object query15() => (from e in context.EMPLOYEE
                                    where e.LASTNAME.StartsWith("G")
                                    select new { e.LASTNAME }).ToList();

        //002_Ejercicio06SQL.pdf
        //1.-
        public object query16() => (from e in context.EMPLOYEE
                                    where e.SALARY > 30000
                                    orderby e.SALARY descending
                                    select new { e.EMPNO, e.LASTNAME, e.BIRTHDATE, e.SALARY }).ToList();

        //2.-
        public object query17() => (from e in context.EMPLOYEE
                                    orderby e.WORKDEPT descending, e.LASTNAME descending
                                    select new { e.LASTNAME, e.FIRSTNME, e.WORKDEPT }).ToList();

        //3.-  pendiente en el order by no lo ordena
        public object query18() => ((from e in context.EMPLOYEE
                                     orderby e.EDLEVEL descending
                                     select new { e.EDLEVEL }).Distinct()).ToList();

        //4.-
        public object query19() => ((from ea in context.EMP_ACT
                        where ea.EMPNO.CompareTo("000100")<= 0
                        orderby ea.EMPNO
                        select new { ea.EMPNO, ea.PROJNO }).Distinct()).ToList();
            
        //5.-
        public object query20() => (from e in context.EMPLOYEE
                                    where e.SEX == "M"
                                    select new { e.LASTNAME, e.SALARY, e.BONUS }).ToList();

        //6.-
        public object query21() => (from e in context.EMPLOYEE
                                    where e.SALARY > 20000 && e.HIREDATE.Value.Year > 1979
                                    select new { e.LASTNAME, e.SALARY, e.COMM }).ToList();

        //7.-
        public object query22() => (from e in context.EMPLOYEE
                                    where (e.SALARY > 22000 && e.BONUS == 400) || (e.BONUS == 500 && e.COMM < 1900)
                                    orderby e.LASTNAME
                                    select new { e.LASTNAME, e.SALARY, e.BONUS, e.COMM }).ToList();

        //8.-
        public object query23() => (from e in context.EMPLOYEE
                                    where e.SALARY > 22000 && (e.BONUS == 400 || e.BONUS == 500) && e.COMM < 1900
                                    orderby e.LASTNAME
                                    select new { e.LASTNAME, e.SALARY, e.BONUS, e.COMM }).ToList();

        //9.-
        List<int> list24 = new List<int>() { 10, 80, 180 };
        public object query24() => (from ea in context.EMP_ACT
                                    where ea.PROJNO.StartsWith("AD") && list24.Contains(ea.ACTNO)
                                    orderby ea.PROJNO, ea.ACTNO
                                    select new { ea.PROJNO, ea.ACTNO, ea.EMSTDATE, ea.EMENDATE }).ToList();

        //10.-
        public object query25() => (from d in context.DEPARTMENT
                                    where d.MGRNO != null
                                    orderby d.MGRNO
                                    select new { d.MGRNO, d.DEPTNO }).ToList();

        //11.-
        public object query26() => (from e in context.EMPLOYEE
                                    where (e.BONUS >= 800 && e.BONUS <= 1000)
                                    orderby e.BONUS, e.EMPNO
                                    select new { e.EMPNO, e.LASTNAME, e.SALARY, e.BONUS }).ToList();

        //12.- 
        public object query27() => (from e in context.EMPLOYEE
                                    where e.WORKDEPT.Contains("A") || e.WORKDEPT.Contains("B") || e.WORKDEPT.Contains("C")
                                    orderby e.LASTNAME, e.EMPNO
                                    select new { e.EMPNO, e.LASTNAME, e.SALARY, e.WORKDEPT }).ToList();

        //13.-
        public object query28() => (from pr in context.PROJECT
                                    where pr.PROJNAME.Contains("SUPPORT")
                                    orderby pr.PROJNO
                                    select new { pr.PROJNO, pr.PROJNAME }).ToList();

        //14.-
        List<string> list29 = new List<string>();
        public object query29() => (from d in context.DEPARTMENT
                                    where d.DEPTNO.Substring(1, 1).Contains("1")
                                    orderby d.DEPTNO
                                    select new { d.DEPTNO, d.DEPTNAME }).ToList();

        //15.-
        public object query30() => ((from e in context.EMPLOYEE
                                    where e.JOB!="PRES" && e.JOB!="MANAGER"
                                    orderby e.SALARY descending
                                    select new { e.LASTNAME,e.FIRSTNME,e.MIDINIT,e.SALARY }).Take(5)).ToList();

        //003_Ejercicio07a.pdf
        public object query31() => (from p in context.PROJECT
                                    from d in context.DEPARTMENT
                                    where p.DEPTNO==d.DEPTNO
                                    orderby p.PROJNO
                                    select new { p.PROJNO,p.PROJNAME,d.DEPTNO,d.DEPTNAME }).ToList();

        public object query32() => (from e in context.EMPLOYEE
                                    from d in context.DEPARTMENT
                                    from p in context.PROJECT
                                    where p.DEPTNO==d.DEPTNO && d.MGRNO==e.EMPNO && d.DEPTNO=="D21"
                                    orderby p.PROJNO
                                    select new { p.PROJNO,d.DEPTNO,d.DEPTNAME,d.MGRNO,e.LASTNAME }).ToList();

        public object query33() => (from e in context.EMPLOYEE
                                    from d in context.DEPARTMENT
                                    where e.WORKDEPT==d.DEPTNO
                                    select new { e.EMPNO,e.LASTNAME,e.WORKDEPT,d.DEPTNAME }).ToList();

        public object query34() => (from e in context.EMPLOYEE
                                    from a in context.EMP_ACT
                                    where e.EMPNO==a.EMPNO
                                    select new { e.EMPNO,e.LASTNAME,a.ACTNO }).ToList();

        public object query35() => (from e in context.EMPLOYEE
                                    from d in context.DEPARTMENT
                                    where e.WORKDEPT==d.DEPTNO && e.JOB=="MANAGER"
                                    select new { e.EMPNO,e.FIRSTNME,e.LASTNAME,d.DEPTNAME }).ToList();

        public object query36() => (from e in context.EMPLOYEE
                                    join d in context.DEPARTMENT
                                    on e.WORKDEPT equals (d.DEPTNO)
                                    select new { e.EMPNO,e.LASTNAME,e.WORKDEPT,d.DEPTNAME }).ToList();

        public object query37() => (from e in context.EMPLOYEE
                                    join a in context.EMP_ACT
                                    on e.EMPNO equals (a.EMPNO)
                                    select new { e.EMPNO,e.LASTNAME,a.ACTNO }).ToList();

        public object query38() => (from e in context.EMPLOYEE
                                    join d in context.DEPARTMENT
                                    on e.WORKDEPT equals d.DEPTNO
                                    where e.JOB=="MANAGER"
                                    select new { e.EMPNO,e.FIRSTNME,e.LASTNAME,d.DEPTNAME }).ToList();
        
        public object query39() => (from e in context.EMPLOYEE
                                    join d in context.DEPARTMENT
                                    on e.WORKDEPT equals d.DEPTNO
                                    join em in context.EMPLOYEE
                                    on d.MGRNO equals em.EMPNO
                                    where e.BIRTHDATE < em.BIRTHDATE
                                    select new { E_EMPNO=e.EMPNO, E_LASTNAME= e.LASTNAME, E_BIRTHDATE=e.BIRTHDATE,M_EMPNO= em.EMPNO,M_LASTNAME= em.LASTNAME, M_BIRTHDATE= em.BIRTHDATE }).ToList();

        //004_Ejercicio07SQL.pdf
        //1.- no sale lo mismo
        public object query40() => (from e in context.EMPLOYEE
                                    join d in context.DEPARTMENT
                                    on e.WORKDEPT equals d.DEPTNO
                                    //where e.EMPNO==d.MGRNO
                                    orderby d.DEPTNAME, e.LASTNAME, e.FIRSTNME
                                    select new { e.LASTNAME,e.FIRSTNME,d.DEPTNAME}).ToList();

        //2.-
        public object query41() => (from e in context.EMPLOYEE
                                    join d in context.DEPARTMENT
                                    on e.WORKDEPT equals d.DEPTNO
                                    where e.WORKDEPT.CompareTo("A02")>= 0 && e.WORKDEPT.CompareTo("D22")<=0 && e.JOB != "MANAGER"
                                    orderby d.DEPTNAME, e.JOB, e.LASTNAME, e.FIRSTNME
                                    select new { e.LASTNAME,e.FIRSTNME,d.DEPTNAME,e.JOB }).ToList();

        //3.-
        public object query42() => (from e in context.EMPLOYEE
                                    join d in context.DEPARTMENT
                                    on e.EMPNO equals d.MGRNO
                                    where d.ADMRDEPT != null
                                    orderby d.DEPTNAME
                                    select new { d.DEPTNAME,e.LASTNAME,e.FIRSTNME }).ToList();

        //4.-
        public object query43() => (from e in context.EMPLOYEE
                                    join d in context.DEPARTMENT
                                    on e.WORKDEPT equals d.DEPTNO
                                    orderby d.DEPTNAME
                                    select new { d.DEPTNAME, e.LASTNAME, e.FIRSTNME }).ToList();

        //5.-
        public object query44() => ((from p in context.PROJECT
                                    join ea in context.EMP_ACT
                                    on p.PROJNO equals ea.PROJNO
                                    where p.PROJNO.StartsWith("AD")
                                    orderby p.PROJNO,ea.ACTNO
                                    select new { p.PROJNO,p.PROJNAME,ea.ACTNO }).Distinct()).ToList();

        //6.-
        public object query45() => ((from e in context.EMPLOYEE
                                    join ea in context.EMP_ACT
                                    on e.EMPNO equals ea.EMPNO
                                    join p in context.PROJECT
                                    on ea.PROJNO equals p.PROJNO
                                    where p.PROJNO=="AD3113"
                                    orderby e.EMPNO,p.PROJNO
                                    select new { e.EMPNO,e.LASTNAME,p.PROJNO }).Distinct()).ToList();

        //7.-
        public object query46() => (from p in context.PROJECT
                                    join ea in context.EMP_ACT
                                    on p.PROJNO equals ea.PROJNO
                                    where ea.EMSTDATE.Value.Year== 1982 
                                    && ea.EMSTDATE.Value.Day==01 
                                    && ea.EMSTDATE.Value.Month==10
                                    orderby ea.PROJNO,ea.EMPNO,ea.ACTNO
                                    select new { ea.EMPNO,p.PROJNO,p.PROJNAME,ea.ACTNO,ea.EMSTDATE }).ToList();

        //8.-
        public object query47() => (from e in context.EMPLOYEE
                                    join ea in context.EMP_ACT
                                    on e.EMPNO equals ea.EMPNO
                                    join p in context.PROJECT
                                    on ea.PROJNO equals p.PROJNO
                                    join d in context.DEPARTMENT
                                    on e.WORKDEPT equals d.DEPTNO
                                    where e.WORKDEPT=="A00"
                                    orderby e.WORKDEPT,ea.ACTNO
                                    select new { e.WORKDEPT,e.LASTNAME,p.PROJNAME,ea.ACTNO }).ToList();

        //9.- no ordena
        public object query48() => ((from e in context.EMPLOYEE
                                    join ea in context.EMP_ACT
                                    on e.EMPNO equals ea.EMPNO
                                    join p in context.PROJECT
                                    on ea.PROJNO equals p.PROJNO
                                    where e.WORKDEPT.CompareTo("A00")>=0 && e.WORKDEPT.CompareTo("C01")<=0
                                    orderby e.WORKDEPT//,e.LASTNAME, ea.ACTNO
                                    select new { e.WORKDEPT,e.LASTNAME,p.PROJNAME,ea.ACTNO }).Distinct()).ToList();

        //10.- 
        //List<Datos1> list49 = new List<Datos1>();
        DateTime fecha = DateTime.Parse("15/10/1982");
        public object query49() => (from e in context.EMPLOYEE
                                    join ea in context.EMP_ACT
                                    on e.EMPNO equals ea.EMPNO
                                    join p in context.PROJECT
                                    on ea.PROJNO equals p.PROJNO
                                    join d in context.DEPARTMENT
                                    on e.WORKDEPT equals d.DEPTNO
                                    where ea.EMSTDATE.Value >= fecha
                                    orderby ea.ACTNO, ea.EMSTDATE
                                    select new { ea.ACTNO, d.MGRNO, ea.EMSTDATE, p.PROJNO, e.LASTNAME }).ToList();

        //11.- 
        public object query50() => (from e in context.EMPLOYEE
                                    join d in context.DEPARTMENT
                                    on e.WORKDEPT equals d.DEPTNO
                                    join em in context.EMPLOYEE
                                    on d.MGRNO equals em.EMPNO
                                    where d.DEPTNO == "A00" && e.EMPNO != em.EMPNO
                                    //orderby e.LASTNAME
                                    select new { d.DEPTNO, MANAGER = em.LASTNAME,EMPLOYEE= e.LASTNAME, M_HIREDATE = em.HIREDATE,E_HIREDATE= e.HIREDATE }).ToList();


        //public object query031() => (from d in context.DEPARTMENT orderby d.ADMRDEPT descending select new { d.DEPTNO, d.DEPTNAME, d.ADMRDEPT }).ToList();
        //public object query031()
        //{
        //    LINQ
        //    var qry = from d in context.DEPARTMENT select new { d.DEPTNO,d.DEPTNAME,d.ADMRDEPT };
        //    Entity proyeccion
        //    var qry =context.DEPARTMENT.Select(de=>new{de.DEPTNAME})
        //    return qry.ToList();
        //    creamos una lista y el retorno una lista
        //    forearch(var info in qry){
        //    lista.add(info.depname);
        //    }
        //    return lista
        //}
    }
}
