using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {
  GameObject player;

    IEnumerator OnTriggerEnter(Collider collider)
    {
        if (!player || (player && collider.gameObject.tag == "player"))
        {

            PdAPI pd = new PdAPI();
            double[] pos = new double[] { 0.7, 0.1 };
            pd.changeValue(pos);
            pd.playAudio();
<<<<<<< HEAD
            //AudioSource audio = GetComponent<AudioSource>();
            //audio.Play();
=======

            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
>>>>>>> e3edf5feb0d8465d86f61d8b7cc6bab596a70f65
            yield return new WaitForSeconds(0.7f);
            Destroy(this.gameObject);
            //Destroy(GameObject.Find("DragHandle"));
           //player.GetComponent<Collider>().enabled = false;
          
           
        }
    }
}
