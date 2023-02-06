public class ContadorNormal : AbstractContadorDeColetaveis
{
    protected bool resultCombinacao;

    private int score;
    private int pontosColetado;
    private int pontosAcerto;    
    private int totalColetaveis;

    protected Coletavel[] coletados;

    public ContadorNormal(int pontosColetado, int pontosAcerto)
    {
        score = 0;
        this.pontosAcerto   = pontosAcerto;
        this.pontosColetado = pontosColetado;
        coletados = new Coletavel[3];        
    }

    public override void configuradoPeloLevel()
    {
        if (LevelUtils.isTutorialLevel())
        {
            Coletavel[] coletados = LevelUtils.getColetaveisColetados();
            for(int contador = 0; contador < coletados.Length; contador++)
            {
                contarColetado(coletados[contador], null); 
            }
        }
    }


    public override void iniciar(int totalColetaveis)
    {
        this.totalColetaveis = totalColetaveis;        
    }

    public override int contarColetado(Coletavel coletavel, SomColetagem somColetagem)
    {
        // Debug.Log(nomeColetado);
        subtrairColetavel();
        adicionaAoContainerDeColetados(coletavel);
        TrincaColetaveisTiles trinca = new TrincaColetaveisTiles(coletados);
        if (trinca.isTodasPosicoesOcupadas())
        {
            if (trinca.isCombinacaoValida())
            {
                if(somColetagem != null)
                {
                    somColetagem.playScoreColetagemSucesso();
                }
                resultCombinacao = true;
                score += pontosAcerto;                
            }
            else
            {
                if(somColetagem != null)
                {
                    somColetagem.playScoreColetagemNaoSucesso();
                }
                resultCombinacao = false;                
            }           
        }
        else
        {
            resultCombinacao = false;            
        }
        score += pontosColetado;
        return score;
    }    

    public override void adicionarColetaveisExtras(int qtd)
    {
        totalColetaveis += qtd;
        //Debug.Log("PosAdicionado Total: " + totalColetaveis);
    } 

    public override void reajustarContagem(ColetadoFimDto evento, bool devolverBoard)
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
            TrincaColetaveisTiles trinca = new TrincaColetaveisTiles(coletados);
            coletados = trinca.resetarColetados();
            if (devolverBoard && !resultCombinacao)
            {
                adicionarColetaveisExtras(3);
            }
        }
    }

    public override bool getResultCombinacao()
    {
        return resultCombinacao;
    }

    public override Coletavel[] getColetados()
    {
        return coletados;
    }    

    public override InformacoesFimDeJogoDto getInfoFimDeJogo()
    {
        return InformacoesFimDeJogoDto.ofFimColetados(isZeroTotalColetaveis());
    }

    public override TrocadorDeOrdem fornecer()
    {
        return new TrocadorDeOrdemVazio();
    }

    public override int getScore()
    {
        return score;
    }

    public override int getTotalDeColetaveis()
    {
        return totalColetaveis;
    }

    protected bool isZeroTotalColetaveis()
    {
        return totalColetaveis == 0;
    }

    private void subtrairColetavel()
    {
        totalColetaveis -= 1;
        //Debug.Log("Total: " + totalColetaveis);
    }

    private void adicionaAoContainerDeColetados(Coletavel coletado)
    {
        TrincaColetaveisTiles trinca = new TrincaColetaveisTiles(coletados);
        int indice = trinca.getPrimeiroIndiceVazio();
        //Debug.Log("Indice contador de coletaveis " + indice);
        coletados[indice] = coletado;        
    }

}
