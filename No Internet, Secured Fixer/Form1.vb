Imports System.Net.NetworkInformation
Imports System.ComponentModel

'Hi, if you like the code and design please give me credits before using it, if you want :)
Public Class Form1
    Private Function IsConnectionAvailable() As Boolean

        Dim url As New System.Uri("https://www.google.com/")
        Dim req As System.Net.WebRequest
        req = System.Net.WebRequest.Create(url)
        Dim resp As System.Net.WebResponse
        Try
            resp = req.GetResponse()
            resp.Close()
            req = Nothing
            Return True
        Catch ex As Exception
            req = Nothing
            Return False
        End Try
    End Function

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox3.Visible = False
        Dim welcometext As String
        welcometext = "Hi " + SystemInformation.UserName + ", hope you're doing good!"
        Label1.Text = welcometext.ToUpper
        Label4.Text = My.Computer.Info.OSFullName
        If System.Environment.Is64BitOperatingSystem = True Then
            Label5.Text = "x64"
        Else
            Label5.Text = "x86"
        End If
        If My.Computer.Network.IsAvailable Then
            Label7.Text = "Connected"
            If IsConnectionAvailable() = True Then
                Label6.Text = "Connected"
                Label6.ForeColor = Color.Green
            Else
                Label6.Text = "Not connected"
                Label6.ForeColor = Color.Red
            End If

        Else
            Label7.Text = "Disconnected"
            Label6.Text = "First connect to any Wifi!"
        End If


    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        PictureBox3.Visible = True
        PictureBox1.Visible = False
        System.IO.File.WriteAllBytes(System.Environment.ExpandEnvironmentVariables("%WinDir%") + "\\clear.bat", My.Resources.clear)
        Dim proProcess As Process
        Dim inStartInfo As New ProcessStartInfo
        inStartInfo.WindowStyle = ProcessWindowStyle.Hidden
        inStartInfo.FileName = System.Environment.ExpandEnvironmentVariables("%WinDir%") + "\\clear.bat"
        inStartInfo.Arguments = String.Empty

        proProcess = Process.Start(inStartInfo)
        proProcess.WaitForExit()

        MsgBox("Done! Fixed from our end, if still problem persists, contact your ISP!", MsgBoxStyle.MsgBoxRight)
        MsgBox("If this program was useful for you, please do consider giving me a star on Github, also visit my site for more such handy tool!")

        PictureBox3.Visible = False

    End Sub


    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Process.Start("https://mustafahasankhan.com")
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Close()
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Process.Start("https://github.com/mustafahasankhan/nointernetsecuredfixer")

    End Sub
End Class
