using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy {
    private GameObject body;
    private float movement_coef;
    private float rotation_coef;
    private MeshRenderer mesh;
    private List<Bullet> bullets;
    private Vector3 movement_vector;
    private Vector3 position_vector;
    private Vector3 rotation_vector;
    private int bullet_lim;
    private BoxCollider hitbox;




    public Enemy(Vector3 position)
    {
        this.body = GameObject.CreatePrimitive(PrimitiveType.Cube);
        this.body.transform.position = position;
        this.body.transform.localScale = new Vector3(0.5f, 0.5f, 1);
        //this.mesh = new MeshRenderer();
        //this.mesh.material = (Material)Resources.Load("player_material");
       // this.mesh.material.color = new Color(255, 0, 0);
       // this.body.AddComponent(this.mesh);
        this.position_vector = this.body.transform.position;

        this.movement_coef = 0.005f;
        this.rotation_coef = 0.5f;

        this.bullets = new List<Bullet>();
        this.movement_vector = new Vector3(0, 0, 0);
        this.bullet_lim = 4;
    
    }




    public void move()
    {
        if (Vector3.Distance(this.position_vector, Movement.position_vector) >= 2)
        {
            this.movement_vector = new Vector3(0, 0, 0);
            Debug.Log("Here");
            Vector3 predicted_position = (Movement.position_vector + Movement.movement_vector);
            this.movement_vector = (predicted_position - this.position_vector).normalized;
            this.rotation_vector = this.movement_vector;
            Debug.Log(this.movement_vector);
            this.position_vector = this.body.transform.position;
            this.body.transform.Translate(this.movement_vector * this.movement_coef);
            //Quaternion rotation = Quaternion.LookRotation(new Vector3(1, 0, 0), (predicted_position - this.position_vector));
            //this.body.transform.rotation = Quaternion.RotateTowards(this.body.transform.rotation, rotation, this.rotation_coef);
        }
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
