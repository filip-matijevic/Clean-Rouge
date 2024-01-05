using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBulletController : MonoBehaviour
{
    private Rigidbody2D selfRB;

    [SerializeField]
    private float maxlifeTime;
    private float wiggleFrequency = 15;
    private float lifeTime;
    private float wiggleTime;

    private Transform bulletRoot;
    // Start is called before the first frame update

void Start(){
    Init();
}
    public void Init(){
        selfRB = GetComponent<Rigidbody2D>();
        bulletRoot = transform.GetChild(0);
        wiggleTime = Random.Range(0, 50);
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime += Time.deltaTime;
        wiggleTime += Time.deltaTime;
        if (lifeTime>maxlifeTime){
            Destroy(gameObject);
        }
        
        WiggleBullet();
    }

    public void Fire(Vector2 direction, float power){
        Init();
        selfRB.AddForce(direction * power);
    }

    void WiggleBullet(){
        var axis = Mathf.Sin(((wiggleTime*wiggleFrequency)/maxlifeTime) * Mathf.PI * 2f) * 0.2f;
        bulletRoot.localPosition = new Vector3(axis, 0, 0);
    }
}
