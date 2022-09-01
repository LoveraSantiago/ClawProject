using UnityEngine;

public class BtnMapaBalao 
{
    private static readonly int IDLE = Animator.StringToHash("idle-baloes");
    private static readonly int ZOOM = Animator.StringToHash("zoom-baloes");

    private BalaoLevelBtnDto balaoLevelDto;

    public BtnMapaBalao(BalaoLevelBtnDto balaoLevelDto)
    {
        this.balaoLevelDto = balaoLevelDto;
    }

    public void colocarNaPosicao(Vector2 posicao)
    {
        balaoLevelDto.BtnLevel.transform.localPosition = posicao;
        balaoLevelDto.BtnLevel.gameObject.SetActive(false);
    }

    public void zoomarBalao()
    {
        balaoLevelDto.BtnLevel.gameObject.SetActive(true);
        balaoLevelDto.Animator.Play(ZOOM);
    }
}
