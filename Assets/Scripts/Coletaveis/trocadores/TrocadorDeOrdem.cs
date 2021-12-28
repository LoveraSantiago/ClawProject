using UnityEngine;

public abstract class TrocadorDeOrdem
{
    //CONFIGURAR VIA POWERUPMANAGER VIA ALLMANAGERS
    public abstract void trocar(Coletavel coletavel1, Coletavel coletavel2);
    public abstract void trocarFigura(Coletavel coletavel1, Coletavel coletavel2);
    public abstract void atualizar(Coletavel coletavel);

    protected void addMaterialOutline(Coletavel coletavel)
    {
        Material materialOutline = MaterialOutline.of(coletavel.getSprite());
        coletavel.addMaterial(materialOutline);
        coletavel.colocarNoLayerDestaque();
    }

    protected void addMaterialGrayScale(Coletavel coletavel)
    {
        DestaqueGrayScale destaque = new DestaqueGrayScale();
        destaque.destacar(coletavel);
    }
}
