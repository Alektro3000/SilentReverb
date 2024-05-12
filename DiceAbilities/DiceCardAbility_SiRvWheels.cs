using System.Collections.Generic;

namespace SilentReverbMod
{
    // Token: 0x0200001F RID: 31
    public class DiceCardAbility_SiRvWheels : DiceCardAbility_SiRvSilentReverbBase
    {
        // Token: 0x06000068 RID: 104 RVA: 0x000039F0 File Offset: 0x00001BF0
        public override void OnSucceedAttack(BattleUnitModel target)
        {
            base.OnSucceedAttack(target);
            for (int i = 0; i < base.Resonance(); i++)
            {
                List<BattleUnitModel> aliveList = BattleObjectManager.instance.GetAliveList(target.faction);
                for (int j = 0; j < 3; j++)
                {
                    BattleUnitModel battleUnitModel = RandomUtil.SelectOne<BattleUnitModel>(aliveList);
                    aliveList.Remove(battleUnitModel);
                    if (battleUnitModel == target)
                    {
                        battleUnitModel.bufListDetail.AddKeywordBufByCard(KeywordBuf.Vibrate, 2, base.owner);
                    }
                    else
                    {
                        battleUnitModel.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Vibrate, 2, base.owner);
                    }
                }
            }
        }

        // Token: 0x0600006B RID: 107 RVA: 0x0000237D File Offset: 0x0000057D
        public override void BeforeRollDice()
        {
            if (base.Resonance() > 0)
            {
                this.behavior.ApplyDiceStatBonus(new DiceStatBonus
                {
                    dmgRate = 100 * base.Resonance(),
                    breakDmg = 100 * base.Resonance()
                });
            }
        }

        // Token: 0x0600006C RID: 108 RVA: 0x00003A70 File Offset: 0x00001C70
        public override void OnWinParrying()
        {
            if (base.card == null || base.card.target == null || base.card.target.currentDiceAction == null)
            {
                return;
            }
            base.card.target.currentDiceAction.DestroyDice(DiceMatch.NextDice, DiceUITiming.Start);
        }
    }
}
