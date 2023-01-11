using UnityEngine;

public class PowerUpInfo
{
    private enum ESTADO { INICIO, PREFINALIZAR, FINALIZAR, EXPIRADO}

    private ESTADO estadoAtual;

    public bool isEstadoInicio       { get { return estadoAtual == ESTADO.INICIO; } }
    public bool isEstadoPreFinalizar { get { return estadoAtual == ESTADO.PREFINALIZAR; } }
    public bool isEstadoFinalizar    { get { return estadoAtual == ESTADO.FINALIZAR; } }
    public bool isEstadoExpirado     { get { return estadoAtual == ESTADO.EXPIRADO; } }

    public bool isPupEntidadeClicavel     { get { return pupEntidade.isClicavel; } }

    public bool isPupEntidadeColetavel { get { return pupEntidade.isColetavel; } }
    public bool isPupEntidadeNotColetavel { get { return !isPupEntidadeColetavel; } }
    public bool hasColetavel { get { return coletavel != null; } }

    public int indiceBtn { get; private set; }
    public int duracaoTempoPupEntidade { get { return pupEntidade.duracao; }}

    public PowerUpEnums.TIPO tipoPupEntidade { get { return pupEntidade.tipo; } }
    private PowerUpEntidade pupEntidade;
    public  Coletavel coletavel { get; private set; }
    
    public InteracaoPowerUpComComponente interacaoPupComComponentes { get; private set; }    
    public PowerUpAcaoExpirado pupEntidadeAcaoExpirado { get { return pupEntidade.getPowerUpGo(); } }

    private PowerUpInfo(ESTADO estado)
    {
        estadoAtual = estado;
    }

    private void configurarPupEntidade(PowerUpEntidade pupEntidade)
    {
        this.pupEntidade = pupEntidade;

        AbstractPowerUpGo powerUpGo = pupEntidade.getPowerUpGo();
        interacaoPupComComponentes = powerUpGo.getInteracaoComComponente();        
    }

    public PowerUpInfo configurarPupEntidade(PowerUpEntidade pupEntidade, Vector3 posInicial)
    {
        configurarPupEntidade(pupEntidade);

        AbstractPowerUpGo interacaoComPowerUp = pupEntidade.getPowerUpGo();
        interacaoComPowerUp.iniciarNaPosicao(posInicial);
        return this;
    }    

    public PowerUpInfo addColetavel(Coletavel coletavel)
    {
        this.coletavel = coletavel;        
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

    public static PowerUpInfo ofPreFinalizar(Coletavel coletavel)
    {
        PowerUpInfo pupInfo = new PowerUpInfo(ESTADO.PREFINALIZAR);
        pupInfo.coletavel = coletavel;
        return pupInfo;
    }

    public static PowerUpInfo ofExpirado()
    {
        PowerUpInfo pupInfo = new PowerUpInfo(ESTADO.EXPIRADO);
        return pupInfo;
    }

    public static PowerUpInfo ofFinalizar(int indiceBtn)
    {
        PowerUpInfo pupInfo = new PowerUpInfo(ESTADO.FINALIZAR);
        pupInfo.indiceBtn = indiceBtn;
        return pupInfo;
    }
}
