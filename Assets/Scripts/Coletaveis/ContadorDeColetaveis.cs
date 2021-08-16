using UnityEngine;

public class ContadorDeColetaveis
{
    private int score = 0;    

    private int pontosColetado;
    private int pontosAcerto;

    private bool backToBoard;
    private bool resultCombinacao;
    private int totalColetaveis;

    private ColetavelTile[] coletados;
    private ColetavelTile[] devolverBoard;
    private ColetavelTile[] devolverTubo;
    private ColetavelTile[] arrayVazio;

    public ContadorDeColetaveis(int pontosColetado, int pontosAcerto)
    {
        this.pontosAcerto = pontosAcerto;
        this.pontosColetado = pontosColetado;
        coletados = new ColetavelTile[3];
        arrayVazio = new ColetavelTile[0];        
    }

    public void configurarTotalColetaveis(int total, bool backToBoard)
    {
        totalColetaveis = total;
        this.backToBoard = backToBoard;
        //Debug.Log("Total: " + totalColetaveis);
    }

    public void adicionarColetado(ColetavelTile coletado)
    {
        // Debug.Log(nomeColetado);
        adicionaAoContainerDeColetados(coletado);

        if (isTodasPosicoesOcupadas())
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

        score += pontosColetado;
    }

    public void adicionarColetaveisExtras(int qtd)
    {
        totalColetaveis += qtd;
        //Debug.Log("PosAdicionado Total: " + totalColetaveis);
    }

    public void subtrairColetavel()
    {
        totalColetaveis -= 1;
        //Debug.Log("Total: " + totalColetaveis);
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

    public void reajustarContagem(ColetadoFim evento)
    {
        if (evento.reajustarContador())
        {
            int indice = evento.getPrimeiroIndiceParaLimpar();
            coletados[indice] = null;
            Debug.Log("Reajuste de contagem no indice " + indice);
        }
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
        int indice = getPrimeiroIndiceVazio();
        coletados[indice] = coletado;        
    }

    private void processarRetornoValido()
    {
        AudioController.current.PlayAudio(AudioController.current.combinacaoOk);
        adicionaPontuacao();
        devolverBoard = arrayVazio;
        devolverTubo = coletados;        
    }

    private void processarRetornoInvalido()
    {
        if (backToBoard)
        {
            devolverBoard = coletados;
            devolverTubo = arrayVazio;
            AudioController.current.PlayAudio(AudioController.current.combinacaoNok);
        }
        else
        {
            devolverBoard = coletados;
            devolverTubo  = coletados;
        }
        AudioController.current.PlayAudio(AudioController.current.combinacaoNok);
    }

    private void adicionaPontuacao()
    {
        score += pontosAcerto;
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
        coletados[0] = null;
        coletados[1] = null;
        coletados[2] = null;
    }

    private int getPrimeiroIndiceVazio()
    {
        if (coletados[0] == null) return 0;
        if (coletados[1] == null) return 1;
        return 2;        
    }

    private bool isTodasPosicoesOcupadas()
    {
        return coletados[0] != null && coletados[1] != null && coletados[2] != null;
    }
}
