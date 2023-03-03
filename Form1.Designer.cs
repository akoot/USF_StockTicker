namespace Stock_Ticker
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dailyRadioButton = new System.Windows.Forms.RadioButton();
            this.weeklyRadioButton = new System.Windows.Forms.RadioButton();
            this.monthlyRadioButton = new System.Windows.Forms.RadioButton();
            this.loadStockButton = new System.Windows.Forms.Button();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.daListBoxe = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.candleStickBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.candleStickBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.candleStickBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.candleStickBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.candleStickBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.candleStickBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 75);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "End date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 18);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Start date";
            // 
            // dailyRadioButton
            // 
            this.dailyRadioButton.AutoSize = true;
            this.dailyRadioButton.Location = new System.Drawing.Point(5, 20);
            this.dailyRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.dailyRadioButton.Name = "dailyRadioButton";
            this.dailyRadioButton.Size = new System.Drawing.Size(59, 20);
            this.dailyRadioButton.TabIndex = 6;
            this.dailyRadioButton.TabStop = true;
            this.dailyRadioButton.Text = "Daily";
            this.dailyRadioButton.UseVisualStyleBackColor = true;
            this.dailyRadioButton.CheckedChanged += new System.EventHandler(this.dailyRadioButton_CheckedChanged);
            // 
            // weeklyRadioButton
            // 
            this.weeklyRadioButton.AutoSize = true;
            this.weeklyRadioButton.Location = new System.Drawing.Point(68, 20);
            this.weeklyRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.weeklyRadioButton.Name = "weeklyRadioButton";
            this.weeklyRadioButton.Size = new System.Drawing.Size(74, 20);
            this.weeklyRadioButton.TabIndex = 7;
            this.weeklyRadioButton.TabStop = true;
            this.weeklyRadioButton.Text = "Weekly";
            this.weeklyRadioButton.UseVisualStyleBackColor = true;
            this.weeklyRadioButton.CheckedChanged += new System.EventHandler(this.weeklyRadioButton_CheckedChanged);
            // 
            // monthlyRadioButton
            // 
            this.monthlyRadioButton.AutoSize = true;
            this.monthlyRadioButton.Location = new System.Drawing.Point(146, 20);
            this.monthlyRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.monthlyRadioButton.Name = "monthlyRadioButton";
            this.monthlyRadioButton.Size = new System.Drawing.Size(74, 20);
            this.monthlyRadioButton.TabIndex = 8;
            this.monthlyRadioButton.TabStop = true;
            this.monthlyRadioButton.Text = "Monthly";
            this.monthlyRadioButton.UseVisualStyleBackColor = true;
            this.monthlyRadioButton.CheckedChanged += new System.EventHandler(this.monthlyRadioButton_CheckedChanged);
            // 
            // loadStockButton
            // 
            this.loadStockButton.Location = new System.Drawing.Point(18, 324);
            this.loadStockButton.Margin = new System.Windows.Forms.Padding(2);
            this.loadStockButton.Name = "loadStockButton";
            this.loadStockButton.Size = new System.Drawing.Size(109, 29);
            this.loadStockButton.TabIndex = 9;
            this.loadStockButton.Text = "LOAD STOCK";
            this.loadStockButton.UseVisualStyleBackColor = true;
            this.loadStockButton.Click += new System.EventHandler(this.loadStockButton_Click);
            // 
            // startDate
            // 
            this.startDate.Location = new System.Drawing.Point(5, 41);
            this.startDate.Margin = new System.Windows.Forms.Padding(2);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(247, 22);
            this.startDate.TabIndex = 11;
            // 
            // endDate
            // 
            this.endDate.Location = new System.Drawing.Point(8, 93);
            this.endDate.Margin = new System.Windows.Forms.Padding(2);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(247, 22);
            this.endDate.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dailyRadioButton);
            this.groupBox1.Controls.Add(this.weeklyRadioButton);
            this.groupBox1.Controls.Add(this.monthlyRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(18, 130);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 56);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "View";
            // 
            // groupBox2
            // 
            this.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.startDate);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.endDate);
            this.groupBox2.Location = new System.Drawing.Point(18, 192);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(263, 127);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            // 
            // daListBoxe
            // 
            this.daListBoxe.FormattingEnabled = true;
            this.daListBoxe.ItemHeight = 16;
            this.daListBoxe.Location = new System.Drawing.Point(18, 40);
            this.daListBoxe.Name = "daListBoxe";
            this.daListBoxe.Size = new System.Drawing.Size(120, 84);
            this.daListBoxe.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stock Symbol";
            // 
            // candleStickBindingSource2
            // 
            this.candleStickBindingSource2.DataSource = typeof(Stock_Ticker.CandleStick);
            // 
            // candleStickBindingSource1
            // 
            this.candleStickBindingSource1.DataSource = typeof(Stock_Ticker.CandleStick);
            // 
            // candleStickBindingSource
            // 
            this.candleStickBindingSource.DataSource = typeof(Stock_Ticker.CandleStick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 383);
            this.Controls.Add(this.loadStockButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.daListBoxe);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Options";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.candleStickBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.candleStickBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.candleStickBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton dailyRadioButton;
        private System.Windows.Forms.RadioButton weeklyRadioButton;
        private System.Windows.Forms.RadioButton monthlyRadioButton;
        private System.Windows.Forms.Button loadStockButton;
        private System.Windows.Forms.DateTimePicker startDate;
        private System.Windows.Forms.DateTimePicker endDate;
        private System.Windows.Forms.BindingSource candleStickBindingSource;
        private System.Windows.Forms.BindingSource candleStickBindingSource1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox daListBoxe;
        private System.Windows.Forms.BindingSource candleStickBindingSource2;
    }
}

