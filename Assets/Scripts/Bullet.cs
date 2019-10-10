using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    // external data
    public float Speed;               // speed value
    public float Accel;               // speed change over time
    public float Angle;               // angular value
    public float Torque;              // angular speed

    public bool Rotate;               // rotate the sprite?
    public float Lifetime;            // lifetime of the bullet in frames
    public float Lifelimit;           // if lifetime exceeds this, destroy the bullet

    // internal data
    protected float HSpeed;          
    protected float VSpeed;
    protected Vector3 Position;
    protected Vector3 Movement;
    protected Collider2D Collider;


    private void Start(){
        Position = gameObject.transform.position;
        Collider = gameObject.GetComponent<Collider2D>();
        Collider.enabled = false;
    } 


    private void FixedUpdate(){

        float dist = Vector3.Distance(
            transform.position,
            Player.character.transform.position
        );

        if(dist > 0.2f){
            Collider.enabled = false;
        }else{
            Collider.enabled = true;
        }

        Speed += Accel;
        Angle += Torque;
        Angle = Mathf.Repeat(Angle, 360f);

        HSpeed = Mathf.Sin(Angle * Mathf.Deg2Rad) * Mathf.Rad2Deg;
        VSpeed = Mathf.Cos(Angle * Mathf.Deg2Rad) * Mathf.Rad2Deg;

        Movement = new Vector3(-HSpeed, VSpeed, 0f);
        Movement = Vector3.ClampMagnitude(Movement,1f);
        Position += Movement * Speed * Time.deltaTime;

        if(Rotate){
            transform.eulerAngles = new Vector3(0,0,Angle);
        }
    
        gameObject.transform.position = Position;
        Lifetime++;

    }

    private void OnBecameInvisible(){
        Destroy(gameObject);
    }

    public void CollideWithPlayer(){
        Destroy(gameObject);
    }

}
