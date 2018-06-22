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
            double[] pos = new double[] { 0.7, 0.5 };
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
