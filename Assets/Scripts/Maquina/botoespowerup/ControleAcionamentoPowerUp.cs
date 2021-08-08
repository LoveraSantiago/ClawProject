public class ControleAcionamentoPowerUp 
{
    private readonly int ESTADO_DESLIGADO = 0;
    private readonly int ESTADO_LIGADO    = 1;
    private readonly int ESTADO_SUSPENSO  = 2;

    private int estadoAtual;
    private bool powerUpEmAcao;

    public ControleAcionamentoPowerUp()
    {
        estadoAtual = ESTADO_LIGADO;
    }

    public void powerUpAcionado()
    {
        powerUpEmAcao = true;
    }

    public void powerUpFinalizado()
    {
        powerUpEmAcao = false;
    }    

    public void desabilitarPowerUp()
    {
        estadoAtual = ESTADO_DESLIGADO;        
    }

    public void habilitarPowerUp()
    {
        estadoAtual = ESTADO_LIGADO;        
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
