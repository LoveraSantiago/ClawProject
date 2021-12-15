using System.Collections.Generic;

public class EditorUtils 
{
    public static List<string> getListaDeLevels()
    {
        List<string> listaDeLEvels = new List<string> {
            "0", "1", "2", "3", "4",

            "Coletavel", "LevelPao", "LevelMaca", "LevelLeite",
            "LevelCoco", "LevelAspargo", "LevelLaranja", "LevelEstrelaMarinha",

            "CacaNiquelIndividual", "CacaNiquelGeral", "TreinoPup",
        };

        return listaDeLEvels;
    }
}
