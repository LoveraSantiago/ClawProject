using UnityEngine;

public abstract class GO : ComponenteRigidBodyDeGO
{  
    public GO(Transform transform, string nome)
        :base(transform.gameObject)
    {
        carregarSpriteRenderer();
        carregarRigidBody();
        setNome(nome);                
    }

    public GO(
        Transform transform,
        Transformador<GameObject, SpriteRenderer> getGoComSprRenderer, 
        string nome)
       : base(transform.gameObject)
    {
        carregarSpriteRenderer(getGoComSprRenderer.transformar(getGo()));
    }

    public GO(GOContexto contextoGO, string nome)
        :this(GameObject.Instantiate(
                contextoGO.mainGO, 
                contextoGO.mainGO.transform.position, 
                Quaternion.Euler(Vector3.zero), 
                contextoGO.mainGOParent).transform, 
              nome){}   

    public GO(GOContexto contextoGO, 
              Transformador<GameObject, SpriteRenderer> getGoComSprRenderer, 
              string nome)
        :this(contextoGO, nome)
    {       
        carregarSpriteRenderer(getGoComSprRenderer.transformar(getGo()));        
    }

    protected abstract GOContexto getGOContext();        

    public void disparar(Vector3 posicao, float angulo, float velocidade)
    {
        Quaternion quatAngulo = Quaternion.Euler(0, 0, angulo);

        GOContexto goContexto = getGOContext();
        GameObject mainGO = goContexto.mainGO;
        mainGO.transform.rotation = quatAngulo;

        colocarNaPosicao(posicao, quatAngulo);
        addImpulso(mainGO.transform.up * velocidade);        
        mainGO.transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    public void disparar(float angulo, float velocidade)
    {
        disparar(getPosicao(), angulo, velocidade);
    }          
}
