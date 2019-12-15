Option Explicit On

Module Module1
    Public myappname As String = "Simple Encrypt/Decrypt"
    Public myappversnum As Integer = 1100
    Public myappvers As String = "v" & (myappversnum / 1000).ToString.Replace(",", ".")
    Public myappfullname As String = myappname & " " & myappvers
    '


    'Copyright Stuff
    Public Function Current_copyright(ByVal fromyear As String, Optional ByVal Copyright_Icon As Boolean = True, Optional ByVal After_Copyright_Text As String = "") As String
        Dim s As String = Date.Today.Year
        Dim c As String = ""
        Select Case Copyright_Icon
            Case True
                c = " © "
            Case False
                c = " (c) "
        End Select
        Dim p As String = fromyear & "-" & s & c & After_Copyright_Text
        Return p
    End Function
End Module
