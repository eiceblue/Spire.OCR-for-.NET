Imports Spire.OCR
Imports System.IO
Imports System.Text

Namespace ScanRotatedImage
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Note: 1. Download the latest model from official website: https://www.e-iceblue.com/Tutorials/NET/Spire.OCR-for-.NET/Program-Guide/Recognize-Text/C-Extract-Text-from-Images-using-the-New-Model-of-Spire.OCR-for-.NET.html
            ' 2. Modify the ModelPath below to your model directory

            Dim imageFile As String = "../../../../../Data/RotatedImage.png"
            Dim outputFile As String = "ScanRotatingImage_out.txt"

            ' Create an instance of the OcrScanner class
            Dim scanner As New OcrScanner()

            ' Create an instance of the ConfigureOptions class to set up the scanner configuration
            Dim configureOptions As New ConfigureOptions()

            ' Set the path to the new model (Must be modified to your actual model path)
            configureOptions.ModelPath = "D:\win-x64"

            ' Set the language for text recognition. The default is English.
            ' Supported languages include English, Chinese, Chinesetraditional, French, German, Japan, and Korean.
            configureOptions.Language = "English"

            ' Enable auto-rotation feature
            configureOptions.AutoRotate = True

            ' Apply configuration options
            scanner.ConfigureDependencies(configureOptions)

            ' Perform scanning operation, 'imageFile' is the source image
            scanner.Scan(imageFile)

            ' Create text aligner to process scan results
            Dim visualText As New VisualTextAligner(scanner.Text)

            ' Get aligned text string
            Dim scannnedText As String = visualText.ToString()

            ' Use StringBuilder to construct final text
            Dim builder As New StringBuilder()
            builder.Append(scannnedText)

            ' Write recognition results to output file
            File.WriteAllText(outputFile, builder.ToString())

            ' Dispose resources
            scanner.Dispose()

            TxtViewer(outputFile)
        End Sub
        Private Sub TxtViewer(ByVal outputFile As String)
            Process.Start(outputFile)
        End Sub

    End Class
End Namespace
