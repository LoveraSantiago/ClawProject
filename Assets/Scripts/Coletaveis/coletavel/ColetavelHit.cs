using UnityEngine;

public class ColetavelHit 
{
    private static HelperColetaveisInGame helperInGame = new HelperColetaveisInGame();

    public static Coletavel hit(InputGame inputGame)
    {
        Vector3 posicaoTap = inputGame.getPosicaoTap();
        posicaoTap.z = 0;
        //Debug.Log("Posicao tap " + posicaoTap);
        string[] layers = new string[] { TagUtils.TAG_LAYER_COLETAVEL, TagUtils.LAYER_COLETAVELGAIOLA };
        int layerMask = LayerMask.GetMask(layers);
        RaycastHit2D raycastHit;
        raycastHit = Physics2D.Raycast(posicaoTap, Vector3.up, 2, layerMask);

        Collider2D colliderResult = raycastHit.collider;
        if(colliderResult != null)
        {
            Debug.Log("Coletavel acertado no input " + inputGame.getPosicaoTap());
            return helperInGame.getColetavelInGameByGoName(colliderResult.name);
        }
        else
        {         
            return null;
        }       
    }
}
