using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncomingPiece : MonoBehaviour
{

    [SerializeField] TypeOfCaptureToken thisToken;
   // Vector3 directionToMove;
    Vector3 toMoveTowards = new Vector3(0, 0, -1);
    float speed = .4f;

    Transform parentTrans;
    // Start is called before the first frame update

    private void Start()
    {
        parentTrans = GetComponentInParent<Transform>();
    }

    public void Initialize(float speed)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
/*
        if (other.gameObject.CompareTag("collector")){

            other.gameObject.GetComponent<Collector>().AddPiece(thisToken);
        

        }*/
    }
    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime; // calculate distance to move
        parentTrans.position = Vector3.MoveTowards(transform.position, toMoveTowards, step);
        if (Vector3.Distance(parentTrans.position, toMoveTowards) < 0.001f)
        {
            DestroyImmediate(parentTrans.gameObject);
        }

    }
}
