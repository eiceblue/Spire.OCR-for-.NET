using Spire.OCR;
using System;
using System.IO;
using System.Windows.Forms;


namespace ExportRectangularArea
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
            string outputFile = "ExportRectangularArea_out.txt";

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

            // Extract text from an image
            scanner.Scan(imageFile);

            // Traverse the ocr result text blocks
            using (StreamWriter fs = new StreamWriter(outputFile, true))
            {
                foreach (IOCRTextBlock blockItem in scanner.Text.Blocks)
                {
                    // Get the block text and its rectangular area
                    fs.WriteLine("Text£º" + blockItem.Text + "\r\n" + "Rectangular area: " + blockItem.Box + "\r\n");
                }
            }

            scanner.Dispose();

            TxtViewer(outputFile);
        }
        private void TxtViewer(string outputFile)
        {
            System.Diagnostics.Process.Start(outputFile);
        }
    }
}
