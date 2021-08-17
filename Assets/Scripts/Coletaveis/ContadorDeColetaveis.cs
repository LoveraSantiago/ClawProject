using UnityEngine;

public class ContadorDeColetaveis
{
    private int score = 0;    

    private int pontosColetado;
    private int pontosAcerto;
    
    private bool resultCombinacao;
    private int totalColetaveis;

    private ColetavelTile[] coletados;   
    private ColetavelTile[] arrayVazio;

    public ContadorDeColetaveis(int pontosColetado, int pontosAcerto)
    {
        this.pontosAcerto = pontosAcerto;
        this.pontosColetado = pontosColetado;
        coletados = new ColetavelTile[3];
        arrayVazio = new ColetavelTile[0];        
    }

    public void configurarTotalColetaveis(int total)
    {
        totalColetaveis = total;
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
                AudioController.current.PlayAudio(AudioController.current.combinacaoNok);
            }
            resetarColetados();
        }
        else
        {
            resultCombinacao = false;            
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
        score += pontosAcerto;        
        AudioController.current.PlayAudio(AudioController.current.combinacaoOk);
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
