#Region "Imports"
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Collections.Specialized
Imports System.Threading
#End Region
#Region "Main-Class"
Public Class Form1
    Private Sub LoadFileButton_Click(sender As Object, e As EventArgs) Handles LoadFileButton.Click
        Using OpenFileDialog As New OpenFileDialog() With {.Title = "Please Select File", .Filter = "txt files (*.txt)|*.txt"}
            If OpenFileDialog.ShowDialog = DialogResult.OK Then
                FileNameBox.Text = OpenFileDialog.FileName
            End If
        End Using
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked Then
            Label1.Text = "Token :" : Label2.Text = "ID :"
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked Then
            Label1.Text = "Webhook :" : Label2.Text = "Content :"
        End If
    End Sub
    ''' <summary>
    ''' Send Http post request to send txt file and return the response body.
    ''' </summary>
    ''' <param name="Url">The Url that we will send the request to it.</param>
    ''' <param name="FormFields">The Form-Data for request body.</param>
    ''' <returns>The Value of response body.</returns>
    Public Function SendPost(Url As String, FormFields As NameValueCollection) As String
        Try
            Dim request As HttpWebRequest = CType(HttpWebRequest.Create(Url), HttpWebRequest)
            Dim boundary As String = "----------------------------" & DateTime.Now.Ticks.ToString("x")
            request.ContentType = "multipart/form-data; boundary=" & boundary
            request.Method = "POST"
            request.KeepAlive = True
            Dim meStream As MemoryStream = CreateMultipartData(boundary, FileNameBox.Text, FormFields)
            request.ContentLength = meStream.Length
            Using requestStream As Stream = request.GetRequestStream()
                meStream.Position = 0
                Dim tempBuffer As Byte() = New Byte(meStream.Length - 1) {}
                meStream.Read(tempBuffer, 0, tempBuffer.Length)
                meStream.Close()
                requestStream.Write(tempBuffer, 0, tempBuffer.Length)
            End Using
            'get response from the server and return the body.
            Using response As WebResponse = request.GetResponse()
                Dim reader2 As New StreamReader(response.GetResponseStream())
                Return reader2.ReadToEnd()
            End Using
        Catch : End Try
        Return Nothing
    End Function

    ''' <summary>
    ''' Create multipart/form-data and return it.
    ''' </summary>
    ''' <param name="boundary">boundary.</param>
    ''' <param name="FilePath">The path of the file we will send.</param>
    ''' <param name="FormFields">The Form-Data to put it in the multipart/form-data.</param>
    ''' <returns>The Value of response body.</returns>
    Public Function CreateMultipartData(boundary As String, FilePath As String, FormFields As NameValueCollection) As MemoryStream
        Dim FileContent As New FileStream(FilePath, FileMode.Open, FileAccess.Read)
        Dim meStream As New MemoryStream()
        Dim Firstboundarybytes As Byte() = Encoding.ASCII.GetBytes(vbCrLf & "--" & boundary & vbCrLf)
        Dim FinalBoundaryBytes As Byte() = Encoding.ASCII.GetBytes(vbCrLf & "--" & boundary & "--")
        Dim formdataT As String = vbCrLf & "--" & boundary & vbCrLf & "Content-Disposition: form-data; name=""{0}"";" & vbCrLf & vbCrLf & "{1}"
        'set the form-data to the multipart/form-data.
        For Each key As String In FormFields.Keys
            Dim formitem As String = String.Format(formdataT, key, FormFields(key))
            Dim formitembytes As Byte() = Encoding.UTF8.GetBytes(formitem)
            meStream.Write(formitembytes, 0, formitembytes.Length)
        Next
        Dim headerTemplate As String = "Content-Disposition: form-data; name={0}; filename=""{1}""" & vbCrLf & "Content-Type: application/octet-stream" & vbCrLf & vbCrLf
        'After finished up the form now we getting to the hard part the file.
        meStream.Write(Firstboundarybytes, 0, Firstboundarybytes.Length)
        'Before we Format the string we must check where the user want send this file; because the parameters name varies from server to server.
        Dim header As String = String.Format(headerTemplate, If(RadioButton1.Checked, "document", "file1"), FileContent.Name)
        Dim headerbytes As Byte() = Encoding.UTF8.GetBytes(header)
        meStream.Write(headerbytes, 0, headerbytes.Length)
        Dim Bytes As Byte() = New Byte(1023) {}
        Dim Bytesnum As Integer = FileContent.Read(Bytes, 0, Bytes.Length)
        While Not Bytesnum = 0
            meStream.Write(Bytes, 0, Bytesnum)
            Bytesnum = FileContent.Read(Bytes, 0, Bytes.Length)
        End While
        'setup memory stream for request stream.
        meStream.Write(FinalBoundaryBytes, 0, FinalBoundaryBytes.Length)
        'Everything is ready now we just need to return the value of meStream.
        Return meStream
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If String.IsNullOrEmpty(FileNameBox.Text) Then MsgBox("The File is missing!") : Exit Sub
        Button2.Enabled = False
        If RadioButton1.Checked AndAlso (String.IsNullOrEmpty(TokenBox.Text) Or String.IsNullOrEmpty(IDBox.Text)) Then
            MsgBox("Something is missing ! <Bot Token or chat id>") : Exit Sub
        ElseIf RadioButton2.Checked AndAlso String.IsNullOrEmpty(TokenBox.Text) Then
            MsgBox("Webhook url is Missing!") : Exit Sub
        End If
        Dim th As New Thread(New ThreadStart(Sub()
                                                 Dim response As String : Dim url As String : Dim Formdata As New NameValueCollection()
                                                 url = If(RadioButton1.Checked, String.Format("https://api.telegram.org/bot{0}/SendDocument", TokenBox.Text), TokenBox.Text)
                                                 'Before we add the form field we must check where the user want send this file; because the parameters name varies from server to server.
                                                 Formdata.Add(If(RadioButton1.Checked, "chat_id", "Content"), IDBox.Text)
                                                 Try
                                                     response = SendPost(url, Formdata)
                                                 Catch ex As Exception
                                                     response = "Error " & ex.Message
                                                 End Try
                                                 RichTextBox1.Text = $"URL : {url}{vbNewLine}Response : {response}"
                                                 Button2.Enabled = True
                                             End Sub)) With {.IsBackground = True} : th.Start()
    End Sub
End Class
#End Region
