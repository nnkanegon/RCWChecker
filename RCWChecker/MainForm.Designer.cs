namespace RCWChecker
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ProcessNameLabel = new System.Windows.Forms.Label();
            this.ProcessNameTextBox = new System.Windows.Forms.TextBox();
            this.AttachButton = new System.Windows.Forms.Button();
            this.DetachButton = new System.Windows.Forms.Button();
            this.SnapshotButton = new System.Windows.Forms.Button();
            this.StatusViewTextBox = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // ProcessNameLabel
            // 
            this.ProcessNameLabel.AutoSize = true;
            this.ProcessNameLabel.Location = new System.Drawing.Point(12, 17);
            this.ProcessNameLabel.Name = "ProcessNameLabel";
            this.ProcessNameLabel.Size = new System.Drawing.Size(77, 12);
            this.ProcessNameLabel.TabIndex = 0;
            this.ProcessNameLabel.Text = "ProcessName:";
            // 
            // ProcessNameTextBox
            // 
            this.ProcessNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProcessNameTextBox.Location = new System.Drawing.Point(95, 14);
            this.ProcessNameTextBox.Name = "ProcessNameTextBox";
            this.ProcessNameTextBox.Size = new System.Drawing.Size(366, 19);
            this.ProcessNameTextBox.TabIndex = 1;
            // 
            // AttachButton
            // 
            this.AttachButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AttachButton.Location = new System.Drawing.Point(467, 12);
            this.AttachButton.Name = "AttachButton";
            this.AttachButton.Size = new System.Drawing.Size(75, 23);
            this.AttachButton.TabIndex = 2;
            this.AttachButton.Text = "Attach";
            this.AttachButton.UseVisualStyleBackColor = true;
            this.AttachButton.Click += new System.EventHandler(this.AttachButton_Click);
            // 
            // DetachButton
            // 
            this.DetachButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DetachButton.Location = new System.Drawing.Point(548, 12);
            this.DetachButton.Name = "DetachButton";
            this.DetachButton.Size = new System.Drawing.Size(75, 23);
            this.DetachButton.TabIndex = 3;
            this.DetachButton.Text = "Detach";
            this.DetachButton.UseVisualStyleBackColor = true;
            this.DetachButton.Click += new System.EventHandler(this.DetachButton_Click);
            // 
            // SnapshotButton
            // 
            this.SnapshotButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SnapshotButton.Location = new System.Drawing.Point(629, 12);
            this.SnapshotButton.Name = "SnapshotButton";
            this.SnapshotButton.Size = new System.Drawing.Size(75, 23);
            this.SnapshotButton.TabIndex = 4;
            this.SnapshotButton.Text = "Snapshot";
            this.SnapshotButton.UseVisualStyleBackColor = true;
            this.SnapshotButton.Click += new System.EventHandler(this.SnapshotButton_Click);
            // 
            // StatusViewTextBox
            // 
            this.StatusViewTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusViewTextBox.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.StatusViewTextBox.Location = new System.Drawing.Point(12, 39);
            this.StatusViewTextBox.Multiline = true;
            this.StatusViewTextBox.Name = "StatusViewTextBox";
            this.StatusViewTextBox.Size = new System.Drawing.Size(692, 348);
            this.StatusViewTextBox.TabIndex = 5;
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AcceptButton = this.AttachButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 399);
            this.Controls.Add(this.StatusViewTextBox);
            this.Controls.Add(this.SnapshotButton);
            this.Controls.Add(this.DetachButton);
            this.Controls.Add(this.AttachButton);
            this.Controls.Add(this.ProcessNameTextBox);
            this.Controls.Add(this.ProcessNameLabel);
            this.Name = "MainForm";
            this.Text = "RCWChecker";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ProcessNameLabel;
        private System.Windows.Forms.TextBox ProcessNameTextBox;
        private System.Windows.Forms.Button AttachButton;
        private System.Windows.Forms.Button DetachButton;
        private System.Windows.Forms.Button SnapshotButton;
        private System.Windows.Forms.TextBox StatusViewTextBox;
        private System.Windows.Forms.Timer timer1;
    }
}

