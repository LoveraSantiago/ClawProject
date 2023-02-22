using UnityEngine;
using System.Collections;

public class BoardMontadorObstaculos : BoardMontadorNormal
{
    private bool[,] obstaculos;

    public override void configuradoPeloLevel()
    {
        base.configuradoPeloLevel();
        obstaculos = LevelUtils.getArrayDeObstaculos();
    }

    protected override PosicaoItensDoBoardDto getPosYITem(BoardDto boardDto)
    {
        return boardDto.PosicoesYObstaculos;
    }

    protected override PosicaoItensDoBoardDto getPosicaoItem(BoardDto boardDto, int indice)
    {
        return boardDto.PosicoesXPares;        
    }

    protected override IEnumerator onPosicaoVaziaCriado(int posX, int posY, Vector3 posicao)
    {
        yield return montarGaiola(posX, posY, posicao);
    }

    protected override IEnumerator onColetavelCriado(int posX, int posY, Coletavel coletavel)
    {   
        yield return montarGaiola(posX, posY, coletavel);        
    }

    private IEnumerator montarGaiola(int posX, int posY, Vector3 posicao)
    {
        bool temGaiola = obstaculos[posY, posX];
        if (temGaiola)
        {
            Gaiola gaiola = criarGaiola();
            gaiola.colocarNaPosicao(posicao);
            yield return new WaitForSeconds(getDelay());
        }       
    }

    private IEnumerator montarGaiola(int posX, int posY, Coletavel coletavel)
    {
        bool temGaiola = obstaculos[posY, posX];
        if (temGaiola)
        {
            Gaiola gaiola = criarGaiola();
            gaiola.colocarNaPosicao(coletavel.getPosicao());
            gaiola.aprisionarColetavel(coletavel.nome);
            coletavel.preso(gaiola.nome);
            //Debug.Log("Gaiola " + gaiola.nome + " Coletavel " + coletavel.nome);
            yield return new WaitForSeconds(getDelay());
        }       
    }

    private Gaiola criarGaiola()
    {
        HelperGaiolasInGame helperGaiolas = new HelperGaiolasInGame();
        Gaiola gaiola = helperGaiolas.criarGaiola();
        gaiola.ligarComEstado();
        return gaiola;
    }
}
