' DZFS.NET 2003
' DChat project
' DC2Converter (IRCtext<->RTF)
'------------------------------------------------------------------------------------
' Programmed by Garikk
' RTF to IRC, text converter v.1.1
'------------------------------------------------------------------------------------

Module DC2Converter


    Private Structure DC2Indexer
        Dim StartPosition As Integer
        Dim LengthString As Integer
        Dim IndexerType As DC2IndexerTypes
        Dim SetColor As Integer
    End Structure
    Private Structure IRC2RTFColorOffsetSet
        Dim ClrString As String
        Dim ClrOffset As Integer
    End Structure

    Private Enum DC2IndexerTypes
        DC2_RENDER_BOLD = 0
        DC2_RENDER_UNDERL = 1
        DC2_RENDER_COLOR = 2
        DC2_RENDER_REV = 3
        DC2_RENDER_ITALIC = 4
    End Enum


    Public Function RTFToDC2(ByVal RTF As String) As String
        Dim RTFBox As New RichTextBox
        Dim DC2Text As String
        Dim SelBold As Boolean = False
        Dim SelItal As Boolean = False
        Dim SelUnderl As Boolean = False
        Dim SelColor As Integer = RTFBox.SelectionColor.ToArgb
        Dim Tmp As Integer
        Dim STEP1 As String()

        RTFBox.Rtf = RTF


        For Tmp = 0 To RTFBox.Text.Length
            RTFBox.Select(Tmp, 1)
            If RTFBox.SelectionFont.Bold = True And SelBold = False Then DC2Text += Chr(2) : SelBold = True
            If RTFBox.SelectionFont.Underline = True And SelUnderl = False Then DC2Text += Chr(31) : SelUnderl = True
            If RTFBox.SelectionFont.Bold = False And SelBold = True Then DC2Text += Chr(2) : SelBold = False
            If RTFBox.SelectionFont.Underline = False And SelUnderl = True Then DC2Text += Chr(31) : SelUnderl = False

            If RTFBox.SelectionColor.ToArgb <> SelColor Then DC2Text += Chr(3) & GetIRCColorCode(RTFBox.SelectionColor.ToArgb) : SelColor = RTFBox.SelectionColor.ToArgb

            DC2Text += RTFBox.SelectedText

        Next
        Return DC2Text


    End Function

    Public Function DC2ToRTF(ByVal RTF As String) As String
        Static RTFBox As New RichTextBox
        Dim RTFtext As String
        Dim SetBold(1) As String
        Dim SetUnderl(1) As String
        Dim CurStep As Integer
        Dim LastStep As Integer
        Dim BoldStat As Byte = 0
        Dim ColorString As String
        Dim ClrParams As IRC2RTFColorOffsetSet
        Dim strTmp() As String
        Dim strTmp1 As String
        SetBold(0) = "\b "
        SetBold(1) = "\b0 "
        SetUnderl(0) = "\ul "
        SetUnderl(1) = "\ulnone "
        Const RTF_BOLD = "\'02"
        Const RTF_UNDER = "\'1f"
        Const RTF_HIGHLIGHT = "\highlight"
        Const RTF_COLOR = "\'03"
        Const IRC_Color = "\cf"
        Const RTF_CLRTBL = "{\colortbl ;\red255\green255\blue255;\red0\green0\blue0;\red0\green0\blue128;\red0\green128\blue0;\red255\green0\blue0;\red128\green0\blue0;\red128\green0\blue128;\red128\green128\blue0;\red255\green255\blue0;\red0\green255\blue0;\red0\green128\blue128;\red0\green255\blue255;\red0\green0\blue255;\red255\green0\blue255;\red128\green128\blue128;\red192\green192\blue192;}"


        RTFBox.Text = RTF
        RTFBox.SelectAll()
        RTFtext = RTFBox.SelectedRtf
        ' RTFBox.Dispose()

        '-------------
        'Bold
        '-------------
        CurStep = RTFtext.IndexOf(RTF_BOLD)
        If CurStep > -1 Then
            Do
                If CurStep = -1 Then Exit Do
                RTFtext = Mid(RTFtext, 1, CurStep) & SetBold(BoldStat) & Mid(RTFtext, CurStep + 5)
                CurStep = RTFtext.IndexOf(RTF_BOLD)
                If BoldStat = 0 Then BoldStat = 1 Else BoldStat = 0
            Loop Until CurStep = -1
        End If
        '-------------
        'Underline
        '-------------
        BoldStat = 0
        CurStep = RTFtext.IndexOf(RTF_UNDER)
        If CurStep > -1 Then
            Do
                If CurStep = -1 Then Exit Do
                RTFtext = Mid(RTFtext, 1, CurStep) & SetUnderl(BoldStat) & Mid(RTFtext, CurStep + 5)
                CurStep = RTFtext.IndexOf(RTF_UNDER)
                If BoldStat = 0 Then BoldStat = 1 Else BoldStat = 0
            Loop Until CurStep = -1
        End If
        '--------------
        'Colors std
        '--------------
        CurStep = RTFtext.IndexOf(RTF_COLOR)
        If CurStep > -1 Then
            RTFtext = ReplClrTbl(RTFtext, RTF_CLRTBL)
            RTFtext = IRCColToRTFCol(RTFtext)
        End If
        Return RTFtext
    End Function

    Public Function ReplClrTbl(ByVal RTF As String, ByVal CTBL As String) As String
        Dim StartCTBL As Integer
        Dim StopCTBL As Integer
        Dim tmp As Integer
        For tmp = 0 To 1
            StopCTBL = RTF.IndexOf("}", StopCTBL + 1)
        Next
        Return Mid(RTF, 1, StopCTBL + 1) & CTBL & Mid(RTF, StopCTBL + 2)
    End Function

    Private Function IRCColToRTFCol(ByVal IRCClr As String) As String
        Dim Tmp As Integer
        Dim Tmp2 As Integer
        Dim t As String
        Dim R() As String
        Dim result As String
        For Tmp = 15 To 0 Step -1
            For Tmp2 = 15 To 0 Step -1
                IRCClr = IRCClr.Replace("\'03" & Tmp & "," & Tmp2, "\highlight1 \cf1 \cf" & Tmp + 1 & " \highlight" & Tmp2 + 1)
            Next
            IRCClr = IRCClr.Replace("\'03" & Tmp, "\cf" & Tmp + 1 & " ")
        Next
        IRCClr = IRCClr.Replace("\'03", "\cf2 ")
        Return IRCClr
    End Function
    Public Function GetIRCColorCode(ByVal ARGB As Integer) As Integer
        Select Case ARGB
            Case Color.White.ToArgb
                Return 0
            Case Color.Black.ToArgb
                Return 1
            Case Color.DarkBlue.ToArgb
                Return 2
            Case Color.DarkGreen.ToArgb
                Return 3
            Case Color.Red.ToArgb
                Return 4
            Case Color.DarkRed.ToArgb
                Return 5
            Case Color.Purple.ToArgb
                Return 6
            Case Color.Orange.ToArgb
                Return 7
            Case Color.Yellow.ToArgb
                Return 8
            Case Color.Green.ToArgb
                Return 9
            Case Color.Cyan.ToArgb
                Return 10
            Case Color.LightCyan.ToArgb
                Return 11
            Case Color.Blue.ToArgb
                Return 12
            Case Color.Pink.ToArgb
                Return 13
            Case Color.Gray.ToArgb
                Return 14
            Case Color.LightGray.ToArgb
                Return 15
            Case Else
                Return Color.Black.ToArgb
        End Select
    End Function

    Public Function GetARGBfromIRCCode(ByVal IRCColorCode As Integer) As Integer
        Select Case IRCColorCode
            Case 0
                Return Color.White.ToArgb
            Case 1
                Return Color.Black.ToArgb
            Case 2
                Return Color.DarkBlue.ToArgb
            Case 3
                Return Color.DarkGreen.ToArgb
            Case 4
                Return Color.Red.ToArgb
            Case 5
                Return Color.DarkRed.ToArgb
            Case 6
                Return Color.Purple.ToArgb
            Case 7
                Return Color.Orange.ToArgb
            Case 8
                Return Color.Yellow.ToArgb
            Case 9
                Return Color.Green.ToArgb
            Case 10
                Return Color.Cyan.ToArgb
            Case 11
                Return Color.LightCyan.ToArgb
            Case 12
                Return Color.Blue.ToArgb
            Case 13
                Return Color.Pink.ToArgb
            Case 14
                Return Color.Gray.ToArgb
            Case 15
                Return Color.LightGray.ToArgb
        End Select
    End Function

End Module
