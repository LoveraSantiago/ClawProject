using UnityEngine;

public class BombaExplosaoHit 
{
    private HelperGaiolasInGame gaiolasInGame;
    private HelperColetaveisInGame coletaveisInGame;

    public BombaExplosaoHit()
    {
        gaiolasInGame    = new HelperGaiolasInGame();
        coletaveisInGame = new HelperColetaveisInGame();
    }

    public void acertar(Vector3 posicaoBomba, PowerUpDto powerUpDto)
    {
        acertarColetaveis(posicaoBomba, powerUpDto);
        acertarGaiolas(posicaoBomba, powerUpDto);       
    }

    private void acertarColetaveis(Vector3 posicaoBomba, PowerUpDto powerUpDto)
    {
        Collider2D[] acertados = acertarAlvos(posicaoBomba, powerUpDto, TagUtils.TAG_LAYER_COLETAVEL);                    

        for (int contador = 0; contador < acertados.Length; contador++)
        {
            string nomeAcertado = acertados[contador].name;
            Coletavel acertado = coletaveisInGame.getColetavelInGameByGoName(nomeAcertado);
            if (acertado.isLivre())
            {
                int angulo = determinarAngulo(posicaoBomba, acertado.getPosicao(), powerUpDto);
                acertado.disparar(angulo, powerUpDto.BombaDto.VelocidadeHit);
            }
        }
    }

    private void acertarGaiolas(Vector3 posicaoBomba, PowerUpDto powerUpDto)
    {
        Collider2D[] acertados = acertarAlvos(posicaoBomba, powerUpDto, TagUtils.LAYER_GAIOLA);        

        for (int contador = 0; contador < acertados.Length; contador++)
        {
            string nomeAcertado = acertados[contador].name;
            Gaiola gaiola = gaiolasInGame.getGaiolaInGameByGoName(nomeAcertado);
            gaiola.desligar();
            if (gaiola.isNaoVazia())
            {
                Coletavel coletavelPreso = coletaveisInGame.getColetavelInGameByGoName(gaiola.coletavelPreso);
                coletavelPreso.colocarNoLayerNormal();
            }
        }
    }

    private Collider2D[] acertarAlvos(Vector3 posicaoBomba, PowerUpDto powerUpDto, string mascara)
    {
        LayerMask mask = LayerMask.GetMask(mascara);
        Collider2D[] acertados = Physics2D.OverlapCircleAll(posicaoBomba, powerUpDto.BombaDto.RaioExplosao, mask);
        return acertados;
    }

    private int determinarAngulo(Vector3 posicaoBomba, Vector3 posicaoAcertado, PowerUpDto powerUpDto)
    {
        if (posicaoBomba.x < posicaoAcertado.x) return -powerUpDto.BombaDto.AnguloHit;
        else return powerUpDto.BombaDto.AnguloHit;
    }
}
