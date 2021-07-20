using System.Collections;
using UnityEngine;

public class Elevador : Consumidor<bool>
{
    private ElevadorDto elevadorDto;
    private MonoBehaviour monoBehaviour;

    private GameObject paredeAlta;
    private GameObject paredeBaixa;

    public Elevador(ElevadorDto elevadorDto, MonoBehaviour monoBehaviour)
    {
        this.elevadorDto = elevadorDto;
        this.monoBehaviour = monoBehaviour;
        posicionarParedes();
    }

    private void acionarElevador()
    {
        monoBehaviour.StartCoroutine(subirElevador());
    }

    public void consumir(bool evento)
    {
        acionarElevador();
    }

    private IEnumerator subirElevador()
    {
        while(paredeAlta.transform.localPosition.y < 0.9f)
        {
            Vector3 acrescimo = new Vector3(0, elevadorDto.VelocidadeSubida * Time.deltaTime, 0);
            paredeAlta.transform.localPosition += acrescimo;
            paredeBaixa.transform.localPosition += acrescimo;
            yield return null;
        }
        posicionarParedes();
        yield return null;
    }

    private void posicionarParedes()
    {
        if(paredeAlta != elevadorDto.ParedeHorizontal1)
        {
            paredeAlta = elevadorDto.ParedeHorizontal1;
            paredeBaixa = elevadorDto.ParedeHorizontal2;
        }
        else
        {
            paredeAlta = elevadorDto.ParedeHorizontal2;
            paredeBaixa = elevadorDto.ParedeHorizontal1;
        }
        paredeAlta.transform.localPosition = Vector3.zero;
        paredeBaixa.transform.localPosition = new Vector3(0, elevadorDto.PosBaixo, 0);
    }
}
