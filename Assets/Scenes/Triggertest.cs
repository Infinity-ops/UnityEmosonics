using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggertest : MonoBehaviour {
    public static int cloneDesCount;
    [SerializeField]
    private RandomSound rs;
    // Use this for initialization
    void Start () {
        rs = GameObject.Find("RandomSound").GetComponent<RandomSound>();
        GameCount.scoreValue = 0;
        cloneDesCount = 0;

    }
  
	
	// Update is called once per frame
	void Update () {
		
	}
    public void reset(int cloneDesCount)
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            Debug.Log("I was hit");
            Destroy(this.gameObject);
            print("kkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk");

            if(this.gameObject.transform.position.x == Duplicator.xrand && this.gameObject.transform.position.y == Duplicator.yrand)
            {
                rs.play();
            }
            
            Destroy(other);
            cloneDesCount++;
            GameCount.scoreValue += 5;
            Debug.Log("cloneDestroy" + cloneDesCount);
        }
    }
}
