Imports System.Environment
Imports System.IO
Imports System.Net

Public Class MainForm
    Public Version As Double = 1.4
    Public Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    Dim InformationFolder As String
    Dim UpdateLocation As String
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdaterVersionLabel.Text = UpdaterVersionLabel.Text & Version
        SpeedLabel.Visible = False
        UpdateInformationLabel.Visible = False
        CurrentDownloadLabel.Visible = False
        AnimationTimer.Enabled = True
        If My.Computer.FileSystem.DirectoryExists(GetFolderPath(SpecialFolder.ApplicationData) & "\Dunois Software\AnimationCheckerPro") Then
            InformationFolder = GetFolderPath(SpecialFolder.ApplicationData) & "\Dunois Software\AnimationCheckerPro"
            UpdateLocation = XMLReader(InformationFolder & "\Settings.xml", "System", "ProgramPath")
            XMLWriter(InformationFolder & "\Settings.xml", "System", "UpdaterVersion", Version)
        Else
            MsgBox("잘못된 접근입니다.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "오류")
        End If
    End Sub
    Function UpdateCheck()
        If My.Computer.FileSystem.FileExists(InformationFolder & "\Settings.xml") Then
            Dim UpdateStatus As Integer = XMLReader(InformationFolder & "\Settings.xml", "System", "UpdateStatus")
            If UpdateStatus = 1 Then
                Return 0
            Else
                Return 1
            End If
        Else
            Return 1
        End If
    End Function
    Public Sub ACPKill()
        For Each prog As Process In Process.GetProcesses
            If prog.ProcessName = "AnimationCheckerPro" Then
                prog.Kill()
            End If
        Next
    End Sub
    Function XMLReader(ByVal XMLPath As String, ByVal Element_1 As String, ByVal Element_2 As String)
        Dim xml = XDocument.Load(XMLPath)
        Try
            Return xml.Element(Element_1).Element(Element_2).Value
        Catch ex As Exception
            Return "Error"
        End Try
    End Function
    Public Sub XMLWriter(ByVal XMLFile As String, ByVal Element_1 As String, ByVal Element_2 As String, ByVal Value As String)
        Dim xmle As XElement = XElement.Load(XMLFile)
        If xmle.Element(Element_2) Is Nothing Then
            xmle.Add(New XElement(Element_2, Value))
            xmle.Save(XMLFile)
        Else
            xmle.SetElementValue(Element_2, Value)
            xmle.Save(XMLFile)
        End If
    End Sub
    Public Sub GetFileFromUrl(ByVal url As String, ByVal DownloadDestination As String)
        FormCloseButton.Enabled = False
        Try
            Dim ReDownBufferSize As Double = 0
            Dim ThisRequest As HttpWebRequest = DirectCast(WebRequest.Create(url), HttpWebRequest)
            Dim ThisResponese As HttpWebResponse = DirectCast(ThisRequest.GetResponse(), HttpWebResponse)
            Dim TotalSize As Integer = ThisResponese.ContentLength
            Dim MyThisStream As Stream = ThisResponese.GetResponseStream()
            Dim GetFileStream As New FileStream(DownloadDestination, FileMode.Create)
            Dim buff As Byte() = New Byte(TotalSize) {}
            Dim buffer As Byte() = buff
            Dim TMP As Long
            Dim StartTime As DateTime = Now
            Try
                Do Until GetFileStream.Length = TotalSize
                    ReDownBufferSize = MyThisStream.Read(buff, 0, 1024)
                    GetFileStream.Write(buffer, 0, ReDownBufferSize)

                    TMP = DateDiff("s", StartTime, Now) + 1
                    Application.DoEvents()
                    DownloadProgressBar.Value = Math.Round(GetFileStream.Length) / Math.Round(TotalSize) * 100
                    CurrentDownloadLabel.Text = Math.Round(GetFileStream.Length / 1024 ^ 2, 2) & "MB / " & Math.Round(TotalSize / 1024 ^ 2, 2) & "MB)"
                    If (GetFileStream.Length / TMP / 1024) > 850 Then
                        SpeedLabel.Text = Format(((GetFileStream.Length / TMP / 1024) / 1024), "#0.##") & " MB/sec"
                    Else
                        SpeedLabel.Text = Format(((GetFileStream.Length / TMP / 1024) / 1024), "#0.##") & " KB/sec"
                    End If
                Loop
            Catch ex As Exception
                End
            End Try
            GetFileStream.Close()
            MyThisStream.Close()
            ThisResponese.Close()
            DownloadProgressBar.Value = 100
        Catch ex As Exception
            MsgBox("다운로드에 실패하였습니다.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "오류")
        End Try
    End Sub

    Private Sub FormCloseButton_Click(sender As Object, e As EventArgs) Handles FormCloseButton.Click
        Close()
    End Sub

    Private Sub AnimationTimer_Tick(sender As Object, e As EventArgs) Handles AnimationTimer.Tick
        AnimationTimer.Enabled = False
        If UpdateCheck() = 0 Then
            ACPKill()
            SpeedLabel.Visible = True
            UpdateInformationLabel.Visible = True
            CurrentDownloadLabel.Visible = True
            ACPDelete(UpdateLocation)
            DownloadVerInfo()
            Dim OldVersion As Double = XMLReader(InformationFolder & "\Settings.xml", "System", "ProgramVersion")
            Dim NewVersion As Double = INIRead("System", "Version", My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData & "\ProgramVersion.ini")
            UpdateInformationLabel.Text = OldVersion & "버전 에서 " & NewVersion & "버전 으로 업데이트 합니다."
            GetFileFromUrl("http://dunois403.cafe24.com/ACPData/AnimationCheckerPro_Temp.exe", UpdateLocation & "\AnimationCheckerPro.exe")
            Shell(UpdateLocation & "\AnimationCheckerPro.exe", AppWinStyle.NormalFocus)
            Close()
        Else
            MsgBox("잘못된 접근입니다.", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, "오류")
        End If
    End Sub
    Public Sub DownloadVerInfo()
        If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData & "\ProgramVersion.ini") Then
            My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData & "\ProgramVersion.ini")
        End If
        My.Computer.Network.DownloadFile("http://dunois403.cafe24.com/ACPData/ACPVersion.ini", My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData & "\ProgramVersion.ini")
    End Sub
    Public Sub ACPDelete(ByVal ProgramLocation As String)
        If My.Computer.FileSystem.FileExists(ProgramLocation & "\AnimationCheckerPro.exe") Then
            My.Computer.FileSystem.DeleteFile(ProgramLocation & "\AnimationCheckerPro.exe")
        End If
    End Sub
    Public Function INIRead(ByVal Session As String, ByVal KeyValue As String, ByVal INIFILE As String) As String
        Dim s As New String("", 1024)
        Dim ReturnValue As Long
        ReturnValue = GetPrivateProfileString(Session, KeyValue, "", s, 1024, INIFILE)
        Return Mid(s, 1, InStr(s, Chr(0)) - 1)

    End Function

    Private Sub SelfUpdateButton_Click(sender As Object, e As EventArgs) Handles SelfUpdateButton.Click
        Dim SelectedFolder As String
        Dim OpenFolderDialog As New FolderBrowserDialog
        OpenFolderDialog.ShowNewFolderButton = True
        OpenFolderDialog.Description = "다운로드 폴더 선택"
        If (OpenFolderDialog.ShowDialog() = DialogResult.OK) Then
            SelectedFolder = OpenFolderDialog.SelectedPath
            ACPKill()
            SpeedLabel.Visible = True
            UpdateInformationLabel.Visible = True
            CurrentDownloadLabel.Visible = True
            ACPDelete(SelectedFolder)
            DownloadVerInfo()
            Dim NewVersion As Double = INIRead("System", "Version", My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData & "\ProgramVersion.ini")
            UpdateInformationLabel.Text = NewVersion & "버전을 다운로드 합니다."
            GetFileFromUrl("http://dunois403.cafe24.com/ACPData/AnimationCheckerPro_Temp.exe", UpdateLocation & "\AnimationCheckerPro.exe")
            Shell(UpdateLocation & "\AnimationCheckerPro.exe", AppWinStyle.NormalFocus)
            Close()
        End If
    End Sub
End Class
