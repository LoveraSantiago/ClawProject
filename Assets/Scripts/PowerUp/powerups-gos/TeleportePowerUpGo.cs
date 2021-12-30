using UnityEngine;
using System.Collections;

public class TeleportePowerUpGo : AbstractTrocaDuplaPowerUpGo
{  
    public TeleportePowerUpGo() : base(powerUpDto.VazioPUp, "teleporte"){}    
   
    public override void resetPup(){}

    protected override IEnumerator realizarTroca(Coletavel coletavel1, Coletavel coletavel2)
    {
        Sprite spr1 = coletavel1.getSprite();
        Sprite spr2 = coletavel2.getSprite();

        MaterialTeleporte materialTeleporteIn  = new MaterialTeleporte();
        MaterialTeleporte materialTeleporteOut = new MaterialTeleporte();

        materialTeleporteIn.addTroca(spr1, spr2);
        materialTeleporteOut.addTroca(spr2, spr1);

        coletavel1.addMaterial(materialTeleporteIn.materialTeleporte);
        coletavel2.addMaterial(materialTeleporteOut.materialTeleporte);

        float contador = 0;
        while(contador < 1.01f)
        {
            contador += Time.deltaTime * powerUpDto.TeleporteDto.VelocidadeTeleporte;
            materialTeleporteIn.addValorDeTroca(contador);
            materialTeleporteOut.addValorDeTroca(contador);
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

        getTrocadorDeOrdem().trocar(coletavel1, coletavel2);

        yield return new WaitForSeconds(powerUpDto.TeleporteDto.DelayFinal);
        powerUpFinalizacao.finalizado();
        yield return null;
    }      
}
