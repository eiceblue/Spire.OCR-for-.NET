using Spire.OCR;
using System;
using System.IO;
using System.Windows.Forms;


namespace ScanLocalImage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Note: 1. Download the latest model from official website: https://www.e-iceblue.com/Tutorials/NET/Spire.OCR-for-.NET/Program-Guide/Recognize-Text/C-Extract-Text-from-Images-using-the-New-Model-of-Spire.OCR-for-.NET.html
            // 2. Modify the ModelPath below to your model directory

            string imageFile = "../../../../../Data/Sample.png";
            string outputFile = "ScanLocalImage_out.txt";

            // Create an instance of the OcrScanner class
            OcrScanner scanner = new OcrScanner();

            // Create an instance of the ConfigureOptions class to set up the scanner configuration
            ConfigureOptions configureOptions = new ConfigureOptions();

            // Set the path to the new model (Must be modified to your actual model path)
            configureOptions.ModelPath = "D:\\win-x64";

            // Set the language for text recognition. The default is English.
            // Supported languages include English, Chinese, Chinesetraditional, French, German, Japan, and Korean.
            configureOptions.Language = "English";

            // Apply the configuration options to the scanner
            scanner.ConfigureDependencies(configureOptions);

            // Scan image file
            scanner.Scan(imageFile);

            // Save result to file
            File.WriteAllText(outputFile, scanner.Text.ToString());

            scanner.Dispose();

            TxtViewer(outputFile);
        }
        private void TxtViewer(string outputFile)
        {
            System.Diagnostics.Process.Start(outputFile);
        }
    }
}
