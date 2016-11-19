
namespace Artesanias_AMG
{
    class Producto
    {
        private int id;
        private string nombre;
        private string descripcion;
        private float costo;
        private float precio;

        public int Id
        {
            get {return id;}
            set {id = value;}
        }
        public string Nombre
        {
            get{return nombre;}
            set{nombre = value;}
        }

        public string Descripcion
        {
            get{return descripcion;}
            set{descripcion = value;}
        }

        public float Costo
        {
            get{return costo;}
            set{costo = value;}
        }

        public float Precio
        {
            get{return precio;}
            set{precio = value;}
        }

        public Producto()
        {
            this.Nombre = null;
            this.Descripcion = null;
            this.Costo = 0;
            this.Precio = 0;
        }

        public Producto(string nombre, string descripcion, float costo, float precio)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Costo = costo;
            this.Precio = precio;
        }


    }
}
