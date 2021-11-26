public class ContadorDeColetaveis
{
    public bool resultCombinacao { get; private set; }
    public bool isFinished { get { return totalColetaveis == 0; } }

    public int score { get; private set; }    
    private int pontosColetado;
    private int pontosAcerto;    
    private int totalColetaveis;

    public ColetavelTile[] coletados { get; private set; }

    public ContadorDeColetaveis(int pontosColetado, int pontosAcerto)
    {
        score = 0;
        this.pontosAcerto = pontosAcerto;
        this.pontosColetado = pontosColetado;
        coletados = new ColetavelTile[3];        
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
                resultCombinacao = true;
                score += pontosAcerto;
                AudioController.current.PlayAudio(AudioController.current.combinacaoOk);                
            }
            else
            {
                resultCombinacao = false;
                AudioController.current.PlayAudio(AudioController.current.combinacaoNok);
            }           
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

    public void reajustarContagem(ColetadoFim evento, bool devolverBoard)
    {
        if (!evento.isNormal)
        {
            int indice = evento.getPrimeiroIndiceParaLimpar();
            coletados[indice] = null;
            //Debug.Log("Reajuste de contagem no indice " + indice);
            if (evento.isRollback)
            {
                adicionarColetaveisExtras(1);
            }
        }
        else if (evento.isNormal && evento.isTodosColetados())
        {
            resetarColetados();
            if (devolverBoard && !resultCombinacao)
            {
                adicionarColetaveisExtras(3);
            }
        }
    }

    private bool isCombinacaoValida()
    {
        return coletados[0].hasEqualsSprite(coletados[1]) &&
               coletados[0].hasEqualsSprite(coletados[2]); 
    }        

    private void adicionaAoContainerDeColetados(ColetavelTile coletado)
    {
        int indice = getPrimeiroIndiceVazio();
        //Debug.Log("Indice contador de coletaveis " + indice);
        coletados[indice] = coletado;        
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
