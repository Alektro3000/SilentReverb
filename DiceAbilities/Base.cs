namespace SilentReverbMod
{
    public class DiceCardAbility_SiRvAdd1Endure : DiceCardAbilityBase
    {
        public override void OnSucceedAttack(BattleUnitModel target)
        {
            base.OnSucceedAttack(target);
            base.owner.bufListDetail.AddKeywordBufByCard(KeywordBuf.Endurance, 1, base.owner);
        }
    }

    public class DiceCardAbility_SiRvAdd1Vibrate : DiceCardAbilityBase
    {
        public override void OnSucceedAttack(BattleUnitModel target)
        {
            base.OnSucceedAttack(target);
            target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Vibrate, 1, base.owner);
        }
    }

    public class DiceCardAbility_SiRvAdd1Vibrate2Bleed : DiceCardAbilityBase
    {
        public override void OnSucceedAttack(BattleUnitModel target)
        {
            base.OnSucceedAttack(target);
            target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Vibrate, 1, base.owner);
            target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Bleeding, 2, base.owner);
        }
        public override string[] Keywords
        {
            get => new string[]
                {
                    "Bleeding_Keyword"
                };
        }
    }
    public class DiceCardAbility_SiRvAdd1VibrateOnClash : DiceCardAbility_SiRvSilentReverbBase
    {
        public override void OnWinParrying()
        {
            base.OnWinParrying();
            base.card.target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Vibrate, 1, base.owner);
        }
    }
    public class DiceCardAbility_SiRvAdd1VibrateOnClashLose : DiceCardAbility_SiRvSilentReverbBase
    {
        public override void OnLoseParrying()
        {
            base.OnLoseParrying();
            base.card.target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Vibrate, 1, base.owner);
        }
    }
    public class DiceCardAbility_SiRvAdd1VibrateToAll : DiceCardAbilityBase
    {
        public override void OnWinParrying()
        {
            base.OnWinParrying();
            BattlePlayingCardDataInUnitModel card = base.card;
            if (card == null)
                return;
            BattleUnitModel target = card.target;
            if (target == null)
                return;

            foreach (BattleUnitModel battleUnitModel in BattleObjectManager.instance.GetAliveList(target.faction))
            {
                if (battleUnitModel == target)
                    battleUnitModel.bufListDetail.AddKeywordBufByCard(KeywordBuf.Vibrate, 1, base.owner);
                else
                    battleUnitModel.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Vibrate, 1, base.owner);

            }
        }
    }
    public class DiceCardAbility_SiRvAdd2Vibrate : DiceCardAbilityBase
    {
        public override void OnSucceedAttack(BattleUnitModel target)
        {
            base.OnSucceedAttack(target);
            target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Vibrate, 2, base.owner);
        }
    }

    public class DiceCardAbility_SiRvAdd2VibrateOnClashLose : DiceCardAbility_SiRvSilentReverbBase
    {
        // Token: 0x06000062 RID: 98 RVA: 0x0000232D File Offset: 0x0000052D
        public override void OnLoseParrying()
        {
            base.OnLoseParrying();
            base.card.target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Vibrate, 2, base.owner);
        }
    }

    public class DiceCardAbility_SiRvAdd3Vibrate : DiceCardAbilityBase
    {
        public override void OnSucceedAttack(BattleUnitModel target)
        {
            base.OnSucceedAttack(target);
            target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Vibrate, 3, base.owner);
        }
    }
    public class DiceCardAbility_SiRvAdd3VibrateOnClash : DiceCardAbility_SiRvSilentReverbBase
    {
        public override void OnWinParrying()
        {
            base.OnWinParrying();
            base.card.target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Vibrate, 3, base.owner);
        }
    }
    public class DiceCardAbility_SiRvAdd5Vibrate : DiceCardAbilityBase
    {
        public override void OnSucceedAttack(BattleUnitModel target)
        {
            base.OnSucceedAttack(target);
            target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Vibrate, 5, base.owner);
        }
    }

}
