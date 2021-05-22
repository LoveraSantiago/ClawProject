using UnityEngine;

public abstract class AbstractPowerUpGo : Coletavel,
                                          GarraInteracaoComPowerUp
{
    protected static MonoBehaviour monoBehaviour;
    protected static PowerUpFinalizacao powerUpFinalizacao;

    public abstract bool garraPodeSegurar();
    public virtual float getAnguloGarraSegurar() { return 15; }//Angulo de fechamento atual configurado no edior
    public virtual void iniciarNaPosicao(Vector3 posicao) { }

    public AbstractPowerUpGo(GameObject goTile, string nome)
        : base(goTile, nome)
    {
    }

    public static void configurar(PowerUpFinalizacao powerUpFinalizacaoArg, MonoBehaviour monoBehaviourArg)
    {
        monoBehaviour = monoBehaviourArg;
        powerUpFinalizacao = powerUpFinalizacaoArg;
    }
}
