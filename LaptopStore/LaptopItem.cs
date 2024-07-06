using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Reflection;

namespace LaptopStore
{
    public partial class LaptopItem : UserControl
    {

        // LaptopItem will open LaptopDetails and pass a delegate to LaptopDetails so it can send data back to MainForm.
        private MainForm _mainForm;

        struct LaptopData
        {
            public string ID;
            public string ModelName;
            public string Color;
            public string Processor;
            public string Storage;
            public string StorageType;
            public string RAM;
            public string Battery;
            public string Price;
            public string Picture;
        }

        const string filePath = @"D:\Visual Studio\repos\LaptopStore\LaptopStore\Resources\data\LaptopDetails.txt"; // Replace with your actual path
        
        private List<LaptopData> laptopDetails; // Creat an object of a struct.
        
        public LaptopItem(MainForm mainForm)
        {
            InitializeComponent();

            _mainForm = mainForm;

            laptopDetails = LoadLaptopDetailsFromFile(filePath); // Load the data from the file, and store it in the struct ojbect.
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int ControlID = int.Parse(btnView.Name); // store the button ID in a varible and convert it to int, because it's a string.
                                                     // The button ID will help us define what raw must be loaded.


            LaptopData laptopData = laptopDetails[ControlID]; // creat a struct object, and fill it with the data that matches with the Button ID only (No need to fetch all the data, this will improve program speed).
                                                              // (EX: User clicks on button with the ID 0, then it will bring the data from the first row (it's index is 0).


            // Now it's time to run the Form
            LaptopDetails frmLaptopDetails = new LaptopDetails(
                laptopData.ModelName,
                laptopData.Color,
                laptopData.Processor,
                laptopData.Storage,
                laptopData.StorageType,
                laptopData.RAM,
                laptopData.Battery,
                laptopData.Price,
                laptopData.Picture, _mainForm.ReceiveItemCountFromLaptopDetails);

            frmLaptopDetails.Text = laptopData.ModelName;

            frmLaptopDetails.ShowDialog();
        }

        private LaptopData ConvertLineToRecord(string line)
        {
            LaptopData laptopData = new LaptopData();
            List<string> laptopDataFields = MainForm.SplitString(line, "#");

            laptopData.ID = laptopDataFields[0];
            laptopData.ModelName = laptopDataFields[1];
            laptopData.Color = laptopDataFields[2];
            laptopData.Processor = laptopDataFields[3];
            laptopData.Storage = laptopDataFields[4];
            laptopData.StorageType = laptopDataFields[5];
            laptopData.RAM = laptopDataFields[6];
            laptopData.Battery = laptopDataFields[7];
            laptopData.Price = laptopDataFields[8];
            laptopData.Picture = laptopDataFields[9];

            return laptopData;
        }

        private List<LaptopData> LoadLaptopDetailsFromFile(string fileName)
        {
            List<LaptopData> laptopDetails = new List<LaptopData>();

            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    laptopDetails.Add(ConvertLineToRecord(line));
                }
            }

            return laptopDetails;
        }
    }
}
