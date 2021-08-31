using System.Collections;
using UnityEngine;

public class BlocoImg : AcaoBlocoImgPUpAtual.ProdutorEvento,
                        AcaoBBarPupEscolhido<int>.ConsumidorEvento
{
    private readonly int ANIM_IR_ESQUERDA  = Animator.StringToHash("irEsquerda");
    private readonly int ANIM_VIR_ESQUERDA = Animator.StringToHash("virDaEsquerda");
    private readonly int ANIM_IR_DIREITA   = Animator.StringToHash("irDireita");
    private readonly int ANIM_VIR_DIREITA  = Animator.StringToHash("virDaDireita");
    private readonly int ANIM_IDLE         = Animator.StringToHash("idle");

    private bool animacaoEmAndamento;

    private BlocoImgDto blocoImgDto;
    private ControlePupDoCanvas controlePups;
    private ProdutorDeEvento<PowerUpEntidade> produtorDeEvento;    

    public BlocoImg(BlocoImgDto blocoImgDto)
    {
        this.blocoImgDto = blocoImgDto;
        blocoImgDto.BtnEsquerda.onClick.AddListener(()=> irParaEsquerda());
        blocoImgDto.BtnDireita.onClick.AddListener(()=> irParaDireita());        

        controlePups = new ControlePupDoCanvas();
        produtorDeEvento = new ProdutorDeEvento<PowerUpEntidade>();
    }

    public void startLaizy()
    {
        irParaPupAtual();
    }

    public void irParaDireita()
    {
        if (!animacaoEmAndamento)
        {
            PowerUpEntidade pupEntidade = controlePups.getAntPup();            
            Utils.MonoBehaviour.StartCoroutine(moverBloco(ANIM_IR_DIREITA, ANIM_VIR_DIREITA, pupEntidade));
        }
    }

    public void irParaEsquerda()
    {
        if (!animacaoEmAndamento)
        {
            PowerUpEntidade pupEntidade = controlePups.getProxPup();
            Utils.MonoBehaviour.StartCoroutine(moverBloco(ANIM_IR_ESQUERDA, ANIM_VIR_ESQUERDA, pupEntidade));
        }
    }    

    public int getIndicePupAtual()
    {
        return controlePups.indiceAtual;
    }

    private IEnumerator moverBloco(int animInicio, int animFim, PowerUpEntidade pupEntidade)
    {
        animacaoEmAndamento = true;
        blocoImgDto.AnimatorBlocoImg.Play(animInicio);
        yield return new WaitForSeconds(0.4f);
        blocoImgDto.ImgPowerUp.sprite = pupEntidade.sprPowerUp;
        blocoImgDto.AnimatorBlocoImg.Play(animFim);
        produtorDeEvento.produziuEvento(pupEntidade);
        yield return new WaitForSeconds(0.4f);
        blocoImgDto.AnimatorBlocoImg.Play(ANIM_IDLE);
        animacaoEmAndamento = false;
    }

    private void irParaPupAtual()
    {
        PowerUpEntidade pupEntidade = controlePups.getPupAtual();
        blocoImgDto.ImgPowerUp.sprite = pupEntidade.sprPowerUp;
        produtorDeEvento.produziuEvento(pupEntidade);
    }
    
    void AcaoBBarPupEscolhido<int>.ConsumidorEvento.consumirEvento(int evento)
    {
        controlePups.irPupDoIndice(evento);
        irParaPupAtual();
    }

    ProdutorDeEvento<PowerUpEntidade> AcaoBlocoImgPUpAtual.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
