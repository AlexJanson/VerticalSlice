using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowAnimation : MonoBehaviour
{

    public int cowAnimationMovement = 0;
    public bool animateAttack = true;
    public bool standUp = false;

    private Animator cowAnimation;
    // Start is called before the first frame update
    void Start()
    {
        cowAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        cowAnimateFunction();
    }

    private void cowAnimateFunction()
    {
        if (animateAttack == false)
        {

            standUp = false;

            if (cowAnimationMovement == 0)
            {

                cowAnimation.Play("CowWalkRightAnimation");

            }
            else if (cowAnimationMovement == 1)
            {

                cowAnimation.Play("CowWalkLeftAnimation");

            }
            else if (cowAnimationMovement == 2)
            {

                cowAnimation.Play("CowWalkFront");

            }
            else if (cowAnimationMovement == 3)
            {

                cowAnimation.Play("CowWalkBack");

            }
        }

        if (animateAttack == true)
        {
            if (cowAnimationMovement == 0)
            {
                if (standUp == false)
                {
                    cowAnimation.Play("CowStandRightAnimation");
                    standUp = true;
                }

            }
            else if (cowAnimationMovement == 1)
            {

                if (standUp == false)
                {
                    cowAnimation.Play("CowStandLeftAnimation");
                    standUp = true;
                }

            }
            else if (cowAnimationMovement == 2)
            {


                if (standUp == false)
                {
                    cowAnimation.Play("CowStandFrontAnimation");
                    standUp = true;
                }

            }
            else if (cowAnimationMovement == 3)
            {

                if (standUp == false)
                {
                    cowAnimation.Play("CowStandBackAnimation");
                    standUp = true;
                }

            }
        }
    }
}
