using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LensaScript : MonoBehaviour
{
    [SerializeField] private Transform lukisanKecil, lukisanBesar;

    private void Update()
    {
        lukisanBesar.position = lukisanKecil.position * 2 - transform.position;
    }
}
