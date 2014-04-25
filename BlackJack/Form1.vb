Public Class Form1
    Public spelershand As New Hand
    Public pak As New Pak
    Public computerhand As New Hand
    Dim intAantal As Integer = -1
    Dim intAantalComp As Integer = -1
    Dim intPunten As Integer = 0
    Dim intPtnComp As Integer = 0
    Dim intPlaatsInPicBox As Integer
    Dim intPlaatsInPicBoxComp As Integer = 0
    Dim ptn2 As Integer

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Show()
        pak.SchudBoek()
        MessageBox.Show("Welkom bij blackjack, klik op nieuwe kaart om te beginnen")

    End Sub
    

    Private Sub btnNieuw_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNieuw.Click

        Speler()

    End Sub

    Private Sub btnVorige_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVorige.Click

        intPlaatsInPicBox -= 1
        AfbNaBladeren()
        CheckKnoppen()

    End Sub

    Private Sub btnVolgende_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVolgende.Click

        intPlaatsInPicBox += 1
        AfbNaBladeren()
        CheckKnoppen()

    End Sub

    Private Sub PuntenTelling(ByRef ptn As Integer, ByVal hand As Hand, ByVal aantalKaarten As Integer)
        

        ptn += hand.HaalKaartOpPlaats(aantalKaarten).WaardeB
        ptn2 += hand.HaalKaartOpPlaats(aantalKaarten).WaardeB

        If hand.HaalKaartOpPlaats(0).Soort = spelershand.HaalKaartOpPlaats(0).Soort And hand.HaalKaartOpPlaats(0).Waarde = spelershand.HaalKaartOpPlaats(0).Waarde Then
            If hand.HaalKaartOpPlaats(aantalKaarten).Waarde = Waarde.Aas Then
                lblPunten2.Visible = True
                If ptn2 + 10 < 21 Then
                    ptn2 += 10
                End If
            End If
            lblPunten.Text = ptn.ToString
            lblPunten2.Text = (ptn2).ToString
            If ptn > 21 Then
                Kapot()
                MessageBox.Show("De computer heeft gewonnen want de speler is kapot")
            End If
        Else
            If hand.HaalKaartOpPlaats(aantalKaarten).Waarde = Waarde.Aas Then
                lblPtnComp2.Visible = True
                If ptn2 + 10 < 21 Then
                    ptn2 += 10
                End If
            End If
            lblPtnComp.Text = ptn.ToString
            lblPtnComp2.Text = (ptn2).ToString
            If ptn > 21 Then
                Kapot()

            End If
            End If
    End Sub

    Private Sub Kapot()
        btnNieuw.Enabled = False
        btnStop.Enabled = False
    End Sub

    Private Sub CheckKnoppen()

        'Om na te kijken of de knoppen "Vorige" en "Volgende" enabled moeten zijn
        Select Case intPlaatsInPicBox
            Case Is = 0
                btnVorige.Enabled = False
                If intAantal > 0 Then
                    btnVolgende.Enabled = True
                Else
                    btnVolgende.Enabled = False
                End If
            Case Is = intAantal
                btnVolgende.Enabled = False
                btnVorige.Enabled = True
            Case Else
                btnVolgende.Enabled = True
                btnVorige.Enabled = True
        End Select
    End Sub

    Private Sub CheckKnoppenComp()

        'Om na te kijken of de knoppen "Vorige" en "Volgende" enabled moeten zijn

        Select Case intPlaatsInPicBoxComp
            Case Is = 0
                btnvorige2.Enabled = False
                If intAantalComp > 0 Then
                    btnvolgende2.Enabled = True
                Else
                    btnvolgende2.Enabled = False
                End If
            Case Is = intAantalComp
                btnvolgende2.Enabled = False
                btnvorige2.Enabled = True
            Case Else
                btnvolgende2.Enabled = True
                btnvorige2.Enabled = True
        End Select

    End Sub

    Private Sub AfbNaBladeren()
        'Zet de afbeelding van de kaart goed na het bladeren in de gekregen kaarten
        picSpelerEen.Image = spelershand.ShowImage(intPlaatsInPicBox)
    End Sub

    Private Sub AfbNaBladerenComp()
        'Zet de afbeelding van de kaart goed na het bladeren in de gekregen kaarten
        picSpelerTwee.Image = computerhand.ShowImage(intPlaatsInPicBoxComp)
    End Sub

    Private Sub btnAfsluiten_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAfsluiten.Click
        Me.Close()
    End Sub

    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        ptn2 = 0
        Computer()
        Winnaar()
    End Sub

    Private Sub Computer()
        While (intPtnComp <= (intPunten And Integer.Parse(lblPunten2.Text))) Or (ptn2 <= (intPunten And Integer.Parse(lblPunten2.Text)) And ptn2 < 21)
            'Dim kaart As New Kaart(Soort.Harten, Waarde.Aas)
            'computerhand.VoegKaartToe(kaart)
            pak.Delen(computerhand, 1)

            intAantalComp += 1
            intPlaatsInPicBoxComp = intAantalComp

            picSpelerTwee.Image = computerhand.ShowImage(intAantalComp)

            PuntenTelling(intPtnComp, computerhand, intAantalComp)
        End While

        CheckKnoppenComp()
        btnNieuw.Enabled = False
        btnStop.Enabled = False
        MessageBox.Show(computerhand.Grootte.ToString)

    End Sub

    Private Sub Speler()
        'Dim kaart As New Kaart(Soort.Harten, Waarde.Aas)
        pak.Delen(spelershand, 1)
        'spelershand.VoegKaartToe(kaart)

        intAantal += 1
        intPlaatsInPicBox = intAantal

        picSpelerEen.Image = spelershand.ShowImage(intAantal)

        'Messagebox voor de soort en de waarde van de nieuwe kaart
        spelershand.DrukAf(spelershand.HaalKaartOpPlaats(intAantal))


        'Tonen van punten
        PuntenTelling(intPunten, spelershand, intAantal)

        CheckKnoppen()

    End Sub


    Private Sub btnvorige2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnvorige2.Click
        intPlaatsInPicBoxComp -= 1
        AfbNaBladerenComp()
        CheckKnoppenComp()
    End Sub

    Private Sub btnvolgende2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnvolgende2.Click
        intPlaatsInPicBoxComp += 1
        AfbNaBladerenComp()
        CheckKnoppenComp()
    End Sub

    Private Sub Winnaar()

        If ((intPunten > intPtnComp) And (intPunten <= 21)) Or (ptn2 > intPtnComp And ptn2 <= 21) Or (intPtnComp > 21) Or ((Integer.Parse(lblPunten2.Text) > intPtnComp) And (Integer.Parse(lblPunten2.Text) > ptn2) And (Integer.Parse(lblPunten2.Text) <= 21)) Then
            MessageBox.Show("De speler heeft gewonnen")
        Else
            MessageBox.Show("De computer heeft gewonnen")
        End If

    End Sub

    Private Sub btnnieuwgame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnieuwgame.Click
        Controls.Clear()
        InitializeComponent()
        Show()
        spelershand.clear()
        pak.clear()
        computerhand.clear()
        intAantal = -1
        intAantalComp = -1
        intPunten = 0
        intPtnComp = 0
        intPlaatsInPicBox = 0
        intPlaatsInPicBoxComp = 0
        ptn2 = 0
        pak.SchudBoek()

    End Sub
End Class
