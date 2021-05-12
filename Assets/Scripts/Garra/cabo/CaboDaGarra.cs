using System.Collections.Generic;
using UnityEngine;

public class CaboDaGarra 
{
    private CaboGarraDto caboDto;
    private Transform posicaoGarra;

    private List<SegmentoCabo> listaDeSegmentos;//TODO tentar trocar por um array
    private Vector3 ropeStartPoint;

    public CaboDaGarra(CaboGarraDto caboGarraDto, Transform posicaoGarra)
    {
        this.caboDto = caboGarraDto;
        this.posicaoGarra = posicaoGarra;

        listaDeSegmentos = new List<SegmentoCabo>();
    }

    public void start()
    {
        SegmentoCabo.configurarLimiteHorizontalMinimo(caboDto.TransfInicioCabo.localPosition.x);
        definirGrossuraDoCabo();

        Vector3[] posicoes = new Vector3[caboDto.LineRenderer.positionCount];
        caboDto.LineRenderer.GetPositions(posicoes);

        for(int contador = 0; contador < posicoes.Length; contador++)
        {
            listaDeSegmentos.Add(new SegmentoCabo(posicoes[contador]));            
        }
    }

    public void update()
    {
        desenharCabo();
    }

    public void fixedUpdate()
    {
        simularGravidade();
    }

    private void definirGrossuraDoCabo()
    {
        caboDto.LineRenderer.startWidth = caboDto.GrossuraLinha;
        caboDto.LineRenderer.endWidth   = caboDto.GrossuraLinha;
    }

    private void desenharCabo()
    {
        Vector3[] posicoes = new Vector3[listaDeSegmentos.Count];
        for (int contador = 0; contador < posicoes.Length; contador++)
        {
            posicoes[contador] = listaDeSegmentos[contador].posNow;
        }

        caboDto.LineRenderer.positionCount = posicoes.Length;
        caboDto.LineRenderer.SetPositions(posicoes);
    }

    private void simularGravidade()
    {
        Vector2 gravidade = new Vector2(0f, -1f);
        for (int contador = 0; contador < listaDeSegmentos.Count; contador++)
        {
            SegmentoCabo primeiroSegmento = listaDeSegmentos[contador];
            Vector2 velocity = primeiroSegmento.posNow - primeiroSegmento.posOld;
            primeiroSegmento.setPosOld(primeiroSegmento.posNow);
            primeiroSegmento.addPosNow(velocity);
            primeiroSegmento.addPosNow(gravidade * Time.fixedDeltaTime);
            listaDeSegmentos[contador] = primeiroSegmento;
        }

        esticarSegmentos();
    }

    private void esticarSegmentos()
    {
        SegmentoCabo primeiroSegmento = listaDeSegmentos[0];
        primeiroSegmento.setPosNow(caboDto.TransfInicioCabo.position);
        listaDeSegmentos[0] = primeiroSegmento;

        SegmentoCabo.configurarLimiteHorizontalMaximo(posicaoGarra.position.x);
        SegmentoCabo ultimoSegmento = listaDeSegmentos[listaDeSegmentos.Count - 1];
        Vector3 posicao = posicaoGarra.position;
        
        ultimoSegmento.setPosNow(posicao);

        listaDeSegmentos[listaDeSegmentos.Count - 1] = ultimoSegmento;

        for (int contador = 0; contador < listaDeSegmentos.Count - 1; contador++)
        {
            SegmentoCabo segmentoAtual  = listaDeSegmentos[contador];
            SegmentoCabo segmentoProximo = listaDeSegmentos[contador + 1];

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
                listaDeSegmentos[contador] = segmentoAtual;
                segmentoProximo.addPosNow(ajuste * 0.5f);
                listaDeSegmentos[contador + 1] = segmentoProximo;
            }
            else
            {
                segmentoProximo.addPosNow(ajuste);
                listaDeSegmentos[contador + 1] = segmentoProximo;
            }
        }
    }
}
