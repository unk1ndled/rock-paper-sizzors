using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Behavior : MonoBehaviour
{
    public string targetType;
    DistAndObject dao;

    private SpriteRenderer spriteRenderer;
    public Sprite rock;
    public Sprite paper;
    public Sprite sissor;

    float maxSpeed = 15f;
    float minSpeed = 10f;
    float deceleration = 1f;



    void Start()
    {
        if (this.tag == "sissor") { targetType = "paper"; //type = "sissor";
        }

        else if (this.tag == "paper") { targetType = "rock"; //type = "paper"; 
        }

        else if (this.tag == "rock") { targetType = "sissor"; //type = "rock"; 
        }

        dao = gameObject.AddComponent<DistAndObject>();
    }



    // Update is called once per frame
    void Update()
    {
        if ((dao.go == null)||(dao.go.tag == this.tag))
        {
            dao = Find(targetType,true);
            
        }

            Vector2 direction;

            if (dao.go != null)
            {
                //LookAt2D(transform, closest.transform.position);

                Vector2 current = transform.position;
                Vector2 target = dao.go.transform.position;
                


                transform.Translate(Pursue2D(current, target), dao.go.transform);


            }
            else
            {
                dao = Find(this.tag,false);
                Vector2 current = transform.position;
                Vector2 target = dao.go.transform.position;
                transform.Translate(Pursue2D(current, target), dao.go.transform);

            }
            


    }

    void OnCollisionEnter2D(Collision2D collInfo)
    {
        ;
        if (collInfo.collider.tag == targetType)
        {
            
            collInfo.collider.GetComponent<Behavior>().targetType = collInfo.collider.tag;
            collInfo.collider.tag = this.tag;

            if (collInfo.collider.tag == "sissor")
            {
                collInfo.collider.GetComponent<SpriteRenderer>().sprite = sissor;
            }

            else if (collInfo.collider.tag == "paper")
            {
                collInfo.collider.GetComponent<SpriteRenderer>().sprite = paper;
            }

            else if (collInfo.collider.tag == "rock")
            {
                collInfo.collider.GetComponent<SpriteRenderer>().sprite = rock;
            }

        }
    }






    public DistAndObject Find(string targetName ,bool findnear)
    {

        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag(targetName);
        GameObject closest = null;
        float distance ;

        if (findnear)
        {
             distance = Mathf.Infinity;
            Vector3 position = transform.position;
            foreach (GameObject go in gos)
            {
                Vector3 diff = go.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    closest = go;
                    distance = curDistance;
                }
            }

            dao.go = closest;
            dao.dist = distance;

            return dao;
        }
        else
        {
             distance = 0f;
            Vector3 position = transform.position;
            foreach (GameObject go in gos)
            {
                Vector3 diff = go.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance > distance)
                {
                    closest = go;
                    distance = curDistance;
                }
            }

            dao.go = closest;
            dao.dist = distance;

            return dao;
        }

        
    }

    public Vector2 Pursue2D(Vector2 current, Vector2 target) {

        Vector2 direction = target - current;


        float distance = direction.magnitude;
        if (distance < minSpeed * Time.deltaTime)
        {
            direction = direction.normalized * minSpeed * Time.deltaTime;
        }
        else
        {
            float maxMagnitude = maxSpeed * Time.deltaTime;
            direction = Vector2.ClampMagnitude(direction, maxMagnitude);
        }

        return direction;
    }

    public static void LookAt2D(Transform transform, Vector2 target)
    { 
        Vector2 current = transform.position;
        Vector2 direction = target - current;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
