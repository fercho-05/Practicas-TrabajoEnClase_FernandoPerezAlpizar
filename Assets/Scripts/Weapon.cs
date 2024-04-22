using System;
using UnityEngine;

[Serializable]
public class Weapon
{
    [SerializeField]
    string name;

    [SerializeField]
    Transform container;

    int _animatorHash;

    public string GetName()
    {
        return name;
    }

    public Transform GetContainer() 
    { 
        return container; 
    }


    public int GetAnimatorHash()
    {
        return _animatorHash;
    }
    
    public void SetAnimatorHash(int newAnimatorHash)
    {
        _animatorHash = newAnimatorHash;
    }


}
