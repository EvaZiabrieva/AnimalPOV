using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnimalPOV
{
    public class MovementController : MonoBehaviour
    {
        private void Update()
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position, Vector3.down);
            if (Physics.Raycast(ray, out hit, 0.1f))
                transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
            else
                transform.rotation = Quaternion.identity;
        }
    }
}
