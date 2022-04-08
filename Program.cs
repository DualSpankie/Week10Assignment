using System;
using System.Collections.Generic;

namespace Week10Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Player a1 = new Player("", 12);
            a1.PrintName();
            Enemy a2 = new Enemy("", 10);
            a2.PrintName();

            a1.opponent = a2;
            a2.opponent = a1;

            List<Fighter> fighters = new List<Fighter>();
            fighters.Add(a1);
            fighters.Add(a2);

            bool gameOver = false;

            while (gameOver == false)
            {
                foreach (Fighter f in fighters)
                {
                    if (f.dead)
                        gameOver = true;

                    f.TakeAction();
                    f.Dies();
                }
            }

        }
    }

    public class Fighter
    {
        public int currentHealth = 0;
        public int maxHealth;
        public bool dead = false;
        string name;
        public Fighter opponent;

        public Fighter(string n, int mh)
        {

            maxHealth = mh;
            name = n;

            currentHealth = maxHealth;

        }
        public string Name
        {
            get { return name; }
            set { name = value; }

        }
        public int Max
        {
            get { return maxHealth; }
            set { maxHealth = value; }

        }
        public void PrintName()
        {
            Console.WriteLine(name + "Health " + maxHealth);
        }
        public virtual void TakeAction()
        {

        }
        public void Dies()
        {
            if (opponent.maxHealth == 0)
                Console.WriteLine("The" + name + " has died");
        }
    }

    class Enemy : Fighter
    {

        public Enemy(string n, int mh) : base(n, mh)
        {

        }

        public override void TakeAction()
        {
            opponent.currentHealth -= 5;
            Console.WriteLine("Attacking player for 5 point of damage!");
        }
    }

    class Player : Fighter
    {
        public int takePotions = 3;

        public Player(string n, int mh) : base(n, mh)
        {

        }

        public override void TakeAction()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1 for attack, 2 for potion");

            int choice = Int32.Parse(Console.ReadLine());

            if (choice == 1)
            {
                opponent.currentHealth -= 3;
                Console.WriteLine("Attacked the enemy for 3 point of damage");
            }



            if (choice == 2)
                if (takePotions > 0)
                {
                    currentHealth += 7;
                    takePotions--;
                    Console.WriteLine("Restored 7 points of health");
                }


        }
    }
}