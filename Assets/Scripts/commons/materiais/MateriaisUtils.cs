using UnityEngine;

public class MateriaisUtils 
{
    public static void configurar(GameObject goPrefabMaterias)
    {
        PrefabDeMateriaisDto prefabDeMateriais = goPrefabMaterias.GetComponent<PrefabDeMateriaisDto>();

        MaterialGrayScale.configurar(prefabDeMateriais.MaterialGrayScale);
        MaterialOutline.configurar(prefabDeMateriais.MaterialOutline);
        MaterialTeleporte.configurar(prefabDeMateriais.MaterialTroca);
        MaterialHdr.configurar(prefabDeMateriais.MaterialHdrAditivo, prefabDeMateriais.MaterialHdrAlpha);
        MaterialSprUnlitDefault.configurar(prefabDeMateriais.MaterialSprUnlitDefault);
    }    
}
