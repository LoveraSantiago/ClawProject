using UnityEngine;
using System.Collections.Generic;

public class DistribuidorParaBotoesPowerUp 
{
    private bool continuarDistribuicao;

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
        int limite = determinarIndicePrimeiraDistribuicao(arrayDePowerUpsParaBotoes);
        for(int contador = 0; contador < limite; contador++)
        {
            PowerUp.TIPO tipoPU = arrayDePowerUpsParaBotoes[contador];
            if(tipoPU != PowerUp.TIPO.NONE)
            {
                PowerUpParaMaquina powerUpPMaquina = new PowerUpParaMaquina(tipoPU, dicionarioDeSprites);
                btnsPowerUp[contador].receberAcaoPowerUp(powerUpPMaquina);
            }
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

    private int determinarIndicePrimeiraDistribuicao(PowerUp.TIPO[] arrayDePowerUpsParaBotoes)
    {
        int limite = 0;
        if (arrayDePowerUpsParaBotoes.Length <= 4)
        {
            continuarDistribuicao = false;
            limite = arrayDePowerUpsParaBotoes.Length;
        }
        else
        {
            limite = 4;
        }
        return limite;
    }
}
