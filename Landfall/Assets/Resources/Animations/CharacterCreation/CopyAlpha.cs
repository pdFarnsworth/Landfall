using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CopyAlpha : MonoBehaviour
{
    Image p;
    Text t;

    // Start is called before the first frame update
    void Start()
    {
        p = GetComponentInParent<Image>();
        t = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Color c = new Color(t.color.r, t.color.g, t.color.b, t.color.a);
        t.color = c;
    }
}
