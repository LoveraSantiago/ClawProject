using UnityEngine;

public class BoardMontadorElevadorNormal : BoardMontadorNormal
{
    private GameObject goParent;

    public BoardMontadorElevadorNormal(GameObject goParent)
    {
        this.goParent = goParent;
    }

    protected override Coletavel criarColetavel(string nomeSprite, Vector3 posicao)
    {
        return HelperColetaveisInGame.criarColetavel(nomeSprite, posicao, goParent);
    }
}
