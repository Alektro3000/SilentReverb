using LOR_DiceSystem;
using System.Collections.Generic;
using UnityEngine;

namespace SilentReverbMod
{
    // Token: 0x02000029 RID: 41
    public class DiceCardSelfAbility_SiRvModerato : DiceCardSelfAbility_SiRvEgo
    {
        // Token: 0x0600008D RID: 141 RVA: 0x00003BC8 File Offset: 0x00001DC8
        public override void OnUseCard()
        {
            if (this.card.target == null)
            {
                return;
            }
            for (int i = 0; i < base.IsResonance(); i++)
            {
                this.card.target.allyCardDetail.AddNewCard(new LorId("SilentReverb", 43), false);
            }
            List<BehaviourDetail> list = new List<BehaviourDetail>();
            int resistValue = this.GetResistValue(BehaviourDetail.Slash);
            int resistValue2 = this.GetResistValue(BehaviourDetail.Penetrate);
            int resistValue3 = this.GetResistValue(BehaviourDetail.Hit);
            int num = resistValue;
            if (resistValue2 > num)
            {
                num = resistValue2;
            }
            if (resistValue3 > num)
            {
                num = resistValue3;
            }
            if (num == resistValue)
            {
                list.Add(BehaviourDetail.Slash);
            }
            if (num == resistValue2)
            {
                list.Add(BehaviourDetail.Penetrate);
            }
            if (num == resistValue3)
            {
                list.Add(BehaviourDetail.Hit);
            }
            BehaviourDetail detail = RandomUtil.SelectOne<BehaviourDetail>(list);
            foreach (BattleDiceBehavior battleDiceBehavior in this.card.GetDiceBehaviorList())
            {
                if (base.IsAttackDice(battleDiceBehavior.behaviourInCard.Detail))
                {
                    battleDiceBehavior.behaviourInCard = battleDiceBehavior.behaviourInCard.Copy();
                    battleDiceBehavior.behaviourInCard.Detail = detail;
                }
            }
        }

        // Token: 0x0600008E RID: 142 RVA: 0x00003CF4 File Offset: 0x00001EF4
        private int GetResistValue(BehaviourDetail detail)
        {
            return Mathf.RoundToInt((0f + BookModel.GetResistRate(this.card.target.Book.GetResistHP(detail)) + BookModel.GetResistRate(this.card.target.Book.GetResistBP(detail))) * 10f);
        }

        // Token: 0x0600008F RID: 143 RVA: 0x00002145 File Offset: 0x00000345
        public override ResonanceEffect GetType()
        {
            return ResonanceEffect.AddResonance;
        }

        // Token: 0x06000090 RID: 144 RVA: 0x00002496 File Offset: 0x00000696
        public override int GetStack()
        {
            return 2;
        }
    }
}
