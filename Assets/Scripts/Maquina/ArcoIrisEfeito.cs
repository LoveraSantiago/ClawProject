using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcoIrisEfeito 
{
    private static Color singleColor;

    private Coroutine coroutineArcoIris;
    private MonoBehaviour monoBehaviour;

    public ArcoIrisEfeito(MonoBehaviour monoBehaviour)
    {
        this.monoBehaviour = monoBehaviour;
    }

    public void ligarEfeitoArcoIris()
    {
        coroutineArcoIris = monoBehaviour.StartCoroutine(ligarGlowArcoIris());
    }

    public void desligarEfeitoArcoIris()
    {
        monoBehaviour.StopCoroutine(coroutineArcoIris);
    }

    private IEnumerator ligarGlowArcoIris()
    {
        while (true)
        {
            singleColor = HSBColor.ToColor(new HSBColor(Mathf.PingPong(Time.time * 0.5f, 1), 1, 1));

            
            yield return null;
        }
    }
}
