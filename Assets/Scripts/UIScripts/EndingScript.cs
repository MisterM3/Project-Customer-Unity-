using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScript : MonoBehaviour
{
    [SerializeField] GameObject goodEnding;
    [SerializeField] GameObject badEnding;
    [SerializeField] GameObject background;
    Animator currentAnimator;
    bool isAnimationDone;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentAnimator != null && currentAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            goodEnding.SetActive(false);
            badEnding.SetActive(false);
            background.SetActive(false);
            currentAnimator = null;
        }
       if(Input.GetKeyDown(KeyCode.B)) PlayBadEnding();
       if(Input.GetKeyDown(KeyCode.G)) PlayGoodEnding();
    }

    public void PlayBadEnding()
    {
        background.SetActive(true);
        badEnding.SetActive(true);
        Animator anim = badEnding.GetComponent<Animator>();
        currentAnimator = anim;
        anim.Play("textAnimation");
    }

    public void PlayGoodEnding()
    {
        background.SetActive(true);
        goodEnding.SetActive(true);
        Animator anim = goodEnding.GetComponent<Animator>();
        anim.Play("shortAnimation");
        currentAnimator = anim;
    }
}
