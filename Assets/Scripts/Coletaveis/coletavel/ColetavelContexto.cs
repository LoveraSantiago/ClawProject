using UnityEngine;

public class ColetavelContexto : GOContexto
{
    public int sprOrderComum;
    public int sprOrdemDestaque;
    public int sprOrdemEscondido;    

    public Nomeador nomeador { get; private set; }
    public CircleCollider2D referenciaColliderColetado { get; private set; }

    public ColetavelContexto(ColetaveisDto coletaveisDto, CircleCollider2D referenciaColliderColetado)
        : base(coletaveisDto.GoMainColetavel)
    {
        nomeador = new Nomeador();
        this.referenciaColliderColetado = referenciaColliderColetado;
        sprOrderComum     = coletaveisDto.OrderColetaveis;
        sprOrdemDestaque  = coletaveisDto.OrderDestaqueColetaveis;
        sprOrdemEscondido = coletaveisDto.OrderEscondidoColetaveis;
    }    
}
