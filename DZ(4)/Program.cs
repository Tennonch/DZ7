//Завдання 4

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    // Компонент
    interface IChristmasTree
    {
        void Display();
    }

    // Конкретний компонент
    class ChristmasTree : IChristmasTree
    {
        public void Display()
        {
            Console.WriteLine("Базова ялинка");
        }
    }

    // Декоратор
    abstract class TreeDecorator : IChristmasTree
    {
        protected IChristmasTree decoratedTree;

        public TreeDecorator(IChristmasTree decoratedTree)
        {
            this.decoratedTree = decoratedTree;
        }

        public virtual void Display()
        {
            decoratedTree.Display();
        }
    }

    // Конкретні декоратори
    class ChristmasLights : TreeDecorator
    {
        public ChristmasLights(IChristmasTree decoratedTree) : base(decoratedTree)
        {
        }

        public override void Display()
        {
            base.Display();
            AddLights();
        }

        private void AddLights()
        {
            Console.WriteLine(" + Гірлянди");
        }
    }

    class ChristmasOrnaments : TreeDecorator
    {
        public ChristmasOrnaments(IChristmasTree decoratedTree) : base(decoratedTree)
        {
        }

        public override void Display()
        {
            base.Display();
            AddOrnaments();
        }

        private void AddOrnaments()
        {
            Console.WriteLine(" + Прикраси");
        }
    }

    // Клієнт
    class Program
    {
        static void Main()
        {
            // Створюємо базову ялинку
            IChristmasTree basicTree = new ChristmasTree();

            // Додаємо гірлянди до ялинки
            IChristmasTree treeWithLights = new ChristmasLights(basicTree);

            // Додаємо прикраси до ялинки з гірляндами
            IChristmasTree treeWithLightsAndOrnaments = new ChristmasOrnaments(treeWithLights);

            // Виводимо оформлені ялинки
            Console.WriteLine("Базова ялинка:");
            basicTree.Display();

            Console.WriteLine("\nЯлинка з гірляндами:");
            treeWithLights.Display();

            Console.WriteLine("\nЯлинка з гірляндами та прикрасами:");
            treeWithLightsAndOrnaments.Display();

            Console.ReadKey();
        }
    }
}
