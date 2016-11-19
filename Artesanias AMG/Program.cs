using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Artesanias_AMG
{
    static class Program
    {       
        public static BindingList<Producto> listaProductos = new BindingList<Producto>(Operations.productList());
        public static BindingList<Venta> listaVentas = new BindingList<Venta>(Operations.salesList());

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //refreshProductList();
            //refreshVentaList();
            Application.Run(new frmPrincipal());
        }

        #region Productos
        public static void refreshProductList()
        {
            listaProductos.Clear();
            listaProductos = new BindingList<Producto>(Operations.productList());
        }

        public static bool eliminarProducto(Producto producto)
        {
            bool resultado = false;
            if (MessageBox.Show("Eliminar el producto seleccionado? \n(" + producto.Nombre + ")", "Pregunta", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Operations.deleteProduct(producto);
                refreshProductList();
                resultado = true;
            }
            return resultado;
        }

        public static void agregarProducto(string Nombre, string Descripcion, float Costo, float Precio)
        {
            Producto producto = new Producto(Nombre, Descripcion, Costo, Precio);
            Operations.addProduct(producto);
        }

        #endregion

        #region Ventas
        public static void agregarVenta(Venta objVenta)
        {
            Operations.addSell(objVenta);
        }

        public static void refreshVentaList()
        {
            listaVentas.Clear();
            listaVentas = new BindingList<Venta>(Operations.salesList());
        }

        public static bool eliminarVenta(Venta venta)
        {
            bool resultado = false;
            if (MessageBox.Show("Eliminar la venta seleccionada?", "Pregunta", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Operations.deleteSell(venta);
                refreshVentaList();
                resultado = true;
            }
            return resultado;
        }

        #endregion

        public static void endApp()
        {
            Application.Exit();
        }
    }
}
