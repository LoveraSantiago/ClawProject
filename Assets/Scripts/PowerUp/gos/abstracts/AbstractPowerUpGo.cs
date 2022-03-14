using UnityEngine;

public abstract class AbstractPowerUpGo : GO,
                                          PowerUpAcaoExpirado
{    
    protected static PowerUpDto powerUpDto;
    private static GOContexto contexto;

    protected static InputGame inputGame;
    protected static PowerUpAcaoFinalizacao powerUpFinalizacao;
    protected static InformacaoDisplayColetado informacaoDisplayColetado;

    private bool configurado;    
    
    public abstract void configurarPup();
    public abstract void iniciarPup();
    public abstract void resetPup();
    
    public virtual void iniciarNaPosicao(Vector3 posicao) { }
    public virtual void timeout() { }

    public abstract InteracaoPowerUpComComponente getInteracaoComComponente();

    public AbstractPowerUpGo(GameObject go, string nome)
        : base(new GOContexto(go, contexto), nome)
    {
    }

    public AbstractPowerUpGo(GameObject go, 
                             Transformador<GameObject, SpriteRenderer> getGoComSprRenderer, 
                             string nome)
        : base(new GOContexto(go, contexto), getGoComSprRenderer, nome)
    {
    }

    public void iniciar()
    {
        if (!configurado)
        {
            configurado = true;
            configurarPup();
        }
        iniciarPup();
    }

    public void expirar()
    {
        powerUpFinalizacao.expirado();
        timeout();
    }
    
    protected override GOContexto getGOContext()
    {
        return contexto;
    }

    public static void configurarAbstractPowerUp(PowerUpDto powerUpDtoArg, PowerUpAcaoFinalizacao powerUpFinalizacaoArg, 
        InputGame inputGameArg)
    {
        powerUpDto = powerUpDtoArg;        
        powerUpFinalizacao = powerUpFinalizacaoArg;
        inputGame = inputGameArg;

        contexto = new GOContexto(powerUpDto.ContextoPup);
    }

    //TODO unificar configuracao
    public static void configurar(InformacaoDisplayColetado informacaoDisplayColetadoArg)
    {
        informacaoDisplayColetado = informacaoDisplayColetadoArg;
    }
}
