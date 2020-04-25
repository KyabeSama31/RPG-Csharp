using System;

namespace RPG_Csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            GameHandler GameHandler = new GameHandler();
            Utilisateur utilisateur = new Utilisateur();
            SaveMaker saveMaker = new SaveMaker();
            string pseudo;
            int correct = 0;
            Player p1;
            Bot b1;
            bool continuePlay = true;
            int roundNb = 0, xpB = 0, lvlB = 0;
            do //Mise en place du jeu avec la création du personnage 
            {
                Console.WriteLine("Entrez votre pseudo : ");
                pseudo = Utilisateur.saisirTexte();
                GameHandler.start(pseudo);
                utilisateur.confirmation();

                p1 = new Player(pseudo);
                p1.display();
                Console.WriteLine("Est-ce correct ?");
                Console.WriteLine("Oui : 1 \nNon : 0");
                correct = Utilisateur.saisirEntier();
                Console.WriteLine(" ");
            } while (correct == 0);


            do
            {
                Console.WriteLine("Attention ! Il y a un ennemi sur la route !");
                Console.WriteLine(" ");
                b1 = new Bot(xpB,lvlB);
                do
                {
                    b1.display();
                    utilisateur.confirmation();
                    Console.WriteLine("");

                    p1.actions(b1);
                    Console.WriteLine("");

                    if (b1.getLife() > 0)
                    {
                        Console.WriteLine("Votre adversaire riposte ! Soyez sur vos gardes !");
                        utilisateur.confirmation();
                        b1.actions(p1);
                        p1.display();
                    }

                } while (p1.getLife() > 0 && b1.getLife() > 0);

                if (p1.getLife()>0)
                {
                    p1.setXp();
                    b1.setXp();
                    xpB += b1.getXp();
                    lvlB += b1.getLvl();
                }

                continuePlay = utilisateur.continuePlay();

                roundNb++;

            } while (continuePlay);

            if (!continuePlay)
            {
                if (utilisateur.askYesNo("Voulez vous sauvegarder votre aventure ?"))
                {
                    saveMaker.save(p1);
                }
               

            }
            if (p1.getLife() <= 0)
            {
                Console.WriteLine("L'aventure est finie pour vous. Vous vous êtes bien battus !");
            }
            else
            {
                Console.WriteLine("Vous avez vaincu vos adversaires. Bien joué !");
            }
        }
    }
}

