using LOR_DiceSystem;
using LOR_XML;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace SilentReverbMod
{
    // Token: 0x0200003A RID: 58
    public class PassiveAbility_SilentReverbBoss : PassiveAbilityBase
    {
        // Token: 0x060000DA RID: 218 RVA: 0x000054BC File Offset: 0x000036BC
        public PassiveAbility_SilentReverbBoss()
        {
            Wheels = 8;
            Crystal = 9;
            Largo = 10;
            Assolo = 11;
            Resonate = 12;
            Vivace = 13;
            Libera = 14;
            Moderato = 15;
            stage = -1;
            Furioso = 16;
            FuriosoAll = 20;
            Additional = new List<int>();
            Addit = new List<int>();
            SavedCards = new List<ValueTuple<double, int>>();
            Additional.Add(Vivace);
            Additional.Add(Libera);
            Additional.Add(Moderato);
            Addit.Add(Largo);
            Addit.Add(Assolo);
            Addit.Add(Zelkova);
            Addit.Add(Ranga);
            counter = 0;
            _bInitBgm = false;
            UseLog = false;
        }

        // Token: 0x060000DB RID: 219 RVA: 0x00005604 File Offset: 0x00003804
        public override void OnWaveStart()
        {
            base.OnWaveStart();
            owner.allyCardDetail.SetMaxDrawHand(12);
            owner.allyCardDetail.SetMaxHand(12);
            stage = -1;
            PhaseInit();
            First = true;
            BeginEnemyCount = BattleObjectManager.instance.GetAliveList_opponent(owner.faction).Count;
            if (Phase == 3 || Phase == 2)
            {
                List<BattleUnitModel> aliveList_opponent = BattleObjectManager.instance.GetAliveList_opponent(owner.faction);
                if (aliveList_opponent.Count > 0)
                {
                    BattleUnitModel battleUnitModel = RandomUtil.SelectOne(aliveList_opponent);
                    battleUnitModel.bufListDetail.AddBuf(new PassiveAbility_1310011.BattleUnitBuf_battle
                    {
                        hpAdder = 100,
                        breakGageAdder = 80
                    });
                    battleUnitModel.bufListDetail.AddBuf(new PlusLight());
                    battleUnitModel.cardSlotDetail.SetDefaultRecoverPoint(3);
                    battleUnitModel.cardSlotDetail.SetRecoverPointDefault();
                    battleUnitModel.SetHp(battleUnitModel.MaxHp);
                    battleUnitModel.breakDetail.breakGauge = battleUnitModel.breakDetail.GetDefaultBreakGauge();
                    if (Phase == 3)
                    {
                        battleUnitModel.passiveDetail.AddPassive(new PassiveAbility_170002());
                        battleUnitModel.passiveDetail.AddPassive(new PassiveAbility_250002());
                    }
                }
            }
        }

        // Token: 0x060000DC RID: 220 RVA: 0x00005744 File Offset: 0x00003944
        public void AddCard(int Id)
        {
            CardCounter += 1.0;
            SavedCards.Add(new ValueTuple<double, int>(GetPriorityAdder() - (double)owner.speedDiceCount + CardCounter, Id));
        }

        // Token: 0x060000DD RID: 221 RVA: 0x0000267A File Offset: 0x0000087A
        public void AddCardNotRes(int Id)
        {
            CardCounter += 1.0;
            SavedCards.Add(new ValueTuple<double, int>(GetPriorityAdder(), Id));
        }

        // Token: 0x060000DE RID: 222 RVA: 0x00005794 File Offset: 0x00003994
        public void AddCardChoice()
        {
            CardCounter += 1.0;
            float num = FindResonanceCount(ResonanceEffect.AddResonance);
            float num2 = FindResonanceCount(ResonanceEffect.CloseResonance);
            float num3 = FindResonanceCount(ResonanceEffect.DistantResonance);
            num2 -= num;
            num3 -= num;
            if (UseLog)
            {
                using (StreamWriter streamWriter = new StreamWriter("LogSilentReverb.txt", true))
                {
                    streamWriter.Write(DateTime.Now);
                    streamWriter.WriteLine("-------------------");
                    streamWriter.Write(" Moderato value: ");
                    streamWriter.Write(num);
                    streamWriter.Write(" Vivace Val ");
                    streamWriter.Write(num2);
                    streamWriter.Write(" Libera Val ");
                    streamWriter.WriteLine(num3);
                }
            }
            if (num2 > 2f && num2 > num3)
            {
                SavedCards.Add(new ValueTuple<double, int>(GetPriorityAdder(), 13));
                Type = ResonanceEffect.DistantResonance;
                return;
            }
            if (num3 > 2f && num3 > num2)
            {
                SavedCards.Add(new ValueTuple<double, int>(GetPriorityAdder(), 14));
                Type = ResonanceEffect.CloseResonance;
                return;
            }
            SavedCards.Add(new ValueTuple<double, int>(GetPriorityAdder(), 15));
            Type = ResonanceEffect.AddResonance;
        }

        // Token: 0x060000DF RID: 223 RVA: 0x000058D0 File Offset: 0x00003AD0
        public void AddCardBypass(int Id, int Pos = 0)
        {
            CardCounter += 1.0;
            if (UseLog)
            {
                using (StreamWriter streamWriter = new StreamWriter("LogSilentReverb.txt", true))
                {
                    streamWriter.WriteLine("Bypassing Card selection");
                    streamWriter.WriteLine(DateTime.Now);
                    streamWriter.WriteLine(string.Format("CardsIds Count {0}", SavedIdPerPosition.Count));
                    streamWriter.WriteLine(string.Format("SpeedDice Count {0}", SavedSpeeds.Count));
                    streamWriter.Write("Ids: [ ");
                    for (int i = 0; i < SavedIdPerPosition.Count; i++)
                    {
                        streamWriter.Write(SavedIdPerPosition[i]);
                        streamWriter.Write(" ");
                    }
                    streamWriter.WriteLine("]");
                    streamWriter.Write("Sealed Dices [ ");
                    for (int j = 0; j < SavedIdPerPosition.Count; j++)
                    {
                        streamWriter.Write(SavedSpeeds[j].breaked);
                        streamWriter.Write(" ");
                    }
                    streamWriter.WriteLine("]");
                }
            }

            for (int k = 0; k < SavedIdPerPosition.Count; k++)
            {
                int num = (Pos + k) % SavedIdPerPosition.Count;
                if (UseLog)
                {
                    using (StreamWriter streamWriter2 = new StreamWriter("LogSilentReverb.txt", true))
                    {
                        streamWriter2.WriteLine(string.Format("Candidate {0}, with position {1}", k, num));
                    }
                }
                if (SavedIdPerPosition[num] == -1 && !SavedSpeeds[num].breaked)
                {
                    SavedIdPerPosition[num] = Id;
                    if (UseLog)
                    {
                        using (StreamWriter streamWriter3 = new StreamWriter("LogSilentReverb.txt", true))
                        {
                            streamWriter3.WriteLine(string.Format("Selected Option {0}", num));
                        }
                    }
                    return;
                }
            }
            if (UseLog)
            {
                using (StreamWriter streamWriter4 = new StreamWriter("LogSilentReverb.txt", true))
                {
                    streamWriter4.WriteLine(string.Format("Error, wasn't selected any option", Array.Empty<object>()));
                }
            }
        }

        // Token: 0x060000E0 RID: 224 RVA: 0x00005B54 File Offset: 0x00003D54
        private void PreApplyCards()
        {
            SavedSpeeds = new List<SpeedDice>(owner.speedDiceResult.FindAll((SpeedDice X) => !X.breaked));
            SavedIdPerPosition = new List<int>(new int[SavedSpeeds.Count]);
            for (int i = 0; i < SavedSpeeds.Count; i++)
            {
                SavedIdPerPosition[i] = -1;
            }
        }

        // Token: 0x060000E1 RID: 225 RVA: 0x00005BDC File Offset: 0x00003DDC
        public void ApplyCards()
        {
            CardCounter = 0.0;
            if (UseLog)
            {
                using (StreamWriter streamWriter = new StreamWriter("LogSilentReverb.txt", true))
                {
                    streamWriter.WriteLine("Applying cards");
                }
            }
            List<int> vibrations = GetVibrations();
            SavedCards.Sort();
            foreach (ValueTuple<double, int> valueTuple in SavedCards)
            {
                int item = valueTuple.Item2;
                bool flag = false;
                int num = -1;
                for (int i = 0; i < SavedIdPerPosition.Count; i++)
                {
                    if (SavedIdPerPosition[i] == -1)
                    {
                        if (num == -1)
                        {
                            num = i;
                        }
                        foreach (int num2 in vibrations)
                        {
                            if (Resonance(SavedSpeeds[i].value, num2))
                            {
                                SavedIdPerPosition[i] = item;
                                if (UseLog)
                                {
                                    using (StreamWriter streamWriter2 = new StreamWriter("LogSilentReverb.txt", true))
                                    {
                                        streamWriter2.WriteLine(string.Format("Saved {0} to position {1} via resonance", item, i));
                                    }
                                }
                                vibrations.Remove(num2);
                                flag = true;
                                break;
                            }
                        }
                        if (flag)
                        {
                            break;
                        }
                    }
                }
                if (!flag && num != -1)
                {
                    SavedIdPerPosition[num] = item;
                    if (UseLog)
                    {
                        using (StreamWriter streamWriter3 = new StreamWriter("LogSilentReverb.txt", true))
                        {
                            streamWriter3.WriteLine(string.Format("Saved {0} to position {1}", item, num));
                        }
                    }
                }
            }
            int num3 = 200;
            foreach (int num4 in SavedIdPerPosition)
            {
                BattleDiceCardModel battleDiceCardModel = null;
                if (num4 != -1)
                {
                    battleDiceCardModel = owner.allyCardDetail.AddTempCard(new LorId("SilentReverb", num4));
                }
                if (battleDiceCardModel != null)
                {
                    battleDiceCardModel.SetCostToZero(true);
                    battleDiceCardModel.SetPriorityAdder(num3);
                    num3 -= 10;
                }
            }
            SavedCards.Clear();
        }

        // Token: 0x060000E2 RID: 226 RVA: 0x00005ED4 File Offset: 0x000040D4
        private List<int> GetVibrations()
        {
            List<int> list = new List<int>();
            List<BattleUnitModel> aliveList_opponent = BattleObjectManager.instance.GetAliveList_opponent(owner.faction);
            if (aliveList_opponent.Count > 0)
            {
                BattleUnitBuf activatedBuf = aliveList_opponent[0].bufListDetail.GetActivatedBuf(KeywordBuf.Vibrate);
                if (activatedBuf != null)
                {
                    list.Add(activatedBuf.stack);
                }
            }
            list.Sort();
            return list;
        }

        // Token: 0x060000E3 RID: 227 RVA: 0x00005F30 File Offset: 0x00004130
        public void PhaseInit()
        {
            Phase = 1;
            if (BattleObjectManager.instance.GetAliveList_opponent(owner.faction).Count == 1)
            {
                Phase = 2;
                UnitDataModel unitData = BattleObjectManager.instance.GetAliveList_opponent(owner.faction)[0].UnitData.unitData;
                if (unitData.OwnerSephirah == SephirahType.Keter && unitData.isSephirah)
                {
                    Phase = 3;
                }
            }
        }

        // Token: 0x060000E4 RID: 228 RVA: 0x00005FA8 File Offset: 0x000041A8
        public override void OnAfterRollSpeedDice()
        {
            owner.allyCardDetail.ExhaustAllCards();
            PreApplyCards();
            if (Phase == 4)
            {
                BattleDiceCardModel battleDiceCardModel = owner.allyCardDetail.AddTempCard(new LorId(SilentReverb_ModInit.packageId, FuriosoAll));
                if (battleDiceCardModel != null)
                {
                    battleDiceCardModel.SetCostToZero(true);
                    battleDiceCardModel.SetPriorityAdder(20);
                }
                battleDiceCardModel = owner.allyCardDetail.AddTempCard(new LorId(SilentReverb_ModInit.packageId, Crystal));
                if (battleDiceCardModel != null)
                {
                    battleDiceCardModel.SetCostToZero(true);
                    battleDiceCardModel.SetPriorityAdder(10);
                }
                battleDiceCardModel = owner.allyCardDetail.AddTempCard(new LorId(SilentReverb_ModInit.packageId, 21));
                if (battleDiceCardModel != null)
                {
                    battleDiceCardModel.SetCostToZero(true);
                    battleDiceCardModel.SetPriorityAdder(50);
                }
                return;
            }
            IsCleared = false;
            if (Phase == 1)
            {
                Battle();
            }
            if (Phase == 2)
            {
                DuelNotRoland();
            }
            if (Phase == 3)
            {
                DuelRoland();
            }
            int num = owner.speedDiceResult.Count - SavedCards.Count;
            if (IsCleared)
            {
                num = 0;
                IsCleared = false;
            }
            for (int i = 0; i < num; i++)
            {
                if (i == 1 && GetVibrations().Contains(7) && !SavedCards.Exists((ValueTuple<double, int> x) => x.Item2 == Mook))
                {
                    AddCard(Mook);
                }
                if (i == 0 && (double)RandomUtil.valueForProb < 0.7 && FindResonanceCount(ResonanceEffect.None) <= 1f && !SavedCards.Exists((ValueTuple<double, int> x) => x.Item2 == Furioso) && Type == ResonanceEffect.None)
                {
                    AddCardChoice();
                }
                else
                {
                    AddCard(Addit[counter]);
                    counter++;
                    counter %= 4;
                }
            }
            ApplyCards();
            if (Singleton<StageController>.Instance.RoundTurn >= 6)
            {
                First = false;
            }
            if (Phase == 3)
            {
                stage = (stage + 2) % 6 - 1;
                return;
            }
            stage = (stage + 1) % 5;
        }

        // Token: 0x060000E5 RID: 229 RVA: 0x000026A9 File Offset: 0x000008A9
        private bool Resonance(int Speed, int Vib)
        {
            return SilentPas().IsResonance(Speed, Vib, 0, Type) > 0;
        }

        // Token: 0x060000E6 RID: 230 RVA: 0x000061DC File Offset: 0x000043DC
        public override BattleUnitModel ChangeAttackTarget(BattleDiceCardModel card, int idx)
        {
            BattleUnitModel battleUnitModel = RandomUtil.SelectOne<BattleUnitModel>(BattleObjectManager.instance.GetAliveList(Faction.Player).FindAll((BattleUnitModel x) => x.bufListDetail.GetActivatedBuf(KeywordBuf.Vibrate) != null && x.IsTargetable(owner) && Resonance(owner.GetSpeedDiceResult(idx).value, x.bufListDetail.GetActivatedBuf(KeywordBuf.Vibrate).stack)));
            if (battleUnitModel != null)
            {
                return battleUnitModel;
            }
            BattleUnitModel battleUnitModel2 = BattleObjectManager.instance.GetAliveList_opponent(owner.faction).Find((BattleUnitModel x) => x.UnitData.unitData.OwnerSephirah == SephirahType.Keter && x.UnitData.unitData.isSephirah);
            if (battleUnitModel2 != null && (double)RandomUtil.valueForProb <= 0.7)
            {
                return battleUnitModel2;
            }
            return base.ChangeAttackTarget(card, idx);
        }

        // Token: 0x060000E7 RID: 231 RVA: 0x000026C2 File Offset: 0x000008C2
        public override int GetSpeedDiceAdder(int speedDiceResult)
        {
            if (Phase == 4)
            {
                return 99;
            }
            return base.GetSpeedDiceAdder(speedDiceResult);
        }

        // Token: 0x060000E8 RID: 232 RVA: 0x00006284 File Offset: 0x00004484
        public override void OnRoundStart()
        {
            if (owner.hp < 26f && Phase != 4)
            {
                Phase = 4;
                owner.bufListDetail.RemoveBufAll();
                if (owner.turnState == BattleUnitTurnState.BREAK)
                {
                    owner.turnState = BattleUnitTurnState.WAIT_CARD;
                }
                owner.breakDetail.nextTurnBreak = false;
                owner.breakDetail.RecoverBreakLife(1, false);
                owner.breakDetail.RecoverBreak(owner.breakDetail.GetDefaultBreakGauge());
                owner.view.DisplayDlg(DialogType.SPECIAL_EVENT);
            }
            InitBgm();
            RandomUtil.SelectOne<BattleUnitModel>(BattleObjectManager.instance.GetAliveList_opponent(owner.faction)).bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Vibrate, RandomUtil.SelectOne<int>(new int[]
            {
                2,
                3
            }), owner);
        }

        // Token: 0x060000E9 RID: 233 RVA: 0x000026D7 File Offset: 0x000008D7
        public override int GetMinHp()
        {
            if (Phase < 4)
            {
                return 25;
            }
            return base.GetMinHp();
        }

        // Token: 0x060000EA RID: 234 RVA: 0x00006380 File Offset: 0x00004580
        private void InitBgm()
        {
            if (_bInitBgm)
            {
                return;
            }
            _bInitBgm = true;
            int emotionTotalCoinNumber = Singleton<StageController>.Instance.GetCurrentStageFloorModel().team.emotionTotalCoinNumber;
            Singleton<StageController>.Instance.GetCurrentWaveModel().team.emotionTotalBonus = emotionTotalCoinNumber + 100;
            AudioClip[] array = new AudioClip[3];
            AudioClip audioClip = Resources.Load<AudioClip>("Sounds/Battle/Reverberation1st_Argalia");
            if (audioClip != null)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = audioClip;
                }
                _oldEnemytheme = SingletonBehavior<BattleSoundManager>.Instance.SetEnemyTheme(array);
                SingletonBehavior<BattleSoundManager>.Instance.ChangeEnemyTheme(0);
                return;
            }
        }

        // Token: 0x060000EB RID: 235 RVA: 0x00006414 File Offset: 0x00004614
        public override bool CanAddBuf(BattleUnitBuf buf)
        {
            if (buf != null)
            {
                KeywordBuf bufType = buf.bufType;
                if (bufType == KeywordBuf.Binding || bufType == KeywordBuf.Quickness)
                {
                    return false;
                }
            }
            return base.CanAddBuf(buf);
        }

        // Token: 0x060000EC RID: 236 RVA: 0x000026EB File Offset: 0x000008EB
        public override void OnRoundEnd()
        {
            if (BattleObjectManager.instance.GetAliveList_opponent(owner.faction).Count > 1)
            {
                owner.bufListDetail.AddKeywordBufByCard(KeywordBuf.Strength, 3, owner);
            }
        }

        // Token: 0x060000ED RID: 237 RVA: 0x00002723 File Offset: 0x00000923
        public PassiveAbility_SilentReverb SilentPas()
        {
            return owner.passiveDetail.PassiveList.Find((PassiveAbilityBase x) => x is PassiveAbility_SilentReverb) as PassiveAbility_SilentReverb;
        }

        // Token: 0x060000EE RID: 238 RVA: 0x0000275E File Offset: 0x0000095E
        public void ClearAdditional()
        {
            IsCleared = true;
        }

        // Token: 0x060000EF RID: 239 RVA: 0x00002767 File Offset: 0x00000967
        public double GetPriorityAdder() => (double)RandomUtil.valueForProb;

        // Token: 0x060000F0 RID: 240 RVA: 0x00006440 File Offset: 0x00004640
        public override int SpeedDiceNumAdder()
        {
            if (Phase == 4)
                return 2 - owner.emotionDetail.SpeedDiceNumAdder();

            int num = 0;
            if (Singleton<StageController>.Instance.RoundTurn >= 2)
                num++;

            if (Phase == 1)
                return 6 + num;

            return 4 + num;
        }

        // Token: 0x060000F1 RID: 241 RVA: 0x0000648C File Offset: 0x0000468C
        private void DuelRoland()
        {
            if (stage == -1)
            {
                AddCard(Appas);
                AddCardChoice();
                AddCard(Mook);
                AddCard(Ranga);
                AddCard(Animato);
                return;
            }
            if (stage == 0)
            {
                AddCard(Wheels);
                AddCardChoice();
                AddCard(OldBoys);
                AddCard(Zelkova);
                AddCard(Allas);
                AddCard(Ranga);
                return;
            }
            if (stage == 1)
            {
                AddCard(Crystal);
                AddCardChoice();
                AddCard(Appas);
                AddCard(Resonate);
                AddCard(Largo);
                AddCard(Zelkova);
                return;
            }
            if (stage == 2)
            {
                AddCard(Animato);
                AddCardChoice();
                AddCard(Allas);
                AddCard(Mook);
                AddCard(OldBoys);
                return;
            }
            if (stage == 3)
            {
                AddCard(Crystal);
                AddCardChoice();
                AddCard(Resonate);
                AddCard(Appas);
                AddCard(Assolo);
                return;
            }
            if (stage == 4)
            {
                AddCardBypass(Furioso, 0);
                AddCard(Resonate);
                AddCard(Appas);
                AddCard(Assolo);
                AddCard(Largo);
                ClearAdditional();
                return;
            }
        }

        // Token: 0x060000F2 RID: 242 RVA: 0x00006640 File Offset: 0x00004840
        private void DuelNotRoland()
        {
            if (stage == -1)
            {
                AddCardNotRes(Wheels);
                AddCard(Animato);
                AddCard(OldBoys);
                AddCard(Zelkova);
                AddCard(Allas);
                return;
            }
            if (stage == 0)
            {
                AddCard(Appas);
                AddCard(Ranga);
                AddCard(OldBoys);
                AddCard(Animato);
                AddCardChoice();
                return;
            }
            if (stage == 1)
            {
                AddCard(Crystal);
                AddCard(Appas);
                AddCard(Resonate);
                AddCard(Largo);
                AddCard(Assolo);
                return;
            }
            if (stage == 2)
            {
                AddCard(Animato);
                AddCard(Allas);
                AddCard(Allas);
                AddCard(Mook);
                AddCard(OldBoys);
                return;
            }
            if (stage == 3)
            {
                if (First)
                {
                    AddCard(Wheels);
                    AddCard(OldBoys);
                    AddCard(Largo);
                }
                else
                {
                    AddCardBypass(Furioso, 0);
                    ClearAdditional();
                }
                AddCard(Appas);
                AddCard(Resonate);
                AddCard(Assolo);
                return;
            }
            if (stage == 4)
            {
                if (First)
                {
                    AddCardBypass(Furioso, 0);
                    ClearAdditional();
                }
                else
                {
                    AddCard(Wheels);
                    AddCard(OldBoys);
                    AddCard(Zelkova);
                }
                AddCard(Appas);
                AddCard(Assolo);
                AddCard(Ranga);
                return;
            }
            if (stage == 5)
            {
                AddCard(Wheels);
                AddCard(Animato);
                AddCard(OldBoys);
                AddCard(Assolo);
                AddCard(Allas);
                AddCardChoice();
                return;
            }
        }

        // Token: 0x060000F3 RID: 243 RVA: 0x00006888 File Offset: 0x00004A88
        private void Battle()
        {
            if (stage == -1)
            {
                AddCardNotRes(Wheels);
                AddCard(Animato);
                AddCard(OldBoys);
                AddCard(Zelkova);
                AddCard(Zelkova);
                AddCard(Allas);
                AddCard(Allas);
                return;
            }
            if (stage == 0)
            {
                AddCard(Mook);
                AddCard(Appas);
                AddCard(Ranga);
                AddCard(OldBoys);
                AddCard(Animato);
                AddCardChoice();
                return;
            }
            if (stage == 1)
            {
                AddCard(Crystal);
                AddCard(Appas);
                AddCard(Animato);
                AddCard(Resonate);
                AddCard(Assolo);
                AddCard(OldBoys);
                return;
            }
            if (stage == 2)
            {
                if (First)
                {
                    AddCardBypass(Furioso, 0);
                    ClearAdditional();
                }
                else
                {
                    AddCard(Appas);
                }
                AddCard(Appas);
                AddCard(Resonate);
                AddCard(OldBoys);
                AddCard(Allas);
                AddCardChoice();
                return;
            }
            if (stage == 3)
            {
                if (First)
                {
                    AddCard(Wheels);
                    AddCard(Appas);
                    AddCard(OldBoys);
                }
                else
                {
                    AddCardBypass(Furioso, 0);
                    AddCard(Appas);
                    AddCard(Appas);
                    ClearAdditional();
                }
                AddCard(Largo);
                AddCard(Assolo);
                return;
            }
            if (stage == 4)
            {
                AddCard(Wheels);
                AddCard(Animato);
                AddCard(OldBoys);
                AddCard(Zelkova);
                AddCard(Allas);
                AddCard(Allas);
                AddCardChoice();
                return;
            }
        }

        // Token: 0x060000F6 RID: 246 RVA: 0x00006ACC File Offset: 0x00004CCC
        public float FindResonanceCount(ResonanceEffect Type)
        {
            double num = 0.0;
            foreach (int speed in GetVibrations())
            {
                foreach (SpeedDice speedDice in owner.speedDiceResult)
                {
                    num += (double)Math.Min(1, SilentPas().IsResonance(speed, speedDice.value, 1, Type));
                }
            }
            return (float)(num / Math.Pow((double)GetVibrations().Count, 0.5));
        }

        // Token: 0x04000035 RID: 53
        public int GetFinal;

        // Token: 0x04000036 RID: 54
        public int Zelkova = 1;

        // Token: 0x04000037 RID: 55
        public int Ranga = 2;

        // Token: 0x04000038 RID: 56
        public int OldBoys = 3;

        // Token: 0x04000039 RID: 57
        public int Allas = 4;

        // Token: 0x0400003A RID: 58
        public int Mook = 5;

        // Token: 0x0400003B RID: 59
        public int Animato = 6;

        // Token: 0x0400003C RID: 60
        public int Wheels;

        // Token: 0x0400003D RID: 61
        public int Crystal;

        // Token: 0x0400003E RID: 62
        public int Largo;

        // Token: 0x0400003F RID: 63
        public int Assolo;

        // Token: 0x04000040 RID: 64
        public int Resonate;

        // Token: 0x04000041 RID: 65
        public int Vivace;

        // Token: 0x04000042 RID: 66
        public int Libera;

        // Token: 0x04000043 RID: 67
        public int Moderato;

        // Token: 0x04000044 RID: 68
        private int stage;

        // Token: 0x04000045 RID: 69
        public bool First;

        // Token: 0x04000046 RID: 70
        public int Furioso;

        // Token: 0x04000047 RID: 71
        private List<int> Additional;

        // Token: 0x04000048 RID: 72
        public int Phase;

        // Token: 0x04000049 RID: 73
        private List<int> Addit;

        // Token: 0x0400004A RID: 74
        private int counter;

        // Token: 0x0400004B RID: 75
        private bool _bInitBgm;

        // Token: 0x0400004C RID: 76
        private bool UseLog;

        // Token: 0x0400004D RID: 77
        public int Appas = 7;

        // Token: 0x0400004E RID: 78
        public int FuriosoAll;

        // Token: 0x0400004F RID: 79
        private AudioClip[] _oldEnemytheme;

        // Token: 0x04000050 RID: 80
        private double CardCounter;

        // Token: 0x04000051 RID: 81
        public bool IsCleared;

        // Token: 0x04000052 RID: 82
        private int BeginEnemyCount;

        // Token: 0x04000053 RID: 83
        private List<ValueTuple<double, int>> SavedCards;

        // Token: 0x04000054 RID: 84
        private List<SpeedDice> SavedSpeeds;

        // Token: 0x04000055 RID: 85
        private List<int> SavedIdPerPosition;

        // Token: 0x04000056 RID: 86
        public ResonanceEffect Type;

        // Token: 0x0200003B RID: 59
        public class PlusLight : BattleUnitBuf
        {
            // Token: 0x060000F7 RID: 247 RVA: 0x00002496 File Offset: 0x00000696
            public override int MaxPlayPointAdder()
            {
                return 2;
            }

            // Token: 0x060000F8 RID: 248 RVA: 0x0000278F File Offset: 0x0000098F
            public PlusLight()
            {
                stack = 0;
            }
        }
    }
}
