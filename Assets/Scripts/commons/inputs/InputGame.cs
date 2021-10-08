using UnityEngine;

public interface InputGame 
{
    void update(Transform referenciaChao);
    bool aconteceuTapNaAreaSuperior();
    bool aconteceuTapNaAreaInferior();
    bool aconteceuTap();
    bool aconteceuDragNaAreaInferior(Vector3 dragPosicao, Transform referenciaChaoMaquina);
    Vector2 getPosicaoTap();
}
