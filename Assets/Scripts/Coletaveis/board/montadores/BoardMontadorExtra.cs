using System.Collections;

public class BoardMontadorExtra : BoardMontador
{
    private int contadorEixoX;
    private int contadorLinhaAtual;    

    private PoolList<Coletavel> poolExtraSubs;

    public override void configuradoPeloLevel(AbstractLevel level)
    {
        setArrayDeColetavel(LevelUtils.getArrayDeColetaveisLevelElevador(level));
        poolExtraSubs = new PoolList<Coletavel>();
    }

    protected override IEnumerator create(BoardDto boardDto)
    {        
        PosicaoItensDoBoardDto posItem = getPosicaoItem(boardDto, ++contadorEixoX);
        float alturaY = boardDto.PosAlturaSub;
        yield return montarLinha(posItem, contadorLinhaAtual, alturaY);

        incrementarContadorDeLinha();        
    }

    protected override IEnumerator onColetavelCriado(int posX, int posY, Coletavel coletavel)
    {
        coletavel.colocarNoLayerElevador();        
        poolExtraSubs.addObjeto(coletavel);        
        yield return null;
    }

    public override int getQtdAcrescentada()
    {
        int qtdAnterior = poolExtraSubs.getQtd();
        poolExtraSubs.reclicarPool();
        return qtdAnterior;
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
