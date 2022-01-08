using UnityEngine;

public class CacaNiquelEventoDto    
{
    private static readonly int ESTADO_INICIO    = 0;
    private static readonly int ESTADO_ANDAMENTO = 1;
    private static readonly int ESTADO_FIM       = 2;

    private bool isSingle;
    private int estadoAtual;

    public bool isInicio { get { return estadoAtual == ESTADO_INICIO; } }
    public bool isEmAndamento { get { return estadoAtual == ESTADO_ANDAMENTO; } }
    public bool isFinalizado { get { return estadoAtual == ESTADO_FIM; } }

    public Sprite[] sprResultados { get; private set; }
    private CacaNiquelResultadoEnum[] resultados;
    private CacaNiquelResultadoEnum resultado;

    public CacaNiquelEventoDto()
    {
        estadoAtual = ESTADO_INICIO;
    }

    private CacaNiquelEventoDto(bool isSingle, Sprite[] sprResultados, CacaNiquelResultadoEnum[] resultados)
    {
        estadoAtual   = ESTADO_FIM;
        this.isSingle      = isSingle;
        this.sprResultados = sprResultados;
        this.resultados    = resultados;
    }

    private CacaNiquelEventoDto(CacaNiquelResultadoEnum resultado)
    {
        estadoAtual = ESTADO_ANDAMENTO;
        this.resultado = resultado;
    }

    public bool isResultSucesso()
    {
        return resultado == CacaNiquelResultadoEnum.SUCESSO;
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

    public static CacaNiquelEventoDto ofEmAndamento(CacaNiquelResultadoEnum resultado)
    {
        CacaNiquelEventoDto evento = new CacaNiquelEventoDto(resultado);
        return evento;
    }

    public static CacaNiquelEventoDto ofGeral(Sprite[] sprResultados, CacaNiquelResultadoEnum[] resultados)
    {
        CacaNiquelEventoDto evento = new CacaNiquelEventoDto(false, sprResultados, resultados);
        return evento;
    }    
}
