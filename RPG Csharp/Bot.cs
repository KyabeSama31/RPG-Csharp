using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Csharp
{
    class Bot
    {
        GameHandler gameHandler = new GameHandler();
        Items.Armors armor = new Items.Armors();

        Dictionary<string, dynamic> Inventory = new Dictionary<string, dynamic>();

        public string pseudo { get; private set; }
        private int physique;
        private int mental;
        private int agilite;
        private int charisme;
        private int perception;
        private int vie;
        private int mana;
        private string classe;
        private int xp;
        private int lvl;

        public Bot(int newXp, int newLvl)
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
            xp = newXp;
            lvl = newLvl;
            Inventory.Add("Arme", new Items.Weapons(classe));
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
            Console.WriteLine($"Il est de niveau \u001b[34m{lvl}\u001b[0m pm.");
        }
        private string GenerateName()//code récupéré sur internet pour générer le nom du bot à sa création
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
        public int getXp()
        {
            return xp;
        }
        public int getLvl()
        {
            return lvl;
        }

        public void damageBot(Items.Weapons weapons, int bonus)//Fonction utilisée quand le bot reçoit des dégats 
        {
            Console.WriteLine(" ");
            int damages = weapons.dealDamages();
            Console.WriteLine($"Vous venez d'infliger \u001b[31m{damages}\u001b[0m points de dégats à \u001b[33m{pseudo}\u001b[0m.");
            vie -= damages + bonus - armor.getArmorValue();//On prend en compte les dégats de l'armen 
            Console.WriteLine(" ");

        }
        /*
         * 
         * Ces fonctions sont basiquement les mêmes que celles pour le joueur.
         * Les choix sont remplacés par des nombres aléatoires.
         * Pour l'instant le bot étant tout le temps un guerrier, sa seule attaque est un coup classique.
         * 
         */
        public void actions(Player player)
        {
            int succes = physique;

            int result = gameHandler.RollDices();


            if (result <= 5)
            {
                Console.WriteLine("C'est une réussite critique ! La chance souri à vos ennemis ! ");
                player.damagePlayer(Inventory["Arme"], 5);
            }
            if (result <= succes)
            {
                Console.WriteLine("Son action est réussie ! Faîtes plus attention la prochaine fois ! ");
                bool dodge = player.dodge(this);

                if (!dodge)
                {
                    player.damagePlayer(Inventory["Arme"], 0);
                } 
                else
                {
                    Console.WriteLine("Vous avez réussi à éviter l'attaque ennemie.");
                }

            }
            else if (result > succes && result < 95)
            {
                Console.WriteLine("Il s'est loupé ! Bien joué.");
                //Conséquence à choisir
            }
            else
            {
                Console.WriteLine("C'est un echec critique ! Les Dieux sont avec vous ! ");
                //Conséquence à choisir

            }
        }

        public void setXp()
        {
            Console.WriteLine("Votre adversaire aussi devient plus fort. Attention ! ");
            Random r = new Random();
            int gainXp = r.Next(5, 21);
            xp += gainXp;

            if (xp >= 100)
            {
                xp -= 100;
                lvl += 1;
                Console.WriteLine($"Attention ! Les ennemis s'adaptent, ils sont niveau {lvl} !\n");
                newItem();
            }
        }
        private void newItem()
        {
            int choix;
            int error = 1;
            do
            {
                Random r = new Random();
                choix = r.Next(1, 3);

                switch (choix)
                {
                    case 1:
                        error = Inventory["Arme"].setType();
                        break;
                    case 2:
                        try
                        {
                            Inventory.Add("Potion", new Items.Potions());
                        }
                        catch (ArgumentException)
                        {
                            error = -1;
                        }
                        break;
                    case 3:
                        error = getNewArmor();
                        break;
                    default:
                        break;
                }
            } while (error == -1);

        }
        private int getNewArmor()
        {
            try
            {
                Inventory.Add("Plastron", new Items.Armors("plastron"));
            }
            catch (ArgumentException)
            {
                try
                {
                    Inventory.Add("Casque", new Items.Armors("casque"));
                }
                catch (ArgumentException)
                {
                    try
                    {
                        Inventory.Add("Pantalon", new Items.Armors("pantalon"));
                    }
                    catch (ArgumentException)
                    {
                        try
                        {
                            Inventory.Add("Bottes", new Items.Armors("bottes"));
                        }
                        catch (ArgumentException)
                        {
                            return -1;
                        }
                    }
                }
            }
            return 1;
        }
    }

}
