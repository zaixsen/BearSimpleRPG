using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class SkillCoreManager : MonoSingleton<SkillCoreManager>
{
    public void RealeaseSkill(SkillData skillData, Transform startPos, Action<PlayableDirector> action = null)
    {
        //ʵ��������
        GameObject skillGo = Instantiate(Resources.Load<GameObject>(skillData.skillPath), startPos);
        //��ֵλ��
        PlayableDirector playableDirector = skillGo.GetComponent<PlayableDirector>();
        TimelineAsset timelineAsset = playableDirector.playableAsset as TimelineAsset;
        TrackAsset animationTrack = timelineAsset.GetOutputTrack(0);
        playableDirector.SetGenericBinding(animationTrack, startPos.GetComponent<Animator>());
        //����
        playableDirector.Play();
        //����
        if (action != null)
        {
            playableDirector.stopped += action;
        }
    }

}
