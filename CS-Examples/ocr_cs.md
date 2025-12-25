# Spire.OCR Extract Rectangular Area
## Extract text and rectangular area information from OCR results
```csharp
// Create an instance of the OcrScanner class
OcrScanner scanner = new OcrScanner();

// Create an instance of the ConfigureOptions class to set up the scanner configuration
ConfigureOptions configureOptions = new ConfigureOptions();

// Set the path to the new model
configureOptions.ModelPath = "D:\\win-x64";

// Set the language for text recognition
configureOptions.Language = "English";

// Apply the configuration options to the scanner
scanner.ConfigureDependencies(configureOptions);

// Extract text from an image
scanner.Scan(imageFile);

// Traverse the ocr result text blocks
foreach (IOCRTextBlock blockItem in scanner.Text.Blocks)
{
    // Get the block text and its rectangular area
    string text = blockItem.Text;
    string rectangularArea = blockItem.Box;
}

scanner.Dispose();
```

---

# spire.ocr csharp image stream
## extract text from image stream using OCR
```csharp
// Create an instance of the OcrScanner class
OcrScanner scanner = new OcrScanner();

// Create an instance of the ConfigureOptions class to set up the scanner configuration
ConfigureOptions configureOptions = new ConfigureOptions();

// Set the path to the new model
configureOptions.ModelPath = "D:\\win-x64";

// Set the language for text recognition
configureOptions.Language = "English";

// Apply the configuration options to the scanner
scanner.ConfigureDependencies(configureOptions);

// Get image stream
Stream stream = (new StreamReader(imageFile)).BaseStream;

// Scan image stream
scanner.Scan(stream, OCRImageFormat.Jpg);

// Get the scanned text
string extractedText = scanner.Text.ToString();

// Clean up
stream.Close();
scanner.Dispose();
```

---

# Spire.OCR C# Language Selection
## OCR scanning with language selection configuration
```csharp
// Create an instance of the OcrScanner class
OcrScanner scanner = new OcrScanner();

// Create an instance of the ConfigureOptions class to set up the scanner configuration
ConfigureOptions configureOptions = new ConfigureOptions();

// Set the path to the new model (Must be modified to your actual model path)
configureOptions.ModelPath = "D:\\win-x64";

// Set the language for text recognition. The default is English.
// Supported languages include English, Chinese, Chinesetraditional, French, German, Japan, and Korean.
configureOptions.Language = "Japan";

// Apply the configuration options to the scanner
scanner.ConfigureDependencies(configureOptions);

// Scan image file
scanner.Scan(imageFile);

// Get OCR result
string ocrResult = scanner.Text.ToString();

scanner.Dispose();
```

---

# Spire.OCR C# Image Scanning
## Core OCR text recognition from local images
```csharp
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
```

---
# spire.ocr csharp text coordinates
## extract text coordinates from image using OCR
```csharp
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
```

---

# OCR Scanning Rotated Images
## Extract text from rotated images using Spire.OCR with auto-rotation feature
```csharp
// Create an instance of the OcrScanner class
OcrScanner scanner = new OcrScanner();

// Create an instance of the ConfigureOptions class to set up the scanner configuration
ConfigureOptions configureOptions = new ConfigureOptions();

// Set the path to the new model
configureOptions.ModelPath = "D:\\win-x64";

// Set the language for text recognition
configureOptions.Language = "English";

// Enable auto-rotation feature
configureOptions.AutoRotate = true;

// Apply configuration options
scanner.ConfigureDependencies(configureOptions);
// Perform scanning operation
scanner.Scan(imageFile);

// Create text aligner to process scan results
VisualTextAligner visualText = new VisualTextAligner(scanner.Text);
// Get aligned text string
string scannnedText = visualText.ToString();

scanner.Dispose();
```

---


