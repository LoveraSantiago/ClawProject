using System.Collections;
using UnityEngine;

public class Elevador : AcaoElevadorFim.ProdutorEvento,
                        Consumidor<bool>
{
    private ElevadorDto elevadorDto;
    private MonoBehaviour monoBehaviour;

    private GameObject paredeAlta;
    private GameObject paredeBaixa;

    public ProdutorDeEvento<ElevadorFim> produtorEventoElevador;

    public Elevador(ElevadorDto elevadorDto, MonoBehaviour monoBehaviour)
    {
        this.elevadorDto = elevadorDto;
        this.monoBehaviour = monoBehaviour;
        posicionarParedes();

        produtorEventoElevador = new ProdutorDeEvento<ElevadorFim>();
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
        while(paredeAlta.transform.localPosition.y < elevadorDto.AlturaSubida)
        {
            Vector3 acrescimo = new Vector3(0, elevadorDto.VelocidadeSubida * Time.deltaTime, 0);
            paredeAlta.transform.localPosition  += acrescimo;
            paredeBaixa.transform.localPosition += acrescimo;

            produtorEventoElevador.produziuEvento(null);
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

    ProdutorDeEvento<ElevadorFim> AcaoElevadorFim.ProdutorEvento.getProdutorDeEventoColetado()
    {
        return produtorEventoElevador;
    }
}
