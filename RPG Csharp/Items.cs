using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Csharp
{
    class Items
    {
        public class Weapons
        {
            private string type;

            public Weapons(string classe) // Le constructeur Weapons va générer une arme en fonction de la classe. 
            {
                switch (classe)
                {
                    case "Guerrier":
                        type = "Sword";
                        break;
                    case "Mage":
                        type = "Staff";
                        break;
                    case "Paladin":
                        type = "BattleAxe";
                        break;
                }
            }

            public int dealDamages()
            {
                Random r = new Random();
                switch (type)
                {
                    case "Sword":
                        return r.Next(1, 7);
                    case "Staff":
                        return r.Next(1, 4);
                    case "BattleAxe":
                        return r.Next(1, 9);
                    default:
                        return 0;
                }
            }

        }

        class Potions
        {

        }

        class Armors
        {

        }
    }
}
