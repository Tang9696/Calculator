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
       
        private double temp = 0;  //�洢��ʱ����
        private char myoperator = ' ';  //�ж�֮ǰ������+-*/�е��ĸ�
 
        private void AddNum(object sender, EventArgs e)
        {   // 1~9��С�����Click�¼�
            //sender���������¼��Ŀؼ����������ǲ���ΪButton
            Button button = (Button)sender;
            textBox2.Text += button.Text;
        }
 
        private void Reset(object sender, EventArgs e)
        {   // CE��Click�¼�
            temp = 0;
            myoperator = ' ';
            textBox1.Text = textBox2.Text = "";
        }
 
        private void Delete(object sender, EventArgs e)
        {   // ����Click�¼�
            //�Ƴ����һ���ַ�
            if (textBox2.TextLength > 0)
                textBox2.Text = textBox2.Text.Remove(textBox2.TextLength - 1);
        }
 
        private void Calculate(object sender, EventArgs e)
        {   // +-*/��Click�¼�
            Button button = (Button)sender;
            if (double.TryParse(textBox2.Text, out temp))  //���԰�textBox2��TextתΪdouble����ֵ��temp
            {
                myoperator = button.Text[0]; //Text��string��ȡ��һ���ַ�
                textBox1.Text = temp.ToString() + ' ' + myoperator;
                textBox2.Text = "";
            }
            else
            {   //ת��ʧ�ܣ���������
                Reset(sender, e);
            }
        }
 
        private void Equal(object sender, EventArgs e)
        {   // = ��Click�¼������㲢��ʾ
            double temp2;
            //����ת����ʧ�������ò�����
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