using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using DWORD = System.UInt32;

namespace CashControl1
{
    public partial class Form1 : Form
    {
        char[] RxData = new char[1000];
        char[] RxData1 = new char[1000];
        string str;

        public Form1()
        {
            InitializeComponent();
            string[] PortNames = SerialPort.GetPortNames(); //포트검색

            foreach (string portnumber in PortNames)
            {
                Port_Combox.Items.Add(portnumber); //검색한 포트를 콤보박스에 입력
                Port_Combox2.Items.Add(portnumber);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /****************************************** 전역 변수 설정 ******************************************/

        System.Timers.Timer mytimer = new System.Timers.Timer();
        System.Timers.Timer mytimer2 = new System.Timers.Timer();
        public static SerialPort sp = new SerialPort(); //지폐인식기
        public static SerialPort sp2 = new SerialPort(); //지폐방출기
        Timer time = new Timer();
        int moneyset = 23000; // 수입해야 할 금액설정 
        int moneyIn = 0; // 수입금
        int change = 0; // 거스름돈
        int returncash = 0; // 환불금액
        int returncash2 = 0;

        /****************************************** 환불 딜레이 함수 ******************************************/

        private static DateTime Delay(int MS)
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);
            while (AfterWards >= ThisMoment)
            {
                Application.DoEvents();
                ThisMoment = DateTime.Now;
            }
            return DateTime.Now;
        }

        /****************************************** 시리얼 포트 연결 해제 ******************************************/
        private void Close_btn_Click(object sender, EventArgs e)
        {
            //////////////////// 지폐 인식기 연결 해제 ////////////////////
            if (sp.IsOpen)
            {
                sp.DiscardInBuffer();
                sp.Close();
                time.Stop();
                textBox1.Text += "[[지폐 인식기]] 연결을 해제합니다." + Environment.NewLine;
            }
            else textBox1.Text += "[[지폐 인식기]]가 이미 해제되었습니다." + Environment.NewLine;

            //////////////////// 지폐 배출기 연결 해제 ////////////////////
            if (sp2.IsOpen)
            {
                sp2.DiscardInBuffer();
                sp2.Close();
                time.Stop();
                textBox2.Text += "((지폐 배출기)) 연결을 해제합니다." + Environment.NewLine;
            }
            else textBox2.Text += "((지폐 배출기))가 이미 해제되었습니다." + Environment.NewLine;
        }

        /****************************************** 시리얼 포트 연결 ******************************************/
        private void Open_btn_Click(object sender, EventArgs e)
        {
            //////////////////// 지폐 인식기 연결 ////////////////////
            if (!sp.IsOpen)
            {
                try
                {
                    sp.PortName = Port_Combox.SelectedItem.ToString();
                    sp.BaudRate = int.Parse(Baud_Combox.SelectedItem.ToString());
                    sp.DataBits = int.Parse(Data_Combox.SelectedItem.ToString());
                    sp.StopBits = StopBits.One;
                    sp.Parity = Parity.None;
                    sp.Handshake = Handshake.None;
                    sp.RtsEnable = true;
                    sp.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                    sp.Open();
                    time.Start();

                    textBox1.Text += "[[지폐 인식기]] 연결되었습니다." + Environment.NewLine;
                    sp.WriteLine("\r\n");
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else textBox1.Text += "[[지폐 인식기]] 이미 연결중입니다." + Environment.NewLine;

            //////////////////// 지폐 배출기 연결 ////////////////////
            if (!sp2.IsOpen)
            {
                try
                {
                    sp2.PortName = Port_Combox2.SelectedItem.ToString();
                    sp2.BaudRate = int.Parse(Baud_Combox2.SelectedItem.ToString());
                    sp2.DataBits = int.Parse(Data_Combox2.SelectedItem.ToString());
                    sp2.StopBits = StopBits.One;
                    sp2.Parity = Parity.None;
                    sp2.Handshake = Handshake.None;
                    sp2.RtsEnable = true;
                    sp2.Open();
                    time.Start();

                    textBox2.Text += "((지폐 배출기)) 연결되었습니다." + Environment.NewLine;
                    sp2.WriteLine("\r\n");
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else textBox2.Text += "((지폐 배출기)) 이미 연결중입니다." + Environment.NewLine;
        }
        /****************************************** 지폐 수입 핸들러 ******************************************/
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            int iRecSize = sp.BytesToRead;
            string strRxData;
            moneyIn = 0;
            try
            {
                if (iRecSize != 0)
                {
                    strRxData = "";
                    byte[] buff = new byte[iRecSize];
                    sp.Read(buff, 0, iRecSize);

                    for (int iTemp = 0; iTemp < iRecSize; iTemp++)
                    {
                        strRxData += Convert.ToByte(buff[iTemp]);
                    }
                    CheckForIllegalCrossThreadCalls = false;
                    for (int iTemp = 0; iTemp < iRecSize; iTemp++)
                    {
                        textBox1.Text += iTemp + string.Format("hex : {0:X2} \r\n", buff[iTemp]);
                        switch (iTemp)
                        {
                            case 5:
                                moneyIn += 10000 * buff[iTemp];
                                break;
                            case 6:
                                moneyIn += 5000 * buff[iTemp];
                                break;
                            case 7:
                                moneyIn += 1000 * buff[iTemp];
                                break;
                        }
                    }
                    textBox1.Text += moneyIn + "원SS" + Environment.NewLine;

                    if (moneyset <= moneyIn)
                    {
                        change = moneyIn - moneyset;
                        textBox1.Text += "총 투입금" + moneyIn + "원" + Environment.NewLine;
                        textBox1.Text += "거스름돈" + change + "원" + Environment.NewLine;
                        sp.Write(new byte[] { 0X02, 0X02, 0X55, 0X57 }, 0, 4); // 수입리셋

                        mytimer.Interval = 1000;
                        mytimer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed); //수입금지설정용 

                        mytimer.Start();

                        moneyIn = 0;

                    }
                    textBox1.Text += "------------------" + Environment.NewLine;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /****************************************** 지폐 수입 작업 ******************************************/
        delegate void TimerEventFiredDelegate();

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            BeginInvoke(new TimerEventFiredDelegate(Work));
        }

        private void Work()
        {
            textBox1.Text += "지폐 수입을 멈춥니다." + Environment.NewLine;
            sp.Write(new byte[] { 0X02, 0X02, 0X53, 0X51 }, 0, 4); // 수입금지

            mytimer.Stop();

            try
            {
                int iRecSize = sp2.BytesToRead;

                textBox2.Text += "금액 :" + change + Environment.NewLine;
                if (0 < change)
                {
                    int changeCnt = change / 1000;
                    string cntHex = Convert.ToString(changeCnt, 16);
                    byte hex = byte.Parse(cntHex);
                    iRecSize = sp2.BytesToRead; // 
                    byte[] buff = new byte[iRecSize]; // 
                    textBox2.Text += "지폐갯수 : " + cntHex + Environment.NewLine; // textbox에 라인값 삽입

                    mytimer2.Interval = 1000;
                    mytimer2.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed2); //방출명령
                    mytimer2.Start();

                }
                else MessageBox.Show("지폐가 없습니다. 관리자에게 문의하세요");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /****************************************** 수입 후 배출 버튼 ******************************************/
        private void Send_Click(object sender, EventArgs e)
        {
            try
            {
                sp.Write(new byte[] { 0X02, 0X02, 0X52, 0X50 }, 0, 4);

                MessageBox.Show("지폐를 투입해주세요");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /****************************************** 수입 금지 버튼 ******************************************/
        private void Stop_Click(object sender, EventArgs e)
        {
            try
            {
                sp.Write(new byte[] { 0X02, 0X02, 0X53, 0X51 }, 0, 4);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /****************************************** 환불 버튼 ******************************************/
        private void Return_cash_Click(object sender, EventArgs e)
        {
            textBox2.Text += moneyIn + "원 투입중" + Environment.NewLine;
            textBox2.Text += "----------------------" + Environment.NewLine;

            try
            {
                if (moneyIn != 0)
                {
                    returncash = moneyIn / 10000;
                    returncash2 = moneyIn % 10000;
                    textBox2.Text += "총 투입금" + moneyIn + "원" + Environment.NewLine;
                    textBox2.Text += "======================" + Environment.NewLine;

                    mytimer2.Interval = 1000;

                    //////////////////// 1만원 미만(천원단위) ////////////////////

                    switch (returncash2)
                    {
                        case 1000:
                            sp2.Write(new byte[] { 0x02, 0x04, 0x10, 0x01, 0x17, 0x03 }, 0, 6);
                            break;
                        case 2000:
                            sp2.Write(new byte[] { 0x02, 0x04, 0x10, 0x02, 0x14, 0x03 }, 0, 6);
                            break;
                        case 3000:
                            sp2.Write(new byte[] { 0x02, 0x04, 0x10, 0x03, 0x15, 0x03 }, 0, 6);
                            break;
                        case 4000:
                            sp2.Write(new byte[] { 0x02, 0x04, 0x10, 0x04, 0x12, 0x03 }, 0, 6);
                            break;
                        case 5000:
                            sp2.Write(new byte[] { 0x02, 0x04, 0x10, 0x05, 0x13, 0x03 }, 0, 6);
                            break;
                        case 6000:
                            sp2.Write(new byte[] { 0x02, 0x04, 0x10, 0x06, 0x10, 0x03 }, 0, 6);
                            break;
                        case 7000:
                            sp2.Write(new byte[] { 0x02, 0x04, 0x10, 0x07, 0x11, 0x03 }, 0, 6);
                            break;
                        case 8000:
                            sp2.Write(new byte[] { 0x02, 0x04, 0x10, 0x08, 0x1E, 0x03 }, 0, 6);
                            break;
                        case 9000:
                            sp2.Write(new byte[] { 0x02, 0x04, 0x10, 0x09, 0x1F, 0x03 }, 0, 6);
                            break;
                    }
                    mytimer2.Interval = 1000;
                    sp2.Write(new byte[] { 0x02, 0x04, 0x12, 0x00, 0x14, 0x03 }, 0, 6); //지폐 배출

                    //////////////////// 1만원 이상 (만원단위) ////////////////////
                    
                    for (int i = 0; i <= returncash; i++)
                    {
                        sp2.Write(new byte[] { 0x02, 0x04, 0x10, 0x10, 0x06, 0x03 }, 0, 6); //10장 세팅
                        textBox2.Text += i+1 + "번째 세팅 값 보냄" + Environment.NewLine;

                        sp2.Write(new byte[] { 0x02, 0x04, 0x12, 0x00, 0x14, 0x03 }, 0, 6); //지폐 배출
                        textBox2.Text += i+1 + "번째 배출 요청 보냄" + Environment.NewLine;

                        textBox2.Text += i+1 + "번째 도는중" + Environment.NewLine;
                        sp2.DiscardInBuffer();

                        Delay(12500);

                    }

                    sp.Write(new byte[] { 0X02, 0X02, 0X55, 0X57 }, 0, 4); // 수입리셋
                    textBox2.Text += "환불이 완료되었습니다." + Environment.NewLine;

                }
                else MessageBox.Show("환불 할 금액이 없습니다");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            str = sp.ReadExisting();
            if (str.Length > 0)
            {
                textBox1.SelectedText += str + Environment.NewLine;
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            String indata = sp.ReadExisting();
            MessageBox.Show(indata);
        }

        private void Port_Combox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Baud_Combox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Data_Combox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        /****************************************** 텍스트 박스 자동 스크롤 ******************************************/

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            textBox1.SelectionStart = textBox1.TextLength;     //스크롤 자동으로 내린다.
            textBox1.ScrollToCaret();
        }

        /****************************************** 거스름돈 작업 ******************************************/
        void timer_Elapsed2(object sender, System.Timers.ElapsedEventArgs e)
        {
            textBox2.Text += change + "원 거슬러 드립니다." + Environment.NewLine;
            switch (change)
            {
                //////////////////// 거스름돈 수량 설정 ////////////////////
                case 1000:
                    sp2.Write(new byte[] { 0x02, 0x04, 0x10, 0x01, 0x17, 0x03 }, 0, 6);
                    break;
                case 2000:
                    sp2.Write(new byte[] { 0x02, 0x04, 0x10, 0x02, 0x14, 0x03 }, 0, 6);
                    break;
                case 3000:
                    sp2.Write(new byte[] { 0x02, 0x04, 0x10, 0x03, 0x15, 0x03 }, 0, 6);
                    break;
                case 4000:
                    sp2.Write(new byte[] { 0x02, 0x04, 0x10, 0x04, 0x12, 0x03 }, 0, 6);
                    break;
                case 5000:
                    sp2.Write(new byte[] { 0x02, 0x04, 0x10, 0x05, 0x13, 0x03 }, 0, 6);
                    break;
                case 6000:
                    sp2.Write(new byte[] { 0x02, 0x04, 0x10, 0x06, 0x10, 0x03 }, 0, 6);
                    break;
                case 7000:
                    sp2.Write(new byte[] { 0x02, 0x04, 0x10, 0x07, 0x11, 0x03 }, 0, 6);
                    break;
                case 8000:
                    sp2.Write(new byte[] { 0x02, 0x04, 0x10, 0x08, 0x1E, 0x03 }, 0, 6);
                    break;
                case 9000:
                    sp2.Write(new byte[] { 0x02, 0x04, 0x10, 0x09, 0x1F, 0x03 }, 0, 6);
                    break;
                case 10000:
                    sp2.Write(new byte[] { 0x02, 0x04, 0x10, 0x10, 0x06, 0x03 }, 0, 6); 
                    break;
            }
            CheckForIllegalCrossThreadCalls = false;
            textBox2.Text += "=== 타이머스탑 ===" + Environment.NewLine;
            Invoke(new TimerEventFiredDelegate(Work2));
        }

        private void Work2()
        {
            sp2.WriteLine("\r\n"); // 해당 SerialPort에 출력 버퍼를 삽입
            textBox2.Text += "--- 거스름돈 배출!!! ---" + Environment.NewLine;
            sp2.Write(new byte[] { 0x02, 0x04, 0x12, 0x00, 0x14, 0x03 }, 0, 6); // 배출
            change = 0;
            mytimer2.Stop();
            sp2.DiscardInBuffer();
            mytimer.Elapsed -= new System.Timers.ElapsedEventHandler(timer_Elapsed); //핸들러 초기화
            mytimer2.Elapsed -= new System.Timers.ElapsedEventHandler(timer_Elapsed2); //핸들러 초기화
        }


        private void Baud_Combox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Data_Combox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Port_Combox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /****************************************** 텍스트 박스 자동 스크롤 ******************************************/
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.SelectionStart = textBox2.TextLength;
            textBox2.ScrollToCaret();
        }
    }
}
