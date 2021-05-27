using UnityEngine;

public abstract class AbstractPowerUpGo : Coletavel,
                                          GarraInteracaoComPowerUp
{
    protected static MonoBehaviour monoBehaviour;
    protected static PowerUpFinalizacao powerUpFinalizacao;
    protected static InputGame inputGame;

    public abstract PowerUpEntidade.INTERACAOGARRA getInteracaoComGarra();
    public virtual float getAnguloGarraSegurar() { return 15; }//Angulo de fechamento atual configurado no edior
    public virtual void iniciarNaPosicao(Vector3 posicao) { }
    public virtual void timeout() { }

    public AbstractPowerUpGo(GameObject goTile, string nome)
        : base(goTile, nome)
    {
    }

    public static void configurar(PowerUpFinalizacao powerUpFinalizacaoArg, MonoBehaviour monoBehaviourArg, InputGame inputGameArg)
    {
        monoBehaviour = monoBehaviourArg;
        powerUpFinalizacao = powerUpFinalizacaoArg;
        inputGame = inputGameArg;
    }
}
