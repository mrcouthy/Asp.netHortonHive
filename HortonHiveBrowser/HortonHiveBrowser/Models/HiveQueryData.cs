using System;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;

namespace HortonHiveBrowser.Models
{
    public class ReportModel
    {
        public string ReportDate { get; set; }
        public DataTable Report { get; set; }
    }

    public class HiveQueryDataService
    {
        public DataTable GetDataFromHivet(string t)
        {
            var dt = new DataTable("MyTable");
            dt.Columns.Add(new DataColumn("Col1", typeof (string)));
            dt.Columns.Add(new DataColumn("Col2", typeof (string)));
            dt.Columns.Add(new DataColumn("Col3", typeof (string)));

            for (int i = 0; i < 3; i++)
            {
                DataRow row = dt.NewRow();
                row["Col1"] = "col 1, row " + i;
                row["Col2"] = "col 2, row " + i;
                row["Col3"] = "col 3, row " + i;
                dt.Rows.Add(row);
            }
            return dt;
        }

        public DataTable GetDataFromHive(string hiveQl)
        {
            var dbConnection = new OdbcConnection("DSN=horton");
            try
            {
                dbConnection.Open();
            }
            catch (OdbcException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            OdbcCommand cmd = dbConnection.CreateCommand();
            cmd.CommandText = hiveQl; // "SELECT * FROM sample_08 LIMIT 100;";
            DbDataReader dr = cmd.ExecuteReader();
            var dataTable = new DataTable();
            dataTable.Load(dr);
            dbConnection.Close();
            return dataTable;
        }
    }
}