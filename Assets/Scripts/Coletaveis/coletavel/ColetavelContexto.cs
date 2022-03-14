using UnityEngine;

public class ColetavelContexto : GOContexto
{
    public readonly int SPR_ORDER_COMUM = 32;//TRANFORMAR EM CONFIGURACAO
    public readonly int SPR_ORDER_DESTAQUE = 33;

    public readonly int LAYER_ELEVADOR = 20;
    public readonly int LAYER_NORMAL = 9;

    public Nomeador nomeador { get; private set; }
    public CircleCollider2D referenciaColliderColetado { get; private set; }

    public ColetavelContexto(ColetaveisDto coletaveisDto, CircleCollider2D referenciaColliderColetado)
        : base(coletaveisDto.ContextoColetavel, new ProcuradorDeSpriteRenderer("imagem"))
    {
        nomeador = new Nomeador();
        this.referenciaColliderColetado = referenciaColliderColetado;
    }    
}
