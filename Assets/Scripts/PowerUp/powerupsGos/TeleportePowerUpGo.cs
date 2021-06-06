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
    private ColetavelQuery coletavelQuery;

    public TeleportePowerUpGo(GameObject goTile, Material matIn, Material matOut) 
        : base(goTile, "teleporte")
    {
        this.matIn = matIn;
        this.matOut = matOut;
    }

    public override PowerUpEntidade.INTERACAOGARRA getInteracaoComGarra()
    {
        return PowerUpEntidade.INTERACAOGARRA.NAO_INTERACAO;
    }

    public override void configurarPup()
    {
        coletavelQuery = new ColetavelQuery();        
    }

    public override void iniciarPup()
    {
        coletavelQuery.executeNoPoolDeColetaveis(new LigadorDeMiras());
        monoBehaviour.StartCoroutine(selecionarAlvos());
    }

    public override void resetPup()
    {
        
    }

    private IEnumerator selecionarAlvos()
    {
        hitColetavel1 = false;
        while (!hitColetavel1)
        {
            if (inputGame.aconteceuTapNaAreaSuperior())
            {
                Vector3 posicaoTap = inputGame.getPosicaoTap();
                posicaoTap.z = 0;

                int layerMask = LayerMask.GetMask("Coletavel");
                RaycastHit2D raycastHit;
                raycastHit = Physics2D.Raycast(posicaoTap, Vector3.up, 2, layerMask);
                if (raycastHit.collider != null)
                {
                    string nomeAlvo = raycastHit.collider.name;
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
                Vector3 posicaoTap = inputGame.getPosicaoTap();
                posicaoTap.z = 0;

                int layerMask = LayerMask.GetMask("Coletavel");
                RaycastHit2D raycastHit;
                raycastHit = Physics2D.Raycast(posicaoTap, Vector3.up, 2, layerMask);
                if (raycastHit.collider != null)
                {
                    string nomeAlvo = raycastHit.collider.name;
                    coletavel2 = coletavelQuery.getColetavelInGameByName(raycastHit.collider.name);
                    coletavelQuery.executeNoPoolDeColetaveis(new LigadorDeAlvoFinal(nomeAlvo));                    
                    hitColetavel2 = true;
                    monoBehaviour.StartCoroutine(fazerTeleporte());
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
        while(contador < 1.1)
        {
            contador += Time.deltaTime * 0.75f;
            matOut.SetFloat("valor", contador);
            matIn.SetFloat("valor", contador);
            yield return null;
        }

        coletavel1.receberSprite(spr2);
        coletavel2.receberSprite(spr1);

        coletavel1.clearMaterial();
        coletavel2.clearMaterial();

        yield return null;
    }
}
