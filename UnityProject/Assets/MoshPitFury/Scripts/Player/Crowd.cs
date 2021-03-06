﻿using UnityEngine;
using System.Collections;

public class Crowd : MonoBehaviour {
	
	public Animator myAnimator;

    public bool isHeadBang;
    public string specificAnimation;

	
	void Start () {
        if(!myAnimator)
        {
            Debug.Log("missing animator for crowd", this.gameObject);
            return;
        }

        if (string.IsNullOrEmpty(specificAnimation))
        {
            if (isHeadBang)
            {
                myAnimator.Play("HeadBang00");
            }
            else
            {
                myAnimator.Play("HeadBang01");
            }
        }

        else myAnimator.Play(specificAnimation);
	}
}
