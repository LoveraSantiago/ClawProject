using System.Collections;
using UnityEngine;

public class BoardManager 
{   
    private BoardDto boardDto;

    private BoardDevolvedor devolvedor;
    private BoardMontadorNormal montador;
    private BoardMontadorExtra montadorExtra;    

    public BoardManager(BoardDto boardDto)
    {
        this.boardDto = boardDto;
        devolvedor    = new BoardDevolvedor();
        montador      = new BoardMontadorNormal();
        montadorExtra = new BoardMontadorExtra();
    }

    public void configuradoPeloLevel(AbstractLevel level)//TODO CRIAR INTERFACE PADRONIZAR CONFIGURADOS PELO LEVEL ALEM DE ADICIONAR SEMANTICA
    {
        BoardMontador.configurar(level.getFamiliaColetavel());
        montador.configuradoPeloLevel(level);
        montador.validacaoArray(boardDto.PosicoesEixoY.Length, boardDto.PosicoesEixoXPar.Length);

        montadorExtra.configuradoPeloLevel(level);
        devolvedor.configuradoPeloLevel(level.devolverParaBoard());        
    }

    public int create(PoolDeColetaveis poolDeColetaveis)
    {
        int qtdColetaveisCriados = montador.create(boardDto, poolDeColetaveis);
        montadorExtra.create(boardDto, poolDeColetaveis);
        return qtdColetaveisCriados;
    }   

    public int subirBoard(PoolDeColetaveis poolDeColetaveis, MonoBehaviour monoBehaviour)
    {
        int qtdColetaveis = montadorExtra.getQtdExtras();
        monoBehaviour.StartCoroutine(subirBoard(poolDeColetaveis));
        return qtdColetaveis;
    }       

    public void devolver(ColetavelTile[] coletados, MonoBehaviour monoBehaviour)
    {
        devolvedor.devolver(boardDto, coletados, monoBehaviour);
    }

    private IEnumerator subirBoard(PoolDeColetaveis poolDeColetaveis)
    {
        float limite = boardDto.BoardPosicao.position.y + boardDto.Subida;
        Vector3 posInicialParedeAlta  = boardDto.ParedeAlta.position;
        Vector3 posInicialParedeBaixa = boardDto.ParedeBaixa.position;
        poolDeColetaveis.executeEmTodosColetaveis(new FixadorEixosXY());

        while (boardDto.BoardPosicao.position.y < limite)
        {
            boardDto.BoardPosicao.position += new Vector3(0, boardDto.VelocidadeSubida * Time.fixedDeltaTime, 0);
            yield return new WaitForFixedUpdate();
        }

        boardDto.ParedeAlta.position  = posInicialParedeAlta;
        boardDto.ParedeBaixa.position = posInicialParedeBaixa;        

        poolDeColetaveis.executeEmTodosColetaveis(new DesafixadorEixosXY());
        montadorExtra.create(boardDto, poolDeColetaveis);
        
        yield return null;
    }
}
