using UnityEngine;

public class EstadoPosicoesMovimentadorArmarioDto 
{
    public bool movimentado { get; private set; }
    public Vector2 posItemReferencia { get; private set; }
    public Vector2 posOriginal { get; private set; }
    public Vector2 pivotOriginal { get; private set; }

    public EstadoPosicoesMovimentadorArmarioDto(Vector2 posItemReferencia)
    {
        this.posItemReferencia = posItemReferencia;
    }

    public void setMovimentado(bool movimentado)
    {
        this.movimentado = movimentado;
    }   

    public void setPosOriginal(Vector2 posOriginal)
    {
        this.posOriginal = posOriginal;
    }

    public void setPivotOriginal(Vector2 pivotOriginal)
    {
        this.pivotOriginal = pivotOriginal;
    }
}
