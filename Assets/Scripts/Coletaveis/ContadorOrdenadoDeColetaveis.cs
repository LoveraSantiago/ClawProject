using UnityEngine;

public class ContadorOrdenadoDeColetaveis 
{
    private int contador;
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



    public void indicarProximoColetavel(PoolDeColetaveis poolDeColetaveis)
    {
        BoardOrdem ordemIt = ordem[contador];
        ColetavelTile coletavelTile = poolDeColetaveis.getColetavelPeloNome(ordemIt.nome);
        materialOutline.SetTexture("_MaintText", coletavelTile.getSprite().texture);
        coletavelTile.addMaterial(materialOutline);
    }

    private bool isLevelOrdem()
    {
        return ordem != null;
    }
}
