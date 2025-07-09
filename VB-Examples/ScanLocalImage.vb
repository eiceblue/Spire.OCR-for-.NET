Imports Spire.OCR
Imports System.IO


Namespace ScanLocalImage
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Note: 1. Download the latest model from official website: https://www.e-iceblue.com/Tutorials/NET/Spire.OCR-for-.NET/Program-Guide/Recognize-Text/C-Extract-Text-from-Images-using-the-New-Model-of-Spire.OCR-for-.NET.html
			' 2. Modify the ModelPath below to your model directory

			Dim imageFile As String = "../../../../../Data/Sample.png"
			Dim outputFile As String = "ScanLocalImage_out.txt"

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

			' Save result to file
			File.WriteAllText(outputFile, scanner.Text.ToString())

			scanner.Dispose()

			TxtViewer(outputFile)
		End Sub
		Private Sub TxtViewer(ByVal outputFile As String)
			Process.Start(outputFile)
		End Sub
	End Class
End Namespace
