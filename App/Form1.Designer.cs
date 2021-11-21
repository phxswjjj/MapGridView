
namespace App
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.mapGridView1 = new MyUI.MapGridView();
            ((System.ComponentModel.ISupportInitialize)(this.mapGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // mapGridView1
            // 
            this.mapGridView1.AllowUserToAddRows = false;
            this.mapGridView1.AllowUserToDeleteRows = false;
            this.mapGridView1.AllowUserToResizeColumns = false;
            this.mapGridView1.AllowUserToResizeRows = false;
            this.mapGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mapGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.mapGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mapGridView1.Location = new System.Drawing.Point(12, 12);
            this.mapGridView1.Name = "mapGridView1";
            this.mapGridView1.RowTailersVisible = true;
            this.mapGridView1.RowTemplate.Height = 24;
            this.mapGridView1.Size = new System.Drawing.Size(1175, 651);
            this.mapGridView1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 675);
            this.Controls.Add(this.mapGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mapGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MyUI.MapGridView mapGridView1;
    }
}

