using UnityEngine;

public class BombaExplosaoHit 
{
    public void acertar(Vector3 posicaoBomba, PowerUpDto powerUpDto)
    {


        LayerMask mask = LayerMask.GetMask(UtilsTags.TAG_LAYER_COLETAVEL);
        Collider2D[] acertados = Physics2D.OverlapCircleAll(posicaoBomba, powerUpDto.BombaDto.RaioExplosao, mask);
        HelperColetaveisInGame helperInGame = new HelperColetaveisInGame();

        for (int contador = 0; contador < acertados.Length; contador++)
        {
            string nomeAcertado = acertados[contador].name;
            Coletavel acertado = helperInGame.getColetavelInGameByGoName(nomeAcertado);
            int angulo = determinarAngulo(posicaoBomba, acertado.getPosicao(), powerUpDto);
            acertado.disparar(angulo, powerUpDto.BombaDto.VelocidadeHit);
        }
    }

    private int determinarAngulo(Vector3 posicaoBomba, Vector3 posicaoAcertado, PowerUpDto powerUpDto)
    {
        if (posicaoBomba.x < posicaoAcertado.x) return -powerUpDto.BombaDto.AnguloHit;
        else return powerUpDto.BombaDto.AnguloHit;
    }
}
