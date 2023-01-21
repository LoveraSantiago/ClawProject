using UnityEngine;

public class ComponentePosicaoDeGO : ComponenteGameObjectDeGO
{
    public ComponentePosicaoDeGO(GameObject go)
        : base(go){}

    public Vector3 getPosicao()
    {
        return getGo().transform.position;
    }

    public Quaternion getAnguloQuaternium()
    {
        return getGo().transform.rotation;
    }

    public Vector3 getAngulo()
    {
        return getAnguloQuaternium().eulerAngles;
    }

    public virtual void colocarNaPosicao(Vector3 posicao)
    {
        getGo().transform.position = posicao;
    }

    public void colocarNaPosicao(Vector3 posicao, Quaternion rotacao)
    {
        colocarNaPosicao(posicao);
        getGo().transform.rotation = rotacao;
    }

    public void colocarNoAngulo(Quaternion quaternion)
    {
        getGo().transform.rotation = quaternion;
    }

    public void colocarNoAngulo(float angulo)
    {
        getGo().transform.rotation = Quaternion.Euler(0, 0, angulo);
    }
}
