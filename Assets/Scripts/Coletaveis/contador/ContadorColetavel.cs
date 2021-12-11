using UnityEngine;

public class ContadorColetavel : ContadorNormal
{
    private ColetavelEntidade coletavelEntidade;

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
    }

    public override int contarColetado(ColetavelTile coletavelTile)
    {
        return base.contarColetado(coletavelTile);        
    }
}
