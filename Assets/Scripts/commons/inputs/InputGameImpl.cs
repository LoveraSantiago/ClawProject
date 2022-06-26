using UnityEngine;

public class InputGameImpl : InputGame,
                             AcaoDesligarMaquina.ConsumidorEvento,
                             AcaoDesligarMaquinaResultado.ConsumidorEvento
{
    private bool isTapAreaSuperior;
    private bool isTapAreaInferior;
    private bool ativado;
    private bool jump1Frame;

    private Vector3 posicaoTap;        

    public InputGameImpl()
    {
        ativado = true;
        jump1Frame = false;
    }

    public void update(Transform referenciaChao)
    {        
        if (Input.GetMouseButtonUp(0) && ativado && !jump1Frame)
        {
            posicaoTap = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (isPosicaoAcimaPosicaoDeReferencia(referenciaChao))
            {
                isTapAreaSuperior = true;
                isTapAreaInferior = false;
            }
            else
            {
                isTapAreaSuperior = false;
                isTapAreaInferior = true;
            }            
        }
        else
        {
            isTapAreaInferior = false;
            isTapAreaSuperior = false;
            jump1Frame = false;
        }
    }

    public bool aconteceuTapNaAreaSuperior()
    {
        return isTapAreaSuperior;
    }

    public bool aconteceuTapNaAreaInferior()
    {
        return isTapAreaInferior;
    }

    public bool aconteceuTap()
    {
        return isTapAreaInferior || isTapAreaSuperior;
    }

    public bool aconteceuDragNaAreaInferior(
        Vector3 dragPosicao, Transform referenciaChaoMaquina)
    {
        //Debug.Log(dragPosicao.y + " | " + referenciaChaoMaquina.position.y + " | " + (dragPosicao.y < referenciaChaoMaquina.position.y));
        return dragPosicao.y < referenciaChaoMaquina.position.y;
    }

    public Vector2 getPosicaoTap()
    {
        return new Vector2(posicaoTap.x, posicaoTap.y);
    }

    private bool isPosicaoAcimaPosicaoDeReferencia(Transform referenciaChaoMaquina)
    {
        return posicaoTap.y > referenciaChaoMaquina.position.y;
    }

    public void consumirTap()
    {
        isTapAreaSuperior = false;
        isTapAreaInferior = false;        
    }

    void AcaoDesligarMaquina.ConsumidorEvento.consumirEvento(DesligarMaquinaDto evento)
    {   
        ativado = false;        
    }

    void AcaoDesligarMaquinaResultado.ConsumidorEvento.consumirEvento(ResultadoDesligarMaquinaDto evento)
    {   
        ativado = !evento.resultadoSair;
        jump1Frame = true;
        consumirTap();
    }   
}
