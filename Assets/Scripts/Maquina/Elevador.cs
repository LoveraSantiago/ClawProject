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

        paredeAlta = elevadorDto.ParedeHorizontal1;
        paredeBaixa = elevadorDto.ParedeHorizontal2;

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
        while(paredeBaixa.transform.localPosition.y < 0)
        {
            Vector3 acrescimo = new Vector3(0, elevadorDto.VelocidadeSubida * Time.deltaTime, 0);
            paredeAlta.transform.localPosition  += acrescimo;
            paredeBaixa.transform.localPosition += acrescimo;

            yield return new WaitForFixedUpdate();
        }

        yield return new WaitForSeconds(1f);
        equipararParedes();        
        yield return new WaitForSeconds(1f);
        Debug.Log("Chamando eventos pre fim");
        produtorEventoElevador.produziuEvento(new ElevadorFim(false));
        yield return new WaitForSeconds(1f);
        while(paredeAlta.transform.localPosition.y > 0)
        {
            Vector3 acrescimo = new Vector3(0, (elevadorDto.VelocidadeSubida) * Time.deltaTime, 0);
            paredeAlta.transform.localPosition -= acrescimo;

            yield return new WaitForFixedUpdate();
        }
        posicionarParedes();        
        yield return new WaitForSeconds(1f);
        Debug.Log("Chamando eventos fim");
        produtorEventoElevador.produziuEvento(new ElevadorFim(true));
        yield return null;
    }

    private void equipararParedes()
    {
        Debug.Log("Paredes equiparadas inicio");
        paredeAlta.transform.localPosition = Vector3.zero;
        paredeBaixa.transform.localPosition = Vector3.zero;
        Debug.Log("Paredes equiparadas fim");
    }

    private void posicionarParedes()
    {
        Debug.Log("Posicionar paredes inicio");        
        paredeBaixa.transform.localPosition = new Vector3(0, elevadorDto.PosBaixo, 0);        
        Debug.Log("Posicionar paredes inicio");
    }    

    ProdutorDeEvento<ElevadorFim> AcaoElevadorFim.ProdutorEvento.getProdutorDeEventoColetado()
    {
        return produtorEventoElevador;
    }
}
