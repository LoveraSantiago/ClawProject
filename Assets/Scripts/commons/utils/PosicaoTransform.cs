using UnityEngine;

public class PosicaoInicialDrag 
{   
    private Transform transform;
 
    public PosicaoInicialDrag(Transform transform)
    {
        this.transform = transform;
    }

    public Vector3 adicionarNaPosicao(Vector3 posAdicionar)
    {   
        Vector3 posicaoCalculada = new Vector3(
           transform.position.x + posAdicionar.x,
           transform.position.y + posAdicionar.y,
           0);

        transform.position = posicaoCalculada;
        return posicaoCalculada;
    }

    public Vector3 adicionarNaPosicaoHorizontal(Vector3 posAdicionar)
    {
        Vector3 posicaoCalculada = new Vector3(
           transform.position.x + posAdicionar.x,
           transform.position.y,
           0);

        transform.position = posicaoCalculada;
        return posicaoCalculada;
    }

    public Vector3 getPosicao()
    {
        return transform.position;
    }  

    public void moveTowards(Vector3 posicaoDestino, float velocidade)
    {
        transform.position = Vector3.MoveTowards(
            transform.position, 
            posicaoDestino, 
            velocidade);
    }

    public void colocarNaPosicaoOriginal(Vector3 posicao)
    {
        transform.position = posicao;     
    }
}
