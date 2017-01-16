using UnityEngine;
using System.Collections;

public class randomplacer : MonoBehaviour {

    // array of objects to be randomly generated 
    public GameObject[] envObj;

    // make sure length of weights = length of envObj
    // bigger number = more weight
    public float[] weights;

    //bounds of terrain
    public float bx_start;
    public float bz_start;
    public float bx_end;
    public float bz_end;

    // y co-ord of terrain
    private float ty = 0;

    //random numbers generated
    [SerializeField]
    private float randx;
    private float randz;

    //density of random objects (direct correlation to number)
    [SerializeField]
    private float density;

    //number of objects generated
    private int numObj;

	// Use this for initialization
	void Start () {
        float wsum = 0;
        for(int i =0; i<weights.Length ;i++) 
        {
            wsum += weights[i];
        }

        //set y
        ty = transform.localPosition.y;

        //find total number of objects
        numObj = (int)Mathf.Ceil(density) * 100;
        
        //count = num of objs generated, 
        //track = type of obj (index of weights array)
        int count = 0, track=0;

        //wtrack = num of objs of type track.
        int wtrack = (int) (numObj * weights[track] / wsum);

        for(int i = 0; i < numObj; i++)
        {   
             
            if(count>wtrack)
            {                
                //set count to 0, change track and wtrack
                count = 0;
                track += 1;
                wtrack = (int)(numObj * weights[track] / wsum);
            }

            randx = Random.Range(bx_start, bx_end);
            randz = Random.Range(bz_start, bz_end);
            

            //to randomize rotation about y axis
            Quaternion rot = Quaternion.identity;
            rot.eulerAngles = new Vector3(0, Random.Range(0, 180), 0);
            Instantiate(envObj[track], new Vector3(randx, ty, randz),rot);
            count += 1;
        }
        
	}
	

}
