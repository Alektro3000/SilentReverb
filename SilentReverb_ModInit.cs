using Battle.DiceAttackEffect;
using HarmonyLib;
using LOR_BattleUnit_UI;
using LOR_XML;
using SMotionLoader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using UI;
using UnityEngine;
using UnityEngine.UI;
using Workshop;

// Token: 0x02000037 RID: 55
public class SilentReverb_ModInit : ModInitializer
{
    // Token: 0x1700000B RID: 11
    // (get) Token: 0x060000BF RID: 191 RVA: 0x000025E4 File Offset: 0x000007E4
    public static string path
    {
        get
        {
            if (SilentReverb_ModInit._path == null)
            {
                SilentReverb_ModInit._path = Path.GetDirectoryName(Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path));
            }
            return SilentReverb_ModInit._path;
        }
    }

    // Token: 0x060000C1 RID: 193 RVA: 0x00004194 File Offset: 0x00002394
    static SilentReverb_ModInit()
    {
        SilentReverb_ModInit.sprites2 = new List<Sprite>();
        SilentReverb_ModInit.sprites3 = new List<Sprite>();
        SilentReverb_ModInit.sprites4 = new List<Sprite>();
        SilentReverb_ModInit.vector = Vector3.zero;
        SilentReverb_ModInit.vector2 = Vector3.zero;
        SilentReverb_ModInit.ArtWorks = new Dictionary<string, Sprite>();
    }

    // Token: 0x060000C2 RID: 194 RVA: 0x00004220 File Offset: 0x00002420
    public override void OnInitializeMod()
    {
        SilentReverb_ModInit.language = GlobalGameManager.Instance.CurrentOption.language;
        SilentReverb_ModInit.AddLocalize();
        Harmony harmony = new Harmony("LOR.SilentReverb_Mod");
        MethodInfo method = typeof(SilentReverb_ModInit).GetMethod("UISettingInvenEquipPageListSlot_SetBooksData");
        harmony.Patch(typeof(UISettingInvenEquipPageListSlot).GetMethod("SetBooksData", AccessTools.all), new HarmonyMethod(method), null, null, null, null);
        SilentReverb_ModInit.GetArtWorks(new DirectoryInfo(SilentReverb_ModInit.path + "/ArtWork"));
        SilentReverb_ModInit.uiinit = true;
        SilentReverb_ModInit.uiinit2 = true;
        method = typeof(SilentReverb_ModInit).GetMethod("UnitDataModel_InitBattleDialogByDefaultBook");
        harmony.Patch(typeof(UnitDataModel).GetMethod("InitBattleDialogByDefaultBook", AccessTools.all), new HarmonyMethod(method), null, null, null, null);
        method = typeof(SilentReverb_ModInit).GetMethod("BattleDialogueModel_6_GetBattleDlg_Pre");
        harmony.Patch(typeof(BattleDialogueModel_6).GetMethod("GetBattleDlg", AccessTools.all, null, new Type[]
        {
            typeof(DialogType)
        }, null), new HarmonyMethod(method), null, null, null, null);
        method = typeof(SilentReverb_ModInit).GetMethod("BattleDialogueModel_8_GetBattleDlg_Pre");
        harmony.Patch(typeof(BattleDialogueModel_8).GetMethod("GetBattleDlg", AccessTools.all, null, new Type[]
        {
            typeof(DialogType)
        }, null), new HarmonyMethod(method), null, null, null, null);
        method = typeof(SilentReverb_ModInit).GetMethod("BattleDialogueModel_10_GetBattleDlg_Pre");
        harmony.Patch(typeof(BattleDialogueModel_10).GetMethod("GetBattleDlg", AccessTools.all, null, new Type[]
        {
            typeof(DialogType)
        }, null), new HarmonyMethod(method), null, null, null, null);
        method = typeof(SilentReverb_ModInit).GetMethod("UnitDataModel_InitBattleDialogByDefaultBook");
        harmony.Patch(typeof(UnitDataModel).GetMethod("InitBattleDialogByDefaultBook", AccessTools.all), new HarmonyMethod(method), null, null, null, null);
        SilentReverb_ModInit.uiinit = true;
        SilentReverb_ModInit.uiinit2 = true;
        SilentReverb_ModInit.uiinit3 = true;
        SilentReverb_ModInit.Init = true;
        method = typeof(SilentReverb_ModInit).GetMethod("BattleDiceCardUI_SetCardPrefix");
        harmony.Patch(typeof(BattleDiceCardUI).GetMethod("SetCard", AccessTools.all), new HarmonyMethod(method), null, null, null, null);
        method = typeof(SilentReverb_ModInit).GetMethod("UIOriginCardSlot_SetDataPrefix");
        harmony.Patch(typeof(UIOriginCardSlot).GetMethod("SetData", AccessTools.all), new HarmonyMethod(method), null, null, null, null);
        method = typeof(SilentReverb_ModInit).GetMethod("BattleDiceCardUI_SetCard");
        harmony.Patch(typeof(BattleDiceCardUI).GetMethod("SetCard", AccessTools.all), null, new HarmonyMethod(method), null, null, null);
        method = typeof(SilentReverb_ModInit).GetMethod("UIOriginCardSlot_SetData");
        harmony.Patch(typeof(UIOriginCardSlot).GetMethod("SetData", AccessTools.all), null, new HarmonyMethod(method), null, null, null);
        method = typeof(SilentReverb_ModInit).GetMethod("DiceEffectManager_CreateBehaviourEffect_Pre");
        harmony.Patch(typeof(DiceEffectManager).GetMethod("CreateBehaviourEffect", AccessTools.all), new HarmonyMethod(method), null, null, null, null);
        method = typeof(SilentReverb_ModInit).GetMethod("DiceEffectManager_CreateBehaviourEffect");
        harmony.Patch(typeof(DiceEffectManager).GetMethod("CreateBehaviourEffect", AccessTools.all), new HarmonyMethod(method), null, null, null, null);
        method = typeof(SilentReverb_ModInit).GetMethod("SpeedDiceUI_CheckBlockDice");
        harmony.Patch(typeof(SpeedDiceUI).GetMethod("CheckBlockDice", AccessTools.all), null, new HarmonyMethod(method), null, null, null);
        method = typeof(SilentReverb_ModInit).GetMethod("BookModel_GetThumbSprite");
        harmony.Patch(typeof(BookModel).GetMethod("GetThumbSprite", AccessTools.all), new HarmonyMethod(method), null, null, null, null);
        Events.OnSkinReloadingCompletion += SilentReverb_ModInit.CopySkinToProjections;
    }

    // Token: 0x060000C3 RID: 195 RVA: 0x00004650 File Offset: 0x00002850
    public static void CopySkinToProjections()
    {
        Singleton<CustomizingBookSkinLoader>.Instance.GetWorkshopBookSkinData("SilentReverb", "BlackArgalia");
        WorkshopSkinData workshopBookSkinData = Singleton<CustomizingBookSkinLoader>.Instance.GetWorkshopBookSkinData("SilentReverb", "BlackArgaliaLib");
        if (workshopBookSkinData != null)
        {
            workshopBookSkinData.id = (Traverse.Create(Singleton<CustomizingResourceLoader>.Instance).Field("_skinData").GetValue() as Dictionary<string, WorkshopSkinData>).Count;
            (Traverse.Create(Singleton<CustomizingResourceLoader>.Instance).Field("_skinData").GetValue() as Dictionary<string, WorkshopSkinData>)[workshopBookSkinData.contentFolderIdx] = workshopBookSkinData;
        }
    }

    // Token: 0x060000C4 RID: 196 RVA: 0x000046E0 File Offset: 0x000028E0
    public static bool UISettingInvenEquipPageListSlot_SetBooksData(UISettingInvenEquipPageListSlot __instance, List<BookModel> books, UIStoryKeyData storyKey)
    {
        Image image = (Image)__instance.GetType().GetField("img_IconGlow", AccessTools.all).GetValue(__instance);
        Image image2 = (Image)__instance.GetType().GetField("img_Icon", AccessTools.all).GetValue(__instance);
        UIEquipPageScrollList listRoot = (UIEquipPageScrollList)__instance.GetType().GetField("listRoot", AccessTools.all).GetValue(__instance);
        List<UIOriginEquipPageSlot> list = (List<UIOriginEquipPageSlot>)__instance.GetType().GetField("equipPageSlotList", AccessTools.all).GetValue(__instance);
        if (books.Count >= 0)
        {
            image.enabled = true;
            image2.enabled = true;
            image2.sprite = SilentReverb_ModInit.ArtWorks["Icon"];
            image.sprite = SilentReverb_ModInit.ArtWorks["Icon"];
        }
        __instance.SetFrameColor(UIColorManager.Manager.GetUIColor(UIColor.Default));
        List<BookModel> list2 = new List<BookModel>((List<BookModel>)typeof(UIInvenEquipPageListSlot).GetMethod("ApplyFilterBooksInStory", AccessTools.all).Invoke(__instance, new object[]
        {
            books
        }));
        __instance.SetEquipPagesData(list2);
        BookModel bookModel = list2.Find((BookModel x) => x == UI.UIController.Instance.CurrentUnit.bookItem);
        if (listRoot.CurrentSelectedBook == null && bookModel != null)
        {
            listRoot.CurrentSelectedBook = bookModel;
        }
        if (listRoot.CurrentSelectedBook != null)
        {
            UIOriginEquipPageSlot uioriginEquipPageSlot = list.Find((UIOriginEquipPageSlot x) => x.BookDataModel == listRoot.CurrentSelectedBook);
            if (uioriginEquipPageSlot != null)
            {
                uioriginEquipPageSlot.SetHighlighted(true, true, false);
            }
        }
        __instance.SetSlotSize();
        return false;
    }

    // Token: 0x060000C5 RID: 197 RVA: 0x00004890 File Offset: 0x00002A90
    public static void GetArtWorks(DirectoryInfo dir)
    {
        if (dir.GetDirectories().Length != 0)
        {
            DirectoryInfo[] directories = dir.GetDirectories();
            for (int i = 0; i < directories.Length; i++)
            {
                SilentReverb_ModInit.GetArtWorks(directories[i]);
            }
        }
        foreach (System.IO.FileInfo fileInfo in dir.GetFiles())
        {
            Texture2D texture2D = new Texture2D(2, 2);
            texture2D.LoadImage(File.ReadAllBytes(fileInfo.FullName));
            Sprite value = Sprite.Create(texture2D, new Rect(0f, 0f, (float)texture2D.width, (float)texture2D.height), new Vector2(0f, 0f));
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileInfo.FullName);
            SilentReverb_ModInit.ArtWorks[fileNameWithoutExtension] = value;
        }
    }

    // Token: 0x060000C6 RID: 198 RVA: 0x00004950 File Offset: 0x00002B50
    public static void BattleDiceCardUI_SetCardPrefix(BattleDiceCardUI __instance, Sprite[] ___costNumberSprite, NumbersData ___costNumbers, ref Color ___colorFrame, ref Color ___colorLineardodge, ref Color ___colorLineardodge_deactive, BattleDiceCardModel cardModel, params BattleDiceCardUI.Option[] options)
    {
        if (cardModel != null && !SilentReverb_ModInit.uiinit)
        {
            __instance.img_Frames[0].sprite = SilentReverb_ModInit.sprites[0];
            __instance.img_Frames[1].sprite = SilentReverb_ModInit.sprites[1];
            __instance.img_Frames[2].sprite = SilentReverb_ModInit.sprites[1];
            __instance.img_Frames[3].sprite = SilentReverb_ModInit.sprites[1];
            __instance.img_Frames[4].sprite = SilentReverb_ModInit.sprites[2];
            ___costNumbers.firstNumbers.content.gameObject.transform.localPosition = SilentReverb_ModInit.vector;
        }
    }

    // Token: 0x060000C7 RID: 199 RVA: 0x00004A08 File Offset: 0x00002C08
    public static void BattleDiceCardUI_SetCard(BattleDiceCardUI __instance, Sprite[] ___costNumberSprite, NumbersData ___costNumbers, ref Color ___colorFrame, ref Color ___colorLineardodge, ref Color ___colorLineardodge_deactive, BattleDiceCardModel cardModel, params BattleDiceCardUI.Option[] options)
    {
        if (cardModel != null && cardModel.GetID().packageId == "SilentReverb")
        {
            if (SilentReverb_ModInit.uiinit)
            {
                SilentReverb_ModInit.uiinit = false;
                SilentReverb_ModInit.sprites.Add(__instance.img_Frames[0].sprite);
                SilentReverb_ModInit.sprites.Add(__instance.img_Frames[1].sprite);
                SilentReverb_ModInit.sprites.Add(__instance.img_Frames[4].sprite);
                SilentReverb_ModInit.vector = ___costNumbers.firstNumbers.content.gameObject.transform.localPosition;
                SilentReverb_ModInit.vector2 = ___costNumbers.firstNumbers.content.gameObject.transform.localPosition + new Vector3(25f, 0f, 0f);
            }
            if (cardModel.GetID().packageId == "SilentReverb")
            {
                ___colorFrame = new Color(1f, 1f, 1f, 1f);
                ___colorLineardodge = new Color(1f, 1f, 1f, 0f);
                ___colorLineardodge_deactive = new Color(1f, 1f, 1f, 0f);
                ___colorLineardodge_deactive.a = 0f;
                __instance.img_Frames[0].sprite = SilentReverb_ModInit.ArtWorks["ReverbLeftPage_Base"];
                __instance.img_Frames[1].sprite = SilentReverb_ModInit.ArtWorks["Reverb_bufBaseFrame"];
                __instance.img_Frames[2].sprite = SilentReverb_ModInit.ArtWorks["Reverb_bufBaseFrame"];
                __instance.img_Frames[3].sprite = SilentReverb_ModInit.ArtWorks["Reverb_bufBaseFrame"];
                __instance.img_Frames[4].sprite = SilentReverb_ModInit.ArtWorks["ReverbRightPage_Base"];
                ___costNumbers.firstNumbers.content.gameObject.transform.localPosition = SilentReverb_ModInit.vector;
                __instance.GetType().GetMethod("SetFrameColor", AccessTools.all).Invoke(__instance, new object[]
                {
                    ___colorFrame
                });
                __instance.GetType().GetMethod("SetRangeIconHsv", AccessTools.all).Invoke(__instance, new object[]
                {
                    SilentReverb_ModInit.___colorRange
                });
                __instance.GetType().GetMethod("SetLinearDodgeColor", AccessTools.all, null, new Type[]
                {
                    typeof(Color)
                }, null).Invoke(__instance, new object[]
                {
                    ___colorLineardodge
                });
            }
        }
    }

    // Token: 0x060000C8 RID: 200 RVA: 0x00004CBC File Offset: 0x00002EBC
    public static void UIOriginCardSlot_SetDataPrefix(UIOriginCardSlot __instance, DiceCardItemModel cardmodel, Image[] ___img_Frames, Image ___img_Artwork, ref Color ___colorFrame, ref Color ___colorLineardodge)
    {
        if (cardmodel != null && !SilentReverb_ModInit.uiinit2)
        {
            ___img_Frames[0].sprite = SilentReverb_ModInit.sprites2[0];
            if (__instance is UIDetailCardSlot && SilentReverb_ModInit.sprites2.Count > 1)
            {
                __instance.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Image>().sprite = SilentReverb_ModInit.sprites2[1];
            }
        }
    }

    // Token: 0x060000C9 RID: 201 RVA: 0x00004D34 File Offset: 0x00002F34
    public static void UIOriginCardSlot_SetData(UIOriginCardSlot __instance, DiceCardItemModel cardmodel, Image[] ___img_Frames, Image ___img_Artwork, ref Color ___colorFrame, ref Color ___colorLineardodge)
    {
        if (cardmodel != null && cardmodel.GetID().packageId == "SilentReverb" && __instance.CardModel.GetID().id >= 1 && __instance.CardModel.GetID().id <= 31)
        {
            ___colorFrame = new Color(1f, 1f, 1f, 1f);
            ___colorLineardodge = new Color(1f, 1f, 1f, 0f);
            if (SilentReverb_ModInit.uiinit2)
            {
                SilentReverb_ModInit.uiinit2 = false;
                SilentReverb_ModInit.sprites2.Add(___img_Frames[0].sprite);
            }
            if (SilentReverb_ModInit.sprites2.Count == 1 && __instance is UIDetailCardSlot)
            {
                Image component = __instance.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Image>();
                SilentReverb_ModInit.sprites2.Add(component.sprite);
            }
            ___img_Frames[0].sprite = SilentReverb_ModInit.ArtWorks["ReverbLeftPage_Base"];
            if (__instance is UIDetailCardSlot)
            {
                __instance.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Image>().sprite = SilentReverb_ModInit.ArtWorks["ReverbRightPage_Base"];
            }
            __instance.GetType().GetMethod("SetFrameColor", AccessTools.all).Invoke(__instance, new object[]
            {
                ___colorFrame
            });
            __instance.GetType().GetMethod("SetRangeIconHsv", AccessTools.all).Invoke(__instance, new object[]
            {
                SilentReverb_ModInit.___colorRange
            });
            __instance.GetType().GetMethod("SetLinearDodgeColor", AccessTools.all, null, new Type[]
            {
                typeof(Color)
            }, null).Invoke(__instance, new object[]
            {
                ___colorLineardodge
            });
        }
    }

    // Token: 0x060000CA RID: 202 RVA: 0x00004F3C File Offset: 0x0000313C
    public static bool DiceEffectManager_CreateBehaviourEffect(ref DiceAttackEffect __result, string resource, float scaleFactor, BattleUnitView self, BattleUnitView target, float time = 1f)
    {
        bool result;
        if (resource == null)
        {
            __result = null;
            result = false;
        }
        else
        {
            if (!SilentReverb_ModInit.CustomEffects.ContainsKey(resource) && resource != string.Empty)
            {
                foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
                {
                    if (type.Name == "DiceAttackEffect_" + resource)
                    {
                        Type value = type;
                        SilentReverb_ModInit.CustomEffects[resource] = value;
                        break;
                    }
                }
            }
            if (SilentReverb_ModInit.CustomEffects.ContainsKey(resource))
            {
                Type componentType = SilentReverb_ModInit.CustomEffects[resource];
                DiceAttackEffect diceAttackEffect = new GameObject(resource).AddComponent(componentType) as DiceAttackEffect;
                diceAttackEffect.Initialize(self, target, 1f);
                diceAttackEffect.SetScale(scaleFactor);
                __result = diceAttackEffect;
                result = false;
            }
            else
            {
                result = true;
            }
        }
        return result;
    }

    // Token: 0x060000CB RID: 203 RVA: 0x00005008 File Offset: 0x00003208
    public static bool DiceEffectManager_CreateBehaviourEffect_Pre(DiceEffectManager __instance, ref DiceAttackEffect __result, string resource, float scaleFactor, BattleUnitView self, BattleUnitView target, float time = 1f)
    {
        bool result;
        if (resource == null)
        {
            __result = null;
            result = false;
        }
        else
        {
            if (!SilentReverb_ModInit.CustomEffects.ContainsKey(resource) && resource != string.Empty)
            {
                foreach (Type type in Assembly.LoadFrom(SilentReverb_ModInit.path + "/SilentReverb.dll").GetTypes())
                {
                    if (type.Name == "DiceAttackEffect_" + resource)
                    {
                        Type value = type;
                        SilentReverb_ModInit.CustomEffects[resource] = value;
                        break;
                    }
                }
            }
            if (SilentReverb_ModInit.CustomEffects.ContainsKey(resource))
            {
                Type componentType = SilentReverb_ModInit.CustomEffects[resource];
                DiceAttackEffect diceAttackEffect = new GameObject(resource).AddComponent(componentType) as DiceAttackEffect;
                diceAttackEffect.Initialize(self, target, 1f);
                diceAttackEffect.SetScale(scaleFactor);
                __result = diceAttackEffect;
                result = false;
            }
            else
            {
                result = true;
            }
        }
        return result;
    }

    // Token: 0x060000CC RID: 204 RVA: 0x000050E4 File Offset: 0x000032E4
    public static void SpeedDiceUI_CheckBlockDice(SpeedDiceUI __instance, BattleUnitView ____view, ref bool __result)
    {
        int orderOfDice = __instance.OrderOfDice;
        if (____view.model.passiveDetail.PassiveList.Exists((PassiveAbilityBase x) => x.id.id == 10 && x.id.packageId == SilentReverb_ModInit.packageId) && ____view.speedDiceSetterUI.SpeedDicesCount > 2 && orderOfDice == 0)
        {
            __result = true;
        }
    }

    // Token: 0x060000CD RID: 205 RVA: 0x00005144 File Offset: 0x00003344
    public static bool BookModel_GetThumbSprite(BookModel __instance, ref Sprite __result)
    {
        bool result;
        if (__instance.BookId.packageId == SilentReverb_ModInit.packageId)
        {
            if (__instance.BookId.id == 10000001)
            {
                __result = SilentReverb_ModInit.ArtWorks["SilenceArgaliaThumb"];
            }
            result = false;
        }
        else
        {
            result = true;
        }
        return result;
    }

    // Token: 0x060000CE RID: 206 RVA: 0x00005194 File Offset: 0x00003394
    public static void AddLocalize()
    {
        typeof(BattleEffectTextsXmlList).GetField("_dictionary", AccessTools.all).GetValue(Singleton<BattleEffectTextsXmlList>.Instance);
        System.IO.FileInfo[] files = new DirectoryInfo(SilentReverb_ModInit.path + "/Localize/" + SilentReverb_ModInit.language + "/BattleDialogues").GetFiles();
        for (int i = 0; i < files.Length; i++)
        {
            using (StringReader stringReader = new StringReader(File.ReadAllText(files[i].FullName)))
            {
                BattleDialogRoot battleDialogRoot = (BattleDialogRoot)new XmlSerializer(typeof(BattleDialogRoot)).Deserialize(stringReader);
                ((Dictionary<string, BattleDialogRoot>)typeof(BattleDialogXmlList).GetField("_dictionary", AccessTools.all).GetValue(Singleton<BattleDialogXmlList>.Instance))[battleDialogRoot.groupName] = battleDialogRoot;
            }
        }
    }

    // Token: 0x060000CF RID: 207 RVA: 0x00005278 File Offset: 0x00003478
    public static bool BattleDialogueModel_6_GetBattleDlg_Pre(DialogType dlgType, ref string __result)
    {
        bool flag = Singleton<StageController>.Instance.GetStageModel().ClassInfo.id == new LorId("SilentReverb", 1) && Singleton<StageController>.Instance.CurrentWave == 1;
        string battleDlg = SilentReverb_ModInit.GetBattleDlg(dlgType, "BlackArgaliaGeburaSay");
        if (flag && battleDlg != string.Empty)
        {
            __result = battleDlg;
            return false;
        }
        return true;
    }

    // Token: 0x060000D0 RID: 208 RVA: 0x000052DC File Offset: 0x000034DC
    public static bool BattleDialogueModel_8_GetBattleDlg_Pre(DialogType dlgType, ref string __result)
    {
        bool flag = Singleton<StageController>.Instance.GetStageModel().ClassInfo.id == new LorId("SilentReverb", 1) && Singleton<StageController>.Instance.CurrentWave == 1;
        string battleDlg = SilentReverb_ModInit.GetBattleDlg(dlgType, "BlackArgaliaBinahSay");
        if (flag && battleDlg != string.Empty)
        {
            __result = battleDlg;
            return false;
        }
        return true;
    }

    // Token: 0x060000D1 RID: 209 RVA: 0x00005340 File Offset: 0x00003540
    public static bool BattleDialogueModel_10_GetBattleDlg_Pre(DialogType dlgType, ref string __result)
    {
        bool flag = Singleton<StageController>.Instance.GetStageModel().ClassInfo.id == new LorId("SilentReverb", 1) && Singleton<StageController>.Instance.CurrentWave == 1;
        string battleDlg = SilentReverb_ModInit.GetBattleDlg(dlgType, "BlackArgaliaRolandSay");
        if (flag && battleDlg != string.Empty)
        {
            __result = battleDlg;
            return false;
        }
        return true;
    }

    // Token: 0x060000D2 RID: 210 RVA: 0x000053A4 File Offset: 0x000035A4
    public static string GetBattleDlg(DialogType dlgType, string character)
    {
        string result = string.Empty;
        string groupID = "SilentReverb";
        Dictionary<DialogType, List<BattleDialog>> dictionary = new Dictionary<DialogType, List<BattleDialog>>();
        BattleDialogCharacter characterData = Singleton<BattleDialogXmlList>.Instance.GetCharacterData(groupID, character);
        if (characterData != null)
        {
            foreach (BattleDialogType battleDialogType in characterData.dialogTypeList)
            {
                dictionary.Add(battleDialogType.dialogType, battleDialogType.dialogList);
            }
        }
        if (dictionary != null && dictionary.ContainsKey(dlgType))
        {
            List<BattleDialog> list = dictionary[dlgType];
            if (list.Count > 0)
            {
                result = list[UnityEngine.Random.Range(0, list.Count)].dialogContent;
            }
        }
        return result;
    }

    // Token: 0x060000D3 RID: 211 RVA: 0x00005464 File Offset: 0x00003664
    public static bool UnitDataModel_InitBattleDialogByDefaultBook(UnitDataModel __instance, LorId lorId)
    {
        bool result;
        if (lorId.packageId == "SilentReverb" && lorId == new LorId("SilentReverb", 1))
        {
            __instance.battleDialogModel = new BattleDialogueModel_BlackArgalia(Singleton<BattleDialogXmlList>.Instance.GetCharacterData("SilentReverb", "BlackArgalia"));
            result = false;
        }
        else
        {
            result = true;
        }
        return result;
    }

    // Token: 0x0400001F RID: 31
    protected static string _path;

    // Token: 0x04000020 RID: 32
    public static string packageId = "SilentReverb";

    // Token: 0x04000021 RID: 33
    public static Dictionary<string, Sprite> ArtWorks;

    // Token: 0x04000022 RID: 34
    private static bool uiinit;

    // Token: 0x04000023 RID: 35
    public static List<Sprite> sprites = new List<Sprite>();

    // Token: 0x04000024 RID: 36
    public static Vector3 vector;

    // Token: 0x04000025 RID: 37
    public static Vector3 vector2;

    // Token: 0x04000026 RID: 38
    public static bool uiinit2;

    // Token: 0x04000027 RID: 39
    public static List<Sprite> sprites2;

    // Token: 0x04000028 RID: 40
    public static List<Sprite> sprites3;

    // Token: 0x04000029 RID: 41
    public static List<Sprite> sprites4;

    // Token: 0x0400002A RID: 42
    private static Vector3 ___colorRange = new Vector3(1f, 0f, 1f);

    // Token: 0x0400002B RID: 43
    public static Dictionary<string, Type> CustomEffects = new Dictionary<string, Type>();

    // Token: 0x0400002C RID: 44
    public static Dictionary<string, Sprite> EffectSprites = new Dictionary<string, Sprite>();

    // Token: 0x0400002D RID: 45
    public static string language;

    // Token: 0x0400002E RID: 46
    public static bool Init;

    // Token: 0x0400002F RID: 47
    public static bool uiinit3;

    // Token: 0x04000030 RID: 48
    public static bool uiinit4;
}
