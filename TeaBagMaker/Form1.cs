using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace TeaBagMaker
{
    public partial class Form1 : Form
    {
        int[] TeaTime = new int[]{ 120, 180, 300 };
        string[] TeaList = new string[]{ "홍차", "녹차", "루이보스차", "국화차" };
        int CountTime = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < TeaList.Length; i++)
                this.CbTeas.Items.Add(TeaList[i]);

            if (this.CbTeas.Items.Count > 0)
            {
                this.CbTeas.SelectedIndex = 0; // select first tea
                this.lblTeaName.Text = TeaList[0]; // selected first tea
            }
        }
               
        private void Teas_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblTeaName.Text = this.CbTeas.Text;
            switch (CbTeas.Text)
            {
                case "홍차":
                    CountTime = TeaTime[0];
                    break;
                case "녹차":
                    CountTime = TeaTime[1];
                    break;
                case "루이보스차":
                    CountTime = TeaTime[2];
                    break;
                case "국화차":
                    CountTime = TeaTime[0];
                    break;
            }
            writeTime("걸립니다.");
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            this.txtCountDown.ReadOnly = true; // can't write here
            this.txtCountDown.Text = ""; // initialize
            this.count.Enabled = true; // start timer
        }

        private void Count_Tick(object sender, EventArgs e)
        {
            if(CountTime<1)
            { // be time out
                this.count.Enabled = false;
                this.txtCountDown.Text = "";
                MessageBox.Show("티백을 건지세요!", "시간이 끝났습니다.",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.CbTeas.Focus();
            }
            else
            {
                this.CountTime--;
                writeTime("남았습니다!");
            }
        }

        private void writeTime(string lastMent)
        {
            int min = this.CountTime / 60;
            int sec = this.CountTime % 60;
            this.txtCountDown.Text = "";
            if (min != 0)
                this.txtCountDown.Text += Convert.ToString(min) + "분 ";
            if (sec != 0)
                this.txtCountDown.Text += Convert.ToString(sec) + "초 ";
            this.txtCountDown.Text += lastMent;
        }
    }
}
