using System;
using System.Drawing;
using System.Windows.Forms;
//using static LaptopStore.MainForm;

namespace LaptopStore
{
    public partial class LaptopDetails : Form
    {

        private MainForm.PassDataDelegate _passData;

        public LaptopDetails(string ModelName,
        string Color,
        string Processor,
        string Storage,
        string StorageType,
        string RAM,
        string Battery, string Price, string Picture, MainForm.PassDataDelegate passData)
        {
            InitializeComponent();

            LblModel1.Text = ModelName;
            LblColor1.Text = Color;
            LblProcessor1.Text = Processor;
            LblStorage1.Text = Storage;
            LblStorageType1.Text = StorageType;
            LblRAM1.Text = RAM;
            LblBattery1.Text = Battery;
            LblPrice1.Text = Price;

            _passData = passData;

            try
            {
                // Load image from file
                pictureBox1.Image = Image.FromFile(Picture);
            }
            catch (Exception ex)
            {

                // Handle image loading errors
                MessageBox.Show($"Error loading image: {ex.Message}", "Image Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Black;
            button1.BackColor = Color.Wheat ;
            Cursor = Cursors.Hand;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Transparent;
            button1.BackColor = Color.FromArgb(0, 106, 193);
            Cursor = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string info = LblModel1.Text + " / " + LblProcessor1.Text + " / " + LblStorage1.Text + " / " +
                          LblStorageType1.Text + " / " + LblRAM1.Text + " / " + LblBattery1.Text;

            Image image = pictureBox1.Image;

            DialogResult result = MessageBox.Show("Are you sure?", "Add to Cart!", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                _passData?.Invoke(info, LblPrice1.Text, image,  1); // Trigger the delegate to send data
                
                Close();
            }
        }
    }
}
