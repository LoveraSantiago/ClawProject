public class ChallengesUtils 
{
    public static bool[] toArray(int challenge)
    {
        switch (challenge)
        {
            case 0: return new bool[] { false, false, false };
            case 1: return new bool[] { true , false, false };
            case 2: return new bool[] { false, true , false };
            case 3: return new bool[] { true , true , false };
            case 4: return new bool[] { false, false, true };
            case 5: return new bool[] { true , false, true };
            case 6: return new bool[] { false, true , true };
            case 7: return new bool[] { true , true , true };
        }
        return null;
    }

    public static int toInteiro(bool[] challenges)
    {
        if (challenges.Length != 3) return 0;

        if (!challenges[0] && !challenges[1] && !challenges[2]) return 0;
        if ( challenges[0] && !challenges[1] && !challenges[2]) return 1;
        if (!challenges[0] &&  challenges[1] && !challenges[2]) return 2;
        if ( challenges[0] &&  challenges[1] && !challenges[2]) return 3;
        if (!challenges[0] && !challenges[1] &&  challenges[2]) return 4;
        if ( challenges[0] && !challenges[1] &&  challenges[2]) return 5;
        if (!challenges[0] &&  challenges[1] &&  challenges[2]) return 6;
        if ( challenges[0] &&  challenges[1] &&  challenges[2]) return 7;

        return 0;
    }

    public static int toQtdEstrelas(int challenge)
    {
        bool[] resultados = toArray(challenge);
        int total = 0;
        for(int contador = 0; contador < resultados.Length; contador++)
        {
            if (resultados[contador])
            {
                total++;
            }
        }
        return total;
    }
}
