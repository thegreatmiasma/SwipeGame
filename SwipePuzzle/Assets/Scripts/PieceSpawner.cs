
using UnityEngine;

public enum TypeOfCaptureToken { red, blue, green, yellow }
public enum DirectionToFrom { left,right,up,down}


public class PieceSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] captureTokenGO;

    Vector3 topSpawnPoint, bottomSpawnPoint,rightSpawnPoint,leftSpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        rightSpawnPoint = new Vector3(1.3f, 0,-1);
        leftSpawnPoint = new Vector3(-1.3f, 0,-1);
        topSpawnPoint = new Vector3(0,1.3f,-1 );
      //  bottomSpawnPoint = new Vector3(0,-1.3f,-1);
       // InvokeRepeating("GenericSpawn", 1, 2);
    }

    void GenericSpawn()
    {
        int randomInt = Random.Range(0, 3);
        TypeOfCaptureToken captureToken =(TypeOfCaptureToken) Random.Range(0, 4);
        switch (randomInt){
            case 0:
                SpawnCaptureToken(rightSpawnPoint, captureToken);
                break;
            case 1:
                SpawnCaptureToken(leftSpawnPoint, captureToken);
                break;
                
            case 2:
                SpawnCaptureToken(topSpawnPoint, captureToken);
                break;
             
            case 3:
                SpawnCaptureToken(bottomSpawnPoint, captureToken);
              
                break;
        }
      
    }


    void SpawnCaptureToken(Vector3 spawnLocation, TypeOfCaptureToken typeToSqawn )
    {
        int typeto = (int)typeToSqawn;
      //  Debug.Log(typeto);
        //Debug.Log(spawnLocation);
        GameObject spawnedItem = Instantiate(captureTokenGO[typeto], spawnLocation, Quaternion.identity);
        spawnedItem.transform.parent = this.transform;
    }
}
