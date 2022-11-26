using UnityEngine;

public class ModalFimColetaveis : AbstractModalFim
{
    private ModalColetaveisDto modalColetaveisDto;
    private SomModais somModais;

    public ModalFimColetaveis(ModalColetaveisDto modalColetaveisDto, SomModais somModais)
    {
        this.modalColetaveisDto = modalColetaveisDto;
        this.somModais = somModais;
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
        somModais.playSomSucessoAbrirModal();
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
        somModais.playSomAbrirModal();
    }

    public override void ligar()
    {
        modalColetaveisDto.Modal.SetActive(true);
    }

    protected override void irParaCena()
    {
        somModais.playSomCliquePositivo();
        ContextoEstaticoUtils.loading.irParaColetaveisCena();        
    }

    public static ModalFimColetaveis ofSucess(ModalColetaveisDto modalColetaveisDto, SomModais somModais)
    {
        ModalFimColetaveis modal = new ModalFimColetaveis(modalColetaveisDto, somModais);
        modal.sucesso();
        return modal;
    }

    public static ModalFimColetaveis ofFail(ModalColetaveisDto modalColetaveisDto, SomModais somModais)
    {
        ModalFimColetaveis modal = new ModalFimColetaveis(modalColetaveisDto, somModais);
        modal.fail();
        return modal;
    }
}
