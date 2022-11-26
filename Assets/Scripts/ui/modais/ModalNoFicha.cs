using UnityEngine;

public class ModalNoFicha 
{
    private readonly int ANIM_OBJETIVO = Animator.StringToHash("modal-objetivo");
    private readonly int ANIM_FECHAR   = Animator.StringToHash("fechar-modal");
    private ModalNoFichaDto modalNoFichaDto;

    public ModalNoFicha(ModalNoFichaDto modalNoFichaDto, SomMap somMap)
    {
        this.modalNoFichaDto = modalNoFichaDto;
        modalNoFichaDto.BtnSair.onClick.AddListener(() => desligar(somMap));
        modalNoFichaDto.BtnIrLoja.onClick.AddListener(() => irParaCena(somMap));
    }

    public void ligar(Ficha ficha, SomMap somMap)
    {
        Color corEscolhida = Color.white;
        if(Ficha.BRONZE == ficha)
        {
            corEscolhida = modalNoFichaDto.CorBronze;
        }
        else if (Ficha.OURO == ficha)
        {
            corEscolhida = modalNoFichaDto.CorOuro;
        }
        else if(Ficha.PRATA == ficha)
        {
            corEscolhida = modalNoFichaDto.CorPrata;
        }
        modalNoFichaDto.ImgFicha.color = corEscolhida;
        somMap.playSomAbrirModal();
        modalNoFichaDto.Animator.Play(ANIM_OBJETIVO);
    }

    private void irParaCena(SomMap somMap)
    {
        modalNoFichaDto.Animator.Play(ANIM_FECHAR);
        somMap.playSomClique();
        ContextoEstaticoUtils.loading.irParaLojaCena();
    }

    private void desligar(SomMap somMap)
    {
        somMap.playSomCliqueCancelar();
        somMap.playSomAbrirModal();
        modalNoFichaDto.Animator.Play(ANIM_FECHAR);        
    }    
}
