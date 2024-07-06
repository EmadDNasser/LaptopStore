using System;
using System.Windows.Forms;

namespace LaptopStore
{
    public partial class CartItem : UserControl
    {

        private Cart cart;

        private double Price = 0;
        public CartItem(Cart cartInstance)
        {
            InitializeComponent();

            cart = cartInstance;

            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

            double Count = Convert.ToDouble(numericUpDown1.Value);
            Price = Convert.ToDouble(txtPrice.Text);
            double TotalPrice = Count * Price;
            label1.Text = TotalPrice.ToString() + " AED";

            cart.UpdateTotalPrice();

        }

        public double GetItemTotalPrice()
        {
            return Convert.ToDouble(numericUpDown1.Value) * Convert.ToDouble(txtPrice.Text);
        }

    }
}
