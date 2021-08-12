using UnityEngine;
using System.Collections;

public class TeleportePowerUpGo : AbstractPowerUpGo
{
    private bool hitColetavel1;
    private bool hitColetavel2;

    private Material matIn;
    private Material matOut;

    private ColetavelTile coletavel1;
    private ColetavelTile coletavel2;

    private Coroutine coroutine;

    public TeleportePowerUpGo() 
        : base(powerUpDto.VazioPUp, "teleporte")
    {
        this.matIn = powerUpDto.MatTeleporteIn;
        this.matOut = powerUpDto.MatTeleporteOut;
    }

    public override GarraInteracaoComPowerUp getObjetoDeInteracaoComGarra()
    {
        return new NaoInteracaoComGarra();
    }

    public override void configurarPup()
    {
    }

    public override void iniciarPup()
    {
        ligarMirasNosColetaveis();
        coroutine = monoBehaviour.StartCoroutine(selecionarAlvos());
    }

    public override void resetPup()
    {
        
    }

    private IEnumerator selecionarAlvos()
    {
        hitColetavel1 = false;
        hitColetavel2 = false;
        ColetavelQuery coletavelQuery = new ColetavelQuery();

        while (!hitColetavel1)
        {
            if (inputGame.aconteceuTapNaAreaSuperior())
            {                
                Collider2D coletavelHit = getColetavelHit();
                if (coletavelHit != null)
                {
                    string nomeAlvo = coletavelHit.name;
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
                Collider2D coletavelHit = getColetavelHit();
                if (coletavelHit != null)
                {
                    string nomeAlvo = coletavelHit.name;
                    coletavel2 = coletavelQuery.getColetavelInGameByName(nomeAlvo);
                    if (!coletavel1.nome.Equals(coletavel2.nome))
                    {
                        coletavelQuery.executeNoPoolDeColetaveis(new LigadorDeAlvoFinal(nomeAlvo));                    
                        hitColetavel2 = true;
                        monoBehaviour.StartCoroutine(fazerTeleporte());
                    }
                }
            }
            yield return null;
        }
        yield return null;
    }

    private IEnumerator fazerTeleporte()
    {
        Sprite spr1 = coletavel1.getSprite();
        Sprite spr2 = coletavel2.getSprite();        

        matIn.SetTexture("inSprite", spr1.texture);
        matIn.SetTexture("outSprite", spr2.texture);

        matOut.SetTexture("inSprite", spr2.texture);
        matOut.SetTexture("outSprite", spr1.texture);

        coletavel1.addMaterial(matIn);
        coletavel2.addMaterial(matOut);

        float contador = 0;
        while(contador < 1.01f)
        {
            contador += Time.deltaTime * 0.75f;
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

        yield return new WaitForSeconds(0.5f);
        powerUpFinalizacao.finalizado();
        yield return null;
    }

    public override void timeout()
    {
        if (!hitColetavel2)
        {
            monoBehaviour.StopCoroutine(coroutine);
            desligarMirasNosColetaveis();
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
}
