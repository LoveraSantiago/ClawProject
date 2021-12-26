using UnityEngine;

public class ColetavelHit 
{
    private static HelperColetaveisInGame helperInGame = new HelperColetaveisInGame();

    public static Coletavel hit(InputGame inputGame)
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
            return helperInGame.getColetavelInGameByGoName(colliderResult.name);
        }
        else
        {         
            return null;
        }       
    }
}
