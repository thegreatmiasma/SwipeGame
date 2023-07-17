
using UnityEngine;


public class SetHorizontalPosition : MonoBehaviour
{

    public static void ResizeNonSelectedLayer(GameObject currentLayerGO)
    {

    
            foreach (Transform trans in currentLayerGO.transform)
            {
                Vector3 tempLocation = trans.localPosition;
                if (Mathf.Abs(tempLocation.x) == .5f || Mathf.Abs(tempLocation.z) == .5f)
                {
                    //    Debug.Log("didnt change");
                }
                else
                {
                    trans.localPosition = tempLocation / 2;
                    //    Debug.Log(tempLocation + " the main");
                }
                //  Debug.Log(tempLocation);

                // currentGO.transform.localScale = new Vector3(.8f, .8f, .8f);


            }
        

    }
    public static void ResizeSelectedLayer(GameObject currentLayerGO)
    {
        foreach (Transform trans in currentLayerGO.transform)
        {
            Vector3 tempLocation = trans.localPosition;
            //  Debug.Log(tempLocation + " the main" + Mathf.Abs(tempLocation.x) + " other " + Mathf.Abs(tempLocation.z));
            if (Mathf.Abs(tempLocation.x) == 1f || Mathf.Abs(tempLocation.z) == 1f)
            {
                //    Debug.Log("didnt change");
            }
            else
            {
                //    Debug.Log(tempLocation + " the main");

                trans.localPosition = tempLocation * 2;
            }
            //     currentGO.transform.localScale = Vector3.one;
        }
    }

}
