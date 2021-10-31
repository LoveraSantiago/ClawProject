using System.Collections.Generic;
using UnityEngine;

public class BordasVidroFrente : ParteEfeitoMaquina
{
    private BordasFrenteDto bordasDto;
    private MaterialGlow materialGlow;

    public BordasVidroFrente(BordasFrenteDto bordasDto)
        :base(bordasDto)
    {
        this.bordasDto = bordasDto;
        materialGlow = new MaterialGlow(bordasDto.SprBordaVidroEfeito.material);
    }   

    protected override string getNomeParteMaquina()
    {
        return ConstantesCoresMaquina.BORDA_VIDRO;
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
