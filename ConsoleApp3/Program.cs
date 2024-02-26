using System;
using System.Collections.Generic;

class Animal
{
    public string Nickname { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public int Energy { get; set; }
    public int Price { get; set; }
    public int MealQuantity { get; set; }

    public Animal(string nickname, int age, string gender, int energy, int price, int mealQuantity)
    {
        Nickname = nickname;
        Age = age;
        Gender = gender;
        Energy = energy;
        Price = price;
        MealQuantity = mealQuantity;
    }

    public virtual void Eat()
    {
        Energy++;
        MealQuantity++;
    }

    public virtual void Sleep()
    {
        Energy += 2;
    }

    public virtual void Play()
    {
        if (Energy > 0)
        {
            Energy--;
        }
        else
        {
            Console.WriteLine($"{Nickname} enerjisi bitdi. Onla artıq oynamaq olmur.");
        }
    }
}

class Cat : Animal
{
    public Cat(string nickname, int age, string gender, int energy, int price, int mealQuantity)
        : base(nickname, age, gender, energy, price, mealQuantity)
    {
    }

    public override void Sleep()
    {
        base.Sleep();
        if (Energy == 0)
        {
            Console.WriteLine($"{Nickname} yatdı. Enerjisi tezelendi.");
        }
    }
}

class PetShop
{
    List<Cat> cats = new List<Cat>();
    int totalMeals = 0;
    int totalPrice = 0;

    public void AddCat(Cat cat)
    {
        cats.Add(cat);
        totalPrice += cat.Price;
    }

    public void RemoveByNickname(string nickname)
    {
        foreach (var cat in cats)
        {
            if (cat.Nickname == nickname)
            {
                cats.Remove(cat);
                Console.WriteLine($"{nickname} adindaki pisik silindi.");
                break;
            }
        }
    }

    public void CalculateTotals()
    {
        foreach (var cat in cats)
        {
            totalMeals += cat.MealQuantity;
        }
    }

    public int TotalMeals { get { return totalMeals; } }
    public int TotalPrice { get { return totalPrice; } }
}

class Program
{
    static void Main(string[] args)
    {
        PetShop petShop = new PetShop();

        Cat tom = new Cat("Tom", 5, "female", 15, 15, 20);
        tom.Play();
        tom.Play();
        tom.Eat();

        petShop.AddCat(tom);
        
        petShop.RemoveByNickname("Tom");
        petShop.CalculateTotals();
        petShop.CalculateTotals();
        Console.WriteLine("Total meals served: " + petShop.TotalMeals);
        Console.WriteLine("Total price of cats: " + petShop.TotalPrice);
    }
}
