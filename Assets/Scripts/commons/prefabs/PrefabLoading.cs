using UnityEngine;

public class PrefabLoading : MonoBehaviour
{
    [SerializeField] private LoadingDto loadingDto;

    public Loading getLoading(SomLoading somLoading, GameObject[] gosDesligar)
    {
        return new Loading(loadingDto, somLoading, gosDesligar);
    }
}
