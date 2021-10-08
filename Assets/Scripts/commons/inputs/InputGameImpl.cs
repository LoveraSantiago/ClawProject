using UnityEngine;

public class InputGameImpl : InputGame
{
    private bool isTapAreaSuperior;
    private bool isTapAreaInferior;    

    private Vector3 posicaoTap;        

    public void update(Transform referenciaChao)
    {        
        if (Input.GetMouseButtonDown(0))
        {
            posicaoTap = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (isPosicaoAcimaPosicaoDeReferencia(referenciaChao))
            {
                isTapAreaSuperior = true;
                isTapAreaInferior = false;
            }
            else
            {
                isTapAreaSuperior = false;
                isTapAreaInferior = true;
            }            
        }
        else
        {
            isTapAreaInferior = false;
            isTapAreaSuperior = false;            
        }
    }

    public bool aconteceuTapNaAreaSuperior()
    {
        return isTapAreaSuperior;
    }

    public bool aconteceuTapNaAreaInferior()
    {
        return isTapAreaInferior;
    }

    public bool aconteceuTap()
    {
        return isTapAreaInferior || isTapAreaSuperior;
    }

    public bool aconteceuDragNaAreaInferior(
        Vector3 dragPosicao, Transform referenciaChaoMaquina)
    {
        return dragPosicao.y < referenciaChaoMaquina.position.y;
    }

    public Vector2 getPosicaoTap()
    {
        return new Vector2(posicaoTap.x, posicaoTap.y);
    }

    private bool isPosicaoAcimaPosicaoDeReferencia(Transform referenciaChaoMaquina)
    {
        return posicaoTap.y > referenciaChaoMaquina.position.y;
    }
}
