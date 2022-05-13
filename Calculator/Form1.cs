using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 
namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        private double temp = 0;  //存储临时数据
        private char myoperator = ' ';  //判断之前按的是+-*/中的哪个
 
        private void AddNum(object sender, EventArgs e)
        {   // 1~9与小数点的Click事件
            //sender是引发该事件的控件，这里我们拆箱为Button
            Button button = (Button)sender;
            textBox2.Text += button.Text;
        }
 
        private void Reset(object sender, EventArgs e)
        {   // CE的Click事件
            temp = 0;
            myoperator = ' ';
            textBox1.Text = textBox2.Text = "";
        }
 
        private void Delete(object sender, EventArgs e)
        {   // ←的Click事件
            //移除最后一个字符
            if (textBox2.TextLength > 0)
                textBox2.Text = textBox2.Text.Remove(textBox2.TextLength - 1);
        }
 
        private void Calculate(object sender, EventArgs e)
        {   // +-*/的Click事件
            Button button = (Button)sender;
            if (double.TryParse(textBox2.Text, out temp))  //尝试把textBox2的Text转为double并赋值给temp
            {
                myoperator = button.Text[0]; //Text是string，取第一个字符
                textBox1.Text = temp.ToString() + ' ' + myoperator;
                textBox2.Text = "";
            }
            else
            {   //转换失败，重置所有
                Reset(sender, e);
            }
        }
 
        private void Equal(object sender, EventArgs e)
        {   // = 的Click事件，计算并显示
            double temp2;
            //尝试转换，失败则重置并返回
            if (!double.TryParse(textBox2.Text, out temp2)) { Reset(sender, e); return; }
            switch (myoperator)
            {
                case '+':
                    temp += temp2;
                    break;
 
                case '-':
                    temp -= temp2;
                    break;
 
                case '*':
                    temp *= temp2;
                    break;
 
                case '/':
                    temp /= temp2;
                    break;
 
                default:
                    break;
            }
            textBox1.Text = "";
            textBox2.Text = temp.ToString();
        }
    }
}