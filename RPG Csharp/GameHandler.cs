using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Csharp
{
    class GameHandler
    {
        //Passer les fonctions dans Utilisateur
        public void start(string pseudo)
        {
            Console.WriteLine($"Bienvenue à vous cher {pseudo} !");
            Console.WriteLine("Vous allez rentrer vos caractéristiques qui définiront le succès ou l'échec de vos actions ");
            Console.WriteLine("Le total de vos caractéristiques ne doit pas dépasser 290 ! Choississez Sagement !");
            Console.WriteLine("Chaque statistique ne doit pas dépasser 80 ! ");
            Console.WriteLine("");
        }


    }
}
