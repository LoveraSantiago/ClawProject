using UnityEngine;

public abstract class AbstractPowerUpGo : Coletavel
{    
    protected static PowerUpDto powerUpDto;
    protected static MonoBehaviour monoBehaviour;

    protected static InputGame inputGame;
    protected static PowerUpFinalizacao powerUpFinalizacao;

    private bool configurado;    
    
    public abstract GarraInteracaoComPowerUp getObjetoDeInteracaoComGarra();
    public abstract void configurarPup();
    public abstract void iniciarPup();
    public abstract void resetPup();
    
    public virtual void iniciarNaPosicao(Vector3 posicao) { }
    public virtual void timeout() { }

    public AbstractPowerUpGo(GameObject goTile, string nome)
        : base(goTile, nome)
    {
    }

    public AbstractPowerUpGo(GameObject goTile, 
                             Transformador<GameObject, GameObject> getGoComSprRenderer, 
                             string nome)
        : base(goTile, getGoComSprRenderer, nome)
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
