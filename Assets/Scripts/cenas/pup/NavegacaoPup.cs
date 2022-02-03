public class NavegacaoPup 
{
    private ModalNoFicha modalNoFicha;

    public NavegacaoPup(ModalNoFichaDto modalNoFichaDto)
    {
        this.modalNoFicha = new ModalNoFicha(modalNoFichaDto);
    }

    public void irGameScenePupPratica(BlocoImgPup blocoImg)
    {
        PlayerPrefsLevel.salvarLevel(Level.PUP);
        abrirCenaOuModal(blocoImg.getIndicePupAtual(), 0);
    }

    public void irGameScenePupIndividual(BlocoImgPup blocoImg)
    {
        PlayerPrefsLevel.salvarLevel(Level.CACANIQUEL_PUP_I);

        int indicePup = blocoImg.getIndicePupAtual();
        PowerUpEntidade pupEntidade = FactoryPowerUpEntidade.getPowerUpFromIndice(indicePup);
        int precoFicha = int.Parse(pupEntidade.preco);

        abrirCenaOuModal(indicePup, precoFicha);
    }

    public void irGameScenePupGeral(BlocoImgPup blocoImg)
    {
        PlayerPrefsLevel.salvarLevel(Level.CACANIQUEL_PUP_G);
        abrirCenaOuModal(blocoImg.getIndicePupAtual(), 1);
    }

    private void abrirCenaOuModal(int indiceAtual, int precoFicha)
    {
        if (PlayerPrefsFichas.possueFichas(Ficha.BRONZE, precoFicha))
        {
            PlayerPrefsFichas.consumirFicha(Ficha.BRONZE, precoFicha);
            PlayerPrefsPup.salvarIndicePup(indiceAtual);
            CenaUtils.irParaCenaMainGame();
        }
        else
        {
            modalNoFicha.ligar();
        }
    }
}
