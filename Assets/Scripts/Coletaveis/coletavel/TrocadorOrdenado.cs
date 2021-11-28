using UnityEngine;

public class TrocadorOrdenado : TrocadorDeOrdem
{
    private static readonly string PROP_MAINTTEXT = "_MaintText";
    NavegacaoDeArray<BoardOrdem> navegacaoOrdem;

    public TrocadorOrdenado(NavegacaoDeArray<BoardOrdem> navegacaoOrdem)
    {
        this.navegacaoOrdem = navegacaoOrdem;
    }

    public void trocarFigura(ColetavelTile coletavelPrimeiro, ColetavelTile coletavelSegundo)
    {
        BoardOrdem ordemPrimeiro = null;
        BoardOrdem ordemSegundo = null;

        int indiceNavegacao = navegacaoOrdem.indiceAtual;
        int tamanhoArray = navegacaoOrdem.getTamanhoArray();
        for (int contador = indiceNavegacao; contador < tamanhoArray; contador++)
        {
            BoardOrdem ordemIt = navegacaoOrdem.getItemDoIndice(contador);
            if (ordemIt.isNomeEquals(coletavelPrimeiro.nome))
            {
                ordemPrimeiro = ordemIt;
            }
            else if (ordemIt.isNomeEquals(coletavelSegundo.nome))
            {
                ordemSegundo = ordemIt;
            }

            if (ordemPrimeiro != null && ordemSegundo != null)
            {
                break;
            }
        }

        if (ordemPrimeiro.isOrdem(indiceNavegacao + 1))
        {
            trocarMaterial(coletavelPrimeiro, coletavelSegundo);
        }
        else if (ordemSegundo.isOrdem(indiceNavegacao + 1))
        {
            trocarMaterial(coletavelSegundo, coletavelPrimeiro);
        }
        trocarNomes(ordemPrimeiro, ordemSegundo);
    }

    public void trocarOrdem(ColetavelTile coletavelPrimeiro, ColetavelTile coletavelSegundo)
    {
        int indiceNavegacao = navegacaoOrdem.indiceAtual;
        int tamanhoArray = navegacaoOrdem.getTamanhoArray();
        for (int contador = indiceNavegacao; contador < tamanhoArray; contador++)
        {
            BoardOrdem ordemIt = navegacaoOrdem.getItemDoIndice(contador);
            if (ordemIt.nome.Equals(coletavelPrimeiro.nome))
            {
                if (ordemIt.isOrdem(indiceNavegacao + 1))
                {
                    trocarSpriteMaterial(coletavelPrimeiro, coletavelSegundo.getSprite());
                }
                break;
            }
        }
    }

    private void trocarNomes(BoardOrdem ordemPrimeiro, BoardOrdem ordemSegundo)
    {
        string nomeTemp = ordemPrimeiro.nome;
        ordemPrimeiro.trocarNome(ordemSegundo.nome);
        ordemSegundo.trocarNome(nomeTemp);
    }

    private void trocarMaterial(ColetavelTile coletavelComMaterial, ColetavelTile coletavelSemMaterial)
    {
        Debug.Log("Troca de material acionada");
        coletavelComMaterial.clearMaterial();
        coletavelSemMaterial.addMaterial(materialOutline);
    }

    private void trocarSpriteMaterial(ColetavelTile coletavelComMaterial, Sprite spr)
    {
        materialOutline.SetTexture(PROP_MAINTTEXT, spr.texture);
        coletavelComMaterial.addMaterial(materialOutline);
    }

}
