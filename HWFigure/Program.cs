using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWFigure
{
    public delegate void MyDelegate();

    public abstract class Figure
    {
        public Figure()
        {
            _name = "Фигура";
        }
        public string printName()
        {
            return _name;
        }
        public abstract float Square();

        public virtual float Square(float metric1)
        {
            return metric1;
        }
        public virtual float Square(float metric1, float metric2)
        {
            return metric1 * metric2;
        }

        public abstract float Perimeter();

        public virtual float Perimeter(float metric1)
        {
            return metric1;
        }
        public virtual float Perimeter(float metric1, float metric2)
        {
            return (metric1 + metric2) * 2;
        }

        protected string _name;
    }

    public class Circle : Figure
    {
        private string _filename = "CircleOutput.txt";
        private float _radius;
        public Circle()
        {
            _name = "Окружность";
        }

        public override float Square()
        {
            return 3.14f * (_radius * _radius);
        }
        public override float Square(float radius)
        {
            _radius = radius;
            return 3.14f * (_radius * _radius);
        }
        public void PrintSquare()
        {
            Console.WriteLine("Площадь = {0}", this.Square());
        }

        public void WriteSquare()
        {
            string _path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            StreamWriter output = new StreamWriter(_path + "\\" + _filename, false);
            output.WriteLine("Площадь = {0}", this.Square());
            output.Close();
        }

        public override float Perimeter()
        {
            return 2 * 3.14f * _radius;
        }
        public override float Perimeter(float radius)
        {
            _radius = radius;
            return 2 * 3.14f * _radius;
        }

        public void PrintPerimeter()
        {
            Console.WriteLine("Периметр = {0}", this.Perimeter());
        }

        public void WritePerimeter()
        {
            string _path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            StreamWriter output = new StreamWriter(_path + "\\" + _filename, true);
            output.WriteLine("Площадь = {0}", this.Perimeter());
            output.Close();
        }
    }

    public class Rectangle : Figure
    {
        private string _filename = "RectangleOutput.txt";
        private float _length = 0, _width = 0;
        public Rectangle()
        {
            _name = "Прямоугольник";
        }
        public override float Square()
        {
            return _length * _width;
        }
        public override float Square(float length, float width)
        {
            _length = length;
            _width = width;
            return _length * _width;
        }

        public void PrintSquare()
        {
            Console.WriteLine("Площадь = {0}", this.Square());
        }

        public void WriteSquare()
        {
            string _path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            StreamWriter output = new StreamWriter(_path + "\\" + _filename, false);
            output.WriteLine("Площадь = {0}", this.Square());
            output.Close();
        }

        public override float Perimeter()
        {
            return (_length + _width) * 2;
        }
        public override float Perimeter(float length, float width)
        {
            _length = length;
            _width = width;
            return (_length + _width) * 2;
        }

        public void PrintPerimeter()
        {
            Console.WriteLine("Периметр = {0}", this.Perimeter());
        }

        public void WritePerimeter()
        {
            string _path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            StreamWriter output = new StreamWriter(_path + "\\" + _filename, true);
            output.WriteLine("Площадь = {0}", this.Perimeter());
            output.Close();
        }
    }

    public class Rhomb : Figure
    {
        private string _filename = "RhombOutput.txt";
        private float _side = 0, _height = 0;

        public Rhomb()
        {
            _name = "Ромб";
        }

        public override float Square()
        {
            return _side * _height;
        }

        public override float Square(float side, float height)
        {
            _side = side;
            _height = height;
            return _side * _height;
        }

        public void PrintSquare()
        {
            Console.WriteLine("Площадь = {0}", this.Square());
        }

        public void WriteSquare()
        {
            string _path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            StreamWriter output = new StreamWriter(_path + "\\" + _filename, false);
            output.WriteLine("Площадь = {0}", this.Square());
            output.Close();
        }
        public override float Perimeter()
        {
            return 4 * _side;
        }
        public override float Perimeter(float side)
        {
            _side = side;
            return 4 * _side;
        }

        public void PrintPerimeter()
        {
            Console.WriteLine("Периметр = {0}", this.Perimeter());
        }

        public void WritePerimeter()
        {
            string _path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            StreamWriter output = new StreamWriter(_path + "\\" + _filename, true);
            output.WriteLine("Площадь = {0}", this.Perimeter());
            output.Close();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle();
            Rectangle rectangle = new Rectangle();
            Rhomb rhomb = new Rhomb();
            MyDelegate FigureDelegate;
            int value = 1;
            while (value != 0)
            {
                Console.WriteLine("\nВыберите фигуру из списка:\n" +
                    "1 - Окружность\n2 - Прямоугольник\n3 - Ромб\n0 - Завершить программу");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 0:
                        {
                            value = 0;
                            break;
                        }

                    case 1:
                        {
                            Console.WriteLine("Введите радиус окружности: ");
                            float radius = float.Parse(Console.ReadLine());
                            circle.Square(radius);
                            circle.Perimeter(radius);
                            FigureDelegate = circle.PrintSquare;
                            FigureDelegate += circle.PrintPerimeter;
                            FigureDelegate?.Invoke();
                            Console.WriteLine("Хотите ли вы записать результат в файл? (1 - да, 0 - нет)");
                            if (int.Parse(Console.ReadLine()) == 1)
                            {
                                circle.WriteSquare();
                                circle.WritePerimeter();
                                Console.WriteLine("Результат записан");
                            }

                            break;
                        }

                    case 2:
                        {
                            Console.WriteLine("Введите длину прямоугольника: ");
                            float length = float.Parse(Console.ReadLine());
                            Console.WriteLine("Введите ширину прямоугольника: ");
                            float width = float.Parse(Console.ReadLine());
                            rectangle.Square(length, width);
                            rectangle.Perimeter(length, width);
                            FigureDelegate = rectangle.PrintSquare;
                            FigureDelegate += rectangle.PrintPerimeter;
                            FigureDelegate?.Invoke();
                            Console.WriteLine("Хотите ли вы записать результат в файл? (1 - да, 0 - нет)");
                            if (int.Parse(Console.ReadLine()) == 1)
                            {
                                rectangle.WriteSquare();
                                rectangle.WritePerimeter();
                                Console.WriteLine("Результат записан");
                            }

                            break;
                        }

                    case 3:
                        {
                            Console.WriteLine("Введите длину основания ромба: ");
                            float side = float.Parse(Console.ReadLine());
                            Console.WriteLine("Введите высоту ромба: ");
                            float height = float.Parse(Console.ReadLine());
                            rhomb.Square(side, height);
                            rhomb.Perimeter(side, height);
                            FigureDelegate = rhomb.PrintSquare;
                            FigureDelegate += rhomb.PrintPerimeter;
                            FigureDelegate?.Invoke();
                            Console.WriteLine("Хотите ли вы записать результат в файл? (1 - да, 0 - нет)");
                            if (int.Parse(Console.ReadLine()) == 1)
                            {
                                rhomb.WriteSquare();
                                rhomb.WritePerimeter();
                                Console.WriteLine("Результат записан");
                            }

                            break;
                        }
                }
            }
        }
    }
}