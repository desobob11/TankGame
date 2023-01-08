using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private GameObject obj;
    private float movement_coef;
    private float rotation_coef;
    private LineRenderer line;
    private Camera cam;
    private GameObject target;
    private List<Bullet> bullets;
    public static Vector3 movement_vector;
    private Vector3 start_vector;
    private Vector3 end_vector;
    private Vector3 viewport;
    private Bounds bounds;
    // Start is called before the first frame updates


    void Start()
    {
        this.obj = GameObject.Find("Player");
        this.target = GameObject.Find("Target");
        this.movement_coef = 0.01f;
        this.rotation_coef = 0.5f;
        this.line = this.obj.GetComponent(typeof (LineRenderer)) as LineRenderer;
        this.bullets = new List<Bullet>();
        cam = Camera.main;

        // this.viewport = cam.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        //this.bounds = new Bounds(new Vector3(0, 0, 0), this.viewport);
        this.bounds = new Bounds(new Vector3(0, 0, 0), new Vector3(10, 10, 10));
        Cursor.visible = false;
    }


    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.obj.transform.Translate(new Vector3(0, 1, 0));
        }
    }

    private void shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 movement_vector = this.end_vector - this.start_vector;


            this.bullets.Add(new Bullet(this.obj.transform.position, movement_vector));
            
        }


    }


    private void check_bounds()
    {
        if (!bounds.Contains(this.obj.transform.position))
        {
            Debug.Break();
        }
    }

    private void update_bullets()
    {
        List<int> indices = new List<int>();
        foreach (Bullet bullet in this.bullets)
        {
            
            if (!bounds.Contains(bullet.get_position()))
            {
                indices.Add(this.bullets.IndexOf(bullet));
            }
            else
            {
                bullet.move();
            }
            
            bullet.move();
        }

        foreach (int index in indices)
        {
            this.bullets[index].delete();
            this.bullets.RemoveAt(index);

        }
    }


    private void draw_line()
    {

        float s_x = this.obj.transform.position.x;
        float s_z = this.obj.transform.position.z;

        Vector3 start = new Vector3(s_x, 0.5f, s_z);
        this.start_vector = start;
        Vector3 mousePos = Input.mousePosition;
 
        Vector3 end = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 8.5f));
        this.end_vector = end;
        Vector3[] positions = new Vector3[] { start, end };

        this.target.transform.position = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 8.5f));

        this.line.SetPositions(positions);

    }
   
private void move()
    {
        movement_vector = new Vector3(0,0,0);
        Vector3 rotation = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            movement_vector.z += movement_coef;
            //rotation.z += rotation_coef;
           // this.obj.transform.Translate(new Vector3(0, 0, movement_coef));
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement_vector.z -= movement_coef;
            //rotation.z -= rotation_coef;
            //this.obj.transform.Translate(new Vector3(0, 0, -movement_coef));
        }
        if (Input.GetKey(KeyCode.A))
        {
            //movement.x -= movement_coef;
            rotation.y -= rotation_coef;
            //this.obj.transform.Translate(new Vector3(-movement_coef, 0, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            //movement.x += movement_coef;
            rotation.y += rotation_coef;
            //this.obj.transform.Translate(new Vector3(movement_coef, 0, 0));
        }
        obj.transform.Translate(movement_vector);
        obj.transform.Rotate(rotation);

    }



    // Update is called once per frame
    void Update()
    {
        jump();
        move();
        draw_line();
        shoot();
        update_bullets();
        check_bounds();
        Debug.Log(this.viewport);
        Debug.Log(this.obj.transform.position);
    }
}
