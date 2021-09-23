using UnityEngine;

public class CacaNiquelResult    
{
    public bool isInicio { get; private set; }
    public bool isFinalizado { get { return !isInicio; } }
    public Sprite[] sprResultados { get; private set; }

    private AbstractLevel.TIPO_GAME tipoGame;
    private DisplayCacaNiquel.RESULTADO_CACANIQUEL[] resultados;

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

    public bool isResultSucesso(int indice)
    {
        return resultados[indice] == DisplayCacaNiquel.RESULTADO_CACANIQUEL.SUCESSO;
    }

    public bool isResultFail(int indice)
    {
        return resultados[indice] == DisplayCacaNiquel.RESULTADO_CACANIQUEL.FAIL;
    }

    public bool isTripleSucess()
    {
        return isResultSucesso(0) &&
               isResultSucesso(1) &&
               isResultSucesso(2);
    }

    public bool isTripleFail()
    {
        return isResultFail(0) &&
               isResultFail(1) &&
               isResultFail(2);
    }

    public bool isPupGeral()
    {
        return tipoGame == AbstractLevel.TIPO_GAME.CACANIQUEL_PUP_GERAL;
    }

    public bool isPupSingle()
    {
        return tipoGame == AbstractLevel.TIPO_GAME.CACANIQUEL_PUP_INDIVIDUAL;
    }
}
