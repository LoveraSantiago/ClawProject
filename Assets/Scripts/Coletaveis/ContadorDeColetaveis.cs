using UnityEngine;

public class ContadorDeColetaveis
{
    private int score = 0;
    private int qtdColetados = 0;

    private bool backToBoard;
    private bool resultCombinacao;
    private int totalColetaveis;

    private ColetavelTile[] coletados;
    private ColetavelTile[] devolverBoard;
    private ColetavelTile[] devolverTubo;
    private ColetavelTile[] arrayVazio;

    public ContadorDeColetaveis()
    {
        coletados = new ColetavelTile[3];
        arrayVazio = new ColetavelTile[0];        
    }

    public void configurarTotalColetaveis(int total, bool backToBoard)
    {
        totalColetaveis = total;
        this.backToBoard = backToBoard;
        Debug.Log("Total: " + totalColetaveis);
    }

    public void adicionarColetado(ColetavelTile coletado)
    {
        // Debug.Log(nomeColetado);
        adicionaAoContainerDeColetados(coletado);

        if (qtdColetados > coletados.Length - 1)
        {
            if (isCombinacaoValida())
            {
                processarRetornoValido();
            }
            else
            {
                processarRetornoInvalido();
            }
            resetarColetados();
        }
        else
        {
            resultCombinacao = false;
            devolverBoard = arrayVazio;
            devolverTubo = arrayVazio;
        }

        score += 10;
    }

    public void adicionarColetaveisExtras(int qtd)
    {
        totalColetaveis += qtd;
        Debug.Log("PosAdicionado Total: " + totalColetaveis);
    }

    public ColetavelTile[] getArrayBoard()
    {
        return devolverBoard;
    }

    public ColetavelTile[] getArrayTubo()
    {
        return devolverTubo;
    }

    public bool getResult()
    {
        return resultCombinacao;
    }

    private bool isCombinacaoValida()
    {
        ColetavelTile primeiroColetado = coletados[0];
        for (int contador = 0; contador < coletados.Length; contador++)
        {
            if (!primeiroColetado.hasEqualsSprite(coletados[contador]))
            {
                resultCombinacao = false;
                return false;
            }
        }
        resultCombinacao = true;
        return true;
    }

    private void adicionaAoContainerDeColetados(ColetavelTile coletado)
    {
        coletados[qtdColetados] = coletado;
        qtdColetados++;
    }

    private void processarRetornoValido()
    {
        AudioController.current.PlayAudio(AudioController.current.combinacaoOk);
        adicionaPontuacao();
        devolverBoard = arrayVazio;
        devolverTubo = coletados;
        totalColetaveis -= 3;
    }

    private void processarRetornoInvalido()
    {
        if (backToBoard)
        {
            devolverBoard = coletados;
            devolverTubo = arrayVazio;
            AudioController.current.PlayAudio(AudioController.current.combinacaoNok);

            totalColetaveis -= 0;
        }
        else
        {
            devolverBoard = coletados;
            devolverTubo  = coletados;

            totalColetaveis -= 3;
        }
        AudioController.current.PlayAudio(AudioController.current.combinacaoNok);
    }

    private void adicionaPontuacao()
    {
        score += 90;
    }

    public int getScore()
    {
        return score;
    }

    public bool hasFinished()
    {
        return totalColetaveis == 0;
    }

    private void resetarColetados()
    {
        qtdColetados = 0;
    }
}
