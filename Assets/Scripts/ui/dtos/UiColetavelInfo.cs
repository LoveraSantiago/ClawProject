using UnityEngine;

public class UiColetavelInfo 
{
    private static readonly int ESTADO_COLETADO     = 0;
    private static readonly int ESTADO_NAO_COLETADO = 1;
    private static readonly int ESTADO_LOCKADO      = 2;

    private int estado;
    public bool isColetado    { get { return estado == ESTADO_COLETADO; } }
    public bool isNaoColetado { get { return estado == ESTADO_NAO_COLETADO; } }
    public bool isLockado     { get { return estado == ESTADO_LOCKADO; } }
    public Sprite sprite { get; private set; }
    public ColetavelEntidade coletavelEntidade { get; private set; }

    protected UiColetavelInfo(int estado, Sprite sprite, ColetavelEntidade coletavelEntidade)
    {
        this.estado = estado;
        this.sprite = sprite;
        this.coletavelEntidade = coletavelEntidade;
    }

    public static UiColetavelInfo ofColetado(Sprite sprite, ColetavelEntidade coletavelEntidade)
    {
        return new UiColetavelInfo(ESTADO_COLETADO, sprite, coletavelEntidade);        
    }

    public static UiColetavelInfo ofNaoColetado(Sprite sprite, ColetavelEntidade coletavelEntidade)
    {
        return new UiColetavelInfo(ESTADO_NAO_COLETADO, sprite, coletavelEntidade);
    }

    public static UiColetavelInfo ofLockado(Sprite sprite, ColetavelEntidade coletavelEntidade)
    {
        return new UiColetavelInfo(ESTADO_LOCKADO, sprite, coletavelEntidade);
    }
}
