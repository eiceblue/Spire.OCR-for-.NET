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

