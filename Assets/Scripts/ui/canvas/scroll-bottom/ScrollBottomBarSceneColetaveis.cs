using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScrollBottomBarSceneColetaveis : ScrollBottomBar,
                                              AcaoBBarPupEscolhido<int>.ProdutorEvento
{
    private ProdutorDeEvento<int> produtorDeIndiceEscolhido;

    public ScrollBottomBarSceneColetaveis(
        GameObject prefabBottomBar,
        ColetavelEntidade.FAMILIA[] familias,
        Dictionary<string, Sprite> dicionarioDeSprites) 
        : base(prefabBottomBar, new Temporaria(familias, dicionarioDeSprites))
    {
        produtorDeIndiceEscolhido = new ProdutorDeEvento<int>();
    }

    protected override void cliqueBoxAcionado(TextMeshProUGUI lblQtd)
    {
        throw new System.NotImplementedException();
    }    

    ProdutorDeEvento<int> AcaoBBarPupEscolhido<int>.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeIndiceEscolhido;
    }

    class Temporaria : ItemsBottomBar
    {
        private ColetavelEntidade.FAMILIA[] familias;
        private Dictionary<string, Sprite> dicionarioDeSprites;

        public Temporaria(ColetavelEntidade.FAMILIA[] familias, Dictionary<string, Sprite> dicionarioDeSprites)
        {
            this.familias = familias;
            this.dicionarioDeSprites = dicionarioDeSprites;
        }

        public string getLabelQtdDoItemIndice(int indice)
        {
            ColetavelEntidade.FAMILIA familia = familias[indice];            
            if (PlayerPrefsColetaveis.isFamiliaLocked(familia.ToString()))
            {
                return "Locked";
            }
            else if(PlayerPrefsColetaveis.isAllFamiliaComColetaveisDisponiveis(familia))            
            {
                return "Ok";
            }
            else
            {
                return "Nok";
            }
        }

        public int getQtdItems()
        {
            return familias.Length;
        }

        public Sprite getSprDoItemIndice(int indice)
        {
            ColetavelEntidade.FAMILIA familia = familias[indice];

            ColetavelHelper coletavelHelper = new ColetavelHelper();
            List<ColetavelEntidade> coletaveisDaFamilia = coletavelHelper.getListaDeColetaveisEntidadeByFamilia(familia);
            ColetavelEntidade coletavelEntidade = coletaveisDaFamilia[0];
            return dicionarioDeSprites[coletavelEntidade.nomeSprite];
        }
    }
}
