using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetUp : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera mainCamera;

    public GameObject rock;
    public GameObject paper;
    public GameObject sissor;
    public int entityCount;

    public BoxCollider2D topWall;
    public BoxCollider2D bottomWall;
    public BoxCollider2D leftWall;
    public BoxCollider2D rightWall;


    void Start()
    {

        //Move walls to edge locations
        topWall.size = new Vector2(mainCamera.ScreenToWorldPoint(new Vector3(Screen.width * 2f, 0f, 0f)).x, 1f);
        topWall.offset = new Vector2(0f, mainCamera.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y + 0.5f);

        bottomWall.size = new Vector2(mainCamera.ScreenToWorldPoint(new Vector3(Screen.width * 2f, 0f, 0f)).x, 1f);
        bottomWall.offset = new Vector2(0f, mainCamera.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).y - 0.5f);

        leftWall.size = new Vector2(1f, mainCamera.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y);
        leftWall.offset = new Vector2(mainCamera.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x - 0.5f, 0f);

        rightWall.size = new Vector2(1f, mainCamera.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y);
        rightWall.offset = new Vector2(mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x + 0.5f, 0f);

        Vector3 pos = new Vector3(0f,0f,0f);

        for (int j = 0; j < this.entityCount; j++)
        {
            float x = Random.Range(-65f, 65f);
            float y = Random.Range(-35f, 35f);
            pos.Set(x, y, 0f);
            SpawnObject(rock, pos);
        }
        for (int j = 0; j < this.entityCount; j++)
        {
            float x = Random.Range(-65f, 65f);
            float y = Random.Range(-35f, 35f);
            pos.Set(x, y, 0f);
            SpawnObject(paper, pos);
        }
        for (int j = 0; j < this.entityCount; j++)
        {
            float x = Random.Range(-65f, 65f);
            float y = Random.Range(-35f, 35f);
            pos.Set(x, y, 0f);
            SpawnObject(sissor, pos);
        }







    }





    public void SpawnObject(GameObject go,Vector3 position)
    {
        Instantiate(go, position, Quaternion.identity);
    }
}
