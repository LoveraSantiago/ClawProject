using UnityEngine;

public abstract class AbstractPowerUpGo : Coletavel
{
    private static float acrescimo;
    protected static PowerUpDto powerUpDto;
    protected static MonoBehaviour monoBehaviour;

    protected static InputGame inputGame;
    protected static PowerUpFinalizacao powerUpFinalizacao;

    private bool configurado;    
    
    public abstract GarraInteracaoComPowerUp getObjetoDeInteracaoComGarra();
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

    protected void ligarMirasNosColetaveis()
    {
        ColetavelQuery coletavelQuery = new ColetavelQuery();
        coletavelQuery.executeNoPoolDeColetaveis(new LigadorDeMiras());
    }

    protected void desligarMirasNosColetaveis()
    {
        ColetavelQuery coletavelQuery = new ColetavelQuery();
        coletavelQuery.executeNoPoolDeColetaveis(new DesligadorDeMiras());
    }

    protected Collider2D getColetavelHit()
    {
        Vector3 posicaoTap = inputGame.getPosicaoTap();
        posicaoTap += new Vector3(0, acrescimo, 0);
        posicaoTap.z = 0;
        Debug.Log("Posicao tap " + posicaoTap);
        int layerMask = LayerMask.GetMask("Coletavel");
        RaycastHit2D raycastHit;
        raycastHit = Physics2D.Raycast(posicaoTap, Vector3.up, 2, layerMask);
        return raycastHit.collider;
    }      

    public static void addAcrescimo(float acrescimoArg)
    {
        acrescimo += acrescimoArg;
    }
}
