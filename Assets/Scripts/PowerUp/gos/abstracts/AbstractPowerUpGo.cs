using UnityEngine;

public abstract class AbstractPowerUpGo : GO,
                                          PowerUpAcaoExpirado
{    
    protected static PowerUpGameDto powerUpDto;
    private static GOContexto contexto;

    protected static InputGame inputGame;
    protected static SomPowerUp somPowerUp;
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
        : base(new GOContexto(go), nome)
    {
    }

    public AbstractPowerUpGo(
        GameObject go, FinderDeSprRenderer finderDeSprRenderer, string nome)
        : base(new GOContexto(go), finderDeSprRenderer, nome)
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

    protected float getDelayInicioMaterialize()
    {
        return powerUpDto.EfeitoMaterializeDto.DelayDuracao;
    }
    
    protected override GOContexto getGOContext()
    {
        return contexto;
    }

    public static void configurarAbstractPowerUp(
        PowerUpGameDto powerUpDtoArg, PowerUpAcaoFinalizacao powerUpFinalizacaoArg, InputGame inputGameArg, SomPowerUp somPowerUpArg)
    {
        powerUpDto         = powerUpDtoArg;        
        powerUpFinalizacao = powerUpFinalizacaoArg;
        inputGame          = inputGameArg;
        contexto           = new GOContexto(powerUpDto.GoMainPup);
        somPowerUp         = somPowerUpArg;
    }
    
    public static void configuradoPeloLevel(InformacaoDisplayColetado informacaoDisplayColetadoArg)
    {
        informacaoDisplayColetado = informacaoDisplayColetadoArg;
    }
}
