using System.Collections;
using UnityEngine;

public class BoardMontadorExtra : BoardMontador
{
    private int contadorEixoX;
    private int contadorLinhaAtual;

    private GameObject goParent;
    private PoolList<Coletavel> poolExtraSubs;

    public BoardMontadorExtra(GameObject goParent)
    {
        this.goParent = goParent;
    }

    public override void configuradoPeloLevel()
    {
        setArrayDeColetavel(LevelUtils.getArrayDeColetaveisLevelElevador());
        poolExtraSubs = new PoolList<Coletavel>();
    }

    protected override IEnumerator create(BoardDto boardDto)
    {        
        PosicaoItensDoBoardDto posItem = getPosicaoItem(boardDto, ++contadorEixoX);
        float alturaY = boardDto.PosAlturaSub;
        yield return montarLinha(posItem, contadorLinhaAtual, alturaY);

        incrementarContadorDeLinha();        
    }

    protected override Coletavel criarColetavel(Sprite sprite, Vector3 posicao)
    {
        return HelperColetaveisInGame.criarColetavel(sprite, posicao, goParent);
    }

    protected override IEnumerator onColetavelCriado(int posX, int posY, Coletavel coletavel)
    {
        coletavel.colocarNoOrderEscondido();
        coletavel.colocarNoLayerElevador();
        coletavel.fixarEixoXY();
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
