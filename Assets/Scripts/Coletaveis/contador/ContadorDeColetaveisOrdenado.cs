using UnityEngine;

public class ContadorDeColetaveisOrdenado : ContadorDeColetaveis, 
                                            TrocadorDeOrdem
{
    private static readonly string PROP_MAINTTEXT = "_MaintText";

    private bool resultErroOrdem;
    private int contadorOrdem;

    private BoardOrdem[] ordem;
    private Material materialOutline;

    public ContadorDeColetaveisOrdenado(int pontosColetado, int pontosAcerto, Material materialOutline)
        :base(pontosColetado, pontosAcerto)
    {
        contadorOrdem = 0;
        this.materialOutline = new Material(materialOutline);        
    }

    public override void configuradoPeloLevel(AbstractLevel level)
    {
        ordem = level.getBoardOrdem();                    
    }

    public override void iniciar(int totalColetaveis)
    {
        base.iniciar(totalColetaveis);
        indicarProximoColetavel();             
    }

    public override int contarColetado(ColetavelTile coletavelTile)
    {
        int score = base.contarColetado(coletavelTile);
        BoardOrdem ordemIt = ordem[contadorOrdem];
        if (coletavelTile.nome.Equals(ordemIt.nome))
        {
            coletavelTile.clearMaterial();
            contadorOrdem++;
            indicarProximoColetavel();
            resultErroOrdem = false;            
        }
        else
        {
            resultErroOrdem = true;            
        }
        return score;
    }

    public override bool isErroOrdem()
    {
        return resultErroOrdem;
    }

    private void indicarProximoColetavel()
    {
        if(contadorOrdem < ordem.Length)
        {
            BoardOrdem ordemIt = ordem[contadorOrdem];

            HelperColetaveisInGame helperInGame = new HelperColetaveisInGame();
            ColetavelTile coletavelTile = helperInGame.getColetavelInGameByName(ordemIt.nome);

            materialOutline.SetTexture(PROP_MAINTTEXT, coletavelTile.getSprite().texture);
            coletavelTile.addMaterial(materialOutline);
        }
    }    

    public void trocarOrdem(ColetavelTile coletavelPrimeiro, ColetavelTile coletavelSegundo)
    {      
        BoardOrdem ordemPrimeiro = null;
        BoardOrdem ordemSegundo = null;            
            
        for(int contadorAtual = contadorOrdem; contadorAtual < ordem.Length; contadorAtual++)
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

        if(ordemPrimeiro.ordem == contadorOrdem + 1)
        {
            trocarMaterial(coletavelPrimeiro, coletavelSegundo);
        }
        else if(ordemSegundo.ordem == contadorOrdem + 1)
        {
            trocarMaterial(coletavelSegundo, coletavelPrimeiro);
        }
        trocarNomes(ordemPrimeiro, ordemSegundo);        
    }

    public void trocarFigura(ColetavelTile coletavelPrimeiro, ColetavelTile coletavelSegundo)
    {       
        for (int contadorAtual = contadorOrdem; contadorAtual < ordem.Length; contadorAtual++)
        {
            BoardOrdem ordemIt = ordem[contadorAtual];
            if (ordemIt.nome.Equals(coletavelPrimeiro.nome))
            {
                if(ordemIt.ordem == contadorOrdem + 1)
                {
                    trocarSpriteMaterial(coletavelPrimeiro, coletavelSegundo.getSprite());
                }
                break;
            }
        }       
    }

    public override int getIndiceOrdem()
    {
        return contadorOrdem;
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
