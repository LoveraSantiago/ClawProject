using UnityEngine;

public class ContadorOrdenadoDeColetaveis : TrocadorDeOrdem
{
    public int contador { get; private set; }
    private BoardOrdem[] ordem;
    private Material materialOutline;

    public ContadorOrdenadoDeColetaveis(Material materialOutline)
    {
        contador = 0;
        this.materialOutline = new Material(materialOutline);        
    }

    public void configuradoPeloLevel(AbstractLevel level)
    {
        if (level.isOrdemLevel())
        {
            ordem = level.getBoardOrdem();            
        }
    }

    public void iniciar(PoolDeColetaveis poolDeColetaveis)
    {
        if(isLevelOrdem())
        {
            indicarProximoColetavel(poolDeColetaveis);
        }
    }

    public bool contarOrdem(ColetavelTile coletavelTile, PoolDeColetaveis poolDeColetaveis)
    {
        if (isLevelOrdem())
        {
            BoardOrdem ordemIt = ordem[contador];
            if (coletavelTile.nome.Equals(ordemIt.nome))
            {
                coletavelTile.clearMaterial();
                contador++;
                indicarProximoColetavel(poolDeColetaveis);
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            return false;
        }
    }
       
    public void indicarProximoColetavel(PoolDeColetaveis poolDeColetaveis)
    {
        if(contador < ordem.Length)
        {
            BoardOrdem ordemIt = ordem[contador];
            ColetavelTile coletavelTile = poolDeColetaveis.getColetavelPeloNome(ordemIt.nome);
            materialOutline.SetTexture("_MaintText", coletavelTile.getSprite().texture);
            coletavelTile.addMaterial(materialOutline);
        }
    }

    private bool isLevelOrdem()
    {
        return ordem != null;
    }

    public void trocarOrdem(ColetavelTile coletavelPrimeiro, ColetavelTile coletavelSegundo)
    {
        if (isLevelOrdem())
        {
            BoardOrdem ordemPrimeiro = null;
            BoardOrdem ordemSegundo = null;            
            
            for(int contadorAtual = contador; contadorAtual < ordem.Length; contadorAtual++)
            {
                BoardOrdem ordemIt = ordem[contadorAtual];
                if (ordemIt.nome.Equals(coletavelPrimeiro.nome))
                {
                    ordemPrimeiro = ordemIt;
                }
                else if (ordemIt.nome.Equals(coletavelSegundo.nome))
                {
                    ordemSegundo = ordemIt;
                }

                if(ordemPrimeiro != null && ordemSegundo != null)
                {
                    break;
                }
            }

            if(ordemPrimeiro.ordem == contador + 1)
            {
                trocarMaterial(coletavelPrimeiro, coletavelSegundo);
            }
            else if(ordemSegundo.ordem == contador + 1)
            {
                trocarMaterial(coletavelSegundo, coletavelPrimeiro);
            }
            trocarNomes(ordemPrimeiro, ordemSegundo);
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
}
