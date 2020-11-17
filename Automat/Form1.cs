using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automat
{
    public partial class Form1 : Form
    {
        List<Gadget> gadgetList = new List<Gadget>();

        public Form1()
        {
            InitializeComponent();
            ShowInfo();
        }

        // Создание гаджетов рандомно
        private void btnRefill_Click(object sender, EventArgs e)
        {
            this.gadgetList.Clear();

            var rnd = new Random();
            for (var i = 0; i < 10; ++i)
            {
                switch (rnd.Next() % 3)
                {
                    case 0:
                        this.gadgetList.Add(Notebook.Generate());
                        break;
                    case 1:
                        this.gadgetList.Add(Tablet.Generate());
                        break;
                    case 2:
                        this.gadgetList.Add(Smartphone.Generate());
                        break;
                }
            }

            ShowInfo();
        }

        // Вывод количества гаджетов
        private void ShowInfo()
        {
            int notebooksCount = 0;
            int tabletsCount = 0;
            int smartphonesCount = 0;

            foreach (var gadget in this.gadgetList)
            {

                if (gadget is Notebook)
                {
                    notebooksCount += 1;
                }
                else if (gadget is Tablet)
                {
                    tabletsCount += 1;
                }
                else if (gadget is Smartphone)
                {
                    smartphonesCount += 1;
                }
            }

            // Вывод списка очереди гаджетов
            txtLast.Text = "";
            foreach (var gadget in this.gadgetList)
            {
                txtLast.Text += gadget.GetName();
                txtLast.Text += "\n";
            }
            

            txtInfo.Text = "Ноутбук\tПланшет\tСмартфон";
            txtInfo.Text += "\n";
            txtInfo.Text += String.Format("{0}\t{1}\t{2}", notebooksCount, tabletsCount, smartphonesCount);
        }

        //Вывод характеристик
        private void btnGet_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            if (this.gadgetList.Count == 0)
            {
                this.Refresh();
                txtOut.Text = "В автомате пусто";
                return;
            }

            // Выбор 1-го гаджета в списке и удаление его
            var gadget = this.gadgetList[0];
            this.gadgetList.RemoveAt(0);

            //Устанавливаю картинки гаджетов
            if (gadget is Notebook)
            {
                this.Refresh();
                Rectangle rect = new Rectangle(0, 115, 230, 180);
                g.DrawImage(Image.FromFile("F:/Automat/Automat/Laptop_logo.png"), rect);

            }
            else if (gadget is Tablet)
            {
                this.Refresh();
                Rectangle rect = new Rectangle(23, 120, 183, 150);
                g.DrawImage(Image.FromFile("F:/Automat/Automat/Tablet.png"), rect);
            }
            else if (gadget is Smartphone)
            {
                this.Refresh();
                Rectangle rect = new Rectangle(10, 100, 210, 300);
                g.DrawImage(Image.FromFile("F:/Automat/Automat/smart.jpg"), rect);
            }

            txtOut.Text = gadget.GetInfo();
            ShowInfo();
        }
    }
}
