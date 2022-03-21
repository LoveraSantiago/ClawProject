using UnityEngine;

public class ComponentePincasDaGarrra : ComponenteRigidBodyDaGarra
{
    private float incremento;

    private EdgeCollider2D colliderPEsquerda;
    private EdgeCollider2D colliderPDireita;    

    public ComponentePincasDaGarrra(GarraDto garraDto)
        : base(garraDto)
    {   
        colliderPEsquerda = getTransformPincaEsquerda().GetComponent<EdgeCollider2D>();
        colliderPDireita  = getTransformPincaDireita().GetComponent<EdgeCollider2D>(); ;
    }   

    //FDT fixed delta time
    public void rotacionarFDT(float velocidade, Quaternion angEsquerda, Quaternion angDireita)
    {
        incremento = Time.fixedDeltaTime + velocidade;

        Transform pincaEsquerda = getTransformPincaEsquerda();
        Transform pincaDireita  = getTransformPincaDireita();

        pincaEsquerda.rotation = Quaternion.RotateTowards(pincaEsquerda.rotation, angEsquerda, incremento);
        pincaDireita.rotation = Quaternion.RotateTowards(pincaDireita.rotation, angDireita, incremento);
    }

    public bool isDireitaNoAngulo(Quaternion anguloDesejado)
    {
        return Mathf.Round(getTransformPincaDireita().rotation.eulerAngles.z) == Mathf.Round(anguloDesejado.eulerAngles.z);
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

    private Transform getTransformPincaEsquerda()
    {
        return garraDto.Corpo.TransformPincaEsquerda;
    }

    private Transform getTransformPincaDireita()
    {
        return garraDto.Corpo.TransformPincaDireita;
    }
}
