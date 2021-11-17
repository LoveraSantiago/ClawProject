using System.Collections.Generic;

public class EditorUtils 
{
    public static List<string> getListaDeLevels()
    {
        List<string> listaDeLEvels = new List<string> {
            "0", "1", "2", "3", "4",
            "999999996", "999999997",
            "999999998", "999999999"
        };

        return listaDeLEvels;
    }
}
