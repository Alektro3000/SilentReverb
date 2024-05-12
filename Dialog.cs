using LOR_XML;

// Token: 0x02000067 RID: 103
public class BattleDialogueModel_BlackArgalia : BattleDialogueModel
{
    // Token: 0x0600018A RID: 394 RVA: 0x00002CC5 File Offset: 0x00000EC5
    public BattleDialogueModel_BlackArgalia(BattleDialogCharacter battleDlg) : base(battleDlg)
    {
    }

    // Token: 0x0600018B RID: 395 RVA: 0x00008340 File Offset: 0x00006540
    public override string GetBattleDlg(DialogType dlgType)
    {
        switch (Singleton<StageController>.Instance.CurrentFloor)
        {
            case SephirahType.Gebura:
                if (BattleObjectManager.instance.GetList(Faction.Player).Exists((BattleUnitModel x) => x.UnitData.unitData.defaultBook.GetBookClassInfoId() == 6))
                {
                    string battleDlg = SilentReverb_ModInit.GetBattleDlg(dlgType, "BlackArgaliaGebura");
                    if (battleDlg != "")
                        return battleDlg;
                }
                break;
            case SephirahType.Binah:
                if (BattleObjectManager.instance.GetList(Faction.Player).Exists((BattleUnitModel x) => x.UnitData.unitData.defaultBook.GetBookClassInfoId() == 8))
                {
                    string battleDlg2 = SilentReverb_ModInit.GetBattleDlg(dlgType, "BlackArgaliaBinah");
                    if (battleDlg2 != "")
                        return battleDlg2;
                }
                break;
            case SephirahType.Keter:
                if (BattleObjectManager.instance.GetList(Faction.Player).Exists((BattleUnitModel x) => x.UnitData.unitData.defaultBook.GetBookClassInfoId() == 10))
                {
                    string battleDlg3 = SilentReverb_ModInit.GetBattleDlg(dlgType, "BlackArgaliaRoland");
                    if (battleDlg3 != "")
                        return battleDlg3;
                }
                break;
        }
        return base.GetBattleDlg(dlgType);
    }
}
