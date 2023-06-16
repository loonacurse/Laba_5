using System;

//Створити суперклас Кухонний прилад і підкласи Посуд, Вилка, Тарілка, Телевізор. Стіл. За допомогою конструктора задати вагу кожного приладу.
//Реалізувати методи: увімкнути електроприлад, помити посуд. Вивести місцеперебування приладів

namespace Laba_5
{
        class Realize
        {
            static void Main(string[] args)
            {
            Dishes dishes = new Dishes(354);
            Interface1 inty1;
            inty1 = dishes;
            inty1.Arrangment();
            dishes.Wash();
            Interface2 inty2;
            Dishes fork = new Fork(45);
            fork.Wash();
            inty2 = fork;
            inty2.P_Weight();
            TVset tv = new TVset(1345);
            tv.Turn_On();
            inty2 = tv;
            inty2.P_Weight();
            Table<Table_T> table = new Table<Table_T>(3459);
            Table_T m = new Table_T("скло", 1);           
            table.Table_Ch(m);
            inty2= table;
            inty2.P_Weight();
            Console.ReadKey();
            }
        }
    abstract class Kitchen_Appliance
        {
            public int Weight { get; set; }
            public Kitchen_Appliance(int weight)
            {
                Weight = weight;
            }
            public virtual void P_Weight() { }             
    }
    class Dishes : Kitchen_Appliance,Interface1,Interface2
    {
        public Dishes(int weight) : base(weight) { }
        public virtual void Wash() => Console.WriteLine($"\nПосуд помито\n");
        public override void P_Weight()=>Console.WriteLine($"\nПосуд важить --> {this.Weight} г\n");
        public void Arrangment()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\t\tСтiл знаходиться посеред кiмнати\n");
            Console.WriteLine("\n\t\tТелевiзор висить на стiнi\n");
            Console.WriteLine("\n\t\tТарiлка лежить на столi\n");
            Console.WriteLine("\n\t\tВиделка знаходиться лiворуч вiд тарiлки\n");
            Console.WriteLine("\n\t\tПосуд в сушарцi\n");
            Console.ForegroundColor = ConsoleColor.Green;
        }
    }

    class Fork : Dishes,Interface2
    {
        public Fork(int weight) : base(weight) { }
        public override void Wash() => Console.WriteLine($"\nВилка помита\n");
        public override void P_Weight() => Console.WriteLine($"\nВилка важить --> {this.Weight} г\n");
    }

    class Plate : Dishes,Interface2
    {
        public Plate(int weight) : base(weight) { }
        public override void Wash() => Console.WriteLine($"\nТарілка помита\n");
        public override void P_Weight() => Console.WriteLine($"\nТарiлка важить --> {this.Weight} г\n");
    }

    class TVset:Kitchen_Appliance,Interface2
    {
        public TVset(int weight) : base(weight) { }
        public void Turn_On() => Console.WriteLine("\nТелевiзор ввiмкнено\n");
        public override void P_Weight() => Console.WriteLine($"\nТелевiзор важить --> {this.Weight} г\n");
    }

    class Table<T> : Kitchen_Appliance, Interface2
        where T:Table_T   
    {
        public Table(int weight) : base(weight) { }
        public override void P_Weight() => Console.WriteLine($"\nСтiл важить --> {this.Weight} г\n");
        public void Table_Ch(T ch) => Console.WriteLine($"\nМатерiал -> {ch.M_Table}\n\n\nКiлькiсть нiжок столу -> {ch.Value}\n");
    }

    class Table_T
    {
        public string M_Table { get; set; }
        public int Value { get; set; }
        public Table_T(string material,int value) { M_Table = material; Value = value; }
    }
}