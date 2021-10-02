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

        Material matIn = new Material(powerUpDto.TeleporteDto.MatTeleporte);
        matIn.SetTexture(PROP_SPRITE_IN, spr1.texture);
        matIn.SetTexture(PROP_SPRITE_OUT, spr2.texture);

        coletavel1.addMaterial(matIn);

        float contador = 0;
        while (contador < 1.01f)
        {
            contador += Time.deltaTime * powerUpDto.TeleporteDto.Velocidade;            
            matIn.SetFloat(PROP_VALOR, contador);
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
