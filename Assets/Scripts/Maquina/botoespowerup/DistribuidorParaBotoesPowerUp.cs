public class DistribuidorParaBotoesPowerUp 
{   
    private int indiceDistribuicao;
    
    private PowerUpEntidade.TIPO[] arrayDaFase;        

    public void distribuirArray(PowerUpEntidade.TIPO[] arrayDePowerUpsParaBotoes, BotaoPowerUp[] btnsPowerUp)
    {
        arrayDaFase = arrayDePowerUpsParaBotoes;
        determinarIndicePrimeiraDistribuicao();
        for(int contador = 0; contador < indiceDistribuicao; contador++)
        {
            PowerUpEntidade.TIPO tipoPU = arrayDaFase[contador];
            if(tipoPU != PowerUpEntidade.TIPO.NONE)
            {
                PowerUpParaMaquina powerUpPMaquina = new PowerUpParaMaquina(tipoPU);
                btnsPowerUp[contador].receberAcaoPowerUp(powerUpPMaquina);
            }
        }
    }

    public void distribuirProxItem(BotaoPowerUp[] btnsPowerUp)
    {
        if (indiceDistribuicao < arrayDaFase.Length)
        {
            PowerUpEntidade.TIPO tipoPU = arrayDaFase[indiceDistribuicao];
            if (tipoPU != PowerUpEntidade.TIPO.NONE)
            {
                PowerUpParaMaquina powerUpPMaquina = new PowerUpParaMaquina(tipoPU);
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
