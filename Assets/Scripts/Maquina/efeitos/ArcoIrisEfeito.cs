using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class ArcoIrisEfeito 
{
    public static Color greenHdr  { get; private set; }
    public static Color redHdr    { get; private set; }
    public static Color yellowHdr { get; private set; }

    private float factorHdr;
    private Coroutine coroutineAtual;    
    private List<ArcoIrisConjunto> listaArcoIrisConjunto;

    public ArcoIrisEfeito(float factorHdr)
    {
        this.factorHdr = factorHdr;
        listaArcoIrisConjunto = new List<ArcoIrisConjunto>();
        configurarCoresHdr(factorHdr);
    }

    public void ligarEfeitoArcoIris()
    {
        ligarGlows();
        coroutineAtual = Utils.MonoBehaviour.StartCoroutine(ligarGlowArcoIris());
    }

    public void ligarBlinkRed()
    {
        coroutineAtual = Utils.MonoBehaviour.StartCoroutine(blinkarCor(redHdr));
    }

    public void ligarBlinkVerde()
    {
        coroutineAtual = Utils.MonoBehaviour.StartCoroutine(blinkarCor(greenHdr));
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
            Color singleColor    = HSBColor.ToColor(new HSBColor(Mathf.PingPong(Time.time * 0.5f, 1), 1, 1));
            Color singleColorHdr = HSBColor.toHdrColor(singleColor, factorHdr);
            for (int contador = 0; contador < listaArcoIrisConjunto.Count; contador++)
            {
                listaArcoIrisConjunto[contador].passarCor(singleColorHdr);
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

    public void configurarCoresHdr(float factorHdr)
    {
        greenHdr  = HSBColor.toHdrColor(Color.green, factorHdr);
        redHdr    = HSBColor.toHdrColor(Color.red, factorHdr);
        yellowHdr = HSBColor.toHdrColor(Color.yellow, factorHdr);
    }
}
