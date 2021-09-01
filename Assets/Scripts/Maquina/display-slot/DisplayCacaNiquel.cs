using System.Collections;
using UnityEngine;

public class DisplayCacaNiquel : AcaoCacaNiquel.ProdutorEvento
{
    private bool acionarCacaNiquel;
    private ProdutorDeEvento<Vazio> produtorDeEvento;

    public DisplayCacaNiquel()
    {
        produtorDeEvento = new ProdutorDeEvento<Vazio>();
    }

    public void configuradoPeloLevel(AbstractLevel.TIPO_GAME tipoGame)
    {        
        if(tipoGame == AbstractLevel.TIPO_GAME.CACANIQUEL_PUP)
        {
            acionarCacaNiquel = true;
        }
    }

    public void iniciar()
    {
        if (acionarCacaNiquel)
        {
            Utils.MonoBehaviour.StartCoroutine(iniciarDisplayCacaNiquel());
        }
    }

    private IEnumerator iniciarDisplayCacaNiquel()
    {
        yield return new WaitForSeconds(0.5f);
        produtorDeEvento.produziuEvento(new Vazio());
    }

    ProdutorDeEvento<Vazio> AcaoCacaNiquel.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
