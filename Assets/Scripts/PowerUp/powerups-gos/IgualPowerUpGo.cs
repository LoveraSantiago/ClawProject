using System.Collections;
using UnityEngine;

public class IgualPowerUpGo : AbstractTrocaPowerUpGo
{
    public IgualPowerUpGo() : base(powerUpDto.VazioPUp, "igual"){ }    
    
    public override void resetPup() { }    

    protected override IEnumerator realizarTroca(ColetavelTile coletavel1, ColetavelTile coletavel2)
    {
        Sprite spr1 = coletavel1.getSprite();
        Sprite spr2 = coletavel2.getSprite();

        MaterialTeleporte materialTeleporte = new MaterialTeleporte();
        materialTeleporte.addTroca(spr1, spr2);       

        coletavel1.addMaterial(materialTeleporte.materialTeleporte);

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

        coletavel1.desligarAnimacao();
        coletavel2.desligarAnimacao();
        yield return null;

        trocadorDeOrdem.trocarFigura(coletavel1, coletavel2);

        yield return new WaitForSeconds(powerUpDto.TeleporteDto.DelayFinal);
        powerUpFinalizacao.finalizado();
        yield return null;
    }        

    public static Fornecedor<AbstractPowerUpGo> getFornecedor()
    {
        return new FornecedorIgual();
    }

    public class FornecedorIgual : Fornecedor<AbstractPowerUpGo>
    {
        public AbstractPowerUpGo fornecer()
        {
            return new IgualPowerUpGo();
        }
    }
}
