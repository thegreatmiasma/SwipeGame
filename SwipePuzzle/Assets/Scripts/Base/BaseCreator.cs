
using System.Collections.Generic;
using UnityEngine;

public enum TypeOfBase { single, connect}
public class BaseCreator
{
   public static BaseTypeBase baseType;
    public BaseCreator(TypeOfBase gamesBseType, GameObject prefab, List<PieceSO>list, BottomSwipe bottomSwipe)
    {
        switch(gamesBseType)
        {

            case TypeOfBase.single:
                baseType = new SingleLayerBase(5,2,prefab,list, bottomSwipe) as SingleLayerBase;
                break;

            case TypeOfBase.connect:
                baseType = new ConnectLikeBase(3,3) as ConnectLikeBase;
                break;
        }

        baseType.CreateBase();
    }

}
   

