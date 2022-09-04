using UnityEngine;

public class DraggavelManager : AcaoPupFromScrollSelecao.ConsumidorEvento,
                                AcaoPowerUpAcionado.ConsumidorEvento,
                                AcaoBotaoPowerUpVazio.ConsumidorEvento
{
    private int qtdDraggaveis;
    private BoxCollider2D colliderDrag;

    public DraggavelManager(BoxCollider2D colliderDrag)
    {
        this.colliderDrag = colliderDrag;
    }

    void AcaoItemEscolhido<PowerUpBtnInfo>.ConsumidorEvento.consumirEvento(PowerUpBtnInfo evento)
    {
        if (evento.hasEntidade)
        {
            if (!evento.powerUpEntidade.isClicavel)
            {
                //Debug.Log("Ligando box collider");
                colliderDrag.enabled = true;
                qtdDraggaveis++;
            }
        }
        else
        {
            if(qtdDraggaveis == 0)
            {
                colliderDrag.enabled = false;
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
                    //Debug.Log("Desligando box collider");
                    colliderDrag.enabled = false;
                }
            }
        }
    }

    void AcaoBotaoPowerUpVazio.ConsumidorEvento.consumirEvento(int evento)
    {
        colliderDrag.enabled = true;
    }
}
