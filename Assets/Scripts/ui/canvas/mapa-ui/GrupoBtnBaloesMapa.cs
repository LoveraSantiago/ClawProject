using System.Collections;
using UnityEngine;

public class GrupoBtnBaloesMapa
{
    private BtnBalaoMapa[] btnsMapasBaloes;

    public GrupoBtnBaloesMapa(BalaoLevelBtnDto[] baloesLevelBtnDto)
    {        
        inicializarBotoesBaloesMapas(baloesLevelBtnDto);
    }

    private void inicializarBotoesBaloesMapas(BalaoLevelBtnDto[] baloesLevelBtnDto)
    {
        btnsMapasBaloes = new BtnBalaoMapa[baloesLevelBtnDto.Length];
        for (int contador = 0; contador < baloesLevelBtnDto.Length; contador++)
        {
            btnsMapasBaloes[contador] = new BtnBalaoMapa(baloesLevelBtnDto[contador]);
        }
    }

    public void dismissBotoesBaloes()
    {
        for (int contador = 0; contador < btnsMapasBaloes.Length; contador++)
        {
            btnsMapasBaloes[contador].zoomarBalaoMenos();
        }
    }

    public void posicionarBaloes(WrapperLevelMapDto evento)
    {
        Vector2[] posicoes = evento.levelMapDto.Posicoes;
        if (evento.isAberto)
        {
            for (int contador = 0; contador < btnsMapasBaloes.Length; contador++)
            {
                btnsMapasBaloes[contador].colocarNaPosicao(posicoes[contador]);
            }
        }
    }

    public IEnumerator coroutineZommarBaloes(WrapperLevelMapDto evento)
    {
        if (evento.isAberto)
        {
            for (int contador = 0; contador < btnsMapasBaloes.Length; contador++)
            {
                btnsMapasBaloes[contador].zoomarBalaoMais();
                yield return new WaitForSeconds(levelMapaUiDto.DelayEntreBaloes);
            }
        }
        yield return null;
    }
}
