Imports Spire.OCR
Imports System
Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Imports System.Xml

Namespace ScanImageWithAI
    Public Partial Class Form1 : Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim filename As String = "../../../../../Data/JapaneseSample.png"
            Dim outputFile As String = @"ScanImageWithAI.txt"

            ' Path to OCR configuration XML file
            Dim filePath As String = "D:\\AI\\ocr.xml"
            Dim newModel As String = "AIModel"
            Dim newApiKey As String = "ApiKey"
            Dim newApiUrl As String = "ApiUrl"

            ' Update OCR configuration with new settings
            UpdateOcrConfig(filePath, newModel, newApiKey, newApiUrl)

            ' Perform OCR scanning on the image
            ScanImg(filename, outputFile)

            ' Display the OCR result in a text viewer
            TxtViewer(outputFile)
        End Sub
        Public Shared Sub ScanImg(ByVal filename As String, ByVal outputFile As String)
            ' Create OCR scanner instance
            Dim scanner As OcrScanner = New OcrScanner()

            ' Configure OCR options
            Dim configureOptions As ConfigureOptions = New ConfigureOptions()
            configureOptions.ModelPath = "D:\\AI"
            configureOptions.Language = "Japanese"

            ' Apply configuration to scanner
            scanner.ConfigureDependencies(configureOptions)

            ' Execute OCR scan on the image
            scanner.Scan(filename)
            File.WriteAllText(outputFile, scanner.Text.ToString())
        End Sub
        Public Shared Sub UpdateOcrConfig(ByVal filePath As String, ByVal model As String, ByVal apiKey As String, ByVal apiUrl As String)
            ' Load the XML configuration file
            Dim doc As XmlDocument = New XmlDocument()
            doc.Load(filePath)

            ' Select XML nodes for each configuration element using XPath
            Dim modelNode As XmlNode = doc.SelectSingleNode("/ocr/configs/model")
            Dim apiKeyNode As XmlNode = doc.SelectSingleNode("/ocr/configs/apiKey")
            Dim apiUrlNode As XmlNode = doc.SelectSingleNode("/ocr/configs/apiUrl")

            ' Update node values if they exist
            if (modelNode  <> Nothing) modelNode.InnerText = model
            if (apiKeyNode  <> Nothing) apiKeyNode.InnerText = apiKey
            if (apiUrlNode  <> Nothing) apiUrlNode.InnerText = apiUrl

            doc.Save(filePath)
            Console.WriteLine("XML file updated  ")
        End Sub
        Private Sub TxtViewer(ByVal outputFile As String)
            System.Diagnostics.Process.Start(outputFile)
        End Sub
    End Class
End Namespace
