using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet
{
    private GameObject body;
    private float speed;
    private Vector3 movement_vector;
    private MeshRenderer mesh;

    public Bullet(Vector3 start_pos, Vector3 movement)
    {

        this.body = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        this.body.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        this.body.transform.position = start_pos;
        this.speed = 0.025f;
        
        // TODO: IMPLEMENT PLAYER VELOCITY AFFECTING TRAVEL PATH
        // this.movement_vector = movement + Movement.movement_vector.normalized;
        this.movement_vector = movement;
       // this.mesh = new MeshRenderer();
       // this.mesh.material.color = new Color(128, 128, 128);
            
       

        GameObject player = GameObject.Find("Player");
        Physics.IgnoreCollision(this.body.GetComponent<SphereCollider>(), player.GetComponent<BoxCollider>());

    }

    public Vector3 get_position()
    {
        return new Vector3(this.body.transform.position.x, 
                           this.body.transform.position.y, 
                           this.body.transform.position.z);

    }



    public void delete()
    {
       Object.Destroy(this.body);
    }


    //TODO: ADD PLAYER VELOCITY TO MOVEMENT VECTOR WHEN SHOOTING
    public void move()
    {
        this.body.transform.Translate(this.movement_vector * this.speed);
    }
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
