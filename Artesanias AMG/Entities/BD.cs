using Microsoft.Office.Interop.Access.Dao;
using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace Artesanias_AMG
{
    class BD
    {
        private static string dbPath = "C:\\Users\\aguerinx\\Documents\\Visual Studio 2015\\Projects\\Artesanias AMG\\Artesanias AMG\\artesanias.accdb";
        private static string dbConnString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\aguerinx\\Documents\\Visual Studio 2015\\Projects\\Artesanias AMG\\Artesanias AMG\\artesanias.accdb";

        static OleDbConnection conexion = new OleDbConnection(dbConnString);

        public static OleDbConnection Conexion
        {
            get { return conexion; }
            set { conexion = value; }
        }

        public BD()
        {

        }

        public static OleDbConnection GetConnection()
        {
            return Conexion;
        }

        public static void createQuery(string query, string fecha)
        {
            
            var dbe = new DBEngine();
            var db = dbe.OpenDatabase(dbPath);
            var qd = new QueryDef();
            qd.Name = String.Format("reporteVentasPorFecha {0}", fecha);
            qd.SQL = String.Format("SELECT Venta.Fecha, Producto.ID, Producto.Nombre, Producto.Precio, Venta.Cantidad, [Precio]*[Cantidad] AS Subtotal FROM Producto INNER JOIN Venta ON Producto.ID = Venta.ID_Producto WHERE (((Venta.Fecha)=#{0}#));", fecha);
            db.QueryDefs.Append(qd);
            db.Close();
        }

        public static void deleteAllReportQuery()
        {
            //list queries
            var dbe = new DBEngine();
            var db = dbe.OpenDatabase(dbPath);
            var list = new List<QueryDef>();

            foreach (QueryDef qd in db.QueryDefs)
            {
                db.QueryDefs.Delete(qd.Name);
            }
            db.Close();
        }

        public static void closeConnection()
        {
            if (Conexion.State.ToString() == "Open")
                Conexion.Close();
        }

        public static void setConnection(OleDbConnection con)
        {
            Conexion = con;
        }
    }

}
