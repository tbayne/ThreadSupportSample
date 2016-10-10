<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbValue1 = New System.Windows.Forms.TextBox()
        Me.tbValue2 = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnIncrementCounter1 = New System.Windows.Forms.Button()
        Me.btnIncrementCounter2 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(54, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Counter 1:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(54, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Counter 2:"
        '
        'tbValue1
        '
        Me.tbValue1.BackColor = System.Drawing.Color.Yellow
        Me.tbValue1.Location = New System.Drawing.Point(117, 32)
        Me.tbValue1.Name = "tbValue1"
        Me.tbValue1.Size = New System.Drawing.Size(100, 20)
        Me.tbValue1.TabIndex = 2
        '
        'tbValue2
        '
        Me.tbValue2.BackColor = System.Drawing.Color.PaleTurquoise
        Me.tbValue2.Location = New System.Drawing.Point(117, 64)
        Me.tbValue2.Name = "tbValue2"
        Me.tbValue2.Size = New System.Drawing.Size(100, 20)
        Me.tbValue2.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnStop)
        Me.GroupBox1.Controls.Add(Me.btnStart)
        Me.GroupBox1.Location = New System.Drawing.Point(287, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(175, 100)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " Thread Control "
        '
        'btnStop
        '
        Me.btnStop.BackColor = System.Drawing.Color.IndianRed
        Me.btnStop.Location = New System.Drawing.Point(70, 55)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(75, 23)
        Me.btnStop.TabIndex = 7
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = False
        '
        'btnStart
        '
        Me.btnStart.BackColor = System.Drawing.Color.PaleGreen
        Me.btnStart.Location = New System.Drawing.Point(70, 23)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(75, 23)
        Me.btnStart.TabIndex = 6
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = False
        '
        'btnIncrementCounter1
        '
        Me.btnIncrementCounter1.BackColor = System.Drawing.Color.Yellow
        Me.btnIncrementCounter1.Enabled = False
        Me.btnIncrementCounter1.Location = New System.Drawing.Point(65, 162)
        Me.btnIncrementCounter1.Name = "btnIncrementCounter1"
        Me.btnIncrementCounter1.Size = New System.Drawing.Size(152, 23)
        Me.btnIncrementCounter1.TabIndex = 7
        Me.btnIncrementCounter1.Text = "Increment Counter 1"
        Me.btnIncrementCounter1.UseVisualStyleBackColor = False
        '
        'btnIncrementCounter2
        '
        Me.btnIncrementCounter2.BackColor = System.Drawing.Color.PaleTurquoise
        Me.btnIncrementCounter2.Enabled = False
        Me.btnIncrementCounter2.Location = New System.Drawing.Point(65, 202)
        Me.btnIncrementCounter2.Name = "btnIncrementCounter2"
        Me.btnIncrementCounter2.Size = New System.Drawing.Size(152, 23)
        Me.btnIncrementCounter2.TabIndex = 8
        Me.btnIncrementCounter2.Text = "Increment Counter 2"
        Me.btnIncrementCounter2.UseVisualStyleBackColor = False
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(613, 268)
        Me.Controls.Add(Me.btnIncrementCounter2)
        Me.Controls.Add(Me.btnIncrementCounter1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.tbValue2)
        Me.Controls.Add(Me.tbValue1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "MainForm"
        Me.Text = "Threading Support Sample Application"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbValue1 As System.Windows.Forms.TextBox
    Friend WithEvents tbValue2 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents btnIncrementCounter1 As System.Windows.Forms.Button
    Friend WithEvents btnIncrementCounter2 As System.Windows.Forms.Button

End Class
