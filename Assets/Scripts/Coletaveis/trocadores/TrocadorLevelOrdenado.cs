using UnityEngine;

public class TrocadorLevelOrdenado : TrocadorDeOrdem
{    
    private NavegacaoDeArray<BoardOrdem> navegacaoOrdem;

    public TrocadorLevelOrdenado(NavegacaoDeArray<BoardOrdem> navegacaoOrdem)
    {
        //Debug.Log("Trocador ordenado chamado");
        this.navegacaoOrdem = navegacaoOrdem;
    }

    public override void atualizar(ColetavelTile coletavel)
    {
        //Debug.Log("Atualizado ordem");
        BoardOrdem ordemAtual = navegacaoOrdem.getItemIndiceAtual();
        if (ordemAtual.isNomeEquals(coletavel.nome))
        {
            addMaterialOutline(coletavel);            
        }
        else
        {
            addMaterialGrayScale(coletavel);            
        }
    }

    public override void trocar(ColetavelTile coletavel1, ColetavelTile coletavel2)
    {
        BoardOrdem ordemPrimeiro = null;
        BoardOrdem ordemSegundo = null;

        int indiceNavegacao = navegacaoOrdem.indiceAtual;
        int tamanhoArray = navegacaoOrdem.getTamanhoArray();
        for (int contador = indiceNavegacao; contador < tamanhoArray; contador++)
        {
            BoardOrdem ordemIt = navegacaoOrdem.getItemDoIndice(contador);
            if (ordemIt.isNomeEquals(coletavel1.nome))
            {
                ordemPrimeiro = ordemIt;
            }
            else if (ordemIt.isNomeEquals(coletavel2.nome))
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
            trocarMaterial(coletavel1, coletavel2);
            addMaterialGrayScale(coletavel1);            
        }
        else if (ordemSegundo.isOrdem(indiceNavegacao + 1))
        {
            trocarMaterial(coletavel2, coletavel1);
            addMaterialGrayScale(coletavel2);            
        }
        trocarNomes(ordemPrimeiro, ordemSegundo);
    }

    public override void trocarFigura(ColetavelTile coletavel1, ColetavelTile coletavel2)
    {
        int indiceNavegacao = navegacaoOrdem.indiceAtual;
        int tamanhoArray = navegacaoOrdem.getTamanhoArray();
        for (int contador = indiceNavegacao; contador < tamanhoArray; contador++)
        {
            BoardOrdem ordemIt = navegacaoOrdem.getItemDoIndice(contador);
            if (ordemIt.nome.Equals(coletavel1.nome))
            {
                if (ordemIt.isOrdem(indiceNavegacao + 1))
                {
                    trocarSpriteMaterial(coletavel1, coletavel2.getSprite());
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
        //Debug.Log("Troca de material acionada");
        coletavelComMaterial.clearMaterial();
        addMaterialOutline(coletavelSemMaterial);                
    }

    private void trocarSpriteMaterial(ColetavelTile coletavelComMaterial, Sprite spr)
    {        
        Material materialOutline = MaterialOutline.of(spr);
        coletavelComMaterial.addMaterial(materialOutline);
    }
}
