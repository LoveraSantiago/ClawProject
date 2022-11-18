using UnityEngine;

public class ModalNoFicha 
{
    private ModalNoFichaDto modalNoFichaDto;

    public ModalNoFicha(ModalNoFichaDto modalNoFichaDto, Loading loading)
    {
        this.modalNoFichaDto = modalNoFichaDto;
        modalNoFichaDto.BtnSair.onClick.AddListener(() => desligar());
        modalNoFichaDto.BtnIrLoja.onClick.AddListener(() => loading.irParaLojaCena());
    }

    public void ligar(Ficha ficha)
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
        modalNoFichaDto.Animator.Play("modal-objetivo");
    }

    private void desligar()
    {
        modalNoFichaDto.Animator.Play("fechar-modal");        
    }    
}
