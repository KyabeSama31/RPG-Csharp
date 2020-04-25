using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Csharp
{
    class ArmorListManager
    {
        public int getNewArmor(Dictionary<string,dynamic> Inventory)
        {
            try
            {
                Inventory.Add("Plastron", new Item.Armor("plastron"));
            }
            catch (ArgumentException)
            {
                try
                {
                    Inventory.Add("Casque", new Item.Armor("casque"));
                }
                catch (ArgumentException)
                {
                    try
                    {
                        Inventory.Add("Pantalon", new Item.Armor("pantalon"));
                    }
                    catch (ArgumentException)
                    {
                        try
                        {
                            Inventory.Add("Bottes", new Item.Armor("bottes"));
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
}
