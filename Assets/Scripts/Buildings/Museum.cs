using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class Museum : MonoBehaviour
{

    bool loaded = false;

    private async void OnTriggerEnter(Collider other)
    {
        if (!loaded)
        {
            MeshRenderer[] nftPanels = GetComponentsInChildren<MeshRenderer>();
            Debug.Log(nftPanels[0]);
            Debug.Log(nftPanels[1]);
            Debug.Log(nftPanels.Length);
            StartCoroutine(InitialLoad("https://api.nftport.xyz/v0/nfts/0xb47e3cd837dDF8e4c57F05d70Ab865de6e193BBB?chain=ethereum&page_number=1&include=metadata",  async
                (UnityWebRequest req) =>
            {
                if (req.isNetworkError || req.isHttpError)
                {
                    Debug.Log($"{req.error}: {req.downloadHandler.text}");
                }
                else
                {
                    Debug.Log(req.downloadHandler.text);
                    JObject json = JObject.Parse(req.downloadHandler.text);
                    for(int i = 0; i < nftPanels.Length; i++)
                    {
                        Debug.Log(json["nfts"][i]["file_url"].ToString());
                        Texture2D _texture = await GetRemoteTexture(json["nfts"][i]["file_url"].ToString());
                        Material[] materials = nftPanels[i].materials;
                        materials[0].mainTexture = _texture;
                        materials[0].color = Color.white;
                        materials[0].mainTextureScale = new Vector2((float)0.1, (float)0.12);
                        materials[0].mainTextureOffset = new Vector2((float)0.52, (float)0.71);
                        nftPanels[i].materials = materials;
                    }
                }
            }));
        }
    }

    private IEnumerator InitialLoad(string url, Action<UnityWebRequest> callback)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", "ae99dd7f-6b10-4889-9d01-9f4f86dac46a");
            // Send the request and wait for a response
            yield return request.SendWebRequest();
            callback(request);
        }
    }

    public static async Task<Texture2D> GetRemoteTexture(string url)
    {
        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(url))
        {
            // begin request:
            var asyncOp = www.SendWebRequest();

            // await until it's done: 
            while (asyncOp.isDone == false)
                await Task.Delay(1000 / 30);//30 hertz

            // read results:
            if (www.isNetworkError || www.isHttpError)
            // if( www.result!=UnityWebRequest.Result.Success )// for Unity >= 2020.1
            {
                // log error:
                #if DEBUG
                Debug.Log($"{www.error}, URL:{www.url}");
                #endif

                // nothing to return on error:
                return null;
            }
            else
            {
                // return valid results:
                return DownloadHandlerTexture.GetContent(www);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
