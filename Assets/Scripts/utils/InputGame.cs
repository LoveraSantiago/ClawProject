using UnityEngine;

public interface InputGame 
{
    void update();
    bool aconteceuTapNaAreaSuperior();
    bool aconteceuTapNaAreaInferior();
    Vector2 getPosicaoTap();
}
