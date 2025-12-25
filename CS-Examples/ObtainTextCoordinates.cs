using Spire.OCR;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ObtainTextCoordinates
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
            string outputFile = "ObtainTextCoordinates_out.txt";

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

            // Scan image
            scanner.Scan(imageFile);

            // Retrieve all text blocks detected by the OCR engine
            IOCRTextBlock[] blocks = scanner.Text.Blocks;
            // Get the text coordinate
            string scannnedText = PrintTextBlocks(blocks);

            // Save result to file
            File.WriteAllText(outputFile, scannnedText);

            scanner.Dispose();

            TxtViewer(outputFile);
        }

        private static string PrintTextBlocks(IOCRTextBlock[] blocks, StringBuilder sb = null)
        {
            // Create a new StringBuilder
            if (sb == null || sb.Length == 0) sb = new StringBuilder();

            // Skip processing if no blocks are provided
            if (blocks != null && blocks.Count() > 0)
            {
                foreach (var block in blocks)
                {
                    // Retrieve the bounding rectangle of the current block
                    Rectangle rectangle = block.Box;

                    // Format the rectangle coordinates and block details
                    string t1 = string.Format("Rectangle : [{0}, {1}, {2}, {3}] , ",
                        rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
                    string t2 = string.Format("Level ({0}): {1}", block.Level.ToString(), block.Text);
                    string text = t1 + t2;
                    text = text + "\n";

                    // Append the formatted information to the result buffer
                    sb.Append(text);

                    // Recursively process any child text blocks
                    PrintTextBlocks(block.TextBlock, sb);
                    if (block.Level == TextBlockType.Line) sb.Append("\n");
                }
            }
            return sb.ToString();
        }

        private void TxtViewer(string outputFile)
        {
            System.Diagnostics.Process.Start(outputFile);
        }

    }
}
