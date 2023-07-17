using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Tower 
{
   public static GameObject mainTowerGO;

   static List<GameObject> towerLevels;

   public  static GameObject currentLayerGO;

    static int currentLayerInt=1;

   public static void SetMainTower(GameObject _mainTower)
    {
        mainTowerGO = _mainTower;
    }

    public static void SetTowerLevels(List<GameObject> _towerLevels)
    {
        towerLevels = _towerLevels;
        currentLayerInt = 1;
        currentLayerGO= towerLevels[currentLayerInt];
        foreach(GameObject go in towerLevels)
        {
            if(go!=currentLayerGO)
            go.GetComponent<TowerLayer>().ShrinkLyers();
        }
      //  currentLayerGO.GetComponent<TowerLayer>().ReturnToFullSize();
        
    }

    public static bool SetCurrentLayer(bool moveUp)
    {
        bool hasChanged = false;

      //  Debug.Log($"current layer {currentLayerInt} is move up {moveUp}");

        if (moveUp == true)
        {
            if (currentLayerInt > 0)
            {
                currentLayerInt--;
                hasChanged = true;

            }
        }
        else
        {
            if (currentLayerInt < towerLevels.Count - 1)
            {
                currentLayerInt++;
                hasChanged = true;

            }
        }

        if (hasChanged == true)
        {
              currentLayerGO.GetComponent<TowerLayer>().ShrinkLyers();
            
           // SetNonSelectedSize();
            currentLayerGO = towerLevels[currentLayerInt];
           // SetSelect5electedSize();
            currentLayerGO.GetComponent<TowerLayer>().ReturnToFullSize();
          //  ResizeLayers();

        }
        return hasChanged;
    }


    static void SetNonSelectedSize(GameObject currentObject)
    {
        foreach (GameObject GO in towerLevels)
        {
            if (currentLayerGO == GO)
                SetHorizontalPosition.ResizeSelectedLayer(GO);
            else
            {
                SetHorizontalPosition.ResizeNonSelectedLayer(GO);
            }
        }
    }

    static void SetSelect5electedSize(GameObject currentObject)
    {

    }

}
