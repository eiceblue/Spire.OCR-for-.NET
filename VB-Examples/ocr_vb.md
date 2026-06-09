# Spire.OCR VB.NET Text Extraction
## Extract text and rectangular areas from images using OCR
```vbnet
' Create an instance of the OcrScanner class
Dim scanner As New OcrScanner()

' Create an instance of the ConfigureOptions class to set up the scanner configuration
Dim configureOptions As New ConfigureOptions()

' Set the path to the new model (Must be modified to your actual model path)
configureOptions.ModelPath = "D:\win-x64"

' Set the language for text recognition. The default is English.
' Supported languages include English, Chinese, Chinesetraditional, French, German, Japan, and Korean.
configureOptions.Language = "English"

' Apply the configuration options to the scanner
scanner.ConfigureDependencies(configureOptions)

' Extract text from an image
scanner.Scan(imageFile)

' Traverse the ocr result text blocks
For Each blockItem As IOCRTextBlock In scanner.Text.Blocks
    ' Get the block text and its rectangular area
    Dim text As String = blockItem.Text
    Dim rectangularArea As String = blockItem.Box.ToString()
Next blockItem

scanner.Dispose()
```

---

# Spire OCR Image Stream Scanning
## Extract text from image stream using OCR technology

```vbnet
' Create an instance of the OcrScanner class
Dim scanner As New OcrScanner()

' Create an instance of the ConfigureOptions class to set up the scanner configuration
Dim configureOptions As New ConfigureOptions()

' Set the path to the new model (Must be modified to your actual model path)
configureOptions.ModelPath = "D:\win-x64"

' Set the language for text recognition. The default is English.
' Supported languages include English, Chinese, Chinesetraditional, French, German, Japan, and Korean.
configureOptions.Language = "English"

' Apply the configuration options to the scanner
scanner.ConfigureDependencies(configureOptions)

' Get image stream
Dim stream As Stream = (New StreamReader(imageFile)).BaseStream

' Scan image stream
scanner.Scan(stream, OCRImageFormat.Jpg)

' Get the recognized text
Dim recognizedText As String = scanner.Text.ToString()

' Clean up resources
stream.Close()
scanner.Dispose()
```

---

# Spire.OCR VB.NET Language Selection
## Perform OCR scanning with language selection
```vbnet
' Create an instance of the OcrScanner class
Dim scanner As New OcrScanner()

' Create an instance of the ConfigureOptions class to set up the scanner configuration
Dim configureOptions As New ConfigureOptions()

' Set the path to the new model (Must be modified to your actual model path)
configureOptions.ModelPath = "D:\win-x64"

' Set the language for text recognition. The default is English.
' Supported languages include English, Chinese, Chinesetraditional, French, German, Japan, and Korean.
configureOptions.Language = "Japan"

' Apply the configuration options to the scanner
scanner.ConfigureDependencies(configureOptions)

' Scan image file
scanner.Scan(imageFile)

scanner.Dispose()
```

---

# Spire.OCR VB.NET Implementation
## Extract text from images using OCR
```vbnet
' Create an instance of the OcrScanner class
Dim scanner As New OcrScanner()

' Create an instance of the ConfigureOptions class to set up the scanner configuration
Dim configureOptions As New ConfigureOptions()

' Set the path to the new model (Must be modified to your actual model path)
configureOptions.ModelPath = "D:\win-x64"

' Set the language for text recognition. The default is English.
' Supported languages include English, Chinese, Chinesetraditional, French, German, Japan, and Korean.
configureOptions.Language = "English"

' Apply the configuration options to the scanner
scanner.ConfigureDependencies(configureOptions)

' Scan image file
scanner.Scan(imageFile)

' Get the extracted text
Dim extractedText As String = scanner.Text.ToString()

scanner.Dispose()
```

---
# Spire.OCR - ScanImageWithAI
## Performs OCR scanning on an image using Spire.OCR and updates AI model configuration via XML.

```vbnet
Public Partial Class Form1 : Inherits Form
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim filename As String = "../../../../../Data/JapaneseSample.png"
        Dim outputFile As String = "ScanImageWithAI.txt"
        Dim filePath As String = "D:\\AI\\ocr.xml"
        Dim newModel As String = "AIModel"
        Dim newApiKey As String = "ApiKey"
        Dim newApiUrl As String = "ApiUrl"

        UpdateOcrConfig(filePath, newModel, newApiKey, newApiUrl)
        ScanImg(filename, outputFile)
        TxtViewer(outputFile)
    End Sub

    Public Shared Sub ScanImg(ByVal filename As String, ByVal outputFile As String)
        Dim scanner As OcrScanner = New OcrScanner()
        Dim configureOptions As ConfigureOptions = New ConfigureOptions()
        configureOptions.ModelPath = "D:\\AI"
        configureOptions.Language = "Japanese"
        scanner.ConfigureDependencies(configureOptions)
        scanner.Scan(filename)
        File.WriteAllText(outputFile, scanner.Text.ToString())
    End Sub

    Public Shared Sub UpdateOcrConfig(ByVal filePath As String, ByVal model As String, ByVal apiKey As String, ByVal apiUrl As String)
        Dim doc As XmlDocument = New XmlDocument()
        doc.Load(filePath)
        Dim modelNode As XmlNode = doc.SelectSingleNode("/ocr/configs/model")
        Dim apiKeyNode As XmlNode = doc.SelectSingleNode("/ocr/configs/apiKey")
        Dim apiUrlNode As XmlNode = doc.SelectSingleNode("/ocr/configs/apiUrl")
        If modelNode <> Nothing Then modelNode.InnerText = model
        If apiKeyNode <> Nothing Then apiKeyNode.InnerText = apiKey
        If apiUrlNode <> Nothing Then apiUrlNode.InnerText = apiUrl
        doc.Save(filePath)
    End Sub

    Private Sub TxtViewer(ByVal outputFile As String)
        System.Diagnostics.Process.Start(outputFile)
    End Sub
End Class
```

---


