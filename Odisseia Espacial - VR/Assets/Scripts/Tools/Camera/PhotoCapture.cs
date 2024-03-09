using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoCapture : MonoBehaviour
{
    [Header("Photo Taker")]
    [SerializeField] private Image photoDisplayArea;
    [SerializeField] private GameObject photoFrame;
    [SerializeField] private GameObject objectToCheck;

    private Camera mainCamera;
    private Texture2D screenCapture;
    private bool viewingPhoto;

    private void Start()
    {
        screenCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(!viewingPhoto)
            {
                StartCoroutine(CapturePhoto());
            }
            else
            {
                RemovePhoto();
            }
        }
    }

    IEnumerator CapturePhoto()
    {
        viewingPhoto = true;

        yield return new WaitForEndOfFrame();

        Rect regionToRead = new Rect(0, 0, Screen.width, Screen.height);

        screenCapture.ReadPixels(regionToRead, 0, 0, false);
        screenCapture.Apply();
        ShowPhoto();

        if (ObjectIsVisibleInPhoto())
        {
            Debug.Log("O objeto está na foto!");
        }
        else
        {
            Debug.Log("O objeto NÃO está na foto!");
        }
    }

    void ShowPhoto()
    {
        Sprite photoSprite = Sprite.Create(screenCapture, new Rect(0.0f, 0.0f, screenCapture.width, screenCapture.height), new Vector2(0.5f, 0.5f), 100.0f);
        photoDisplayArea.sprite = photoSprite;

        photoFrame.SetActive(true);
    }

    void RemovePhoto()
    {
        viewingPhoto = false;
        photoFrame.SetActive(false);
    }

    bool ObjectIsVisibleInPhoto()
    {
        // Obtem os planos do frustum da câmera principal
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(mainCamera);

        // Testa se a caixa delimitadora (AABB) do objeto está dentro do frustum
        if (GeometryUtility.TestPlanesAABB(planes, objectToCheck.GetComponent<Renderer>().bounds))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
