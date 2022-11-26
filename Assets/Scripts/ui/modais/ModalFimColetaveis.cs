using UnityEngine;

public class ModalFimColetaveis : AbstractModalFim
{
    private ModalColetaveisDto modalColetaveisDto;

    public ModalFimColetaveis(ModalColetaveisDto modalColetaveisDto, Loading loading)
    {
        this.modalColetaveisDto = modalColetaveisDto;
        modalColetaveisDto.BtnAvancar.onClick.AddListener(() => irParaCena(loading));
    }

   public void sucesso()
    {
        int idColetavel = PlayerPrefsColetaveis.recuperarNavegacaoColetavel();
        ColetavelEntidade coletavel = ContextoEstaticoUtils.mapaEntidade.getColetavelEntidadeByIndice(idColetavel);
        string levelNome = ContextoEstaticoUtils.level.getLevelName();

        modalColetaveisDto.LblLevelTitle.text = levelNome;
        modalColetaveisDto.ImgColetavel.sprite = coletavel.sprite;
        modalColetaveisDto.LblMsg.text = "Parabens!!! Conseguiu coletar " + coletavel.nome + " para a sua coleção!!! Muito bem!!!";

        PlayerPrefsMapas.salvarColetavelAdquiridoDoDoMapa(coletavel);
    }

    public void fail()
    {
        int idColetavel = PlayerPrefsColetaveis.recuperarNavegacaoColetavel();
        ColetavelEntidade coletavel = ContextoEstaticoUtils.mapaEntidade.getColetavelEntidadeByIndice(idColetavel);
        string levelNome = ContextoEstaticoUtils.level.getLevelName();
        Material materialGrayScale = MaterialGrayScale.of(coletavel.sprite);

        modalColetaveisDto.LblLevelTitle.text = levelNome;
        modalColetaveisDto.ImgColetavel.sprite = coletavel.sprite;
        modalColetaveisDto.ImgColetavel.material = materialGrayScale;
        modalColetaveisDto.LblMsg.text = "Ah que pena! Nao foi dessa vez que conseguiu coletar " + coletavel.nome + " para a sua coleção!!!";
    }

    public override void ligar()
    {
        modalColetaveisDto.Modal.SetActive(true);
    }

    protected override void irParaCena(Loading loading)
    {
        loading.irParaColetaveisCena();        
    }

    public static ModalFimColetaveis ofSucess(ModalColetaveisDto modalColetaveisDto, Loading loading)
    {
        ModalFimColetaveis modal = new ModalFimColetaveis(modalColetaveisDto, loading);
        modal.sucesso();
        return modal;
    }

    public static ModalFimColetaveis ofFail(ModalColetaveisDto modalColetaveisDto, Loading loading)
    {
        ModalFimColetaveis modal = new ModalFimColetaveis(modalColetaveisDto, loading);
        modal.fail();
        return modal;
    }
}
