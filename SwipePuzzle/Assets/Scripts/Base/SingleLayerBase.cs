using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
public class SingleLayerBase : BaseTypeBase
{
    int  _type;
    int _numberOfPieces;
    List<PieceSO> ListOfPotentialPieces;
    GameObject holderGO;
    GameObject _preFab;
    float xDistanceApart;
    BottomSwipe _bottomSwipe;
    List<GameObject> sectionBlocks = new List<GameObject>();
    GameObject[] segments;
    public SingleLayerBase(int numberOfPieces, int types, GameObject prefab, List<PieceSO> listOfSOs,BottomSwipe bottomSwipe)
    {
        _type = types;
        _numberOfPieces = numberOfPieces;
        _preFab = prefab;
        _bottomSwipe = bottomSwipe;
        // float processed = -numberOfPieces / 2f;
        //  xDistanceApart = processed / 10;
        xDistanceApart = 0;
        ListOfPotentialPieces = listOfSOs;

        _bottomSwipe.SetSingleLayer(this);
        segments = new GameObject[3];
    }
    public  void CreateBase()
    {
        GameObject holdThemAll = new GameObject();


        holderGO = new GameObject();
       
        holdThemAll.transform.localPosition = new Vector3(0,-.89f,-.3f);

        holderGO.transform.parent = holdThemAll.transform;
       
        segments[1]=holderGO;
        holderGO.transform.localPosition = Vector3.zero;
        CreateRow();
        for (int x = 0 ; x < 2; x++)
        {
            GameObject newObject = MonoBehaviour.Instantiate(holderGO);
            Vector3 temp = holderGO.transform.position;
           
            if(x==1)
            {
                temp.x -= .5f;
                newObject.name = "zero";
                newObject.transform.position = temp;
                segments[0] = newObject;
            }
            else
            {
                temp.x += .5f;
                newObject.transform.position = temp;
                newObject.name = "two";
                segments[2] = newObject;
            }
           // newObject.SetActive(false);

            newObject.transform.parent = holdThemAll.transform;
        }
        
       // holderGO.transform.parent = _bottomSwipe.gameObject.transform;
    
    }

    int currentCenter=1;

    bool breakCheck = false;
    public void MoveLayer(bool isLeft)
    {
      
        foreach (GameObject go in segments)
        {
            if (isLeft)        
            {
                go.transform.localPosition += new Vector3(.0015f, 0, 0);
            }
            else
            {
                go.transform.localPosition -= new Vector3(.0015f, 0, 0);
            }
       
        }
        double adjusted = Math.Round(segments[currentCenter].transform.localPosition.x, 2);
       // Debug.Log($"position {segments[currentCenter].transform.localPosition.x}" + " current center " + currentCenter+ " is blocked "+breakCheck);

        if (adjusted == .25f&&breakCheck==false)
        { 
            //Debug.Log($"position {segments[currentCenter].transform.localPosition.x}" + " current center " + currentCenter);
            ShiftRight();
           
        }
        else  if(adjusted == -.25f && breakCheck == false)
        {

            ShiftLeft();
          
         
        }
    
        else
        {
            if(adjusted!=-.25f&&adjusted!=.25f)
            breakCheck = false;
        }
       

    }
   // Vector3 moveto;
   // Vector3 tempVect;
    Vector3 moveLeft = new Vector3(.75f,0,0);
    Vector3 moveRight = new Vector3(-.75f, 0, 0);

    Vector3 moveLeft2 = new Vector3(.25f,0,0);
    Vector3 moveRight2 = new Vector3(-.25f, 0, 0);
   void ShiftLeft()
    {//positive .75
      //  Debug.Log("shift left");
        switch (currentCenter)
        {
            case 0:
                segments[2].transform.localPosition = moveLeft;
                segments[1].transform.localPosition = moveLeft2;
                currentCenter = 1;
                break;

            case 1:
                segments[0].transform.localPosition = moveLeft;
                segments[2].transform.localPosition = moveLeft2;
                currentCenter = 2;
           
                break;

            case 2:
                segments[1].transform.localPosition = moveLeft;
                segments[0].transform.localPosition = moveLeft2;
                currentCenter = 0;
                break;

               
        }
        breakCheck = true;

    }
    void ShiftRight()
    {//negative .75
     //   Debug.Log("switch right");
        switch (currentCenter)
        {
            case 0:
                segments[1].transform.localPosition = moveRight;
                segments[2].transform.localPosition = moveRight2;
                currentCenter = 2;
                break;

            case 1:
                segments[2].transform.localPosition = moveRight;
                segments[0].transform.localPosition = moveRight2;
                currentCenter = 0;
                
                break;

            case 2:
                segments[0].transform.localPosition = moveRight;
                segments[1].transform.localPosition = moveRight2;
                currentCenter = 1;
                break;
        }
        breakCheck = true;
    }

    void CreateRow()
    {
        for(int x = 0;x<_numberOfPieces; x++)
        {
            CreatePiece(x);
        }
    }

    void CreatePiece(int pieceNumber)
    {
       
        GameObject newPiece = MonoBehaviour.Instantiate(_preFab, holderGO.transform);
        newPiece.tag = "collectable";
        newPiece.name = "bottom " + pieceNumber;
        newPiece.transform.position = new Vector3(xDistanceApart, newPiece.transform.position.y, newPiece.transform.position.z);
        Collector tempCollector = newPiece.AddComponent<Collector>();
        tempCollector.Initialize(ListOfPotentialPieces[UnityEngine.Random.Range(0, 5)], false,true, this);
        tempCollector.pieceIndex = pieceNumber;
            
        xDistanceApart = Mathf.Abs(xDistanceApart);
        if (pieceNumber%2==0)
        {
            xDistanceApart=Mathf.Abs(xDistanceApart);
            xDistanceApart += .1f;
        }
        else
        {
            xDistanceApart = xDistanceApart * -1;
        }
          
       // Debug.Log(xDistanceApart);
    }
    public void  TurnOffPieces(int incomingIndex)
    {
        foreach(GameObject GO in segments)
        {
            foreach (Transform  tran in GO.transform)
            {
                if(tran.GetComponent<Collector>().pieceIndex== incomingIndex)
                {
                    tran.gameObject.SetActive(false);
                }
            }

        }
    }
  
}
