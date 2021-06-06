using UnityEngine;

public abstract class AbstractPowerUpGo : Coletavel,
                                          GarraInteracaoComPowerUp
{
    private bool configurado;

    protected static MonoBehaviour monoBehaviour;
    protected static PowerUpFinalizacao powerUpFinalizacao;
    protected static InputGame inputGame;

    public abstract PowerUpEntidade.INTERACAOGARRA getInteracaoComGarra();
    public abstract void configurarPup();
    public abstract void iniciarPup();
    public abstract void resetPup();

    public virtual float getAnguloGarraSegurar() { return 15; }//Angulo de fechamento atual configurado no edior
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


    public static void configurarAbstractPowerUp(PowerUpFinalizacao powerUpFinalizacaoArg, MonoBehaviour monoBehaviourArg, InputGame inputGameArg)
    {
        monoBehaviour = monoBehaviourArg;
        powerUpFinalizacao = powerUpFinalizacaoArg;
        inputGame = inputGameArg;
    }
}
