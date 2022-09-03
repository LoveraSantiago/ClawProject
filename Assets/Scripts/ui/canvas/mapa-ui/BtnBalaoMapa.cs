using UnityEngine;

public class BtnBalaoMapa 
{
    private static readonly int IDLE       = Animator.StringToHash("idle-baloes");
    private static readonly int ZOOM_MAIS  = Animator.StringToHash("zoom-mais");
    private static readonly int ZOOM_MENOS = Animator.StringToHash("zoom-menos");

    private BalaoLevelBtnDto balaoLevelDto;

    public BtnBalaoMapa(BalaoLevelBtnDto balaoLevelDto)
    {
        this.balaoLevelDto = balaoLevelDto;
        this.balaoLevelDto.BtnLevel.gameObject.SetActive(false);
    }

    public void colocarNaPosicao(Vector2 posicao)
    {
        balaoLevelDto.BtnLevel.transform.localPosition = posicao;        
    }

    public void zoomarBalaoMais()
    {
        this.balaoLevelDto.BtnLevel.gameObject.SetActive(true);
        balaoLevelDto.Animator.Play(ZOOM_MAIS);
    }

    public void zoomarBalaoMenos()
    {
        balaoLevelDto.Animator.Play(ZOOM_MENOS);        
    }
}
