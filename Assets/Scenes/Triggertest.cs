using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Triggertest : MonoBehaviour {
    public static int cloneDesCount;
    [SerializeField] private RandomSound rs;
    [SerializeField] private Image errorImage;
    public static bool testPass2;
    private RectTransform crosshairRect;
    private bool test;
    private AudioSource wrongHit;
    //To Destroy attempt Ball
    // Use this for initialization
    void Start () {
        wrongHit = GetComponent<AudioSource>();
        AudioClip myAudioClip;
        myAudioClip = (AudioClip)Resources.Load("wrongSound");
        wrongHit.clip = myAudioClip;
        rs = GameObject.Find("RandomSound").GetComponent<RandomSound>();
        errorImage.enabled = false;
        crosshairRect = errorImage.GetComponent<RectTransform>();
        crosshairRect.sizeDelta = new Vector2(50, 50);
        test = false;
        testPass2 = false;
    }


    // Update is called once per frame
    IEnumerator PlayClickAudio() {
        wrongHit.Play();
        while (wrongHit.isPlaying)
        {
            yield return new WaitForSeconds(5);  //Don't freeze
        }
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
                StartCoroutine(PlayClickAudio());

                Vector3 ff;
                ff = this.gameObject.transform.localPosition;
                Debug.Log("MMMMAN" +ff);
                crosshairRect.position = new Vector3(251+(ff.x * 50), 203 + (ff.y * 50), 0);
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
            Destroy(this.gameObject);
            Destroy(other);

        }
              
    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log("clsdddddddddddddddddddd");
 
          //  errorImage.enabled = false;
       
    }
}
