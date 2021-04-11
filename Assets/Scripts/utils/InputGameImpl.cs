using UnityEngine;

public class InputGameImpl : InputGame
{
    private bool isAreaSuperior;
    private bool isAreaInferior;

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
                isAreaSuperior = true;
                isAreaInferior = false;
            }
            else
            {
                isAreaSuperior = false;
                isAreaInferior = true;
            }
        }
        else
        {
            isAreaInferior = false;
            isAreaSuperior = false;
        }
    }

    public bool aconteceuTapNaAreaSuperior()
    {
        return isAreaSuperior;
    }

    public bool aconteceuTapNaAreaInferior()
    {
        return isAreaInferior;
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
