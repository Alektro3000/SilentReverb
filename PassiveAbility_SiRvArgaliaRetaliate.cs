using LOR_DiceSystem;
using System.Collections.Generic;

namespace SilentReverbMod
{
    // Token: 0x02000064 RID: 100
    public class PassiveAbility_SiRvArgaliaRetaliate : PassiveAbilityBase
    {
        // Token: 0x06000183 RID: 387 RVA: 0x00008284 File Offset: 0x00006484
        public override void OnStartBattle()
        {
            base.OnStartBattle();
            DiceCardXmlInfo cardItem = ItemXmlDataList.instance.GetCardItem(new LorId("SilentReverb", 40), false);
            new DiceBehaviour();
            List<BattleDiceBehavior> list = new List<BattleDiceBehavior>();
            int num = 0;
            foreach (DiceBehaviour diceBehaviour in cardItem.DiceBehaviourList)
            {
                BattleDiceBehavior battleDiceBehavior = new BattleDiceBehavior();
                battleDiceBehavior.behaviourInCard = diceBehaviour.Copy();
                battleDiceBehavior.SetIndex(num++);
                list.Add(battleDiceBehavior);
            }
            owner.cardSlotDetail.keepCard.AddBehaviours(cardItem, list);
        }
    }
}
