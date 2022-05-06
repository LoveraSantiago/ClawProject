using UnityEngine;

public class DraggavelManager : AcaoBBarItemEscolhido<PowerUpBtnInfo>.ConsumidorEvento,
                                AcaoPowerUpAcionado.ConsumidorEvento
{
    private int qtdDraggaveis;
    private BoxCollider2D colliderDrag;

    public DraggavelManager(BoxCollider2D colliderDrag)
    {
        this.colliderDrag = colliderDrag;
    }

    void AcaoBBarItemEscolhido<PowerUpBtnInfo>.ConsumidorEvento.consumirEvento(PowerUpBtnInfo evento)
    {
        if (evento.hasEntidade)
        {
            if (!evento.powerUpEntidade.isClicavel)
            {
                Debug.Log("Ligando box collider");
                colliderDrag.enabled = true;
                qtdDraggaveis++;
            }
        }
    }

    void AcaoPowerUpAcionado.ConsumidorEvento.consumirEvento(PowerUpInfo evento)
    {
        if (evento.isInicio)
        {
            if (!evento.isClicavel)
            {
                qtdDraggaveis--;
                if(qtdDraggaveis == 0)
                {
                    Debug.Log("Desligando box collider");
                    colliderDrag.enabled = false;
                }
            }
        }
    }
}
