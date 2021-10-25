using UnityEngine;
using UnityEngine.UI;

public class Preenchedor 
{

    public void colocarSprite(GameObject go, Sprite sprite)
    {
        go.GetComponent<SpriteRenderer>().sprite = sprite;
        go.transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    public void colocarSprVazio(GameObject go, Sprite spriteVazio)
    {
        colocarSprite(go, spriteVazio);
    }

    public void resetText(Text text)
    {
        text.text = "00";
    }

    public void colocarTexto(NavegacaoPeloBoard navegacao, int novoValor, Sprite spriteVazio)
    {
        //Debug.Log("Troca de texto chamada");
        GameObject go = navegacao.getGoDaMira();
        Sprite spr = go.GetComponent<SpriteRenderer>().sprite;
        if (spr != null && !spr.name.Equals(spriteVazio.name))
        {
            Text text = navegacao.getTextDaMira();
            text.text = novoValor.ToString();
            //Debug.Log("Troca de texto realizada no text " + text.gameObject.name);
        }
        else
        {
            //Debug.Log("Troca de texto NAO realizada");
        }
    }
}
