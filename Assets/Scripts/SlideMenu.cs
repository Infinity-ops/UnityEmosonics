using UnityEngine;
using System.Collections;

public class SlideMenu : MonoBehaviour
{

    //refrence for the pause menu panel in the hierarchy
    public GameObject SlidePanel;
    //animator reference
    private Animator anim;
    //variable for checking if the game is paused 

    void Start()
    {
        //unpause the game on start
        Time.timeScale = 1;
        //get the animator component
        anim = SlidePanel.GetComponent<Animator>();
        //disable it on start to stop it from playing the default animation
        anim.enabled = false;
    }

    // Update is called once per frame
    public void Update()
    {

    }

    //function to pause the game
    public void openMenu()
    {
        //enable the animator component
        anim.enabled = true;
        //play the Slidein animation
        anim.Play("slideMenuIn");
        //freeze the timescale
        Time.timeScale = 0;
    }
    //function to unpause the game
    public void closeMenu()
    {
        //play the SlideOut animation
        anim.Play("slideMenuOut");
        //set back the time scale to normal time scale
        Time.timeScale = 1;
    }

}