using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilTeleguiadoPowerUpGo : AbstractPowerUpGo
                                         
{
    private bool configurado;
    private bool hitColetavel;

    private ColetavelQuery coletavelQuery;
    private CapsuleCollider2D capsuleCollider;
    private Transform[] pathMissil;

    public MissilTeleguiadoPowerUpGo(GameObject tileMissil, Transform[] pathMissil) : 
        base(tileMissil, "missil-teleguiado")
    {
        this.pathMissil = pathMissil;
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
            capsuleCollider = goColetavel.GetComponent<CapsuleCollider2D>();
        }
        base.ligar();        
        coletavelQuery.executeNoPoolDeColetaveis(new LigadorDeMiras());
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
                    string nomeAlvo = raycastHit.collider.name;
                    coletavelQuery.executeNoPoolDeColetaveis(new LigadorDeAlvo(nomeAlvo));
                    hitColetavel = true;
                    monoBehaviour.StartCoroutine(disparandoMissil(coletavelQuery.getColetavelInGameByName(nomeAlvo)));
                }
            }
            yield return null;
        }
        yield return null;
    }

    private IEnumerator disparandoMissil(ColetavelTile coletavel)
    {
        capsuleCollider.isTrigger = true;
        while (true)
        {
            Vector2 direcao = (Vector2) (coletavel.getPosicao() - getPosicao());
            direcao.Normalize();
            float rotacao = Vector3.Cross(direcao, goColetavel.transform.up).z;
            addVelocidadeAngular(-rotacao * 1);
            addVelocidade(- goColetavel.transform.up * 1);

            yield return null;
        }

        yield return null;
    }

    private class LigadorDeAlvo : ConsumidorDeEvento<ColetavelTile>
    {
        private string nameAlvo;

        public LigadorDeAlvo(string nameAlvo)
        {
            this.nameAlvo = nameAlvo;
        }

        public void consumirEvento(ColetavelTile coletavel)
        {
            if (coletavel.isAtivo())
            {
                if (coletavel.nome.Equals(nameAlvo))
                {
                    coletavel.ligarAnimacaoMiraSelecionado();
                }
                else
                {
                    coletavel.desligarAnimacao();
                }
            }
        }
    }

    private class LigadorDeMiras : ConsumidorDeEvento<ColetavelTile>
    {
        public void consumirEvento(ColetavelTile coletavel)
        {
            if (coletavel.isAtivo())
            {
                coletavel.ligarAnimacaoMira();                        
            }
        }
    }

    public Vector2 lerp(Vector2 a, Vector2 b, float t)
    {
        return a + (b - a) * t;
    }

    public Vector2 quadraticCurve(Vector2 a, Vector2 b, Vector2 c, float t)
    {
        Vector2 p0 = lerp(a, b, t);
        Vector2 p1 = lerp(b, c, t);
        return lerp(p0, p1, t);
    }

    public Vector2 cubicCurve(Vector2 a, Vector2 b, Vector2 c, Vector2 d, float t)
    {
        Vector2 p0 = quadraticCurve(a, b, c, t);
        Vector2 p1 = quadraticCurve(b, c, d, t);
        return lerp(p0, p1, t);
    }
}
