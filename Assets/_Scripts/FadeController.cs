using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeController : MonoBehaviour
{
    FadeInOut fade;

    private void Start()
    {
        fade = FindObjectOfType<FadeInOut>();
        fade.FadeOut();
    }

}
