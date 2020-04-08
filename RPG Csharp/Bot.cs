using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Csharp
{
    class Bot
    {
        public string pseudo { get; private set; }
        private int physique;
        private int mental;
        private int agilite;
        private int charisme;
        private int perception;
        private int vie;
        private int mana;
        private string classe;

        public Bot()
        {
            pseudo = GenerateName();
            classe = "Guerrier";
            physique = 80;
            mental = 50;
            agilite = 60;
            charisme = 40;
            perception = 70;
            vie = 20;
            mana = 15;
        }
        public void display()
        {
            Console.WriteLine($"Le Bot est \u001b[33m{pseudo}\u001b[0m.");
            Console.WriteLine($"C'est un {classe}.");
            Console.WriteLine($"Il a \u001b[31m{physique}\u001b[0m en physique.");
            Console.WriteLine($"Il a \u001b[31m{mental}\u001b[0m en mental.");
            Console.WriteLine($"Il a \u001b[31m{agilite}\u001b[0m en agilite.");
            Console.WriteLine($"Il a \u001b[31m{charisme}\u001b[0m en charisme.");
            Console.WriteLine($"Il a \u001b[31m{perception}\u001b[0m en perception.");
            Console.WriteLine($"Sa vie est de \u001b[32m{vie}\u001b[0m pv.");
            Console.WriteLine($"Sa mana est de \u001b[34m{mana}\u001b[0m pm.");
        }
        public string GenerateName()
        {
            Random lentgh = new Random();
            int len = lentgh.Next(1, 11);
            Random r = new Random();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            while (b < len)
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }
            return Name;
        }
        public int getLife()
        {
            return vie;
        }
        public void damageBot(Items.Weapons weapons, int bonus)
        {
            Console.WriteLine(" ");
            int damages = weapons.dealDamages();
            Console.WriteLine($"Vous venez d'infliger \u001b[31m{damages}\u001b[0m points de dégats à \u001b[33m{pseudo}\u001b[0m.");
            vie -= damages + bonus;
            Console.WriteLine(" ");

        }
    }
}
