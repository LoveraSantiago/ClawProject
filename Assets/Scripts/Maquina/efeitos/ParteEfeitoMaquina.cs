using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ParteEfeitoMaquina : ArcoIrisConjunto
{
    private ParteEfeitoDto parteEfeitoDto;

    protected ParteEfeitoMaquina(ParteEfeitoDto parteEfeitoDto)
    {
        this.parteEfeitoDto = parteEfeitoDto;
    }

    public void configuradoPeloLevel(Dictionary<string, string> dicionarioDeCores)
    {
        string nomeParteMaquina = getNomeParteMaquina();
        string corHex = dicionarioDeCores[nomeParteMaquina];
        Color cor = Utils.getCorByHex(corHex);
        cor.a = getTransparencia();
        parteEfeitoDto.SprRenderColorir.color = cor;
    }

    protected abstract string getNomeParteMaquina();
    
    protected virtual float getTransparencia()
    {
        return 1;
    }
}
