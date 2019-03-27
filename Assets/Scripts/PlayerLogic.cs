using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour {

    public static int counter;
    public GameObject explosion;
    Camera camera;

    private Ray ray;
    private bool isSpecialEnemyKilled;

    void Start()
    {
        camera = GetComponent<Camera>();
        counter = 0;
        isSpecialEnemyKilled = false;
    }

    void Update()
    {
        DoHit();
        CheckForLose();
    }

    private void DoHit()
    {
        int layerVertical = LayerMask.NameToLayer("Vertical");
        int layerDiagonal = LayerMask.NameToLayer("Diagonal");
        int layerSpecial = LayerMask.NameToLayer("Special");
        int mask = 1 << layerVertical | 1 << layerDiagonal | 1 << layerSpecial;
        RaycastHit hit;
        ray = camera.ScreenPointToRay(Input.mousePosition);
        
        if (Input.GetMouseButtonDown(0))
        {
            SoundManager.instance.PlayerShootingSound();
            if (Physics.Raycast(ray, out hit, 1000f, mask))            
            {
                Instantiate(explosion, hit.transform.position, hit.transform.rotation);
                SoundManager.instance.EnemyKillingSound();
                Destroy(hit.collider.gameObject);

                if (hit.collider.gameObject.layer == layerSpecial)
                {
                    isSpecialEnemyKilled = true;
                }
            }
        }        
    }

    private void CheckForLose()
    {
        if (isSpecialEnemyKilled || counter >= 3)
        {
            GameManager.isGameOver = true;
            GameManager.instance.ShowLoseMessage();            
        }
    }
}
