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
        private int xp;
        private int lvl;

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
            int choix;
            do
            {
                Console.WriteLine("Aventurier, tu as le choix entre 3 différentes classes ! ");
                Console.WriteLine("Le Guerrier pour qui une bonne baston vaux mieux que milles mots !");
                Console.WriteLine("Le Mage qui balance des boules de feu en plein milieu du champs de bataille");
                Console.WriteLine("Le Paladin qui n'hésitera pas à voler au secours des petites filles !");

                Console.WriteLine("Le Guerrier : 1 \nLe Mage : 2 \nLe Paladin : 3");
                choix = Utilisateur.saisirEntier();
            } while (choix < 1 || choix > 3);
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
            int succes = ChooseActions();
            if (succes == -1)
            {
                Console.WriteLine("Votre choix n'a pas été compris.");
                Console.WriteLine("Veuillez réessayer");
                succes = ChooseActions();
            }
            Console.WriteLine("Aventurier ! Lancez les dés !");
            gameHandler.confirmation();
            int result = gameHandler.RollDices();
            Console.WriteLine($"Vous avez obtenu \u001b[31m{result}\u001b[0m à votre lancé !");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            resultats(result, bot, succes);
        }

        private int ChooseActions()
        {
            double moy;
            bool possibility;
            int choix;
            do
            {
                possibility = true;
                do
                {
                    Console.WriteLine("Que voulez vous faire ? ");
                    Console.WriteLine("Il va tâter de mon épée (jet de physique) : 1");
                    Console.WriteLine("Il va voir de quoi ma magie est faite (jet de mental) : 2");
                    Console.WriteLine("Deus Vult (jet sur la moyenne entre la puissance et l'agilité) : 3");
                    choix = Utilisateur.saisirEntier();
                    Console.WriteLine(" ");
                } while (choix < 1 || choix > 3);

                switch (choix)
                {
                    case 1:
                        return physique;
                    case 2:
                        if (mana < 8)
                        {
                            Console.WriteLine("Vous n'avez pas assez de mana !");
                            possibility = false;
                            break;
                        }
                        else
                        {
                            mana -= 8;
                            return mental;
                        }
                    case 3:
                        if (mana < 5)
                        {
                            Console.WriteLine("Vous n'avez pas assez de mana !");
                            possibility = false;
                            break;
                        }
                        else
                        {
                            moy = (physique + agilite) / 2;
                            mana -= 5;
                            return (int)moy;
                        }
                    default:
                        return -1;
                }
            } while (!possibility);
            return -1;
        }

        public void damagePlayer(Items.Weapons weapons, int bonus)
        {
            Console.WriteLine(" ");
            int damages = weapons.dealDamages();
            Console.WriteLine($"Vous venez de recevoir \u001b[31m{damages}\u001b[0m points de dégats.");
            Console.WriteLine($"Votre vie est de \u001b[32m{vie}\u001b[0m pv.");
            vie -= damages + bonus;
            Console.WriteLine(" ");
        }

        public bool dodge(Bot bot)
        {
            int choix;
            do
            {
                Console.WriteLine("Voulez vous tenter d'esquiver ? ");
                Console.WriteLine("Oui : 1\nNon : 2 ");
                choix = Utilisateur.saisirEntier();
            } while (choix < 1 || choix > 2);

            switch (choix)
            {
                case 1:
                    return tentative();
                case 2:
                    return false;
                default:
                    return false;
            }
        }

        private void resultats(int result, Bot bot, int succes)
        {
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

        private bool tentative()
        {
            int succes = (int)(agilite + perception) / 2;
            int result = gameHandler.RollDices();
            Console.WriteLine($"Vous avez obtenu \u001b[31m{result}\u001b[0m.");
            Console.WriteLine("");
            if (result <= 5)
            {
                Console.WriteLine("Réussite Critique ! GG !");

                return true;
            }
            if (result <= succes)
            {
                Console.WriteLine("Bien joué vous l'avez évité !");
                return true;
            }
            if (result > succes && result < 95)
            {
                Console.WriteLine("Dommage c'est loupé ! ");
                return false;
            }
            Console.WriteLine("C'est un echec critique ! Vous tombez par terre ! -5pv");
            vie -= 5;
            return false;
        }

        public void setXp()
        {
            Console.WriteLine("Vous avez vaincu votre adversaire ! ");
            Console.WriteLine("Voici le moment d'être récompensé !");
            Random r = new Random();
            int gainXp = r.Next(5, 21);
            Console.WriteLine($"Vous venez de gagner {gainXp}");
            xp += gainXp;

            if (xp >= 100)
            {
                xp -= 100;
                lvl += 1;
                Console.WriteLine($"Vous gagnez un niveau ! Vous êtes niveau {lvl} !\n");
                newItem();
            }
        }

        private void newItem()
        {
            int choix;
            Console.WriteLine("Vous avez le droit à un nouvel item ! ");
            do
            {
                Console.WriteLine("Que voulez vous faire ? ");
                Console.WriteLine("Je vais récupérer l'arme du vaincu ! : 1");
                Console.WriteLine("J'ai cru apercevoir une potion dans sa poche : 2");
                Console.WriteLine("Son armure est magnifique ! Maintenant elle est à moi ! : 3");
                choix = Utilisateur.saisirEntier();
                Console.WriteLine(" ");
            } while (choix < 1 || choix > 3);

            switch (choix)
            {
                case 1:

                    break;
                default:
                    break;
            }
        }
    }
}
