Public Class Hand

    Private _Hand As New ArrayList
    Private _GrootteHand As Integer

    Public ReadOnly Property Grootte As Integer
        Get
            Return _Hand.Count
        End Get
    End Property

    Public ReadOnly Property HaalKaartOpPlaats(ByVal index As Integer) As Kaart
        Get
            If index >= 0 And index < _Hand.Count Then
                Return CType(_Hand(index), Kaart)
            Else
                Throw New ArgumentOutOfRangeException("Index ligt buiten het bereik")
            End If
        End Get
    End Property

    Public Sub VoegKaartToe(ByVal k As Kaart)
        _Hand.Add(k)
    End Sub

    Public Sub DrukAf()
        For i = 0 To _Hand.Count - 1
            MessageBox.Show(CType(_Hand(i), Kaart).Soort.ToString & " " & CType(_Hand(i), Kaart).Waarde.ToString)
        Next
    End Sub

    Public Sub clear()
        _Hand.Clear()
    End Sub

    Public Sub DrukAf(ByVal kaart As Kaart)
        MessageBox.Show(kaart.Soort.ToString & " " & kaart.Waarde.ToString)
    End Sub

    Public Function ShowImage(ByVal index As Integer) As Bitmap
        Select Case CType(_Hand(index), Kaart).Waarde
            Case Waarde.Aas

                Select Case CType(_Hand(index), Kaart).Soort
                    Case Soort.Harten
                        Return My.Resources.he1
                    Case Soort.Klaveren
                        Return My.Resources.cl1
                    Case Soort.Schoppen
                        Return My.Resources.sp1
                    Case Soort.Ruiten
                        Return My.Resources.di1
                End Select
            Case Waarde.Twee
                Select Case CType(_Hand(index), Kaart).Soort
                    Case Soort.Harten
                        Return My.Resources.he2
                    Case Soort.Klaveren
                        Return My.Resources.cl2
                    Case Soort.Schoppen
                        Return My.Resources.sp2
                    Case Soort.Ruiten
                        Return My.Resources.di2
                End Select
            Case Waarde.Drie
                Select Case CType(_Hand(index), Kaart).Soort
                    Case Soort.Harten
                        Return My.Resources.he3
                    Case Soort.Klaveren
                        Return My.Resources.cl3
                    Case Soort.Schoppen
                        Return My.Resources.sp3
                    Case Soort.Ruiten
                        Return My.Resources.di3
                End Select
            Case Waarde.Vier
                Select Case CType(_Hand(index), Kaart).Soort
                    Case Soort.Harten
                        Return My.Resources.he4
                    Case Soort.Klaveren
                        Return My.Resources.cl4
                    Case Soort.Schoppen
                        Return My.Resources.sp4
                    Case Soort.Ruiten
                        Return My.Resources.di4
                End Select
            Case Waarde.Vijf
                Select Case CType(_Hand(index), Kaart).Soort
                    Case Soort.Harten
                        Return My.Resources.he5
                    Case Soort.Klaveren
                        Return My.Resources.cl5
                    Case Soort.Schoppen
                        Return My.Resources.sp5
                    Case Soort.Ruiten
                        Return My.Resources.di5
                End Select
            Case Waarde.Zes
                Select Case CType(_Hand(index), Kaart).Soort
                    Case Soort.Harten
                        Return My.Resources.he6
                    Case Soort.Klaveren
                        Return My.Resources.cl6
                    Case Soort.Schoppen
                        Return My.Resources.sp6
                    Case Soort.Ruiten
                        Return My.Resources.di6
                End Select
            Case Waarde.Zeven
                Select Case CType(_Hand(index), Kaart).Soort
                    Case Soort.Harten
                        Return My.Resources.he7
                    Case Soort.Klaveren
                        Return My.Resources.cl7
                    Case Soort.Schoppen
                        Return My.Resources.sp7
                    Case Soort.Ruiten
                        Return My.Resources.di7
                End Select
            Case Waarde.Acht
                Select Case CType(_Hand(index), Kaart).Soort
                    Case Soort.Harten
                        Return My.Resources.he8
                    Case Soort.Klaveren
                        Return My.Resources.cl8
                    Case Soort.Schoppen
                        Return My.Resources.sp8
                    Case Soort.Ruiten
                        Return My.Resources.di8
                End Select
            Case Waarde.Negen
                Select Case CType(_Hand(index), Kaart).Soort
                    Case Soort.Harten
                        Return My.Resources.he9
                    Case Soort.Klaveren
                        Return My.Resources.cl9
                    Case Soort.Schoppen
                        Return My.Resources.sp9
                    Case Soort.Ruiten
                        Return My.Resources.di9
                End Select
            Case Waarde.Tien
                Select Case CType(_Hand(index), Kaart).Soort
                    Case Soort.Harten
                        Return My.Resources.he10
                    Case Soort.Klaveren
                        Return My.Resources.cl10
                    Case Soort.Schoppen
                        Return My.Resources.sp10
                    Case Soort.Ruiten
                        Return My.Resources.di10
                End Select
            Case Waarde.Boer
                Select Case CType(_Hand(index), Kaart).Soort
                    Case Soort.Harten
                        Return My.Resources.hej
                    Case Soort.Klaveren
                        Return My.Resources.clj
                    Case Soort.Schoppen
                        Return My.Resources.spj
                    Case Soort.Ruiten
                        Return My.Resources.dij
                End Select
            Case Waarde.Dame
                Select Case CType(_Hand(index), Kaart).Soort
                    Case Soort.Harten
                        Return My.Resources.heq
                    Case Soort.Klaveren
                        Return My.Resources.clq
                    Case Soort.Schoppen
                        Return My.Resources.spq
                    Case Soort.Ruiten
                        Return My.Resources.diq
                End Select
            Case Waarde.Heer
                Select Case CType(_Hand(index), Kaart).Soort
                    Case Soort.Harten
                        Return My.Resources.hek
                    Case Soort.Klaveren
                        Return My.Resources.clk
                    Case Soort.Schoppen
                        Return My.Resources.spk
                    Case Soort.Ruiten
                        Return My.Resources.dik
                End Select
            Case Else
                Return Nothing
        End Select
        Return Nothing
    End Function

End Class
