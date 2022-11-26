using UnityEngine;

public class ModalFimColetaveis : AbstractModalFim
{
    private ModalColetaveisDto modalColetaveisDto;

    public ModalFimColetaveis(ModalColetaveisDto modalColetaveisDto)
    {
        this.modalColetaveisDto = modalColetaveisDto;
        modalColetaveisDto.BtnAvancar.onClick.AddListener(() => irParaCena());
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

    protected override void irParaCena()
    {
        ContextoEstaticoUtils.loading.irParaColetaveisCena();        
    }

    public static ModalFimColetaveis ofSucess(ModalColetaveisDto modalColetaveisDto)
    {
        ModalFimColetaveis modal = new ModalFimColetaveis(modalColetaveisDto);
        modal.sucesso();
        return modal;
    }

    public static ModalFimColetaveis ofFail(ModalColetaveisDto modalColetaveisDto)
    {
        ModalFimColetaveis modal = new ModalFimColetaveis(modalColetaveisDto);
        modal.fail();
        return modal;
    }
}
