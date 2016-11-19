

namespace Artesanias_AMG
{
    class Venta
    {
        private int id;
        private string date;
        private int product_id;
        private int amount;
        private int price;

        public string Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }

        public int Product_Id
        {
            get
            {
                return product_id;
            }

            set
            {
                product_id = value;
            }
        }

        public int Amount
        {
            get
            {
                return amount;
            }

            set
            {
                amount = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public int Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }

        public Venta()
        {
            this.Date = null;
            this.Product_Id = 0;
            this.Amount = 0;  
        }

        public Venta(string date, int product_id, int amount, int price)
        {
            this.Date = date;
            this.Product_Id = product_id;
            this.Amount = amount;
            this.Price = price;
        }

        public string toString()
        {
            string str = "id: " + Id.ToString();
            str = str + "fecha: " + Date.ToString();
            str = str + "id_producto: " + Product_Id.ToString();
            str = str + "cantidad: " + Amount.ToString();

            return str;
        }
    }
}
