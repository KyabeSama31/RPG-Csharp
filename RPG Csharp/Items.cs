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
                    case "SwordUp":
                        return r.Next(1, 9);
                    case "StaffdUp":
                        return r.Next(1, 6);
                    case "BattleAxeUp":
                        return r.Next(1, 11);
                    default:
                        return 0;
                }
            }

            public int setType()
            {
                switch (type)
                {
                    case "Sword":
                        type = "SwordUp";
                        return 1;
                    case "Staff":
                        type = "StaffdUp";
                        return 1;
                    case "BattleAxe":
                        type = "BattleAxeUp";
                        return 1;
                    default:
                        Console.WriteLine("Votre arme est meilleure que la sienne.");
                        return -1;

                }
            }

        }
       
       public class Potions
        {
            private int healingBonus;
            public Potions()
            {
                healingBonus = 5;
            }
            public int usePotion()
            {
                return healingBonus;
            }
        }


        public class Armors
        {
            private int armorValue=0;
            public Armors(string type)
            {
                
                switch (type)
                {
                    case "plastron":
                        armorValue += 5;
                        break;
                    case "casque":
                        armorValue += 3;
                        break;
                    case "pantalon":
                        armorValue += 4;
                        break;
                    case "bottes":
                        armorValue += 3;
                        break;

                    default:
                        break;
                }
            }
            public Armors()
            {

            }
            public int getArmorValue()
            {
                return armorValue;
            }
        }
    }
}
