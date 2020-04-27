using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Csharp
{
    class Bot : Personnage
    {

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
            Inventory.Add("Arme", new Item.Weapon(classe));
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

        public void damageBot(Item.Weapon weapons, int bonus)//Fonction utilisée quand le bot reçoit des dégats 
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

            int result = utilisateur.RollDices();


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
        private new void newItem(int choix)
        {
            int error = 1;
            do
            {
                Random r = new Random();
                choix = r.Next(1, 3);

               error = base.newItem(choix);

            } while (error == -1);
        }
    }
}
