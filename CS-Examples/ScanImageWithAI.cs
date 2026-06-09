using Spire.OCR;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace ScanImageWithAI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filename = "../../../../../Data/JapaneseSample.png";
            string outputFile = @"ScanImageWithAI.txt";

            // Path to OCR configuration XML file
            string filePath = "D:\\AI\\ocr.xml";
            string newModel = "AIModel";
            string newApiKey = "ApiKey";
            string newApiUrl = "ApiUrl";

            // Update OCR configuration with new settings
            UpdateOcrConfig(filePath, newModel, newApiKey, newApiUrl);

            // Perform OCR scanning on the image
            ScanImg(filename, outputFile);

            // Display the OCR result in a text viewer
            TxtViewer(outputFile);
        }
        public static void ScanImg(string filename, string outputFile)
        {
            // Create OCR scanner instance
            OcrScanner scanner = new OcrScanner();

            // Configure OCR options
            ConfigureOptions configureOptions = new ConfigureOptions();
            configureOptions.ModelPath = "D:\\AI";
            configureOptions.Language = "Japanese";

            // Apply configuration to scanner
            scanner.ConfigureDependencies(configureOptions);

            // Execute OCR scan on the image
            scanner.Scan(filename);
            File.WriteAllText(outputFile, scanner.Text.ToString());
        }
        public static void UpdateOcrConfig(string filePath, string model, string apiKey, string apiUrl)
        {
            // Load the XML configuration file
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            // Select XML nodes for each configuration element using XPath
            XmlNode modelNode = doc.SelectSingleNode("/ocr/configs/model");
            XmlNode apiKeyNode = doc.SelectSingleNode("/ocr/configs/apiKey");
            XmlNode apiUrlNode = doc.SelectSingleNode("/ocr/configs/apiUrl");

            // Update node values if they exist
            if (modelNode != null) modelNode.InnerText = model;
            if (apiKeyNode != null) apiKeyNode.InnerText = apiKey;
            if (apiUrlNode != null) apiUrlNode.InnerText = apiUrl;

            doc.Save(filePath);
            Console.WriteLine("XML file updated  ");
        }
        private void TxtViewer(string outputFile)
        {
            System.Diagnostics.Process.Start(outputFile);
        }
    }
}
