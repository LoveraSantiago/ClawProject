using UnityEngine;

public class BoardMontadorObstaculos : BoardMontadorNormal
{
    private bool[,] obstaculos;

    public override void configuradoPeloLevel(AbstractLevel level)
    {
        base.configuradoPeloLevel(level);
        obstaculos = LevelUtils.getArrayDeObstaculos(level);
    }

    protected override PosicaoItensDoBoardDto getPosYITem(BoardDto boardDto)
    {
        return boardDto.PosicoesYObstaculos;
    }

    protected override PosicaoItensDoBoardDto getPosicaoItem(BoardDto boardDto, int indice)
    {
        return boardDto.PosicoesXPares;        
    }

    protected override void onPosicaoVaziaCriado(int posX, int posY, Vector3 posicao)
    {
        montarGaiola(posX, posY, posicao);
    }

    protected override void onColetavelCriado(int posX, int posY, Coletavel coletavel)
    {
        base.onColetavelCriado(posX, posY, coletavel);
        montarGaiola(posX, posY, coletavel);        
    }

    private void montarGaiola(int posX, int posY, Vector3 posicao)
    {
        bool temGaiola = obstaculos[posY, posX];
        if (temGaiola)
        {
            Gaiola gaiola = criarGaiola();
            gaiola.colocarNaPosicao(posicao);            
        }
    }

    private void montarGaiola(int posX, int posY, Coletavel coletavel)
    {
        bool temGaiola = obstaculos[posY, posX];
        if (temGaiola)
        {
            Gaiola gaiola = criarGaiola();
            gaiola.colocarNaPosicao(coletavel.getPosicao());
            coletavel.preso();
            Debug.Log("Gaiola " + gaiola.nome + " Coletavel " + coletavel.nome);
        }
    }

    private Gaiola criarGaiola()
    {
        HelperGaiolasInGame helperGaiolas = new HelperGaiolasInGame();
        Gaiola gaiola = helperGaiolas.criarGaiola();
        return gaiola;
    }
}
