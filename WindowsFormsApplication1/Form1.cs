using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Button[,] list = new Button[4, 4];
        Random rand = new Random();
        const int size = 4;
        const int Font = 35;


        public Form1()
        {
            Color colorInit = Color.Black;
            
            
            Init(list);
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Add();
            Add();

        }

        //----------------------------------------------------------------------------------------------------------------------------------


        private void Add()
        {

            int a = rand.Next(4);
            int b = rand.Next(4);
            if (list[a, b].Text != "-1")
            {
                if (Check())
                {
                    Add();
                }
                else
                {
                    MessageBox.Show("Места больше нет");
                    return;
                }
            }
            else
            {

                list[a, b].Location = new Point(Link_x(a), Link_y(b));
                list[a, b].Text = "2";//a.ToString() + b.ToString();
                
                list[a, b].Font = new Font("Arial", Font, FontStyle.Bold);
                Controls.Add(list[a, b]);

            }


        }

        private bool Check()
        {
            int length = 4;
            bool flag = false;
            for (int i = 0; i < length; i++)
                for (int j = 0; j < length; j++)
                {
                    if (list[i, j].Text == "-1")
                    {
                        flag = true;
                    }
                }
            return flag;
        }

        private void Init(Button[,] list)
        {

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    list[i, j] = new Button();
                    list[i, j].Text = "-1";
                    list[i, j].Width = 100;
                    list[i, j].Height = 100;
                    list[i, j].Enabled = false;
                    list[i, j].BackColor = Color.DarkOrchid;
                }
        }

        private int Link_x(int x)
        {

            switch (x)
            {
                case 0:
                    {
                        x = (panel1.Width / 4) * 0 + panel1.Location.X;
                        break;
                    }
                case 1:
                    {
                        x = (panel1.Width / 4) * 1 + panel1.Location.X;
                        break;
                    }
                case 2:
                    {
                        x = (panel1.Width / 4) * 2 + panel1.Location.X;
                        break;
                    }
                case 3:
                    {
                        x = (panel1.Width / 4) * 3 + panel1.Location.X;
                        break;
                    }


            }

            return x;
        }

        private int Link_y(int y)
        {

            switch (y)
            {
                case 0:
                    {
                        y = (panel1.Height / 4) * 0 + panel1.Location.Y;
                        break;
                    }
                case 1:
                    {
                        y = (panel1.Height / 4) * 1 + panel1.Location.Y;
                        break;
                    }
                case 2:
                    {
                        y = (panel1.Height / 4) * 2 + panel1.Location.Y;
                        break;
                    }
                case 3:
                    {
                        y = (panel1.Height / 4) * 3 + panel1.Location.Y;
                        break;
                    }
            }

            return y;
        }

        private void Press(object sender, KeyEventArgs e)
        {

            if (e.KeyCode.ToString() == Keys.Left.ToString())
            {
                label1.Text = "Left";
                Slide_Left();
                Add();
                Add();
            }
            if (e.KeyCode.ToString() == Keys.Up.ToString())
            {
                label1.Text = "Up";
                Slide_Up();
                Add();
                Add();


            }
            if (e.KeyCode.ToString() == Keys.Right.ToString())
            {
                label1.Text = "Right";
                Slide_Right();
                Add();
                Add();

            }
            if (e.KeyCode.ToString() == Keys.Down.ToString())
            {
                label1.Text = "Down";
                Slide_Down();
                Add();
                Add();
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------
        private void Slide_Left()
        {
            
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i == 0 || list[i, j].Text == "-1")
                    {
                        continue;
                    }

                    if (list[i - 1, j].Text != "-1")//суммирование
                    {

                        if (list[i - 1, j].Text == list[i, j].Text)
                        {
                            
                            list[i - 1, j].Text = Convert.ToString(Convert.ToInt32(list[i - 1, j].Text) + Convert.ToInt32(list[i, j].Text));
                            list[i, j].Text = "-1";
                            Controls.Remove(list[i, j]);
                        }
                    }
            
                       
                    
                    if (list[i - 1, j].Text == "-1")//приближение збс
                    {
                        int a = i;
                        int b = j;
                        while (a != 0)
                        {
                            if (list[a - 1, b].Text == "-1")
                            {
                                list[a - 1, b].Location = new Point(Link_x(a - 1), Link_y(b));
                                list[a - 1, b].Text = list[a, b].Text;
                                list[a - 1, b].Font = new Font("Arial", Font, FontStyle.Bold);
                                list[a, b].Text = "-1";
                                Controls.Add(list[a - 1, b]);
                                Controls.Remove(list[a, b]);

                            }else
                            {
                                if (list[a - 1, b].Text == list[a, b].Text)
                                {

                                    list[a - 1, b].Text = Convert.ToString(Convert.ToInt32(list[a - 1, b].Text) + Convert.ToInt32(list[a, b].Text));
                                    list[a, b].Text = "-1";
                                    Controls.Remove(list[a, b]);
                                }
                            }
                            --a;
                        }

                        
                    }
                }

                
            }
            
        }

        private void Slide_Right()
        {

            for (int i = 3; i != -1; i--)
            {
                for (int j = 3; j != -1; j--)
                {
                    if (i == 3 || list[i, j].Text == "-1")
                    {
                        continue;
                    }

                    if (list[i + 1, j].Text != "-1")//суммирование
                    {

                        if (list[i + 1, j].Text == list[i, j].Text)
                        {

                            list[i + 1, j].Text = Convert.ToString(Convert.ToInt32(list[i + 1, j].Text) + Convert.ToInt32(list[i, j].Text));
                            list[i, j].Text = "-1";
                            Controls.Remove(list[i, j]);
                        }
                    }



                    if (list[i + 1, j].Text == "-1")//приближение збс
                    {
                        int a = i;
                        int b = j;
                        while (a != 3)
                        {
                            if (list[a + 1, b].Text == "-1")
                            {
                                list[a + 1, b].Location = new Point(Link_x(a + 1), Link_y(b));
                                list[a + 1, b].Text = list[a, b].Text;
                                list[a + 1, b].Font = new Font("Arial", Font, FontStyle.Bold);
                                list[a, b].Text = "-1";
                                Controls.Add(list[a + 1, b]);
                                Controls.Remove(list[a, b]);

                            }
                            else
                            {
                                if (list[a + 1, b].Text == list[a, b].Text)
                                {

                                    list[a + 1, b].Text = Convert.ToString(Convert.ToInt32(list[a + 1, b].Text) + Convert.ToInt32(list[a, b].Text));
                                    list[a, b].Text = "-1";
                                    Controls.Remove(list[a, b]);
                                }
                            }
                            ++a;
                        }


                    }
                }


            }

        }

        private void Slide_Up()
        {
            bool up = false;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i == 0 || list[j, i].Text == "-1")
                    {
                        continue;
                    }
                    if (list[j, i - 1].Text != "-1")
                    {

                        if (list[j, i - 1].Text == list[j, i].Text)
                        {
                            up = true;
                            list[j, i - 1].Text = Convert.ToString(Convert.ToInt32(list[j, i - 1].Text) + Convert.ToInt32(list[j, i].Text));
                            list[j, i].Text = "-1";
                            Controls.Remove(list[j, i]);
                        }
                    }
                    if (list[j, i - 1].Text == "-1")
                    {
                        up = true;
                        list[j, i - 1].Location = new Point(Link_x(j), Link_y(i - 1));
                        list[j, i - 1].Text = list[j, i].Text;
                        list[j, i - 1].Font = new Font("Arial", Font, FontStyle.Bold);
                        list[j, i].Text = "-1";
                        Controls.Remove(list[j, i]);
                        Controls.Add(list[j, i - 1]);
                    }

                }
            }
            if (up)
            {
                Slide_Up();
            }
        }

        private void Slide_Down()
        {
            bool down = false;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i == 3 || list[j, i].Text == "-1")
                    {
                        continue;
                    }
                    if (list[j, i + 1].Text != "-1")
                    {

                        if (list[j, i + 1].Text == list[j, i].Text)
                        {
                            down = true;
                            list[j, i + 1].Text = Convert.ToString(Convert.ToInt32(list[j, i + 1].Text) + Convert.ToInt32(list[j, i].Text));
                            list[j, i].Text = "-1";
                            Controls.Remove(list[j, i]);
                        }
                    }
                    if (list[j, i + 1].Text == "-1")
                    {
                        down = true;
                        list[j, i + 1].Location = new Point(Link_x(j), Link_y(i + 1));
                        list[j, i + 1].Text = list[j, i].Text;
                        list[j, i + 1].Font = new Font("Arial", Font, FontStyle.Bold);
                        list[j, i].Text = "-1";
                        Controls.Remove(list[j, i]);
                        Controls.Add(list[j, i + 1]);
                    }

                }
            }
            if (down)
            {
                Slide_Down();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        //----------------------------------------------------------------------------------------------------------------------






    }
}
