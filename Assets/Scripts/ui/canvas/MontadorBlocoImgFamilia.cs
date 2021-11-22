using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MontadorBlocoImgFamilia 
{
    public void montarBlocoImagemComFamilia(BlocoImgColetaveisDto blocoImgsDto, ColetavelEntidade.FAMILIA familia)
    {
        blocoImgsDto.LblNomeFamilia.text = familia.ToString();

        ColetavelHelper coletavelHelper = new ColetavelHelper();
        List<ColetavelEntidade> coletaveis = coletavelHelper.getListaDeColetaveisEntidadeByFamilia(familia);

        for (int contador = 0; contador < coletaveis.Count; contador++)
        {
            string nomeSprite = coletaveis[contador].nomeSprite;
            Sprite sprIt = coletavelHelper.getSpriteColetavelByNomeSprite(nomeSprite);

            Image imageIt = blocoImgsDto.GrupoImgColetaveis[contador];
            imageIt.sprite = sprIt;

            ColetavelEntidade coletavelIt = coletavelHelper.getColetavelEntidadeBySprite(sprIt.name);

            if (PlayerPrefsColetaveis.isFamiliaNotLocked(familia.ToString()))
            {
                if (PlayerPrefsColetaveis.isColetavelIndisponivel(coletavelIt.nome))
                {
                    Material matGray = new Material(Utils.materialGrayScale);
                    matGray.SetTexture("main_text", sprIt.texture);
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
