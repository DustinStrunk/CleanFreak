Imports System.IO
Imports System.IO.Packaging
Public Class Form3
    Dim download As String = "C:\Users\" + Environment.UserName + "\Downloads"
    Dim zippath = CurDir()
    Dim path3 = CurDir()
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If CheckBox1.Checked = True Then

            Dim zip As Package = ZipPackage.Open(zippath & "\backupcf.zip", IO.FileMode.OpenOrCreate, IO.FileAccess.ReadWrite)

            Dim list1 As String() = Directory.GetFiles(download, "*" & ListBox1.Text)
            For Each f In list1
                AddToArchive(zip, f)
            Next
            zip.Close()

        Else
        Dim list1 As String() = Directory.GetFiles(download, "*" & ListBox1.Text)
        For Each f In list1
            Dim list2 As String = f.Substring(f.LastIndexOf("\"))
            If Not File.Exists(path3 & "\backupcf" & list2) Then
                File.Copy(f, path3 & "\backupcf" & list2)
            End If
        Next
        MessageBox.Show("Done!" & vbCrLf & "Backup is located in" & path3 & "\backupcf\")
        End If
    End Sub


    Private Sub Form3_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        RadioButton1.Checked = True
        Directory.CreateDirectory(path3 & "\backupcf")
        Dim list As String() = Directory.GetFiles(download, "*.*")
            For Each f In list
                Dim extension As String = f.Substring(f.LastIndexOf("."))
                If ListBox1.Items.Contains(extension) Then
                Else
                    ListBox1.Items.Add(extension)
                End If
            Next
    End Sub
  Private Sub AddToArchive(ByVal zip As Package, _ 
                           ByVal fileToAdd As String)
        Dim uriFileName As String = fileToAdd.Replace(" ", "_")
        Dim zipUri As String = String.Concat("/", _
                   IO.Path.GetFileName(uriFileName))
        Dim partUri As New Uri(zipUri, UriKind.Relative)
        Dim contentType As String = _
                   Net.Mime.MediaTypeNames.Application.Zip
        If RadioButton1.Checked = True Then
            Try
                Dim pkgPart As PackagePart = zip.CreatePart(partUri, _
                           contentType, CompressionOption.Normal)
                Dim bites As Byte() = File.ReadAllBytes(fileToAdd)

                pkgPart.GetStream().Write(bites, 0, bites.Length)
            Catch ex As Exception

            End Try
        ElseIf RadioButton2.Checked = True Then
            Try
                Dim pkgPart As PackagePart = zip.CreatePart(partUri, _
                           contentType, CompressionOption.Maximum)
                Dim bites As Byte() = File.ReadAllBytes(fileToAdd)
                pkgPart.GetStream().Write(bites, 0, bites.Length)
            Catch ex As Exception
            End Try
        ElseIf RadioButton3.Checked = True Then
            Try
                Dim pkgPart As PackagePart = zip.CreatePart(partUri, _
                          contentType, CompressionOption.Fast)
                Dim bites As Byte() = File.ReadAllBytes(fileToAdd)
                pkgPart.GetStream().Write(bites, 0, bites.Length)
            Catch ex As Exception : End Try
        ElseIf RadioButton4.Checked = True Then
            Try
                Dim pkgPart As PackagePart = zip.CreatePart(partUri, _
                              contentType, CompressionOption.SuperFast)
                Dim bites As Byte() = File.ReadAllBytes(fileToAdd)

                pkgPart.GetStream().Write(bites, 0, bites.Length)
            Catch ex As Exception : End Try

        End If
    End Sub
End Class