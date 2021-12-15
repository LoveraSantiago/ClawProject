using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MontadorBlocoImgFamilia 
{
    public void montarBlocoImagemComFamilia(BlocoImgColetaveisDto blocoImgsDto, ColetavelEntidade.FAMILIA familia)
    {
        blocoImgsDto.LblNomeFamilia.text = familia.ToString();

        HelperColetavelEntidade helperColetavel = new HelperColetavelEntidade();
        List<ColetavelEntidade> coletaveis = helperColetavel.getListaDeColetaveisEntidadeByFamilia(familia);

        for (int contador = 0; contador < coletaveis.Count; contador++)
        {
            string nomeSprite = coletaveis[contador].nomeSprite;
            Sprite sprIt = helperColetavel.getSpriteColetavelByNomeSprite(nomeSprite);

            Image imageIt = blocoImgsDto.GrupoImgColetaveis[contador];
            imageIt.sprite = sprIt;

            ColetavelEntidade coletavelIt = helperColetavel.getColetavelEntidadeBySprite(sprIt.name);

            if (PlayerPrefsColetaveis.isFamiliaNotLocked(familia.ToString()))
            {
                if (PlayerPrefsColetaveis.isColetavelIndisponivel(coletavelIt.nome))
                {
                    Material matGray = MaterialGrayScale.of(sprIt);                        
                    imageIt.material = matGray;
                }
                imageIt.color = Color.white;
            }
            else
            {
                imageIt.color = Color.black;
                imageIt.material = null;
            }
        }
    }
}
