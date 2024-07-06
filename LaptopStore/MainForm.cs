using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace LaptopStore
{

    public partial class MainForm : Form
    {
        const string filePath = @"data\LaptopData.txt"; // Replace with your actual path

        // Delegate definition
        public delegate void PassDataDelegate(string LaptopInfo, string LaptopPrice, Image LaptopImage, int _Count);

        public List<LaptopInfo> laptopDetails1 = new List<LaptopInfo>();

        public int count = 0;
                     
        public class LaptopInfo
        {
            public string _LaptopInfo { get; set; }
            public string _Price { get; set; }
            public Image _Image { get; set; }
        }

        public MainForm()
        {
            InitializeComponent();

            btnSignOut.Visible = false;

            List<LaptopItem> laptopItems = LoadLaptopDataFromFile(filePath);
            GenerateLaptopItems(laptopItems);
        }

        private void SubscribeEmailID(object sender, string _emailID)
        {
            // Handle the data received from Login Form
            lblEmailID.Text = _emailID;

            btnSignOut.Visible = true;
            btnSignIn.Visible = false;
            
        }

        public void ReceiveItemCountFromLaptopDetails(string LaptopInfo, string LaptopPrice, Image LaptopImage, int ItemCount)
        {
            // Handle the received Item Count from LaptopDetails Form
            count += ItemCount;

            btnItemCount.Enabled = true;

            btnItemCount.Text = count.ToString();

            laptopDetails1.Add(new LaptopInfo {  _LaptopInfo =  LaptopInfo, _Price = LaptopPrice, _Image = LaptopImage });

        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            LogIn logIn = new LogIn();

            logIn.SignInfoHandler += SubscribeEmailID; // Subscribe to the event
           
            logIn.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblEmailID.Text = string.Empty;
            btnSignOut.Visible = false;
            btnSignIn.Visible = true;
        }

        public static List<string> SplitString(string S1, string Delim)
        {
            List<string> lString = new List<string>();
            int pos = 0;
            int startIndex = 0;
            string sWord;

            // Use String.IndexOf() to find delimiter position
            while ((pos = S1.IndexOf(Delim, startIndex)) != -1)
            {
                sWord = S1.Substring(startIndex, pos - startIndex);

                // Add word if not empty
                if (!string.IsNullOrEmpty(sWord))
                {
                    lString.Add(sWord);
                }

                // Update starting position for next iteration
                startIndex = pos + Delim.Length;
            }

            // Add the last word if S1 is not empty
            sWord = S1.Substring(startIndex);
            if (!string.IsNullOrEmpty(sWord))
            {
                lString.Add(sWord);
            }

            return lString;
        }

        LaptopItem ConvertLineToRecord(string Line)
        {
            LaptopItem laptopItem = new LaptopItem(this);
           
            List<string> LaptopData = new List<string>();
            
            LaptopData = SplitString(Line, "#");

            laptopItem.btnView.Name = LaptopData[0];
            laptopItem.richTextBox1.Text = LaptopData[1];

            try
            {
                // Load image from file
                laptopItem.pictureBox1.Image = Image.FromFile(LaptopData[2]);
            }
            catch (Exception ex)
            {

                // Handle image loading errors
                MessageBox.Show($"Error loading image: {ex.Message}", "Image Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return laptopItem;
        }

        private List<LaptopItem> LoadLaptopDataFromFile(string FileName)
        {
           
            List<LaptopItem> laptopItems = new List<LaptopItem>();

            using (StreamReader reader = new StreamReader(FileName))
            {
                // Read lines one by one
                string line;
                LaptopItem laptopItem = new LaptopItem(this);
                while ((line = reader.ReadLine()) != null)
                {
                    laptopItem = ConvertLineToRecord(line);
                    laptopItems.Add(laptopItem);
                }
            }

            return laptopItems;
        }

        private void GenerateLaptopItems(List<LaptopItem> laptopItem)
        {
            int ItemCount = 0;

            // Define starting position and spacing
            int xPos = 25;
            int yPos = 20;
            int spacing = 185;

            foreach (LaptopItem laptopItem1 in laptopItem)
            {
                laptopItem1.Location = new Point(xPos, yPos);

                panel1.Controls.Add(laptopItem1); // Add LaptopItem to form
                ItemCount++;

                if (ItemCount % 5 != 0)
                {
                    xPos += spacing;  // Update position for next LaptopItem  
                }
                else
                {
                    xPos = 25;
                    yPos += laptopItem1.Height + 20;
                    
                }
            }

        }

        private void GenerateCartItem(Cart cart)
        {
            int xPos = 10;
            int yPos = 20;

            for (int i = 0; i < laptopDetails1.Count; i++)
            {
                CartItem cartItem = new CartItem(cart);
                cartItem.Location = new Point(xPos, yPos);

                cartItem.richTextBox1.Text = laptopDetails1[i]._LaptopInfo;
                cartItem.txtPrice.Text = laptopDetails1[i]._Price;

                cartItem.pictureBox1.Image = laptopDetails1[i]._Image;
                cartItem.label1.Text = laptopDetails1[i]._Price + " AED";

                cart.panel2.Controls.Add(cartItem);
                yPos += cartItem.Height + 10;
            }

            cart.UpdateTotalPrice();
        }

        private void ItemCount_Click(object sender, EventArgs e)
        {
            Cart cart = new Cart(this);
  
            GenerateCartItem(cart);

            cart.ShowDialog();
        }

    }
}