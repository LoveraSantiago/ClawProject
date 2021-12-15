public abstract class AbstractContadorDeColetaveis : Fornecedor<TrocadorDeOrdem>
{
    public abstract void iniciar(int totalColetaveis);

    public virtual void configuradoPeloLevel(AbstractLevel level) {}

    public abstract int contarColetado(ColetavelTile coletavelTile);

    public abstract void adicionarColetaveisExtras(int qtd);

    public abstract void reajustarContagem(ColetadoFim evento, bool devolverBoard);

    public abstract bool getResultCombinacao();

    public abstract ColetavelTile[] getColetados();

    public virtual int getIndiceOrdem()
    {
        return 0;
    }

    public abstract InformacoesFimDeJogoDto getInfoFimDeJogo();

    public abstract TrocadorDeOrdem fornecer();
}
