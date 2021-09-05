using System.Collections.Generic;
using UnityEngine;

public class VigasTras : ArcoIrisConjunto
{
    private VigasDto vigasDto;
    private MaterialGlow materialGlowVigaEsquerda;
    private MaterialGlow materialGlowVigaDireita;

    public VigasTras(VigasDto vigasDto)
    {
        this.vigasDto = vigasDto;
        materialGlowVigaEsquerda = new MaterialGlow(vigasDto.SprVigasTrasEsquerdaEfeito.material);
        materialGlowVigaDireita = new MaterialGlow(vigasDto.SprVigasTrasDireitaEfeito.material);
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
        materialGlowVigaEsquerda.setCorNoMaterial(cor);
        materialGlowVigaDireita.setCorNoMaterial(cor);
    }
}
