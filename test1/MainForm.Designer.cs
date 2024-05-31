namespace test1
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
            this.WriteExcelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WriteExcelButton
            // 
            this.WriteExcelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WriteExcelButton.Location = new System.Drawing.Point(61, 15);
            this.WriteExcelButton.Name = "WriteExcelButton";
            this.WriteExcelButton.Size = new System.Drawing.Size(84, 23);
            this.WriteExcelButton.TabIndex = 0;
            this.WriteExcelButton.Text = "WriteExcel";
            this.WriteExcelButton.UseVisualStyleBackColor = true;
            this.WriteExcelButton.Click += new System.EventHandler(this.WriteExcelButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(206, 52);
            this.Controls.Add(this.WriteExcelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "test1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button WriteExcelButton;
    }
}

