using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    public bool isInitiated = false;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        GameInitialize();
    }

    void GameInitialize()
    {
        PlayerController.Instance.HideThePlayer();
        DialogBox.Instance.Hide();

        SceneLoader.Instance.GameSceneInitiate();

        isInitiated = true;
    }

    private void Update()
    {
        // ������������
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                // ����������������Ƶ�����̨
                Debug.Log("Clicked on: " + hit.transform.name);
            }
        }
    }

}
