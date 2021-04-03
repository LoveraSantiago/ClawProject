using UnityEngine;

public class ContadorDeColetaveis
{
    private int score = 0;
    private int qtdColetados = 0;

    private string[] nomesColetados;

    public ContadorDeColetaveis()
    {
        nomesColetados = new string[3];
    }

    public void adicionarColetado(string nomeColetado,
        ResultadoDoContadorColetaveis resultadoSucesso, ResultadoDoContadorColetaveis resultadoFalha)
    {
        Debug.Log(nomeColetado);
        adicionaAoContainerDeColetados(nomeColetado);

        if (qtdColetados > nomesColetados.Length - 1)
        {
            if (isCombinacaoValida())
            {
                AudioController.current.PlayAudio(AudioController.current.combinacaoOk);
                resultadoSucesso.processarResultado(nomesColetados);
                adicionaPontuacao();
            }
            else
            {
                AudioController.current.PlayAudio(AudioController.current.combinacaoNok);
                resultadoFalha.processarResultado(nomesColetados);
            }
            resetarColetados();
        }

        score++;

    }

    public bool hasResetColetados()
    {
        return qtdColetados == 0;
    }

    private bool isCombinacaoValida()
    {
        string nomePrimeiroColetado = nomesColetados[0];
        for (int i = 0; i < nomesColetados.Length; i++)
        {
            if (!nomePrimeiroColetado.Equals(nomesColetados[i]))
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

    private void adicionaPontuacao()
    {
        score += 30;
    }

    public int getScore()
    {
        return score;
    }

    private void resetarColetados()
    {
        qtdColetados = 0;
    }
}
