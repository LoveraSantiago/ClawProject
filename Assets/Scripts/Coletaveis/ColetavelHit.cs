using UnityEngine;

public class ColetavelHit 
{
    private static ColetavelHelper coletavelHelper = new ColetavelHelper();

    public static ColetavelTile hit(InputGame inputGame, out bool result)
    {
        Vector3 posicaoTap = inputGame.getPosicaoTap();
        posicaoTap.z = 0;
        //Debug.Log("Posicao tap " + posicaoTap);
        int layerMask = LayerMask.GetMask("Coletavel");
        RaycastHit2D raycastHit;
        raycastHit = Physics2D.Raycast(posicaoTap, Vector3.up, 2, layerMask);

        Collider2D colliderResult = raycastHit.collider;
        if(colliderResult != null)
        {
            result = true;
            return coletavelHelper.getColetavelInGameByName(colliderResult.name);
        }
        else
        {
            result = false;
            return null;
        }       
    }
}
