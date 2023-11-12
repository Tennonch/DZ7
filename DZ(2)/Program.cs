﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Задача 2
namespace Builder
{
    class Program
    {
        class Pizza
        {
            string dough;
            string sauce;
            string topping;
            public Pizza() { }
            public void SetDough(string d) { dough = d; }
            public void SetSauce(string s) { sauce = s; }
            public void SetTopping(string t) { topping = t; }
            public void Info()
            {
                Console.WriteLine("Dough: {0}\nSauce: {1}\nTopping: {2}", dough, sauce, topping);
            }
        }

        // Abstract Builder
        abstract class PizzaBuilder
        {
            protected Pizza pizza;
            public PizzaBuilder() { }
            public Pizza GetPizza() { return pizza; }
            public void CreateNewPizza() { pizza = new Pizza(); }
            public abstract void BuildDough();
            public abstract void BuildSauce();
            public abstract void BuildTopping();
        }

        // Concrete Builder
        class HawaiianPizzaBuilder : PizzaBuilder
        {
            public override void BuildDough() { pizza.SetDough("cross"); }
            public override void BuildSauce() { pizza.SetSauce("mild"); }
            public override void BuildTopping()
            {
                pizza.SetTopping("ham+pineapple");
            }
        }

        // Concrete Builder
        class SpicyPizzaBuilder : PizzaBuilder
        {
            public override void BuildDough()
            {
                pizza.SetDough("panbaked");
            }
            public override void BuildSauce() { pizza.SetSauce("hot"); }
            public override void BuildTopping()
            {
                pizza.SetTopping("pepperoni+salami");
            }
        }

        // Concrete Builder for Margarita Pizza
        class MargaritaPizzaBuilder : PizzaBuilder
        {
            public override void BuildDough()
            {
                pizza.SetDough("thin");
            }

            public override void BuildSauce()
            {
                pizza.SetSauce("tomato");
            }

            public override void BuildTopping()
            {
                pizza.SetTopping("mozzarella+basil");
            }
        }

        // Director
        class Waiter
        {
            private PizzaBuilder pizzaBuilder;
            public void SetPizzaBuilder(PizzaBuilder pb)
            {
                pizzaBuilder = pb;
            }
            public Pizza GetPizza() { return pizzaBuilder.GetPizza(); }
            public void ConstructPizza()
            {
                pizzaBuilder.CreateNewPizza();
                pizzaBuilder.BuildDough();
                pizzaBuilder.BuildSauce();
                pizzaBuilder.BuildTopping();
            }
        }

        // Client
        class BuilderExample
        {
            public static void Main(String[] args)
            {
                Waiter waiter = new Waiter();

                // Ordering Hawaiian Pizza
                PizzaBuilder hawaiianPizzaBuilder = new HawaiianPizzaBuilder();
                waiter.SetPizzaBuilder(hawaiianPizzaBuilder);
                waiter.ConstructPizza();
                Pizza pizza = waiter.GetPizza();
                pizza.Info();

                Console.WriteLine();

                // Ordering Spicy Pizza
                PizzaBuilder spicyPizzaBuilder = new SpicyPizzaBuilder();
                waiter.SetPizzaBuilder(spicyPizzaBuilder);
                waiter.ConstructPizza();
                pizza = waiter.GetPizza();
                pizza.Info();

                Console.WriteLine();

                // Ordering Margarita Pizza
                PizzaBuilder margaritaPizzaBuilder = new MargaritaPizzaBuilder();
                waiter.SetPizzaBuilder(margaritaPizzaBuilder);
                waiter.ConstructPizza();
                pizza = waiter.GetPizza();
                pizza.Info();

                Console.ReadKey();
            }
        }
    }
}