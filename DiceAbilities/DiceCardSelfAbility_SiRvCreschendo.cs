namespace SilentReverbMod
{
    // Token: 0x02000032 RID: 50
    public class DiceCardSelfAbility_SiRvCreschendo : DiceCardSelfAbility_SiRvBase
    {
        // Token: 0x060000AB RID: 171 RVA: 0x00003E04 File Offset: 0x00002004
        public override void OnUseCard()
        {
            card.AddDiceAdder(DiceMatch.LastDice, 2 * BattleObjectManager.instance.GetAliveList((base.owner.faction == Faction.Player) ? Faction.Enemy : Faction.Player).Count);
            foreach (BattleUnitModel battleUnitModel in BattleObjectManager.instance.GetAliveList((base.owner.faction == Faction.Player) ? Faction.Enemy : Faction.Player))
            {
                if (battleUnitModel.bufListDetail.GetActivatedBuf(KeywordBuf.Vibrate) != null && battleUnitModel.bufListDetail.GetActivatedBuf(KeywordBuf.Vibrate).stack >= 5)
                {
                    card.ApplyDiceStatBonus(DiceMatch.LastDice, new DiceStatBonus
                    {
                        min = 4
                    });
                }
            }
            foreach (BattleUnitModel battleUnitModel2 in BattleObjectManager.instance.GetAliveList((base.owner.faction == Faction.Player) ? Faction.Enemy : Faction.Player))
            {
                if (battleUnitModel2.bufListDetail.GetActivatedBuf(KeywordBuf.Vibrate) == null || battleUnitModel2.bufListDetail.GetActivatedBuf(KeywordBuf.Vibrate).stack < 5)
                {
                    return;
                }
            }
            card.ApplyDiceStatBonus(DiceMatch.LastDice, new DiceStatBonus
            {
                min = 20
            });
        }

        // Token: 0x060000AC RID: 172 RVA: 0x00003F70 File Offset: 0x00002170
        public override bool OnChooseCard(BattleUnitModel owner)
        {
            return GetUniqueCardCount() >= 9;
        }

        // Token: 0x060000AD RID: 173 RVA: 0x00003FFC File Offset: 0x000021FC
        public override void OnApplyCard()
        {
            BattleUnitModel owner = base.owner;
            if (owner != null)
            {
                owner.view.charAppearance.ChangeMotion(ActionDetail.Aim);
            }
        }

        // Token: 0x060000AE RID: 174 RVA: 0x00004028 File Offset: 0x00002228
        public override void OnReleaseCard()
        {
            BattleUnitModel owner = base.owner;
            if (owner != null)
            {
                owner.view.charAppearance.ChangeMotion(ActionDetail.Standing);
            }
        }

        // Token: 0x060000AF RID: 175 RVA: 0x0000257A File Offset: 0x0000077A
        public override void OnStartBattle()
        {
            base.OnStartBattle();
            base.owner.bufListDetail.AddBuf(new BattleUnitBuf_SiRvCreschendoBuf());
        }
    }
}
