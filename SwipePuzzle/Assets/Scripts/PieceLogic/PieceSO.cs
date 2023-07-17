using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]

public class PieceSO :  ScriptableObject
{
    public  visualDesign thisDesign;
 
    public swipeDirection directToSwipe;
    [SerializeField] bool doesChain;

    public Texture testTexture;
}

