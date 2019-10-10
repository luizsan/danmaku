using UnityEngine;
using System.Collections;

public class Utils : MonoBehaviour {

	// angle between two Vector2 coordinates
    public static float Angle(Vector2 a, Vector2 b){
    	if(a.x == b.x && a.y == b.y){
    		return 0;
    	}else{
        	return Mathf.Atan2(b.y-a.y, b.x-a.x)*180.0f/Mathf.PI;
        }
    }


}
