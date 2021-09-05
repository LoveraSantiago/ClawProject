using System.Collections.Generic;
using UnityEngine;

public class VigasTras : ArcoIrisConjunto
{
    private VigasDto vigasDto;
    private MaterialGlow materialGlow;

    public VigasTras(VigasDto vigasDto)
    {
        this.vigasDto = vigasDto;
        materialGlow = new MaterialGlow(vigasDto.MaterialVigas);
    }

    public void configuradoPeloLevel(Dictionary<string, string> dicionarioDeCores)
    {
        string corHex = dicionarioDeCores[ConstantesCoresMaquina.VIGA_TRAS];
        Color cor = Utils.getCorByHex(corHex);
        vigasDto.VigaTrasDireita.color = cor;
        vigasDto.VigaTrasEsquerda.color = cor;
    }

    public void desligar()
    {
        vigasDto.VigaTrasDireitaEfeito.SetActive(false);
        vigasDto.VigaTrasEsquerdaEfeito.SetActive(false);
    }

    public void ligar()
    {
        vigasDto.VigaTrasDireitaEfeito.SetActive(true);
        vigasDto.VigaTrasEsquerdaEfeito.SetActive(true);
    }

    public void passarCor(Color cor)
    {       
        materialGlow.setCorNoMaterial(cor);
    }
}
