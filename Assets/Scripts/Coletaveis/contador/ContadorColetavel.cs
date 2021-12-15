using UnityEngine;

public class ContadorColetavel : ContadorNormal
{
    private bool resultSucessoColetavel;
    private ColetavelEntidade coletavelEntidade;
    private TrincaColetaveisTiles trincaLevelColetaveis;    

    public ContadorColetavel(int pontosColetado, int pontosAcerto) 
        : base(pontosColetado, pontosAcerto){}

    public override void configuradoPeloLevel(AbstractLevel level)
    {
        coletavelEntidade = LevelUtils.getColetavelFromLevelColetavel(level);
    }

    public override void iniciar(int totalColetaveis)
    {
        base.iniciar(totalColetaveis);
        destacarColetaveis();
    }

    private void destacarColetaveis()
    {
        HelperColetaveisInGame helperInGame = new HelperColetaveisInGame();
        ColetavelTile[] coletaveis = helperInGame.getColetavelInGameDoTipo(coletavelEntidade);
        for(int contador = 0; contador < coletaveis.Length; contador++)
        {
            ColetavelTile coletavelIt = coletaveis[contador];
            Material materialOutline = MaterialOutline.of(coletavelIt.getSprite());
            coletavelIt.addMaterial(materialOutline);
            coletavelIt.colocarNoLayerDestaque();
        }

        trincaLevelColetaveis = new TrincaColetaveisTiles(coletaveis);
    }

    public override int contarColetado(ColetavelTile coletavelTile)
    {
        resultSucessoColetavel = false;
        int score = base.contarColetado(coletavelTile);

        if (resultCombinacao && trincaLevelColetaveis.isColetaveisNaTrinca(coletados))
        {
            resultSucessoColetavel = true;            
        }        
        return score;
    }    

    public override InformacoesFimDeJogoDto getInfoFimDeJogo()
    {
        if (resultSucessoColetavel)
        {
            return InformacoesFimDeJogoDto.ofTrinca();
        }
        else
        {
            return base.getInfoFimDeJogo();
        }
    }

    public override TrocadorDeOrdem fornecer()
    {
        return new TrocadorLevelColetavel(trincaLevelColetaveis);
    }
}
