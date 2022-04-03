using System.Collections.Generic;
using UnityEngine;

public abstract class ParteEfeitoMaquinaV2 : ArcoIrisConjunto
{
    private ParteEfeitoDto parteEfeitoDto;
    private MaterialGlow materialGlow;

    protected ParteEfeitoMaquinaV2(ParteEfeitoDto parteEfeitoDto)
    {
        this.parteEfeitoDto = parteEfeitoDto;
        materialGlow = new MaterialGlow(parteEfeitoDto.SprRenderEfeito.material);
    }

    public void configuradoPeloLevel(Dictionary<string, string> dicionarioDeCores)
    {
        
    }

    protected abstract string getNomeParteMaquina();

    protected virtual float getTransparencia()
    {
        return 1;
    }

    public void desligar()
    {
        parteEfeitoDto.GoEfeito.SetActive(false);
    }

    public void ligar()
    {
        parteEfeitoDto.GoEfeito.SetActive(true);
    }

    public void passarCor(Color cor)
    {
        materialGlow.setCorNoMaterial(cor);
    }
}
