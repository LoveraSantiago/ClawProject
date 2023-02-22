using UnityEngine;

public class ExplosaoHit 
{
    public void acertarTudo(Vector3 posicaoBomba, float raio, int anguloHit, float velocidadeHit)
    {
        acertarColetaveis(posicaoBomba, raio, anguloHit, velocidadeHit);
        acertarGaiolas(posicaoBomba, raio);       
    }

    private void acertarColetaveis(Vector3 posicaoBomba, float raio, int anguloHit, float velocidadeHit)
    {
        Collider2D[] acertados = acertarAlvos(posicaoBomba, raio, LayerUtils.LAYER_COLETAVEL_DESCRICAO);                    

        for (int contador = 0; contador < acertados.Length; contador++)
        {
            string nomeAcertado = acertados[contador].name;
            
            Coletavel acertado = HelperColetaveisInGame.getColetavelInGameByGoName(nomeAcertado);
            if (acertado.isLivre())
            {
                int angulo = determinarAngulo(posicaoBomba, acertado.getPosicao(), anguloHit);
                acertado.disparar(angulo, velocidadeHit);
            }
        }
    }

    public void acertarGaiolas(Vector3 posicaoBomba, float raio)
    {
        Collider2D[] acertados = acertarAlvos(posicaoBomba, raio, LayerUtils.LAYER_GAIOLA_DESCRICAO);        

        for (int contador = 0; contador < acertados.Length; contador++)
        {
            string nomeAcertado = acertados[contador].name;

            HelperGaiolasInGame gaiolasInGame = new HelperGaiolasInGame();
            Gaiola gaiola = gaiolasInGame.getGaiolaInGameByGoName(nomeAcertado);
            gaiola.desligarComEstado();
            //Debug.Log("Gaiola " + gaiola.nome + " coletavel " + gaiola.nomeColetavelPreso);            
        }
    }

    private Collider2D[] acertarAlvos(Vector3 posicaoBomba, float raio, string mascara)
    {
        LayerMask mask = LayerMask.GetMask(mascara);
        Collider2D[] acertados = Physics2D.OverlapCircleAll(posicaoBomba, raio, mask);
        return acertados;
    }

    private int determinarAngulo(Vector3 posicaoBomba, Vector3 posicaoAcertado, int anguloHit)
    {
        if (posicaoBomba.x < posicaoAcertado.x) return -anguloHit;
        else return anguloHit;
    }
}
