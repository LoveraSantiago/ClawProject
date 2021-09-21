using UnityEngine;

public class CacaNiquelResult    
{
    public bool isInicio { get; private set; }
    public bool isFinalizado { get { return !isInicio; } }
    public AbstractLevel.TIPO_GAME tipoGame { get; private set; }
    public Sprite[] sprResultados { get; private set; }
    public DisplayCacaNiquel.RESULTADO_CACANIQUEL[] resultados { get; private set; }

    public CacaNiquelResult()
    {
        isInicio = true;
    }

    public CacaNiquelResult(
        AbstractLevel.TIPO_GAME tipoGame, Sprite[] sprResultados, DisplayCacaNiquel.RESULTADO_CACANIQUEL[] resultados)
    {
        this.tipoGame = tipoGame;
        this.sprResultados = sprResultados;
        this.resultados = resultados;
    }
}
