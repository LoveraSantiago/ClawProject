using UnityEngine;

public class PowerUpInfoDto
{
    private PowerUpEnums.ESTADO estadoAtual;

    public bool isEstadoInicio       { get { return estadoAtual == PowerUpEnums.ESTADO.INICIO; } }
    public bool isEstadoPreFinalizar { get { return estadoAtual == PowerUpEnums.ESTADO.PREFINALIZAR; } }

    public bool isEstadoEmAndamento { get { return estadoAtual == PowerUpEnums.ESTADO.ALVO1_SELECIONADO; } }
    public bool isEstadoFinalizar    { get { return estadoAtual == PowerUpEnums.ESTADO.FINALIZAR; } }
    public bool isEstadoExpirado     { get { return estadoAtual == PowerUpEnums.ESTADO.EXPIRADO; } }

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

    private PowerUpInfoDto(PowerUpEnums.ESTADO estado)
    {
        estadoAtual = estado;
    }

    private void configurarPupEntidade(PowerUpEntidade pupEntidade)
    {
        this.pupEntidade = pupEntidade;

        AbstractPowerUpGo powerUpGo = pupEntidade.getPowerUpGo();
        interacaoPupComComponentes = powerUpGo.getInteracaoComComponente();        
    }

    public PowerUpInfoDto configurarPupEntidade(PowerUpEntidade pupEntidade, Vector3 posInicial)
    {
        configurarPupEntidade(pupEntidade);

        AbstractPowerUpGo interacaoComPowerUp = pupEntidade.getPowerUpGo();
        interacaoComPowerUp.iniciarNaPosicao(posInicial);
        return this;
    }    

    public PowerUpInfoDto addColetavel(Coletavel coletavel)
    {
        this.coletavel = coletavel;        
        return this;
    }
    
    public static PowerUpInfoDto ofInicio(PowerUpEntidade pupEntidade)
    {
        PowerUpInfoDto pupInfo = new PowerUpInfoDto(PowerUpEnums.ESTADO.INICIO);
        pupInfo.configurarPupEntidade(pupEntidade);
        return pupInfo;
    }

    public static PowerUpInfoDto ofInicio(PowerUpEntidade pupEntidade, Vector3 posInicial)
    {
        PowerUpInfoDto pupInfo = new PowerUpInfoDto(PowerUpEnums.ESTADO.INICIO);
        pupInfo.configurarPupEntidade(pupEntidade, posInicial);
        return pupInfo;
    }

    public static PowerUpInfoDto ofPreFinalizar()
    {
        PowerUpInfoDto pupInfo = new PowerUpInfoDto(PowerUpEnums.ESTADO.PREFINALIZAR);
        return pupInfo;
    }

    public static PowerUpInfoDto ofPreFinalizar(Coletavel coletavel)
    {
        PowerUpInfoDto pupInfo = new PowerUpInfoDto(PowerUpEnums.ESTADO.PREFINALIZAR);
        pupInfo.coletavel = coletavel;
        return pupInfo;
    }

    public static PowerUpInfoDto ofExpirado()
    {
        PowerUpInfoDto pupInfo = new PowerUpInfoDto(PowerUpEnums.ESTADO.EXPIRADO);
        return pupInfo;
    }

    public static PowerUpInfoDto ofFinalizar(int indiceBtn)
    {
        PowerUpInfoDto pupInfo = new PowerUpInfoDto(PowerUpEnums.ESTADO.FINALIZAR);
        pupInfo.indiceBtn = indiceBtn;
        return pupInfo;
    }
}
