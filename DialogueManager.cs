using System.Collections;
using TMPro;
using UnityEngine;

[System.Serializable]
public struct SubtitleText
{
    public float time;
    [TextArea(3, 10)] public string text;
}

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueContainer; // gameobject containing subtitles
    public TextMeshProUGUI subtitles; // subtitle text
    public AudioSource dialogueAudioSource;
    public AudioClip trainingRoomAudio;
    public AudioClip pistolsInfoAudio;
    public AudioClip riflesInfoAudio;
    public AudioClip doorsInfoAudio;
    public AudioClip firstFloorIntroAudio;
    public AudioClip cyborgdeath;
    public Animator cyborgAnimator;

    // structs that contains subtitles and time intervals
    public SubtitleText[] subtitleTextTrainingRoom;
    public SubtitleText[] subtitleTextPistolsInfo;
    public SubtitleText[] subtitleTextRiflesInfo;
    public SubtitleText[] subtitleTextDoorsInfo;
    public SubtitleText[] subtitleTextFirstFloor;

    [ContextMenu("Training Room")]
    public void StartSubtitlesTrainingRoom()
    {
        StartCoroutine(TrainingRoomSubsCoroutine());
    }

    [ContextMenu("Pistols")]
    public void StartSubtitlesPistolsInfo()
    {
        StartCoroutine(PistolsInfoSubCoroutine());
    }

    [ContextMenu("Rifles")]
    public void StartSubtitlesRiflesInfo()
    {
        StartCoroutine(RiflesInfoSubCoroutine());
    }

    [ContextMenu("Automated doors")]
    public void StartSubtitlesDoors()
    {
        StartCoroutine(DoorsInfoSubCoroutine());
    }
   
    [ContextMenu("First Floor")]
    public void StartSubtitlesFirstFloor()
    {
        StartCoroutine(FirstFloorSubsCoroutine());     
    }


    private IEnumerator FirstFloorSubsCoroutine()
    {
        dialogueAudioSource.clip = firstFloorIntroAudio;
        dialogueAudioSource.Play();
        cyborgAnimator.SetTrigger("Talk");
        dialogueContainer.SetActive(true);

        foreach (var voiceLine in subtitleTextFirstFloor)
        {
            subtitles.text = voiceLine.text;  // display struct-written subs inside the text field

            yield return new WaitForSecondsRealtime(voiceLine.time); // time interval for each subtitle based on the audio clip
        }

        cyborgAnimator.SetTrigger("StopTalking");
        dialogueContainer.SetActive(false); // hide sub container when done    
    }


    private IEnumerator TrainingRoomSubsCoroutine()
    {
        dialogueAudioSource.clip = trainingRoomAudio;
        dialogueAudioSource.Play();
        cyborgAnimator.SetTrigger("Talk");
        dialogueContainer.SetActive(true);

        foreach (var voiceLine in subtitleTextTrainingRoom)
        {
            subtitles.text = voiceLine.text;  // display struct-written subs inside the text field

            yield return new WaitForSecondsRealtime(voiceLine.time); // time interval for each subtitle based on the audio clip
        }

        cyborgAnimator.SetTrigger("StopTalking");
        dialogueContainer.SetActive(false); // hide sub container when done
    }


    private IEnumerator PistolsInfoSubCoroutine()
    {
        dialogueAudioSource.clip = pistolsInfoAudio;
        dialogueAudioSource.Play();
        cyborgAnimator.SetTrigger("Talk");
        dialogueContainer.SetActive(true);

        foreach (var voiceLine in subtitleTextPistolsInfo)
        {
            subtitles.text = voiceLine.text;  // display struct-written subs inside the text field

            yield return new WaitForSecondsRealtime(voiceLine.time); // time interval for each subtitle based on the audio clip
        }

        cyborgAnimator.SetTrigger("StopTalking");
        dialogueContainer.SetActive(false); // hide sub container when done
    }

    private IEnumerator RiflesInfoSubCoroutine()
    {
        dialogueAudioSource.clip = riflesInfoAudio;
        dialogueAudioSource.Play();
        cyborgAnimator.SetTrigger("Talk");
        dialogueContainer.SetActive(true);

        foreach (var voiceLine in subtitleTextRiflesInfo)
        {
            subtitles.text = voiceLine.text;  // display struct-written subs inside the text field

            yield return new WaitForSecondsRealtime(voiceLine.time); // time interval for each subtitle based on the audio clip
        }

        cyborgAnimator.SetTrigger("StopTalking");
        cyborgAnimator.SetTrigger("Death");
        yield return new WaitForSeconds(2);
        dialogueAudioSource.clip = cyborgdeath;
        dialogueAudioSource.Play();
        dialogueContainer.SetActive(false); // hide sub container when done
    }

    private IEnumerator DoorsInfoSubCoroutine()
    {
        dialogueAudioSource.clip = doorsInfoAudio;
        dialogueAudioSource.Play();
        cyborgAnimator.SetTrigger("Talk");
        dialogueContainer.SetActive(true);

        foreach (var voiceLine in subtitleTextDoorsInfo)
        {
            subtitles.text = voiceLine.text;  // display struct-written subs inside the text field

            yield return new WaitForSecondsRealtime(voiceLine.time); // time interval for each subtitle based on the audio clip
        }

        cyborgAnimator.SetTrigger("StopTalking");
        dialogueContainer.SetActive(false); // hide sub container when done
    }
}
