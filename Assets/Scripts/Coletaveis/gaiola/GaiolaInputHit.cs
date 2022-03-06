using UnityEngine;

public class GaiolaInputHit 
{
    private static HelperGaiolasInGame helperInGame = new HelperGaiolasInGame();

    public static Gaiola hit(InputGame inputGame)
    {
        Vector3 posicaoTap = inputGame.getPosicaoTap();
        posicaoTap.z = 0;
        //Debug.Log("Posicao tap " + posicaoTap);
        int layerMask = LayerMask.GetMask(TagUtils.LAYER_GAIOLA);
        RaycastHit2D raycastHit;
        raycastHit = Physics2D.Raycast(posicaoTap, Vector3.up, 2, layerMask);

        Collider2D colliderResult = raycastHit.collider;
        if (colliderResult != null)
        {
            return helperInGame.getGaiolaInGameByGoName(colliderResult.name);
        }
        else
        {
            return null;
        }
    }
}
