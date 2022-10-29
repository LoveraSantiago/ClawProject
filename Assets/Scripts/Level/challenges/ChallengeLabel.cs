using UnityEngine;

public class ChallengeLabel 
{
    public string conteudo { get; private set; }
    public bool temImg1 { get { return img1 != null; } }
    public bool temImg2 { get { return img2 != null; } }
    public bool temImg3 { get { return img3 != null; } }
    public Sprite img1 { get; private set; }
    public Sprite img2 { get; private set; }
    public Sprite img3 { get; private set; }

    public ChallengeLabel(string conteudo)
    {
        addConteudo(conteudo);
    }

    public void addConteudo(string conteudo)
    {
        this.conteudo = conteudo;
    }

    public void addIgms(Sprite img1, Sprite img2, Sprite img3)
    {
        this.img1 = img1;
        this.img2 = img2;
        this.img3 = img3;
    }
}
