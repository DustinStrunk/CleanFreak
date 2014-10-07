Imports System.IO
Imports System.Net
Public Class Form1

    Dim download As String = "C:\Users\" + Environment.UserName + "\Downloads"


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click



        If ListBox1.Text.Contains("\") Then
            If CheckBox1.Checked = True Then
                If MessageBox.Show("Are you sure you would like to delete all files with an" & ListBox1.Text, "Are you Sure?", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    File.Delete(ListBox1.Text)
                Else : MessageBox.Show(ListBox1.Text & "was not deleted")
                End If
            Else
                File.Delete(ListBox1.Text)
            End If

        Else
            If CheckBox1.Checked = True Then
                If MessageBox.Show("Are you sure you would like to delete all files with an" & ListBox1.Text, "Are you Sure?", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    If RadioButton1.Checked = True Then
                        MessageBox.Show("Please wait for the done messagebox to show.")
                        Dim exelist As String() = Directory.GetFiles(download, "*" & ListBox1.Text, SearchOption.AllDirectories)
                        For Each f In exelist
                            File.Delete(f)
                            ListBox1.Items.Remove(ListBox1.SelectedIndex)
                        Next
                        MessageBox.Show("Done!")
                    Else
                        MessageBox.Show("Please wait for the done messagebox to show.")
                        Dim exelist As String() = Directory.GetFiles(download, "*" & ListBox1.Text)
                        For Each f In exelist
                            File.Delete(f)
                            ListBox1.Items.Remove(ListBox1.SelectedIndex)
                        Next
                        MessageBox.Show("Done!")
                    End If
                Else : MessageBox.Show("The files havn't been deleted") : End If
            Else
                If RadioButton1.Checked = True Then
                    MessageBox.Show("Please wait for the done messagebox to show.")
                    Dim exelist As String() = Directory.GetFiles(download, "*" & ListBox1.Text, SearchOption.AllDirectories)
                    For Each f In exelist
                        File.Delete(f)
                        ListBox1.Items.Remove(ListBox1.SelectedIndex)
                    Next
                    MessageBox.Show("Done!")
                Else
                    MessageBox.Show("Please wait for the done messagebox to show.")
                    Dim exelist As String() = Directory.GetFiles(download, "*" & ListBox1.Text)
                    For Each f In exelist
                        File.Delete(f)
                        ListBox1.Items.Remove(ListBox1.SelectedIndex)
                    Next
                    MessageBox.Show("Done!")
                End If
            End If
        End If


    End Sub

    Dim fbd As FolderBrowserDialog = New FolderBrowserDialog
    Private Sub Button2_Click_1(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        fbd.ShowDialog()
        TextBox1.Text = fbd.SelectedPath
        ListBox1.Items.Clear()
        Dim list4 As String() = Directory.GetFiles(TextBox1.Text, "*.*")
        For Each f In list4
            Dim extension2 As String = f.Substring(f.LastIndexOf("."))
            If ListBox1.Items.Contains(extension2) Then

            Else
                ListBox1.Items.Add(extension2)

            End If

        Next

    End Sub
    Private Sub TextBox1_Click(sender As Object, e As System.EventArgs) Handles TextBox1.Click
        fbd.ShowDialog()
        TextBox1.Text = fbd.SelectedPath

    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim list3 As String() = Directory.GetFiles(download, "*.*")
        For Each f In list3
            Dim extension As String = f.Substring(f.LastIndexOf("."))
            If ListBox1.Items.Contains(extension) Then
            Else
                ListBox1.Items.Add(extension)

            End If

        Next

    End Sub

    Private Sub SerchToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SerchToolStripMenuItem.Click

        If TextBox1.Text = "" Then
            Dim r As String() = Directory.GetFiles(download, "*" & ListBox1.Text)
            ListBox1.Width = 271
            ListBox1.Items.Clear()
            For Each f In r
                ListBox1.Items.Add(f)
            Next
        Else
            Dim w As String() = Directory.GetFiles(TextBox1.Text, "*" & ListBox1.Text)
            ListBox1.Width = 271
            ListBox1.Items.Clear()
            For Each f In w
                ListBox1.Items.Add(f)
            Next
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        If ListBox1.Text.Contains("\") Then
            Dim r As String() = Directory.GetFiles(download, "*" & ListBox1.Text)
            For Each f In r
                File.Delete(f)
                ListBox1.Items.Remove(ListBox1.SelectedIndex)
            Next
        Else
            File.Delete(ListBox1.Text)
        End If
    End Sub

    Private Sub OriganalEntriesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OriganalEntriesToolStripMenuItem.Click
        ListBox1.Items.Clear()
        If TextBox1.Text = "" Then
            Dim list3 As String() = Directory.GetFiles(download, "*.*")
            For Each f In list3
                Dim extension As String = f.Substring(f.LastIndexOf("."))
                If ListBox1.Items.Contains(extension) Then

                Else
                    ListBox1.Items.Add(extension)

                End If

            Next
        Else
            Dim list4 As String() = Directory.GetFiles(TextBox1.Text, "*.*")
            For Each f In list4
                Dim extension2 As String = f.Substring(f.LastIndexOf("."))
                If ListBox1.Items.Contains(extension2) Then

                Else
                    ListBox1.Items.Add(extension2)

                End If
            Next
        End If
    End Sub

    Private Sub ListBox1_MouseHover(sender As Object, e As System.EventArgs) Handles ListBox1.MouseHover
        ToolTip1.SetToolTip(ListBox1, ListBox1.Text)
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Form2.Show()
    End Sub

    
    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Form3.Show()
    End Sub
End Class
