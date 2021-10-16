using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlocoImgColetaveis 
{
    private Image[] grupoImgColetaveis;
    private NavegacaoDeArray<ColetavelEntidade.FAMILIA> controleFamilia;

    public BlocoImgColetaveis(
        Dictionary<string, Sprite> dicionarioDeSprites, BlocoImgColetaveisDto blocoImgsDto)
    {
        this.grupoImgColetaveis = blocoImgsDto.GrupoImgColetaveis;

        ColetavelEntidade.FAMILIA[] familias = { ColetavelEntidade.FAMILIA.FRUTAS,
                                                 ColetavelEntidade.FAMILIA.FAKE };

        controleFamilia = new NavegacaoDeArray<ColetavelEntidade.FAMILIA>(familias, 0);

        ColetavelHelper coletavelHelper = new ColetavelHelper();
        List<ColetavelEntidade> coletaveis = coletavelHelper.getListaDeColetaveisEntidadeByFamilia(familias[0]);
        for (int contador = 0; contador < coletaveis.Count; contador++)
        {
            grupoImgColetaveis[contador].sprite = dicionarioDeSprites[coletaveis[contador].nomeSprite];
        }
    }
}
