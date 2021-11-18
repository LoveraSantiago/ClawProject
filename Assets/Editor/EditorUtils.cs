using System.Collections.Generic;

public class EditorUtils 
{
    public static List<string> getListaDeLevels()
    {
        List<string> listaDeLEvels = new List<string> {
            "0", "1", "2", "3", "4",
            "Coletavel", "CacaNiquelIndividual",
            "CacaNiquelGeral", "TreinoPup"
        };

        return listaDeLEvels;
    }
}
