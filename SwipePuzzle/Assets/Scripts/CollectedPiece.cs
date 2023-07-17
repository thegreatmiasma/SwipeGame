
using UnityEngine;

public class CollectedPiece : MonoBehaviour
{
    // Start is called before the first frame update

    TypeOfCaptureToken thisType;

    [SerializeField] MeshRenderer meshRenderer;


    public void Initialize(TypeOfCaptureToken incomingType)
    {
        thisType = incomingType;
          meshRenderer = GetComponentInChildren<MeshRenderer>();
        switch (incomingType)
        {
            case TypeOfCaptureToken.red:
                thisType = TypeOfCaptureToken.red;
                meshRenderer.materials[0].SetColor("_Color",Color.red);
                break;
            case TypeOfCaptureToken.blue:
                thisType = TypeOfCaptureToken.blue;
                meshRenderer.materials[0].SetColor("_Color", Color.blue);
                break;

            case TypeOfCaptureToken.green:
                thisType = TypeOfCaptureToken.green;
                meshRenderer.materials[0].SetColor("_Color",Color.green);
                break;

            case TypeOfCaptureToken.yellow:
                thisType = TypeOfCaptureToken.yellow;
                meshRenderer.materials[0].SetColor("_Color", Color.yellow);
                break;
        }
    }
}
