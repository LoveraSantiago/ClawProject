using UnityEngine;

public class InputGameImpl : InputGame
{
    private bool isTapAreaSuperior;
    private bool isTapAreaInferior;

    private Vector3 posicaoTap;
    private Transform referenciaChaoMaquina;

    public InputGameImpl(Transform referenciaChao)
    {
        referenciaChaoMaquina = referenciaChao;
    }

    public void update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            posicaoTap = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (isPosicaoAcimaPosicaoDeReferencia())
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

    public bool aconteceuDragNaAreaInferior(Vector3 dragPosicao)
    {
        Debug.Log("Drag Y: " + dragPosicao.y + " Ref Y: " + referenciaChaoMaquina.position.y);
        return dragPosicao.y < referenciaChaoMaquina.position.y;
    }

    public Vector2 getPosicaoTap()
    {
        return new Vector2(posicaoTap.x, posicaoTap.y);
    }

    private bool isPosicaoAcimaPosicaoDeReferencia()
    {
        return posicaoTap.y > referenciaChaoMaquina.position.y;
    }
}
