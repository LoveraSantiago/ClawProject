using UnityEngine;

public class PowerUpManager : PowerUpAcionamento,
                              PowerUpFinalizacao,
                              AcaoPowerUp.ProdutorEvento
{
    private ProdutorDeEvento<PowerUpInfo> produtorDeEventoPowerUp;    

    public PowerUpManager(PowerUpDto powerUpDto, MonoBehaviour monoBehaviour, InputGame inputGame)
    {   
        PowerUpParaMaquina.configAcionadorDePowerUp(this);
        produtorDeEventoPowerUp = new ProdutorDeEvento<PowerUpInfo>();        

        AbstractPowerUpGo.configurarAbstractPowerUp(powerUpDto, this, inputGame, monoBehaviour);        
    }    

    public void acionado(PowerUpEntidade powerUp)
    {
        AbstractPowerUpGo interacaoComPowerUp = powerUp.getPowerUpGo();

        PowerUpInfo powerUpInfo = new PowerUpInfo(PowerUpInfo.ESTADO.INICIO)
            .configurarDuracaoTempo(powerUp.duracao)
            .configurarObjetoInteracaoComGarra(interacaoComPowerUp.getInteracaoComGarra());

        produtorDeEventoPowerUp.produziuEvento(powerUpInfo);
    }

    public void acionado(PowerUpEntidade powerUp, Vector3 posicaoAtual)
    {
        AbstractPowerUpGo interacaoComPowerUp = powerUp.getPowerUpGo();
        interacaoComPowerUp.iniciarNaPosicao(posicaoAtual);

        PowerUpInfo powerUpInfo = new PowerUpInfo(PowerUpInfo.ESTADO.INICIO)
            .configurarDuracaoTempo(powerUp.duracao)
            .configurarObjetoInteracaoComGarra(interacaoComPowerUp.getInteracaoComGarra());

        produtorDeEventoPowerUp.produziuEvento(powerUpInfo);
    }   

    public void preFinalizar()
    {
        PowerUpInfo powerUpInfo = new PowerUpInfo(PowerUpInfo.ESTADO.PREFINALIZAR);
        produtorDeEventoPowerUp.produziuEvento(powerUpInfo);
    }

    public void preFinalizar(ColetavelTile coletavelTile)
    {
        PowerUpInfo powerUpInfo = new PowerUpInfo(PowerUpInfo.ESTADO.PREFINALIZAR)
            .addColetavel(coletavelTile);
        produtorDeEventoPowerUp.produziuEvento(powerUpInfo);
    }

    public void finalizado()
    {
        PowerUpInfo powerUpInfo = new PowerUpInfo(PowerUpInfo.ESTADO.FINALIZAR);
        produtorDeEventoPowerUp.produziuEvento(powerUpInfo);
    }    

    ProdutorDeEvento<PowerUpInfo> AcaoPowerUp.ProdutorEvento.getProdutorDeEventoColetado()
    {
        return produtorDeEventoPowerUp;
    }    
}
