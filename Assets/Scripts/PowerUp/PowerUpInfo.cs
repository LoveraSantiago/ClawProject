using UnityEngine;

public class PowerUpInfo
{
    public enum ESTADO { INICIO, PREFINALIZAR, FINALIZAR}

    public ESTADO estadoAtual;

    public bool isInicio { get { return estadoAtual == ESTADO.INICIO; } }
    public bool isPreFinalizar { get { return estadoAtual == ESTADO.PREFINALIZAR; } }
    public bool isFinalizar { get { return estadoAtual == ESTADO.FINALIZAR; } }
    public bool hasColetavel { get { return coletavelTile != null; } }

    public int duracaoTempo { get { return pupEntidade.duracao; }}

    public PowerUpEntidade pupEntidade { get; private set; }
    public ColetavelTile coletavelTile { get; private set; }

    public PowerUpInteracaoComGarra interacaoComGarra { get; private set; }
    public PowerUpInteracaoDisplayColetado interacaoDisplayColetado { get; private set; }

    public PowerUpInfo(ESTADO estado)
    {
        estadoAtual = estado;
    }

    public PowerUpInfo configurarPupEntidade(PowerUpEntidade pupEntidade)
    {
        this.pupEntidade = pupEntidade;

        AbstractPowerUpGo interacaoComPowerUp = pupEntidade.getPowerUpGo();
        interacaoComGarra = interacaoComPowerUp.getObjInteracaoComGarra();
        interacaoDisplayColetado = interacaoComPowerUp.getObjInteracaoDisplayColetado();
        return this;
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
}
