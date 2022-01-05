using UnityEngine;

public class CacaNiquelEventoDto    
{
    public bool isInicio { get; private set; }
    public bool isFinalizado { get { return !isInicio; } }
    public Sprite[] sprResultados { get; private set; }

    private bool isSingle;
    private CacaNiquelResultadoEnum[] resultados;

    public CacaNiquelEventoDto()
    {
        isInicio = true;
    }

    private CacaNiquelEventoDto(bool isSingle, Sprite[] sprResultados, CacaNiquelResultadoEnum[] resultados)
    {
        this.isSingle = isSingle;
        this.sprResultados = sprResultados;
        this.resultados = resultados;
    }

    public bool isResultSucesso(int indice)
    {
        return resultados[indice] == CacaNiquelResultadoEnum.SUCESSO;
    }

    public bool isResultFail(int indice)
    {
        return resultados[indice] == CacaNiquelResultadoEnum.FAIL;
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
        return !isPupSingle();
    }

    public bool isPupSingle()
    {
        return isSingle;
    }

    public static CacaNiquelEventoDto ofSingle(Sprite[] sprResultados, CacaNiquelResultadoEnum[] resultados)
    {
        CacaNiquelEventoDto evento = new CacaNiquelEventoDto(true, sprResultados, resultados);
        return evento;
    }

    public static CacaNiquelEventoDto ofGeral(Sprite[] sprResultados, CacaNiquelResultadoEnum[] resultados)
    {
        CacaNiquelEventoDto evento = new CacaNiquelEventoDto(false, sprResultados, resultados);
        return evento;
    }
}
