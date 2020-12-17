using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Items : ScriptableObject
{

    public string Name;
    public string description;
    public int uses;
    public Boost[] Boost;
}
