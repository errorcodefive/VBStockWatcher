<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmControl
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
        Me.lblTicker = New System.Windows.Forms.Label()
        Me.txtTicker = New System.Windows.Forms.TextBox()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.calStart = New System.Windows.Forms.MonthCalendar()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.calEnd = New System.Windows.Forms.MonthCalendar()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblTicker
        '
        Me.lblTicker.AutoSize = True
        Me.lblTicker.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTicker.Location = New System.Drawing.Point(12, 9)
        Me.lblTicker.Name = "lblTicker"
        Me.lblTicker.Size = New System.Drawing.Size(96, 20)
        Me.lblTicker.TabIndex = 0
        Me.lblTicker.Text = "Stock Ticker"
        '
        'txtTicker
        '
        Me.txtTicker.Location = New System.Drawing.Point(16, 32)
        Me.txtTicker.Name = "txtTicker"
        Me.txtTicker.Size = New System.Drawing.Size(165, 20)
        Me.txtTicker.TabIndex = 1
        '
        'lblStartDate
        '
        Me.lblStartDate.AutoSize = True
        Me.lblStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStartDate.Location = New System.Drawing.Point(12, 55)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(83, 20)
        Me.lblStartDate.TabIndex = 2
        Me.lblStartDate.Text = "Start Date"
        '
        'calStart
        '
        Me.calStart.Location = New System.Drawing.Point(16, 75)
        Me.calStart.MaxSelectionCount = 1
        Me.calStart.Name = "calStart"
        Me.calStart.TabIndex = 3
        '
        'lblEndDate
        '
        Me.lblEndDate.AutoSize = True
        Me.lblEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEndDate.Location = New System.Drawing.Point(12, 246)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(77, 20)
        Me.lblEndDate.TabIndex = 4
        Me.lblEndDate.Text = "End Date"
        '
        'calEnd
        '
        Me.calEnd.Location = New System.Drawing.Point(16, 266)
        Me.calEnd.MaxSelectionCount = 1
        Me.calEnd.Name = "calEnd"
        Me.calEnd.TabIndex = 5
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(16, 441)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(227, 41)
        Me.btnUpdate.TabIndex = 6
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'frmControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 861)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.calEnd)
        Me.Controls.Add(Me.lblEndDate)
        Me.Controls.Add(Me.calStart)
        Me.Controls.Add(Me.lblStartDate)
        Me.Controls.Add(Me.txtTicker)
        Me.Controls.Add(Me.lblTicker)
        Me.Name = "frmControl"
        Me.Text = "Controls"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTicker As System.Windows.Forms.Label
    Friend WithEvents txtTicker As System.Windows.Forms.TextBox
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents calStart As System.Windows.Forms.MonthCalendar
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents calEnd As System.Windows.Forms.MonthCalendar
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
End Class
