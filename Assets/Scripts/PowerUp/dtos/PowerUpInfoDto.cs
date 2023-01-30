using UnityEngine;

public class PowerUpInfoDto
{
    public PowerUpEnums.ESTADO estadoAtual { get; private set; }

    public bool isEstadoInicio       { get { return estadoAtual == PowerUpEnums.ESTADO.INICIO; } }
    public bool isEstadoPreFinalizar { get { return estadoAtual == PowerUpEnums.ESTADO.PREFINALIZAR; } }

    public bool isEstadoEmAndamento { get 
        { 
            return estadoAtual == PowerUpEnums.ESTADO.ALVO1_SELECIONADO || 
                   estadoAtual == PowerUpEnums.ESTADO.ALVO2_SELECIONADO ||
                   estadoAtual == PowerUpEnums.ESTADO.ALVO3_SELECIONADO; 
        } }

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

    public PowerUpInfoDto(PowerUpEnums.ESTADO estado)
    {
        estadoAtual = estado;
    }
    
    public PowerUpInfoDto(PowerUpEnums.ESTADO estado, int indiceBtn)
    {
        estadoAtual = estado;
        this.indiceBtn = indiceBtn;
    }
    
    public PowerUpInfoDto(PowerUpEnums.ESTADO estado, Coletavel coletavel)
    {
        estadoAtual = estado;
        this.coletavel = coletavel;
    }

    public PowerUpInfoDto(PowerUpEnums.ESTADO estado, PowerUpEntidade pupEntidade)
    {
        estadoAtual = estado;
        configurarPupEntidade(pupEntidade);
    }
    
    public PowerUpInfoDto(PowerUpEnums.ESTADO estado, PowerUpEntidade pupEntidade, Vector3 posInicial)
    {
        estadoAtual = estado;
        configurarPupEntidade(pupEntidade, posInicial);
    }

    private void configurarPupEntidade(PowerUpEntidade pupEntidade)
    {
        this.pupEntidade = pupEntidade;

        AbstractPowerUpGo powerUpGo = pupEntidade.getPowerUpGo();
        interacaoPupComComponentes = powerUpGo.getInteracaoComComponente();        
    }

    private PowerUpInfoDto configurarPupEntidade(PowerUpEntidade pupEntidade, Vector3 posInicial)
    {
        configurarPupEntidade(pupEntidade);

        AbstractPowerUpGo interacaoComPowerUp = pupEntidade.getPowerUpGo();
        interacaoComPowerUp.iniciarNaPosicao(posInicial);
        return this;
    }    

    private PowerUpInfoDto addColetavel(Coletavel coletavel)
    {
        this.coletavel = coletavel;        
        return this;
    }
}
