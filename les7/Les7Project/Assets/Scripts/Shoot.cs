using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public KeyCode shootKey = KeyCode.LeftControl;
    public GameObject prefab;
    public float delay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(shootKey))
        {
            Callshot("player");
        }
    }
    public void Callshot(string origin)
    {
        StartCoroutine(AwaitDelay(delay, origin));
    }
    private IEnumerator AwaitDelay(float time, string origin)
    {
        yield return new WaitForSeconds(time);
        createProjectile(origin);
    }
    private void createProjectile(string origin)
    {
        GameObject ob = Instantiate(prefab);
        ob.transform.position = transform.position;
        ob.transform.rotation = transform.rotation;
        if (origin == "enemy")
        {
            ob.GetComponent<KillOnHit>().targetTag = "player";
        }
        Destroy(ob, 3f);
    }
}
