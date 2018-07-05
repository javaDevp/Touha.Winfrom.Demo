using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Touha.Tools.Common.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet ds = new DataSet();
            DataTable dtTran = new DataTable();
            dtTran.Columns.Add("tran_no");
            dtTran.Columns.Add("parent_tran_no");
            dtTran.Columns.Add("desc");
            dtTran.Columns.Add("sql");
            DataRow dr = dtTran.NewRow();
            dr["tran_no"] = "T_10";
            dr["desc"] = "xx交易";
            dtTran.Rows.Add(dr);
            dr = dtTran.NewRow();
            dr["tran_no"] = "T_101";
            dr["parent_tran_no"] = "T_10";
            dr["desc"] = "xx交易";
            dtTran.Rows.Add(dr);
            dr = dtTran.NewRow();
            dr["tran_no"] = "T_102";
            dr["parent_tran_no"] = "T_10";
            dr["desc"] = "xx交易";
            dtTran.Rows.Add(dr);
            ds.Tables.Add(dtTran);


            DataTable dtTranField = new DataTable();
            dtTranField.Columns.Add("tran_no");
            dtTranField.Columns.Add("field_name");
            dr = dtTranField.NewRow();
            dr["tran_no"] = "T_101";
            dr["field_name"] = "a";
            dtTranField.Rows.Add(dr);
            dr = dtTranField.NewRow();
            dr["tran_no"] = "T_102";
            dr["field_name"] = "b";
            dtTranField.Rows.Add(dr);
            ds.Tables.Add(dtTranField);

            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(AppDomain.CurrentDomain.BaseDirectory + "config.xml");

            string tran_no = xdoc.SelectSingleNode("request").Attributes["tran_no"].Value;
            Console.WriteLine(tran_no);
            DataSet trands = GetTransInfo(tran_no);

            Console.ReadKey();


        }

        private static DataSet GetTransInfo(string tran_no)
        {
            DataSet ds = new DataSet();
            DataTable dtTran = new DataTable();
            dtTran.Columns.Add("tran_no");
            dtTran.Columns.Add("parent_tran_no");
            dtTran.Columns.Add("desc");
            dtTran.Columns.Add("sql");
            DataRow dr = dtTran.NewRow();
            dr["tran_no"] = "T_10";
            dr["desc"] = "xx交易";
            dtTran.Rows.Add(dr);
            dr = dtTran.NewRow();
            dr["tran_no"] = "T_101";
            dr["parent_tran_no"] = "T_10";
            dr["desc"] = "xx交易";
            dtTran.Rows.Add(dr);
            dr = dtTran.NewRow();
            dr["tran_no"] = "T_102";
            dr["parent_tran_no"] = "T_10";
            dr["desc"] = "xx交易";
            dtTran.Rows.Add(dr);
            ds.Tables.Add(dtTran);


            DataTable dtTranField = new DataTable();
            dtTranField.Columns.Add("tran_no");
            dtTranField.Columns.Add("field_name");
            dr = dtTranField.NewRow();
            dr["tran_no"] = "T_101";
            dr["field_name"] = "a";
            dtTranField.Rows.Add(dr);
            dr = dtTranField.NewRow();
            dr["tran_no"] = "T_102";
            dr["field_name"] = "b";
            dtTranField.Rows.Add(dr);
            ds.Tables.Add(dtTranField);
            return ds;
        }
    }
}
