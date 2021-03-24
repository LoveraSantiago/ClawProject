using UnityEngine;

public class ContadorDeColetaveis
{
    private int qtdColetados = 0;
    private GameObject[] itensColetados;

    private SpriteRenderer[] spritesDeColetados;    
    public GameObject[] Match { get { return itensColetados; } }

    private ColetavelCallback callback;

    public ContadorDeColetaveis(SpriteRenderer[] spritesDeColetados, ColetavelCallback callback)
    {
        itensColetados = new GameObject[3];
        this.spritesDeColetados = spritesDeColetados;
        this.callback = callback;
    }

    public void adicionarColetado(GameObject coletado)
    {        
        adicionaAoContainerDeColetados(coletado.GetComponent<SpriteRenderer>().sprite);

        if (qtdColetados > spritesDeColetados.Length - 1)
        {
            if (isCombinacaoValida())
            {
                adicionaPontuacao();

                if(callback != null)
                {
                    callback.match(itensColetados);
                }

            }
            else
            {
                retornaObjetosParaBoard();
            }

            resetarColetados();
        }

    }

    private bool isCombinacaoValida()
    {
        Debug.Log("isCombinacaoValida");
        return true;
    }

    private void adicionaAoContainerDeColetados(Sprite coletado)
    {
        Debug.Log("adicionaAoContainerDeColetados");
        spritesDeColetados[qtdColetados].sprite = coletado;
        qtdColetados++;
    }

    private void retornaObjetosParaBoard()
    {
        Debug.Log("retornarObjetosParaBoard");
    }

    private void adicionaPontuacao()
    {
        Debug.Log("adicionaPontuacao");
    }

    private void resetarColetados()
    {
        Debug.Log("resetar coletado");
        qtdColetados = 0;
        //itensColetados = new GameObject[3];
        //spritesDeColetados = new SpriteRenderer[3];
    }

    public interface ColetavelCallback
    {
        public void match(GameObject[] coletados);
    }
}
