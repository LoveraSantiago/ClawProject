using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class ArcoIrisEfeito 
{
    private Coroutine coroutineAtual;
    private MonoBehaviour monoBehaviour;

    private List<ArcoIrisConjunto> listaArcoIrisConjunto;

    public ArcoIrisEfeito(MonoBehaviour monoBehaviour)
    {
        this.monoBehaviour = monoBehaviour;
        listaArcoIrisConjunto = new List<ArcoIrisConjunto>();
    }

    public void ligarEfeitoArcoIris()
    {
        ligarGlows();
        coroutineAtual = monoBehaviour.StartCoroutine(ligarGlowArcoIris());
    }

    public void ligarBlinkRed()
    {
        coroutineAtual = monoBehaviour.StartCoroutine(blinkarCor(Color.red));
    }

    public void ligarBlinkVerde()
    {
        coroutineAtual = monoBehaviour.StartCoroutine(blinkarCor(Color.green));
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
        monoBehaviour.StopCoroutine(coroutineAtual);
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
