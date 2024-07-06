using System;
using System.Drawing;
using System.Windows.Forms;
using static LaptopStore.Order;

namespace LaptopStore
{
    public partial class Cart : Form
    {
        private MainForm mainForm;

        public Cart(MainForm mainFormInstance)
        {
            InitializeComponent();
            mainForm = mainFormInstance;
        }

        public void UpdateTotalPrice()
        {
            double totalPrice = 0;

            foreach (Control control in panel2.Controls)
            {
                if (control is CartItem cartItem)
                {
                    totalPrice += cartItem.GetItemTotalPrice();
                }
            }

            LblTotalPrice.Text = totalPrice.ToString() + " AED";
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (mainForm.lblEmailID.Text == string.Empty)
            {
                MessageBox.Show("Please Log in!");
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure?", "Create order", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    Order order = new Order
                    (
                        "LS0000",
                        mainForm.lblEmailID.Text,
                        DateTime.Now,
                        "Dubai Sports City, Stadium Point, 1604",
                        OrderStatus.Shipped,
                        "VISA Card",
                        "TLS0000"
                    );

                    foreach (Control control in panel2.Controls)
                    {
                        if (control is CartItem cartItem)
                        {
                            Order.OrderItem orderItem = new Order.OrderItem
                            {
                                LaptopInfo = cartItem.richTextBox1.Text,
                                Price = Convert.ToDouble(cartItem.txtPrice.Text),
                                Quantity = Convert.ToInt32(cartItem.numericUpDown1.Value)
                            };
                            order.AddItem(orderItem);
                        }
                    }

                    var emailService = new EmailService();
                    emailService.Subscribe(order);

                    order.CreateOrder(order);

                    mainForm.btnItemCount.Enabled = false; // Make the cart button disabled.
                    mainForm.btnItemCount.Text = string.Empty; // Reset the items count label.
                    mainForm.count = 0; // Reset the items count in the cart.
                    mainForm.laptopDetails1.Clear(); // Clear the List
                    panel2.Controls.Clear(); // Remove all cart items
                    UpdateTotalPrice();      // Reset total price
                    Close();
                }
            }
        }

        private void button1_MouseHover(object sender, System.EventArgs e)
        {
            button1.BackColor = Color.LightBlue;
        }

        private void button1_MouseLeave(object sender, System.EventArgs e)
        {
            button1.BackColor = Color.FromArgb(0, 0, 192);
        }
    }
}
