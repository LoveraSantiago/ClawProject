using UnityEngine;

public class ComponentePincasDaGarrra : ComponenteRigidBodyDaGarra
{
    private float incremento;

    private EdgeCollider2D colliderPEsquerda;
    private EdgeCollider2D colliderPDireita;    

    public ComponentePincasDaGarrra(GarraDto garraDto, SomGarra somGarra)
        : base(garraDto, somGarra)
    {   
        colliderPEsquerda = getTransformPincaEsquerda().GetComponent<EdgeCollider2D>();
        colliderPDireita  = getTransformPincaDireita().GetComponent<EdgeCollider2D>(); ;
    }   

    //FDT fixed delta time
    public void rotacionarPincaFDT(float velocidade, Quaternion angEsquerda, Quaternion angDireita)
    {
        incremento = Time.fixedDeltaTime + velocidade;

        Transform pincaEsquerda = getTransformPincaEsquerda();
        Transform pincaDireita  = getTransformPincaDireita();

        pincaEsquerda.rotation = Quaternion.RotateTowards(pincaEsquerda.rotation, angEsquerda, incremento);
        pincaDireita.rotation = Quaternion.RotateTowards(pincaDireita.rotation, angDireita, incremento);
    }

    public bool isPincaDireitaNoAngulo(Quaternion anguloDesejado)
    {
        return Mathf.Round(getTransformPincaDireita().rotation.eulerAngles.z) == Mathf.Round(anguloDesejado.eulerAngles.z);
    }

    public void acionarTriggerDaPinca()
    {
        colliderPEsquerda.isTrigger = true;
        colliderPDireita.isTrigger = true;
    }

    public void acionarColliderDaPinca()
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
