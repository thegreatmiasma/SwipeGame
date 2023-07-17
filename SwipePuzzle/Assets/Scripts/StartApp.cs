
using System.Collections.Generic;
using UnityEngine;


public class StartApp : MonoBehaviour
{


    [SerializeField] GameObject collectPrefab;
    [SerializeField] Mover mover;
    [SerializeField] MoveTowerVertical moveTowerVertical;
    [SerializeField] BottomSwipe bottomSwipe;

    [SerializeField]
    float[] locations;
    [SerializeField]
    float xSeperation;
    [SerializeField]
    float zSeperation;
    [SerializeField]
    TypeOfBase gamesType;
    public static BaseTypeBase typeOfBase;

    [SerializeField] List<PieceSO> ListOfPotentialPieces;

    // Use this for initialization
    void Start()
    {

        TowerCreator towerCreator = new TowerCreator(collectPrefab, xSeperation, zSeperation, locations, ListOfPotentialPieces);
        BaseCreator baseCreator = new BaseCreator(gamesType, collectPrefab, ListOfPotentialPieces, bottomSwipe);


    }
}
