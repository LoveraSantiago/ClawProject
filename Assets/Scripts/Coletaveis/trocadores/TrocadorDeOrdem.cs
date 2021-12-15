using UnityEngine;

public abstract class TrocadorDeOrdem
{
    //CONFIGURAR VIA POWERUPMANAGER VIA ALLMANAGERS
    public abstract void trocar(ColetavelTile coletavelPrimeiro, ColetavelTile coletavelSegundo);
    public abstract void trocarFigura(ColetavelTile coletavelPrimeiro, ColetavelTile coletavelSegundo);
    public abstract void atualizar(ColetavelTile coletavelPrimeiro);

    protected void addMaterialOutline(ColetavelTile coletavel)
    {
        Material materialOutline = MaterialOutline.of(coletavel.getSprite());
        coletavel.addMaterial(materialOutline);
        coletavel.colocarNoLayerDestaque();
    }

    protected void addMaterialGrayScale(ColetavelTile coletavel)
    {
        DestaqueGrayScale destaque = new DestaqueGrayScale();
        destaque.destacar(coletavel);
    }
}
