using UnityEngine;

public abstract class TrocadorDeOrdem
{
    //CONFIGURAR VIA POWERUPMANAGER VIA ALLMANAGERS
    public abstract void trocar(ColetavelTile coletavel1, ColetavelTile coletavel2);
    public abstract void trocarFigura(ColetavelTile coletavel1, ColetavelTile coletavel2);
    public abstract void atualizar(ColetavelTile coletavel);

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
