using UnityEngine;
using System.Collections;

public class Emitter : MonoBehaviour {

	public GameObject Bullet;

	// Update is called once per frame
	private void FixedUpdate () {

		for(int i = 0; i < 4; i++){
	        float angle = Random.Range(0f,360000f) / 1000f;
	        float torque = Random.Range(-200f,200f) / 1000f;
	        Emit(Bullet, transform.position, angle, 0f, torque);
	    }

	}

	public static void Emit(GameObject prefab, Vector3 pos, float angle, float accel, float torque){
	    GameObject obj = Instantiate(prefab);

	    obj.GetComponent<Bullet>().Angle = angle;
	    obj.GetComponent<Bullet>().Accel = accel;
	    obj.GetComponent<Bullet>().Torque = torque;
	    
	    obj.transform.position = pos;
	}


}
