using System.Collections;
using UnityEngine;

public class IgualPowerUpGo : AbstractTrocaDuplaPowerUpGo
{
    public IgualPowerUpGo() : base(powerUpDto.VazioPUp, "igual"){ }    
    
    public override void resetPup() 
    {
        EfeitoParticulas efeitoTeleporte = new EfeitoParticulas();
        efeitoTeleporte.desligar(powerUpDto.TeleporteDto.EfeitoTeleporte1);
    }    

    protected override IEnumerator realizarTroca(DuplaDeColetaveisDto duplaDeColetaveis)
    {
        Coletavel coletavel1 = duplaDeColetaveis.coletavel1;
        Coletavel coletavel2 = duplaDeColetaveis.coletavel2;

        EfeitoParticulas efeitoTeleporte = new EfeitoParticulas();
        efeitoTeleporte.ligar(powerUpDto.TeleporteDto.EfeitoTeleporte1, coletavel1.getPosicao());

        Sprite spr1 = coletavel1.getSprite();
        Sprite spr2 = coletavel2.getSprite();

        MaterialTeleporte materialTeleporte = new MaterialTeleporte();
        materialTeleporte.addTroca(spr1, spr2);

        coletavel1.addMaterial(materialTeleporte.materialTeleporte);
        somPowerUp.playSomTeleporte();

        float contador = 0;
        while (contador < 1.01f)
        {
            contador += Time.deltaTime * powerUpDto.TeleporteDto.VelocidadeTeleporte;
            materialTeleporte.addValorDeTroca(contador);            
            yield return null;
        }

        powerUpFinalizacao.preFinalizar();
        coletavel1.receberSprite(spr2);

        coletavel1.clearMaterial();

        coletavel1.ligarAnimacaoIdle();
        coletavel2.ligarAnimacaoIdle();
        yield return null;

        getTrocadorDeOrdem().trocarFigura(coletavel1, coletavel2);

        yield return new WaitForSeconds(powerUpDto.TeleporteDto.DelayFinal);        
        powerUpFinalizacao.finalizado();
        yield return null;
    }          
}
