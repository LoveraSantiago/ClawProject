using System.Collections.Generic;
using UnityEngine;

public class DistribuidorParaBotoesPowerUp 
{   
    private int indiceDistribuicao;
    
    private PowerUpEntidade.NAME[] arrayDaFase;
    private Dictionary<string, Sprite> dicionarioDeSprites;

    public DistribuidorParaBotoesPowerUp(Sprite[] arrayDeSpritesBotoes)
    {        
        montarDicionarioDeSprites(arrayDeSpritesBotoes);
    }

    public void distribuirArray(PowerUpEntidade.NAME[] arrayDePowerUpsParaBotoes, BotaoPowerUp[] btnsPowerUp)
    {
        arrayDaFase = arrayDePowerUpsParaBotoes;
        determinarIndicePrimeiraDistribuicao();
        for(int contador = 0; contador < indiceDistribuicao; contador++)
        {
            PowerUpEntidade.NAME namePU = arrayDaFase[contador];
            if(namePU != PowerUpEntidade.NAME.NONE)
            {
                PowerUpParaMaquina powerUpPMaquina = new PowerUpParaMaquina(namePU, dicionarioDeSprites);
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
                PowerUpParaMaquina powerUpPMaquina = new PowerUpParaMaquina(namePU, dicionarioDeSprites);
                BotaoPowerUp btnDisponivel = getPrimeiroBotaoDisponivel(btnsPowerUp);
                btnDisponivel.receberAcaoPowerUp(powerUpPMaquina);
            }

            indiceDistribuicao++;            
        }
    }

    private void montarDicionarioDeSprites(Sprite[] arrayDeSpritesBotoes)
    {
        dicionarioDeSprites = new Dictionary<string, Sprite>();
        for(int contador = 0; contador < arrayDeSpritesBotoes.Length; contador++)
        {
            Sprite spriteIt = arrayDeSpritesBotoes[contador];
            dicionarioDeSprites.Add(spriteIt.name, spriteIt);
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
