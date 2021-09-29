using UnityEngine;

public class LinhaModalPontos 
{
    private LinhaModalPontosDto linhasDto;

    public LinhaModalPontos(LinhaModalPontosDto linhasDto)
    {
        this.linhasDto = linhasDto;
    }

    public void passarInfos(string label1, Sprite spr, string label2)
    {
        linhasDto.LblText1.text = label1;
        linhasDto.ImgLinha.sprite = spr;
        linhasDto.LblText2.text = label2;
    }   

    public void desligar()
    {
        linhasDto.GoLinha.SetActive(false);
    }

    public void ligar()
    {
        linhasDto.GoLinha.SetActive(true);
    }
}
