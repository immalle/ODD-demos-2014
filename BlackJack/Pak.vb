Public Class Pak
    Private _PakKaarten As New ArrayList

    Public ReadOnly Property Aantal() As Integer
        Get
            Return _PakKaarten.Count
        End Get
    End Property

    Default Public ReadOnly Property Speelkaart(ByVal index As Integer) As Kaart
        Get
            If (index >= 0 And index < _PakKaarten.Count) Then
                Return CType(_PakKaarten(index), Kaart)
            Else
                Throw New ArgumentOutOfRangeException("Index ligt buiten het bereik")
            End If
        End Get
    End Property

    Public Sub New()
        For i = 0 To 3
            For j = 0 To 12
                _PakKaarten.Add(New Kaart(CType(i, Soort), CType(j, Waarde)))
            Next
        Next
    End Sub
    Public Sub clear()
        _PakKaarten.Clear()

        For i = 0 To 3
            For j = 0 To 12
                _PakKaarten.Add(New Kaart(CType(i, Soort), CType(j, Waarde)))
            Next
        Next
    End Sub
    Public Sub SchudBoek()

        Dim tempPak As New ArrayList
        Dim k As Kaart
        Dim rnd As New Random
        Dim i, plaats As Integer

        For i = 0 To _PakKaarten.Count - 1

            plaats = rnd.Next(0, _PakKaarten.Count)
            k = CType(_PakKaarten(plaats), Kaart)
            tempPak.Add(k)
            _PakKaarten.Remove(k)
        Next
        _PakKaarten = tempPak
    End Sub

    Public Sub Delen(ByVal hand As Hand, ByVal aantal As Integer)

        Dim i As Integer = 0
        Dim plaats As Integer = 0

        Do Until i = aantal
            hand.VoegKaartToe(CType(_PakKaarten(plaats), Kaart))
            _PakKaarten.RemoveAt(plaats)
            i += 1
        Loop


        'Originele manier, klopt niet
        '
        'For i = 0 To aantal
        '    hand.VoegKaartToe(CType(_PakKaarten(i), Kaart))
        '    _PakKaarten.RemoveAt(i)
        'Next
    End Sub

End Class
