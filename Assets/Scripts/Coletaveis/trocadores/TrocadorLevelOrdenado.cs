using UnityEngine;

public class TrocadorLevelOrdenado : TrocadorDeOrdem
{    
    private NavegacaoDeArray<BoardOrdem> navegacaoOrdem;

    public TrocadorLevelOrdenado(NavegacaoDeArray<BoardOrdem> navegacaoOrdem)
    {
        Debug.Log("Trocador ordenado chamado");
        this.navegacaoOrdem = navegacaoOrdem;
    }

    public void atualizar(ColetavelTile coletavelPrimeiro)
    {
        Debug.Log("Atualizado ordem");
        BoardOrdem ordemAtual = navegacaoOrdem.getItemIndiceAtual();
        if (ordemAtual.isNomeEquals(coletavelPrimeiro.nome))
        {
            destaqueOutline(coletavelPrimeiro);
            coletavelPrimeiro.colocarNoLayerDestaque();
        }
        else
        {
            destaqueGrayScale(coletavelPrimeiro);
            coletavelPrimeiro.colocarNoLayerComum();
        }
    }

    public void trocar(ColetavelTile coletavelPrimeiro, ColetavelTile coletavelSegundo)
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
            destaqueGrayScale(coletavelPrimeiro);
            destacarLayer(coletavelSegundo, coletavelPrimeiro);
        }
        else if (ordemSegundo.isOrdem(indiceNavegacao + 1))
        {
            trocarMaterial(coletavelSegundo, coletavelPrimeiro);
            destaqueGrayScale(coletavelSegundo);
            destacarLayer(coletavelPrimeiro, coletavelSegundo);
        }
        trocarNomes(ordemPrimeiro, ordemSegundo);
    }

    public void trocarFigura(ColetavelTile coletavelPrimeiro, ColetavelTile coletavelSegundo)
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
        destaqueOutline(coletavelSemMaterial);        
    }

    private void trocarSpriteMaterial(ColetavelTile coletavelComMaterial, Sprite spr)
    {        
        Material materialOutline = MaterialOutline.of(spr);
        coletavelComMaterial.addMaterial(materialOutline);
    }   

    private void destaqueGrayScale(ColetavelTile coletavel)
    {
        DestaqueGrayScale destaque = new DestaqueGrayScale();
        destaque.destacar(coletavel);
    }

    private void destaqueOutline(ColetavelTile coletavel)
    {
        Material materialOutline = MaterialOutline.of(coletavel.getSprite());
        coletavel.addMaterial(materialOutline);
    }

    private void destacarLayer(ColetavelTile coletavelDestaque, ColetavelTile coletavelDesfoque)
    {
        coletavelDestaque.colocarNoLayerDestaque();
        coletavelDesfoque.colocarNoLayerComum();
    }
}
