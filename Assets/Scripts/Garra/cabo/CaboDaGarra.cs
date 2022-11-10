using System.Collections.Generic;
using UnityEngine;

public class CaboDaGarra 
{    
    private SegmentoCabo[] segmentos;   

    public CaboDaGarra(CaboGarraDto caboDto)
    {
        Dictionary<string, string> dicionarioDeCores = ContextoEstaticoUtils.level.getDicionarioDeCores();
        string corHex = dicionarioDeCores[ConstantesCoresMaquina.CABO_DA_GARRA];
        Color cor = CorUtils.getCorByHex(corHex);
        caboDto.LineRenderer.startColor = cor;
        caboDto.LineRenderer.endColor = cor;
    }

    public void start(CaboGarraDto caboDto)
    {
        SegmentoCabo.configurarLimiteHorizontalMinimo(caboDto.TransfInicioCabo.localPosition.x);
        definirGrossuraDoCabo(caboDto);

        Vector3[] posicoes = new Vector3[caboDto.LineRenderer.positionCount];
        caboDto.LineRenderer.GetPositions(posicoes);

        segmentos = new SegmentoCabo[posicoes.Length];
        for (int contador = 0; contador < posicoes.Length; contador++)
        {
            segmentos[contador] = new SegmentoCabo(posicoes[contador]);            
        }
    }

    public void update(CaboGarraDto caboDto)
    {
        desenharCabo(caboDto);
    }

    public void fixedUpdate(CaboGarraDto caboDto, Transform posicaoGarra)
    {
        simularGravidade(caboDto, posicaoGarra);
    }

    private void definirGrossuraDoCabo(CaboGarraDto caboDto)
    {
        caboDto.LineRenderer.startWidth = caboDto.GrossuraLinha;
        caboDto.LineRenderer.endWidth   = caboDto.GrossuraLinha;
    }

    private void desenharCabo(CaboGarraDto caboDto)
    {
        Vector3[] posicoes = new Vector3[segmentos.Length];
        for (int contador = 0; contador < posicoes.Length; contador++)
        {
            posicoes[contador] = segmentos[contador].posNow;
        }

        caboDto.LineRenderer.positionCount = posicoes.Length;
        caboDto.LineRenderer.SetPositions(posicoes);
    }

    private void simularGravidade(CaboGarraDto caboDto, Transform posicaoGarra)
    {
        Vector2 gravidade = new Vector2(0f, -1f);
        for (int contador = 0; contador < segmentos.Length; contador++)
        {
            SegmentoCabo primeiroSegmento = segmentos[contador];
            Vector2 velocity = primeiroSegmento.posNow - primeiroSegmento.posOld;
            primeiroSegmento.setPosOld(primeiroSegmento.posNow);
            primeiroSegmento.addPosNow(velocity);
            primeiroSegmento.addPosNow(gravidade * Time.fixedDeltaTime);
            segmentos[contador] = primeiroSegmento;
        }

        esticarSegmentos(caboDto, posicaoGarra);
    }

    private void esticarSegmentos(CaboGarraDto caboDto, Transform posicaoGarra)
    {
        SegmentoCabo primeiroSegmento = segmentos[0];
        primeiroSegmento.setPosNow(caboDto.TransfInicioCabo.position);
        segmentos[0] = primeiroSegmento;

        SegmentoCabo.configurarLimiteHorizontalMaximo(posicaoGarra.position.x);
        SegmentoCabo ultimoSegmento = segmentos[segmentos.Length - 1];
        Vector3 posicao = posicaoGarra.position;
        
        ultimoSegmento.setPosNow(posicao);

        segmentos[segmentos.Length - 1] = ultimoSegmento;

        for (int contador = 0; contador < segmentos.Length - 1; contador++)
        {
            SegmentoCabo segmentoAtual  = segmentos[contador];
            SegmentoCabo segmentoProximo = segmentos[contador + 1];

            float dist = (segmentoAtual.posNow - segmentoProximo.posNow).magnitude;
            float error = Mathf.Abs(dist - caboDto.TamanhoSegmento);
            Vector2 direcao = Vector2.zero;

            if (dist > caboDto.TamanhoSegmento)
            {
                direcao = (segmentoAtual.posNow - segmentoProximo.posNow).normalized;
            }
            else if (dist < caboDto.TamanhoSegmento)
            {
                direcao = (segmentoProximo.posNow - segmentoAtual.posNow).normalized;
            }

            Vector2 ajuste = direcao * error;
            if (contador != 0)
            {
                segmentoAtual.subPosNow(ajuste * 0.5f);
                segmentos[contador] = segmentoAtual;
                segmentoProximo.addPosNow(ajuste * 0.5f);
                segmentos[contador + 1] = segmentoProximo;
            }
            else
            {
                segmentoProximo.addPosNow(ajuste);
                segmentos[contador + 1] = segmentoProximo;
            }
        }
    }
}
