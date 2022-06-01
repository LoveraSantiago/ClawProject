using UnityEngine;

public class ColorivelMesaJoystick
{
    private GameObject goMesaCima;
    private GameObject goMesaBaixo;

    private FinderComponente finder;

    public ColorivelMesaJoystick(FinderComponente finder)
    {
        this.finder = finder;
        GameObject goMesa = finder.findNaMaquina("mesa-joystick");
        goMesaCima  = finder.findNoComponente(goMesa, ConstantesCoresMaquinaV2.JOYSTICK_MESA_CIMA);
        goMesaBaixo = finder.findNoComponente(goMesa, ConstantesCoresMaquinaV2.JOYSTICK_MESA_BAIXO);
    }


    public ComponenteColorivel getMesaCima()
    {
        return new SingleCompColorivel(goMesaCima);
    }

    public ComponenteColorivel getMesaBaixo()
    {   
        return new SingleCompColorivel(goMesaBaixo);
    }

    public ComponenteColorivel getJoystickSuporte()
    {
        GameObject goJoystick = getGoJoystick();
        GameObject goSuporte = finder.findNoComponente(goJoystick, ConstantesCoresMaquinaV2.JOYSTICK_SUPORTE);
        return new SingleCompColorivel(goSuporte);
    }

    public ComponenteColorivel getJoystickHaste()
    {   
        GameObject goJoystick = getGoJoystick();
        GameObject goHaste = finder.findNoComponente(goJoystick, ConstantesCoresMaquinaV2.JOYSTICK_HASTE);
        return new SingleCompColorivel(goHaste);
    }

    public ComponenteColorivel getJoystickBola()
    {
        GameObject goJoystick = getGoJoystick();
        GameObject goHaste = finder.findNoComponente(goJoystick, ConstantesCoresMaquinaV2.JOYSTICK_HASTE);
        GameObject goBola = finder.findNoComponente(goHaste, ConstantesCoresMaquinaV2.JOYSTICK_BOLA);
        return new SingleCompColorivel(goBola);
    }

    public ComponenteColorivel getJoystickBtnSuporte()
    {
        GameObject goBotaoJoystick = getBotaoJoystick();
        GameObject goSuporte = finder.findNoComponente(goBotaoJoystick, ConstantesCoresMaquinaV2.JOYSTICK_BTN_SUPORTE);
        return new SingleCompColorivel(goSuporte);
    }

    public ComponenteColorivel getJoystickBtn()
    {
        GameObject goBotaoJoystick = getBotaoJoystick();        
        return new SingleCompColorivel(goBotaoJoystick);
    }

    public ComponenteColorivel getOrificioFicha()
    {
        GameObject goFicha = finder.findNoComponente(goMesaBaixo, ConstantesCoresMaquinaV2.ORIFICIO_FICHA);
        return new SingleCompColorivel(goFicha);
    }

    public ComponenteColorivel getOrificioCard()
    {
        GameObject goCard = finder.findNoComponente(goMesaBaixo, ConstantesCoresMaquinaV2.ORIFICIO_CARD);
        return new SingleCompColorivel(goCard);
    }

    public ComponenteColorivel getOrificioTrianguloFicha()
    {
        GameObject goSeta = finder.findNoComponente(goMesaBaixo, ConstantesCoresMaquinaV2.ORIFICIO_SETA);
        return new SingleCompColorivel(goSeta);
    }

    public ComponenteColorivel getBtnPupBaseDireita()
    {
        GameObject goBtnPup = getBtnPupDireita();        
        return new SingleCompColorivel(goBtnPup);
    }

    public ComponenteColorivel getBtnPupTopoDireita()
    {
        GameObject goBtnPup = getBtnPupDireita();
        GameObject goBtnTampa = extrairBtnTampaFrom(goBtnPup);
        return new SingleCompColorivel(goBtnTampa);
    }

    public ComponenteColorivel getBtnPupBaseEsquerda()
    {
        GameObject goBtnPup = getBtnPupEsquerda();        
        return new SingleCompColorivel(goBtnPup);
    }

    public ComponenteColorivel getBtnPupTopoEsquerda()
    {
        GameObject goBtnPup = getBtnPupEsquerda();
        GameObject goBtnTampa = extrairBtnTampaFrom(goBtnPup);
        return new SingleCompColorivel(goBtnTampa);
    }   

    private GameObject getGoJoystick()
    {
        return finder.findNoComponente(goMesaCima, "joystick");
    }

    private GameObject getBotaoJoystick()
    {
        return finder.findNoComponente(goMesaCima, "botao-joystick");
    }

    private GameObject getBtnPupDireita()
    {
        return finder.findNoComponente(goMesaCima, "btn-powerup-direita");
    }

    private GameObject getBtnPupEsquerda()
    {
        return finder.findNoComponente(goMesaCima, "btn-powerup-esquerda");
    }

    private GameObject extrairBtnTampaFrom(GameObject goBtn)
    {
        return finder.findNoComponente(goBtn, "botao-tampa");
    }
}
