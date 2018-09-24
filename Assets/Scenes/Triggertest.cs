using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Triggertest : MonoBehaviour {
    public static int cloneDesCount;
    [SerializeField] private RandomSound rs;
    [SerializeField] private Image errorImage;
    [SerializeField] private Image errorImage1;  //Removetest//
    public static bool testPass2;
    private RectTransform crosshairRect;
    private RectTransform crosshairRect1; //Removetest//
    private bool test;
    private AudioSource wrongHit;
    //To Destroy attempt Ball
    // Use this for initialization
    void Start () {
        
       // AudioClip myAudioClip;
        //myAudioClip = (AudioClip)Resources.Load("wrongSound");
       // wrongHit.clip = myAudioClip;
        rs = GameObject.Find("RandomSound").GetComponent<RandomSound>();
        errorImage.enabled = true;
        errorImage1.enabled = true;//Removetest//
        crosshairRect = errorImage.GetComponent<RectTransform>();
        crosshairRect.sizeDelta = new Vector2(50, 50);
        crosshairRect1 = errorImage1.GetComponent<RectTransform>();//Removetest//
        crosshairRect1.sizeDelta = new Vector2(50, 50);//Removetest//
       // crosshairRect.position = new Vector3(115.5f,206.5f, 0);//Removetest//
        //crosshairRect1.position = new Vector3(0, 0, 0);//Removetest//
        test = false;
        testPass2 = false;
    }


   
    void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "Projectile")
        {
           
            
            if((this.gameObject.transform.position.x == Duplicator.xrand) && (this.gameObject.transform.position.y == Duplicator.yrand)) //correct hit
            {
                rs.play();
                test = true;
                GameCount.scoreValue = 0;
                cloneDesCount = 0;
                
            }
            if ((this.gameObject.transform.position.x != Duplicator.xrand) || (this.gameObject.transform.position.y != Duplicator.yrand))
            {
                
                Vector3 ff;
                ff = this.gameObject.transform.localPosition;
                Debug.Log("MMMMAN" +ff);
                crosshairRect.position = new Vector3(115.5f+ (40*ff.x),206.5f+(40*ff.y), 0);
                wrongHit = GetComponent<AudioSource>();
                wrongHit.volume = 1;
                wrongHit.Play();
                errorImage.enabled = true;
                testPass2 =true;
            }

            
            if (test)
            {
                cloneDesCount++;
                GameCount.scoreValue += 5;
                test = false;
            }
            Debug.Log("cloneDestroy" + cloneDesCount);
            test = false;
            Debug.Log("I was hit");
           Destroy(this.gameObject, 0.3f);
            Destroy(other);

        }
              
    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log("clsdddddddddddddddddddd");
 
          //  errorImage.enabled = false;
       
    }
}
