<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnNieuw = New System.Windows.Forms.Button
        Me.btnVorige = New System.Windows.Forms.Button
        Me.btnVolgende = New System.Windows.Forms.Button
        Me.btnvolgende2 = New System.Windows.Forms.Button
        Me.btnvorige2 = New System.Windows.Forms.Button
        Me.btnStop = New System.Windows.Forms.Button
        Me.picSpelerTwee = New System.Windows.Forms.PictureBox
        Me.picSpelerEen = New System.Windows.Forms.PictureBox
        Me.lblPunten = New System.Windows.Forms.Label
        Me.btnAfsluiten = New System.Windows.Forms.Button
        Me.lblPtnComp = New System.Windows.Forms.Label
        Me.lblPunten2 = New System.Windows.Forms.Label
        Me.lblPtnComp2 = New System.Windows.Forms.Label
        Me.btnnieuwgame = New System.Windows.Forms.Button
        CType(Me.picSpelerTwee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSpelerEen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnNieuw
        '
        Me.btnNieuw.Location = New System.Drawing.Point(322, 305)
        Me.btnNieuw.Name = "btnNieuw"
        Me.btnNieuw.Size = New System.Drawing.Size(94, 23)
        Me.btnNieuw.TabIndex = 0
        Me.btnNieuw.Text = "Nieuwe kaart"
        Me.btnNieuw.UseVisualStyleBackColor = True
        '
        'btnVorige
        '
        Me.btnVorige.Enabled = False
        Me.btnVorige.Location = New System.Drawing.Point(35, 293)
        Me.btnVorige.Name = "btnVorige"
        Me.btnVorige.Size = New System.Drawing.Size(75, 23)
        Me.btnVorige.TabIndex = 3
        Me.btnVorige.Text = "Vorige"
        Me.btnVorige.UseVisualStyleBackColor = True
        '
        'btnVolgende
        '
        Me.btnVolgende.Enabled = False
        Me.btnVolgende.Location = New System.Drawing.Point(187, 293)
        Me.btnVolgende.Name = "btnVolgende"
        Me.btnVolgende.Size = New System.Drawing.Size(75, 23)
        Me.btnVolgende.TabIndex = 4
        Me.btnVolgende.Text = "Volgende"
        Me.btnVolgende.UseVisualStyleBackColor = True
        '
        'btnvolgende2
        '
        Me.btnvolgende2.Enabled = False
        Me.btnvolgende2.Location = New System.Drawing.Point(713, 293)
        Me.btnvolgende2.Name = "btnvolgende2"
        Me.btnvolgende2.Size = New System.Drawing.Size(75, 23)
        Me.btnvolgende2.TabIndex = 6
        Me.btnvolgende2.Text = "Volgende"
        Me.btnvolgende2.UseVisualStyleBackColor = True
        '
        'btnvorige2
        '
        Me.btnvorige2.Enabled = False
        Me.btnvorige2.Location = New System.Drawing.Point(536, 293)
        Me.btnvorige2.Name = "btnvorige2"
        Me.btnvorige2.Size = New System.Drawing.Size(75, 23)
        Me.btnvorige2.TabIndex = 5
        Me.btnvorige2.Text = "Vorige"
        Me.btnvorige2.UseVisualStyleBackColor = True
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(322, 356)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(94, 23)
        Me.btnStop.TabIndex = 7
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'picSpelerTwee
        '
        Me.picSpelerTwee.ErrorImage = Nothing
        Me.picSpelerTwee.InitialImage = Global.Kaarten.My.Resources.Resources.cl1
        Me.picSpelerTwee.Location = New System.Drawing.Point(624, 79)
        Me.picSpelerTwee.Name = "picSpelerTwee"
        Me.picSpelerTwee.Size = New System.Drawing.Size(136, 190)
        Me.picSpelerTwee.TabIndex = 2
        Me.picSpelerTwee.TabStop = False
        '
        'picSpelerEen
        '
        Me.picSpelerEen.ErrorImage = Nothing
        Me.picSpelerEen.InitialImage = Global.Kaarten.My.Resources.Resources.cl1
        Me.picSpelerEen.Location = New System.Drawing.Point(89, 79)
        Me.picSpelerEen.Name = "picSpelerEen"
        Me.picSpelerEen.Size = New System.Drawing.Size(136, 190)
        Me.picSpelerEen.TabIndex = 1
        Me.picSpelerEen.TabStop = False
        '
        'lblPunten
        '
        Me.lblPunten.AutoSize = True
        Me.lblPunten.Location = New System.Drawing.Point(86, 356)
        Me.lblPunten.Name = "lblPunten"
        Me.lblPunten.Size = New System.Drawing.Size(0, 13)
        Me.lblPunten.TabIndex = 8
        '
        'btnAfsluiten
        '
        Me.btnAfsluiten.Location = New System.Drawing.Point(322, 409)
        Me.btnAfsluiten.Name = "btnAfsluiten"
        Me.btnAfsluiten.Size = New System.Drawing.Size(94, 23)
        Me.btnAfsluiten.TabIndex = 9
        Me.btnAfsluiten.Text = "Afsluiten"
        Me.btnAfsluiten.UseVisualStyleBackColor = True
        '
        'lblPtnComp
        '
        Me.lblPtnComp.AutoSize = True
        Me.lblPtnComp.Location = New System.Drawing.Point(644, 380)
        Me.lblPtnComp.Name = "lblPtnComp"
        Me.lblPtnComp.Size = New System.Drawing.Size(0, 13)
        Me.lblPtnComp.TabIndex = 10
        '
        'lblPunten2
        '
        Me.lblPunten2.AutoSize = True
        Me.lblPunten2.Location = New System.Drawing.Point(170, 356)
        Me.lblPunten2.Name = "lblPunten2"
        Me.lblPunten2.Size = New System.Drawing.Size(0, 13)
        Me.lblPunten2.TabIndex = 11
        Me.lblPunten2.Visible = False
        '
        'lblPtnComp2
        '
        Me.lblPtnComp2.AutoSize = True
        Me.lblPtnComp2.Location = New System.Drawing.Point(710, 380)
        Me.lblPtnComp2.Name = "lblPtnComp2"
        Me.lblPtnComp2.Size = New System.Drawing.Size(0, 13)
        Me.lblPtnComp2.TabIndex = 12
        Me.lblPtnComp2.Visible = False
        '
        'btnnieuwgame
        '
        Me.btnnieuwgame.Location = New System.Drawing.Point(324, 453)
        Me.btnnieuwgame.Name = "btnnieuwgame"
        Me.btnnieuwgame.Size = New System.Drawing.Size(91, 25)
        Me.btnnieuwgame.TabIndex = 13
        Me.btnnieuwgame.Text = "Nieuw game"
        Me.btnnieuwgame.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1077, 573)
        Me.Controls.Add(Me.btnnieuwgame)
        Me.Controls.Add(Me.lblPtnComp2)
        Me.Controls.Add(Me.lblPunten2)
        Me.Controls.Add(Me.lblPtnComp)
        Me.Controls.Add(Me.btnAfsluiten)
        Me.Controls.Add(Me.lblPunten)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.btnvolgende2)
        Me.Controls.Add(Me.btnvorige2)
        Me.Controls.Add(Me.btnVolgende)
        Me.Controls.Add(Me.btnVorige)
        Me.Controls.Add(Me.picSpelerTwee)
        Me.Controls.Add(Me.picSpelerEen)
        Me.Controls.Add(Me.btnNieuw)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.picSpelerTwee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSpelerEen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnNieuw As System.Windows.Forms.Button
    Friend WithEvents picSpelerEen As System.Windows.Forms.PictureBox
    Friend WithEvents picSpelerTwee As System.Windows.Forms.PictureBox
    Friend WithEvents btnVorige As System.Windows.Forms.Button
    Friend WithEvents btnVolgende As System.Windows.Forms.Button
    Friend WithEvents btnvolgende2 As System.Windows.Forms.Button
    Friend WithEvents btnvorige2 As System.Windows.Forms.Button
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents lblPunten As System.Windows.Forms.Label
    Friend WithEvents btnAfsluiten As System.Windows.Forms.Button
    Friend WithEvents lblPtnComp As System.Windows.Forms.Label
    Friend WithEvents lblPunten2 As System.Windows.Forms.Label
    Friend WithEvents lblPtnComp2 As System.Windows.Forms.Label
    Friend WithEvents btnnieuwgame As System.Windows.Forms.Button

End Class
