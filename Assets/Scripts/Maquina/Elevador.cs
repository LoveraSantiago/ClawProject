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
        elevadorDto.ParedeHorizontalFixa.transform.localPosition = new Vector3(0, elevadorDto.PosBaixo, 0);
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

            yield return null;
        }

        equipararParedes();
        yield return new WaitForSeconds(0.5f);
        produtorEventoElevador.produziuEvento(null);
        yield return new WaitForSeconds(0.5f);
        posicionarParedes();
        yield return null;
    }

    private void equipararParedes()
    {
        paredeAlta.transform.localPosition = paredeBaixa.transform.localPosition;
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
        paredeAlta.layer = 11;
        
        paredeBaixa.transform.localPosition = new Vector3(0, elevadorDto.PosBaixo, 0);
        paredeBaixa.layer = 17;

    }    

    ProdutorDeEvento<ElevadorFim> AcaoElevadorFim.ProdutorEvento.getProdutorDeEventoColetado()
    {
        return produtorEventoElevador;
    }
}
