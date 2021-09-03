using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class ArcoIrisEfeito 
{
    private Coroutine coroutineAtual;    

    private List<ArcoIrisConjunto> listaArcoIrisConjunto;

    public ArcoIrisEfeito()
    {   
        listaArcoIrisConjunto = new List<ArcoIrisConjunto>();
    }

    public void ligarEfeitoArcoIris()
    {
        ligarGlows();
        coroutineAtual = Utils.MonoBehaviour.StartCoroutine(ligarGlowArcoIris());
    }

    public void ligarBlinkRed()
    {
        coroutineAtual = Utils.MonoBehaviour.StartCoroutine(blinkarCor(Color.red));
    }

    public void ligarBlinkVerde()
    {
        coroutineAtual = Utils.MonoBehaviour.StartCoroutine(blinkarCor(Color.green));
    }

    private void ligarGlows()
    {
        for (int contador = 0; contador < listaArcoIrisConjunto.Count; contador++)
        {
            listaArcoIrisConjunto[contador].ligar();
        }
    }

    public void desligarEfeito()
    {
        desligarGlows();
        Utils.MonoBehaviour.StopCoroutine(coroutineAtual);
    }

    private void desligarGlows()
    {
        for (int contador = 0; contador < listaArcoIrisConjunto.Count; contador++)
        {
            listaArcoIrisConjunto[contador].desligar();
        }
    }

    public ArcoIrisEfeito addArcoIrisConjunto(ArcoIrisConjunto arcoIrisConjunto)
    {
        listaArcoIrisConjunto.Add(arcoIrisConjunto);
        return this;
    }

    private IEnumerator ligarGlowArcoIris()
    {
        while (true)
        {
            Color singleColor = HSBColor.ToColor(new HSBColor(Mathf.PingPong(Time.time * 0.5f, 1), 1, 1));
            for (int contador = 0; contador < listaArcoIrisConjunto.Count; contador++)
            {
                listaArcoIrisConjunto[contador].passarCor(singleColor);
            }

            yield return null;
        }
    }

    private IEnumerator blinkarCor(Color cor)
    {
        while (true)
        {
            ligarGlows();
            for (int contador = 0; contador < listaArcoIrisConjunto.Count; contador++)
            {
                listaArcoIrisConjunto[contador].passarCor(cor);
            }
            yield return new WaitForSeconds(0.2f);
            desligarGlows();
            yield return new WaitForSeconds(0.2f);
        }
    }
}
