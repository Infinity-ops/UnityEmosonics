using UnityEngine;
using System.Collections;

/**
 * slides settings menu in and out
 */
public class slideMenuScript : MonoBehaviour
{

    //refrence for the pause menu panel in the hierarchy
    public GameObject SlidePanel; /**< panel containing menu which slides up and down */
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

    /**
     * opens menu/slides menu upwards
     */
    public void openMenu()
    {
        //enable the animator component
        anim.enabled = true;
        //play the Slidein animation
        anim.Play("slideMenuIn");
        //freeze the timescale
        Time.timeScale = 0;
    }

    /**
     * closes menu/slides menu downwards
     */
    public void closeMenu()
    {
        //play the SlideOut animation
        anim.Play("slideMenuOut");
        //set back the time scale to normal time scale
        Time.timeScale = 1;
    }

}