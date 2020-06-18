﻿Imports System.Net
Imports System.Text
Imports System.IO
Imports Microsoft.Win32
Imports System.ComponentModel
Imports System.Threading

Public Class Main
    Dim ThreadList As New List(Of Thread)
    Public ListBoxList As New List(Of String)
    Public UseQueue As Boolean = False
    Public m3u8List As New List(Of String)
    Public txtList As New List(Of String)
    Public mpdList As New List(Of String)
    Public ResoAvalibe As String = Nothing
    Public ResoSearchRunning As Boolean = False
    Public UsedMap As String = Nothing
    Public Debug1 As Boolean = False
    Public Debug2 As Boolean = False
    Public LogBrowserData As Boolean = False
    Public Thumbnail As String = Nothing
    Public MergeSubstoMP4 As Boolean = False
    Public LoginDialog As Boolean = False
    Public SaveLog As Boolean = False
    Dim ListOfStreams As New List(Of String)
    Public NonCR_Timeout As Integer = 5
    Public NonCR_URL As String = Nothing
    Public DlSoftSubsRDY As Boolean = True
    Public gIndexH As Integer = -1
    Public DialogTaskString As String
    Public UserCloseDialog As Boolean = False
    Dim Aktuell As String
    Dim Gesamt As String
    Public LabelUpdate As String = "Status: idle"
    Public LabelEpisode As String = "..."
    Public b As Boolean = True
    Public c As Boolean = True
    Public d As Boolean = True
    Public LoginOnly As String = "False"
    Public CreditsOnly As Boolean = False
    Public Pfad As String = My.Computer.FileSystem.CurrentDirectory
    Public ffmpeg_command As String = " -c copy -bsf:a aac_adtstoasc" '" -c:v hevc_nvenc -preset fast -b:v 6M -bsf:a aac_adtstoasc " 
    Public Resu As Integer
    Dim Resu2 As String
    Public ResuSave As String = "6666x6666"
    Public SubSprache As String
    'Public Unlock As Integer = 0
    'Public Unlock2 As Integer
    Public SubFolder As Integer
    Public SoftSubs As New List(Of String)
    Public AbourtList As New List(Of String)
    Public PauseList As New List(Of String)
    Public watingList As New List(Of String)
    Dim SoftSubsString As String
    Dim CR_Unlock_Error As String
    Dim versuch2 As Integer = 0
    Public keks As String = Nothing
    Public Startseite As String = "https://www.crunchyroll.com/"
    Dim SubSprache2 As String
    Dim URL_DL As String
    Dim Pfad_DL As String
    Public Grapp_RDY As Boolean = True
    Public Grapp_non_cr_RDY As Boolean = True
    Public Grapp_Abord As Boolean = False
    Public MaxDL As Integer
    'Public TaskCount As Integer = 0
    Public Event UpdateUI(ByVal sender As String, ByVal Int As Integer, ByVal Size As Double, ByVal Finished As Double, Color As Color, ByVal Speed As String)
    Public ResoNotFoundString As String
    Public ResoBackString As String
    Dim PB_list As New List(Of PictureBox)
    Public bt_dl As New List(Of PictureBox)
    Public bt_p As New List(Of PictureBox)
    Public PR_List As New List(Of Process)
    Public WebbrowserURL As String = Nothing
    Public WebbrowserText As String = Nothing
    Public WebbrowserTitle As String = Nothing
    Public UserBowser As Boolean = False
#Region "Sprachen Vairablen"
    Public URL_Invaild As String = "invalid URL, this Downloader is only for crunchyroll.com"
    Public SubFolder_automatic As String = "[automatic : Series/Season]"
    Public SubFolder_Nothing As String = "[ ignore subfolder ]"

    Dim DL_Path_String As String = "Please choose download directory."
    Public CR_Premium_Failed As String = "Can not verify the active premium membership."
    Public No_Stream As String = "Please make sure that the URL is correct."
    Dim TaskNotCompleed As String = "Please wait until the current task is completed."
    Dim Premium_Stream As String = "Please make sure that you logged in for this premium episode."
    Dim Error_Mass_DL As String = "We run into a problem here." + vbNewLine + "You can try to download every episode individually."
    Dim User_Fault_NoName As String = "no name, fallback solution : "
    Dim Sub_language_NotFound As String = "Could not find the sub language" + vbNewLine + "please make sure the language is available: "
    Dim Resolution_NotFound As String = "Could not find any resolution."
    Dim Error_unknown As String = "We run into a unknown problem here." + vbNewLine + "Do you like to send an Bug report?"
    Public CR_Unlock_Error_String As String = "unable to get an CR-US cookie."
    Dim ErrorNoPermisson As String = "Access is denied."
    'UI Variablen
    Public GB_Resolution_Text As String = "Resolution"
    Public GB_SubLanguage_Text As String = "Hardsub language"
    Public GB_Sub_Path_Text As String = "Sub directory"
    Public UL_US_Text As String = "enable US Cookie"
    Public RBAnime_Text As String = "series name"
    Public RBStaffel_Text As String = "series name + season"
    Public NewStart_String As String = "to adopt all the settings, a restart is necessary."
    Public DL_Count_simultaneousText As String = "Simultaneous Downloads"
    Public GB_Sub_FormatText As String = "extended Sub Settings"
    Public LabelResoNotFoundText As String = "resolution not found" + vbNewLine + "Select another one below"
    Public LabelLangNotFoundText As String = "language not found" + vbNewLine + "Select another one below"
    Public ButtonResoNotFoundText As String = "Submit"
    Public CB_SuB_Nothing As String = "[ without  (none) ]"
    Dim StatusToolTip As ToolTip = New ToolTip()
    Dim StatusToolTipText As String
    Public RunGecko As String = "Startup"
#End Region

#Region "UI"

    Private Sub PictureBox1_MouseHover(sender As Object, e As EventArgs) Handles pictureBox1.MouseMove
        pictureBox1.BackColor = SystemColors.Control
    End Sub

    Private Sub PictureBox1_MouseLeave(sender As Object, e As EventArgs) Handles pictureBox1.MouseLeave
        pictureBox1.BackColor = Color.Transparent
    End Sub


    Private Sub PictureBox2_MouseHover(sender As Object, e As EventArgs) Handles pictureBox2.MouseMove
        pictureBox2.BackColor = SystemColors.Control
    End Sub

    Private Sub PictureBox2_MouseLeave(sender As Object, e As EventArgs) Handles pictureBox2.MouseLeave
        pictureBox2.BackColor = Color.Transparent
    End Sub



    Private Sub PictureBox3_MouseEnter(sender As Object, e As EventArgs) Handles pictureBox3.MouseEnter
        pictureBox3.BackColor = SystemColors.Control
    End Sub

    Private Sub PictureBox3_MouseLeave(sender As Object, e As EventArgs) Handles pictureBox3.MouseLeave
        pictureBox3.BackColor = Color.Transparent
    End Sub

    Private Sub PictureBox4_MouseHover(sender As Object, e As EventArgs) Handles pictureBox4.MouseMove
        pictureBox4.BackColor = SystemColors.Control
    End Sub

    Private Sub PictureBox4_MouseLeave(sender As Object, e As EventArgs) Handles pictureBox4.MouseLeave
        pictureBox4.BackColor = Color.Transparent
    End Sub




#End Region
    Public Declare Function waveOutSetVolume Lib "winmm.dll" (ByVal uDeviceID As Integer, ByVal dwVolume As Integer) As Integer

    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If InStr(My.Computer.Info.OSFullName, "Server") Then
            MsgBox("Windows Server is not supported!", MsgBoxStyle.Critical)
            Me.Close()
        End If

        waveOutSetVolume(0, 0)
        Try
            Dim FileLocation As DirectoryInfo = New DirectoryInfo(Application.StartupPath)
            For Each File In FileLocation.GetFiles()
                If InStr(File.FullName, "log.txt") Then
                    My.Computer.FileSystem.DeleteFile(Path.Combine(Application.StartupPath, File.FullName))
                    Exit For
                End If
            Next
        Catch ex As Exception

        End Try
        ServicePointManager.Expect100Continue = True
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        Me.Icon = My.Resources.icon
        Try
            Dim rkg As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\CRDownloader")
            keks = rkg.GetValue("keks").ToString
        Catch ex As Exception
        End Try


        Try
            Dim rkg As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\CRDownloader")
            Pfad = rkg.GetValue("Ordner").ToString
        Catch ex As Exception

        End Try

        Try
            Dim rkg As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\CRDownloader")
            Startseite = rkg.GetValue("Startseite").ToString
        Catch ex As Exception

        End Try
#Region "Startup IU"
        StatusToolTip.Active = True
#End Region

        Try
            Dim rkg As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\CRDownloader")
            UseQueue = CBool(Integer.Parse(rkg.GetValue("QueueMode").ToString))
        Catch ex As Exception

        End Try

        Try
            Dim rkg As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\CRDownloader")
            ffmpeg_command = rkg.GetValue("ffmpeg_command").ToString
        Catch ex As Exception
            ffmpeg_command = " -c copy -bsf:a aac_adtstoasc "
        End Try

        If ffmpeg_command = " -c:v hevc_nvenc -preset fast -b:v 6M -bsf:a aac_adtstoasc " Then
            MaxDL = 2
        ElseIf ffmpeg_command = " -c:v libx265 -preset fast -b:v 6M -bsf:a aac_adtstoasc " Then
            MaxDL = 1
        End If
        Try
            Dim rkg As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\CRDownloader")
            Resu = Integer.Parse(rkg.GetValue("Resu").ToString)
            'MsgBox(Resu)
        Catch ex As Exception
        End Try

        Try
            Dim rkg As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\CRDownloader")
            SubSprache = rkg.GetValue("Sub").ToString
        Catch ex As Exception
        End Try

        Try
            Dim rkg As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\CRDownloader")
            SubFolder = Integer.Parse(rkg.GetValue("SubFolder").ToString)
        Catch ex As Exception
            SubFolder = 1
        End Try

        Try
            Dim rkg As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\CRDownloader")
            MaxDL = Integer.Parse(rkg.GetValue("SL_DL").ToString)


        Catch ex As Exception
            MaxDL = 1
        End Try
        Try
            Dim rkg As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\CRDownloader")
            MergeSubstoMP4 = CBool(Integer.Parse(rkg.GetValue("MergeMP4").ToString))
        Catch ex As Exception

        End Try
        Try
            Dim rkg As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\CRDownloader")
            SaveLog = CBool(Integer.Parse(rkg.GetValue("SaveLog").ToString))
        Catch ex As Exception

        End Try
        Try
            Dim rkg As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\CRDownloader")
            SaveLog = CBool(Integer.Parse(rkg.GetValue("SaveLog").ToString))
        Catch ex As Exception

        End Try
#Region "removed softsubtitle"

        Try
            Dim rkg As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\CRDownloader")
            SoftSubsString = rkg.GetValue("AddedSubs").ToString
            If SoftSubsString = "none" Then

            Else
                Dim SoftSubsStringSplit() As String = SoftSubsString.Split(New String() {","}, System.StringSplitOptions.RemoveEmptyEntries)
                For i As Integer = 0 To SoftSubsStringSplit.Count - 1
                    SoftSubs.Add(SoftSubsStringSplit(i))
                Next
            End If
        Catch ex As Exception
        End Try

#End Region

        If Resu = Nothing Then
            Resu = 1080
        End If

        If SubSprache = Nothing Then
            SubSprache = "enUS"
        End If

    End Sub

    Public Sub ListAdd(ByVal NameKomplett As String, ByVal NameP1 As String, ByVal NameP2 As String, ByVal Reso As String, ByVal HardSub As String, ByVal SoftSubs As String, ByVal ThumbnialURL As String)
        'MsgBox(NameKomplett)
        Dim ReDl As Boolean = False
        Dim index As Integer = 0
        For i As Integer = 0 To PB_list.Count - 1
            If PB_list.Item(i).Name = NameKomplett Then
                ReDl = True
                index = i
            End If
        Next
        If ReDl = True Then
            Dim PB As PictureBox = bt_dl.Item(index)
            PB.Enabled = True
        Else
            Dim b As New Bitmap(838, 142, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
            Dim g As Graphics = Graphics.FromImage(b)
            Dim ZeroPoint As Point = New Point(0, 0)
            Dim TextPoint As Point = New Point(195, 15)
            Dim TextPointL2 As Point = New Point(195, 42)
            Dim TextPointL3 As Point = New Point(773, 100)
            Dim TextPointL4 As Point = New Point(195, 101)
            Dim TextPointL4A2 As Point = New Point(300, 101)
            Dim ThumbnialPoint As Point = New Point(11, 20)
            Dim ProgressbarPoint As Point = New Point(195, 70)
            Dim newImage As Image = My.Resources.backgroud
            Dim img As Image = My.Resources.main_del
            Try
                Dim wc As New WebClient()
                Dim bytes As Byte() = wc.DownloadData(ThumbnialURL)
                Dim ms As New MemoryStream(bytes)
                img = System.Drawing.Image.FromStream(ms)
            Catch ex As Exception
                'MsgBox(ex.ToString)
                'MsgBox(ThumbnialURL)
            End Try
            g.DrawImage(newImage, ZeroPoint)
            Dim Thumnail As New Bitmap(168, 95, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
            Dim gr_dest As Graphics = Graphics.FromImage(Thumnail)
            gr_dest.DrawImage(img, 0, 0,
            Thumnail.Width + 1,
            Thumnail.Height + 1)
            g.DrawImage(Thumnail, ThumbnialPoint)
            g.DrawString(NameP1, FontLabel.Font, Brushes.Black, TextPoint)
            g.DrawString(NameP2, FontLabel.Font, Brushes.Black, TextPointL2)
            g.DrawRectangle(Pens.Black, ProgressbarPoint.X, ProgressbarPoint.Y, 601, 20)
            Dim brGradient As Brush = New SolidBrush(Color.FromArgb(247, 140, 37))
            g.FillRectangle(brGradient, ProgressbarPoint.X + 1, ProgressbarPoint.Y + 1, 0, 19)
            g.DrawString("0%", FontLabel2.Font, Brushes.Black, TextPointL3)
            g.DrawString(Reso, FontLabel.Font, Brushes.Black, TextPointL4)
            g.DrawString(HardSub, FontLabel.Font, Brushes.Black, TextPointL4A2)
            g.Dispose()
            gIndexH = gIndexH + 1

            With ListView1.Items.Add(0)
                LVPictureBox(ListView1, gIndexH, b, "Softsubs: " + SoftSubs, NameKomplett) ' removed softsubs LVPictureBox(ListView1, gIndexH, b, "Softsubs: " + SoftSubs, NameKomplett)

                Bt_del(ListView1, gIndexH, NameKomplett)
                Bt_PAUSE(ListView1, gIndexH, NameKomplett)
            End With
        End If
    End Sub

    Public Function Bt_del(ByVal pListView As ListView, ByVal ItemIndex As Integer, ByVal NameKomplett As String) As PictureBox
        'btn erstellen funktion
        Dim r As Rectangle
        Dim bt_r As New PictureBox
        Dim c As Integer = ListView1.Items.Count - 1
        r = pListView.Items(c).Bounds()
        bt_r.Parent = pListView
        bt_r.SetBounds(775, r.Y + 10, 35, 29)
        bt_dl.Add(bt_r)
        bt_r.Name = NameKomplett
        'bt_r.FlatStyle = FlatStyle.System
        bt_r.Visible = True
        bt_r.BringToFront()
        bt_r.Enabled = True
        bt_r.Image = My.Resources.main_close
        bt_r.Image = My.Resources.main_del
        bt_r.BackgroundImageLayout = ImageLayout.Center
        bt_r.SizeMode = PictureBoxSizeMode.Zoom
        ToolTip1.SetToolTip(bt_r, NameKomplett)
        'bt_r.FlatAppearance.BorderSize = 1
        'bt_r.FlatAppearance.BorderColor = Color.Black
        AddHandler bt_r.Click, AddressOf Me.Bt_r_click
        AddHandler bt_r.MouseEnter, AddressOf Me.Bt_r_ME
        AddHandler bt_r.MouseLeave, AddressOf Me.Bt_r_ML
        Return Nothing
    End Function
    Public Function Bt_PAUSE(ByVal pListView As ListView, ByVal ItemIndex As Integer, ByVal NameKomplett As String) As PictureBox
        'btn erstellen funktion
        Dim r As Rectangle
        Dim bt_r As New PictureBox
        Dim c As Integer = ListView1.Items.Count - 1
        r = pListView.Items(c).Bounds()
        bt_r.Parent = pListView
        bt_r.SetBounds(740, r.Y + 15, 25, 20)
        bt_p.Add(bt_r)
        bt_r.Name = "pause " + NameKomplett
        'bt_r.FlatStyle = FlatStyle.System
        bt_r.Visible = True
        bt_r.BringToFront()
        bt_r.Enabled = True
        bt_r.Image = My.Resources.main_pause
        bt_r.BackgroundImageLayout = ImageLayout.Center
        bt_r.SizeMode = PictureBoxSizeMode.Zoom
        ToolTip1.SetToolTip(bt_r, NameKomplett)
        'bt_r.FlatAppearance.BorderSize = 1
        'bt_r.FlatAppearance.BorderColor = Color.Black
        AddHandler bt_r.Click, AddressOf Me.Bt_p_click
        AddHandler bt_r.MouseEnter, AddressOf Me.Bt_p_ME
        AddHandler bt_r.MouseLeave, AddressOf Me.Bt_p_ML
        Return Nothing
    End Function

    Private Sub Bt_r_click(ByVal sender As Object, ByVal e As EventArgs)
        Dim b As PictureBox = sender
        b.Image = My.Resources.main_close
        If MessageBox.Show("Cancel this Download?", "Cancel?", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            AbourtList.Add(b.Name)
            b.Enabled = False
        Else
            b.Image = My.Resources.main_del
        End If

    End Sub
    Private Sub Bt_r_ME(ByVal sender As Object, ByVal e As EventArgs)
        Dim b As PictureBox = sender
        b.Image = My.Resources.main_del_hover
    End Sub
    Private Sub Bt_r_ML(ByVal sender As Object, ByVal e As EventArgs)
        Dim b As PictureBox = sender
        b.Image = My.Resources.main_del
    End Sub
    Private Sub Bt_p_click(ByVal sender As Object, ByVal e As EventArgs)
        Dim b As PictureBox = sender
        If CBool(InStr(b.Name, "pause")) Then
            b.Name = b.Name.Replace("pause", "continue")
            b.Image = My.Resources.main_pause_play
            PauseList.Add(b.Name.Replace("continue", ""))
        Else
            b.Name = b.Name.Replace("continue", "pause")
            b.Image = My.Resources.main_pause
            For i As Integer = 0 To PauseList.Count - 1
                If CBool(InStr(PauseList.Item(i), b.Name.Replace("pause", ""))) Then
                    PauseList.RemoveAt(i)
                    Exit For
                End If
            Next
        End If



    End Sub
    Private Sub Bt_p_ME(ByVal sender As Object, ByVal e As EventArgs)
        Dim b As PictureBox = sender
        If CBool(InStr(b.Name, "pause")) Then
            b.Image = My.Resources.main_pause_hover
        Else
            b.Image = My.Resources.main_pause_play_hover
        End If


    End Sub
    Private Sub Bt_p_ML(ByVal sender As Object, ByVal e As EventArgs)
        Dim b As PictureBox = sender
        If CBool(InStr(b.Name, "pause")) Then
            b.Image = My.Resources.main_pause
        Else
            b.Image = My.Resources.main_pause_play
        End If

    End Sub
    Public Function LVPictureBox(ByVal pListView As ListView, ByVal ItemIndex As Integer, ByVal img As Bitmap, ByVal SoftSubs As String, ByVal NameKomplett As String) As PictureBox
        'btn erstellen funktion
        Dim r As Rectangle
        Dim bt_d As New PictureBox
        Dim TT As New ToolTip
        Dim c As Integer = ListView1.Items.Count - 1
        r = pListView.Items(c).Bounds()
        r.Width = 838
        r.Height = 142
        bt_d.Parent = pListView
        bt_d.SetBounds(r.X, r.Y, r.Width, r.Height)
        bt_d.Name = NameKomplett
        bt_d.BackgroundImage = img

        ToolTip1.SetToolTip(bt_d, SoftSubs)
        bt_d.BackgroundImageLayout = ImageLayout.Center
        'bt_d.FlatAppearance.BorderColor = Color.Orange
        bt_d.Visible = True
        bt_d.Enabled = True
        PB_list.Add(bt_d)
        ' AddHandler LVPictureBox., AddressOf Me.LVPictureBox_MouseHover
        Return Nothing
    End Function


    Public Sub Pause(ByVal pau As Single)

        'Programmausführung verzögern *******************************************************

        Dim start, finish As Single
        start = Microsoft.VisualBasic.DateAndTime.Timer

        finish = start + pau
        Do While Microsoft.VisualBasic.DateAndTime.Timer < finish
            Application.DoEvents()
        Loop

    End Sub

#Region "Season DL"

    Public Sub MassGrapp()
        Anime_Add.groupBox2.Visible = True
        Anime_Add.PictureBox1.Enabled = True
        Anime_Add.PictureBox1.Visible = True
        Anime_Add.groupBox1.Visible = False
        Anime_Add.ComboBox1.Items.Clear()
        Anime_Add.comboBox3.Items.Clear()
        Anime_Add.comboBox4.Items.Clear()
        Anime_Add.ComboBox1.Enabled = False
        Anime_Add.comboBox3.Enabled = True
        Anime_Add.comboBox4.Enabled = True
        Dim Anzahl As String() = WebbrowserText.Split(New String() {"wrapper container-shadow hover-classes"}, System.StringSplitOptions.RemoveEmptyEntries)
        Dim Titel As String() = Anzahl(0).Split(New String() {"<meta content=" + Chr(34)}, System.StringSplitOptions.RemoveEmptyEntries)
        Dim Titel2 As String() = Titel(1).Split(New String() {Chr(34)}, System.StringSplitOptions.RemoveEmptyEntries)
        'Label10.Text = Titel2(0)
        Dim c As Integer = Anzahl.Count - 1
        '  FolgenZahl.Text = c.ToString + " Folgen gefunden."

        Array.Reverse(Anzahl)
        For i As Integer = 0 To Anzahl.Count - 2
            Dim URLGrapp As String() = Anzahl(i).Split(New String() {"title=" + Chr(34)}, System.StringSplitOptions.RemoveEmptyEntries)
            'MsgBox("1" + Chr(34))

            Dim URLGrapp2 As String() = URLGrapp(1).Split(New String() {Chr(34)}, System.StringSplitOptions.RemoveEmptyEntries)

            Anime_Add.comboBox3.Items.Add(URLGrapp2(0))
            Anime_Add.comboBox4.Items.Add(URLGrapp2(0))
        Next

    End Sub

    Public Sub SeasonDropdownGrapp()

        Anime_Add.groupBox2.Visible = True
        Anime_Add.PictureBox1.Enabled = True
        Anime_Add.PictureBox1.Visible = True
        Anime_Add.groupBox1.Visible = False
        Anime_Add.ComboBox1.Items.Clear()
        Anime_Add.comboBox3.Items.Clear()
        Anime_Add.comboBox4.Items.Clear()
        Anime_Add.ComboBox1.Enabled = True
        Anime_Add.comboBox3.Enabled = True
        Anime_Add.comboBox4.Enabled = True
        Dim Anzahl As String() = WebbrowserText.Split(New String() {"season-dropdown content-menu block"}, System.StringSplitOptions.RemoveEmptyEntries)
        Array.Reverse(Anzahl)
        For i As Integer = 0 To Anzahl.Count - 2
            Dim Titel As String() = Anzahl(i).Split(New String() {"</a>"}, System.StringSplitOptions.RemoveEmptyEntries)
            Dim Titel2 As String() = Titel(0).Split(New String() {">"}, System.StringSplitOptions.RemoveEmptyEntries)
            'MsgBox(Titel2(0))
            Anime_Add.ComboBox1.Items.Add(Titel2(1))
        Next

    End Sub

    Public Async Sub MassDL()
        If Anime_Add.comboBox3.Text = Nothing Then
            Exit Sub
        End If
        Anime_Add.Add_Display.Text = "preparing ..."
        Dim Website As String = WebbrowserText

        If Anime_Add.ComboBox1.Enabled = True Then
            Dim SeasonDropdownAnzahl As String() = Website.Split(New String() {"season-dropdown content-menu block"}, System.StringSplitOptions.RemoveEmptyEntries)
            Array.Reverse(SeasonDropdownAnzahl)
            Dim SDV As Integer = 0
            For i As Integer = 0 To SeasonDropdownAnzahl.Count - 1
                If InStr(SeasonDropdownAnzahl(i), Chr(34) + ">" + Anime_Add.ComboBox1.SelectedItem.ToString + "</a>") Then
                    SDV = i
                End If
            Next
            Website = SeasonDropdownAnzahl(SDV)
        End If
        Try
            Dim Anzahl As String() = Website.Split(New String() {"wrapper container-shadow hover-classes"}, System.StringSplitOptions.RemoveEmptyEntries)
            Array.Reverse(Anzahl)
            Dim c As Integer = 0
            Aktuell = "0"
            If Anime_Add.comboBox4.SelectedIndex > Anime_Add.comboBox3.SelectedIndex Or Anime_Add.comboBox4.SelectedIndex = Anime_Add.comboBox3.SelectedIndex Then
                c = Anime_Add.comboBox4.SelectedIndex - Anime_Add.comboBox3.SelectedIndex + 1
            Else
                Dim TempCB3 As Integer = Anime_Add.comboBox3.SelectedIndex
                Dim TempCB4 As Integer = Anime_Add.comboBox4.SelectedIndex
                Anime_Add.comboBox3.SelectedIndex = TempCB4
                Anime_Add.comboBox4.SelectedIndex = TempCB3
                c = Anime_Add.comboBox4.SelectedIndex - Anime_Add.comboBox3.SelectedIndex + 1
            End If
            Gesamt = c.ToString
            For i As Integer = Anime_Add.comboBox3.SelectedIndex To Anime_Add.comboBox4.SelectedIndex

                For e As Integer = 0 To Integer.MaxValue
                    'FontLabel.Visible = True
                    'FontLabel.Text = PR_List.Count.ToString
                    If Grapp_RDY = True Then
                        RemoveFinishedTask()
                        Pause(1)
                        If PR_List.Count < MaxDL Then
                            Exit For
                        Else
                            'MsgBox(e)
                            Await Task.Delay(2000)
                        End If
                    Else
                        Await Task.Delay(2000)
                    End If
                Next
                If Anime_Add.Mass_DL_Cancel = False Then
                    b = True
                    Exit For
                    Grapp_Abord = True
                    'MsgBox("dl_abourd")
                End If
                Dim d As Integer = i - Anime_Add.comboBox3.SelectedIndex + 1
                Dim URLGrapp As String() = Anzahl(i).Split(New String() {"<a href=" + Chr(34)}, System.StringSplitOptions.RemoveEmptyEntries)
                Dim URLGrapp2 As String() = URLGrapp(1).Split(New String() {Chr(34)}, System.StringSplitOptions.RemoveEmptyEntries)
                If Debug2 = True Then
                    MsgBox("https://www.crunchyroll.com" + URLGrapp2(0))
                End If
                If UseQueue = True Then
                    Anime_Add.ListBox1.Items.Add("https://www.crunchyroll.com" + URLGrapp2(0))
                    Anime_Add.Add_Display.ForeColor = Color.FromArgb(9248044)
                    Pause(1)
                    Anime_Add.Add_Display.ForeColor = Color.Black

                Else
                    Grapp_RDY = False
                    b = False
                    GeckoFX.WebBrowser1.Navigate("https://www.crunchyroll.com" + URLGrapp2(0))
                End If

                Aktuell = d.ToString
                Anime_Add.Add_Display.Text = Aktuell + " / " + Gesamt
            Next


        Catch ex As Exception
            If Debug2 = True Then
                MsgBox(ex.ToString)
            End If
            Anime_Add.comboBox4.Items.Clear()
            Anime_Add.comboBox3.Items.Clear()
            Aktuell = 0.ToString
            Gesamt = 0.ToString

            Anime_Add.groupBox1.Visible = True
            Anime_Add.groupBox2.Visible = False
            Anime_Add.GroupBox3.Visible = False
            Anime_Add.Mass_DL_Cancel = False
            Anime_Add.pictureBox4.Image = My.Resources.main_button_download_default
        End Try
        Pause(5)
        Anime_Add.groupBox1.Visible = True
        Anime_Add.groupBox2.Visible = False
        Anime_Add.GroupBox3.Visible = False
        Anime_Add.Mass_DL_Cancel = False
        Anime_Add.pictureBox4.Image = My.Resources.main_button_download_default
    End Sub
#End Region

#Region "SubsOnly"

    Public Sub MassGrappSubs()
        einstellungen.MultiDLSoftSubs.Enabled = True
        einstellungen.PictureBox3.Image = My.Resources.softsubs_download
        einstellungen.ComboBox1.Items.Clear()
        einstellungen.comboBox3.Items.Clear()
        einstellungen.comboBox4.Items.Clear()
        einstellungen.ComboBox2.Enabled = False
        Dim Anzahl As String() = WebbrowserText.Split(New String() {"wrapper container-shadow hover-classes"}, System.StringSplitOptions.RemoveEmptyEntries)
        Dim Titel As String() = Anzahl(0).Split(New String() {"<meta content=" + Chr(34)}, System.StringSplitOptions.RemoveEmptyEntries)
        Dim Titel2 As String() = Titel(1).Split(New String() {Chr(34)}, System.StringSplitOptions.RemoveEmptyEntries)
        Dim c As Integer = Anzahl.Count - 1
        Array.Reverse(Anzahl)
        For i As Integer = 0 To Anzahl.Count - 2
            Dim URLGrapp As String() = Anzahl(i).Split(New String() {"title=" + Chr(34)}, System.StringSplitOptions.RemoveEmptyEntries)
            Dim URLGrapp2 As String() = URLGrapp(1).Split(New String() {Chr(34)}, System.StringSplitOptions.RemoveEmptyEntries)

            einstellungen.comboBox3.Items.Add(URLGrapp2(0))
            einstellungen.comboBox4.Items.Add(URLGrapp2(0))
        Next

    End Sub

    Public Sub SeasonDropdownGrappSubs()
        einstellungen.MultiDLSoftSubs.Enabled = True
        einstellungen.PictureBox3.Image = My.Resources.softsubs_download
        einstellungen.ComboBox1.Items.Clear()
        einstellungen.comboBox3.Items.Clear()
        einstellungen.comboBox4.Items.Clear()
        einstellungen.ComboBox2.Enabled = True
        einstellungen.comboBox3.Enabled = True
        einstellungen.comboBox4.Enabled = True
        Dim Anzahl As String() = WebbrowserText.Split(New String() {"season-dropdown content-menu block"}, System.StringSplitOptions.RemoveEmptyEntries)
        Array.Reverse(Anzahl)
        For i As Integer = 0 To Anzahl.Count - 2
            Dim Titel As String() = Anzahl(i).Split(New String() {"</a>"}, System.StringSplitOptions.RemoveEmptyEntries)
            Dim Titel2 As String() = Titel(0).Split(New String() {">"}, System.StringSplitOptions.RemoveEmptyEntries)
            'MsgBox(Titel2(0))
            einstellungen.ComboBox2.Items.Add(Titel2(1))
        Next

    End Sub

    Public Sub DownloadSubsOnly()
        'Try
        'Throw New System.Exception("Test")
        DlSoftSubsRDY = False
        Dim CR_Anime_Titel As String = Nothing
        Dim CR_Anime_Staffel As String = Nothing
        Dim CR_Anime_Folge As String = Nothing
#Region "Name + Pfad"
        Dim Pfad2 As String
        Dim CR_FilenName As String = Nothing
        Dim SubfolderValue As String = Nothing
        Dim CR_FilenName_Backup As String = Nothing


#Region "Name von Crunchyroll"

        'Dim Bug_Deutsch As String = "-"
        'If CBool(InStr(WebbrowserTitle, "Anschauen auf Crunchyroll")) Then
        '    Bug_Deutsch = ":"
        'End If
        'Dim CR_Name_by_Titel_2 As String() = WebbrowserTitle.Split(New String() {Bug_Deutsch}, System.StringSplitOptions.RemoveEmptyEntries)
        'CR_FilenName = CR_Name_by_Titel_2(0).Trim()

        Dim Bug_Deutsch As String = "-"
        If CBool(InStr(WebbrowserTitle, "Anschauen auf Crunchyroll")) Then
            Bug_Deutsch = ":"
        End If
        Dim CR_Name_by_Titel_2 As String() = WebbrowserTitle.Split(New String() {Bug_Deutsch}, System.StringSplitOptions.RemoveEmptyEntries)
        Dim CR_Title As String = Nothing
        If CR_Name_by_Titel_2.Count > 2 Then
            For i As Integer = 0 To CR_Name_by_Titel_2.Count - 2
                If CR_Title = Nothing Then
                    CR_Title = CR_Name_by_Titel_2(i).Trim()
                Else
                    CR_Title = CR_Title + " " + CR_Name_by_Titel_2(i).Trim()
                End If

            Next
        End If
        CR_FilenName = CR_Title
        CR_FilenName_Backup = CR_Title
        'MsgBox(CR_FilenName)
        If CBool(InStr(WebbrowserText, "<h4>")) Then ' false on movie true on series
            Dim CR_Name_1 As String() = WebbrowserText.Split(New String() {"<h4>"}, System.StringSplitOptions.RemoveEmptyEntries)
            Dim CR_Name_2 As String() = CR_Name_1(1).Split(New String() {"</h4>"}, System.StringSplitOptions.RemoveEmptyEntries) '(New [Char]() {"-"})
            Dim CR_Name_Staffel0_Folge1 As String()
            If CBool(InStr(CR_Name_2(0), ",")) Then
                CR_Name_Staffel0_Folge1 = CR_Name_2(0).Split(New [Char]() {System.Convert.ToChar(",")}, System.StringSplitOptions.RemoveEmptyEntries)
                CR_Anime_Staffel = CR_Name_Staffel0_Folge1(0).Trim()
                CR_Anime_Folge = CR_Name_Staffel0_Folge1(1).Trim()
                CR_Anime_Folge = System.Text.RegularExpressions.Regex.Replace(CR_Anime_Folge, "[^\w\\-]", " ")
            Else
                CR_Anime_Staffel = Nothing
                CR_Anime_Folge = CR_Name_2(0).Trim()
                CR_Anime_Folge = System.Text.RegularExpressions.Regex.Replace(CR_Anime_Folge, "[^\w\\-]", " ")
            End If


            Dim CR_Name_4 As String() = CR_Name_1(0).Split(New String() {"class=" + Chr(34) + "text-link" + Chr(34) + ">"}, System.StringSplitOptions.RemoveEmptyEntries) '(New [Char]() {"-"})
            Dim CR_Name_Anime0 As String() = CR_Name_4(CR_Name_4.Length - 1).Split(New String() {"</a>"}, System.StringSplitOptions.RemoveEmptyEntries)
            CR_Name_Anime0(0) = System.Text.RegularExpressions.Regex.Replace(CR_Name_Anime0(0), "[^\w\\-]", " ")
            CR_Anime_Titel = CR_Name_Anime0(0).Trim
            If CR_Anime_Staffel = Nothing Then
                CR_FilenName = CR_Anime_Titel + " " + CR_Anime_Folge
            Else
                CR_FilenName = CR_Anime_Titel + " " + CR_Anime_Staffel + " " + CR_Anime_Folge
            End If

            CR_FilenName_Backup = RemoveExtraSpaces(CR_FilenName)


        End If
#End Region
        CR_FilenName = System.Text.RegularExpressions.Regex.Replace(CR_FilenName, "[^\w\\-]", " ")
        CR_FilenName = RemoveExtraSpaces(CR_FilenName)

        If SubfolderValue = Nothing Then
            Pfad2 = Pfad + "\" + CR_FilenName + ".mp4"
        Else
            Pfad2 = Pfad + "\" + SubfolderValue + CR_FilenName + ".mp4"
        End If
        If Not Directory.Exists(Path.GetDirectoryName(Pfad2)) Then
            ' Nein! Jetzt erstellen...
            Try
                Directory.CreateDirectory(Path.GetDirectoryName(Pfad2))
            Catch ex As Exception
                ' Ordner wurde nich erstellt
                Pfad2 = Pfad + "\" + CR_FilenName_Backup + ".mp4"
            End Try
        End If
        Pfad2 = Chr(34) + Pfad2 + Chr(34)

#End Region
#Region "Subs"
        Dim SoftSubs2 As New List(Of String)
        If SoftSubs.Count > 0 Then
            For i As Integer = 0 To SoftSubs.Count - 1
                If CBool(InStr(WebbrowserText, Chr(34) + "language" + Chr(34) + ":" + Chr(34) + SoftSubs(i) + Chr(34) + ",")) Then
                    SoftSubs2.Add(SoftSubs(i))
                Else
                    'MsgBox("Softsubtitle for " + SoftSubs(i) + " is not avalible.", MsgBoxStyle.Information)
                End If
            Next

        End If
        If SubSprache = "None" Then
            If CBool(InStr(WebbrowserText, Chr(34) + "hardsub_lang" + Chr(34) + ":null")) Then
                SubSprache2 = "null"
            Else
                Me.Invoke(New Action(Function()
                                         ResoNotFoundString = WebbrowserText
                                         DialogTaskString = "Language"
                                         Reso.ShowDialog()
                                         Return Nothing
                                     End Function))
                If UserCloseDialog = True Then
                    Throw New System.Exception(Chr(34) + "UserAbort" + Chr(34))
                Else
                    If ResoBackString = Nothing Then
                    Else
                        SubSprache2 = ResoBackString
                    End If
                End If
                'Throw New System.Exception("Could not find the sub language")
            End If


        Else
            If CBool(InStr(WebbrowserText, Chr(34) + "hardsub_lang" + Chr(34) + ":" + Chr(34) + SubSprache + Chr(34) + ",")) Then
                SubSprache2 = Chr(34) + SubSprache + Chr(34)

            ElseIf CBool(InStr(WebbrowserText, Chr(34) + "language" + Chr(34) + ":" + Chr(34) + SubSprache + Chr(34) + ",")) Then
                If MessageBox.Show("It look like only Softsubtitle are avalibe." + vbNewLine + "Are you want to use Softsubtitle this time instead?", "No Hardsubtitle", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                    SubSprache2 = "null"
                    SoftSubs2.Add(SubSprache)
                Else
                    Throw New System.Exception("Could not find the sub language")
                End If


            Else
                Me.Invoke(New Action(Function()
                                         ResoNotFoundString = WebbrowserText
                                         DialogTaskString = "Language"
                                         Reso.ShowDialog()
                                         Return Nothing
                                     End Function))
                If UserCloseDialog = True Then
                    Throw New System.Exception(Chr(34) + "UserAbort" + Chr(34))
                Else
                    If ResoBackString = Nothing Then
                    Else
                        SubSprache2 = ResoBackString
                    End If
                End If
            End If
        End If


#End Region
        If Grapp_Abord = True Then
            Grapp_RDY = True
            Grapp_Abord = False
            'MsgBox("grapp_abourd")
            Exit Sub

        End If


#Region "Download softsub file"

        If SoftSubs2.Count > 0 Then
            For i As Integer = 0 To SoftSubs2.Count - 1
                LabelUpdate = "Status: downloading subtitle file"
                LabelEpisode = SoftSubs2(i)
                Dim SoftSub As String() = WebbrowserText.Split(New String() {Chr(34) + "language" + Chr(34) + ":" + Chr(34) + SoftSubs2(i) + Chr(34) + "," + Chr(34) + "url" + Chr(34) + ":" + Chr(34)}, System.StringSplitOptions.RemoveEmptyEntries)
                Dim SoftSub_2 As String() = SoftSub(1).Split(New [Char]() {Chr(34)})
                Dim SoftSub_3 As String = SoftSub_2(0).Replace("\/", "/")
                Dim client0 As New WebClient
                client0.Encoding = Encoding.UTF8
                Dim str0 As String = client0.DownloadString(SoftSub_3)
                Dim Pfad3 As String = Pfad2.Replace(Chr(34), "")
                Dim FN As String = Path.ChangeExtension(Path.Combine(Path.GetFileNameWithoutExtension(Pfad3) + " " + SoftSubs2(i) + Path.GetExtension(Pfad3)), "ass")
                'MsgBox(FN)
                If i = 0 Then
                    FN = Path.ChangeExtension(Path.GetFileName(Pfad3), "ass")
                    'MsgBox(FN)
                End If
                Dim Pfad4 As String = Path.Combine(Path.GetDirectoryName(Pfad3), FN)
                'MsgBox(Pfad4)
                File.WriteAllText(Pfad4, str0, Encoding.UTF8)
                Pause(1)
            Next


        End If
#End Region

        DlSoftSubsRDY = True

        'Catch ex As Exception
        'End Try
    End Sub

    Public Async Sub MassSubsDL()
        If einstellungen.comboBox3.Text = Nothing Then
            Exit Sub
        ElseIf einstellungen.comboBox4.Text = Nothing Then
            Exit Sub
        End If
        einstellungen.SoftSubsMass.Text = "preparing ..."
        Dim Website As String = WebbrowserText

        If einstellungen.ComboBox2.Enabled = True Then
            Dim SeasonDropdownAnzahl As String() = Website.Split(New String() {"season-dropdown content-menu block"}, System.StringSplitOptions.RemoveEmptyEntries)
            Array.Reverse(SeasonDropdownAnzahl)
            Dim SDV As Integer = 0
            For i As Integer = 0 To SeasonDropdownAnzahl.Count - 1
                If InStr(SeasonDropdownAnzahl(i), Chr(34) + ">" + einstellungen.ComboBox2.SelectedItem.ToString + "</a>") Then
                    SDV = i
                End If
            Next
            Website = SeasonDropdownAnzahl(SDV)
        End If
        Try
            Dim Anzahl As String() = Website.Split(New String() {"wrapper container-shadow hover-classes"}, System.StringSplitOptions.RemoveEmptyEntries)
            Array.Reverse(Anzahl)
            Dim c As Integer = einstellungen.comboBox4.SelectedIndex - einstellungen.comboBox3.SelectedIndex + 1
            'AnzahlGesamt.Text = c.ToString
            Gesamt = c.ToString
            Aktuell = "0"
            If einstellungen.comboBox4.SelectedIndex > einstellungen.comboBox3.SelectedIndex Then

                For i As Integer = einstellungen.comboBox3.SelectedIndex To einstellungen.comboBox4.SelectedIndex

                    For e As Integer = 0 To Integer.MaxValue

                        If DlSoftSubsRDY = True Then
                            Exit For
                        Else
                            Await Task.Delay(2000)
                        End If
                    Next

                    Dim dd As Integer = i - einstellungen.comboBox3.SelectedIndex + 1
                    Dim URLGrapp As String() = Anzahl(i).Split(New String() {"<a href=" + Chr(34)}, System.StringSplitOptions.RemoveEmptyEntries)
                    Dim URLGrapp2 As String() = URLGrapp(1).Split(New String() {Chr(34)}, System.StringSplitOptions.RemoveEmptyEntries)
                    'MsgBox("https://www.crunchyroll.com" + URLGrapp2(0))
                    DlSoftSubsRDY = False
                    b = False
                    d = False
                    GeckoFX.WebBrowser1.Navigate("https://www.crunchyroll.com" + URLGrapp2(0))
                    Aktuell = dd.ToString
                    einstellungen.SoftSubsMass.Text = Aktuell + " / " + Gesamt
                Next



            End If
        Catch ex As Exception
            Anime_Add.comboBox4.Items.Clear()
            Anime_Add.comboBox3.Items.Clear()
            ' MsgBox(Error_Mass_DL, MsgBoxStyle.Information)
            'MsgBox(ex.ToString)
            Aktuell = 0.ToString
            Gesamt = 0.ToString

            Anime_Add.groupBox1.Visible = True
            Anime_Add.groupBox2.Visible = False
            Anime_Add.GroupBox3.Visible = False
            Anime_Add.Mass_DL_Cancel = False
            Anime_Add.pictureBox4.Image = My.Resources.main_button_download_default
        End Try
        Pause(5)
        Anime_Add.groupBox1.Visible = True
        Anime_Add.groupBox2.Visible = False
        Anime_Add.GroupBox3.Visible = False
        Anime_Add.Mass_DL_Cancel = False
        Anime_Add.pictureBox4.Image = My.Resources.main_button_download_default
    End Sub
#End Region

#Region "Sub to display"

    Public Function SubValuesToDisplay() As String
        Try
            Dim deDE As Boolean = False
            Dim enUS As Boolean = False
            Dim ptBR As Boolean = False
            Dim esLA As Boolean = False
            Dim frFR As Boolean = False
            Dim arME As Boolean = False
            Dim ruRU As Boolean = False
            Dim itIT As Boolean = False
            Dim esES As Boolean = False
            Dim ListReturn As String = Nothing
            For i As Integer = 0 To SoftSubs.Count - 1
                If SoftSubs(i) = "deDE" Then
                    deDE = True
                ElseIf SoftSubs(i) = "enUS" Then
                    enUS = True
                ElseIf SoftSubs(i) = "ptBR" Then
                    ptBR = True
                ElseIf SoftSubs(i) = "esLA" Then
                    esLA = True
                ElseIf SoftSubs(i) = "frFR" Then
                    frFR = True
                ElseIf SoftSubs(i) = "arME" Then
                    arME = True
                ElseIf SoftSubs(i) = "ruRU" Then
                    ruRU = True
                ElseIf SoftSubs(i) = "itIT" Then
                    itIT = True
                ElseIf SoftSubs(i) = "esES" Then
                    esES = True
                End If
            Next
            If deDE = True Then
                If ListReturn = Nothing Then
                    ListReturn = "Deutsch"
                Else
                    ListReturn = ListReturn + ", Deutsch"
                End If

            End If
            If enUS = True Then
                If ListReturn = Nothing Then
                    ListReturn = "English"
                Else
                    ListReturn = ListReturn + ", English"
                End If
            End If
            If esLA = True Then
                If ListReturn = Nothing Then
                    ListReturn = "Español (LA)"
                Else
                    ListReturn = ListReturn + ", Español (LA)"
                End If

            End If
            If ptBR = True Then
                If ListReturn = Nothing Then
                    ListReturn = "Português (Brasil)"
                Else
                    ListReturn = ListReturn + ", Português (Brasil)"
                End If

            End If
            If frFR = True Then
                If ListReturn = Nothing Then
                    ListReturn = "Français (France)"
                Else
                    ListReturn = ListReturn + ", Français (France)"
                End If
            End If
            If arME = True Then
                If ListReturn = Nothing Then
                    ListReturn = "العربية (Arabic)"
                Else
                    ListReturn = ListReturn + ", العربية (Arabic)"
                End If
            End If
            If ruRU = True Then
                If ListReturn = Nothing Then
                    ListReturn = "Русский (Russian)"
                Else
                    ListReturn = ListReturn + ", Русский (Russian)"
                End If
            End If
            If itIT = True Then
                If ListReturn = Nothing Then
                    ListReturn = "Italiano (Italian)"
                Else
                    ListReturn = ListReturn + ", Italiano (Italian)"
                End If

            End If
            If esES = True Then
                If ListReturn = Nothing Then
                    ListReturn = "Español (España)"
                Else
                    ListReturn = ListReturn + ", Español (España)"
                End If
            End If

            Return ListReturn

        Catch ex As Exception
            Return Nothing
        End Try

    End Function


    Public Function HardSubValuesToDisplay(ByVal HardSub As String) As String
        Try
            If HardSub = Chr(34) + "deDE" + Chr(34) Then
                Return "Deutsch"
            ElseIf HardSub = Chr(34) + "enUS" + Chr(34) Then
                Return "English"
            ElseIf HardSub = Chr(34) + "ptBR" + Chr(34) Then
                Return "Português (Brasil)"
            ElseIf HardSub = Chr(34) + "esLA" + Chr(34) Then
                Return "Español (LA)"
            ElseIf HardSub = Chr(34) + "frFR" + Chr(34) Then
                Return "Français (France)"
            ElseIf HardSub = Chr(34) + "arME" + Chr(34) Then
                Return "العربية (Arabic)"
            ElseIf HardSub = Chr(34) + "ruRU" + Chr(34) Then
                Return "Русский (Russian)"
            ElseIf HardSub = Chr(34) + "itIT" + Chr(34) Then
                Return "Italiano (Italian)"
            ElseIf HardSub = Chr(34) + "esES" + Chr(34) Then
                Return "Español (España)"
            End If

            Return CB_SuB_Nothing

        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Function CCtoMP4CC(ByVal HardSub As String) As String
        Try
            If HardSub = "deDE" Then
                Return "ger"
            ElseIf HardSub = "enUS" Then
                Return "eng"
            ElseIf HardSub = "ptBR" Then
                Return "por"
            ElseIf HardSub = "esLA" Then
                Return "spa"
            ElseIf HardSub = "frFR" Then
                Return "fre"
            ElseIf HardSub = "arME" Then
                Return "ara"
            ElseIf HardSub = "ruRU" Then
                Return "rus"
            ElseIf HardSub = "itIT" Then
                Return "ita"
            ElseIf HardSub = "esES" Then
                Return "spa"
            End If

            Return "chi"

        Catch ex As Exception
            Return Nothing
        End Try

    End Function

#End Region

    Public Sub GrappURL()

        Try
            'Throw New System.Exception("Test")
            Grapp_RDY = False
            Dim CR_Anime_Titel As String = Nothing
            Dim CR_Anime_Staffel As String = Nothing
            Dim CR_Anime_Folge As String = Nothing
#Region "Name + Pfad"
            Dim Pfad2 As String
            Dim TextBox2_Text As String = Nothing
            Dim CR_FilenName As String = Nothing
            Dim SubfolderValue As String = Nothing
            Dim CR_FilenName_Backup As String = Nothing

            Me.Invoke(New Action(Function()
                                     TextBox2_Text = Anime_Add.textBox2.Text
                                     Return Nothing
                                 End Function))
#Region "Name von Crunchyroll"
            If TextBox2_Text = Nothing Or TextBox2_Text = "Name of the Anime" Then
                'MsgBox("True")
                'Dim Bug_Deutsch As String = "-"
                'If CBool(InStr(WebbrowserTitle, "Anschauen auf Crunchyroll")) Then
                '    Bug_Deutsch = ":"
                'End If
                'Dim CR_Name_by_Titel_2 As String() = WebbrowserTitle.Split(New String() {Bug_Deutsch}, System.StringSplitOptions.RemoveEmptyEntries)
                'CR_FilenName = CR_Name_by_Titel_2(0).Trim() '+ " " + CR_Name_by_Script2(0).Trim

                Dim Bug_Deutsch As String = "-"
                If CBool(InStr(WebbrowserTitle, "Anschauen auf Crunchyroll")) Then
                    Bug_Deutsch = ":"
                End If
                Dim CR_Name_by_Titel_2 As String() = WebbrowserTitle.Split(New String() {Bug_Deutsch}, System.StringSplitOptions.RemoveEmptyEntries)
                Dim CR_Title As String = Nothing
                If CR_Name_by_Titel_2.Count > 2 Then
                    For i As Integer = 0 To CR_Name_by_Titel_2.Count - 2
                        If CR_Title = Nothing Then
                            CR_Title = CR_Name_by_Titel_2(i).Trim()
                        Else
                            CR_Title = CR_Title + " " + CR_Name_by_Titel_2(i).Trim()
                        End If

                    Next
                End If
                CR_FilenName = CR_Title
                CR_FilenName_Backup = CR_Title
                'MsgBox(CR_FilenName)

                If CBool(InStr(WebbrowserText, "<h4>")) Then ' false on movie true on series
                    Dim CR_Name_1 As String() = WebbrowserText.Split(New String() {"<h4>"}, System.StringSplitOptions.RemoveEmptyEntries)
                    Dim CR_Name_2 As String() = CR_Name_1(1).Split(New String() {"</h4>"}, System.StringSplitOptions.RemoveEmptyEntries) '(New [Char]() {"-"})
                    Dim CR_Name_Staffel0_Folge1 As String()
                    If CBool(InStr(CR_Name_2(0), ",")) Then
                        CR_Name_Staffel0_Folge1 = CR_Name_2(0).Split(New [Char]() {System.Convert.ToChar(",")}, System.StringSplitOptions.RemoveEmptyEntries)
                        CR_Anime_Staffel = CR_Name_Staffel0_Folge1(0).Trim()
                        CR_Anime_Folge = CR_Name_Staffel0_Folge1(1).Trim()
                        CR_Anime_Folge = System.Text.RegularExpressions.Regex.Replace(CR_Anime_Folge, "[^\w\\-]", " ")
                    Else
                        CR_Anime_Staffel = Nothing
                        CR_Anime_Folge = CR_Name_2(0).Trim()
                        CR_Anime_Folge = System.Text.RegularExpressions.Regex.Replace(CR_Anime_Folge, "[^\w\\-]", " ")
                    End If


                    Dim CR_Name_4 As String() = CR_Name_1(0).Split(New String() {"class=" + Chr(34) + "text-link" + Chr(34) + ">"}, System.StringSplitOptions.RemoveEmptyEntries) '(New [Char]() {"-"})
                    Dim CR_Name_Anime0 As String() = CR_Name_4(CR_Name_4.Length - 1).Split(New String() {"</a>"}, System.StringSplitOptions.RemoveEmptyEntries)
                    CR_Name_Anime0(0) = System.Text.RegularExpressions.Regex.Replace(CR_Name_Anime0(0), "[^\w\\-]", " ")
                    CR_Anime_Titel = CR_Name_Anime0(0).Trim
                    If CR_Anime_Staffel = Nothing Then
                        CR_FilenName = CR_Anime_Titel + " " + CR_Anime_Folge
                    Else
                        CR_FilenName = CR_Anime_Titel + " " + CR_Anime_Staffel + " " + CR_Anime_Folge
                    End If

                    CR_FilenName_Backup = RemoveExtraSpaces(CR_FilenName)


                End If
#End Region

            Else
                Me.Invoke(New Action(Function()
                                         If Anime_Add.ComboBox2.Text = SubFolder_automatic Then
                                             MsgBox(SubFolder_automatic + " is not working with a costum name", MsgBoxStyle.Information)
                                         ElseIf Anime_Add.ComboBox2.Text = SubFolder_Nothing Then
                                         Else
                                             SubfolderValue = Anime_Add.ComboBox2.Text + "\"
                                         End If
                                         Return Nothing
                                     End Function))
                'MsgBox(TextBox2_Text)
                CR_FilenName = RemoveExtraSpaces(System.Text.RegularExpressions.Regex.Replace(TextBox2_Text, "[^\w\\-]", " "))
                CR_FilenName_Backup = CR_FilenName
            End If
            Me.Invoke(New Action(Function()
                                     If Anime_Add.ComboBox2.Text = SubFolder_automatic Then
                                         If SubFolder = 2 Then
                                             SubfolderValue = CR_Anime_Titel + "\" + CR_Anime_Staffel + "\"
                                         ElseIf SubFolder = 1 Then
                                             SubfolderValue = CR_Anime_Titel + "\"
                                         End If
                                     ElseIf Anime_Add.ComboBox2.Text = SubFolder_Nothing Then
                                     Else
                                         SubfolderValue = Anime_Add.ComboBox2.Text + "\"
                                     End If
                                     Return Nothing
                                 End Function))
            'MsgBox(CR_FilenName)
            CR_FilenName = System.Text.RegularExpressions.Regex.Replace(CR_FilenName, "[^\w\\-]", " ")
            CR_FilenName = RemoveExtraSpaces(CR_FilenName)
            If SubfolderValue = Nothing Then
                Pfad2 = Pfad + "\" + CR_FilenName + ".mp4"
            Else
                Pfad2 = Pfad + "\" + SubfolderValue + CR_FilenName + ".mp4"
            End If
            If Not Directory.Exists(Path.GetDirectoryName(Pfad2)) Then
                ' Nein! Jetzt erstellen...
                Try
                    Directory.CreateDirectory(Path.GetDirectoryName(Pfad2))
                Catch ex As Exception
                    ' Ordner wurde nich erstellt
                    Pfad2 = Pfad + "\" + CR_FilenName_Backup + ".mp4"
                End Try
            End If
            Pfad2 = Chr(34) + Pfad2 + Chr(34)

#End Region
#Region "Subs"
            Dim SoftSubs2 As New List(Of String)
            If SoftSubs.Count > 0 Then
                For i As Integer = 0 To SoftSubs.Count - 1
                    If CBool(InStr(WebbrowserText, Chr(34) + "language" + Chr(34) + ":" + Chr(34) + SoftSubs(i) + Chr(34) + ",")) Then
                        SoftSubs2.Add(SoftSubs(i))
                    Else
                        'MsgBox("Softsubtitle for " + SoftSubs(i) + " is not avalible.", MsgBoxStyle.Information)
                    End If
                Next

            End If
            If SubSprache = "None" Then
                If CBool(InStr(WebbrowserText, Chr(34) + "hardsub_lang" + Chr(34) + ":null")) Then
                    SubSprache2 = "null"
                Else
                    Me.Invoke(New Action(Function()
                                             ResoNotFoundString = WebbrowserText
                                             DialogTaskString = "Language"
                                             Reso.ShowDialog()
                                             Return Nothing
                                         End Function))
                    If UserCloseDialog = True Then
                        Throw New System.Exception(Chr(34) + "UserAbort" + Chr(34))
                    Else
                        If ResoBackString = Nothing Then
                        Else
                            SubSprache2 = ResoBackString
                        End If
                    End If
                    'Throw New System.Exception("Could not find the sub language")
                End If


            Else
                If CBool(InStr(WebbrowserText, Chr(34) + "hardsub_lang" + Chr(34) + ":" + Chr(34) + SubSprache + Chr(34) + ",")) Then
                    SubSprache2 = Chr(34) + SubSprache + Chr(34)

                ElseIf CBool(InStr(WebbrowserText, Chr(34) + "language" + Chr(34) + ":" + Chr(34) + SubSprache + Chr(34) + ",")) Then
                    If MessageBox.Show("It look like only Softsubtitle are avalibe." + vbNewLine + "Are you want to use Softsubtitle this time instead?", "No Hardsubtitle", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                        SubSprache2 = "null"
                        SoftSubs2.Add(SubSprache)
                    Else
                        Throw New System.Exception("Could not find the sub language")
                    End If


                Else
                    Me.Invoke(New Action(Function()
                                             ResoNotFoundString = WebbrowserText
                                             DialogTaskString = "Language"
                                             Reso.ShowDialog()
                                             Return Nothing
                                         End Function))
                    If UserCloseDialog = True Then
                        Throw New System.Exception(Chr(34) + "UserAbort" + Chr(34))
                    Else
                        If ResoBackString = Nothing Then
                        Else
                            SubSprache2 = ResoBackString
                        End If
                    End If
                End If
            End If


#End Region
            If Grapp_Abord = True Then
                Grapp_RDY = True
                Grapp_Abord = False
                'MsgBox("grapp_abourd")
                Exit Sub

            End If
#Region "m3u8 suche"
            Dim ii As Integer = 0
            'MsgBox(Chr(34) + "hardsub_lang" + Chr(34) + ":" + SubSprache2 + "," + Chr(34) + "url" + Chr(34) + ":" + Chr(34))
            Dim CR_URI_Master As String = Nothing
            Dim CR_URI_Master_Split1 As String() = WebbrowserText.Split(New String() {My.Resources.hls_Value}, System.StringSplitOptions.RemoveEmptyEntries)
            Dim hls_List As New List(Of String)
            For i As Integer = 0 To CR_URI_Master_Split1.Count - 1
                If InStr(CR_URI_Master_Split1(i), My.Resources.hls_endString) Then
                    Dim s As String() = CR_URI_Master_Split1(i).Split(New String() {My.Resources.hls_endString}, System.StringSplitOptions.RemoveEmptyEntries)
                    hls_List.Add(s(0))
                End If
            Next
            'Dim CR_URI_Master_Split1 As String() = WebbrowserText.Split(New String() {Chr(34) + "hardsub_lang" + Chr(34) + ":" + SubSprache2 + "," + Chr(34) + "url" + Chr(34) + ":" + Chr(34)}, System.StringSplitOptions.RemoveEmptyEntries)

            For i As Integer = 0 To hls_List.Count - 1
                If InStr(hls_List(i), Chr(34) + "hardsub_lang" + Chr(34) + ":" + SubSprache2 + "," + Chr(34) + "url" + Chr(34) + ":" + Chr(34)) Then

                    Dim s() As String = hls_List(i).Split(New String() {Chr(34) + "hardsub_lang" + Chr(34) + ":" + SubSprache2 + "," + Chr(34) + "url" + Chr(34) + ":" + Chr(34)}, System.StringSplitOptions.RemoveEmptyEntries)
                    CR_URI_Master = s(1).Replace("\/", "/")
                    'MsgBox(CR_URI_Master)
                End If
            Next
            If CBool(InStr(CR_URI_Master, "master.m3u8")) Then
                Me.Invoke(New Action(Function()
                                         Anime_Add.StatusLabel.Text = "Status: m3u8 found, looking for resolution"
                                         Return Nothing
                                     End Function))
            Else
                Throw New System.Exception("Premium Episode")
            End If
#End Region

#Region "Download softsub file or build ffmpeg cmd"
            Dim SoftSubMergeURLs As String = Nothing
            Dim SoftSubMergeMaps As String = " -map 0:v -map 0:a"
            Dim SoftSubMergeMetatata As String = Nothing

            If SoftSubs2.Count > 0 Then
                If MergeSubstoMP4 = True Then
                    For i As Integer = 0 To SoftSubs2.Count - 1
                        Dim SoftSub As String() = WebbrowserText.Split(New String() {Chr(34) + "language" + Chr(34) + ":" + Chr(34) + SoftSubs2(i) + Chr(34) + "," + Chr(34) + "url" + Chr(34) + ":" + Chr(34)}, System.StringSplitOptions.RemoveEmptyEntries)
                        Dim SoftSub_2 As String() = SoftSub(1).Split(New [Char]() {Chr(34)})
                        Dim SoftSub_3 As String = SoftSub_2(0).Replace("\/", "/")
                        If SoftSubMergeURLs = Nothing Then
                            SoftSubMergeURLs = " -i " + Chr(34) + SoftSub_3 + Chr(34)
                        Else
                            SoftSubMergeURLs = SoftSubMergeURLs + " -i " + Chr(34) + SoftSub_3 + Chr(34)
                        End If
                        SoftSubMergeMaps = SoftSubMergeMaps + " -map " + (i + 1).ToString
                        If SoftSubMergeMetatata = Nothing Then
                            SoftSubMergeMetatata = " -metadata:s:s:" + i.ToString + " language=" + CCtoMP4CC(SoftSubs2(i))
                        Else
                            SoftSubMergeMetatata = SoftSubMergeMetatata + " -metadata:s:s:" + i.ToString + " language=" + CCtoMP4CC(SoftSubs2(i))
                        End If

                    Next

                Else
                    For i As Integer = 0 To SoftSubs2.Count - 1
                        LabelUpdate = "Status: downloading subtitle file"
                        LabelEpisode = SoftSubs2(i)
                        Dim SoftSub As String() = WebbrowserText.Split(New String() {Chr(34) + "language" + Chr(34) + ":" + Chr(34) + SoftSubs2(i) + Chr(34) + "," + Chr(34) + "url" + Chr(34) + ":" + Chr(34)}, System.StringSplitOptions.RemoveEmptyEntries)
                        Dim SoftSub_2 As String() = SoftSub(1).Split(New [Char]() {Chr(34)})
                        Dim SoftSub_3 As String = SoftSub_2(0).Replace("\/", "/")
                        Dim client0 As New WebClient
                        client0.Encoding = Encoding.UTF8
                        Dim str0 As String = client0.DownloadString(SoftSub_3)
                        Dim Pfad3 As String = Pfad2.Replace(Chr(34), "")
                        Dim FN As String = Path.ChangeExtension(Path.Combine(Path.GetFileNameWithoutExtension(Pfad3) + " " + SoftSubs2(i) + Path.GetExtension(Pfad3)), "ass")
                        'MsgBox(FN)
                        If i = 0 Then
                            FN = Path.ChangeExtension(Path.GetFileName(Pfad3), "ass")
                            'MsgBox(FN)
                        End If
                        Dim Pfad4 As String = Path.Combine(Path.GetDirectoryName(Pfad3), FN)
                        'MsgBox(Pfad4)
                        File.WriteAllText(Pfad4, str0, Encoding.UTF8)
                        Pause(1)
                    Next

                End If
            End If
#End Region

#Region "lösche doppel download"

            Dim Pfad5 As String = Pfad2.Replace(Chr(34), "")
            If My.Computer.FileSystem.FileExists(Pfad5) Then 'Pfad = Kompeltter Pfad mit Dateinamen + ENdung
                If MessageBox.Show("The file " + Pfad5 + " already exists." + vbNewLine + "You want to override it?", "File exists!", MessageBoxButtons.OKCancel) = DialogResult.OK Then
                    Try
                        My.Computer.FileSystem.DeleteFile(Pfad5)
                    Catch ex As Exception
                    End Try
                Else
                    Grapp_RDY = True
                    Exit Sub
                End If

            End If
#End Region
            If Resu = 42 Then
                If MergeSubstoMP4 = True Then
                    URL_DL = "-i " + Chr(34) + CR_URI_Master + Chr(34) + SoftSubMergeURLs + SoftSubMergeMaps + " " + ffmpeg_command + " -c:s mov_text" + SoftSubMergeMetatata
                Else
                    URL_DL = CR_URI_Master
                End If
                'MsgBox(URL_DL)
            Else


                Dim client As New System.Net.WebClient
                client.Encoding = Encoding.UTF8
                'MsgBox(CR_URI_Master)
                Dim str As String = client.DownloadString(CR_URI_Master)
                'MsgBox(str)

                If CBool(InStr(str, "x" + Resu.ToString + ",")) Then
                    Resu2 = "x" + Resu.ToString
                Else
                    'MsgBox(str)
                    If CBool(InStr(str, ResuSave + ",")) Then
                        Resu2 = Resu2
                    Else
                        Me.Invoke(New Action(Function()
                                                 DialogTaskString = "Resolution"
                                                 ResoNotFoundString = str
                                                 Reso.ShowDialog()
                                                 Return Nothing
                                             End Function))


                        'MsgBox(ResoBackString)
                        If UserCloseDialog = True Then
                            Throw New System.Exception(Chr(34) + "UserAbort" + Chr(34))
                        Else
                            Resu2 = ResoBackString
                        End If
                    End If
                End If
                'MsgBox(Resu2)
                Dim VLC_URI_1 As String() = str.Split(New String() {Resu2 + ","}, System.StringSplitOptions.RemoveEmptyEntries)
                Dim VLC_URI_2 As String() = VLC_URI_1(1).Split(New [Char]() {Chr(34)})
                Dim VLC_URI_3 As String() = VLC_URI_2(2).Split(New [Char]() {System.Convert.ToChar("#")})
                If MergeSubstoMP4 = True Then
                    URL_DL = "-i " + Chr(34) + VLC_URI_3(0).Trim() + Chr(34) + SoftSubMergeURLs + SoftSubMergeMaps + " " + ffmpeg_command + " -c:s mov_text" + SoftSubMergeMetatata
                Else
                    URL_DL = VLC_URI_3(0).Trim()
                End If
                'MsgBox(URL_DL)
            End If
#Region "thumbnail"
            Dim thumbnail As String() = WebbrowserText.Split(New String() {My.Resources.thumbnailString}, System.StringSplitOptions.RemoveEmptyEntries)
            Dim thumbnail2 As String() = thumbnail(1).Split(New String() {Chr(34) + "}"}, System.StringSplitOptions.RemoveEmptyEntries) '(New [Char]() {"-"})
            Dim thumbnail3 As String = thumbnail2(0).Replace("\/", "/")
#End Region
#Region "<li> constructor"
            Dim Subsprache3 As String = HardSubValuesToDisplay(SubSprache2)
            Dim ResoHTMLDisplay As String = Nothing
            If ResoBackString = Nothing Then
                ResoHTMLDisplay = Resu.ToString + "p"
            ElseIf DialogTaskString = "Language" Then
                ResoHTMLDisplay = Resu.ToString + "p"
            Else
                Dim ResoHTML As String() = ResoBackString.Split(New String() {"x"}, System.StringSplitOptions.RemoveEmptyEntries)
                If ResoHTML.Count > 1 Then
                    ResoHTMLDisplay = ResoHTML(1) + "p"

                Else
                    ResoHTMLDisplay = ResoHTML(0) + "p"
                End If
            End If
            Dim L2Name As String = CR_FilenName_Backup
            If Resu = 42 Then
                ResoHTMLDisplay = "[Auto]"
            End If
            Pfad_DL = Pfad2
            Dim L1Name_Split As String() = WebbrowserURL.Split(New String() {"/"}, System.StringSplitOptions.RemoveEmptyEntries)
            Dim L1Name As String = L1Name_Split(1).Replace("www.", "")
            Me.Invoke(New Action(Function()
                                     ListAdd(Pfad_DL, L1Name, L2Name, ResoHTMLDisplay, Subsprache3, SubValuesToDisplay(), thumbnail3)
                                     Return Nothing
                                 End Function))
#End Region

            AsyncWorkerX.RunAsync(AddressOf DownloadFFMPEG, URL_DL, Pfad_DL, Pfad_DL)
            Grapp_RDY = True
            Me.Invoke(New Action(Function()

                                     Anime_Add.StatusLabel.Text = "Status: idle"
                                     Return Nothing
                                 End Function))
        Catch ex As Exception
            Me.Invoke(New Action(Function()

                                     Anime_Add.StatusLabel.Text = "Status: idle"
                                     Return Nothing
                                 End Function))
            Grapp_RDY = True

            If CBool(InStr(ex.ToString, "Could not find the sub language")) Then
                MsgBox(Sub_language_NotFound + SubSprache)
            ElseIf CBool(InStr(ex.ToString, "RESOLUTION Not Found")) Then
                MsgBox(Resolution_NotFound)
            ElseIf CBool(InStr(ex.ToString, "Premium Episode")) Then
                MsgBox(Premium_Stream, MsgBoxStyle.Information)
            ElseIf CBool(InStr(ex.ToString, "System.UnauthorizedAccessException")) Then
                MsgBox(ErrorNoPermisson + vbNewLine + ex.ToString, MsgBoxStyle.Information)
            ElseIf CBool(InStr(ex.ToString, Chr(34) + "UserAbort" + Chr(34))) Then
                MsgBox(ex.ToString, MsgBoxStyle.Information)
            Else
                If MessageBox.Show(Error_unknown, "Error!", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                    Dim CCC As String() = WebbrowserText.Split(New String() {My.Resources.CC_String}, System.StringSplitOptions.RemoveEmptyEntries)
                    Dim CCC1 As String() = CCC(1).Split(New String() {".gif" + Chr(34)}, System.StringSplitOptions.RemoveEmptyEntries)

                    Dim SaveString As String = "Operating System: " + My.Computer.Info.OSFullName + vbNewLine + vbNewLine + "Crunchyroll URL: " + WebbrowserURL + vbNewLine + vbNewLine + "subtitle language: " + SubSprache + vbNewLine + vbNewLine + "video resolution: " + Resu.ToString + vbNewLine + vbNewLine + "error message: " + ex.ToString + vbNewLine + ex.StackTrace.ToString + vbNewLine + vbNewLine + "softsubs enabled?: " + SoftSubs.ToString + vbNewLine + vbNewLine + "Crunchyroll Downloader Version: " + Application.ProductVersion + vbNewLine + vbNewLine + "detected location from Crunchyroll: " + CCC1(0)

                    File.WriteAllText("Error " + DateTime.Now.ToString("dd.MM.yyyy HH.mm") + ".txt", SaveString)
                    Dim Request As HttpWebRequest = CType(WebRequest.Create("https://docs.google.com/forms/d/e/1FAIpQLSdR1QI19Lh-c-XO_iXNkDwsTUZhCMEu84boQkgW5AOBUxyiyA/formResponse"), HttpWebRequest)
                    Request.Method = "POST"
                    Request.ContentType = "application/x-www-form-urlencoded"
                    Dim Post As String = "entry.240217066=" + My.Computer.Info.OSFullName + "&entry.358200455=" + WebbrowserURL + "&entry.618751432=" + SubSprache + "&entry.924054550=" + Resu.ToString + "&entry.679000538=" + ex.ToString + "&entry.1789515979=" + SoftSubsString + "&entry.683247287=" + Application.ProductVersion + "&entry.377264428=" + CCC1(0) + "&fvv=1&draftResponse=[null,null," + Chr(34) + "-3005021683493723280" + Chr(34) + "] &pageHistory=0&fbzx=-3005021683493723280"
                    Dim byteArray() As Byte = Encoding.UTF8.GetBytes(Post)
                    Request.ContentLength = byteArray.Length
                    Dim DataStream As Stream = Request.GetRequestStream()
                    DataStream.Write(byteArray, 0, byteArray.Length)
                    DataStream.Close()
                    Dim Response As HttpWebResponse = Request.GetResponse()
                    DataStream = Response.GetResponseStream()
                    Dim reader As New StreamReader(DataStream)
                    Dim ServerResponse As String = reader.ReadToEnd()
                    reader.Close()
                    DataStream.Close()
                    Response.Close()
                    Dim Version_Check As String() = ServerResponse.Split(New String() {"<div class=" + Chr(34) + "freebirdFormviewerViewResponseConfirmationMessage" + Chr(34) + ">"}, System.StringSplitOptions.RemoveEmptyEntries)
                    Dim Version_Check2 As String() = Version_Check(1).Split(New String() {"</div>"}, System.StringSplitOptions.RemoveEmptyEntries)
                    'If Application.ProductVersion = Version_Check2(0) Then
                    'Else
                    'MsgBox("A newer version is available: v" + Version_Check2(0))
                    'End If
                End If
            End If

        End Try
    End Sub

    Public Sub RemoveFinishedTask()
        'Try
        '    Dim FinishedTask As Integer = 0
        '    For i As Integer = 0 To PR_List.Count - 1
        '        If PR_List.Item(i).HasExited = True Then
        '            FinishedTask = FinishedTask + 1
        '        End If
        '    Next
        '    For ii As Integer = 0 To FinishedTask
        '        For i As Integer = 0 To PR_List.Count - 1
        '            If PR_List.Item(i).HasExited = True Then
        '               
        '                Exit For
        '            End If
        '        Next
        '    Next
        'Catch ex As Exception

        'End Try
        Try

            For i As Integer = 0 To PR_List.Count - 1
                If PR_List.Item(i).HasExited = True Then
                    Dim p As Process = PR_List.Item(i)
                    Dim c As String = p.StartInfo.Arguments
                    Dim FolderName() As String = c.Split(New String() {"index"}, System.StringSplitOptions.RemoveEmptyEntries)
                    Dim FolderName2() As String = FolderName(1).Split(New String() {".m3u8"}, System.StringSplitOptions.RemoveEmptyEntries)
                    Dim FolderName3 As String = FolderName2(0)
                    Dim Pfad2 As String = Application.StartupPath + "\" + FolderName3 + "\"
                    If Directory.Exists(Path.GetDirectoryName(Pfad2)) Then
                        Try
                            Directory.Delete(Path.GetDirectoryName(Pfad2), True)
                            File.Delete(Application.StartupPath + "\" + "index" + FolderName3 + ".m3u8")
                        Catch ex As Exception
                            MsgBox(ex.ToString)
                        End Try
                    End If
                    PR_List.Remove(PR_List.Item(i))
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub tsDownloadAsync(ByVal DL_URL As String, ByVal DL_Pfad As String)
        Dim wc_ts As New WebClient
        wc_ts.DownloadFile(New Uri(DL_URL), DL_Pfad)

    End Sub
    Private Function tsStatusAsync(ByVal prozent As Integer, ByVal di As IO.DirectoryInfo, ByVal Filename As String, ByVal pausetime As Integer)
        Dim Now As Date = Date.Now

        Dim FinishedSize As Double = 0
        Dim AproxFinalSize As Double = 0

        Try

            Dim aryFi As IO.FileInfo() = di.GetFiles("*.ts")
            Dim fi As IO.FileInfo
            For Each fi In aryFi
                FinishedSize = FinishedSize + Math.Round(fi.Length / 1048576, 2, MidpointRounding.AwayFromZero).ToString()
            Next
        Catch ex As Exception
        End Try
        'Thread.Sleep(1000)
        'Pause(1)

        If prozent > 0 Then
            AproxFinalSize = Math.Round(FinishedSize * 100 / prozent, 2, MidpointRounding.AwayFromZero).ToString() ' Math.Round( / 1048576, 2, MidpointRounding.AwayFromZero).ToString()
        End If
        Dim duration As TimeSpan = Date.Now - di.CreationTime
        Dim TimeinSeconds As Integer = duration.Hours * 3600 + duration.Minutes * 60 + duration.Seconds
        TimeinSeconds = TimeinSeconds - pausetime
        Dim DataRate As Double = FinishedSize / TimeinSeconds
        Dim DataRateString As String = Math.Round(DataRate, 2, MidpointRounding.AwayFromZero).ToString()
        If prozent > 100 Then
            prozent = 100
        End If
        RaiseEvent UpdateUI(Filename, prozent, FinishedSize, AproxFinalSize, Color.FromArgb(247, 140, 37), DataRateString + "MB\s")

        Return Nothing
    End Function


    Private Function DownloadFFMPEG(ByVal DL_URL As String, ByVal DL_Pfad As String, ByVal Filename As String) As String

        Dim client0 As New WebClient
        client0.Encoding = Encoding.UTF8
        Dim text As String = client0.DownloadString(DL_URL)
        Dim textLenght() As String = text.Split(New String() {vbLf}, System.StringSplitOptions.RemoveEmptyEntries)
        Dim Fragments() As String = text.Split(New String() {"https:"}, System.StringSplitOptions.RemoveEmptyEntries)
        Dim FragmentsInt As Integer = Fragments.Count - 2
        Dim nummerint As Integer = -1
        Dim m3u8FFmpeg As String = Nothing
        Dim ts_dl As String = Nothing
        Dim Folder As String = einstellungen.GeräteID()
        Dim Pfad2 As String = Application.StartupPath + "\" + Folder + "\"
        Dim PauseTime As Integer = 0
        If Not Directory.Exists(Path.GetDirectoryName(Pfad2)) Then
            ' Nein! Jetzt erstellen...
            Try
                Directory.CreateDirectory(Path.GetDirectoryName(Pfad2))
            Catch ex As Exception
                ' Ordner wurde nich erstellt
                'Pfad2 = Pfad + "\" + CR_FilenName_Backup + ".mp4"
            End Try
        End If
        Dim di As New IO.DirectoryInfo(Pfad2)
        For i As Integer = 0 To textLenght.Length - 1

            If InStr(textLenght(i), "https") Then
                If nummerint > -1 Then
                    'MsgBox(" " + DL_Pfad)
                    For w As Integer = 0 To Integer.MaxValue

                        If PauseList.Contains(" " + DL_Pfad) Then
                            'MsgBox(True.ToString)
                            Thread.Sleep(5000)
                            PauseTime = PauseTime + 5
                        ElseIf ThreadList.Count > 7 Then
                            Thread.Sleep(250)
                        Else
                            'Thread.Sleep(250)
                            Exit For
                        End If
                    Next
                    'dl1
                    nummerint = nummerint + 1
                    Dim nummer4D As String = String.Format("{0:0000}", nummerint)
                    Dim i2weilsVSsowill As Integer = i
                    Dim Evaluator = New Thread(Sub() Me.tsDownloadAsync(textLenght(i2weilsVSsowill), Pfad2 + nummer4D + ".ts"))
                    Evaluator.Start()
                    ThreadList.Add(Evaluator)
                    m3u8FFmpeg = m3u8FFmpeg + Pfad2 + nummer4D + ".ts" + vbLf
                    Dim FragmentsFinised = (ThreadList.Count + nummerint) / FragmentsInt * 100
                    'Dim status = New Thread(Sub() Me.tsStatusAsync(FragmentsFinised, di, Filename))
                    'status.Start()
                    tsStatusAsync(FragmentsFinised, di, Filename, PauseTime)
                Else
                    m3u8FFmpeg = m3u8FFmpeg + textLenght(i) + vbLf
                    nummerint = 0
                End If
            ElseIf textLenght(i) = "#EXT-X-PLAYLIST-TYPE:VOD" Then

            Else
                m3u8FFmpeg = m3u8FFmpeg + textLenght(i) + vbLf
            End If
        Next
        Dim utf8WithoutBom As New System.Text.UTF8Encoding(False)
        Using sink As New StreamWriter("index" + Folder + ".m3u8", False, utf8WithoutBom)
            sink.WriteLine(m3u8FFmpeg)
        End Using
        tsStatusAsync(100, di, Filename, PauseTime)
        URL_DL = "index" + Folder + ".m3u8"
        Dim proc As New Process
        Dim exepath As String = Application.StartupPath + "\ffmpeg.exe"
        Dim startinfo As New System.Diagnostics.ProcessStartInfo
        'Dim cmd As String = "-i " + Chr(34) + URL_DL + Chr(34) + " -c copy -bsf:a aac_adtstoasc " + Pfad_DL 'start ffmpeg with command strFFCMD string
        '-loglevel repeat+level+debug" + " 
        Dim cmd As String = "-protocol_whitelist file,crypto,http,https,tcp,tls -i " + Chr(34) + URL_DL + Chr(34) + " " + ffmpeg_command + " " + DL_Pfad 'start ffmpeg with command strFFCMD string
        'MsgBox(cmd)

        If MergeSubstoMP4 = True Then
            If CBool(InStr(DL_URL, "-i " + Chr(34))) = True Then
                cmd = DL_URL + " " + DL_Pfad
            End If
        End If
        If UsedMap = Nothing Then
        Else
            '"-loglevel repeat+level+debug" + " 
            cmd = "-i " + Chr(34) + URL_DL + Chr(34) + " -map 0:a " + "-map " + UsedMap + " " + ffmpeg_command + " " + DL_Pfad
            UsedMap = Nothing
        End If
        If Debug2 = True Then
            MsgBox(cmd)
        End If


        'all parameters required to run the process
        startinfo.FileName = exepath
        startinfo.Arguments = cmd
        startinfo.UseShellExecute = False
        startinfo.WindowStyle = ProcessWindowStyle.Normal
        startinfo.RedirectStandardError = True
        'startinfo.RedirectStandardInput = True
        startinfo.RedirectStandardOutput = True
        startinfo.CreateNoWindow = True
        AddHandler proc.ErrorDataReceived, AddressOf TestOutput
        AddHandler proc.OutputDataReceived, AddressOf TestOutput
        proc.StartInfo = startinfo
        PR_List.Add(proc)
        proc.Start() ' start the process
        proc.BeginOutputReadLine()
        proc.BeginErrorReadLine()
        'proc.WaitForExit()
        Return Nothing
    End Function


    Sub TestOutput(ByVal sender As Object, ByVal e As DataReceivedEventArgs)
        Try
            Dim pr As Process = sender
            Dim FileNameSplit As String() = pr.StartInfo.Arguments.ToString().Split(New String() {Chr(34)}, System.StringSplitOptions.RemoveEmptyEntries)
            Dim FileName As String = Chr(34) + FileNameSplit(FileNameSplit.Count - 1) + Chr(34)
            Dim logfile As String = FileName.Replace(".mp4", ".log").Replace(Chr(34), "")
            If SaveLog = True Then
                If File.Exists(logfile) Then
                    Using sw As StreamWriter = File.AppendText(logfile)
                        sw.Write(vbNewLine)
                        sw.Write(Date.Now + e.Data)
                    End Using
                Else
                    File.WriteAllText(logfile, Date.Now + e.Data)
                End If
            End If
            'MsgBox(FileName)
            'If CBool(InStr(e.Data, "[Parsed_cropdetect_0")) And CBool(InStr(e.Data, "crop=")) = True Then
            '    If Debug2 = True Then
            '        MsgBox(True.ToString)
            '    End If

            '    Dim CropSearch() As String = e.Data.Split(New String() {"crop="}, System.StringSplitOptions.RemoveEmptyEntries)
            '    Dim CropSearch2 As String = "crop=" + CropSearch(1)
            '    Dim newProcess As String = pr.StartInfo.Arguments.ToString().Replace("cropdetect=24:16:0", CropSearch2)
            '    pr.Kill()

            '    If Debug2 = True Then
            '        MsgBox(newProcess)
            '    End If

            'End If


            If MergeSubstoMP4 = False Then
                If CBool(InStr(e.Data, "Stream #")) And CBool(InStr(e.Data, "Video")) = True Then
                    'MsgBox(True.ToString + vbNewLine + e.Data)
                    'MsgBox(InStr(e.Data, "Stream #").ToString + vbNewLine + InStr(e.Data, "Video").ToString)

                    'MsgBox("with CBool" + vbNewLine + CBool(InStr(e.Data, "Stream #")).ToString + vbNewLine + CBool(InStr(e.Data, "Video")).ToString)

                    ListOfStreams.Add(e.Data)
                End If
                If InStr(e.Data, "Stream #") And InStr(e.Data, " -> ") Then
                    'UsesStreams.Add(e.Data)
                    'MsgBox(e.Data)
                    Dim StreamSearch() As String = e.Data.Split(New String() {" -> "}, System.StringSplitOptions.RemoveEmptyEntries)
                    Dim StreamSearch2 As String = StreamSearch(0) + ":"
                    For i As Integer = 0 To ListOfStreams.Count - 1
                        If CBool(InStr(ListOfStreams(i), StreamSearch2)) Then 'And CBool(InStr(ListOfStreams(i), " Video:")) Then
                            'MsgBox(ListOfStreams(i))
                            Dim ResoSearch() As String = ListOfStreams(i).Split(New String() {"x"}, System.StringSplitOptions.RemoveEmptyEntries)
                            'MsgBox(ResoSearch(1))
                            If CBool(InStr(ResoSearch(2), " [")) = True Then
                                Dim ResoSearch2() As String = ResoSearch(2).Split(New String() {" ["}, System.StringSplitOptions.RemoveEmptyEntries)
                                For ii As Integer = 0 To PB_list.Count - 1
                                    If PB_list(ii).Name = FileName Then
                                        Dim p As PictureBox = PB_list(ii)
                                        p.Image = p.BackgroundImage
                                        Dim g As Graphics = Graphics.FromImage(p.Image)
                                        Dim TextPointL4 As Point = New Point(195, 101)
                                        Dim Weiß As Brush = New SolidBrush(Color.FromArgb(242, 242, 242))
                                        g.FillRectangle(Weiß, TextPointL4.X - 3, TextPointL4.Y - 3, 70, 30)
                                        g.DrawString(ResoSearch2(0) + "p", FontLabel.Font, Brushes.Black, TextPointL4)
                                        Dim brGradient As Brush = New SolidBrush(Color.FromArgb(125, 0, 0))
                                        g.Dispose()
                                        Exit For
                                    End If
                                Next
                            End If

                        End If
                    Next
                End If
            End If

            If Me.Visible = False Or AbourtList.Contains(FileName) Then
                ' Try
                pr.Kill()
                pr.WaitForExit(500)
                'Catch ex As Exception
                'End Try
                RaiseEvent UpdateUI(FileName, 200, 0, 0, Color.FromArgb(125, 0, 0), "-MB\s")
            End If
            Me.Invoke(New Action(Function()
                                     For i As Integer = 0 To PB_list.Count - 1

                                         If PB_list(i).Name = FileName Then
                                             If InStr(e.Data, "Duration: N/A, bitrate: N/A") Then

                                             ElseIf InStr(e.Data, "Duration: ") Then
                                                 Dim ZeitGesamt As String() = e.Data.Split(New String() {"Duration: "}, System.StringSplitOptions.RemoveEmptyEntries)
                                                 Dim ZeitGesamt2 As String() = ZeitGesamt(1).Split(New [Char]() {System.Convert.ToChar(".")})
                                                 Dim ZeitGesamtSplit() As String = ZeitGesamt2(0).Split(New [Char]() {System.Convert.ToChar(":")})
                                                 'MsgBox(ZeitGesamt2(0))
                                                 Dim ZeitGesamtInteger As Integer = CInt(ZeitGesamtSplit(0)) * 3600 + CInt(ZeitGesamtSplit(1)) * 60 + CInt(ZeitGesamtSplit(2))

                                                 ListView1.Items.Item(i).Text = ZeitGesamtInteger


                                             ElseIf InStr(e.Data, " time=") Then
                                                 'MsgBox(e.Data)
                                                 Dim ZeitFertig As String() = e.Data.Split(New String() {" time="}, System.StringSplitOptions.RemoveEmptyEntries)
                                                 Dim ZeitFertig2 As String() = ZeitFertig(1).Split(New [Char]() {System.Convert.ToChar(".")})
                                                 Dim ZeitFertigSplit() As String = ZeitFertig2(0).Split(New [Char]() {System.Convert.ToChar(":")})
                                                 Dim ZeitFertigInteger As Integer = CInt(ZeitFertigSplit(0)) * 3600 + CInt(ZeitFertigSplit(1)) * 60 + CInt(ZeitFertigSplit(2))
                                                 Dim bitrate3 As String = 0
                                                 If InStr(e.Data, "bitrate=") Then
                                                     Dim bitrate As String() = e.Data.Split(New String() {"bitrate="}, System.StringSplitOptions.RemoveEmptyEntries)
                                                     Dim bitrate2 As String() = bitrate(1).Split(New String() {"kbits/s"}, System.StringSplitOptions.RemoveEmptyEntries)

                                                     If InStr(bitrate2(0), ".") Then
                                                         Dim bitrateTemo As String() = bitrate2(0).Split(New String() {"."}, System.StringSplitOptions.RemoveEmptyEntries)
                                                         bitrate3 = bitrateTemo(0)
                                                     ElseIf InStr(bitrate2(0), ",") Then
                                                         Dim bitrateTemo As String() = bitrate2(0).Split(New String() {","}, System.StringSplitOptions.RemoveEmptyEntries)
                                                         bitrate3 = bitrateTemo(0)
                                                     End If
                                                 End If
                                                 Dim bitrateInt As Double = CInt(bitrate3) / 1024
                                                 Dim FileSize As Double = CInt(ListView1.Items.Item(i).Text) * bitrateInt / 8
                                                 Dim DownloadFinished As Double = ZeitFertigInteger * bitrateInt / 8
                                                 Dim percent As Integer = ZeitFertigInteger / CInt(ListView1.Items.Item(i).Text) * 100
                                                 RaiseEvent UpdateUI(FileName, percent, Math.Round(DownloadFinished, 2, MidpointRounding.AwayFromZero), Math.Round(FileSize, 2, MidpointRounding.AwayFromZero), Color.FromArgb(247, 139, 37), "converting")
                                             End If
                                         End If

                                     Next

                                     Return Nothing
                                 End Function))
        Catch ex As Exception

        End Try

    End Sub


    Private Sub Main_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Try
            Me.Visible = False
            RemoveFinishedTask()
            'Pause(2)
        Catch ex As Exception
        End Try

    End Sub

    Private Sub Main_UpdateUI(sender As String, ByVal int As Integer, ByVal Size As Double, ByVal Finished As Double, Color As Color, ByVal Speed As String) Handles Me.UpdateUI
        Try
            For i As Integer = 0 To PB_list.Count - 1

                If PB_list(i).Name = sender Then
                    If int = 200 Then
                        Dim p As PictureBox = PB_list(i)
                        p.Image = p.BackgroundImage
                        Dim g As Graphics = Graphics.FromImage(p.Image)
                        Dim ProgressbarPoint As Point = New Point(195, 70)
                        Dim WeißeBox As Point = New Point(450, 93)
                        Dim ProzentText As Point = New Point(773, 100)
                        Dim Weiß As Brush = New SolidBrush(Color.FromArgb(242, 242, 242))
                        g.FillRectangle(Weiß, WeißeBox.X + 1, WeißeBox.Y + 1, 350, 30)
                        g.DrawString("-%", FontLabel2.Font, Brushes.Black, ProzentText)
                        Dim brGradient As Brush = New SolidBrush(Color)
                        g.FillRectangle(brGradient, ProgressbarPoint.X + 1, ProgressbarPoint.Y + 1, 600, 19)
                        g.Dispose()
                        AbourtList.Remove(sender)
                    Else
                        Dim stringFormat As New StringFormat()
                        stringFormat.Alignment = StringAlignment.Far
                        stringFormat.LineAlignment = StringAlignment.Center
                        Dim p As PictureBox = PB_list(i)

                        p.Image = p.BackgroundImage
                        Dim g As Graphics = Graphics.FromImage(p.Image)
                        Dim ProgressbarPoint As Point = New Point(195, 70)
                        Dim WeißeBox As Point = New Point(465, 93)
                        Dim ProzentText As Point = New Point(795, 113)
                        Dim Weiß As Brush = New SolidBrush(Color.FromArgb(242, 242, 242))
                        g.FillRectangle(Weiß, WeißeBox.X + 1, WeißeBox.Y + 1, 335, 30)
                        g.DrawString(Speed + " " + Size.ToString + "MB/" + Finished.ToString + "MB " + int.ToString + "%", FontLabel2.Font, Brushes.Black, ProzentText, stringFormat)
                        Dim brGradient As Brush = New SolidBrush(Color)
                        g.FillRectangle(brGradient, ProgressbarPoint.X + 1, ProgressbarPoint.Y + 1, int * 6, 19)
                        g.Dispose()
                    End If
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles pictureBox3.Click
        RemoveFinishedTask()
        Pause(1)
        If PR_List.Count > 0 Then
            If MessageBox.Show("Are you sure you want close the program and end all active downloads?", "confirm?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                For i As Integer = 0 To PR_List.Count - 1
                    Dim pr As Process = PR_List.Item(i)
                    pr.Kill()
                    pr.WaitForExit(100)
                Next

                Me.Close()
            End If
        Else
            Me.Close()
        End If
    End Sub


    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles pictureBox4.Click
        Anime_Add.Show()

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles pictureBox2.Click
        einstellungen.Show()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles pictureBox1.Click
        UserBowser = True
        GeckoFX.Show()
    End Sub

#Region " Move Form "

    ' [ Move Form ]
    '
    ' // By Elektro 

    Public MoveForm As Boolean
    Public MoveForm_MousePosition As Point

    Public Sub MoveForm_MouseDown(sender As Object, e As MouseEventArgs) Handles _
    MyBase.MouseDown ' Add more handles here (Example: PictureBox1.MouseDown)

        If e.Button = MouseButtons.Left Then
            MoveForm = True
            Me.Cursor = Cursors.NoMove2D
            MoveForm_MousePosition = e.Location
        End If

    End Sub

    Public Sub MoveForm_MouseMove(sender As Object, e As MouseEventArgs) Handles _
    MyBase.MouseMove ' Add more handles here (Example: PictureBox1.MouseMove)

        If MoveForm Then
            Me.Location = Me.Location + (e.Location - MoveForm_MousePosition)
        End If

    End Sub

    Public Sub MoveForm_MouseUp(sender As Object, e As MouseEventArgs) Handles _
    MyBase.MouseUp ' Add more handles here (Example: PictureBox1.MouseUp)

        If e.Button = MouseButtons.Left Then
            MoveForm = False
            Me.Cursor = Cursors.Default
        End If

    End Sub
#End Region

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs)
        Startup.ShowDialog()
    End Sub

    Public Function RemoveExtraSpaces(input_text As String) As String

        Dim rsRegEx As System.Text.RegularExpressions.Regex
        rsRegEx = New System.Text.RegularExpressions.Regex("\s+")

        Return rsRegEx.Replace(input_text, " ").Trim()

    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            For i As Integer = 0 To ThreadList.Count - 1
                If ThreadList.Item(i).IsAlive Then
                Else
                    ThreadList.Remove(ThreadList.Item(i))
                End If
            Next
        Catch ex As Exception

        End Try
        Try
            For s As Integer = 0 To ListView1.Items.Count - 1
                Dim r As Rectangle = ListView1.Items.Item(s).Bounds
                PB_list(s).SetBounds(r.X, r.Y, r.Width, r.Height)
                bt_dl(s).SetBounds(775, r.Y + 10, 35, 29)
                bt_p(s).SetBounds(740, r.Y + 15, 25, 20)
            Next
        Catch ex As Exception

        End Try
    End Sub

#Region "unused"




    'Public Shared Function GetPage(url As String) As String
    '    Try
    '        Dim ourUri As New Uri(url)
    '        Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create(ourUri), HttpWebRequest)
    '        myHttpWebRequest.Timeout = 10000
    '        Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
    '        Return myHttpWebResponse.ResponseUri.ToString
    '        myHttpWebResponse.Close()
    '    Catch e As Exception
    '        'MsgBox(e.Message.ToString)
    '        Return url
    '    End Try
    'End Function
    Sub FFMPEGResoBack(ByVal sender As Object, ByVal e As DataReceivedEventArgs)
        If InStr(e.Data, ": Video:") Then
            Dim ZeileReso() As String = e.Data.Split(New String() {" ["}, System.StringSplitOptions.RemoveEmptyEntries)
            Dim ZeileReso2() As String = ZeileReso(0).Split(New String() {"x"}, System.StringSplitOptions.RemoveEmptyEntries)
            Dim ZeileReso3() As String = e.Data.Split(New String() {": Video:"}, System.StringSplitOptions.RemoveEmptyEntries)
            Dim ZeileReso4() As String = ZeileReso3(0).Split(New String() {"Stream #"}, System.StringSplitOptions.RemoveEmptyEntries)
            'If ResoAvalibe = Nothing Then
            '    ResoAvalibe = ZeileReso2(ZeileReso2.Count - 1).Trim + ":--:" + ZeileReso4(1)
            'Else
            ResoAvalibe = ResoAvalibe + vbNewLine + ZeileReso2(ZeileReso2.Count - 1).Trim + ":--:" + ZeileReso4(1)
            'End If
        ElseIf InStr(e.Data, "Duration:") Then
            ResoAvalibe = Nothing
        ElseIf InStr(e.Data, "At least one output file must be specified") Then
            ResoSearchRunning = False
        End If
    End Sub

    Public Sub FFMPEG_Reso(ByVal DL_URL As String)
        ResoSearchRunning = True
        Dim proc As New Process
        Dim exepath As String = Application.StartupPath + "\ffmpeg.exe"
        Dim startinfo As New System.Diagnostics.ProcessStartInfo

        Dim cmd As String = "-i " + Chr(34) + DL_URL + Chr(34) 'start ffmpeg with command strFFCMD string
        Dim ffmpegOutput As String = Nothing
        Dim ffmpegOutput2 As String = Nothing
        'all parameters required to run the process
        startinfo.FileName = exepath
        startinfo.Arguments = cmd
        startinfo.UseShellExecute = False
        startinfo.WindowStyle = ProcessWindowStyle.Hidden
        startinfo.RedirectStandardError = True
        startinfo.RedirectStandardOutput = True
        startinfo.CreateNoWindow = True
        AddHandler proc.ErrorDataReceived, AddressOf FFMPEGResoBack
        AddHandler proc.OutputDataReceived, AddressOf FFMPEGResoBack
        proc.StartInfo = startinfo
        proc.Start() ' start the process
        proc.BeginOutputReadLine()
        proc.BeginErrorReadLine()
        'Dim ZeitAnzeige As String = Nothing
        'Dim StreamNR As String = Nothing
        ''Math.Abs()
        'Dim AllReso As String = "1080p720p480p360p"
        'Dim AllResoArry() As String = AllReso.Split(New String() {"p"}, System.StringSplitOptions.RemoveEmptyEntries)
        'Dim Zeilen() As String = ffmpegOutput.Split(New String() {vbNewLine}, System.StringSplitOptions.RemoveEmptyEntries)
        'For i As Integer = 0 To Zeilen.Count - 1
        '    If InStr(Zeilen(i), "x" + Resu.ToString + " [") Then
        '        Dim ZeileReso() As String = Zeilen(i).Split(New String() {": Video:"}, System.StringSplitOptions.RemoveEmptyEntries)
        '        Dim ZeileReso2() As String = ZeileReso(0).Split(New String() {"Stream #"}, System.StringSplitOptions.RemoveEmptyEntries)
        '        StreamNR = ZeileReso2(1)
        '    End If
        'Next

        'Return ZeitAnzeige + "#1" + StreamNR
    End Sub
#End Region

    Public Sub Grapp_non_CR()

        If NonCR_URL = Nothing Then Exit Sub
        Me.Invoke(New Action(Function()
                                 Anime_Add.StatusLabel.Text = "Status: m3u8 found, trying to start the download"
                                 Return Nothing
                             End Function))
        Grapp_non_cr_RDY = False
        For i As Integer = 0 To 30
            If ResoSearchRunning = True Then
                Pause(1)
            Else
                Exit For
            End If
        Next
        If Debug2 = True Then
            MsgBox(ResoSearchRunning.ToString)
        End If
        Dim Video_Title As String = WebbrowserTitle.Replace(" - Watch on VRV", "").Replace("Free Streaming", "").Replace("Tubi", "")
        Video_Title = RemoveExtraSpaces(Video_Title)
#Region "Name + Pfad"
        Dim Video_FilenName As String = Video_Title
        Video_FilenName = System.Text.RegularExpressions.Regex.Replace(Video_FilenName, "[^\w\\-]", " ")
        Video_FilenName = RemoveExtraSpaces(Video_FilenName + ".mp4")
#End Region

#Region "thumbnail"
        Dim thumbnail As String() = Nothing
        Dim thumbnail2 As String() = Nothing
        Dim thumbnail4 As String = "None, will usese fail image"
        Try
            If InStr(WebbrowserText, "thumbnail") Then
                thumbnail = WebbrowserText.Split(New String() {"thumbnail"}, System.StringSplitOptions.RemoveEmptyEntries)
            End If
        Catch ex As Exception

        End Try
        Try
            For i As Integer = 0 To thumbnail.Count - 1
                If InStr(thumbnail(i), ".jpg") Then
                    If InStr(thumbnail(i), "https:") Then
                        thumbnail2 = thumbnail(i).Split(New String() {".jpg"}, System.StringSplitOptions.RemoveEmptyEntries)
                        Dim thumbnail3 As String() = thumbnail2(0).Split(New String() {"https:"}, System.StringSplitOptions.RemoveEmptyEntries)
                        thumbnail4 = "https:" + thumbnail3(thumbnail3.Count - 1).Replace("&amp;", "&").Replace("/u0026", "&").Replace("\u002F", "/").Replace("\/", "/") + ".jpg"
                        Exit For
                    End If
                End If
            Next

        Catch ex As Exception
        End Try
#End Region


#Region "lösche doppel download"

        Dim Pfad5 As String = Path.Combine(Pfad + Video_FilenName)
        If My.Computer.FileSystem.FileExists(Pfad5) Then 'Pfad = Kompeltter Pfad mit Dateinamen + ENdung
            If MessageBox.Show("The file " + Pfad5 + " already exists." + vbNewLine + "You want to override it?", "File exists!", MessageBoxButtons.OKCancel) = DialogResult.OK Then
                Try
                    My.Computer.FileSystem.DeleteFile(Pfad5)
                Catch ex As Exception
                End Try
            Else
                Grapp_non_cr_RDY = True
                Exit Sub
            End If

        End If
#End Region
        URL_DL = NonCR_URL.Replace("&amp;", "&").Replace("/u0026", "&").Replace("\u002F", "/") 'hls_List.Item(i2).Replace("&amp;", "&").Replace("/u0026", "&").Replace("\u002F", "/")
#Region "<li> constructor"
        Dim Subsprache3 As String = "undefined" 'HardSubValuesToDisplay(SubSprache2)
        Dim ResoHTMLDisplay As String = "[Auto]"
        If InStr(ResoAvalibe, Resu.ToString) Then
            Dim ResoUse As String() = ResoAvalibe.Split(New String() {Resu.ToString + ":--:"}, System.StringSplitOptions.RemoveEmptyEntries)
            Dim ResoUse2 As String() = ResoUse(1).Split(New String() {vbNewLine}, System.StringSplitOptions.RemoveEmptyEntries)

            UsedMap = ResoUse2(0)
            If Debug2 = True Then
                MsgBox(UsedMap)
            End If
            ResoHTMLDisplay = Resu.ToString + "p"
        Else
            ResoHTMLDisplay = "[Auto]"
        End If

        Dim L2Name As String = Video_Title
        Dim L1Name_Split As String() = WebbrowserURL.Split(New String() {"/"}, System.StringSplitOptions.RemoveEmptyEntries)
        Dim L1Name As String = L1Name_Split(1)
        Pfad_DL = Chr(34) + Pfad + "\" + Video_FilenName + Chr(34)
        Me.Invoke(New Action(Function()
                                 ListAdd(Pfad_DL, L1Name, L2Name, ResoHTMLDisplay, Subsprache3, SubValuesToDisplay(), thumbnail4)
                                 Return Nothing
                             End Function))
#End Region
        AsyncWorkerX.RunAsync(AddressOf DownloadFFMPEG, URL_DL, Pfad_DL, Pfad_DL)
        Grapp_non_cr_RDY = True
        Me.Invoke(New Action(Function()

                                 Anime_Add.StatusLabel.Text = "Status: idle"
                                 Return Nothing
                             End Function))

    End Sub

    Private Sub PictureBox2_DoubleClick(sender As Object, e As EventArgs) Handles pictureBox2.DoubleClick
        If Debug1 = True Then
            If Debug2 = True Then
                einstellungen.Close()
                Try
                    My.Computer.Clipboard.SetText(WebbrowserText)

                    MsgBox("webbrowser text copyed to the clipboard")
                Catch ex As Exception
                End Try
            Else
                Debug2 = True
                einstellungen.Close()
                MsgBox("Debug activated")
            End If
        Else
            Debug1 = True
            einstellungen.Close()
            'MsgBox("Debug activated")
        End If
    End Sub
    Public Sub DownloadMangaPages(ByVal BaseURL As String, ByVal SiteList As List(Of String), ByVal FolderName As String)
        Dim L1Name_Split As String() = WebbrowserURL.Split(New String() {"/"}, System.StringSplitOptions.RemoveEmptyEntries)
        Dim L1Name As String = L1Name_Split(1).Replace("www.", "")
        Pfad_DL = Pfad + "\" + FolderName
        If Debug2 = True Then
            MsgBox(BaseURL + SiteList(0))
        End If
        Me.Invoke(New Action(Function()

                                 ListAdd(Pfad_DL, L1Name, FolderName, "Manga", "Manga", "", BaseURL + SiteList(0))

                                 Return Nothing
                             End Function))

        Dim CurrentIndex As Integer = 0
        For i As Integer = 0 To PB_list.Count - 1
            If PB_list.Item(i).Name = Pfad_DL Then
                CurrentIndex = i
            End If
        Next


        Try
            Directory.CreateDirectory(Pfad_DL)
            'MsgBox(True.ToString)
        Catch ex As Exception
        End Try

        'If Not Directory.Exists(Path.GetDirectoryName(Pfad_DL)) Then
        '    ' Nein! Jetzt erstellen...
        '    Try
        '        Directory.CreateDirectory(Path.GetDirectoryName(Pfad_DL))
        '        MsgBox(True.ToString)
        '    Catch ex As Exception
        '        MsgBox(False.ToString)
        '        ' Ordner wurde nich erstellt
        '        Exit Sub
        '        'Pfad_DL = Pfad + "\" + CR_FilenName_Backup + ".mp4"
        '    End Try
        'End If

        For i As Integer = 0 To SiteList.Count - 1
            Dim iWert As Integer = i
            Using client As New WebClient()
                client.DownloadFile(BaseURL + SiteList(i), Pfad_DL + "\" + SiteList(i))
                Pause(1)
            End Using
            Me.Invoke(New Action(Function()
                                     Dim stringFormat As New StringFormat()
                                     stringFormat.Alignment = StringAlignment.Far
                                     stringFormat.LineAlignment = StringAlignment.Center
                                     Dim p As PictureBox = PB_list(CurrentIndex)
                                     p.Image = p.BackgroundImage
                                     Dim g As Graphics = Graphics.FromImage(p.Image)
                                     Dim ProgressbarPoint As Point = New Point(195, 70)
                                     Dim WeißeBox As Point = New Point(525, 93)
                                     Dim ProzentText As Point = New Point(795, 113)
                                     Dim Weiß As Brush = New SolidBrush(Color.FromArgb(242, 242, 242))
                                     g.FillRectangle(Weiß, WeißeBox.X + 1, WeißeBox.Y + 1, 275, 30)
                                     g.DrawString((iWert + 1).ToString + "/" + SiteList.Count.ToString + " " + Math.Round(iWert / (SiteList.Count - 1) * 100, 2, MidpointRounding.AwayFromZero).ToString + "%", FontLabel2.Font, Brushes.Black, ProzentText, stringFormat)
                                     Dim brGradient As Brush = New SolidBrush(Color.FromArgb(247, 140, 37))
                                     g.FillRectangle(brGradient, ProgressbarPoint.X + 1, ProgressbarPoint.Y + 1, CInt((iWert / (SiteList.Count - 1)) * 600), 19)
                                     g.Dispose()
                                     Return Nothing
                                 End Function))

        Next

    End Sub

    Private Sub Main_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Me.MouseDoubleClick
        Login.Show()
    End Sub


End Class

