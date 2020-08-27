namespace Parser
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.EndPage = new System.Windows.Forms.NumericUpDown();
            this.ParserDataList = new System.Windows.Forms.RichTextBox();
            this.Search = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.EndPage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(387, 265);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(128, 42);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start Parsing";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(387, 330);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(128, 39);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop Parsing";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // EndPage
            // 
            this.EndPage.Location = new System.Drawing.Point(387, 40);
            this.EndPage.Name = "EndPage";
            this.EndPage.Size = new System.Drawing.Size(128, 23);
            this.EndPage.TabIndex = 3;
            // 
            // ParserDataList
            // 
            this.ParserDataList.Location = new System.Drawing.Point(13, 13);
            this.ParserDataList.Name = "ParserDataList";
            this.ParserDataList.Size = new System.Drawing.Size(368, 365);
            this.ParserDataList.TabIndex = 4;
            this.ParserDataList.Text = "";
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(386, 145);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(129, 23);
            this.Search.TabIndex = 5;
            this.Search.TextChanged += new System.EventHandler(this.Search_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(386, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Найти в тексте";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(386, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Количество страниц";
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(527, 414);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.ParserDataList);
            this.Controls.Add(this.EndPage);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Name = "MainForm";
            this.Text = "Parser";
            ((System.ComponentModel.ISupportInitialize)(this.EndPage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.NumericUpDown EndPage;
        private System.Windows.Forms.RichTextBox ParserDataList;
        private System.Windows.Forms.TextBox Search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

