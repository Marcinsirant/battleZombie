using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public Transform firePoint;
    public GameObject gunPrefab;
    public GameObject bulletPrefab;
    protected FireButton fireButton;

    private GameObject prefabInstance;
    [HideInInspector]public PropertiesGun propertiesGun;
    
    [SerializeField] private AudioSource shootSound;

    private void Start()
    {
        if (DataPlayer.dataPlayer)
        {
            gunPrefab = DataPlayer.dataPlayer.setGunPrefab; 
        }
        prefabInstance = GameObject.Instantiate(gunPrefab) as GameObject;
        prefabInstance.transform.SetParent(gameObject.transform);
        fireButton = FindObjectOfType<FireButton>();
        propertiesGun = prefabInstance.GetComponent<PropertiesGun>();
        prefabInstance.transform.localPosition = new Vector2((float)propertiesGun.positionX, (float)propertiesGun.positionY);
        
    }
    // Update is called once per frame
    void Update()
    {
        
        if ((Input.GetKeyDown(KeyCode.Space) || fireButton.pressed) && !fireButton.fired) {
            fireButton.fired = true;
            StartCoroutine(Shoot());
        }

        
    }


    IEnumerator Shoot()
    {
        
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        shootSound.Play();
        yield return new WaitForSeconds((float)propertiesGun.reload);
        fireButton.fired = false;
    }
}
