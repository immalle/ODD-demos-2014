Public Enum Soort
    Harten
    Ruiten
    Klaveren
    Schoppen
End Enum

Public Enum Waarde
    Aas
    Twee
    Drie
    Vier
    Vijf
    Zes
    Zeven
    Acht
    Negen
    Tien
    Boer
    Dame
    Heer
End Enum
Public Class Kaart
    Private _Soort As Soort
    Private _Waarde As Waarde
    Private _WaardeB As Integer
    Private _WaardeC As Integer

    Public Property WaardeB() As Integer
        Get
            Return _WaardeB
        End Get
        Set(ByVal value As Integer)
            _WaardeB = value
        End Set
    End Property

    Public Property WaardeC() As Integer
        Get
            Return _WaardeC
        End Get
        Set(ByVal value As Integer)
            _WaardeC = value
        End Set
    End Property

    Public Property Soort() As Soort
        Get
            Return _Soort
        End Get
        Set(ByVal value As Soort)
            _Soort = Soort
        End Set
    End Property

    Public Property Waarde() As Waarde
        Get
            Return _Waarde
        End Get
        Set(ByVal value As Waarde)
            _Waarde = value
        End Set
    End Property

    Public Sub New(ByVal soort As Soort, ByVal waarde As Waarde)
        _Soort = soort
        _Waarde = waarde
        SetWaardeB()
    End Sub

    Public Sub SetWaardeB()
        Select Case Waarde
            Case Is = Kaarten.Waarde.Aas
                WaardeB = 1
                WaardeC = 11
            Case Is = Kaarten.Waarde.Twee
                WaardeB = 2
            Case Is = Kaarten.Waarde.Drie
                WaardeB = 3
            Case Is = Kaarten.Waarde.Vier
                WaardeB = 4
            Case Is = Kaarten.Waarde.Vijf
                WaardeB = 5
            Case Is = Kaarten.Waarde.Zes
                WaardeB = 6
            Case Is = Kaarten.Waarde.Zeven
                WaardeB = 7
            Case Is = Kaarten.Waarde.Acht
                WaardeB = 8
            Case Is = Kaarten.Waarde.Negen
                WaardeB = 9
            Case Is = Kaarten.Waarde.Tien
                WaardeB = 10
            Case Is = Kaarten.Waarde.Boer
                WaardeB = 10
            Case Is = Kaarten.Waarde.Dame
                WaardeB = 10
            Case Is = Kaarten.Waarde.Heer
                WaardeB = 10
        End Select
    End Sub

End Class

