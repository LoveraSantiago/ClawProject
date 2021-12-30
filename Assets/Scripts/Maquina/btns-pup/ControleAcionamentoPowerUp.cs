public class ControleAcionamentoPowerUp 
{
    private readonly int ESTADO_DESLIGADO = 0;
    private readonly int ESTADO_LIGADO    = 1;
    private readonly int ESTADO_SUSPENSO  = 2;

    private int estadoAtual;

    private bool powerUpEmAcao;
    private bool powerUpDisplayEmAcao;

    public ProdutorDeEvento<int> produtorDeEventoEscolhaPup { get; private set; }

    public ControleAcionamentoPowerUp()
    {
        estadoAtual = ESTADO_LIGADO;
        produtorDeEventoEscolhaPup = new ProdutorDeEvento<int>();
    }   

    public void habilitarPowerUp()
    {
        if (!powerUpDisplayEmAcao)
        {
            powerUpEmAcao = false;
            estadoAtual = ESTADO_LIGADO;        
        }
    }

    public void habilitarPowerUpPosDisplay()
    {
        powerUpDisplayEmAcao = false;
        habilitarPowerUp();
    }

    public void desabilitarPowerUp()
    {
        estadoAtual = ESTADO_DESLIGADO;        
    }

    public void suspenderPowerUp()
    {
        estadoAtual = ESTADO_SUSPENSO;        
    }

    public bool podeAcionarPupBtn(AcaoBotaoPowerUp acaoBotaoPowerUp)
    {
        if (powerUpEmAcao)       return false;
        if (isEstadoLigado())    return true;
        if (isEstadoDesligado()) return false;
        return isEstadoSuspenso() && isAcaoBotaoPupTiposEspeciais(acaoBotaoPowerUp);        
    }    

    private bool isAcaoBotaoPupTiposEspeciais(AcaoBotaoPowerUp acaoBotaoPowerUp)
    {
        return (acaoBotaoPowerUp != null) &&
            (acaoBotaoPowerUp.getTipo() == PowerUpEnums.TIPO.ROLLBACK ||
             acaoBotaoPowerUp.getTipo() == PowerUpEnums.TIPO.DESCARTE);
    }

    public bool podeAcionarPupDraggavel()
    {
        return isEstadoLigado() && !powerUpEmAcao;
    }

    public void notificarAcionado(AcaoBotaoPowerUp acaoBotaoPowerUp)
    {
        powerUpEmAcao = true;
        if(isAcaoBotaoPupTiposEspeciais(acaoBotaoPowerUp))
        {
            powerUpDisplayEmAcao = true;
        }
    }

    public void escolhendoPupParaIndice(int indice)
    {
        produtorDeEventoEscolhaPup.produziuEvento(indice);
    }

    private bool isEstadoLigado()
    {
        return estadoAtual == ESTADO_LIGADO;
    }

    private bool isEstadoDesligado()
    {
        return estadoAtual == ESTADO_DESLIGADO;
    }

    private bool isEstadoSuspenso()
    {
        return estadoAtual == ESTADO_SUSPENSO;
    }
}
