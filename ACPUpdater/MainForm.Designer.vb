<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
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

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기에서는 수정하지 마세요.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.SelfUpdateButton = New System.Windows.Forms.Button()
        Me.FormCloseButton = New System.Windows.Forms.Button()
        Me.DownloadProgressBar = New System.Windows.Forms.ProgressBar()
        Me.SpeedLabel = New System.Windows.Forms.Label()
        Me.UpdateInformationLabel = New System.Windows.Forms.Label()
        Me.UpdaterVersionLabel = New System.Windows.Forms.Label()
        Me.CurrentDownloadLabel = New System.Windows.Forms.Label()
        Me.AnimationTimer = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'SelfUpdateButton
        '
        Me.SelfUpdateButton.Location = New System.Drawing.Point(529, 12)
        Me.SelfUpdateButton.Name = "SelfUpdateButton"
        Me.SelfUpdateButton.Size = New System.Drawing.Size(109, 23)
        Me.SelfUpdateButton.TabIndex = 1
        Me.SelfUpdateButton.Text = "수동 업데이트"
        Me.SelfUpdateButton.UseVisualStyleBackColor = True
        '
        'FormCloseButton
        '
        Me.FormCloseButton.Location = New System.Drawing.Point(563, 70)
        Me.FormCloseButton.Name = "FormCloseButton"
        Me.FormCloseButton.Size = New System.Drawing.Size(75, 23)
        Me.FormCloseButton.TabIndex = 2
        Me.FormCloseButton.Text = "닫기"
        Me.FormCloseButton.UseVisualStyleBackColor = True
        '
        'DownloadProgressBar
        '
        Me.DownloadProgressBar.Location = New System.Drawing.Point(12, 41)
        Me.DownloadProgressBar.Name = "DownloadProgressBar"
        Me.DownloadProgressBar.Size = New System.Drawing.Size(626, 23)
        Me.DownloadProgressBar.TabIndex = 3
        '
        'SpeedLabel
        '
        Me.SpeedLabel.AutoSize = True
        Me.SpeedLabel.Location = New System.Drawing.Point(12, 16)
        Me.SpeedLabel.Name = "SpeedLabel"
        Me.SpeedLabel.Size = New System.Drawing.Size(31, 15)
        Me.SpeedLabel.TabIndex = 4
        Me.SpeedLabel.Text = "속도"
        '
        'UpdateInformationLabel
        '
        Me.UpdateInformationLabel.AutoSize = True
        Me.UpdateInformationLabel.Location = New System.Drawing.Point(12, 74)
        Me.UpdateInformationLabel.Name = "UpdateInformationLabel"
        Me.UpdateInformationLabel.Size = New System.Drawing.Size(83, 15)
        Me.UpdateInformationLabel.TabIndex = 5
        Me.UpdateInformationLabel.Text = "업데이트 정보"
        '
        'UpdaterVersionLabel
        '
        Me.UpdaterVersionLabel.AutoSize = True
        Me.UpdaterVersionLabel.Location = New System.Drawing.Point(401, 16)
        Me.UpdaterVersionLabel.Name = "UpdaterVersionLabel"
        Me.UpdaterVersionLabel.Size = New System.Drawing.Size(95, 15)
        Me.UpdaterVersionLabel.TabIndex = 6
        Me.UpdaterVersionLabel.Text = "업데이터 버전 : "
        '
        'CurrentDownloadLabel
        '
        Me.CurrentDownloadLabel.AutoSize = True
        Me.CurrentDownloadLabel.Location = New System.Drawing.Point(152, 16)
        Me.CurrentDownloadLabel.Name = "CurrentDownloadLabel"
        Me.CurrentDownloadLabel.Size = New System.Drawing.Size(59, 15)
        Me.CurrentDownloadLabel.TabIndex = 7
        Me.CurrentDownloadLabel.Text = "전체 상황"
        '
        'AnimationTimer
        '
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(650, 104)
        Me.ControlBox = False
        Me.Controls.Add(Me.CurrentDownloadLabel)
        Me.Controls.Add(Me.UpdaterVersionLabel)
        Me.Controls.Add(Me.UpdateInformationLabel)
        Me.Controls.Add(Me.SpeedLabel)
        Me.Controls.Add(Me.DownloadProgressBar)
        Me.Controls.Add(Me.FormCloseButton)
        Me.Controls.Add(Me.SelfUpdateButton)
        Me.Font = New System.Drawing.Font("나눔고딕", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AnimationCheckerPro Updater"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SelfUpdateButton As Button
    Friend WithEvents FormCloseButton As Button
    Friend WithEvents DownloadProgressBar As ProgressBar
    Friend WithEvents SpeedLabel As Label
    Friend WithEvents UpdateInformationLabel As Label
    Friend WithEvents UpdaterVersionLabel As Label
    Friend WithEvents CurrentDownloadLabel As Label
    Friend WithEvents AnimationTimer As Timer
End Class
