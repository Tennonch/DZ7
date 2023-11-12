//Задача 6

//1. Створити систему для обробки замовлень у ресторані.
//Використовуючи шаблон "Facade", щоб спростити взаємодію клієнта
//з різними підсистемами, такими як кухня, обслуговування та каса.

using System;

// Subsystems
class Kitchen
{
    public void PrepareFood()
    {
        Console.WriteLine("Food is being prepared in the kitchen");
    }
}

class Service
{
    public void ServeFood()
    {
        Console.WriteLine("Food is being served to the customer");
    }
}

class Cashier
{
    public void ReceivePayment()
    {
        Console.WriteLine("Payment received at the cashier");
    }
}

// Facade
class RestaurantFacade
{
    private Kitchen kitchen;
    private Service service;
    private Cashier cashier;

    public RestaurantFacade()
    {
        kitchen = new Kitchen();
        service = new Service();
        cashier = new Cashier();
    }

    public void PlaceOrder()
    {
        Console.WriteLine("Order placed by the customer");
        kitchen.PrepareFood();
        service.ServeFood();
        cashier.ReceivePayment();
        Console.WriteLine("Order completed");
    }
}

// Client
class Program
{
    static void Main()
    {
        RestaurantFacade restaurant = new RestaurantFacade();
        restaurant.PlaceOrder();

        Console.Read();
    }
}

//2. Реалізувати систему для вимірювання температури.
//Використовуючи шаблон "Adapter", щоб адаптувати
//різні типи термометрів до єдиного інтерфейсу.

//using System;

//Target
//interface ITemperatureSensor
//{
//    double GetTemperature();
//}

//Adaptee
//class CelsiusThermometer
//{
//    public double GetTemperatureCelsius()
//    {
//        Simulating temperature measurement in Celsius
//        return 25.5;
//    }
//}

//class FahrenheitThermometer
//{
//    public double GetTemperatureFahrenheit()
//    {
//        Simulating temperature measurement in Fahrenheit
//        return 77.9;
//    }
//}

//Adapter
//class CelsiusAdapter : ITemperatureSensor
//{
//    private CelsiusThermometer celsiusThermometer;

//    public CelsiusAdapter(CelsiusThermometer thermometer)
//    {
//        celsiusThermometer = thermometer;
//    }

//    public double GetTemperature()
//    {
//        return celsiusThermometer.GetTemperatureCelsius();
//    }
//}

//class FahrenheitAdapter : ITemperatureSensor
//{
//    private FahrenheitThermometer fahrenheitThermometer;

//    public FahrenheitAdapter(FahrenheitThermometer thermometer)
//    {
//        fahrenheitThermometer = thermometer;
//    }

//    public double GetTemperature()
//    {
//        return fahrenheitThermometer.GetTemperatureFahrenheit();
//    }
//}

//Client
//class Program
//{
//    static void Main()
//    {
//        CelsiusThermometer celsiusThermometer = new CelsiusThermometer();
//        FahrenheitThermometer fahrenheitThermometer = new FahrenheitThermometer();

//        ITemperatureSensor celsiusAdapter = new CelsiusAdapter(celsiusThermometer);
//        ITemperatureSensor fahrenheitAdapter = new FahrenheitAdapter(fahrenheitThermometer);

//        Console.WriteLine("Temperature in Celsius: " + celsiusAdapter.GetTemperature());
//        Console.WriteLine("Temperature in Fahrenheit: " + fahrenheitAdapter.GetTemperature());

//        Console.Read();
//    }
//}
