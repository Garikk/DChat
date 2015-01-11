' DZFS.NET 2003
' DChat project
' Gx52 v.1.2
'------------------------------------------------------------------------------------
' Programmed by Jurik
' Gx52u Add-on by Garikk
' DEC-Gx52 Converter
'------------------------------------------------------------------------------------

Option Strict Off
Option Explicit On
Module Gx52
    ' Max number - 14768649 (zzzz)

    Dim InitOk As Boolean
    Dim I As Integer
    Dim Mas(62) As String
    Dim M As String

    Public Function Gx52ToDEC(ByVal M As String) As Integer
        If M.Length = 2 Then Gx52ToDEC = Gx52uToDEC(M) : Exit Function
        Dim N1 As Integer = Gx52uToDEC(Mid(M, 1, 2))
        Dim N2 As String = Gx52uToDEC(Mid(M, 3, 2))
        Gx52ToDEC = N1 * 3844 + N2
    End Function

    Public Function DECtoGx52(ByVal M As Integer) As String
        Dim N1 As Integer
        Dim N2 As Integer
        If M < 3844 Then DECtoGx52 = DECToGx52u(M) : Exit Function
        N2 = M \ 3844
        N1 = M Mod 3844
        DECtoGx52 = DECToGx52u(N2) & DECToGx52u(N1)
    End Function

    Private Function Gx52uToDEC(ByVal M As String) As Short
        If InitOk = False Then Init()
        Dim N As Integer
        Dim N1 As Integer
        Dim Res As Integer
        If Mid(M, 1, 1) = "0" Then M = Mid(M, 2, 1)
        For I = 1 To 62
            If M = Mas(I) Then
                Gx52uToDEC = I - 1
                Exit Function
            End If
        Next
        For I = 1 To 62
            If Mas(I) = Mid(M, 1, 1) Then
                N = I - 1
                Exit For
            End If
        Next
        For I = 1 To 62
            If Mas(I) = Mid(M, 2, 1) Then
                N1 = I - 1
                Exit For
            End If
        Next
        Gx52uToDEC = N * 62 + N1
    End Function

    Private Function DECToGx52u(ByVal M As Integer) As String
        If InitOk = False Then Init()
        Dim N As Integer
        Dim Ost As Integer
        Dim Res As String
        Dim S As String
        Dim Cnt As Boolean
        Cnt = False
        If Val(M) < 62 Then
            S = Mas(Val(M) + 1)
            Cnt = True
        End If
        If Cnt = False Then
            N = Val(M)
            Ost = N
            Do While Ost >= 62
                Ost = N Mod 62
                N = N \ 62
                Res = Res + Mas(Ost + 1)
                If N < 62 Then Res = Res & Mas(N + 1)
            Loop
            S = Mid(Res, 2, 1) + Mid(Res, 1, 1)
        End If
        If Len(S) = 1 Then S = "0" & S
        DECToGx52u = S
    End Function

    Public Sub Init()
        ' Инициализация перекодировщика Dec->Gx52
        For I = 1 To 10
            Mas(I) = I - 1
        Next
        M = "abcdefghijklmnopqrstuvwxyz"
        For I = 11 To 36
            Mas(I) = UCase(Mid(M, I - 10, 1))
            Mas(I + 26) = Mid(M, I - 10, 1)
        Next
        InitOk = True
    End Sub
End Module