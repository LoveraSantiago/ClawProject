using UnityEngine;
using System.Collections;

public class TeleportePowerUpGo : PowerUpNaoInteracaoComGarra
{
    private static TrocadorDeOrdem trocadorDeOrdem;    

    private bool hitColetavel2;            
    private Coroutine coroutine;

    public TeleportePowerUpGo() 
        : base(powerUpDto.VazioPUp, "teleporte")
    {
    
    }    

    public override void configurarPup(){}

    public override void iniciarPup()
    {
        ColetaveisMiras miras = new ColetaveisMiras();
        miras.ligar();
        coroutine = Utils.MonoBehaviour.StartCoroutine(selecionarAlvos());
    }

    public override void resetPup(){}

    private IEnumerator selecionarAlvos()
    {
        bool hitColetavel1 = false;
        hitColetavel2 = false;

        ColetavelTile coletavel1 = null;
        ColetavelTile coletavel2 = null;

        ColetavelQuery coletavelQuery = new ColetavelQuery();
        ColetavelHit coletavelHit = new ColetavelHit();
        while (!hitColetavel1)
        {
            if (inputGame.aconteceuTapNaAreaSuperior())
            {
                Collider2D coletavelAcertado = coletavelHit.hit(inputGame);
                if (coletavelAcertado != null)
                {
                    string nomeAlvo = coletavelAcertado.name;
                    coletavel1 = coletavelQuery.getColetavelInGameByName(nomeAlvo);
                    coletavel1.ligarAnimacaoMiraSelecionado();
                    hitColetavel1 = true;                    
                }
            }
            yield return null;
        }

        while (!hitColetavel2)
        {
            if (inputGame.aconteceuTapNaAreaSuperior())
            {
                Collider2D coletavelAcertado = coletavelHit.hit(inputGame);
                if (coletavelAcertado != null)
                {
                    string nomeAlvo = coletavelAcertado.name;
                    coletavel2 = coletavelQuery.getColetavelInGameByName(nomeAlvo);
                    if (!coletavel1.nome.Equals(coletavel2.nome))
                    {
                        coletavelQuery.executeNoPoolDeColetaveis(new LigadorDeAlvoFinal(nomeAlvo));                    
                        hitColetavel2 = true;
                        Utils.MonoBehaviour.StartCoroutine(fazerTeleporte(coletavel1, coletavel2));
                    }
                }
            }
            yield return null;
        }
        yield return null;
    }

    private IEnumerator fazerTeleporte(ColetavelTile coletavel1, ColetavelTile coletavel2)
    {
        Sprite spr1 = coletavel1.getSprite();
        Sprite spr2 = coletavel2.getSprite();

        Material matIn = powerUpDto.TeleporteDto.MatTeleporteIn;
        Material matOut = powerUpDto.TeleporteDto.MatTeleporteOut;
        matIn.SetTexture("inSprite", spr1.texture);
        matIn.SetTexture("outSprite", spr2.texture);

        matOut.SetTexture("inSprite", spr2.texture);
        matOut.SetTexture("outSprite", spr1.texture);

        coletavel1.addMaterial(matIn);
        coletavel2.addMaterial(matOut);

        float contador = 0;
        while(contador < 1.01f)
        {
            contador += Time.deltaTime * powerUpDto.TeleporteDto.Velocidade;
            matOut.SetFloat("valor", contador);
            matIn.SetFloat("valor", contador);
            yield return null;
        }
        powerUpFinalizacao.preFinalizar();
        coletavel1.receberSprite(spr2);
        coletavel2.receberSprite(spr1);

        coletavel1.clearMaterial();
        coletavel2.clearMaterial();

        coletavel1.desligarAnimacao();
        coletavel2.desligarAnimacao();

        yield return new WaitForSeconds(powerUpDto.TeleporteDto.DelayFinal);
        powerUpFinalizacao.finalizado();
        yield return null;
    }

    public override void timeout()
    {
        if (!hitColetavel2)
        {
            Utils.MonoBehaviour.StopCoroutine(coroutine);
            ColetaveisMiras miras = new ColetaveisMiras();
            miras.desligar();
            powerUpFinalizacao.finalizado();
        }
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

    public static void configurarTrocadorDeOrdem(TrocadorDeOrdem trocadorDeOrdemArg)
    {
        trocadorDeOrdem = trocadorDeOrdemArg;
    }
}
