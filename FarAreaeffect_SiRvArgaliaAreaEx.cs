using Battle.DiceAttackEffect;
using LOR_DiceSystem;
using LOR_XML;
using Sound;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000055 RID: 85
public class FarAreaeffect_SiRvArgaliaAreaEx : FarAreaEffect
{
    // Token: 0x17000015 RID: 21
    // (get) Token: 0x0600014C RID: 332 RVA: 0x00002145 File Offset: 0x00000345
    public override bool HasIndependentAction
    {
        get
        {
            return true;
        }
    }

    // Token: 0x0600014D RID: 333 RVA: 0x00007A1C File Offset: 0x00005C1C
    public override void Init(BattleUnitModel self, params object[] args)
    {
        base.Init(self, args);
        _victimList = new List<BattleFarAreaPlayManager.VictimInfo>();
        _elapsedEndAtk = 0f;
        _elapsedAtkOneTarget = 0f;
        OnEffectStart();
        _trailObject = Util.LoadPrefab("Battle/SpecialEffect/ArgaliaSpecialAreaEffect", base.transform);
        _trailObject.transform.localPosition = Vector3.zero;
        _self.view.charAppearance.ChangeMotion(ActionDetail.Default);
        List<BattleUnitModel> list = new List<BattleUnitModel>();
        list.AddRange(BattleObjectManager.instance.GetAliveList((self.faction == Faction.Enemy) ? Faction.Player : Faction.Enemy));
        SingletonBehavior<BattleCamManager>.Instance.FollowUnits(false, list);
        _sign = ((UnityEngine.Random.Range(0f, 1f) > 0.5f) ? 1 : -1);
        _dstPosAtkOneTarget = Vector3.zero;
        _srcPosAtkOneTarget = Vector3.zero;
    }

    // Token: 0x0600014E RID: 334 RVA: 0x00007B00 File Offset: 0x00005D00
    public override bool ActionPhase(float deltaTime, BattleUnitModel attacker, List<BattleFarAreaPlayManager.VictimInfo> victims, ref List<BattleFarAreaPlayManager.VictimInfo> defenseVictims)
    {
        bool result = false;
        if (_trailObject != null)
        {
            base.transform.position = _self.view.atkEffectRoot.position;
        }
        if (state == FarAreaEffect.EffectState.Start)
        {
            if (_self.moveDetail.isArrived)
            {
                state = FarAreaEffect.EffectState.GiveDamage;
                _victimList = new List<BattleFarAreaPlayManager.VictimInfo>(victims);
            }
        }
        else if (state == FarAreaEffect.EffectState.GiveDamage)
        {
            if (_elapsedAtkOneTarget < Mathf.Epsilon)
            {
                CardRange ranged = attacker.currentDiceAction.card.GetSpec().Ranged;
                if (ranged == CardRange.FarArea)
                {
                    Util.DebugEditorLog("?");
                }
                else if (ranged == CardRange.FarAreaEach)
                {
                    List<BattleFarAreaPlayManager.VictimInfo> victimList = _victimList;
                    if (victimList != null && victimList.Count > 0)
                    {
                        if (_victimList.Exists((BattleFarAreaPlayManager.VictimInfo x) => !x.unitModel.IsDead()))
                        {
                            List<BattleFarAreaPlayManager.VictimInfo> list = new List<BattleFarAreaPlayManager.VictimInfo>();
                            foreach (BattleFarAreaPlayManager.VictimInfo victimInfo in _victimList)
                            {
                                if (!victimInfo.unitModel.IsDead())
                                {
                                    list.Add(victimInfo);
                                }
                            }
                            BattleFarAreaPlayManager.VictimInfo victimInfo2 = list[UnityEngine.Random.Range(0, list.Count)];
                            attacker.view.WorldPosition = victimInfo2.unitModel.view.WorldPosition;
                            FarAreaeffect_SiRvArgaliaAreaEx._motionCount = (FarAreaeffect_SiRvArgaliaAreaEx._motionCount + 1) % 2;
                            attacker.view.charAppearance.ChangeMotion((FarAreaeffect_SiRvArgaliaAreaEx._motionCount == 0) ? ActionDetail.Slash2 : ActionDetail.S14);
                            _sign = ((_sign == 1) ? -1 : 1);
                            Vector3 b = new Vector3(SingletonBehavior<HexagonalMapManager>.Instance.tileSize * 4f * _self.view.transform.localScale.x / 1.5f, 0f, 0f) * (float)_sign;
                            _srcPosAtkOneTarget = victimInfo2.unitModel.view.WorldPosition + b;
                            _dstPosAtkOneTarget = victimInfo2.unitModel.view.WorldPosition - b;
                            attacker.view.WorldPosition = _srcPosAtkOneTarget;
                            attacker.UpdateDirection(victimInfo2.unitModel.view.WorldPosition);
                            string resource = (FarAreaeffect_SiRvArgaliaAreaEx._motionCount == 0) ? "FX_Mon_Argalia_Slash_Up" : "FX_Mon_Argalia_Slash_Down_Small";
                            DiceAttackEffect diceAttackEffect = SingletonBehavior<DiceEffectManager>.Instance.CreateBehaviourEffect(resource, 1f, attacker.view, victimInfo2.unitModel.view, 1f);
                            if (diceAttackEffect != null)
                            {
                                diceAttackEffect.SetLayer("Effect");
                            }
                            BattlePlayingCardDataInUnitModel playingCard = victimInfo2.playingCard;
                            if (((playingCard != null) ? playingCard.currentBehavior : null) != null)
                            {
                                if (attacker.currentDiceAction.currentBehavior.DiceResultValue > victimInfo2.playingCard.currentBehavior.DiceResultValue)
                                {
                                    attacker.currentDiceAction.currentBehavior.GiveDamage(victimInfo2.unitModel);
                                    if (FarAreaeffect_SiRvArgaliaAreaEx._motionCount == 0)
                                    {
                                        SingletonBehavior<SoundEffectManager>.Instance.PlayClip("Battle/Blue_Argalria_Far_Atk1", false, 1f, null);
                                    }
                                    else
                                    {
                                        SingletonBehavior<SoundEffectManager>.Instance.PlayClip("Battle/Blue_Argalria_Far_Atk2", false, 1f, null);
                                    }
                                    if (victimInfo2.unitModel.IsDead())
                                    {
                                        List<BattleUnitModel> list2 = new List<BattleUnitModel>();
                                        list2.Add(_self);
                                        victimInfo2.unitModel.view.DisplayDlg(DialogType.DEATH, list2);
                                    }
                                    victimInfo2.unitModel.view.charAppearance.ChangeMotion(ActionDetail.Damaged);
                                    victimInfo2.destroyedDicesIndex.Add(victimInfo2.playingCard.currentBehavior.Index);
                                }
                                else
                                {
                                    victimInfo2.unitModel.view.charAppearance.ChangeMotion(ActionDetail.Guard);
                                    victimInfo2.unitModel.UpdateDirection(attacker.view.WorldPosition);
                                    if (!defenseVictims.Contains(victimInfo2))
                                    {
                                        defenseVictims.Add(victimInfo2);
                                    }
                                }
                            }
                            else
                            {
                                attacker.currentDiceAction.currentBehavior.GiveDamage(victimInfo2.unitModel);
                                if (FarAreaeffect_SiRvArgaliaAreaEx._motionCount == 0)
                                {
                                    SingletonBehavior<SoundEffectManager>.Instance.PlayClip("Battle/Blue_Argalria_Far_Atk1", false, 1f, null);
                                }
                                else
                                {
                                    SingletonBehavior<SoundEffectManager>.Instance.PlayClip("Battle/Blue_Argalria_Far_Atk2", false, 1f, null);
                                }
                                if (victimInfo2.unitModel.IsDead())
                                {
                                    List<BattleUnitModel> list3 = new List<BattleUnitModel>();
                                    list3.Add(_self);
                                    victimInfo2.unitModel.view.DisplayDlg(DialogType.DEATH, list3);
                                }
                                victimInfo2.unitModel.view.charAppearance.ChangeMotion(ActionDetail.Damaged);
                            }
                            SingletonBehavior<BattleManagerUI>.Instance.ui_unitListInfoSummary.UpdateCharacterProfile(victimInfo2.unitModel, victimInfo2.unitModel.faction, victimInfo2.unitModel.hp, victimInfo2.unitModel.breakDetail.breakGauge, null);
                            SingletonBehavior<BattleManagerUI>.Instance.ui_unitListInfoSummary.UpdateCharacterProfile(attacker, attacker.faction, attacker.hp, attacker.breakDetail.breakGauge, null);
                            _victimList.Remove(victimInfo2);
                        }
                    }
                }
            }
            _elapsedAtkOneTarget += deltaTime;
            if (Vector3.SqrMagnitude(_dstPosAtkOneTarget - _srcPosAtkOneTarget) > Mathf.Epsilon)
            {
                attacker.view.WorldPosition = Vector3.Lerp(_srcPosAtkOneTarget, _dstPosAtkOneTarget, _elapsedAtkOneTarget * 10f);
            }
            if (_elapsedAtkOneTarget > 0.25f)
            {
                _elapsedAtkOneTarget = 0f;
                _srcPosAtkOneTarget = Vector3.zero;
                _dstPosAtkOneTarget = Vector3.zero;
                if (_victimList == null || _victimList.Count == 0)
                {
                    state = FarAreaEffect.EffectState.End;
                }
                else if (!_victimList.Exists((BattleFarAreaPlayManager.VictimInfo x) => !x.unitModel.IsDead()))
                {
                    _victimList.Clear();
                    state = FarAreaEffect.EffectState.End;
                }
            }
        }
        else if (state == FarAreaEffect.EffectState.End)
        {
            _elapsedEndAtk += deltaTime;
            if (_elapsedEndAtk > 0.35f)
            {
                _self.view.charAppearance.ChangeMotion(ActionDetail.Default);
                state = FarAreaEffect.EffectState.None;
                _elapsedEndAtk = 0f;
            }
        }
        else if (_self.moveDetail.isArrived)
        {
            SingletonBehavior<BattleCamManager>.Instance.FollowUnits(false, BattleObjectManager.instance.GetAliveList(false));
            result = true;
            if (_trailObject != null)
            {
                UnityEngine.Object.Destroy(_trailObject);
            }
            UnityEngine.Object.Destroy(base.gameObject);
        }
        return result;
    }

    // Token: 0x0600014F RID: 335 RVA: 0x00002A82 File Offset: 0x00000C82
    protected override void Update()
    {
        if (isRunning && _self.moveDetail.isArrived)
        {
            isRunning = false;
        }
    }

    // Token: 0x06000150 RID: 336 RVA: 0x00002087 File Offset: 0x00000287
    private void OnDestroy()
    {
    }

    // Token: 0x04000082 RID: 130
    private const string _TRAIL_PREFAB_PATH = "Battle/SpecialEffect/ArgaliaSpecialAreaEffect";

    // Token: 0x04000083 RID: 131
    private static int _motionCount;

    // Token: 0x04000084 RID: 132
    private List<BattleFarAreaPlayManager.VictimInfo> _victimList;

    // Token: 0x04000085 RID: 133
    private float _elapsedEndAtk;

    // Token: 0x04000086 RID: 134
    private float _elapsedAtkOneTarget;

    // Token: 0x04000087 RID: 135
    private GameObject _trailObject;

    // Token: 0x04000088 RID: 136
    private int _sign;

    // Token: 0x04000089 RID: 137
    private Vector3 _srcPosAtkOneTarget;

    // Token: 0x0400008A RID: 138
    private Vector3 _dstPosAtkOneTarget;
}
