using UnityEngine;

#pragma warning disable 0649
public class PrefabLoading : MonoBehaviour
{
    [SerializeField] private LoadingDto loadingDto;

    public void iniciarLoading(SomLoading somLoading, GameObject[] gosDesligar)
    {
        Loading loading = new Loading(loadingDto, somLoading, gosDesligar);
        ContextoEstaticoUtils.configLoading(loading);
    }
}
