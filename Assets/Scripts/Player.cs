using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    // static reference
    public static Player character;

    // shottype prefab
    [SerializeField] private GameObject Bullet;

    // internal data
    [SerializeField] private float Speed = 1f;
    [SerializeField] private float Focus = 0.5f;

    private float H = 0f;
    private float V = 0f;
    private Vector3 Position;
    private Vector3 Movement;
    private Vector3 Mouse;
    private float Rotation;
    private static float HBounds = 0.725f;
    private static float VBounds = 0.925f;

    // ---

    private void Awake(){
        character = this;
    }

    private void Start(){
        Position = gameObject.transform.position;
    } 
    
    private void FixedUpdate(){
        H = Input.GetAxisRaw("Horizontal");
        V = Input.GetAxisRaw("Vertical");

        Movement = new Vector3(H,V,0f);
        Movement = Vector3.ClampMagnitude(Movement,1f);
        
        if(Input.GetButton("Focus")){
            Position += (Movement * Focus * Time.deltaTime);
        }else{
            Position += (Movement * Speed * Time.deltaTime);
        }
        
        Position.x = Mathf.Clamp(Position.x, -HBounds, HBounds);
        Position.y = Mathf.Clamp(Position.y, -VBounds, VBounds);
        Position.z = 0f;

        Mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Rotation = Utils.Angle(Position,Mouse) - 90f;

        gameObject.transform.position = Position;
        gameObject.transform.eulerAngles = new Vector3(0,0,Rotation);
    }

    private void Fire(){
        GameObject shot = Instantiate(Bullet);
        shot.GetComponent<Bullet>().Angle = Rotation;
        shot.transform.position = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collider){
        collider.GetComponent<Bullet>().CollideWithPlayer();
    }

    private void OnTriggerStay2D(Collider2D collider){
        collider.GetComponent<Bullet>().CollideWithPlayer();
    }


}
