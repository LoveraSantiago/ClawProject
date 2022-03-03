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
        montarGaiola(posX, posY, posicao, null);
    }

    protected override void onColetavelCriado(int posX, int posY, Coletavel coletavel)
    {
        base.onColetavelCriado(posX, posY, coletavel);
        montarGaiola(posX, posY, coletavel.getPosicao(), coletavel.nome);
        coletavel.naoInteracaoComOutrosColetaveis();
    }

    private void montarGaiola(int posX, int posY, Vector3 posicao, string nomeColetado)
    {
        bool temGaiola = obstaculos[posY, posX];
        if (temGaiola)
        {
            Gaiola gaiola = new Gaiola();
            gaiola.colocarNaPosicao(posicao);
            gaiola.aprisionarColetavel(nomeColetado);
        }
    }
}
