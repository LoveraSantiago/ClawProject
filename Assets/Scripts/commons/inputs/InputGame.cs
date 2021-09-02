using UnityEngine;

public interface InputGame 
{
    void update();
    bool aconteceuTapNaAreaSuperior();
    bool aconteceuTapNaAreaInferior();
    bool aconteceuTap();
    bool aconteceuDragNaAreaInferior(Vector3 dragPosicao);
    Vector2 getPosicaoTap();
}
