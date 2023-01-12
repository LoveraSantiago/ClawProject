using UnityEngine;
using System.Collections;

public class TeleportePowerUpGo : AbstractTrocaDuplaPowerUpGo
{  
    public TeleportePowerUpGo() : base(powerUpDto.VazioPUp, "teleporte"){}    
   
    public override void resetPup(){}

    protected override IEnumerator realizarTroca(DuplaDeColetaveisDto duplaDeColetaveis)
    {
        Coletavel coletavel1 = duplaDeColetaveis.coletavel1;
        Coletavel coletavel2 = duplaDeColetaveis.coletavel2;

        EfeitoParticulas efeitoTeleporte = new EfeitoParticulas();
        efeitoTeleporte.ligar(powerUpDto.TeleporteDto.EfeitoTeleporte1, coletavel1.getPosicao());
        efeitoTeleporte.ligar(powerUpDto.TeleporteDto.EfeitoTeleporte2, coletavel2.getPosicao());

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

        coletavel1.ligarAnimacaoIdle();
        coletavel2.ligarAnimacaoIdle();
        yield return null;

        getTrocadorDeOrdem().trocar(coletavel1, coletavel2);

        yield return new WaitForSeconds(powerUpDto.TeleporteDto.DelayFinal);

        efeitoTeleporte.desligar(powerUpDto.TeleporteDto.EfeitoTeleporte1);
        efeitoTeleporte.desligar(powerUpDto.TeleporteDto.EfeitoTeleporte2);
        powerUpFinalizacao.finalizado();
        yield return null;
    }      
}
