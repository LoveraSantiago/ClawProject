using UnityEngine;

public class PosicaoBotaoPowerUp 
{
    //private BotaoPowerUpDto btnDto;
    private BotaoPowerUpDtoV2 btnDto;

    //public PosicaoBotaoPowerUp(BotaoPowerUpDto btnDto)
    //{
    //    this.btnDto = btnDto;
    //}

    public PosicaoBotaoPowerUp(BotaoPowerUpDtoV2 btnDto)
    {
        this.btnDto = btnDto;
    }

    //public Vector3 adicionarNaPosicao(Vector3 posAdicionar)
    //{
    //    Vector3 posicaoCalculada = new Vector3(
    //       btnDto.GoParteDentro.transform.position.x + posAdicionar.x,
    //       btnDto.GoParteDentro.transform.position.y + posAdicionar.y,
    //       0);

    //    btnDto.GoParteDentro.transform.position = posicaoCalculada;
    //    return posicaoCalculada;
    //}

    public Vector3 adicionarNaPosicao(Vector3 posAdicionar)
    {
        Transform transform = btnDto.TransformBtnTampa;
        Vector3 posicaoCalculada = new Vector3(
           transform.position.x + posAdicionar.x,
           transform.position.y + posAdicionar.y,
           0);

        btnDto.TransformBtnTampa.transform.position = posicaoCalculada;
        return posicaoCalculada;
    }

    //public Vector3 getPosicao()
    //{
    //    return btnDto.GoParteDentro.transform.position;
    //}

    public Vector3 getPosicao()
    {
        return btnDto.TransformBtnTampa.transform.position;
    }  

    //public void moveTowards(Vector3 posicaoDestino, float velocidade)
    //{
    //    btnDto.GoParteDentro.transform.position = Vector3.MoveTowards(
    //        btnDto.GoParteDentro.transform.position, posicaoDestino, velocidade);
    //}

    public void moveTowards(Vector3 posicaoDestino, float velocidade)
    {
        btnDto.TransformBtnTampa.transform.position = Vector3.MoveTowards(
            btnDto.TransformBtnTampa.transform.position, posicaoDestino, velocidade);
    }

    //public void colocarNaPosicaoOriginal(Vector3 posicao, Quaternion rotacao)
    //{
    //    btnDto.GoParteDentro.transform.position = posicao;
    //    btnDto.GoBtnPowerUp.transform.localRotation = rotacao;

    //    Transform transformBtnPup = btnDto.GoBtnPowerUp.transform;
    //    transformBtnPup.localRotation = btnDto.GoAreaExterna.transform.localRotation;
    //    btnDto.GoAreaExterna.transform.localRotation = Quaternion.identity;
    //}

    public void colocarNaPosicaoOriginal(Vector3 posicao, Quaternion rotacao)
    {
        btnDto.TransformBtnTampa.transform.position = posicao;
        //btnDto.GoBtnPowerUp.transform.localRotation = rotacao;

        //Transform transformBtnPup = btnDto.GoBtnPowerUp.transform;
        //transformBtnPup.localRotation = btnDto.GoAreaExterna.transform.localRotation;
        //btnDto.GoAreaExterna.transform.localRotation = Quaternion.identity;
    }

    public void colocarNaPosicaoOriginalAcionado(Vector3 posicao, Quaternion rotacao)
    {
        colocarNaPosicaoOriginal(posicao, rotacao);        
    }
}
