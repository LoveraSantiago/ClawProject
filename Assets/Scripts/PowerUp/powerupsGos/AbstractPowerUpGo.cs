using UnityEngine;

public abstract class AbstractPowerUpGo : Coletavel,
                                          GarraInteracaoComPowerUp
{
    protected static PowerUpDto powerUpDto;
    protected static MonoBehaviour monoBehaviour;

    protected static InputGame inputGame;
    protected static PowerUpFinalizacao powerUpFinalizacao;

    private bool configurado;

    public abstract PowerUpEntidade.INTERACAOGARRA getInteracaoComGarra();
    public abstract void configurarPup();
    public abstract void iniciarPup();
    public abstract void resetPup();

    public virtual float getAnguloParaGarraSegurar() { return 15; }//Angulo de fechamento atual configurado no edior
    public virtual void iniciarNaPosicao(Vector3 posicao) { }
    public virtual void timeout() { }

    public AbstractPowerUpGo(GameObject goTile, string nome)
        : base(goTile, nome)
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

    public static void configurarAbstractPowerUp(PowerUpDto powerUpDtoArg, PowerUpFinalizacao powerUpFinalizacaoArg, 
        InputGame inputGameArg, MonoBehaviour monoBehaviourArg)
    {
        powerUpDto = powerUpDtoArg;
        monoBehaviour = monoBehaviourArg;
        powerUpFinalizacao = powerUpFinalizacaoArg;
        inputGame = inputGameArg;
    }
}
