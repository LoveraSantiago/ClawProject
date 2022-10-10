public abstract class AbstractContadorDeColetaveis : Fornecedor<TrocadorDeOrdem>
{
    public abstract void iniciar(int totalColetaveis);

    public virtual void configuradoPeloLevel(AbstractLevel level) {}

    public abstract int contarColetado(Coletavel coletavel);

    public abstract void adicionarColetaveisExtras(int qtd);

    public abstract void reajustarContagem(ColetadoFimDto evento, bool devolverBoard);

    public abstract bool getResultCombinacao();

    public abstract Coletavel[] getColetados();

    public virtual int getIndiceOrdem()
    {
        return 0;
    }

    public abstract int getScore();

    public abstract InformacoesFimDeJogoDto getInfoFimDeJogo();

    public abstract TrocadorDeOrdem fornecer();
}
