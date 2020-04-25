using System;

namespace RPG_Csharp
{
    public class Utilisateur
    {
        /// <summary>
        /// Fonction permettant de demander la saisie d'une valeur entiere a l'utilisateur
        /// </summary>
        /// <returns>la valeur entiere saisie par l'utilisateur.</returns>
        public static int saisirEntier()
        {
            int val = -1;
            bool erreurSaisie = false;
            do
            {
                try
                {
                    val = int.Parse(Console.ReadLine());
                    erreurSaisie = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Veuillez saisir une valeur entiere");
                    erreurSaisie = true;
                }
            } while (erreurSaisie);

            return val;
        }

        /// <summary>
        /// Fonction permettant de demander la saisie d'une valeur reelle a l'utilisateur
        /// </summary>
        /// <returns>la valeur reelle saisie par l'utilisateur.</returns>
        public static double saisirReel()
        {
            double val = -1;
            bool erreurSaisie = false;
            do
            {
                try
                {
                    val = double.Parse(Console.ReadLine());
                    erreurSaisie = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Veuillez saisir une valeur double");
                    erreurSaisie = true;
                }
            } while (erreurSaisie);

            return val;
        }

        /// <summary>
        /// Fonction permettant de demander la saisie d'une chaine de caracteres a l'utilisateur
        /// </summary>
        /// <returns>la chaine de caracteres saisie par l'utilisateur.</returns>
        public static string saisirTexte()
        {
            return Console.ReadLine();
        }

        public void confirmation()
        {
            string inputConfirmation;
            do
            {
                Console.WriteLine("Appuyez sur Entrée pour continuer ");
                inputConfirmation = Utilisateur.saisirTexte();
            } while (inputConfirmation != "");
        }
        public int RollDices()
        {
            int dicesValue;
            var generator = new Random();
            dicesValue = generator.Next(1, 101);
            return dicesValue;
        }

        public bool continuePlay()
        {
            int choix;
            do
            {
                Console.WriteLine("Voulez vous continuer à jouer ?");
                Console.WriteLine("Oui : 1 \nNon : 2");
                choix = Utilisateur.saisirEntier();
            } while (choix < 1 || choix > 2);

            switch (choix)
            {
                case 1:
                    return true;
                case 2:
                    return false;
                default:
                    break;
            }
            return false;
        }

        public bool askYesNo(string message)
        {
            string inputConfirmation;
            do
            {
                Console.Write(message);
                Console.WriteLine(" (O/n)");
                inputConfirmation = Utilisateur.saisirTexte().ToLower();
            } while (inputConfirmation != "" && inputConfirmation != "o" && inputConfirmation != "n");
            return inputConfirmation == "" || inputConfirmation == "o";
        }
    }
}

