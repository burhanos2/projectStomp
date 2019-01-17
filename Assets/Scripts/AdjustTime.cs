using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustTime {

    private MonoBehaviour _mb = new MonoBehaviour();

	public void InstantTimeSwitch(float modifier)
    {
        Time.timeScale = modifier;
    }

    public IEnumerator LimitedTimeSwitch(float modifier, float duration)
    {
        float oldValue = Time.timeScale;
        Time.timeScale = modifier;
        yield return _mb.StartCoroutine(Wait(duration));
        Time.timeScale = oldValue;
    }

    public IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }

}
