/********************************************************************************
** Company： 
** auth：    jerryli
** date：    2017/8/7 17:08:28
** desc：    简单的串口发送数据操作
** Ver.:     V1.0.0
*********************************************************************************/


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0807
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string str;
            for(int i = 0;i <256; i++)
            {
                str = i.ToString("x").ToUpper();
                if(str.Length == 1)
                {
                    str = "0" + str;
             
                }
                comboBox1.Items.Add("0x" + str);



            }

            comboBox1.Text = "0X00";//初始值



        }

        private void button1_Click(object sender, EventArgs e)
        {
            string data = comboBox1.Text;
            string convertdata = data.Substring(2, 2);
            byte[] buffer = new byte[1];//因为write（）中需要数组参数
            buffer[0] = Convert.ToByte(convertdata, 16);//将字符串转化为byte型变量
            try//防止出错
            {
                serialPort1.Open();
                serialPort1.Write(buffer,0,1);
                serialPort1.Close();


            }
            catch
            {
                if(serialPort1.IsOpen)
                {
                    serialPort1.Close();//如果是写数据是出错，此时窗口状态为开，就应关闭串口，防止下次不能使用。

                }
                MessageBox.Show("串口出错","错误提示");


            }






        }



    }
}
