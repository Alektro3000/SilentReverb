namespace SilentReverbMod
{
    public class DiceCardSelfAbility_SiRvAppasEffect : DiceCardSelfAbility_SiRvBase
    {
        public override void OnUseCard()
        {
            for (int i = 0; i < base.IsResonance(); i++)
            {
                card.ApplyDiceAbility(DiceMatch.AllAttackDice, new DiceCardAbility_SiRvAdd1Endure());
            }
        }
        public override string[] Keywords
        {
            get => new string[]
                {
                    "Endurance_Keyword"
                };

        }
    }
}
