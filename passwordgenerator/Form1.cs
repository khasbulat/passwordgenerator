using System.Collections.Specialized;

namespace passwordgenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //вычислени€ L и сделать условие чтобы был минимум L длина парол€ 6 задание
        //использование доп групп символов помимо моего варианта 7 задание
        private void button1_Click(object sender, EventArgs e)
        {
            //объ€вл€ем алфавиты дл€ генератора
            string A1 = "…÷” ≈Ќ√Ўў«’Џ‘џ¬јѕ–ќЋƒ∆Ёя„—ћ»“№Ѕё";
            string A2 = "~`@#є$;%^:&!?*(){}[].,-_=+<>'/|";
            Random rnd= new Random();
            int length,Power=0,max, count=0,element,method;
            //проверка на ввод числа в текстбокс1,текстбокс2
            if (!int.TryParse(textBox1.Text, out length)) {
                MessageBox.Show("¬веденные данные не числа");
            } else if (!int.TryParse(textBox2.Text, out length))
                MessageBox.Show("¬веденные данные не числа");
            else
            {
                //мощность алфавита рассчЄт
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
                //находим L по условию *s<=A в степени L
                for (int i = 0; i > -1; i++)
                {
                    if (S <= Math.Pow(Power, i))
                    {
                        L = i;
                        break;
                    }
                }
                //присваиваем данные из текстбокса2 как кол-во паролей
                string str = textBox2.Text;
                int pwcount = int.Parse(str);
                //проверка отметил ли пользователь критерии дл€ генерации парол€
                if (checkBox1.Checked || checkBox2.Checked)
                {
                    label4.Text = "";
                    //генераци€ определенного количества паролей
                    for (int i = 0; i <= pwcount; i++)
                    {
                       //формирование парол€ не менее длины L
                       //осуществл€ем условие, при котором, если введенна€ длина будет больше вычисленной, исход€ из мощности, то максимальна€ длина парол€ станет введенной
                        if (length > L)
                        {
                            max = length;
                        }
                        //иначе максимальна€ длина станет вычисленной
                        else max = L;
                        //проверка длины парол€, если удовлетвор€ет, то с помощью random генерируем каждый символ в зависимости от выбранных параметров
                        while (count<max)
                        {
                            //переменна€ метод случайным образом выбирает метод, с помощью которого он будет генерировать случайное значение на каждый символ
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
                else MessageBox.Show("требовани€ не подход€т дл€ создани€ парол€"); //случай если пользователь не выбрал услови€, значит пароль не загенерируетс€


            }



        }
    }
}