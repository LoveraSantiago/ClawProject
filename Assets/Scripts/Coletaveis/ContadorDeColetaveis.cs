using UnityEngine;
using UnityEngine.SceneManagement;

public class ContadorDeColetaveis
{
    private int score = 0;
    private int qtdColetados = 0;
    private string[] nomesColetados;
    private string[] arrayBoard;
    private string[] arrayTubo;
    private int totalColetaveis;

    public ContadorDeColetaveis(int totalColetaveis)
    {
        nomesColetados = new string[3];
        this.totalColetaveis = totalColetaveis;
    }

    public void adicionarColetado(string nomeColetado)
    {
       // Debug.Log(nomeColetado);
        adicionaAoContainerDeColetados(nomeColetado);

        if (qtdColetados > nomesColetados.Length - 1)
        {
            if (isCombinacaoValida())
            {
                AudioController.current.PlayAudio(AudioController.current.combinacaoOk);
                adicionaPontuacao();
                arrayBoard = new string[0];
                arrayTubo = nomesColetados;
                totalColetaveis -= 3;               
            }
            else
            {
                arrayBoard = nomesColetados;
                arrayTubo = new string[0];
                AudioController.current.PlayAudio(AudioController.current.combinacaoNok);

                totalColetaveis -= 3;
            }
            resetarColetados();
        }
        else
        {
            arrayBoard = new string[0];
            arrayTubo = new string[0];
        }

        score++;

        if (totalColetaveis <= 0)
        {
            resetCena();
        }
    }

    public string[] getArrayBoard()
    {
        return arrayBoard;
    }

    public string[] getArrayTubo()
    {
        return arrayTubo;
    }

    public void resetCena()
    {
        SceneManager.LoadScene("MapScene");
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
