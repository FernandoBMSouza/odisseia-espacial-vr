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

    [Header("Raycast Distance Chack")]
    [SerializeField] private Transform player;
    [SerializeField] private Transform target;
    [SerializeField] private float maxDistance = 10f;
    private RaycastHit hit;
    private bool isRaycastHitting = false;


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

        // Lance um raio do jogador para o objeto espec�fico
        if (Physics.Raycast(player.position, (target.position - player.position).normalized, out hit, maxDistance))
        {
            // Verifique se o objeto atingido � o objeto espec�fico
            if (hit.transform == target)
            {
                // O objeto espec�fico est� dentro da dist�ncia m�xima
                isRaycastHitting = true;
            }
            else
            {
                isRaycastHitting= false;
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
            Debug.Log("O objeto est� na foto!");
        }
        else
        {
            Debug.Log("O objeto N�O est� na foto!");
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
        // Obtem os planos do frustum da c�mera principal
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(mainCamera);

        // Testa se a caixa delimitadora (AABB) do objeto est� dentro do frustum
        if (GeometryUtility.TestPlanesAABB(planes, objectToCheck.GetComponent<Renderer>().bounds) && isRaycastHitting)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
