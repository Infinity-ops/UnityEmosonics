using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {
  GameObject player;

    IEnumerator OnTriggerEnter(Collider collider)
    {
        if (!player || (player && collider.gameObject.tag == "player"))
        {
            PdAPI pd = GameObject.Find("PureData").GetComponent<PdAPI>();
<<<<<<< HEAD
            double[] pos = new double[] { 0.1, 0.5 };
<<<<<<< HEAD
            Destroy(this.gameObject);
            StonePrefab = GameObject.FindGameObjectWithTag("Projectile");
            DestroyObject(StonePrefab);
=======
>>>>>>> 60596e6ea1e239616627d639dff7ab479f96c2a4
=======
            double[] pos = new double[] { 0.7, 0.5 };
>>>>>>> parent of 8b3bb35... Added score /Attempts
            pd.changeValue(pos);
            pd.playAudio();

            //AudioSource audio = GetComponent<AudioSource>();
            //audio.Play();

            yield return new WaitForSeconds(0.7f);
            Destroy(this.gameObject);
            //Destroy(GameObject.Find("DragHandle"));
           //player.GetComponent<Collider>().enabled = false;
          
           
        }
    }
}
