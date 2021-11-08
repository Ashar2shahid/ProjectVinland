using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{

    public GameObject playerPrefab;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float minZ;
    public float maxZ;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
        GameObject myPlayer =  (GameObject)PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);
        myPlayer.transform.Find("Main Camera").gameObject.SetActive(true);
        myPlayer.transform.Find("3rdPersonCamera").gameObject.SetActive(true);
        myPlayer.transform.Find("AimCinemachine").gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
