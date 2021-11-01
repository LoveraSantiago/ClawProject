using System.Collections.Generic;
using UnityEngine;

public class VigasTras : ArcoIrisConjunto
{
    private VigasDto vigasDto;    
    private MaterialGlow materialGlowVigaDireita;

    public VigasTras(VigasDto vigasDto)
    {
        this.vigasDto = vigasDto;      
        materialGlowVigaDireita = new MaterialGlow(vigasDto.SprVigasTrasDireitaEfeito.material);
    }

    public void configuradoPeloLevel(Dictionary<string, string> dicionarioDeCores)
    {
        string corHex = dicionarioDeCores[ConstantesCoresMaquina.VIGA_TRAS];
        Color cor = Utils.getCorByHex(corHex);
        vigasDto.VigaTrasDireita.color = cor;
    }

    public void desligar()
    {
        vigasDto.VigaTrasDireitaEfeito.SetActive(false);
    }

    public void ligar()
    {
        vigasDto.VigaTrasDireitaEfeito.SetActive(true);
    }

    public void passarCor(Color cor)
    {       
        materialGlowVigaDireita.setCorNoMaterial(cor);
    }
}
