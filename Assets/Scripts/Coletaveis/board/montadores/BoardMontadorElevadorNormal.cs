using UnityEngine;

public class BoardMontadorElevadorNormal : BoardMontadorNormal
{
    private GameObject goParent;

    public BoardMontadorElevadorNormal(GameObject goParent)
    {
        this.goParent = goParent;
    }

    protected override Coletavel criarColetavel(Sprite sprite, Vector3 posicao)
    {
        return HelperColetaveisInGame.criarColetavel(sprite, posicao, goParent);
    }
}
