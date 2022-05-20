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

    protected override Coletavel criarColetavel(string nomeSprite, Vector3 posicao)
    {
        return HelperColetaveisInGame.criarColetavel(nomeSprite, posicao, goParent);
    }

    protected override IEnumerator onColetavelCriado(int posX, int posY, Coletavel coletavel)
    {
        coletavel.colocarNoOrderEscondido();
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
