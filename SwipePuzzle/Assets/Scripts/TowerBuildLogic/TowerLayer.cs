

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLayer : MonoBehaviour
    {
	List<GameObject> ItemsInLayer;

	public void AddItemToLatyer(GameObject catcherItem)
    {
		if (ItemsInLayer == null) ItemsInLayer = new List<GameObject>();

		ItemsInLayer.Add(catcherItem);
    }
	
	public void LayerChosen()
    {
		InputReader.instance.horizontalSwipe -= directionArg => {StartRotProcess(directionArg); };
	}

	public void LayerUnChosen()
    {
		InputReader.instance.horizontalSwipe -= directionArg => {StartRotProcess(directionArg); };
	}
	bool isRotating;

	public void RotateLayer(float dir)
    {
		StartRotProcess(dir);
    }

	private void Update()
    {
		if (isRotating == true)
		{
			float rotAdjust = 90 * rotateMult;

            if(Mathf.Abs(rotateMult)%4 == 0)
            {
             //   Debug.Log("backhome");//
            }
			this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(0, rotAdjust, 0), Time.deltaTime * 14);
           // Debug.Log($"rot adjust {rotAdjust} current rotation {this.transform.rotation.eulerAngles.y}");
		}


	}
	int rotateMult=0;
	
    private void StartRotProcess(float direction)
    {
		isRotating = true;
        if (direction > 0)
        {
			rotateMult -= 1;
		}
        else
        {
			rotateMult+= 1;
		}
	
	}


	public void ShrinkLyers()
    {
        
        // SetScaleOnShrink();
        shrinkCurrentTime = Time.time;
        RunShinkRoutine();
        SetScaleOnShrink();
      //  StartCoroutine(ShrinkNumberCO());
    }
    Vector2 startLoc;
    Vector3 endLoc;
    void SetScaleOnShrink()
    {
        foreach (GameObject catherObject in ItemsInLayer)
        {
            catherObject.GetComponent<Collector>().PullPieceIn();
         //   Vector3 tempLoc = catherObject.gameObject.transform.localPosition;
            // tempLoc.x = change / 2;
            //  tempLoc.y = change / 2;
            // tempLoc.z = change / 2;
           // catherObject.transform.localPosition = tempLoc / 2;
        }
    }

    void RunningShrink()
    {
        ;
        foreach (GameObject catherObject in ItemsInLayer)
        {
            Vector3 tempLoc = catherObject.gameObject.transform.localPosition;
            catherObject.transform.localScale = new Vector3(change, change, change);
            
        }

    }
    void RunningGrow()
    {
  
        foreach (GameObject catherObject in ItemsInLayer)
        {
            Vector3 tempLoc = catherObject.gameObject.transform.localPosition;
            catherObject.transform.localScale = new Vector3(change, change, change);
    
        }

    }

	void SetScaleOnReturnToNormal()
	{
        foreach (GameObject catherObject in ItemsInLayer)
        {
            catherObject.GetComponent<Collector>().PushPieceOut();
           // Vector3 tempLoc = catherObject.gameObject.transform.localPosition;
           // tempLoc.y = change * 2;
           // tempLoc.z = change * 2;
           // tempLoc.x = change * 2;
          //  catherObject.transform.localPosition = tempLoc*2;
        }
    }

    void RunShinkRoutine()
    {
      
        StartCoroutine(ShrinklayerdLayer());
    }
	public void ReturnToFullSize() { 
    
       // SetScaleOnReturnToNormal();
       SetScaleOnReturnToNormal();
        RunGrowCoroutine();
    }
    float shrinkAmount;
    IEnumerator ShrinkNumberCO()
    {
        shrinkAmount = 1;

        while(shrinkAmount<2) {
           // Debug.Log("time minus time "+ (Time.time - shrinkCurrentTime));
            shrinkAmount =1+ (Time.time - shrinkCurrentTime)/10;
           // Debug.Log("shrink Time "+shrinkAmount);
            SetScaleOnShrink(); 
            yield return shrinkAmount;
        }
     //   Debug.Log("last rung");
        
    }

	float currentTime;
    float shrinkCurrentTime;
	void RunGrowCoroutine()
	{
		
		currentTime = Time.time;
		 StartCoroutine(ExpandLayer());
	}
    float change = 0;

    IEnumerator ExpandLayer()
	{
		 change =0f;
		while (change < 1)
		{
			change =(( Time.time - currentTime)*1.5f)+.5f;
			RunningGrow();
            yield return change;
        }

		
	}
    IEnumerator ShrinklayerdLayer()
    {
        change = 1f;
        while (change > .5)
        {
            change -=(Time.time- shrinkCurrentTime)/100;
            RunningShrink();
            yield return change;
        }


    }
}
