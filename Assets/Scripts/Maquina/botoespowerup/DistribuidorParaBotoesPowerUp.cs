public class DistribuidorParaBotoesPowerUp 
{   
    private int indiceDistribuicao;
    
    private PowerUpEntidade.NAME[] arrayDaFase;        

    public void distribuirArray(PowerUpEntidade.NAME[] arrayDePowerUpsParaBotoes, BotaoPowerUp[] btnsPowerUp)
    {
        arrayDaFase = arrayDePowerUpsParaBotoes;
        determinarIndicePrimeiraDistribuicao();
        for(int contador = 0; contador < indiceDistribuicao; contador++)
        {
            PowerUpEntidade.NAME namePU = arrayDaFase[contador];
            if(namePU != PowerUpEntidade.NAME.NONE)
            {
                PowerUpParaMaquina powerUpPMaquina = new PowerUpParaMaquina(namePU);
                btnsPowerUp[contador].receberAcaoPowerUp(powerUpPMaquina);
            }
        }
    }

    public void distribuirProxItem(BotaoPowerUp[] btnsPowerUp)
    {
        if (indiceDistribuicao < arrayDaFase.Length)
        {
            PowerUpEntidade.NAME namePU = arrayDaFase[indiceDistribuicao];
            if (namePU != PowerUpEntidade.NAME.NONE)
            {
                PowerUpParaMaquina powerUpPMaquina = new PowerUpParaMaquina(namePU);
                BotaoPowerUp btnDisponivel = getPrimeiroBotaoDisponivel(btnsPowerUp);
                btnDisponivel.receberAcaoPowerUp(powerUpPMaquina);
            }

            indiceDistribuicao++;            
        }
    }    

    private void determinarIndicePrimeiraDistribuicao()
    {
        indiceDistribuicao = 0;
        if (arrayDaFase.Length <= 4)
        {
            indiceDistribuicao = arrayDaFase.Length;
        }
        else
        {
            indiceDistribuicao = 4;
        }        
    }

    private BotaoPowerUp getPrimeiroBotaoDisponivel(BotaoPowerUp[] btnsPowerUp)
    {
        for(int contador = 0; contador < btnsPowerUp.Length; contador++)
        {
            if (!btnsPowerUp[contador].hasPowerUp)
            {
                return btnsPowerUp[contador];
            }
        }        
        return null;
    }
}
