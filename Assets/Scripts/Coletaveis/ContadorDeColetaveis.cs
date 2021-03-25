using UnityEngine;

public class ContadorDeColetaveis
{    
    private int qtdColetados = 0;
    private SpriteRenderer[] spritesDeColetados;



    private ColetavelCallback callback;

    public ContadorDeColetaveis(SpriteRenderer[] spritesDeColetados, ColetavelCallback callback)
    {        
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
        Sprite primeiroSprite = spritesDeColetados[0].sprite;
        for(int i = 0; i < spritesDeColetados.Length; i++)
        {
            if(primeiroSprite != spritesDeColetados[i].sprite)
            {
                return false;
            }
        }

        return true;
    }

    private void adicionaAoContainerDeColetados(Sprite coletado)
    {        
        spritesDeColetados[qtdColetados].sprite = coletado;
        qtdColetados++;
    }

    private void retornaObjetosParaBoard()
    {        
        if (callback != null)
        {
            callback.match(false);
        }
    }

    private void adicionaPontuacao()
    {        
        if (callback != null)
        {
            callback.match(true);
        }
    }

    private void resetarColetados()
    {        
        qtdColetados = 0;       
    }

    public interface ColetavelCallback
    {
        public void match(bool result);
    }
}
