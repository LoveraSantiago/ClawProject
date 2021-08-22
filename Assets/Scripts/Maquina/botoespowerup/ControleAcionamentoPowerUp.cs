public class ControleAcionamentoPowerUp 
{
    private readonly int ESTADO_DESLIGADO = 0;
    private readonly int ESTADO_LIGADO    = 1;
    private readonly int ESTADO_SUSPENSO  = 2;

    private int estadoAtual;

    private bool powerUpEmAcao;
    private bool powerUpDisplayEmAcao;

    public ControleAcionamentoPowerUp()
    {
        estadoAtual = ESTADO_LIGADO;
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
        return  isEstadoSuspenso() && acaoBotaoPowerUp.getName() == PowerUpEntidade.NAME.ROLLBACK;        
    }    

    public bool podeAcionarPupDraggavel()
    {
        return isEstadoLigado() && !powerUpEmAcao;
    }

    public void notificarAcionado(AcaoBotaoPowerUp acaoBotaoPowerUp)
    {
        powerUpEmAcao = true;
        if(acaoBotaoPowerUp.getName() == PowerUpEntidade.NAME.ROLLBACK)
        {
            powerUpDisplayEmAcao = true;
        }
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
