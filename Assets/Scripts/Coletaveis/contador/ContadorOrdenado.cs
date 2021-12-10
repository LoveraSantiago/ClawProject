using UnityEngine;

public class ContadorOrdenado : ContadorNormal
{
    private bool resultErroOrdem;
    private NavegacaoDeArray<BoardOrdem> navegacaoOrdem;    

    public ContadorOrdenado(int pontosColetado, int pontosAcerto)
        :base(pontosColetado, pontosAcerto){}

    public override void configuradoPeloLevel(AbstractLevel level)
    {
        BoardOrdem[] ordens = LevelUtils.getBoardOrdensFromLevelOrdenado(level);
        navegacaoOrdem = new NavegacaoDeArray<BoardOrdem>(ordens, 0);
    }

    public override void iniciar(int totalColetaveis)
    {
        base.iniciar(totalColetaveis);
        indicarProximoColetavel();             
    }

    public override int contarColetado(ColetavelTile coletavelTile)
    {
        int score = base.contarColetado(coletavelTile);
        BoardOrdem ordemIt = navegacaoOrdem.getItemIndiceAtual();
        if (coletavelTile.nome.Equals(ordemIt.nome))
        {
            coletavelTile.clearMaterial();
            navegacaoOrdem.incrementar();
            indicarProximoColetavel();
            resultErroOrdem = false;            
        }
        else
        {
            resultErroOrdem = true;            
        }
        return score;
    }

    public override bool isErroOrdem()
    {
        return resultErroOrdem;
    }

    private void indicarProximoColetavel()
    {
        if (navegacaoOrdem.isIndiceAtualMenorQtdItensArray())
        {
            BoardOrdem ordemIt = navegacaoOrdem.getItemIndiceAtual();

            HelperColetaveisInGame helperInGame = new HelperColetaveisInGame();
            ColetavelTile coletavelTile = helperInGame.getColetavelInGameByGoName(ordemIt.nome);
                        
            Material materialOutline = MaterialOutline.of(coletavelTile.getSprite());
            coletavelTile.addMaterial(materialOutline);
            coletavelTile.colocarNoLayerDestaque();
        }
    }        

    public override int getIndiceOrdem()
    {
        return navegacaoOrdem.indiceAtual;
    }

    public override TrocadorDeOrdem fornecer()
    {
        return new TrocadorOrdenado(navegacaoOrdem);
    }
}
