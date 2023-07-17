
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SetActiveCollector : MonoBehaviour
{

    [SerializeField]
    GameObject prefab;
    bool clicked;
    private void Start()
    {
        InputReader.enterPressAction += SetToFire;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if( getClickableObject(out RaycastHit hit).tag=="activator")
           {
                
                clicked = true;
            }
     }
    }

    public void SetToFire()
    {
        clicked = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (clicked)
        {
            clicked = false;
            LaunchPiece(other);
        }
    }
     void LaunchPiece(Collider other)
    {
        GameObject tempObject = GameObject.Instantiate(prefab, this.gameObject.transform.position, Quaternion.identity);
        Collector createdCollector = tempObject.AddComponent<Collector>();
        createdCollector.Initialize(other.gameObject.GetComponent<Collector>().GetThisPieceSO(), true, false,createdCollector.baseTypeBase);
    }
    GameObject getClickableObject( out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray.origin,ray.direction *10,out hit))
        {
            if (!isPointerOverUIObject())
            {
                target = hit.collider.gameObject;
            }

        }
        return target;
    }
    bool isPointerOverUIObject()
    {
        PointerEventData ped = new PointerEventData(EventSystem.current);
        ped.position= new Vector2(Input.mousePosition.z,Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(ped,results);
        return results.Count > 0;
    }


}
