Option Explicit On

Module Module1
    Public myappname As String = "Simple Encrypt/Decrypt"
    Public myappversnum As Integer = 500
    Public myappvers As String = "v" & (myappversnum / 1000).ToString.Replace(",", ".")
    Public myappfullname As String = myappname & " " & myappvers
    '


    'Copyright Stuff
    Public Function current_copyright(ByVal fromyear As String, Optional ByVal Copyright_Icon As Boolean = True, Optional ByVal After_Copyright_Text As String = "") As String
        Dim s As String = Date.Today.Year
        Dim p As String = ""
        Dim c As String = ""
        Select Case Copyright_Icon
            Case True
                c = " © "
            Case False
                c = " (c) "
        End Select
        p = fromyear & "-" & s & c & After_Copyright_Text
        Return p
    End Function
End Module
