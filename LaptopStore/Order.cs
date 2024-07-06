using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LaptopStore
{

    public partial class Order : Form
    {
        public event EventHandler<Order> OrderChanged;
        public class OrderItem 
        {
            public string LaptopInfo { get; set; }
            public double Price { get; set; }
            public int Quantity { get; set; }
            public double TotalPrice => Price * Quantity;

            public OrderItem(){}

        }
  
        public string OrderID { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime OrderDate { get; set; }
        //public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public List<OrderItem> Items { get; set; }
        public double TotalPrice => Items.Sum(item => item.TotalPrice);
        public string ShippingAddress { get; set; }
        public OrderStatus ORderStatus { get; set; }
        public string PaymentMethod { get; set; }
        public string TrackingNumber { get; set; }


        public Order(string orderID, string customerEmail, DateTime orderdate, string shippingAddress, OrderStatus orderStatus, string paymentMethod, string trackingNumber)
        {
            InitializeComponent();
            this.OrderID = orderID;
            this.CustomerEmail = customerEmail;
            this.OrderDate = orderdate;
            this.ShippingAddress = shippingAddress;
            this.ORderStatus = orderStatus;
            this.PaymentMethod = paymentMethod;
            this.TrackingNumber = trackingNumber;
            this.Items = new List<OrderItem>(); // Initialize the list of order items
        }

        public void CreateOrder(Order order)
        {
            OrderChanged?.Invoke(this, order);
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }

        public void UpdateStatus(OrderStatus newStatus)
        {
            ORderStatus = newStatus;
        }

        public string GetOrderSummary()
        {
            return $"OrderID: {OrderID}\nCustomerEmail: {CustomerEmail}\nOrderDate: {OrderDate}\n" +
                $"TotalPrice: {TotalPrice}\nOrderStatus: {ORderStatus}\nShippingAddress: {ShippingAddress}\n" +
                $"PaymentMethod: {PaymentMethod}\nTrackingNumber: {TrackingNumber}\n";
        }

        public enum OrderStatus
        {
            Pending,
            Shipped,
            Delivered,
            Canceled
        }
    }
}
