using UnityEngine;
using System.Collections;

public class KeyControlAnimation : MonoBehaviour
{

    // We create a variable capable of containing all values in a Animator-component.

    private Animator myAnimator;

    void Start()
    {

        // We link our variable in the script to the Animator-component and the variables thereinn.

        myAnimator = GetComponent<Animator>();

        // Just to make sure we give all our variables false statements to start with.


        myAnimator.SetBool("Walk", false);

    }
    void Update()
    {

        // When the key/button is pressed the variable becomes true.

        if (Input.GetKeyDown("w"))
        {
            myAnimator.SetBool("Walk", true);
        }


        // When the key/button is released the variable becomes false.

        if (Input.GetKeyUp("w"))
        {
            myAnimator.SetBool("Walk", false);
        }
    }
}
