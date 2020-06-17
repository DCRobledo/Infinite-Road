using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public GameObject roadTile;
    public int roadLength = 30;
    public int roadWidth = 5;

    public GameObject cameraGO;
    // Start is called before the first frame update
    void Start()
    {
        cameraGO.transform.position = new Vector3(roadWidth/2f, 0, -10);

        //Automatic Generation of the whole road tile's set
        for (int i = 0; i<roadLength; i++){
            for(int j = 0; j<roadWidth; j++){
                GameObject insTile = GameObject.Instantiate(roadTile, this.transform);
                insTile.transform.position = new Vector3(j, i, 0);
                insTile.transform.name = "RoadTile("+ j +","+ i +")";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
