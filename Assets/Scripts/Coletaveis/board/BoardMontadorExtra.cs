using UnityEngine;

public class BoardMontadorExtra : BoardMontador
{
    private int contadorEixoX;
    private int contadorLinhaAtual;

    private PoolList<ColetavelTile> poolExtraSubs;

    public void configuradoPeloLevel(AbstractLevel level)
    {
        arrayDeColetaveis = level.getArrayDeColetaveisSub();

        if (hasExtraSubColetaveis())
        {
            poolExtraSubs = new PoolList<ColetavelTile>();
        }
    }

    public void create(BoardDto boardDto, PoolDeColetaveis poolDeColetaveis)
    {
        if (hasExtraSubColetaveis())
        {            
            float[] eixoX = getEixoX(boardDto, ++contadorEixoX);            
            montarLinha(eixoX, contadorLinhaAtual, boardDto.PosAlturaSub, poolDeColetaveis);
            incrementarContadorDeLinha();
        }
    }

    protected override void onColetavelCriado(ColetavelTile coletavel)
    {
        coletavel.colocarNoLayerElevador();        
        poolExtraSubs.addObjeto(coletavel);
    }

    public void ativarColetaveisSub()
    {        
        while (poolExtraSubs.hasObjeto())
        {
            ColetavelTile coletavel = poolExtraSubs.getObjeto();
            coletavel.colocarNoLayerNormal();            
        }
        poolExtraSubs.reclicarPool();     
    }

    public int getQtdExtras()
    {
        return poolExtraSubs.getQtd();
    }

    private bool hasExtraSubColetaveis()
    {
        return arrayDeColetaveis != null;
    }

    private void incrementarContadorDeLinha()
    {
        if(arrayDeColetaveis.GetLength(0) - 1 <= contadorLinhaAtual)
        {
            contadorLinhaAtual = 0;
        }
        else
        {
            contadorLinhaAtual++;
        }        
    }
}
