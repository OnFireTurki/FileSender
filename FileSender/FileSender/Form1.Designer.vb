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
        Me.FileNameBox = New System.Windows.Forms.TextBox()
        Me.LoadFileButton = New System.Windows.Forms.Button()
        Me.TokenBox = New System.Windows.Forms.TextBox()
        Me.IDBox = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'FileNameBox
        '
        Me.FileNameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FileNameBox.Location = New System.Drawing.Point(12, 12)
        Me.FileNameBox.Name = "FileNameBox"
        Me.FileNameBox.Size = New System.Drawing.Size(281, 20)
        Me.FileNameBox.TabIndex = 0
        Me.FileNameBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LoadFileButton
        '
        Me.LoadFileButton.AllowDrop = True
        Me.LoadFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LoadFileButton.Location = New System.Drawing.Point(299, 12)
        Me.LoadFileButton.Name = "LoadFileButton"
        Me.LoadFileButton.Size = New System.Drawing.Size(34, 21)
        Me.LoadFileButton.TabIndex = 1
        Me.LoadFileButton.Text = "..."
        Me.LoadFileButton.UseVisualStyleBackColor = True
        '
        'TokenBox
        '
        Me.TokenBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TokenBox.Location = New System.Drawing.Point(12, 39)
        Me.TokenBox.Name = "TokenBox"
        Me.TokenBox.Size = New System.Drawing.Size(321, 20)
        Me.TokenBox.TabIndex = 2
        Me.TokenBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'IDBox
        '
        Me.IDBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.IDBox.Location = New System.Drawing.Point(12, 65)
        Me.IDBox.Name = "IDBox"
        Me.IDBox.Size = New System.Drawing.Size(321, 20)
        Me.IDBox.TabIndex = 3
        Me.IDBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(12, 112)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(321, 23)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Send"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(12, 141)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(321, 109)
        Me.RichTextBox1.TabIndex = 5
        Me.RichTextBox1.Text = ""
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(12, 91)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(88, 17)
        Me.RadioButton1.TabIndex = 6
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Telegram Bot"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(222, 91)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(111, 17)
        Me.RadioButton2.TabIndex = 7
        Me.RadioButton2.Text = "Discord Webhook"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(14, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Token :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(14, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "ID :"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(345, 262)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.IDBox)
        Me.Controls.Add(Me.TokenBox)
        Me.Controls.Add(Me.LoadFileButton)
        Me.Controls.Add(Me.FileNameBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form1"
        Me.Text = "txtFileSender"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents FileNameBox As TextBox
    Friend WithEvents LoadFileButton As Button
    Friend WithEvents TokenBox As TextBox
    Friend WithEvents IDBox As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
