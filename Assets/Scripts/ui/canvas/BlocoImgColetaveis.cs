using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlocoImgColetaveis 
{
    private Image[] grupoColetaveis;
    private NavegacaoDeArray<ColetavelEntidade.FAMILIA> controleFamilia;

    public BlocoImgColetaveis(Dictionary<string, Sprite> dicionarioDeSprites, Image[] grupoColetaveis)
    {
        this.grupoColetaveis = grupoColetaveis;

        ColetavelEntidade.FAMILIA[] familias = { ColetavelEntidade.FAMILIA.FRUTAS,
                                                 ColetavelEntidade.FAMILIA.FAKE };

        controleFamilia = new NavegacaoDeArray<ColetavelEntidade.FAMILIA>(familias, 0);

        ColetavelHelper coletavelHelper = new ColetavelHelper();
        List<ColetavelEntidade> coletaveis = coletavelHelper.getListaDeColetaveisEntidadeByFamilia(familias[0]);
        for (int contador = 0; contador < coletaveis.Count; contador++)
        {
            grupoColetaveis[contador].sprite = dicionarioDeSprites[coletaveis[contador].nomeSprite];
        }
    }
}
