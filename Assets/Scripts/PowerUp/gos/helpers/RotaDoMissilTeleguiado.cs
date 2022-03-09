using System.Collections;
using UnityEngine;

public class RotaDoMissilTeleguiado 
{
    private float distanciaAnterior;
    private Vector2[] pathMissilRecalculado;

    public void recalcularRota(Vector3 posicaoFim, PathMissilDto pathMissil)
    {   
        Transform tranformMain = pathMissil.GoMainPath.transform;
        if (posicaoFim.x > 0)
        {
            tranformMain.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            tranformMain.localScale = new Vector3(1f, 1f, 1f);
        }

        int lenghPath = pathMissil.PathPointsMissil.Length;
        pathMissilRecalculado = new Vector2[lenghPath];
        for (int contador = 0; contador < lenghPath; contador++)
        {
            pathMissilRecalculado[contador] = pathMissil.PathPointsMissil[contador].position;
        }

        pathMissilRecalculado[lenghPath - 1] = posicaoFim;
        pathMissilRecalculado[lenghPath - 2] = new Vector2(posicaoFim.x, pathMissilRecalculado[lenghPath - 2].y);
    }

    public IEnumerator rotaParaOAlvo(GO go, float velocidade, int tamanhoDaRota)
    {
        int contadorIndice = 0;
        float contador = 0;
        Vector2 p1 = pathMissilRecalculado[contadorIndice * 3];
        Vector2 p2 = pathMissilRecalculado[contadorIndice * 3 + 1];
        Vector2 p3 = pathMissilRecalculado[contadorIndice * 3 + 2];
        Vector2 p4 = pathMissilRecalculado[contadorIndice * 3 + 3];

        distanciaAnterior = 100;

        while (true)
        {
            contador += (velocidade * Time.deltaTime);
            Vector2 posicao = MathUtils.cubicCurve(p1, p2, p3, p4, contador);
            Vector2 posNext = MathUtils.cubicCurve(p1, p2, p3, p4, contador + 0.01f);
            go.colocarNaPosicao(posicao);

            Vector2 diferenca = posicao - posNext;
            diferenca.Normalize();
            float z = Mathf.Atan2(diferenca.y, diferenca.x) * Mathf.Rad2Deg;
            Quaternion quat = Quaternion.Euler(0f, 0f, z - 90);
            go.colocarNoAngulo(quat);

            float distanciaAtual = (p4 - posicao).magnitude;
            //Debug.Log("Dist: " + distanciaAtual + " Ang: " + z);

            if (distanciaAtual > distanciaAnterior)
            {
                distanciaAnterior = 100;
                //Debug.Log("********************");
                contador = 0;
                contadorIndice++;
                if ((contadorIndice * 3 + 3) > tamanhoDaRota)
                {
                    break;
                }
                p1 = pathMissilRecalculado[contadorIndice * 3];
                p2 = pathMissilRecalculado[contadorIndice * 3 + 1];
                p3 = pathMissilRecalculado[contadorIndice * 3 + 2];
                p4 = pathMissilRecalculado[contadorIndice * 3 + 3];
            }
            else
            {
                distanciaAnterior = distanciaAtual;
            }
            yield return null;
        }
    }

}
