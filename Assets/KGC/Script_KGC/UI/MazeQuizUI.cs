using System;
using System.Collections;
using Common.Scripts.Players;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MazeQuizUI : MonoBehaviour, IPuzzleUI
{
    [Header("입력창 UI")]
    public TMP_InputField inputField;
    public Button submitButton;
    public GameObject slotPrefab;
    public Transform slotParent;
    
    [Header("정답: 최대 다섯글자")]
    public string correctAnswer;

    [Header("정답 애니메이션 연출 설정")]
    public CanvasGroup canvasGroup;
    public GameObject cutsceneLookTarget;
    public float cutsceneWaitDuration; //카메라 이동 후 지속시간
    public float cutsceneMoveDuration; //카메라가 이동하는 속도
    
    private GameObject[] slots;

    public event Action OnCorrect;
    public void UIOpen()
    {
        var playerController = FindObjectOfType<PlayerController>();
        playerController?.LockInput();
        
        gameObject.SetActive(true);
    }

    public void UIClose()
    {
        gameObject.SetActive(false);

        var interaction = FindObjectOfType<Interaction>();
        if (interaction != null)
        {
            interaction.UnlockInteraction();
        }
        
        var playerController = FindObjectOfType<PlayerController>();
        playerController?.UnlockInput();
        
    }

    private void Start()
    {
        CreateSlot();
        submitButton.onClick.AddListener(CheckAnswer);
    }

    void CreateSlot()
    {
        slots = new GameObject[correctAnswer.Length];

        for (int i = 0; i < correctAnswer.Length; i++)
        {
            GameObject slot = Instantiate(slotPrefab, slotParent);
            slot.GetComponentInChildren<TMP_Text>().text = "_";
            slots[i] = slot;
        }
    }

    void CheckAnswer()
    {
        string userInputText = inputField.text.Trim().ToLower();

        if (userInputText == correctAnswer.ToLower())
        {
            for (int i = 0; i < correctAnswer.Length; i++)
            {
                slots[i].GetComponentInChildren<TMP_Text>().text = correctAnswer[i].ToString().ToLower();
            }

            OnCorrectAnswer();
        }
        else
        {
            for (int i = 0; i < correctAnswer.Length; i++)
            {
                slots[i].GetComponentInChildren<TMP_Text>().text = "_";
                
            }
        }
        inputField.text = String.Empty;
    }

    void HideUI()
    {
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
    }

    void OnCorrectAnswer()
    {
        Debug.Log("정답!!");
        OnCorrect?.Invoke();

        var interaction = FindObjectOfType<Interaction>();
        if (interaction != null)
        {
            interaction.ClearInteraction();
            interaction.LockInteraction();
        }
        
        var playerController = FindObjectOfType<PlayerController>();
        playerController?.LockInput();

        HideUI();
        StartCoroutine(PlayCutSceneAnim());
    }

    private IEnumerator PlayCutSceneAnim()
    {
        Transform cam = Camera.main.transform;
        
        Vector3 startPos = cam.position;
        Quaternion startRot = cam.rotation;

        cutsceneLookTarget= GameObject.Find("ExitTargetWall");
        
        Vector3 targetPos = cutsceneLookTarget.transform.position + Vector3.up * 10f;
        Quaternion targetRot = Quaternion.LookRotation(cutsceneLookTarget.transform.position - targetPos);
        
        yield return StartCoroutine(MoveCameraToTarget(cam,targetPos,targetRot, cutsceneMoveDuration));
        yield return new WaitForSeconds(cutsceneWaitDuration);
        yield return StartCoroutine(MoveCameraToTarget(cam,startPos,startRot, cutsceneMoveDuration));
        
        var player = FindObjectOfType<PlayerController>();
        var interaction = FindObjectOfType<Interaction>();

        player?.UnlockInput();
        interaction?.UnlockInteraction();
        interaction?.ClearInteraction();
        UIClose();

    }

    private IEnumerator MoveCameraToTarget(Transform _cam, Vector3 _targetPos, Quaternion _targetRot, float _duration)
    {
        Vector3 startPos = _cam.position;
        Quaternion startRot = _cam.rotation;
        float elapsed = 0f;

        while (elapsed < _duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.SmoothStep(0,1,elapsed/_duration);
            
            _cam.position = Vector3.Lerp(startPos, _targetPos, t);
            _cam.rotation = Quaternion.Lerp(startRot, _targetRot, t);
            
            yield return null;
        }
        _cam.position = _targetPos;
        _cam.rotation = _targetRot;
    }
}
