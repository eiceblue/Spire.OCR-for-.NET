using Spire.OCR;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;


namespace ScanRotatedImage
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

            string imageFile = "../../../../../Data/RotatedImage.png";
            string outputFile = "ScanRotatingImage_out.txt";

            // Create an instance of the OcrScanner class
            OcrScanner scanner = new OcrScanner();

            // Create an instance of the ConfigureOptions class to set up the scanner configuration
            ConfigureOptions configureOptions = new ConfigureOptions();

            // Set the path to the new model (Must be modified to your actual model path)
            configureOptions.ModelPath = "D:\\win-x64";

            // Set the language for text recognition. The default is English.
            // Supported languages include English, Chinese, Chinesetraditional, French, German, Japan, and Korean.
            configureOptions.Language = "English";

            // Enable auto-rotation feature
            configureOptions.AutoRotate = true;

            // Apply configuration options
            scanner.ConfigureDependencies(configureOptions);
            // Perform scanning operation, 'imageFile' is the source image
            scanner.Scan(imageFile);

            // Create text aligner to process scan results
            VisualTextAligner visualText = new VisualTextAligner(scanner.Text);
            // Get aligned text string
            string scannnedText = visualText.ToString();

            // Use StringBuilder to construct final text
            StringBuilder builder = new StringBuilder();
            builder.Append(scannnedText);
            // Write recognition results to output file
            File.WriteAllText(outputFile, builder.ToString());


            scanner.Dispose();

            TxtViewer(outputFile);
        }
        private void TxtViewer(string outputFile)
        {
            System.Diagnostics.Process.Start(outputFile);
        }
    }
}
