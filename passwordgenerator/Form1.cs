using System.Collections.Specialized;

namespace passwordgenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //���������� L � ������� ������� ����� ��� ������� L ����� ������ 6 �������
        //������������� ��� ����� �������� ������ ����� �������� 7 �������
        private void button1_Click(object sender, EventArgs e)
        {
            //��������� �������� ��� ����������
            string A1 = "��������������������������������";
            string A2 = "~`@#�$;%^:&!?*(){}[].,-_=+<>'/|";
            Random rnd= new Random();
            int length,Power=0,max, count=0,element,method;
            //�������� �� ���� ����� � ���������1,���������2
            if (!int.TryParse(textBox1.Text, out length)) {
                MessageBox.Show("��������� ������ �� �����");
            } else if (!int.TryParse(textBox2.Text, out length))
                MessageBox.Show("��������� ������ �� �����");
            else
            {
                //�������� �������� �������
                if(checkBox1.Checked) 
                {
                    Power += A1.Length;
                }
                if (checkBox2.Checked) 
                {
                    Power+= A2.Length;
                }
                double S = 10 * 60 * 24 * 5 / Math.Pow(10, -6); //s*
                int L = 0;
                //������� L �� ������� *s<=A � ������� L
                for (int i = 0; i > -1; i++)
                {
                    if (S <= Math.Pow(Power, i))
                    {
                        L = i;
                        break;
                    }
                }
                //����������� ������ �� ����������2 ��� ���-�� �������
                string str = textBox2.Text;
                int pwcount = int.Parse(str);
                //�������� ������� �� ������������ �������� ��� ��������� ������
                if (checkBox1.Checked || checkBox2.Checked)
                {
                    label4.Text = "";
                    //��������� ������������� ���������� �������
                    for (int i = 0; i <= pwcount; i++)
                    {
                       //������������ ������ �� ����� ����� L
                       //������������ �������, ��� �������, ���� ��������� ����� ����� ������ �����������, ������ �� ��������, �� ������������ ����� ������ ������ ���������
                        if (length > L)
                        {
                            max = length;
                        }
                        //����� ������������ ����� ������ �����������
                        else max = L;
                        //�������� ����� ������, ���� �������������, �� � ������� random ���������� ������ ������ � ����������� �� ��������� ����������
                        while (count<max)
                        {
                            //���������� ����� ��������� ������� �������� �����, � ������� �������� �� ����� ������������ ��������� �������� �� ������ ������
                            method = rnd.Next(1, 3);
                            if (method == 1 & checkBox1.Checked)
                            {
                                element = rnd.Next(0, A1.Length);
                                label4.Text += A1[element] ;
                                count++;
                            }
                            if (method == 2 & checkBox2.Checked)
                            {
                                element = rnd.Next(0, A2.Length);
                                label4.Text += A2[element] ;
                                count++;
                            }

                        }

                    }

                }
                else MessageBox.Show("���������� �� �������� ��� �������� ������"); //������ ���� ������������ �� ������ �������, ������ ������ �� ��������������


            }



        }
    }
}