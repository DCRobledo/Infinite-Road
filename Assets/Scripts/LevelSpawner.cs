using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public GameObject roadTile;
    public int roadLength = 30;
    public int roadWidth = 5;

    public GameObject cameraGO;

    public Sprite leftRoad;
    public Sprite rightRoad;

    public Sprite leftStartRoad;
    public Sprite middleStartRoad;
    public Sprite rightStartRoad;

    public Sprite grassTile;
    // Start is called before the first frame update
    void Start()
    {
        cameraGO.transform.position = new Vector3((roadWidth-1) / 2f, .5f, -10);

        SpawnLevel();
    }

    private void SpawnLevel()
    {
        SpawnStartRoad();
        SpawnGrass();

        for (int i = 0; i < roadLength; i++)
        {
            for (int j = 0; j < roadWidth; j++)
            {
                GameObject insTile = GameObject.Instantiate(roadTile, this.transform);
                insTile.transform.position = new Vector3(j, i, 0);
                insTile.transform.name = "RoadTile(" + j + "," + i + ")";

                if (j == 0)
                    insTile.GetComponent<SpriteRenderer>().sprite = leftRoad;
                if (j == roadWidth - 1)
                    insTile.GetComponent<SpriteRenderer>().sprite = rightRoad;
            }
        }
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
        }
    }

    public void SpawnGrass(){
        for(int y = -1; y<roadLength; y++){
            for(int x=-2; x<roadWidth+2; x++){
                GameObject insTile = GameObject.Instantiate(roadTile, this.transform);
                insTile.transform.position = new Vector3(x, y, 2);
                insTile.transform.name = "RoadTile(" + x + "," + -1 + ")";
                insTile.GetComponent<SpriteRenderer>().sprite = grassTile;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
