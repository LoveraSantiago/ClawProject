using UnityEngine;

public class ModalNoFicha 
{
    private readonly int ANIM_OBJETIVO = Animator.StringToHash("modal-objetivo");
    private readonly int ANIM_FECHAR   = Animator.StringToHash("fechar-modal");
    private ModalNoFichaDto modalNoFichaDto;

    public ModalNoFicha(ModalNoFichaDto modalNoFichaDto, SomModalNoFicha somModalNoFicha)
    {
        this.modalNoFichaDto = modalNoFichaDto;
        modalNoFichaDto.BtnSair.onClick.AddListener(() => desligar(somModalNoFicha));
        modalNoFichaDto.BtnIrLoja.onClick.AddListener(() => irParaCena(somModalNoFicha));
    }

    public void ligar(Ficha ficha, SomModalNoFicha somModalNoFicha)
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
        somModalNoFicha.playSomAbrirModal();
        modalNoFichaDto.Animator.Play(ANIM_OBJETIVO);
    }

    private void irParaCena(SomModalNoFicha somModalNoFicha)
    {
        if (ContextoEstaticoUtils.loading.naoAcionado)
        {
            modalNoFichaDto.Animator.Play(ANIM_FECHAR);
            somModalNoFicha.playSomClique();
            ContextoEstaticoUtils.loading.irParaLojaCena();
        }
    }

    private void desligar(SomModalNoFicha somModalNoFicha)
    {
        somModalNoFicha.playSomCliqueCancelar();
        somModalNoFicha.playSomAbrirModal();
        modalNoFichaDto.Animator.Play(ANIM_FECHAR);        
    }    
}
