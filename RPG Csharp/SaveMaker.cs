using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RPG_Csharp
{
    class SaveMaker
    {
        string jsonString;
        string path = @"/save";
        public void save(Player p)
        {
            jsonString = JsonSerializer.Serialize<Player>(p);
            File.WriteAllText(path, jsonString);
        }
        
    }
}
