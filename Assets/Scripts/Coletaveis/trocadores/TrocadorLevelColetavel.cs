using UnityEngine;

public class TrocadorLevelColetavel : TrocadorDeOrdem
{
    private TrincaColetaveisTiles trincaColetaveis;

    public TrocadorLevelColetavel(TrincaColetaveisTiles trincaColetaveis)
    {
        this.trincaColetaveis = trincaColetaveis;
    }

    public override void atualizar(ColetavelTile coletavelPrimeiro)
    {
        Debug.Log("atualizar ordem chamado");
        if (trincaColetaveis.isColetavelNaTrinca(coletavelPrimeiro))
        {

        }
        else
        {
            colocarMaterialGrayscaleDeVolta(coletavelPrimeiro);
        }
    }

    public override void trocarFigura(ColetavelTile coletavelPrimeiro, ColetavelTile coletavelSegundo)
    {
        Debug.Log("trocar figura chamado");
        if (trincaColetaveis.isColetavelNaTrinca(coletavelPrimeiro) &&
            trincaColetaveis.isColetavelNaTrinca(coletavelSegundo))
        {
            Material materialOutline = MaterialOutline.of(coletavelPrimeiro.getSprite());
            coletavelPrimeiro.addMaterial(materialOutline);
        }
        else
        {
            colocarMaterialGrayscaleDeVolta(coletavelPrimeiro);
        }
    }

    public override void trocar(ColetavelTile coletavelPrimeiro, ColetavelTile coletavelSegundo)
    {
        Debug.Log("trocar ordem chamado");
        if (trincaColetaveis.isColetavelNaTrinca(coletavelPrimeiro))
        {

        }
        else if (trincaColetaveis.isColetavelNaTrinca(coletavelSegundo))
        {

        }
        else
        {
            //HelperColetaveisInGame helperInGame = new HelperColetaveisInGame();
            //Material materialGrayScale = helperInGame.getMaterialGrayscaleTo(coletavelPrimeiro);
            //coletavelPrimeiro.addMaterial(materialGrayScale);
            //coletavelPrimeiro.colocarNoLayerComum();
        }

    }   

    private void colocarMaterialGrayscaleDeVolta(ColetavelTile coletavel)
    {
        HelperColetaveisInGame helperInGame = new HelperColetaveisInGame();
        Material materialGrayScale = helperInGame.getMaterialGrayscaleTo(coletavel);
        coletavel.addMaterial(materialGrayScale);
        coletavel.colocarNoLayerComum();
    }
}
