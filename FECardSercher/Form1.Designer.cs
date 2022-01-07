namespace FECardSercher
{
    partial class FECipherCardSearcher
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
            this.CardImagePanel = new System.Windows.Forms.Panel();
            this.CardTextPanel = new System.Windows.Forms.Panel();
            this.SerachResultPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // CardImagePanel
            // 
            this.CardImagePanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CardImagePanel.Location = new System.Drawing.Point(13, 13);
            this.CardImagePanel.Name = "CardImagePanel";
            this.CardImagePanel.Size = new System.Drawing.Size(308, 431);
            this.CardImagePanel.TabIndex = 0;
            // 
            // CardTextPanel
            // 
            this.CardTextPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CardTextPanel.Location = new System.Drawing.Point(13, 450);
            this.CardTextPanel.Name = "CardTextPanel";
            this.CardTextPanel.Size = new System.Drawing.Size(308, 126);
            this.CardTextPanel.TabIndex = 1;
            // 
            // SerachResultPanel
            // 
            this.SerachResultPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.SerachResultPanel.Location = new System.Drawing.Point(328, 12);
            this.SerachResultPanel.Name = "SerachResultPanel";
            this.SerachResultPanel.Size = new System.Drawing.Size(325, 563);
            this.SerachResultPanel.TabIndex = 2;
            // 
            // FECipherCardSearcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 588);
            this.Controls.Add(this.SerachResultPanel);
            this.Controls.Add(this.CardTextPanel);
            this.Controls.Add(this.CardImagePanel);
            this.Name = "FECipherCardSearcher";
            this.Text = "FECipherCardSearcher";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel CardImagePanel;
        private System.Windows.Forms.Panel CardTextPanel;
        private System.Windows.Forms.Panel SerachResultPanel;
    }
}

