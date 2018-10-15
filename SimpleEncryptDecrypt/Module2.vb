Module Module2
#Region "Init Application"
    Private WithEvents mytoolstrip As New ToolStrip
    Private WithEvents mytoolstrip_combo As New ToolStripComboBox
    Private mytoolstip_label As New ToolStripLabel
    Private cypher_array As Array = {"ROT5", "ROT13", "ROT18", "ROT47", "Rotate by"}
    Public Sub init_toolstrip_box(ByVal frm As Form)
        frm.Controls.Add(mytoolstrip)
        With mytoolstip_label
            .Text = "Select cypher: "
        End With
        For Each i In cypher_array
            mytoolstrip_combo.Items.Add(i)
        Next
        With mytoolstrip_combo
            .SelectedIndex = 1
            .DropDownStyle = ComboBoxStyle.DropDownList
        End With

        With mytoolstrip
            .Items.Add(mytoolstip_label)
            .Items.Add(mytoolstrip_combo)
        End With
    End Sub
    Private Sub mytoolstrip_combo_OnSelect() Handles mytoolstrip_combo.SelectedIndexChanged
        Select Case mytoolstrip_combo.SelectedIndex
            Case 0 'ROT5
                ROT5_cypher.opener(main)
            Case 1 'ROT13
                ROT13_cypher.opener(main)
            Case 2 'ROT18
                ROT18_cypher.opener(main)
            Case 3 'ROT47
                ROT47_cypher.opener(main)
            Case 4 'Rotate by
                Rotate_by_cypher.opener(main)
        End Select
    End Sub

#End Region

    Public Class ROT13_cypher
        Private Shared Aline As Array = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M"}
        Private Shared Bline As Array = {"N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
        Private Shared LineA As New ArrayList
        Private Shared LineB As New ArrayList
        Private WithEvents encrypt_button As New Button
        Private Sub encrypt_button_Click() Handles encrypt_button.Click
            Dim b As New ROT13_cypher
            main.TextBox2.Text = b.engine(main.TextBox1.Text)
        End Sub
        Public Shared Sub opener(ByVal form As Form)
            'set textbox sentence
            For Each ctrl In form.Controls
                If ctrl.name = "GroupBox1" Then
                    For Each i In ctrl.controls
                        If i.name = "TextBox1" Then
                            i.text = "ROT13 (""ROT13 (""rotate by 13 places"", sometimes hyphenated ROT-13) is a simple letter substitution cipher that replaces a letter with the letter 13 letters after it in the alphabet. ROT13 is a special case of the Caesar cipher, developed in ancient Rome."
                        End If
                    Next
                End If
                If ctrl.name = "cypherbutton" Then
                    form.Controls.Remove(ctrl)
                End If
            Next

            'create new button
            Dim s As New ROT13_cypher
            With s.encrypt_button
                .Text = "ROT13 Cypher"
                .Location = New Point(347, 50)
                .Size = New Size(143, 26)
                .Name = "cypherbutton"
            End With
            form.Controls.Add(s.encrypt_button)

            'Fill Label
            LineA.Clear()
            LineB.Clear()
            main.Label2.Text = Nothing
            For u = 0 To Aline.Length - 1
                LineA.Add(Aline(u))
                main.Label2.Text += " " & Aline(u) & " |"
                If u = Aline.Length - 1 Then
                    main.Label2.Text = main.Label2.Text.Substring(0, main.Label2.Text.LastIndexOf("|"))
                End If
            Next
            main.Label2.Text += vbCrLf & "--------------------------------------------------" & vbCrLf
            For u = 0 To Bline.Length - 1
                LineB.Add(Bline(u))
                main.Label2.Text += " " & Bline(u) & " |"
                If u = Bline.Length - 1 Then
                    main.Label2.Text = main.Label2.Text.Substring(0, main.Label2.Text.LastIndexOf("|"))
                End If
            Next
        End Sub
        Public Function engine(ByVal completeString As String)
            Dim u As Integer = completeString.Length
            Dim bufferString As String = completeString
            Dim outputString As String = Nothing
            Dim doesLineContainChar As Boolean

            For i = 0 To u - 1
                doesLineContainChar = False

                bufferString = completeString.Substring(0, 1)
                completeString = completeString.Remove(completeString.IndexOf(bufferString), 1)

                For Each s In Aline
                    If s.ToString = bufferString.ToUpper Then
                        If Char.IsLower(bufferString) Then
                            outputString += Bline(LineA.IndexOf(s)).ToString.ToLower
                        Else
                            outputString += LineB(LineA.IndexOf(s))
                        End If
                        doesLineContainChar = True
                    End If
                Next

                For Each bs In LineB
                    If bs.ToString = bufferString.ToUpper Then
                        If Char.IsLower(bufferString) Then
                            outputString += LineA(LineB.IndexOf(bs)).ToString.ToLower
                        Else
                            outputString += LineA(LineB.IndexOf(bs))
                        End If
                        doesLineContainChar = True
                    End If
                Next
                If doesLineContainChar = False Then
                    outputString += bufferString
                End If
            Next

            Return outputString
        End Function
    End Class

    Public Class ROT47_cypher
        Private Shared ALine As Array = {"!", """", "#", "$", "%", "&", "'", "(", ")", "*", "+", ",", "-", ".", "/", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", ":", ";", "<", "=", ">", "?", "@", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "[", "\", "]", "^", "_", "`", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "{", "|", "}", "~"}
        Private Shared BLine As Array = {"P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "[", "\", "]", "^", "_", "`", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "{", "|", "}", "~", "!", """", "#", "$", "%", "&", "'", "(", ")", "*", "+", ",", "-", ".", "/", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", ":", ";", "<", "=", ">", "?", "@", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O"}
        Private Shared LineA As New ArrayList
        Private Shared LineB As New ArrayList
        Private WithEvents encrypt_button As New Button
        Private Sub encrypt_button_Click() Handles encrypt_button.Click
            Dim b As New ROT47_cypher
            main.TextBox2.Text = b.engine(main.TextBox1.Text)
        End Sub
        Public Shared Sub opener(ByVal form As Form)
            'set textbox sentence
            For Each ctrl In form.Controls
                If ctrl.name = "GroupBox1" Then
                    For Each i In ctrl.controls
                        If i.name = "TextBox1" Then
                            i.text = "ROT47 is a derivative of ROT13 which, in addition to scrambling the basic letters, also treats numbers and common symbols. Instead of using the sequence A–Z as the alphabet, ROT47 uses a larger set of characters from the common character encoding known as ASCII."
                        End If
                    Next
                End If
                If ctrl.name = "cypherbutton" Then
                    form.Controls.Remove(ctrl)
                End If
            Next

            'create new button
            Dim s As New ROT47_cypher
            With s.encrypt_button
                .Text = "ROT47 Cypher"
                .Location = New Point(347, 50)
                .Size = New Size(143, 26)
                .Name = "cypherbutton"
            End With
            form.Controls.Add(s.encrypt_button)

            'Fill Label
            LineA.Clear()
            LineB.Clear()
            main.Label2.Text = Nothing
            For u = 0 To ALine.Length - 1
                LineA.Add(ALine(u))
                'main.Label2.Text += " " & ALine(u) & " |"
                main.Label2.Text += ALine(u)
                If u = ALine.Length + 1 Then
                    main.Label2.Text = main.Label2.Text.Substring(0, main.Label2.Text.LastIndexOf("|"))
                End If
            Next
            main.Label2.Text += vbCrLf & "--------------------------------------------------" & vbCrLf
            For u = 0 To BLine.Length - 1
                LineB.Add(BLine(u))
                'main.Label2.Text += " " & BLine(u) & " |"
                main.Label2.Text += BLine(u)
                If u = BLine.Length + 1 Then
                    main.Label2.Text = main.Label2.Text.Substring(0, main.Label2.Text.LastIndexOf("|"))
                End If
            Next
        End Sub

        Private Function engine(ByVal completeString As String)
            Dim u As Integer = completeString.Length
            Dim bufferString As String = completeString
            Dim outputString As String = Nothing
            Dim doesLineContainChar As Boolean = False

            For Each cryptchar In completeString
                If LineA.IndexOf(cryptchar.ToString) = -1 Then
                    outputString += cryptchar
                Else
                    outputString += LineB(LineA.IndexOf(cryptchar.ToString))
                End If
            Next
            Return outputString
        End Function
    End Class

    Public Class ROT5_cypher
        Private Shared ALine As Array = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0"}
        Private Shared BLine As Array = {"6", "7", "8", "9", "0", "1", "2", "3", "4", "5"}
        Private Shared LineA As New ArrayList
        Private Shared LineB As New ArrayList
        Private WithEvents encrypt_button As New Button
        Private Sub encrypt_button_Click() Handles encrypt_button.Click
            Dim b As New ROT5_cypher
            main.TextBox2.Text = b.engine(main.TextBox1.Text)
        End Sub
        Public Shared Sub opener(ByVal form As Form)
            'set textbox sentence
            For Each ctrl In form.Controls
                If ctrl.name = "GroupBox1" Then
                    For Each i In ctrl.controls
                        If i.name = "TextBox1" Then
                            i.text = "ROT5 is a practice similar to ROT13 that applies to numeric digits (0 to 9) 0123456789"
                        End If
                    Next
                End If
                If ctrl.name = "cypherbutton" Then
                    form.Controls.Remove(ctrl)
                End If
            Next

            'create new button
            Dim s As New ROT5_cypher
            With s.encrypt_button
                .Text = "ROT5 Cypher"
                .Location = New Point(347, 50)
                .Size = New Size(143, 26)
                .Name = "cypherbutton"
            End With
            form.Controls.Add(s.encrypt_button)

            'Fill Label
            LineA.Clear()
            LineB.Clear()
            main.Label2.Text = Nothing
            For u = 0 To ALine.Length - 1
                LineA.Add(ALine(u))
                main.Label2.Text += " " & ALine(u) & " |"
                If u = ALine.Length - 1 Then
                    main.Label2.Text = main.Label2.Text.Substring(0, main.Label2.Text.LastIndexOf("|"))
                End If
            Next
            main.Label2.Text += vbCrLf & "---------------------------------------" & vbCrLf
            For u = 0 To BLine.Length - 1
                LineB.Add(BLine(u))
                main.Label2.Text += " " & BLine(u) & " |"
                If u = BLine.Length - 1 Then
                    main.Label2.Text = main.Label2.Text.Substring(0, main.Label2.Text.LastIndexOf("|"))
                End If
            Next
        End Sub

        Private Function engine(ByVal completeString As String)
            Dim outputString As String = Nothing

            For Each cryptchar In completeString
                If LineA.IndexOf(cryptchar.ToString) = -1 Then
                    outputString += cryptchar
                Else
                    outputString += LineB(LineA.IndexOf(cryptchar.ToString))
                End If
            Next
            Return outputString
        End Function
    End Class

    Public Class ROT18_cypher
        Private Shared Aline As Array = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "1", "2", "3", "4", "5"}
        Private Shared Bline As Array = {"N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "6", "7", "8", "9", "0"}
        Private Shared LineA As New ArrayList
        Private Shared LineB As New ArrayList
        Private WithEvents encrypt_button As New Button
        Private Sub encrypt_button_Click() Handles encrypt_button.Click
            Dim b As New ROT18_cypher
            main.TextBox2.Text = b.engine(main.TextBox1.Text.ToString)
        End Sub
        Public Shared Sub opener(ByVal form As Form)
            'set textbox sentence
            For Each ctrl In form.Controls
                If ctrl.name = "GroupBox1" Then
                    For Each i In ctrl.controls
                        If i.name = "TextBox1" Then
                            i.text = "ROT18 Is a combination of ROT5 and ROT13 - 123456790"
                        End If
                    Next
                End If
                If ctrl.name = "cypherbutton" Then
                    form.Controls.Remove(ctrl)
                End If
            Next

            'create new button
            Dim s As New ROT18_cypher
            With s.encrypt_button
                .Text = "ROT18 Cypher"
                .Location = New Point(347, 50)
                .Size = New Size(143, 26)
                .Name = "cypherbutton"
            End With
            form.Controls.Add(s.encrypt_button)

            'Fill Label
            LineA.Clear()
            LineB.Clear()
            main.Label2.Text = Nothing
            For u = 0 To Aline.Length - 1
                LineA.Add(Aline(u))
                main.Label2.Text += " " & Aline(u) & " |"
                If u = Aline.Length - 1 Then
                    main.Label2.Text = main.Label2.Text.Substring(0, main.Label2.Text.LastIndexOf("|"))
                End If
            Next
            main.Label2.Text += vbCrLf & "--------------------------------------------------" & vbCrLf
            For u = 0 To Bline.Length - 1
                LineB.Add(Bline(u))
                main.Label2.Text += " " & Bline(u) & " |"
                If u = Bline.Length - 1 Then
                    main.Label2.Text = main.Label2.Text.Substring(0, main.Label2.Text.LastIndexOf("|"))
                End If
            Next
        End Sub
        Public Function engine(ByVal completeString As String)
            Dim outputString As String = Nothing

            For Each cryptchar In completeString
                If LineA.IndexOf(cryptchar.ToString) = -1 And LineB.IndexOf(cryptchar.ToString) = -1 Then
                    outputString += cryptchar.ToString
                Else
                    If LineA.IndexOf(cryptchar.ToString) = -1 Then
                        outputString += LineA(LineB.IndexOf(cryptchar.ToString))
                    End If
                    If LineB.IndexOf(cryptchar.ToString) = -1 Then
                        outputString += LineB(LineA.IndexOf(cryptchar.ToString))
                    End If
                End If
            Next
            Return outputString
        End Function
    End Class

    Public Class Rotate_by_cypher
        Private Shared ALine As Array = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
        Private Shared LineA As New ArrayList
        Private WithEvents encrypt_button As New Button
        Private Sub encrypt_button_Click() Handles encrypt_button.Click
            Dim b As New Rotate_by_cypher
            Dim rot_by = InputBox("Rotation by?", myappfullname)
            If IsNumeric(rot_by) Then
                If rot_by >= 0 And rot_by <= 25 Then
                    main.TextBox2.Text = b.engine(main.TextBox1.Text, rot_by)
                Else
                    MsgBox("Please enter only NUMBERS between 0 and 25!", MsgBoxStyle.Information, myappfullname)
                End If
            Else
                MsgBox("Please enter only NUMBERS between 0 and 25!", MsgBoxStyle.Information, myappfullname)
            End If
        End Sub
        Public Shared Sub opener(ByVal form As Form)
            'set textbox sentence
            For Each ctrl In form.Controls
                If ctrl.name = "GroupBox1" Then
                    For Each i In ctrl.controls
                        If i.name = "TextBox1" Then
                            i.text = "Rotate by given places between 0 and 25. Without numeric cypher"
                        End If
                    Next
                End If
                If ctrl.name = "cypherbutton" Then
                    form.Controls.Remove(ctrl)
                End If
            Next

            'create new button
            Dim s As New Rotate_by_cypher
            With s.encrypt_button
                .Text = "Rotate by * Cypher"
                .Location = New Point(347, 50)
                .Size = New Size(143, 26)
                .Name = "cypherbutton"
            End With
            form.Controls.Add(s.encrypt_button)

            'Fill Label
            LineA.Clear()
            main.Label2.Text = "Rotation by given place" & vbCr & vbCr &
                                "Note: If you encrypt by 7, then decryption happens" & vbCr &
                                "by 19 (26 - 7 = 19)"
            For Each i In ALine
                LineA.Add(i)
            Next
        End Sub

        Private Function engine(ByVal completeString As String, ByVal rotation_places As Short)
            Dim outputString As String = Nothing
            Dim cryptcharstate As Boolean = False

            For Each cryptchar In completeString
                'is upper?
                If Char.IsLower(cryptchar.ToString) Then
                    cryptcharstate = True
                    cryptchar = Char.ToUpper(cryptchar)
                Else
                    cryptcharstate = False
                End If

                If LineA.IndexOf(cryptchar.ToString) = -1 Then
                    outputString += cryptchar
                Else
                    If cryptcharstate = True Then
                        'check rotation
                        If LineA.IndexOf(cryptchar.ToString) + rotation_places <= 25 Then
                            outputString += Char.ToLower(LineA(LineA.IndexOf(cryptchar.ToString) + rotation_places))
                        Else
                            outputString += Char.ToLower(LineA((LineA.IndexOf(cryptchar.ToString) + rotation_places) - 26))
                        End If

                    Else
                        'check rotation
                        If LineA.IndexOf(cryptchar.ToString) + rotation_places <= 25 Then
                            outputString += LineA(LineA.IndexOf(cryptchar.ToString) + rotation_places)
                        Else
                            outputString += LineA((LineA.IndexOf(cryptchar.ToString) + rotation_places) - 26)
                        End If
                    End If
                End If


            Next
            Return outputString
        End Function
    End Class


End Module
