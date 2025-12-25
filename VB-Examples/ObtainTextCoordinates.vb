Imports Spire.OCR
Imports System.IO
Imports System.Text

Namespace ObtainTextCoordinates
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Note: 1. Download the latest model from official website: https://www.e-iceblue.com/Tutorials/NET/Spire.OCR-for-.NET/Program-Guide/Recognize-Text/C-Extract-Text-from-Images-using-the-New-Model-of-Spire.OCR-for-.NET.html
            ' 2. Modify the ModelPath below to your model directory

            Dim imageFile As String = "../../../../../Data/Sample.png"
            Dim outputFile As String = "ObtainTextCoordinates_out.txt"

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

            ' Scan image
            scanner.Scan(imageFile)

            ' Retrieve all text blocks detected by the OCR engine
            Dim blocks As IOCRTextBlock() = scanner.Text.Blocks

            ' Get the text coordinate
            Dim scannnedText As String = PrintTextBlocks(blocks)

            ' Save result to file
            File.WriteAllText(outputFile, scannnedText)

            scanner.Dispose()

            TxtViewer(outputFile)
        End Sub

        Private Function PrintTextBlocks(blocks As IOCRTextBlock(), Optional sb As StringBuilder = Nothing) As String
            ' Create a new StringBuilder
            If sb Is Nothing OrElse sb.Length = 0 Then
                sb = New StringBuilder()
            End If

            ' Skip processing if no blocks are provided
            If blocks IsNot Nothing AndAlso blocks.Count() > 0 Then
                For Each block In blocks
                    ' Retrieve the bounding rectangle of the current block
                    Dim rectangle As Rectangle = block.Box

                    ' Format the rectangle coordinates and block details
                    Dim t1 As String = String.Format("Rectangle : [{0}, {1}, {2}, {3}] , ",
                                             rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height)
                    Dim t2 As String = String.Format("Level ({0}): {1}", block.Level.ToString(), block.Text)
                    Dim text As String = t1 & t2
                    text = text & vbCrLf

                    ' Append the formatted information to the result buffer
                    sb.Append(text)

                    ' Recursively process any child text blocks
                    PrintTextBlocks(block.TextBlock, sb)
                    If block.Level = TextBlockType.Line Then
                        sb.Append(vbCrLf)
                    End If
                Next
            End If

            Return sb.ToString()
        End Function

        Private Sub TxtViewer(ByVal outputFile As String)
            Process.Start(outputFile)
        End Sub
    End Class
End Namespace
