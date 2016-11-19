

using System;
using System.Data;
using System.Data.OleDb;

namespace Artesanias_AMG
{
    class Reports
    {
        public static DataTable getSalesByDate(string date)
        {
            OleDbConnection conexion = BD.GetConnection();
            OleDbDataAdapter dataAdapter;
            DataTable dataTable = new DataTable();



            try
            {
                OleDbCommand comando = new OleDbCommand("SELECT * FROM Venta where fecha = #" + date + "#;", conexion);
                dataAdapter = new OleDbDataAdapter(comando);
                dataAdapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conexion.State.ToString() == "Open")
                    conexion.Close();
                BD.setConnection(conexion);
            }
            return dataTable;
        }
    }
}
