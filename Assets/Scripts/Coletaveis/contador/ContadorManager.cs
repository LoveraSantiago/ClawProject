public class ContadorManager 
{
    private AbstractContadorDeColetaveis contador;
    private ColetaveisDto coletaveisDto;

    public ContadorManager(ColetaveisDto coletaveisDto)
    {
        this.coletaveisDto = coletaveisDto;
    }

    public void configuradoPeloLevel(AbstractLevel level)
    {
        int pontosColetados = coletaveisDto.PontosColetados;
        int pontosAcerto    = coletaveisDto.PontosAcerto;

        if (LevelUtils.isOrdemLevel(level))
        {
            contador = new ContadorOrdenado(pontosColetados, pontosAcerto);
        }
        else if (LevelUtils.isColetavelLevel(level))
        {
            contador = new ContadorColetavel(pontosColetados, pontosAcerto);
        }
        else
        {
            contador = new ContadorNormal(pontosColetados, pontosAcerto);
        }
        contador.configuradoPeloLevel(level);
    }

    public void iniciar(int totalColetaveis)
    {
        contador.iniciar(totalColetaveis);
    }

    public int contarColetado(Coletavel coletavel)
    {
        return contador.contarColetado(coletavel);
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
}
