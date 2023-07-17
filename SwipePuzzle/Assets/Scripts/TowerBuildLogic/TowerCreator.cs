
using System;
using System.Collections.Generic;
using UnityEngine;

public class TowerCreator
{
    // Start is called before the first frame update
    List<GameObject> VerticalLayersOfPlatforms = new List<GameObject>();

    [SerializeField] List<PieceSO> ListOfPotentialPieces;

    
    GameObject squarePrefab;

    float numberOfLayers = 3;
    float itemsPerLayer = 4;

  //  List<GameObject> towerLayerGOs = new List<GameObject>();

    GameObject tower;
   
    int currentLayerInt = -1;
    float[] locations;
    float xSeperation;
    float zSeperation;


    public TowerCreator(GameObject _preFab, float x, float z, float[]verticalSpacing, List<PieceSO>list)
    {
        ListOfPotentialPieces = list;
        squarePrefab = _preFab;
        xSeperation = x;
        zSeperation = z;
        locations = verticalSpacing;
        BuildTower();
    }

    private void BuildTower()
    {
     
        tower = new GameObject();
        CreateTower();
        PopulateTower();
        LayerSpacing();
        currentLayerInt = 1;
        Tower.SetMainTower(tower);
        Tower.SetTowerLevels(VerticalLayersOfPlatforms);
    }


    void CreateTower()
    {

        for(int x = 0; x < numberOfLayers; x++)
        {
            GameObject layer = CreateLayer();
          //  Debug.Log($"the towers {tower.gameObject}");
            layer.transform.parent = tower.transform;
            layer.name = " the name " + x;
            layer.transform.position = DefineLayerSeperation();
            layer.AddComponent<TowerLayer>();
            VerticalLayersOfPlatforms.Add(layer);
        }
    }


    void PopulateTower()
    {

        foreach(GameObject layer in VerticalLayersOfPlatforms)
        {
            TowerLayer tempLayer = layer.GetComponent<TowerLayer>();
          for(int x = 0; x < itemsPerLayer; x++)
            {
                LayerFill(layer, tempLayer);
            }
        
        }
    }

    void LayerFill(GameObject layer, TowerLayer towerLayer)
    {
        GameObject tempCollector = AddCollector();
        tempCollector.transform.parent = layer.transform;
        tempCollector.transform.parent = layer.transform;
        towerLayer.AddItemToLatyer(tempCollector);
    }

    GameObject AddCollector()
    {
        int rando = UnityEngine.Random.Range(0, 5);
        GameObject collector = MonoBehaviour.Instantiate(squarePrefab, tower.transform);
       collector.AddComponent<Collector>().Initialize(ListOfPotentialPieces[rando],false,false,null);
        return collector;
    }

    GameObject CreateLayer()
    {
        GameObject tempLayer = new GameObject();
        return tempLayer;
    }

  
    Vector3 DefineLayerSeperation()
    {
        currentLayerInt++;
      
        return new Vector3(0, locations[currentLayerInt], 0);
    }
    void LayerSpacing()
    {
        foreach (GameObject go in VerticalLayersOfPlatforms)
        {
            
            PerLayerPlacement(go);
      
        }
  
    }
    
    void PerLayerPlacement(GameObject layer)
    {
     
        Vector3[] spacing = new Vector3[4] {new Vector3(xSeperation,0,0), new Vector3(-xSeperation, 0, 0), new Vector3(0, 0, zSeperation), new Vector3(0, 0, -zSeperation)};
    
        int x = 0;
        foreach(Transform trans in layer.transform)
        {

            trans.localPosition = spacing[x];
            x++;
        }
    }
 

    void CollectBoxColliders()
    {
        foreach (GameObject go in VerticalLayersOfPlatforms)
        {
            foreach (Transform tran in go.transform)
            {
                Debug.Log(tran + " the trans");
            }
        }
    }





}
