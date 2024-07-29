using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class SkillCoreManager : MonoSingleton<SkillCoreManager>
{
    public void RealeaseSkill(SkillData skillData, Transform startPos, Action<PlayableDirector> action = null)
    {
        //实例化技能
        GameObject skillGo = Instantiate(Resources.Load<GameObject>(skillData.skillPath), startPos);
        //赋值位置
        PlayableDirector playableDirector = skillGo.GetComponent<PlayableDirector>();
        TimelineAsset timelineAsset = playableDirector.playableAsset as TimelineAsset;
        TrackAsset animationTrack = timelineAsset.GetOutputTrack(0);
        playableDirector.SetGenericBinding(animationTrack, startPos.GetComponent<Animator>());
        //播放
        playableDirector.Play();
        //销毁
        if (action != null)
        {
            playableDirector.stopped += action;
        }
    }

}
