using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilTeleguiadoPowerUpGo : AbstractPowerUpGo,
                                         ConsumidorDeEvento<ColetavelTile>
{
    private bool configurado;
    private bool hitColetavel;

    private ColetavelQuery coletavelQuery;

    public MissilTeleguiadoPowerUpGo(GameObject tileMissil) : 
        base(tileMissil, "missil-teleguiado")
    {
    }

    public override PowerUpEntidade.INTERACAOGARRA getInteracaoComGarra()
    {
        return PowerUpEntidade.INTERACAOGARRA.PARADO;
    }

    public override float getAnguloGarraSegurar()
    {
        return 16f;
    }

    public override void colocarNaPosicao(Vector3 posicao)
    {
        base.colocarNaPosicao(posicao + new Vector3(0, -0.4f, 0));
    }

    public override void ligar()
    {
        if (!configurado)
        {
            coletavelQuery = new ColetavelQuery();
            configurado = true;
        }
        base.ligar();        
        coletavelQuery.executeNoPoolDeColetaveis(this);
        monoBehaviour.StartCoroutine(selecionarAlvo());
    }

    private IEnumerator selecionarAlvo()
    {
        hitColetavel = false;
        while (!hitColetavel)
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
                    ColetavelTile coletavel = coletavelQuery.getColetavelInGameByName(raycastHit.collider.name);
                    coletavel.ligarAnimacaoMiraSelecionado();
                    hitColetavel = true;
                }
            }
            yield return null;
        }
        yield return null;
    }

    public void consumirEvento(ColetavelTile coletavel)
    {
        if (coletavel.isAtivo())
        {
            coletavel.ligarAnimacaoMira();                        
        }
    }
}
