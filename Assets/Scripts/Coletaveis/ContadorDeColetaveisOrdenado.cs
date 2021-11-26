using UnityEngine;

public class ContadorDeColetaveisOrdenado : TrocadorDeOrdem
{
    private static readonly string PROP_MAINTTEXT = "_MaintText";

    public int contador { get; private set; }
    private BoardOrdem[] ordem;
    private Material materialOutline;

    public ContadorDeColetaveisOrdenado(Material materialOutline)
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

    public void iniciar()
    {
        if(isLevelOrdem())
        {
            indicarProximoColetavel();
        }
    }

    public bool contarOrdem(ColetavelTile coletavelTile)
    {
        if (isLevelOrdem())
        {
            BoardOrdem ordemIt = ordem[contador];
            if (coletavelTile.nome.Equals(ordemIt.nome))
            {
                coletavelTile.clearMaterial();
                contador++;
                indicarProximoColetavel();
                return false;
            }
            else
            {
                return true;
            }
        }
        return false;        
    }
       
    public void indicarProximoColetavel()
    {
        if(contador < ordem.Length)
        {
            BoardOrdem ordemIt = ordem[contador];

            HelperColetaveisInGame helperColetaveis = new HelperColetaveisInGame();
            ColetavelTile coletavelTile = helperColetaveis.getColetavelInGameByName(ordemIt.nome);

            materialOutline.SetTexture(PROP_MAINTTEXT, coletavelTile.getSprite().texture);
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

    public void trocarFigura(ColetavelTile coletavelPrimeiro, ColetavelTile coletavelSegundo)
    {
        if (isLevelOrdem())
        {
            for (int contadorAtual = contador; contadorAtual < ordem.Length; contadorAtual++)
            {
                BoardOrdem ordemIt = ordem[contadorAtual];
                if (ordemIt.nome.Equals(coletavelPrimeiro.nome))
                {
                    if(ordemIt.ordem == contador + 1)
                    {
                        trocarSpriteMaterial(coletavelPrimeiro, coletavelSegundo.getSprite());
                    }
                    break;
                }
            }
        }
    }

    private void trocarNomes(BoardOrdem ordemPrimeiro, BoardOrdem ordemSegundo)
    {
        string nomeTemp = ordemPrimeiro.nome;
        ordemPrimeiro.trocarNome(ordemSegundo.nome);
        ordemSegundo.trocarNome(nomeTemp);
    }

    private void trocarSpriteMaterial(ColetavelTile coletavelComMaterial, Sprite spr)
    {
        materialOutline.SetTexture(PROP_MAINTTEXT, spr.texture);
        coletavelComMaterial.addMaterial(materialOutline);
    }

    private void trocarMaterial(ColetavelTile coletavelComMaterial, ColetavelTile coletavelSemMaterial)
    {
        Debug.Log("Troca de material acionada");
        coletavelComMaterial.clearMaterial();
        coletavelSemMaterial.addMaterial(materialOutline);
    }    
}
