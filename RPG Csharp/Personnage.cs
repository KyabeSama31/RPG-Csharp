using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Csharp
{
    class Personnage
    {
        protected GameHandler gameHandler = new GameHandler();
        protected Item.Armor armor = new Item.Armor();
        protected ArmorListManager ArmorListManager = new ArmorListManager();
        protected Utilisateur utilisateur = new Utilisateur();
        protected Dictionary<string, dynamic> Inventory = new Dictionary<string, dynamic>();

        protected string pseudo;
        protected int physique;
        protected int mental;
        protected int agilite;
        protected int charisme;
        protected int perception;
        protected int vie;
        protected int mana;
        protected string classe;
        protected int xp;
        protected int lvl;


        public int getLife()
        {
            return vie;
        }
        public int getXp()
        {
            return xp;
        }
        public int getLvl()
        {
            return lvl;
        }

        public void display()
        {
            Console.WriteLine($"Pseudo : \u001b[33m{pseudo}\u001b[0m.");
            Console.WriteLine($"Classe : {classe}.");
            Console.WriteLine($"\u001b[31m{physique}\u001b[0m en physique.");
            Console.WriteLine($"\u001b[31m{mental}\u001b[0m en mental.");
            Console.WriteLine($"\u001b[31m{agilite}\u001b[0m en agilite.");
            Console.WriteLine($"\u001b[31m{charisme}\u001b[0m en charisme.");
            Console.WriteLine($"\u001b[31m{perception}\u001b[0m en perception.");
            Console.WriteLine($"\u001b[32m{vie}\u001b[0m pv.");
            Console.WriteLine($" \u001b[34m{mana}\u001b[0m pm.");
            Console.WriteLine($"Niveau \u001b[34m{lvl}\u001b[0m.");
        }
        public void setXp()
        {
            Console.WriteLine("Voici le moment d'être récompensé !");
            Random r = new Random();
            int gainXp = r.Next(5, 21);
            Console.WriteLine($"Gain d'xp: {gainXp}");
            xp += gainXp;

            if (xp >= 100)
            {
                xp -= 100;
                lvl += 1;
                Console.WriteLine($"Lvl up ! Niveau {lvl} !\n");
                newItem(-1);
            }
        }

        protected int newItem(int choix)
        {
            switch (choix)
            {
                case 1:
                   return Inventory["Arme"].setType();
                case 2:
                    try
                    {
                        Inventory.Add("Potion", new Item.Potion());
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("Vous avez déjà une potion sur vous. ");
                        return -1;
                    }
                    break;
                case 3:
                    return ArmorListManager.getNewArmor(Inventory);
                default:
                    return -1;
            }
            return -1;
        }
    }
}
