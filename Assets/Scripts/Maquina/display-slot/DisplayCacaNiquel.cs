using System.Collections;
using UnityEngine;

public class DisplayCacaNiquel : AcaoCacaNiquel.ProdutorEvento
{
    private bool acionarCacaNiquel;
    private ProdutorDeEvento<Vazio> produtorDeEvento;
    private InputGame inputGame;

    public DisplayCacaNiquel(InputGame inputGame)
    {
        this.inputGame = inputGame;
        produtorDeEvento = new ProdutorDeEvento<Vazio>();
    }

    public void configuradoPeloLevel(AbstractLevel.TIPO_GAME tipoGame)
    {        
        if(tipoGame == AbstractLevel.TIPO_GAME.CACANIQUEL_PUP)
        {
            acionarCacaNiquel = true;            
        }
    }

    public void iniciar(GrupoDisplays grupoDisplays)
    {
        if (acionarCacaNiquel)
        {
            Utils.MonoBehaviour.StartCoroutine(iniciarDisplayCacaNiquel(grupoDisplays));
        }
    }

    private IEnumerator iniciarDisplayCacaNiquel(GrupoDisplays grupoDisplays)
    {
        yield return new WaitForSeconds(0.5f);
        produtorDeEvento.produziuEvento(new Vazio());
        grupoDisplays.ligarGlowLuz();

        int indicePup = PlayerPrefsUtils.recuperarIndicePup();
        PowerUpEntidade pupEscolhido = FactoryPowerUpEntidade.getPowerUpFromIndice(indicePup);

        Sprite[] spritesSlot1 = new Sprite[] { pupEscolhido.sprPowerUp, grupoDisplays.displaysSlotsDto.SprVazio };
        Sprite[] spritesSlot2 = new Sprite[] { pupEscolhido.sprPowerUp, grupoDisplays.displaysSlotsDto.SprVazio };
        Sprite[] spritesSlot3 = new Sprite[] { pupEscolhido.sprPowerUp, grupoDisplays.displaysSlotsDto.SprVazio, grupoDisplays.displaysSlotsDto.SprMoeda };

        grupoDisplays.ligarCacaNiquel(spritesSlot1, spritesSlot2, spritesSlot3);
        yield return new WaitForSeconds(0.1f);

        int clicado = 0;
        Sprite[][] allSrites = new Sprite[][] { spritesSlot1, spritesSlot2, spritesSlot3 };
        while(clicado < 3)
        {
            if (inputGame.aconteceuTap())
            {                
                grupoDisplays.desligarCacaNiquel(clicado, allSrites[clicado]);
                clicado++;
            }            
            yield return null;
        }
    }

    ProdutorDeEvento<Vazio> AcaoCacaNiquel.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
