using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggertest : MonoBehaviour {
    public static int cloneDesCount;
    [SerializeField]
    private RandomSound rs;
    public static bool testPass2;
    public bool test;
     //To Destroy attempt Ball
    // Use this for initialization
    void Start () {
        rs = GameObject.Find("RandomSound").GetComponent<RandomSound>();
        test = false;
        testPass2 = false;
    }
  
	
	// Update is called once per frame
	void Update () {
		
	}
   
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            Debug.Log("I was hit");
            Destroy(this.gameObject);
            
            if((this.gameObject.transform.position.x == Duplicator.xrand) && (this.gameObject.transform.position.y == Duplicator.yrand))
            {
                rs.play();
                test = true;
                GameCount.scoreValue = 0;
                cloneDesCount = 0;
                
            }
            if ((this.gameObject.transform.position.x != Duplicator.xrand) || (this.gameObject.transform.position.y != Duplicator.yrand))
            {
                testPass2 =true;
            }
           
            Destroy(other);
            if (test)
            {
                cloneDesCount++;
                GameCount.scoreValue += 5;
                test = false;
            }
            Debug.Log("cloneDestroy" + cloneDesCount);
            test = false;
           
        }
              
    }
}
