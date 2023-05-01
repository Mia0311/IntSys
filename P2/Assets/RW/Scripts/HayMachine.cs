using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayMachine : MonoBehaviour
{

    public float movementSpeed;
    public float horizontalBoundary = 22;
    public GameObject hayBalePrefab;
    public Transform  haySpawnpoint;
    public float shootInterval;

    private float shootTimer;

    // Moving the hay machine on the ray track without exceed the area
    private void UpdateMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput < 0 && transform.position.x > -horizontalBoundary) 
        {
            transform.Translate(transform.right * -movementSpeed * Time.deltaTime);
        }
        else if (horizontalInput > 0 && transform.position.x < horizontalBoundary) 
        {
            transform.Translate(transform.right * movementSpeed * Time.deltaTime);
        }
        //Everytime the hey machine moves, the console will appear its position in x-axis
        //Debug.Log(transform.position.x);
    }

    private void UpdateShooting() {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0 && Input.GetKey(KeyCode.Space)) 
        {
            shootTimer = shootInterval;
            ShootHay();
        }
    }

    private void ShootHay()
    {
        // Method to create an instance of a given prefab or GameObject and places in the scene
        // In this case, the initial position of the hay bale is the same as the haySpawnpoint transform
        // Quaternion.identity set default rotation value to (X:0, Y:0, Z:0)
        Instantiate(hayBalePrefab, haySpawnpoint.position, Quaternion.identity);
        SoundManager.Instance.PlayShootClip();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        UpdateShooting();
    }
}
