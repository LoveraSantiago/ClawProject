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

    public void iniciar(GrupoDisplays grupoDisplays)
    {
        if (acionarCacaNiquel)
        {
            Utils.MonoBehaviour.StartCoroutine(iniciarDisplayCacaNiquel(grupoDisplays));
        }
    }

    private IEnumerator iniciarDisplayCacaNiquel(GrupoDisplays grupoDisplays)
    {
        yield return new WaitForSeconds(0.5f);
        produtorDeEvento.produziuEvento(new Vazio());
        grupoDisplays.ligarGlowLuz();
    }

    ProdutorDeEvento<Vazio> AcaoCacaNiquel.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
