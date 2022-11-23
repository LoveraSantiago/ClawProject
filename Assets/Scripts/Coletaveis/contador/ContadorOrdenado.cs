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

    public override int contarColetado(Coletavel coletavel, SomColetagem somColetagem)
    {
        int score = base.contarColetado(coletavel, somColetagem);
        BoardOrdem ordemIt = navegacaoOrdem.getItemIndiceAtual();
        if (coletavel.nome.Equals(ordemIt.nome))
        {
            coletavel.clearMaterial();
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

    public override InformacoesFimDeJogoDto getInfoFimDeJogo()
    {
        if (resultErroOrdem)
        {
            return InformacoesFimDeJogoDto.ofErroOrdem();
        }
        else
        {
            return base.getInfoFimDeJogo();
        }
    }    

    private void indicarProximoColetavel()
    {
        if (navegacaoOrdem.isIndiceAtualMenorQtdItensArray())
        {
            BoardOrdem ordemIt = navegacaoOrdem.getItemIndiceAtual();
            
            Coletavel coletavelTile = HelperColetaveisInGame.getColetavelInGameByGoName(ordemIt.nome);
                        
            Material materialOutline = MaterialOutline.of(coletavelTile.getSprite());
            coletavelTile.addMaterial(materialOutline);
            coletavelTile.colocarNoOrderDestaque();
        }
    }        

    public override int getIndiceOrdem()
    {
        return navegacaoOrdem.indiceAtual;
    }

    public override TrocadorDeOrdem fornecer()
    {
        return new TrocadorLevelOrdenado(navegacaoOrdem);
    }
}
