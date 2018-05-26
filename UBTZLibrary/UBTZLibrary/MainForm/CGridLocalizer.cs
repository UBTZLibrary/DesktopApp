using DevExpress.XtraGrid.Localization;
using DevExpress.XtraPivotGrid.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBTZLibrary.MainForm
{
    public class CGridLocalizer : GridLocalizer
    {
        public override string GetLocalizedString(GridStringId id)
        {
            try
            {
                switch (id)
                {
                    case GridStringId.GridNewRowText:
                        return "Шинээр нэмэх";

                    case GridStringId.FilterPanelCustomizeButton:
                        return "Жагсаалтыг шүүх";

                    case GridStringId.PopupFilterAll:
                        return "Бүгд";

                    case GridStringId.PopupFilterCustom:
                        return "Нөхцөл";

                    case GridStringId.PopupFilterBlanks:
                        return "Хоосон";

                    case GridStringId.PopupFilterNonBlanks:
                        return "Хоосон биш";

                    case GridStringId.CustomFilterDialogFormCaption:
                        return "Шүүлт";

                    case GridStringId.CustomFilterDialogCaption:
                        return "Хэрэглэгчийн шүүлт";

                    case GridStringId.CustomFilterDialogRadioAnd:
                        return "&And";

                    case GridStringId.CustomFilterDialogRadioOr:
                        return "&Or";

                    case GridStringId.CustomFilterDialogOkButton:
                        return "&Ok";

                    case GridStringId.CustomFilterDialogCancelButton:
                        return "&Cancel";

                    case GridStringId.MenuColumnAutoFilterRowHide:
                        return "Шүүлт нуух";

                    case GridStringId.MenuColumnAutoFilterRowShow:
                        return "Шүүлт харуулах";

                    case GridStringId.MenuColumnFindFilterHide:
                        return "Бүх баганын шүүлт нуух";

                    case GridStringId.MenuColumnFindFilterShow:
                        return "Бүх баганын шүүлт харуулах";

                    case GridStringId.FindControlFindButton:
                        return "Хайх";

                    case GridStringId.FindControlClearButton:
                        return "Цэвэрлэх";

                    case GridStringId.FindNullPrompt:
                        return "";

                    case GridStringId.MenuColumnBandCustomization:
                        return "Багана тохируулах";

                    case GridStringId.MenuFooterSum:
                        return "Sum";

                    case GridStringId.MenuFooterMin:
                        return "Min";

                    case GridStringId.MenuFooterMax:
                        return "Max";

                    case GridStringId.MenuFooterCount:
                        return "Count";

                    case GridStringId.MenuFooterAverage:
                        return "Average";

                    case GridStringId.MenuFooterNone:
                        return "None";

                    case GridStringId.MenuFooterSumFormat:
                        return "{0:#,##0.00}";

                    case GridStringId.MenuFooterMinFormat:
                        return "{0}";

                    case GridStringId.MenuFooterMaxFormat:
                        return "{0}";

                    case GridStringId.MenuFooterCountFormat:
                        return "{0}";

                    case GridStringId.MenuFooterAverageFormat:
                        return "{0:#,##0.00}";

                    case GridStringId.MenuColumnSortAscending:
                        return "Буурахаар эрэмбэ";

                    case GridStringId.MenuColumnSortDescending:
                        return "Өсөхөөр эрэмбэ";

                    case GridStringId.MenuColumnRemoveColumn:
                        return "Багана нуух";

                    case GridStringId.MenuColumnShowColumn:
                        return "Багана харуулах";

                    case GridStringId.MenuColumnGroup:
                        return "Бүлэглэх";

                    case GridStringId.MenuColumnUnGroup:
                        return "Бүлэглэлтийг болих";

                    case GridStringId.MenuColumnColumnCustomization:
                        return "Багана тохируулах";

                    case GridStringId.MenuColumnBestFit:
                        return "Тохиромжтой өргөн";

                    case GridStringId.MenuColumnClearFilter:
                        return "Шүүлтийг болих";

                    case GridStringId.MenuColumnBestFitAllColumns:
                        return "Бүх баганы тохиромжтой өргөн";

                    case GridStringId.MenuGroupPanelShow:
                        return "Бүлэглэлтийг харах";

                    case GridStringId.MenuGroupPanelHide:
                        return "Бүлэглэлтийг нуух";

                    case GridStringId.MenuGroupPanelFullExpand:
                        return "Задлах";

                    case GridStringId.MenuGroupPanelFullCollapse:
                        return "Хураах";

                    case GridStringId.MenuGroupPanelClearGrouping:
                        return "Бүлэглэлтийг болих";

                    case GridStringId.MenuColumnGroupBox:
                        return "Бүлэглэх талбар";

                    case GridStringId.GridGroupPanelText:
                        return "Энд бүлэглэх баганаа чирч тавина";

                    case GridStringId.MenuColumnClearSorting:
                        return "Эрэмбийг болих";

                    case GridStringId.MenuColumnClearAllSorting:
                        return "Бүх эрэмбийг болих";

                    case GridStringId.MenuColumnFilterEditor:
                        return "Шүүлт хийх цонх";

                    case GridStringId.FilterBuilderOkButton:
                        return "Ok";

                    case GridStringId.FilterBuilderCancelButton:
                        return "Болих";

                    case GridStringId.FilterBuilderApplyButton:
                        return "Сонгох";

                    case GridStringId.FilterBuilderCaption:
                        return "Жагсаалтын шүүх";

                    case GridStringId.CustomizationBands:
                        return "Нуусан бүлгүүд";

                    case GridStringId.CustomizationColumns:
                        return "Нуусан баганууд";

                    case GridStringId.CustomizationFormBandHint:
                        return "Баганын бүлгүүдийг энд оруулна.";

                    case GridStringId.CustomizationFormColumnHint:
                        return "Багануудыг энд оруулна.";

                    case GridStringId.CustomizationCaption:
                        return "Багана тохируулах.";

                    case GridStringId.MenuFooterCountGroupFormat:
                        return "Нийт {0:D}";

                    case GridStringId.MenuColumnResetGroupSummarySort:
                        return "Бүлэглэлтийн эрэмбийг болих";

                    case GridStringId.MenuColumnSortGroupBySummaryMenu:
                        return "Бүлэглэлтийн эрэмбэ";
                }
            }
            catch { }
            return id.ToString();
        }

    }
}
