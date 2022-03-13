using System.Collections;
using UnityEngine;

public class AsaMiniPowerUpGo : AbstractAsaPowerUpGo
{
    public AsaMiniPowerUpGo() 
        : base(powerUpDto.AsaMiniDto.AsaMiniGo, "MiniAsas"){}

    protected override float getGravidadeNegativa()
    {
        return powerUpDto.AsaMiniDto.GravidadeNeg;
    }

    protected override float getOffset()
    {
        return powerUpDto.AsaMiniDto.Offset;
    }

    protected override float getHalturaLimite()
    {
        HelperColetaveisInGame coletaveisInGame = new HelperColetaveisInGame();
        Coletavel coletavelMaisAlto = coletaveisInGame.getColetavelMaisAlto();

        HelperGaiolasInGame gaiolasInGame = new HelperGaiolasInGame();
        Gaiola gaiolaMaisAlta = gaiolasInGame.getGaiolaMaisAlta();

        float altura = 0;
        if(gaiolaMaisAlta == null)
        {
            altura = coletavelMaisAlto.getPosicao().y;
        }
        else
        {
            Debug.Log("Altura coletavel " + coletavelMaisAlto.getPosicao().y);
            Debug.Log("Altura gaiola " + gaiolaMaisAlta.getPosicao().y);

            altura = Mathf.Max(coletavelMaisAlto.getPosicao().y, gaiolaMaisAlta.getPosicao().y);
        }
        return altura + powerUpDto.AsaMiniDto.IncrementoHaltura;
    }

    protected override IEnumerator finalizarVoar(Coletavel coletavelAcertado)
    {
        coletavelAcertado.colocarNaPosicao(getPosicao());
        coletavelAcertado.restaurar();
        desligar();

        powerUpFinalizacao.preFinalizar();
        yield return new WaitForSeconds(powerUpDto.AsaDto.DelayFinalizar);

        powerUpFinalizacao.finalizado();
        yield return null;
    }    
}
