using UnityEngine;

public class PowerUpInfo
{
    private enum ESTADO { INICIO, PREFINALIZAR, FINALIZAR}

    private ESTADO estadoAtual;

    public bool isInicio       { get { return estadoAtual == ESTADO.INICIO; } }
    public bool isPreFinalizar { get { return estadoAtual == ESTADO.PREFINALIZAR; } }
    public bool isFinalizar    { get { return estadoAtual == ESTADO.FINALIZAR; } }

    public bool isColetavel { get { return pupEntidade.isColetavel; } }
    public bool isNotColetavel { get { return !isColetavel; } }
    public bool hasColetavel { get { return coletavelTile != null; } }

    public int duracaoTempo { get { return pupEntidade.duracao; }}

    public PowerUpEnums.TIPO tipo { get { return pupEntidade.tipo; } }
    private PowerUpEntidade pupEntidade;
    public  ColetavelTile coletavelTile { get; private set; }

    public PowerUpInteracaoComGarra interacaoComGarra { get; private set; }
    public PowerUpInteracaoDisplayColetado interacaoDisplayColetado { get; private set; }

    private PowerUpInfo(ESTADO estado)
    {
        estadoAtual = estado;
    }

    private void configurarPupEntidade(PowerUpEntidade pupEntidade)
    {
        this.pupEntidade = pupEntidade;

        AbstractPowerUpGo interacaoComPowerUp = pupEntidade.getPowerUpGo();
        interacaoComGarra = interacaoComPowerUp.getObjInteracaoComGarra();
        interacaoDisplayColetado = interacaoComPowerUp.getObjInteracaoDisplayColetado();        
    }

    public PowerUpInfo configurarPupEntidade(PowerUpEntidade pupEntidade, Vector3 posInicial)
    {
        configurarPupEntidade(pupEntidade);

        AbstractPowerUpGo interacaoComPowerUp = pupEntidade.getPowerUpGo();
        interacaoComPowerUp.iniciarNaPosicao(posInicial);
        return this;
    }    

    public PowerUpInfo addColetavel(ColetavelTile coletavelTile)
    {
        this.coletavelTile = coletavelTile;        
        return this;
    }
    
    public static PowerUpInfo ofInicio(PowerUpEntidade pupEntidade)
    {
        PowerUpInfo pupInfo = new PowerUpInfo(ESTADO.INICIO);
        pupInfo.configurarPupEntidade(pupEntidade);
        return pupInfo;
    }

    public static PowerUpInfo ofInicio(PowerUpEntidade pupEntidade, Vector3 posInicial)
    {
        PowerUpInfo pupInfo = new PowerUpInfo(ESTADO.INICIO);
        pupInfo.configurarPupEntidade(pupEntidade, posInicial);
        return pupInfo;
    }

    public static PowerUpInfo ofPreFinalizar()
    {
        PowerUpInfo pupInfo = new PowerUpInfo(ESTADO.PREFINALIZAR);
        return pupInfo;
    }

    public static PowerUpInfo ofPreFinalizar(ColetavelTile coletavelTile)
    {
        PowerUpInfo pupInfo = new PowerUpInfo(ESTADO.PREFINALIZAR);
        pupInfo.coletavelTile = coletavelTile;
        return pupInfo;
    }

    public static PowerUpInfo ofFinalizar()
    {
        PowerUpInfo pupInfo = new PowerUpInfo(ESTADO.FINALIZAR);        
        return pupInfo;
    }
}
