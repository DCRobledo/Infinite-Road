using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public int roadWidth = 50;
    public int previousYLevel = -1;

    public List<GameObject> roadCollidables = new List<GameObject>();
    public List<GameObject> sideRoadCollidables = new List<GameObject>();


    public GameObject cameraGO;
    public GameObject roadTile;
    public GameObject carObj;

    public Sprite leftRoad;
    public Sprite rightRoad;
    public Sprite leftStartRoad;
    public Sprite middleStartRoad;
    public Sprite rightStartRoad;
    public Sprite plainRoad;
    public Sprite grassTile;

    public float maxYLevel = -1f;
    

    void Start() {
        cameraGO.transform.position = new Vector3((roadWidth-1) / 2f, .5f, -10);
        SpawnStartRoad();
    }

    private void SpawnStartRoad() {
        for (int x = 0; x < roadWidth; x++)
        {
            GameObject insTile = GameObject.Instantiate(roadTile, this.transform);
            insTile.transform.position = new Vector3(x, -1, -5);
            insTile.transform.name = "StartRoadTile(" + x + "," + -1 + ")";
            insTile.GetComponent<SpriteRenderer>().sprite = middleStartRoad;

            if (x == 0)
                insTile.GetComponent<SpriteRenderer>().sprite = leftStartRoad;
            if (x == roadWidth - 1)
                insTile.GetComponent<SpriteRenderer>().sprite = rightStartRoad;
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
        for (int x = -2; x < roadWidth+2; x++)
        {
            GameObject insTile = GameObject.Instantiate(getGOToSpawn(x), this.transform);
            insTile.transform.position = new Vector3(x, y, 0);
            insTile.transform.name = "RoadTile(" + x + "," + y + ")";
            insTile.AddComponent<DestroyMe>().carObj = carObj;
            if (x == 0)
                insTile.GetComponent<SpriteRenderer>().sprite = leftRoad;
            if (x == roadWidth - 1)
                insTile.GetComponent<SpriteRenderer>().sprite = rightRoad;

            SpawnCollidableObject(y, x, insTile);
        }
    }

    private void SpawnCollidableObject(float y, int x, GameObject insTile) {
        int rnd = Random.Range(0, 100);

        if (rnd <= 1 && x >= 0 && x <= roadWidth -1)
            SpawnCollidable(y, x, insTile, roadCollidables);

        else if (rnd >= 90 && (x == -2 || x == -1 || x == roadWidth + 1 || x == roadWidth))
            SpawnCollidable(y, x, insTile, sideRoadCollidables);
    }

    private void SpawnCollidable(float y, int x, GameObject insTile, List<GameObject> list)
    {
        int listRnd = Random.Range(0, list.Count);
        GameObject collidableObj = GameObject.Instantiate(list[listRnd]);
        collidableObj.transform.position = new Vector3(x, y, -5);
        insTile.transform.name = "Collidable(" + x + "," + y + ")";
        insTile.AddComponent<DestroyMe>().carObj = carObj;
    }

    private GameObject getGOToSpawn(int x){
        GameObject go = roadTile;
        go.GetComponent<SpriteRenderer>().sprite = plainRoad;
        SelectSprite(x, go);

        return go;
    }

    private void SelectSprite(int x, GameObject go)
    {
        if (x == -2 || x == -1 || x == roadWidth + 1 || x == roadWidth)
            go.GetComponent<SpriteRenderer>().sprite = grassTile;
        else if (x == roadWidth - 1)
            go.GetComponent<SpriteRenderer>().sprite = rightRoad;
        else if (x == 0)
            go.GetComponent<SpriteRenderer>().sprite = leftRoad;
    }

    void Update() {
        SpawnLevel();
    }

    private void SpawnLevel() {
        if (carObj.transform.position.y > maxYLevel-10){
            previousYLevel = previousYLevel + 1;
            SpawnRoad(previousYLevel);
            maxYLevel = previousYLevel;
        }
    }
}
