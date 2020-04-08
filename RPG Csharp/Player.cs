﻿using System;
using System.Collections.Generic;


namespace RPG_Csharp
{
    class Player
    {
        GameHandler gameHandler = new GameHandler();

        Dictionary<string, Items.Weapons> Inventory = new Dictionary<string, Items.Weapons>();

        public string pseudo { get; private set; }
        private int physique;
        private int mental;
        private int agilite;
        private int charisme;
        private int perception;
        private int vie;
        private int mana;
        private string classe;
        public Player(string newPseudo)
        {
            pseudo = setPseudo(newPseudo);

            do
            {
                classe = pickClass();
            } while (classe == "error");
            switch (classe)
            {
                case "Guerrier":
                    vie = 25;
                    mana = 10;
                    break;
                case "Mage":
                    vie = 10;
                    mana = 25;
                    break;
                case "Paladin":
                    vie = 20;
                    mana = 20;
                    break;
            }
            int sommeStat, max = 80;
            do
            {
                Console.WriteLine("Indiquez votre statistique en Physique : ");
                physique = Utilisateur.saisirEntier();
                Console.WriteLine("Indiquez votre statistique en Mental : ");
                mental = Utilisateur.saisirEntier();
                Console.WriteLine("Indiquez votre statistique en Agilité : ");
                agilite = Utilisateur.saisirEntier();
                Console.WriteLine("Indiquez votre statistique en Charisme : ");
                charisme = Utilisateur.saisirEntier();
                Console.WriteLine("Indiquez votre statistique en Perception : ");
                perception = Utilisateur.saisirEntier();

                sommeStat = physique + mental + agilite + charisme + perception;

            } while (sommeStat != 290 && physique < max && mental < max && agilite < max && charisme < max && perception < max);
            Inventory.Add("Arme", new Items.Weapons(classe)); // On ajoute une arme à l'inventaire en fonction de la classe choisie (ref constructeur Weapons)
        }
        public void display()
        {
            Console.WriteLine($"Vous êtes \u001b[33m{pseudo}\u001b[0m.");
            Console.WriteLine($"Vous avez choisi la classe {classe}.");
            Console.WriteLine($"Vous avez \u001b[31m{physique}\u001b[0m en physique.");
            Console.WriteLine($"Vous avez \u001b[31m{mental}\u001b[0m en mental.");
            Console.WriteLine($"Vous avez \u001b[31m{agilite}\u001b[0m en agilite.");
            Console.WriteLine($"Vous avez \u001b[31m{charisme}\u001b[0m en charisme.");
            Console.WriteLine($"Vous avez \u001b[31m{perception}\u001b[0m en perception.");
            Console.WriteLine($"Votre vie est de \u001b[32m{vie}\u001b[0m pv.");
            Console.WriteLine($"Votre mana est de \u001b[34m{mana}\u001b[0m pm.");
        }

        public int getLife()
        {
            return vie;
        }
        public string setPseudo(string newPseudo)
        {
            return newPseudo;
        }
        private string pickClass()
        {

            Console.WriteLine("Aventurier, tu as le choix entre 3 différentes classes ! ");
            Console.WriteLine("Le Guerrier pour qui une bonne baston vaux mieux que milles mots !");
            Console.WriteLine("Le Mage qui balance des boules de feu en plein milieu du champs de bataille");
            Console.WriteLine("Le Paladin qui n'hésitera pas à voler au secours des petites filles !");

            Console.WriteLine("Le Guerrier : 1 \nLe Mage : 2 \nLe Paladin : 3");
            int choix = Utilisateur.saisirEntier();
            switch (choix)
            {
                case 1:
                    return "Guerrier";
                case 2:
                    return "Mage";
                case 3:
                    return "Paladin";
                default:
                    return "error";
            }
        }

        public void actions(Bot bot)
        {
            int choix;
            do
            {
                Console.WriteLine("Que voulez vous faire ? ");
                Console.WriteLine("Il va tâter de mon épée (jet de physique) : 1");
                Console.WriteLine("Il va voir de quoi ma magie est faite (jet de mental) : 2");
                Console.WriteLine("Deus Vult (jet sur la moyenne entre la puissance et l'agilité) : 3");
                choix = Utilisateur.saisirEntier();
                Console.WriteLine(" ");
            } while (choix <= 1 && choix >= 3);
            int succes = 0;
            double moy;
            switch (choix)
            {
                case 1:
                    succes = physique;
                    break;
                case 2:
                    succes = mental;
                    mana -= 5;
                    break;
                case 3:
                    moy = (physique + agilite) / 2;
                    succes = (int)moy;
                    break;
            }

            Console.WriteLine("Aventurier ! Lancez les dés !");
            gameHandler.confirmation();
            int result = gameHandler.RollDices();
            Console.WriteLine($"Vous avez obtenu \u001b[31m{result}\u001b[0m à votre lancé !");
            Console.WriteLine(" ");
            Console.WriteLine(" ");

            if (result <= 5)
            {
                Console.WriteLine("C'est une réussite critique ! Vous êtes en veine aujourd'hui ! ");
                bot.damageBot(Inventory["Arme"], 5);

            }
            if (result <= succes)
            {
                Console.WriteLine("Votre action est réussie ! Bien joué Aventurier ! ");
                bot.damageBot(Inventory["Arme"], 0);
            }
            else if (result > succes && result < 95)
            {
                Console.WriteLine("C'est raté ! désolé à vous.");
                //Conséquence à choisir
            }
            else
            {
                Console.WriteLine("C'est un echec critique ! Esperons que l'univers soit assez clément ! ");
                //Conséquence à choisir

            }
        }
    }
}