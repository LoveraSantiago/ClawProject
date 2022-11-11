using UnityEngine;

#pragma warning disable 0649
[System.Serializable]
public class MainTitleDto 
{
    [SerializeField] private Animator animator;

    public Animator Animator { get { return animator; } }
}
