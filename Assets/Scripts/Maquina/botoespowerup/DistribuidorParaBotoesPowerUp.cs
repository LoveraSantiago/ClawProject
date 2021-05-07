using UnityEngine;
using System.Collections.Generic;

public class DistribuidorParaBotoesPowerUp 
{   
    private int indiceDistribuicao;

    private BotaoPowerUp[] btnsPowerUp;
    private PowerUpEntidade.NAME[] arrayDaFase;

    private Dictionary<string, Sprite> dicionarioDeSprites;

    public DistribuidorParaBotoesPowerUp(BotaoPowerUp[] btnsPowerUp, Sprite[] arrayDeSpritesBotoes)
    {
        this.btnsPowerUp = btnsPowerUp;
        montarDicionarioDeSprites(arrayDeSpritesBotoes);
    }

    public void distribuirArray(PowerUpEntidade.NAME[] arrayDePowerUpsParaBotoes)
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

    public void distribuirProxItem()
    {
        if (indiceDistribuicao < arrayDaFase.Length)
        {
            PowerUpEntidade.NAME namePU = arrayDaFase[indiceDistribuicao];
            if (namePU != PowerUpEntidade.NAME.NONE)
            {
                PowerUpParaMaquina powerUpPMaquina = new PowerUpParaMaquina(namePU, dicionarioDeSprites);
                BotaoPowerUp btnDisponivel = getPrimeiroBotaoDisponivel();
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

    private BotaoPowerUp getPrimeiroBotaoDisponivel()
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
