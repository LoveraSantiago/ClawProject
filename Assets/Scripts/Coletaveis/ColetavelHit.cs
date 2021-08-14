using UnityEngine;

public class ColetavelHit 
{
    public Collider2D hit(InputGame inputGame)
    {
        Vector3 posicaoTap = inputGame.getPosicaoTap();
        posicaoTap.z = 0;
        Debug.Log("Posicao tap " + posicaoTap);
        int layerMask = LayerMask.GetMask("Coletavel");
        RaycastHit2D raycastHit;
        raycastHit = Physics2D.Raycast(posicaoTap, Vector3.up, 2, layerMask);
        return raycastHit.collider;
    }
}
