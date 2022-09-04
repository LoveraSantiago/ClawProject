using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class GrupoBtnBaloesMapa : AcaoBotaoMapaAcionado.ProdutorEvento
{
    private BtnBalaoMapa[] btnsMapasBaloes;
    private ProdutorDeEvento<int> produtorDeEvento;

    public GrupoBtnBaloesMapa(BalaoLevelBtnDto[] baloesLevelBtnDto)
    {        
        inicializarBotoesBaloesMapas(baloesLevelBtnDto);
        produtorDeEvento = new ProdutorDeEvento<int>();
    }

    private void inicializarBotoesBaloesMapas(BalaoLevelBtnDto[] baloesLevelBtnDto)
    {
        btnsMapasBaloes = new BtnBalaoMapa[baloesLevelBtnDto.Length];
        for (int contador = 0; contador < baloesLevelBtnDto.Length; contador++)
        {
            btnsMapasBaloes[contador] = new BtnBalaoMapa(baloesLevelBtnDto[contador]);
            baloesLevelBtnDto[contador].BtnLevel.onClick.AddListener(() => cliqueAcionado());
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

    public IEnumerator coroutineZommarBaloes(WrapperLevelMapDto evento, float delay)
    {
        if (evento.isAberto)
        {
            for (int contador = 0; contador < btnsMapasBaloes.Length; contador++)
            {
                btnsMapasBaloes[contador].zoomarBalaoMais();
                yield return new WaitForSeconds(delay);
            }
        }
        yield return null;
    }

    private void cliqueAcionado()
    {
        GameObject go = EventSystem.current.currentSelectedGameObject;
        produtorDeEvento.produziuEvento(int.Parse(go.name));
    }

    ProdutorDeEvento<int> ProdutorConsumidoresDeEvento<int>.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
