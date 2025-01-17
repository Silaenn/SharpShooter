using UnityEngine;
using StarterAssets;

public class Weapon : MonoBehaviour
{
    StarterAssetsInputs starterAssetsInputs;
    void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
    }
    void Update()
    {
        if (starterAssetsInputs.shoot)
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
            {
                Debug.Log(hit.collider.name);
                starterAssetsInputs.ShootInput(false);
            }

        }

    }
}
