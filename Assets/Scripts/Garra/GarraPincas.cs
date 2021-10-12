using UnityEngine;

public class GarraPincas 
{
    private float incremento;    

    private EdgeCollider2D colliderPEsquerda;
    private EdgeCollider2D colliderPDireita;

    private Transform pincaEsquerda;
    private Transform pincaDireita;

    public GarraPincas(Transform pincaEsquerda, Transform pincaDireita)
    {
        this.pincaEsquerda = pincaEsquerda;
        this.pincaDireita = pincaDireita;

        colliderPEsquerda = this.pincaEsquerda.GetComponent<EdgeCollider2D>();
        colliderPDireita = this.pincaDireita.GetComponent<EdgeCollider2D>(); ;
    }

    //FDT fixed delta time
    public void rotacionarFDT(float velocidade, Quaternion angEsquerda, Quaternion angDireita)
    {
        incremento = Time.fixedDeltaTime + velocidade;

        pincaEsquerda.rotation = Quaternion.RotateTowards(pincaEsquerda.rotation, angEsquerda, incremento);
        pincaDireita.rotation  = Quaternion.RotateTowards(pincaDireita.rotation , angDireita , incremento);
    }

    public bool isDireitaNoAngulo(Quaternion anguloDesejado)
    {
        return Mathf.Round(pincaDireita.rotation.eulerAngles.z) == Mathf.Round(anguloDesejado.eulerAngles.z);        
    }

    public void acionarTrigger()
    {
        colliderPEsquerda.isTrigger = true;
        colliderPDireita.isTrigger = true;
    }

    public void acionarCollider()
    {
        colliderPEsquerda.isTrigger = false;
        colliderPDireita.isTrigger = false;
    }
}
