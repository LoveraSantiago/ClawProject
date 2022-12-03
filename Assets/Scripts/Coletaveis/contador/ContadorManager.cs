public class ContadorManager 
{
    private AbstractContadorDeColetaveis contador;
    private ColetaveisDto coletaveisDto;

    public ContadorManager(ColetaveisDto coletaveisDto)
    {
        this.coletaveisDto = coletaveisDto;
    }

    public void configuradoPeloLevel()
    {
        int pontosColetados = coletaveisDto.PontosColetados;
        int pontosAcerto    = coletaveisDto.PontosAcerto;

        if (LevelUtils.isOrdemLevel())
        {
            contador = new ContadorOrdenado(pontosColetados, pontosAcerto);
        }
        else if (LevelUtils.isColetavelLevel())
        {
            contador = new ContadorColetavel(pontosColetados, pontosAcerto);
        }
        else
        {
            contador = new ContadorNormal(pontosColetados, pontosAcerto);
        }
        contador.configuradoPeloLevel();
    }

    public void iniciar(int totalColetaveis)
    {
        contador.iniciar(totalColetaveis);
    }

    public int contarColetado(Coletavel coletavel, SomColetagem somColetagem)
    {
        return contador.contarColetado(coletavel, somColetagem);
    }

    public void adicionarColetaveisExtras(int qtd)
    {
        contador.adicionarColetaveisExtras(qtd);
    }

    public void reajustarContagem(ColetadoFimDto evento, bool devolverBoard)
    {
        contador.reajustarContagem(evento, devolverBoard);
    }

    public bool getResultCombinacao()
    {
        return contador.getResultCombinacao();
    }

    public int getIndiceOrdem()
    {
        return contador.getIndiceOrdem();
    }

    public Coletavel[] getColetados()
    {
        return contador.getColetados();
    }

    public InformacoesFimDeJogoDto getInfoFimDeJogo()
    {
        return contador.getInfoFimDeJogo();
    }   

    public Fornecedor<TrocadorDeOrdem> getFornecedorTrocadorDeOrdem()
    {
        return contador;
    }

    public int getScore()
    {
        return contador.getScore();
    }

    public int getTotalDeColetaveis()
    {
        return contador.getTotalDeColetaveis();
    }    
}
