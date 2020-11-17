using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Automat
{
    public class Gadget
    {
        public static Random rnd = new Random();
        public double ScreenDiog = 0;

        public virtual String GetInfo()
        {
            var str = String.Format("\nДиагональ: {0}", this.ScreenDiog);
            return str;
        }

        public virtual String GetName()
        {
            return "Гаджет";
        }
    }

    public class Notebook : Gadget
    {
        public bool KeyBackl = true;
        public int Cores = 0;
        public int Capacity = 0;

        // Характеристики гаджета
        public override String GetInfo()
        {
            var str = "Ноутбук";
            str += base.GetInfo();
            str += String.Format("\nНаличие подсветки клавиатуры: {0}", this.KeyBackl);
            str += String.Format("\nКоличество ядер: {0}", this.Cores);
            str += String.Format("\nОбъем жесткого диска: {0} Мб", this.Capacity);
            return str;
        }

        // Создание Ноутбука
        public static Notebook Generate()
        {
            return new Notebook
            {
                ScreenDiog = rnd.Next(15, 30),
                KeyBackl = rnd.Next(2) == 0,
                Cores = rnd.Next(2, 10),
                Capacity = rnd.Next(250, 10000)
            };
        }

        public override String GetName()
        {
            return "Ноутбук";
        }
    }

    public class Tablet : Gadget
    {
        public bool Cam = true;
        public int Dpi = 0;

        public override String GetInfo()
        {
            var str = "Планшет";
            str += base.GetInfo();
            str += String.Format("\nНаличие камеры: {0}", this.Cam);
            str += String.Format("\ndpi экрана: {0}", this.Dpi);
            return str;
        }

        // Создание планшета
        public static Tablet Generate()
        {
            return new Tablet
            {
                ScreenDiog = rnd.Next(7, 15),
                Cam = rnd.Next(2) == 0,
                Dpi = rnd.Next(300, 450),
            };

        }

        public override String GetName()
        {
            return "Планшет";
        }
    }

    public class Smartphone : Gadget
    {
        public int sim = 0;
        public int CamPixel = 0;
        public int Battery = 0;

        public override String GetInfo()
        {
            var str = "Смартфон";
            str += base.GetInfo();
            str += String.Format("\nСлотов под sim карту: {0} шт.", this.sim);
            str += String.Format("\nМегапикселей у камеры: {0}", this.CamPixel);
            str += String.Format("\nБатарея: {0} mAh", this.Battery);
            return str;
        }

        // Создание смартфона
        public static Smartphone Generate()
        {
            return new Smartphone
            {
                ScreenDiog = rnd.Next(3, 7),
                sim = rnd.Next(1,2),
                CamPixel = rnd.Next(5, 64),
                Battery = rnd.Next(2000, 10000)
            };
        }

        public override String GetName()
        {
            return "Смартфон";
        }
    }
}