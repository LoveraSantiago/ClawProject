using UnityEngine;

public class ContadorDeColetaveis
{    
    private int qtdColetados = 0;
    private SpriteRenderer[] spritesDeColetados;



    private ColetavelCallback callback;

    public ContadorDeColetaveis(SpriteRenderer[] spritesDeColetados, ColetavelCallback callback)
    {
        //itensColetados = new GameObject[3];
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

        Sprite primeiroSprite = spritesDeColetados[0].sprite;
        for(int i = 0; i < spritesDeColetados.Length; i++)
        {
            if(primeiroSprite != spritesDeColetados[1].sprite)
            {
                return false;
            }
        }

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

        if (callback != null)
        {
            callback.match(false);
        }
    }

    private void adicionaPontuacao()
    {
        Debug.Log("adicionaPontuacao");
        if (callback != null)
        {
            callback.match(true);
        }
    }

    private void resetarColetados()
    {
        Debug.Log("resetar coletado");
        qtdColetados = 0;       
    }

    public interface ColetavelCallback
    {
        public void match(bool result);
    }
}
