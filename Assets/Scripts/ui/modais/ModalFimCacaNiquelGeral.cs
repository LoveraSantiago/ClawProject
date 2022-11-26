using UnityEngine;

public class ModalFimCacaNiquelGeral : AbstractModalFim
{
    private ModalCacaNiquelDto modalCacaNiquelDto;

    public ModalFimCacaNiquelGeral(
        CacaNiquelEventoDto evento, ModalCacaNiquelDto modalCacaNiquelDto, CacaNiquelDto cacaNiquelDto, Loading loading)
    {
        this.modalCacaNiquelDto = modalCacaNiquelDto;
        configurar(evento, cacaNiquelDto);
        modalCacaNiquelDto.BtnAvancar.onClick.AddListener(() => irParaCena(loading));
    }

    public void configurar(CacaNiquelEventoDto evento, CacaNiquelDto cacaNiquelDto)
    {        
        modalCacaNiquelDto.LblNomePup.text = "Power Ups Todos";

        for (int contador = 0; contador < evento.sprResultados.Length; contador++)
        {
            Sprite spritePup = evento.sprResultados[contador];
            PowerUpEntidade powerUp = FactoryPowerUpEntidade.getPowerUpEntidadeBySprite(spritePup);
            int qtdPup = PlayerPrefsPowerUp.recuperarQtdPup(powerUp.nome);
            PlayerPrefsPowerUp.adicionarPup(powerUp.nome, 1);
            string textLinha = " + 1 = " + (qtdPup + 1);

            modalCacaNiquelDto.SlotsCacaNiquel[contador].ImgResultado.sprite = spritePup;
            modalCacaNiquelDto.SlotsCacaNiquel[contador].ImgBackground.color = cacaNiquelDto.CorSucesso;
            LinhaModalCacaNiquelDto linha = modalCacaNiquelDto.LinhaResult[contador];
            linha.ImgLinha.sprite = spritePup;
            linha.LblLinha.text = textLinha;
        }        
    }    

    private void montarLinhas(CacaNiquelEventoDto evento, CacaNiquelDto cacaNiquelDto)
    {
    }

    public override void ligar()
    {
        modalCacaNiquelDto.Modal.SetActive(true);
    }

    protected override void irParaCena(Loading loading)
    {
        loading.irParaPowerUpCena();
    }
}
