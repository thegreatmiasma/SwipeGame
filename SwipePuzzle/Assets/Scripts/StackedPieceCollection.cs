
using UnityEngine;

public class StackedPieceCollection : MonoBehaviour
{
    [SerializeField] GameObject stackablePrefab;
  

    public GameObject GetStackableItem(TypeOfCaptureToken typeOfToken)
    {
        GameObject objcectToPass = Instantiate(stackablePrefab);

        CollectedPiece collectedTopass = objcectToPass.GetComponent<CollectedPiece>();

        switch (typeOfToken)
        {
            case TypeOfCaptureToken.yellow:
                collectedTopass.Initialize(typeOfToken);
                break;
            case TypeOfCaptureToken.red:

                break;
            case TypeOfCaptureToken.green:

                break;
            case TypeOfCaptureToken.blue:

                break;
        }
        collectedTopass.Initialize(typeOfToken);
        return objcectToPass;
    }
}
