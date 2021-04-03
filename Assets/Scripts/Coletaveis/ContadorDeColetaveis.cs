using UnityEngine;

public class ContadorDeColetaveis
{
    private int score = 0;
    private int qtdColetados = 0;

    private string[] nomesColetados;

    private ColetavelCallback callback;

    private ProdutorDeEvento<Sprite> produtorDeSpriteColetado;

    public ContadorDeColetaveis(ColetavelCallback callback)
    {
        this.callback = callback;
        nomesColetados = new string[3];
        produtorDeSpriteColetado = new ProdutorDeEvento<Sprite>();
    }

    public void adicionarColetado(string nomeColetado)
    {
        adicionaAoContainerDeColetados(nomeColetado);

        if (qtdColetados > nomesColetados.Length - 1)
        {
            if (isCombinacaoValida())
            {
                AudioController.current.PlayAudio(AudioController.current.combinacaoOk);
                adicionaPontuacao();
            }
            else
            {
                AudioController.current.PlayAudio(AudioController.current.combinacaoNok);
                retornaObjetosParaBoard();
            }

            resetarColetados();
        }

    }

    public int getQtdColetados()
    {
        return qtdColetados;
    }

    private bool isCombinacaoValida()
    {
        string nomePrimeiroColetado = nomesColetados[0];
        for (int i = 0; i < nomesColetados.Length; i++)
        {
            if (nomePrimeiroColetado.Equals(nomesColetados[i]))
            {
                return false;
            }
        }
        return true;
    }

    private void adicionaAoContainerDeColetados(string nomeColetado)
    {
        nomesColetados[qtdColetados] = nomeColetado;
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
        score += 30;        
    }

    private void resetarColetados()
    {
        qtdColetados = 0;
    }

    public interface ColetavelCallback
    {
        void match(bool result);
    }
}
