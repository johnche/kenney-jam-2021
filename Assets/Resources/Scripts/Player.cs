using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameObject[] planets;
    Rigidbody2D playerBody;
    public float gravityConstant = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        planets = GameObject.FindGameObjectsWithTag("Planet");
        playerBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        foreach (GameObject planet in planets)
        {
            float distance = Vector2.Distance(planet.transform.position, gameObject.transform.position);
            float gravitationalForce = gravityConstant
                * planet.transform.localScale.magnitude
                * gameObject.transform.localScale.magnitude
                / (float)Math.Pow(distance, 2);

            Vector2 forceDirection = (planet.transform.position - gameObject.transform.position).normalized;

            Debug.Log($"{gravityConstant} " +
                $"player {gameObject.transform.localScale.magnitude} " +
                $"planet {planet.transform.localScale.magnitude} " +
                $"top {gravityConstant*planet.transform.localScale.magnitude*gameObject.transform.localScale.magnitude} " +
                $"dist {Math.Pow(distance, 2)} " +
                $"result {gravitationalForce}");
            playerBody.AddForce(gravitationalForce * forceDirection);
            //playerBody.AddForce(0.5f * forceDirection);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
