using UnityEngine;

public class PincaDaGarra 
{
    private float incremento;    

    private Transform pincaEsquerda;
    private Transform pincaDireita;

    public PincaDaGarra(Transform pincaEsquerda, Transform pincaDireita)
    {
        this.pincaEsquerda = pincaEsquerda;
        this.pincaDireita = pincaDireita;
    }

    public void fixUpdateRotacionamento(
        float velocidade, Quaternion anguloEsquerda, Quaternion anguloDireita)
    {
        incremento = Time.fixedDeltaTime + velocidade;

        pincaEsquerda.rotation = Quaternion.RotateTowards(pincaEsquerda.rotation, anguloEsquerda, incremento);
        pincaDireita.rotation  = Quaternion.RotateTowards(pincaDireita.rotation , anguloDireita , incremento);
    }

    public bool isNoAngulo(float angulo)
    {
        return Mathf.Round(pincaDireita.rotation.eulerAngles.z) == Mathf.Round(angulo);
    }
}
