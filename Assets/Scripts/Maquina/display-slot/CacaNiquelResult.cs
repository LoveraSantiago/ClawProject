using UnityEngine;

public class CacaNiquelResult    
{
    public bool isInicio { get; private set; }
    public bool isFinalizado { get { return !isInicio; } }

    public CacaNiquelResult()
    {
        isInicio = true;
    }

    public CacaNiquelResult(AbstractLevel.TIPO_GAME tipoGame, Sprite[] resultados)
    {

    }
}
