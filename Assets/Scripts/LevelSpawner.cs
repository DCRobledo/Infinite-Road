using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public int roadLength = 30;
    public int roadWidth = 5;

    public GameObject cameraGO;
    public GameObject roadTile;
    public GameObject carObj;


    public Sprite leftRoad;
    public Sprite rightRoad;

    public Sprite leftStartRoad;
    public Sprite middleStartRoad;
    public Sprite rightStartRoad;

    public Sprite grassTile;

    public float maxYLevel = -1f;
    public int previousYLevel = -1;

    void Start()
    {
        cameraGO.transform.position = new Vector3((roadWidth-1) / 2f, .5f, -10);

        SpawnStartRoad();
    }

    private void SpawnStartRoad()
    {
        for (int x = 0; x < roadWidth; x++)
        {
            GameObject insTile = GameObject.Instantiate(roadTile, this.transform);
            insTile.transform.position = new Vector3(x, -1, 0);
            insTile.transform.name = "RoadTile(" + x + "," + -1 + ")";
            insTile.GetComponent<SpriteRenderer>().sprite = middleStartRoad;

            if (x == 0)
                insTile.GetComponent<SpriteRenderer>().sprite = leftStartRoad;
            if (x == roadWidth - 1)
                insTile.GetComponent<SpriteRenderer>().sprite = rightStartRoad;
            SpawnStartGrass(x);
        }
       

    }

    private void SpawnStartGrass(int x)
    {
        GameObject insTile = GameObject.Instantiate(roadTile, this.transform);
        insTile.transform.position = new Vector3(x, -1, 2);
        insTile.transform.name = "GrassTile(" + x + "," + -1 + ")";
        insTile.GetComponent<SpriteRenderer>().sprite = grassTile;
    }

    private void SpawnRoad(float y){
        for (int x = 0; x < roadWidth; x++) {
            GameObject insTile = GameObject.Instantiate(roadTile, this.transform);
            insTile.transform.position = new Vector3(x, y, 0);
            insTile.transform.name = "RoadTile(" + x + "," + y + ")";
            insTile.AddComponent<DestroyMe>().carObj = carObj;
            if (x == 0)
                insTile.GetComponent<SpriteRenderer>().sprite = leftRoad;
            if (x == roadWidth - 1)
                insTile.GetComponent<SpriteRenderer>().sprite = rightRoad;
        }
    }

    private void SpawnGrass(float y){
        for(int x=-2; x<roadWidth+2; x++){
            GameObject insTile = GameObject.Instantiate(roadTile, this.transform);
            insTile.transform.position = new Vector3(x, y, 2);
            insTile.transform.name = "RoadTile(" + x + "," + -1 + ")";
            insTile.GetComponent<SpriteRenderer>().sprite = grassTile;
            insTile.AddComponent<DestroyMe>().carObj = carObj;
        }
    }

    void Update()
    {
        SpawnLevel();
    }

    private void SpawnLevel()
    {
        if (carObj.transform.position.y > maxYLevel-6)
        {
            previousYLevel = previousYLevel + 1;
            SpawnRoad(previousYLevel);
            SpawnGrass(previousYLevel);
            maxYLevel = previousYLevel;
        }
    }
}
