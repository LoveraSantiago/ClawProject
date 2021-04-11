using UnityEngine;

public class InputGameImpl : InputGame
{
    private Transform referenciaChaoMaquina;

    public InputGameImpl(Transform referenciaChao)
    {
        referenciaChaoMaquina = referenciaChao;
    }

    public bool aconteceuTapNaAreaJogavel()
    {
        return Input.GetMouseButtonDown(0) && isPosicaoAcimaPosicaoDeReferencia();
    }

    private bool isPosicaoAcimaPosicaoDeReferencia()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition).y > referenciaChaoMaquina.position.y;
    }
}
