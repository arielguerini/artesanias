using System.Data.OleDb;
using System.Collections.Generic;
using System;
using System.Data;

namespace Artesanias_AMG
{
    class Operations
    {
        #region Productos
        public static List<Producto> productList()
        {
            List<Producto> productos = new List<Producto>();
            OleDbConnection conexion = BD.GetConnection();

            try
            {
                OleDbCommand comando = new OleDbCommand("SELECT * FROM Producto;", conexion);
                conexion.Open();
                OleDbDataReader lector = comando.ExecuteReader();
                if (lector.HasRows)
                {
                    Producto obj = null;
                    while (lector.Read())
                    {
                        obj = new Producto();
                        obj.Id = int.Parse(lector["ID"].ToString());
                        obj.Nombre = lector["Nombre"].ToString();
                        obj.Descripcion = lector["Descripcion"].ToString();
                        obj.Costo = float.Parse(lector["Costo"].ToString());
                        obj.Precio = float.Parse(lector["Precio"].ToString());
                        productos.Add(obj);
                    }
                }
                return productos;
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
        }

        public static void addProduct(Producto prod)
        {
            OleDbConnection conexion = BD.GetConnection();
            string consulta = "INSERT INTO Producto (Nombre, Descripcion, Costo, Precio) VALUES (@Nombre, @Descripcion, @Costo, @Precio);";

            try
            {
                OleDbCommand comando = new OleDbCommand(consulta, conexion);

                comando.Parameters.Add("@Nombre", OleDbType.VarChar).Value = prod.Nombre;
                comando.Parameters.Add("@Descripcion", OleDbType.VarChar).Value = prod.Descripcion;
                comando.Parameters.Add("@Costo", OleDbType.Currency).Value = prod.Costo;
                comando.Parameters.Add("@Precio", OleDbType.Currency).Value = prod.Precio;

                conexion.Open();

                using (comando)
                {
                    
                    comando.ExecuteNonQuery();

                }
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
        }

        public static Producto getProductByID(int id)
        {
            Producto resultado = new Producto();
            foreach(Producto prod in Program.listaProductos)
            {
                if (prod.Id == id)
                {
                    resultado = prod;
                    break;
                }
            }
            return resultado;
        }

        public static void deleteProduct(Producto prod)
        {
            OleDbConnection conexion = BD.GetConnection();
            string consulta = "DELETE * FROM Producto where id = @id;";

            try
            {
                OleDbCommand comando = new OleDbCommand(consulta, conexion);

                comando.Parameters.Add("@id", OleDbType.Integer).Value = prod.Id;
                conexion.Open();

                using (comando)
                {
                    comando.ExecuteNonQuery();

                }
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
        }

        public static void modifyProduct(Producto prod, string key, string value)
        {
            string query = "";
            OleDbConnection conexion = BD.GetConnection();
            OleDbCommand com = new OleDbCommand();

            switch (key)
            {
                case "nombre":
                    query = "UPDATE Producto SET nombre = @value where id = " + prod.Id + ";";
                    com.Parameters.Add("@value", OleDbType.VarChar).Value = value;
                    break;
                case "descripcion":
                    query = "UPDATE Producto SET descripcion = @value where id = " + prod.Id + ";";
                    com.Parameters.Add("@value", OleDbType.VarChar).Value = int.Parse(value);
                    break;
                case "costo":
                    query = "UPDATE Producto SET costo = @value where id = " + prod.Id + ";";
                    com.Parameters.Add("@value", OleDbType.Currency).Value = int.Parse(value);
                    break;
                case "precio":
                    query = "UPDATE Producto SET precio = @value where id = " + prod.Id + ";";
                    com.Parameters.Add("@value", OleDbType.Currency).Value = int.Parse(value);
                    break;
            }

            try
            {
                com.CommandText = query;
                com.Connection = conexion;

                conexion.Open();

                using (com)
                {
                    com.ExecuteNonQuery();

                }
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
        }

        #endregion

        #region Ventas
        public static Venta createSell(string date, int product_id, int amount, int price)
        {
            Venta objVenta = new Venta(date, product_id, amount, price);
            return objVenta;
        }

        public static List<Venta> salesList()
        {
            List<Venta> ventas = new List<Venta>();
            OleDbConnection conexion = BD.GetConnection();

            try
            {
                OleDbCommand comando = new OleDbCommand("SELECT * FROM Venta ORDER BY Venta.Fecha;", conexion);
                conexion.Open();
                OleDbDataReader lector = comando.ExecuteReader();
                if (lector.HasRows)
                {
                    Venta obj = null;
                    while (lector.Read())
                    {
                        obj = new Venta();
                        obj.Id = int.Parse(lector["ID"].ToString());
                        DateTime date = DateTime.Parse(lector["Fecha"].ToString());
                        obj.Date = date.ToShortDateString();
                        obj.Product_Id = int.Parse(lector["ID_Producto"].ToString());
                        obj.Amount = int.Parse(lector["Cantidad"].ToString());
                        obj.Price = int.Parse(lector["Precio"].ToString());
                        ventas.Add(obj);
                    }
                }
                return ventas;
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
        }

        public static void addSell(Venta objVenta)
        {
            OleDbConnection conexion = BD.GetConnection();
            string consulta = "INSERT INTO Venta (Fecha, Id_Producto, Cantidad, Precio) VALUES (@Fecha, @Id_Producto, @Cantidad, @Precio);";

            try
            {
                OleDbCommand comando = new OleDbCommand(consulta, conexion);

                comando.Parameters.Add("@Fecha", OleDbType.Date).Value = objVenta.Date;
                comando.Parameters.Add("@Id_Producto", OleDbType.Integer).Value = objVenta.Product_Id;
                comando.Parameters.Add("@Cantidad", OleDbType.Integer).Value = objVenta.Amount;
                comando.Parameters.Add("@Precio", OleDbType.Integer).Value = objVenta.Price;

                conexion.Open();

                using (comando)
                {
                    comando.ExecuteNonQuery();

                }
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
        }

        public static void modifySell(Venta sell, string key, string value)
        {
            string query = "";
            OleDbConnection conexion = BD.GetConnection();
            OleDbCommand com = new OleDbCommand();

            switch (key)
            {
                case "fecha":
                     query = "UPDATE Venta SET fecha = @value where id = " + sell.Id + ";";
                     com.Parameters.Add("@value", OleDbType.Date).Value = value;
                    break;
                case "producto":
                     query = "UPDATE Venta SET id_producto = @value where id = " + sell.Id + ";";
                     com.Parameters.Add("@value", OleDbType.Integer).Value = int.Parse(value);
                    break;
                case "cantidad":
                    query = "UPDATE Venta SET cantidad = @value where id = " + sell.Id + ";";
                    com.Parameters.Add("@value", OleDbType.Integer).Value = int.Parse(value);
                    break;
                case "precio":
                    query = "UPDATE Venta SET precio = @value where id = " + sell.Id + ";";
                    com.Parameters.Add("@value", OleDbType.Currency).Value = int.Parse(value);
                    break;
            }

            try
            {
                com.CommandText = query;
                com.Connection = conexion;

                conexion.Open();

                using (com)
                {
                    com.ExecuteNonQuery();

                }
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
        }

        public static void deleteSell(Venta obj)
        {
            OleDbConnection conexion = BD.GetConnection();
            string consulta = "DELETE * FROM venta where id = @id;";

            try
            {
                OleDbCommand comando = new OleDbCommand(consulta, conexion);

                comando.Parameters.Add("@id", OleDbType.Integer).Value = obj.Id;
                conexion.Open();

                using (comando)
                {
                    comando.ExecuteNonQuery();
                }
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
        }

        public static DataTable getVentasView()
        {
            OleDbConnection conexion = BD.GetConnection();
            OleDbDataAdapter dataAdapter;
            DataTable dataTable = new DataTable();



            try
            {
                OleDbCommand comando = new OleDbCommand("SELECT * FROM VistaVentas;", conexion);
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
        #endregion

        #region Reportes

        #endregion
    }
}
