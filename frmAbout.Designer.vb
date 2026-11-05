<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbout
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
        picGrocery = New PictureBox()
        lblAbout1 = New Label()
        txtAbout = New TextBox()
        CType(picGrocery, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' picGrocery
        ' 
        picGrocery.Image = My.Resources.Resources.GroceryPic
        picGrocery.Location = New Point(12, 12)
        picGrocery.Name = "picGrocery"
        picGrocery.Size = New Size(126, 266)
        picGrocery.SizeMode = PictureBoxSizeMode.StretchImage
        picGrocery.TabIndex = 0
        picGrocery.TabStop = False
        ' 
        ' lblAbout1
        ' 
        lblAbout1.AutoSize = True
        lblAbout1.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblAbout1.Location = New Point(160, 12)
        lblAbout1.Name = "lblAbout1"
        lblAbout1.Size = New Size(163, 119)
        lblAbout1.TabIndex = 1
        lblAbout1.Text = "The Happy Hopes Project" & vbCrLf & vbCrLf & "Version: ICT3615 2026  v1" & vbCrLf & vbCrLf & "Dr R van de Merwe" & vbCrLf & vbCrLf & "ICT3615_2026"
        ' 
        ' txtAbout
        ' 
        txtAbout.Font = New Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtAbout.Location = New Point(160, 146)
        txtAbout.Multiline = True
        txtAbout.Name = "txtAbout"
        txtAbout.Size = New Size(257, 132)
        txtAbout.TabIndex = 3
        ' 
        ' frmAbout
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        BackColor = SystemColors.ActiveCaption
        ClientSize = New Size(442, 290)
        Controls.Add(txtAbout)
        Controls.Add(lblAbout1)
        Controls.Add(picGrocery)
        DoubleBuffered = True
        Enabled = False
        Name = "frmAbout"
        Text = "About"
        CType(picGrocery, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents picGrocery As PictureBox
    Friend WithEvents lblAbout1 As Label
    Friend WithEvents txtAbout As TextBox
End Class
