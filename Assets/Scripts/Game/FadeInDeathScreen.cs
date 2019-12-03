using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInDeathScreen : MonoBehaviour
{
    public GameObject player;
    public float Duration = 0.4f;

    void Update()
    { 
        FadeIn();   
    }
    public void FadeIn()
    {
        var uiElement = GetComponent<CanvasGroup>();
        if(player.GetComponent<Player_Movement>().canMove == false)
        {
            Debug.Log("Go");
            //StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 1));
            StartCoroutine(DoFade(uiElement, uiElement.alpha, 1));
        }
        
    }

    public IEnumerator DoFade(CanvasGroup canvGroup, float start, float end)
    {
        float counter = 0f;

        while (counter < Duration)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(start, end, counter / Duration);
            yield return null;
        }
    }
    public IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float lerpTime = 0.5f)
    {
        yield return new WaitForSeconds(1f);
        float _timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - _timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;
       
        while(true)
        {
            timeSinceStarted = Time.time - _timeStartedLerping;
            percentageComplete = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp(start, end, percentageComplete);

            cg.alpha = currentValue;

            if (percentageComplete >= 1) break;

            yield return new WaitForEndOfFrame();
        }
        Debug.Log("Done");
    }
}
