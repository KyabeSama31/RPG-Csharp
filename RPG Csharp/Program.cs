using System;

namespace RPG_Csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            GameHandler GameHandler = new GameHandler();
            string pseudo;
            int correct = 0;
            Player p1;
            Bot b1;
            do //Mise en place du jeu avec la création du personnage 
            {
                Console.WriteLine("Entrez votre pseudo : ");
                pseudo = Utilisateur.saisirTexte();
                GameHandler.start(pseudo);
                GameHandler.confirmation();

                p1 = new Player(pseudo);
                p1.display();
                Console.WriteLine("Est-ce correct ?");
                Console.WriteLine("Oui : 1 \nNon : 0");
                correct = Utilisateur.saisirEntier();
                Console.WriteLine(" ");
            } while (correct == 0);
            Console.WriteLine("Attention ! Il y a un ennemi sur la route !");
            Console.WriteLine(" ");
            b1 = new Bot();
            do
            {
                b1.display();
                GameHandler.confirmation();
                Console.WriteLine("");
                p1.actions(b1);
                Console.WriteLine("");
            } while (p1.getLife() > 0 && b1.getLife() > 0);
        }
    }
}

