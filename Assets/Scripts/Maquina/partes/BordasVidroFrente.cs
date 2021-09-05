using System.Collections.Generic;
using UnityEngine;

public class BordasVidroFrente : ArcoIrisConjunto
{
    private BordasFrenteDto bordasDto;
    private MaterialGlow materialGlow;

    public BordasVidroFrente(BordasFrenteDto bordasDto)
    {
        this.bordasDto = bordasDto;
        materialGlow = new MaterialGlow(bordasDto.SprBordaVidroEfeito.material);
    }

    public void configuradoPeloLevel(Dictionary<string, string> dicionarioDeCores)
    {
        string corHex = dicionarioDeCores[ConstantesCoresMaquina.BORDA_VIDRO];
        bordasDto.SprBordaVidro.color = Utils.getCorByHex(corHex);
    }

    public void desligar()
    {
        bordasDto.BordaVidroEfeito.SetActive(false);
    }

    public void ligar()
    {
        bordasDto.BordaVidroEfeito.SetActive(true);
    }

    public void passarCor(Color cor)
    {
        materialGlow.setCorNoMaterial(cor);
    }
}
