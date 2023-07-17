
using UnityEngine;

public class BottomSwipe : MonoBehaviour
{
    // Start is called before the first frame update

    SingleLayerBase singleLayer;

    public void SetSingleLayer(SingleLayerBase singlebase)
    {
        singleLayer = singlebase;
    }
    public void SetLocation(float incomingFloat)
    {
      //  Debug.Log(incomingFloat);
     //   Vector3 localPos = this.transform.localPosition;
        if (incomingFloat > 0)
        {
        //    Debug.Log("left");
         //   localPos.x = +.1f;
            singleLayer.MoveLayer(true);
        }
        else if(incomingFloat<0)
        {
            //  localPos.x = -.1f;
           // Debug.Log("right");
            singleLayer.MoveLayer(false);
        }
       // this.transform.localPosition = localPos;
    }
 
    void Start()
    {
        InputReader.swipeMovement += SetLocation;
    }

  
}
