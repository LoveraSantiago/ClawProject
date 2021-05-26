using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilTeleguiadoPowerUpGo : AbstractPowerUpGo                                         
{
    private bool configurado;
    private bool hitColetavel;

    private ColetavelQuery coletavelQuery;
    private CapsuleCollider2D capsuleCollider;
    
    private Vector2[] pathMissilRecalculado;
    private PathMissilDto pathMissilDto;

    public MissilTeleguiadoPowerUpGo(GameObject tileMissil, PathMissilDto pathMissilDto) : 
        base(tileMissil, "missil-teleguiado")
    {
        this.pathMissilDto = pathMissilDto;
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
        recalcularPath(coletavel.getPosicao());
        capsuleCollider.isTrigger = true;
        int contadorIndice = 0;
        float contador = 0;
        Vector2 p1 = pathMissilRecalculado[contadorIndice * 3];
        Vector2 p2 = pathMissilRecalculado[contadorIndice * 3 + 1];
        Vector2 p3 = pathMissilRecalculado[contadorIndice * 3 + 2];
        Vector2 p4 = pathMissilRecalculado[contadorIndice * 3 + 3];

        while (true)
        {
            contador += (2.5f * Time.deltaTime);
            Vector2 posicao = cubicCurve(p1, p2, p3, p4, contador);
            Vector2 posNext = cubicCurve(p1, p2, p3, p4, contador + 0.01f);
            colocarNaPosicao(posicao);

            Vector2 diferenca = posicao - posNext;
            diferenca.Normalize();
            float z = Mathf.Atan2(diferenca.y, diferenca.x) * Mathf.Rad2Deg;
            Quaternion quat = Quaternion.Euler(0f, 0f, z - 90);
            colocarNoAngulo(quat);

            float distancia = (posicao - p4).sqrMagnitude;
            Debug.Log("Dist: " + distancia + " Ang: " + z);
            if (distancia < 0.1f)
            {
                Debug.Log("********************");
                contador = 0;
                contadorIndice++;
                if ((contadorIndice * 3 + 3) > pathMissilDto.PathPointsMissil.Length)
                {
                    break;
                }
                p1 = pathMissilRecalculado[contadorIndice * 3];
                p2 = pathMissilRecalculado[contadorIndice * 3 + 1];
                p3 = pathMissilRecalculado[contadorIndice * 3 + 2];
                p4 = pathMissilRecalculado[contadorIndice * 3 + 3];
            }
            yield return null;
        }
        coletavel.disparar(0, 20f);
        coletavel.desligarAnimacao();
        desligar();

        PequenaExplosaoShake explosaoShake = new PequenaExplosaoShake(monoBehaviour);
        explosaoShake.shake();
        powerUpFinalizacao.preFinalizar();

        yield return new WaitForSeconds(1.1f);
        powerUpFinalizacao.finalizado();

        yield return null;
    }

    private void recalcularPath(Vector3 posicaoFim)
    {
        if(posicaoFim.x > 0)
        {
            pathMissilDto.GoMainPath.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            pathMissilDto.GoMainPath.transform.localScale = new Vector3(1f, 1f, 1f);
        }

        pathMissilRecalculado = new Vector2[pathMissilDto.PathPointsMissil.Length];
        for(int contador = 0; contador < pathMissilDto.PathPointsMissil.Length; contador++)
        {
            pathMissilRecalculado[contador] = pathMissilDto.PathPointsMissil[contador].position;
        }

        pathMissilRecalculado[pathMissilRecalculado.Length - 1] = posicaoFim;
        pathMissilRecalculado[pathMissilRecalculado.Length - 2] = new Vector2(posicaoFim.x, pathMissilRecalculado[pathMissilRecalculado.Length - 2].y);
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
