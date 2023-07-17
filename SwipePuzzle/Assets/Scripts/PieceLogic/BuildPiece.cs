using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum visualDesign { one, two, three, four, five, six, seven, eight, nine }

public enum swipeDirection { up, down, left, right }
public class BuildPiece : MonoBehaviour
{
 

    struct pieceDesign
    {
        visualDesign blockDesign;
        swipeDirection directionToSwipe;
        bool doesChain;
    }

    List<pieceDesign> DesignPieces;
    // Start is called before the first frame update
    void Start()
    {
        DesignPieces = new List<pieceDesign>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
