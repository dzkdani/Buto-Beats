using UnityEngine;
using System.Collections;

public class CreditPage : MonoBehaviour
{
    [SerializeField]
    GameObject panel;
    Vector3 newScale;
    Vector3 threshold;
    void Start()
    {
        threshold = new Vector3(.4f, .4f, .4f);
        panel.transform.localScale = threshold;
        panel.SetActive(false);
    }
    void Update()
    {
		panel.transform.localScale = Vector3.Lerp(panel.transform.localScale, newScale, .3f);
        if (panel.transform.localScale.magnitude <= threshold.magnitude)
            panel.gameObject.SetActive(false);
    }
    public void Close()
    {
		newScale = Vector3.zero;
    }

    public void Open()
    {
        panel.gameObject.SetActive(true);
		panel.transform.localScale = threshold;
        newScale = Vector3.one;
    }


}
