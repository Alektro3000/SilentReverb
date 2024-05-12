using LOR_DiceSystem;

namespace SilentReverbMod
{
    // Token: 0x02000096 RID: 150
    public class DiceCardSelfAbility_SiRvResonateHurt : DiceCardSelfAbility_SiRvBase
    {
        // Token: 0x06000235 RID: 565 RVA: 0x0000C024 File Offset: 0x0000A224
        public override void OnUseCard()
        {
            this.card.ignorePower = true;
            if (base.IsResonance() == 0)
            {
                this.card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
                {
                    min = 8
                });
            }
            for (int i = 0; i < base.IsResonance(); i++)
            {
                DiceCardXmlInfo cardItem = ItemXmlDataList.instance.GetCardItem(new LorId("SilentReverb", 45), false);
                BattleDiceBehavior battleDiceBehavior = new BattleDiceBehavior();
                battleDiceBehavior.behaviourInCard = cardItem.DiceBehaviourList[0].Copy();
                battleDiceBehavior.SetIndex(3);
                this.card.AddDice(battleDiceBehavior);
            }
        }

        // Token: 0x06000236 RID: 566 RVA: 0x00007564 File Offset: 0x00005764
        public override void OnStartParrying()
        {
            BattleUnitModel target = this.card.target;
            if (target == null || target.currentDiceAction == null)
            {
                return;
            }
            target.currentDiceAction.ignorePower = true;
        }

        // Token: 0x06000238 RID: 568 RVA: 0x0000C0BC File Offset: 0x0000A2BC
        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            base.BeforeRollDice(behavior);
            BattlePlayingCardDataInUnitModel card = this.card;
            BattleUnitModel battleUnitModel = (card != null) ? card.target : null;
            if (battleUnitModel != null)
            {
                BattleUnitBuf battleUnitBuf = battleUnitModel.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x.bufType == KeywordBuf.Vibrate);
                if (battleUnitBuf != null)
                {
                    int stack = battleUnitBuf.stack;
                    if (behavior != null)
                    {
                        behavior.ApplyDiceStatBonus(new DiceStatBonus
                        {
                            dmg = stack * 2,
                            breakDmg = stack * 2,
                            guardBreakAdder = stack * 2
                        });
                    }
                }
            }
        }
    }
}
