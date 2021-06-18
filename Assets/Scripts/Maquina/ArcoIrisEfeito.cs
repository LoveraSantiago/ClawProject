using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class ArcoIrisEfeito 
{
    private Coroutine coroutineArcoIris;
    private MonoBehaviour monoBehaviour;

    private List<ArcoIrisConjunto> listaArcoIrisConjunto;

    public ArcoIrisEfeito(MonoBehaviour monoBehaviour)
    {
        this.monoBehaviour = monoBehaviour;
        listaArcoIrisConjunto = new List<ArcoIrisConjunto>();
    }

    public void ligarEfeitoArcoIris()
    {
        for(int contador = 0; contador < listaArcoIrisConjunto.Count; contador++)
        {
            listaArcoIrisConjunto[contador].ligar();
        }
        coroutineArcoIris = monoBehaviour.StartCoroutine(ligarGlowArcoIris());
    }

    public void desligarEfeitoArcoIris()
    {
        for (int contador = 0; contador < listaArcoIrisConjunto.Count; contador++)
        {
            listaArcoIrisConjunto[contador].desligar();
        }
        monoBehaviour.StopCoroutine(coroutineArcoIris);
    }

    public void addArcoIrisConjunto(ArcoIrisConjunto arcoIrisConjunto)
    {
        listaArcoIrisConjunto.Add(arcoIrisConjunto);
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
}
