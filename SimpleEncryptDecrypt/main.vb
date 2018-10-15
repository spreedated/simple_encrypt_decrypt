Public Class main
    Public keyShow As Boolean = False
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = myappfullname
        init_toolstrip_box(Me)
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Select Case keyShow
            Case False
                keyShow = True
                Button2.Text = "Hide &Key"
                Label1.Visible = True
                Label2.Visible = True
            Case True
                keyShow = False
                Button2.Text = "Show &Key"
                Label1.Visible = False
                Label2.Visible = False
        End Select
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            Button1.PerformClick()
            TextBox1.Focus()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox2.Text.Length >= 1 Then
            My.Computer.Clipboard.Clear()
            My.Computer.Clipboard.SetText(TextBox2.Text)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        infobox.ShowDialog()
    End Sub
End Class
