
using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] PieceSO thisPiece;
    bool isGoingDown;
    Vector3 goDown;
    public BaseTypeBase baseTypeBase { get; set; }
    public int pieceIndex
    {

        set;
        get;
    }
  
    
    public void Initialize(PieceSO incomingPiece, bool isMove, bool isBottom, BaseTypeBase basetype)
    {
        thisPiece = incomingPiece;
        if (isMove) SendInMotion();
        SetVisual();
        if (isBottom) {
            this.gameObject.AddComponent<Rigidbody>().isKinematic = true; }
        Debug.Log(basetype + " base type");
        baseTypeBase = basetype;
    }
   


     void SendInMotion()
    {
        goDown = this.gameObject.transform.position;
        goDown.y -= 3;
        isGoingDown = true;
       
    }
    void SetVisual()
    {
        GetComponent<MeshRenderer>().materials[0].SetTexture("_BaseMap",thisPiece.testTexture);
    }
    public PieceSO GetThisPieceSO()
    {
       // Debug.Log(thisPiece + " inside of collector");
        return thisPiece;
    }

  
   
    float currentLerpTime;
    float speed =1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("collectable"))
        {
            //Debug.Log(other.gameObject.tag);
            if (other.gameObject.GetComponent<Collector>()&& isSameType(other.gameObject.GetComponent<Collector>())) {
                //Destroy(other.gameObject);
                other.gameObject.SetActive(false);
                BaseCreator.baseType.TurnOffPieces(pieceIndex);
            }
        
        }
    }
    bool isSameType(Collector hitPiece)
    {
        if (hitPiece.GetThisPieceSO().testTexture == thisPiece.testTexture)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void Update()
    {
        if (runSizeChange)
        {
            

            currentLerpTime += Time.deltaTime;

            if (currentLerpTime > .5f)
            {
                currentLerpTime = .5f;
                runSizeChange = false;
            }
            float percentage = currentLerpTime / .5f;
         //   Debug.Log(percentage);

                this.transform.localPosition = Vector3.Lerp(startloc, endLoc, percentage);
        }

        if (isGoingDown)
        {
          //  Debug.Log("moveing");
            var step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position,goDown, step);
            if (this.gameObject.transform.position.y < -1) Destroy(this.gameObject);
        }

    }


    Vector3 startloc;
    Vector3 endLoc;
    float startTime;
    bool runSizeChange;
    public void PullPieceIn()
    {
        startloc = this.transform.localPosition;
       
        endLoc = startloc / 1.2f;
        currentLerpTime = 0;
        runSizeChange = true;
    }

    public void PushPieceOut()
    {
        startloc = this.transform.localPosition;
       
        endLoc = startloc * 1.2f;
        currentLerpTime = 0;
        runSizeChange = true;
    }


}
