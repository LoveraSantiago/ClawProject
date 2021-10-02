using UnityEngine;
using System.Collections;

public class TeleportePowerUpGo : AbstractTrocaPowerUpGo
{  
    public TeleportePowerUpGo() : base(powerUpDto.VazioPUp, "teleporte"){}    
   
    public override void resetPup(){}

    protected override IEnumerator realizarTroca(ColetavelTile coletavel1, ColetavelTile coletavel2)
    {
        Sprite spr1 = coletavel1.getSprite();
        Sprite spr2 = coletavel2.getSprite();

        Material matIn  = new Material(powerUpDto.TeleporteDto.MatTeleporte);
        Material matOut = new Material(powerUpDto.TeleporteDto.MatTeleporte);
        matIn.SetTexture(PROP_SPRITE_IN, spr1.texture);
        matIn.SetTexture(PROP_SPRITE_OUT, spr2.texture);

        matOut.SetTexture(PROP_SPRITE_IN, spr2.texture);
        matOut.SetTexture(PROP_SPRITE_OUT, spr1.texture);

        coletavel1.addMaterial(matIn);
        coletavel2.addMaterial(matOut);

        float contador = 0;
        while(contador < 1.01f)
        {
            contador += Time.deltaTime * powerUpDto.TeleporteDto.Velocidade;
            matOut.SetFloat(PROP_VALOR, contador);
            matIn.SetFloat(PROP_VALOR, contador);
            yield return null;
        }
        powerUpFinalizacao.preFinalizar();
        coletavel1.receberSprite(spr2);
        coletavel2.receberSprite(spr1);

        coletavel1.clearMaterial();
        coletavel2.clearMaterial();

        coletavel1.desligarAnimacao();
        coletavel2.desligarAnimacao();
        yield return null;

        trocadorDeOrdem.trocarOrdem(coletavel1, coletavel2);

        yield return new WaitForSeconds(powerUpDto.TeleporteDto.DelayFinal);
        powerUpFinalizacao.finalizado();
        yield return null;
    }   

    public static Fornecedor<AbstractPowerUpGo> getFornecedor()
    {
        return new FornecedorTeleporte();
    }

    public class FornecedorTeleporte : Fornecedor<AbstractPowerUpGo>
    {
        public AbstractPowerUpGo fornecer()
        {
            return new TeleportePowerUpGo();
        }
    }   
}
