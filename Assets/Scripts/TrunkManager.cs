using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TrunkManager : MonoBehaviour
{
    [SerializeField] private List<Transform> bones;
    [SerializeField] private PlayerController playerController;

    [SerializeField] private float firstComeBackLerp;
    [SerializeField] private float iPositionLerp;
    [SerializeField] private float firstPosLerp;
    [SerializeField] private float waveLerp;

    private GameEvents gameEvents;

    private bool come;
    private bool wave = false;

    private void Start()
    {
        gameEvents = GameEvents.instance;

        for (int i = 1; i < transform.childCount; i++)
        {
            bones.Add(transform.GetChild(i));
        }
        gameEvents.Start += () => come = true;
        gameEvents.GameOver += () => come = false;
        gameEvents.Win += () => come = false;

        gameEvents.SuckIn += WaveStarter;
    }

    private void FixedUpdate()
    {
        TrunkRunning();
        Wave();
    }

    private void TrunkRunning()
    {
        if (come)
        {
            Vector3 playerPos = playerController.transform.position;

            bones[0].position = Vector3.Lerp(bones[0].position, new Vector3(playerPos.x + 0.7f, playerPos.y + 1, playerPos.z), firstPosLerp);

            bones[0].localEulerAngles = Vector3.Lerp(bones[0].localEulerAngles, new Vector3(1, 0,
                         Mathf.Clamp(bones[0].localEulerAngles.z - playerController.Diff().x * 7, 10, 180)), 1f);

            for (int i = 1; i < bones.Count - 2; i++)
            {
                Vector3 bonepos = bones[i].transform.position;
                bones[i].position = Vector3.Lerp(bonepos, bones[i - 1].position, iPositionLerp);
                bones[i].LookAt(bones[i - 1]);
                bones[i].Rotate(90, 90, 180);
            }
            ComeBack();
        }
    }

    private void ComeBack()
    {
        bones[0].localEulerAngles = Vector3.Lerp(bones[0].localEulerAngles, new Vector3(0, 0, 90), firstComeBackLerp);
    }

    public void WaveStarter()
    {
        Vector3 scale = bones[0].transform.localScale;
        if (wave == false)
        {
            bones[1].transform.DOScale(new Vector3(scale.x, 4.5f, 4.5f), 0.2f).SetLoops(2, LoopType.Yoyo).OnStart(() => wave = true).OnComplete(() => wave = false);
        }

    }

    private void Wave()
    {
        for (int i = 1; i < bones.Count - 2; i++)
        {
            bones[i].transform.localScale = Vector3.Lerp(bones[i].transform.localScale, bones[i - 1].transform.localScale, waveLerp);
        }
    }
}
