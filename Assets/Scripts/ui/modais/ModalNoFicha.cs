using UnityEngine;

public class ModalNoFicha 
{
    private ModalNoFichaDto modalNoFichaDto;

    public ModalNoFicha(ModalNoFichaDto modalNoFichaDto, Loading loading, SomMap somMap)
    {
        this.modalNoFichaDto = modalNoFichaDto;
        modalNoFichaDto.BtnSair.onClick.AddListener(() => desligar(somMap));
        modalNoFichaDto.BtnIrLoja.onClick.AddListener(() => loading.irParaLojaCena());
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
        modalNoFichaDto.Animator.Play("modal-objetivo");
    }

    private void desligar(SomMap somMap)
    {
        somMap.playSomCliqueCancelar();
        somMap.playSomAbrirModal();
        modalNoFichaDto.Animator.Play("fechar-modal");        
    }    
}
