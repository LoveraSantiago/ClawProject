using UnityEngine;

public class ContadorDeColetaveis 
{
    private int qtdColetados;
    private GameObject[] itensColetados;

    private SpriteRenderer[] spritesDeColetados;

    public ContadorDeColetaveis(SpriteRenderer[] spritesDeColetados)
    {
        itensColetados = new GameObject[3];
        this.spritesDeColetados = spritesDeColetados;
    }

    public void adicionarColetado(GameObject coletado)
    {
        spritesDeColetados[qtdColetados].sprite = coletado.GetComponent<SpriteRenderer>().sprite;
        qtdColetados++;//alguma regra pra nao estourar os indices do array

        if (isCombinacaoValida())
        {
            algumaCoisa();
        }
        else
        {
            resetarColetados();
        }
    }

    private void algumaCoisa()
    {

    }


    private bool isCombinacaoValida()
    {
        //Regra para validar a cada coletado
        //talvez validar se o sprite e repitido
        //no caso negativo     
        return true;
    }

    private void resetarColetados()
    {
        qtdColetados = 0;
    }
}
