using UnityEngine;

public class BoardMontadorExtra //TODO refatorar com BoardMontador
{
    private ColetavelEntidade.FAMILIA familia;

    private int[,] arrayDeColetaveisSub;

    private PoolList<ColetavelTile> poolExtraSubs;

    public void configuradoPeloLevel(AbstractLevel level)
    {
        familia = level.getFamiliaColetavel();
        arrayDeColetaveisSub = level.getArrayDeColetaveisSub();

        if (hasExtraSubColetaveis())
        {
            poolExtraSubs = new PoolList<ColetavelTile>();
        }
    }

    public void create(BoardDto boardDto, PoolDeColetaveis poolDeColetaveis)
    {
        if (hasExtraSubColetaveis())
        {
            ColetavelQuery coletavelQuery = new ColetavelQuery();

            float[] eixoX = getEixoX(boardDto, 0);
            for (int contadorColuna = 0; contadorColuna < eixoX.Length; contadorColuna++)
            {
                int id = arrayDeColetaveisSub[0, contadorColuna];
                ColetavelEntidade coletavelEntidade = coletavelQuery.getColetavelEntidadeById(id);

                if (coletavelEntidade.isVazio())//SE FOR VAZIO VAI PARA A PROXIMA ITERACAO
                {
                    continue;
                }
                else if (coletavelEntidade.isRandom())//SE FOR RANDOMICO SORTEIA UM COLETAVEL ENTIDADE POR FAMILIA
                {
                    coletavelEntidade = coletavelQuery.getColetavelEntidadeByFamilia(familia);
                }

                Vector3 posicao = new Vector3(eixoX[contadorColuna], boardDto.PosAlturaSub, 0);
                ColetavelTile coletavel = poolDeColetaveis.criarColetavel();
                coletavel.colocarNoLayerElevador();
                coletavel.ligar();
                coletavel.receberSprite(coletavelEntidade.nomeSprite);
                coletavel.colocarNaPosicao(posicao);
                poolExtraSubs.addObjeto(coletavel);

                //Debug.Log("Criando coletavel extra: " + coletavel.nome + " pos: " + coletavel.getPosicao());
            }
        }
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
        return arrayDeColetaveisSub != null;
    }

    private float[] getEixoX(BoardDto boardDto, int indice)
    {
        if (indice % 2 == 0)
        {
            return boardDto.PosicoesEixoXPar;
        }
        else
        {
            return boardDto.PosicoesEixoXImpar;
        }
    }
}
