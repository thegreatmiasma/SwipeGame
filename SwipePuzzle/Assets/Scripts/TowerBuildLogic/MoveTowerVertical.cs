
using UnityEngine;

public class MoveTowerVertical : MonoBehaviour
{
    [SerializeField]
    float speed;

    Vector3 target;


    bool isMoving;

    public void MoveTower(bool isUp)
    {
        if (isUp == true) { target.y += .15f; } else { target.y -= .15f; }
       
        isMoving = true;
    }

    void Update()
    {
        if (isMoving == true)
        {
            var step = speed * Time.deltaTime; // calculate distance to move
            Tower.mainTowerGO.transform.position = Vector3.MoveTowards(Tower.mainTowerGO.transform.position, target, step);

      
            if (Vector3.Distance(Tower.mainTowerGO.transform.position, target) < 0.001f)
            {
                
                Tower.mainTowerGO.transform.position = target;
                
                isMoving = false;
             
            }
        }


    }
}
