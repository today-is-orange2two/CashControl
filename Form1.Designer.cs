namespace CashControl1
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Data_Combox = new System.Windows.Forms.ComboBox();
            this.Baud_Combox = new System.Windows.Forms.ComboBox();
            this.Port_Combox = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Stop = new System.Windows.Forms.Button();
            this.Send = new System.Windows.Forms.Button();
            this.Close_btn = new System.Windows.Forms.Button();
            this.Open_btn = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Data_Combox2 = new System.Windows.Forms.ComboBox();
            this.Baud_Combox2 = new System.Windows.Forms.ComboBox();
            this.Port_Combox2 = new System.Windows.Forms.ComboBox();
            this.timer_stop = new System.Windows.Forms.Timer(this.components);
            this.Return_cash = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Return_cash);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Data_Combox);
            this.groupBox1.Controls.Add(this.Baud_Combox);
            this.groupBox1.Controls.Add(this.Port_Combox);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.Stop);
            this.groupBox1.Controls.Add(this.Send);
            this.groupBox1.Controls.Add(this.Close_btn);
            this.groupBox1.Controls.Add(this.Open_btn);
            this.groupBox1.Location = new System.Drawing.Point(12, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(475, 353);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "지폐인식기";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "data";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "baudrate";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "port";
            // 
            // Data_Combox
            // 
            this.Data_Combox.FormattingEnabled = true;
            this.Data_Combox.Items.AddRange(new object[] {
            "8"});
            this.Data_Combox.Location = new System.Drawing.Point(93, 140);
            this.Data_Combox.Name = "Data_Combox";
            this.Data_Combox.Size = new System.Drawing.Size(121, 20);
            this.Data_Combox.TabIndex = 11;
            this.Data_Combox.Text = "8";
            this.Data_Combox.SelectedIndexChanged += new System.EventHandler(this.Data_Combox_SelectedIndexChanged);
            // 
            // Baud_Combox
            // 
            this.Baud_Combox.FormattingEnabled = true;
            this.Baud_Combox.Items.AddRange(new object[] {
            "115200"});
            this.Baud_Combox.Location = new System.Drawing.Point(93, 97);
            this.Baud_Combox.Name = "Baud_Combox";
            this.Baud_Combox.Size = new System.Drawing.Size(121, 20);
            this.Baud_Combox.TabIndex = 10;
            this.Baud_Combox.Text = "115200";
            this.Baud_Combox.SelectedIndexChanged += new System.EventHandler(this.Baud_Combox_SelectedIndexChanged);
            // 
            // Port_Combox
            // 
            this.Port_Combox.FormattingEnabled = true;
            this.Port_Combox.Location = new System.Drawing.Point(93, 48);
            this.Port_Combox.Name = "Port_Combox";
            this.Port_Combox.Size = new System.Drawing.Size(121, 20);
            this.Port_Combox.TabIndex = 9;
            this.Port_Combox.SelectedIndexChanged += new System.EventHandler(this.Port_Combox_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(228, 19);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(229, 317);
            this.textBox1.TabIndex = 8;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // Stop
            // 
            this.Stop.Location = new System.Drawing.Point(117, 241);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(105, 44);
            this.Stop.TabIndex = 7;
            this.Stop.Text = "수입금지";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // Send
            // 
            this.Send.Location = new System.Drawing.Point(6, 241);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(105, 44);
            this.Send.TabIndex = 6;
            this.Send.Text = "지폐수입 후 배출";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // Close_btn
            // 
            this.Close_btn.Location = new System.Drawing.Point(117, 191);
            this.Close_btn.Name = "Close_btn";
            this.Close_btn.Size = new System.Drawing.Size(105, 44);
            this.Close_btn.TabIndex = 5;
            this.Close_btn.Text = "연결끊기";
            this.Close_btn.UseVisualStyleBackColor = true;
            this.Close_btn.Click += new System.EventHandler(this.Close_btn_Click);
            // 
            // Open_btn
            // 
            this.Open_btn.Location = new System.Drawing.Point(6, 191);
            this.Open_btn.Name = "Open_btn";
            this.Open_btn.Size = new System.Drawing.Size(105, 44);
            this.Open_btn.TabIndex = 4;
            this.Open_btn.Text = "연결";
            this.Open_btn.UseVisualStyleBackColor = true;
            this.Open_btn.Click += new System.EventHandler(this.Open_btn_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.Data_Combox2);
            this.groupBox2.Controls.Add(this.Baud_Combox2);
            this.groupBox2.Controls.Add(this.Port_Combox2);
            this.groupBox2.Location = new System.Drawing.Point(519, 47);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(457, 353);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "지폐배출기";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(219, 18);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(232, 318);
            this.textBox2.TabIndex = 8;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "data";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "baudrate";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "port";
            // 
            // Data_Combox2
            // 
            this.Data_Combox2.FormattingEnabled = true;
            this.Data_Combox2.Items.AddRange(new object[] {
            "8"});
            this.Data_Combox2.Location = new System.Drawing.Point(92, 121);
            this.Data_Combox2.Name = "Data_Combox2";
            this.Data_Combox2.Size = new System.Drawing.Size(116, 20);
            this.Data_Combox2.TabIndex = 2;
            this.Data_Combox2.Text = "8";
            this.Data_Combox2.SelectedIndexChanged += new System.EventHandler(this.Data_Combox2_SelectedIndexChanged);
            // 
            // Baud_Combox2
            // 
            this.Baud_Combox2.FormattingEnabled = true;
            this.Baud_Combox2.Items.AddRange(new object[] {
            "9600"});
            this.Baud_Combox2.Location = new System.Drawing.Point(92, 80);
            this.Baud_Combox2.Name = "Baud_Combox2";
            this.Baud_Combox2.Size = new System.Drawing.Size(116, 20);
            this.Baud_Combox2.TabIndex = 1;
            this.Baud_Combox2.Text = "9600";
            this.Baud_Combox2.SelectedIndexChanged += new System.EventHandler(this.Baud_Combox2_SelectedIndexChanged);
            // 
            // Port_Combox2
            // 
            this.Port_Combox2.FormattingEnabled = true;
            this.Port_Combox2.Location = new System.Drawing.Point(92, 42);
            this.Port_Combox2.Name = "Port_Combox2";
            this.Port_Combox2.Size = new System.Drawing.Size(116, 20);
            this.Port_Combox2.TabIndex = 0;
            this.Port_Combox2.SelectedIndexChanged += new System.EventHandler(this.Port_Combox2_SelectedIndexChanged);
            // 
            // Return_cash
            // 
            this.Return_cash.Location = new System.Drawing.Point(6, 291);
            this.Return_cash.Name = "Return_cash";
            this.Return_cash.Size = new System.Drawing.Size(105, 44);
            this.Return_cash.TabIndex = 14;
            this.Return_cash.Text = "환불";
            this.Return_cash.UseVisualStyleBackColor = true;
            this.Return_cash.Click += new System.EventHandler(this.Return_cash_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 444);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Data_Combox;
        private System.Windows.Forms.ComboBox Baud_Combox;
        private System.Windows.Forms.ComboBox Port_Combox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.Button Send;
        private System.Windows.Forms.Button Close_btn;
        private System.Windows.Forms.Button Open_btn;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox Data_Combox2;
        private System.Windows.Forms.ComboBox Baud_Combox2;
        private System.Windows.Forms.ComboBox Port_Combox2;
        private System.Windows.Forms.Timer timer_stop;
        private System.Windows.Forms.Button Return_cash;
    }
}

