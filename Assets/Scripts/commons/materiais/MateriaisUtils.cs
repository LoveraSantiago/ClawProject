using UnityEngine;

public class MateriaisUtils 
{
    public static void configurar(GameObject goPrefabMaterias)
    {
        PrefabDeMateriaisDto prefabDeMateriais = goPrefabMaterias.GetComponent<PrefabDeMateriaisDto>();
        MaterialGrayScale.configurar(prefabDeMateriais.MaterialGrayScale);
        MaterialOutline.configurar(prefabDeMateriais.MaterialOutline);
    }    
}
