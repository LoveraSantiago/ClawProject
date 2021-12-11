using UnityEngine;

public class TrocadorLevelColetavel : TrocadorDeOrdem
{
    private TrincaColetaveisTiles trincaColetaveis;

    public TrocadorLevelColetavel(TrincaColetaveisTiles trincaColetaveis)
    {
        this.trincaColetaveis = trincaColetaveis;
    }

    public void atualizarOrdem(ColetavelTile coletavelPrimeiro)
    {
        Debug.Log("atualizar ordem chamado");
    }

    public void trocarFigura(ColetavelTile coletavelPrimeiro, ColetavelTile coletavelSegundo)
    {
        Debug.Log("trocar figura chamado");
        if (trincaColetaveis.isColetavelNaTrinca(coletavelPrimeiro))
        {

        }
        else
        {
            HelperColetaveisInGame helperInGame = new HelperColetaveisInGame();
            Material materialGrayScale = helperInGame.getMaterialGrayscaleTo(coletavelPrimeiro);
            coletavelPrimeiro.addMaterial(materialGrayScale);
            coletavelPrimeiro.colocarNoLayerComum();
        }
    }

    public void trocarOrdem(ColetavelTile coletavelPrimeiro, ColetavelTile coletavelSegundo)
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
}
