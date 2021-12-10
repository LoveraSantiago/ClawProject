public class BoardMontadorExtra : BoardMontador
{
    private int contadorEixoX;
    private int contadorLinhaAtual;

    private DestaqueGrayScale destaque;

    private PoolList<ColetavelTile> poolExtraSubs;

    public override void configuradoPeloLevel(AbstractLevel level)
    {
        setArrayDeColetavel(LevelUtils.getArrayDeColetaveisLevelElevador(level));
        poolExtraSubs = new PoolList<ColetavelTile>();

        destaque = new DestaqueGrayScale(level);
    }

    protected override void create(BoardDto boardDto)
    {        
        float[] eixoX = getEixoX(boardDto, ++contadorEixoX);            
        montarLinha(eixoX, contadorLinhaAtual, boardDto.PosAlturaSub);
        incrementarContadorDeLinha();        
    }

    protected override void onColetavelCriado(ColetavelTile coletavel)
    {
        coletavel.colocarNoLayerElevador();        
        poolExtraSubs.addObjeto(coletavel);

        destaque.destacar(coletavel);
    }

    public override int getQtdAcrescentada()
    {
        return poolExtraSubs.getQtd();        
    }    

    private void incrementarContadorDeLinha()
    {
        if(getQtdItensDimensaoZero() - 1 <= contadorLinhaAtual)
        {
            contadorLinhaAtual = 0;
        }
        else
        {
            contadorLinhaAtual++;
        }        
    }
}
