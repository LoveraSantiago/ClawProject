using UnityEngine;
using System.Collections.Generic;

public class DistribuidorParaBotoesPowerUp 
{   
    private int indiceDistribuicao;

    private BotaoPowerUp[] btnsPowerUp;
    private PowerUp.TIPO[] arrayDaFase;

    private Dictionary<string, Sprite> dicionarioDeSprites;

    public DistribuidorParaBotoesPowerUp(BotaoPowerUp[] btnsPowerUp, Sprite[] arrayDeSpritesBotoes)
    {
        this.btnsPowerUp = btnsPowerUp;
        montarDicionarioDeSprites(arrayDeSpritesBotoes);
    }

    public void distribuirArray(PowerUp.TIPO[] arrayDePowerUpsParaBotoes)
    {
        arrayDaFase = arrayDePowerUpsParaBotoes;
        determinarIndicePrimeiraDistribuicao();
        for(int contador = 0; contador < indiceDistribuicao; contador++)
        {
            PowerUp.TIPO tipoPU = arrayDaFase[contador];
            if(tipoPU != PowerUp.TIPO.NONE)
            {
                PowerUpParaMaquina powerUpPMaquina = new PowerUpParaMaquina(tipoPU, dicionarioDeSprites);
                btnsPowerUp[contador].receberAcaoPowerUp(powerUpPMaquina);
            }
        }
    }

    public void distribuirProxItem()
    {
        if (indiceDistribuicao < arrayDaFase.Length)
        {
            PowerUp.TIPO tipoPU = arrayDaFase[indiceDistribuicao];
            if (tipoPU != PowerUp.TIPO.NONE)
            {
                PowerUpParaMaquina powerUpPMaquina = new PowerUpParaMaquina(tipoPU, dicionarioDeSprites);
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
