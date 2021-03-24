using UnityEngine;

public class ContadorDeColetaveis
{
    private int qtdColetados = 0;
    private GameObject[] itensColetados;

    private SpriteRenderer[] spritesDeColetados;

    public ContadorDeColetaveis(SpriteRenderer[] spritesDeColetados)
    {
        itensColetados = new GameObject[3];
        this.spritesDeColetados = spritesDeColetados;
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
        itensColetados = new GameObject[3];
    }
}
