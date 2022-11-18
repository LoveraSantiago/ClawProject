using UnityEngine;

public class ModalFimCacaNiquelIndividual : AbstractModalFim
{    
    private ModalCacaNiquelDto modalCacaNiquelDto;

    public ModalFimCacaNiquelIndividual(
        CacaNiquelEventoDto evento, ModalCacaNiquelDto modalCacaNiquelDto, CacaNiquelDto cacaNiquelDto, Loading loading)
    {
        this.modalCacaNiquelDto = modalCacaNiquelDto;
        configurar(evento, cacaNiquelDto);
        modalCacaNiquelDto.BtnAvancar.onClick.AddListener(()=> irParaCena(loading));
    }

    public void configurar(CacaNiquelEventoDto evento, CacaNiquelDto cacaNiquelDto)
    {
        int indicePup = PlayerPrefsPowerUp.recuperarIndicePup();
        PowerUpEntidade pupEscolhido = FactoryPowerUpEntidade.getPowerUpFromIndice(indicePup);

        modalCacaNiquelDto.ImgHeadPup.sprite = pupEscolhido.sprPersonagemPup;
        modalCacaNiquelDto.LblNomePup.text = pupEscolhido.nome;
        montarSlotsResultados(evento, pupEscolhido, cacaNiquelDto);
        montarLinhasResultados(evento, pupEscolhido);
    }

    private void montarSlotsResultados(CacaNiquelEventoDto evento, PowerUpEntidade pup, CacaNiquelDto cacaNiquelDto)
    {
        for(int contador = 0; contador < modalCacaNiquelDto.SlotsCacaNiquel.Length; contador++)
        {
            modalCacaNiquelDto.SlotsCacaNiquel[contador].ImgResultado.sprite = evento.sprResultados[contador];
            if (evento.isResultSucesso(contador))
            {
                modalCacaNiquelDto.SlotsCacaNiquel[contador].ImgBackground.color = cacaNiquelDto.CorSucesso;
            }
            else if (evento.isResultFail(contador))
            {
                modalCacaNiquelDto.SlotsCacaNiquel[contador].ImgBackground.color = cacaNiquelDto.CorFalha;
            }
            else
            {
                modalCacaNiquelDto.SlotsCacaNiquel[contador].ImgBackground.color = cacaNiquelDto.CorMeio;
            }
        }
    }

    private void montarLinhasResultados(CacaNiquelEventoDto evento, PowerUpEntidade pupEscolhido)
    {
        int qtdPups = PlayerPrefsPowerUp.recuperarQtdPup(pupEscolhido.nome);
        int qtdFichasBronze = PlayerPrefsFichas.getQtdFichas(Ficha.BRONZE);        

        string textLinhaPups = null;
        string textBonus     = null;
        string textFicha = null;

        int qtdSucesso = evento.getQtdSucesso();
        switch (qtdSucesso)
        {
            case 0:
                {
                    textLinhaPups = "  +  0 = " + qtdPups;
                    textBonus     = "  + 1 = " + (qtdPups + 1);
                    PlayerPrefsPowerUp.adicionarPup(pupEscolhido.nome, 1);
                    break;
                }
            case 3:
                {
                    textLinhaPups = "  +  3 = " + (qtdPups + 3);
                    textBonus     = "  + 3 = " + (qtdPups + 6);                    
                    PlayerPrefsPowerUp.adicionarPup(pupEscolhido.nome, 6);
                    break;
                }
            default:
                {
                    textLinhaPups = "  + " + qtdSucesso + " = " + (qtdPups + qtdSucesso);
                    textBonus     = "  + 0 = " + (qtdPups + qtdSucesso);                    
                    PlayerPrefsPowerUp.adicionarPup(pupEscolhido.nome, qtdSucesso);
                    break;
                }
        }

        if (evento.hasFicha())
        {
            textFicha = "  + 1 = " + (qtdFichasBronze + 1);
            PlayerPrefsFichas.ganharFicha(Ficha.BRONZE, 1);
        }
        else
        {
            textFicha = "  + 0 = " + qtdFichasBronze;
        }

        popularModal(pupEscolhido.sprIconPowerUp, textLinhaPups, textBonus, textFicha);
    }

    private void popularModal(Sprite sprite, string textLinhaPup, string textLinhaBonus, string textFicha)
    {
        LinhaModalCacaNiquelDto linha0 = modalCacaNiquelDto.LinhaResult[0];
        LinhaModalCacaNiquelDto linha1 = modalCacaNiquelDto.LinhaResult[1];
        LinhaModalCacaNiquelDto linha2 = modalCacaNiquelDto.LinhaResult[2];

        linha0.ImgLinha.sprite = sprite;
        linha0.LblLinha.text = textLinhaPup;
        linha1.LblLinha.text = textLinhaBonus;
        linha2.LblLinha.text = textFicha;
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
