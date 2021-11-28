using UnityEngine;

public class MateriaisUtils 
{
    public MateriaisUtils configurarGrayScale(Material materialGrayScale)
    {
        MaterialGrayScale.configurar(materialGrayScale);
        return this;
    }      

    public MateriaisUtils configurarOutline(Material materialOutline)
    {
        MaterialOutline.configurar(materialOutline);
        return this;
    }
}
