using DevExpress.XtraPivotGrid.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBTZLibrary.MainForm
{

    public class CPivotGridLocalizer : PivotGridLocalizer
    {
        public override string GetLocalizedString(PivotGridStringId id)
        {
           
            switch (id)
            {

                case PivotGridStringId.RowHeadersCustomization:
                    return "Мөрийн талбарууд";

                case PivotGridStringId.ColumnHeadersCustomization:
                    return "Баганын талбарууд";

                case PivotGridStringId.FilterHeadersCustomization:
                    return "Шүүлтүүрийн талбарууд";

                case PivotGridStringId.DataHeadersCustomization:
                    return "Өгөгдлийн талбарууд";

                case PivotGridStringId.PopupMenuHidePrefilter:
                    return "Талбарыг өөрчлөлтөө нэмэх эсвэл хасах боломжтой.";

                case PivotGridStringId.CustomizationFormAddTo:
                    return "Талбар руу нэмэх ";

                case PivotGridStringId.GrandTotal:
                    return "Нийт дүн";

                case PivotGridStringId.Total:
                    return "Бүгд дүн";

                case PivotGridStringId.TotalFormat:
                    return "Нийт дүн формат";

                case PivotGridStringId.PrefilterFormCaption:
                    return "Шүүлт хийх цонх";

                case PivotGridStringId.RowArea:
                    return "Мөр талбар";

                case PivotGridStringId.ColumnArea:
                    return "Багана талбар";

                case PivotGridStringId.DataArea:
                    return "Өгөгдлийн талбар";

                case PivotGridStringId.FilterArea:
                    return "Шүүлтүүрийн талбар";

                case PivotGridStringId.TotalFormatAverage:
                    return "Дундаж нийт дүн";

                case PivotGridStringId.CustomizationFormCaption:
                    return "Багануудыг тохируулах";
                case PivotGridStringId.CustomizationFormText:
                    return "";

                case PivotGridStringId.PopupMenuSortFieldByColumn:
                    return "Баганаар эрэмбэлэх";
                case PivotGridStringId.PopupMenuRemoveAllSortByColumn:
                    return "Бүх баганын эрэмбыг болих";

                case PivotGridStringId.PopupMenuShowFieldList:
                    return "Баганы жагсаалт";

                case PivotGridStringId.PopupMenuFieldOrder:
                    return "Талбарын эрэмбэ";

                case PivotGridStringId.PopupMenuRefreshData:
                    return "Мэдээлэл шинэчлэх";

                case PivotGridStringId.PopupMenuShowPrefilter:
                    return "Шүүлт хийх цонх";

                case PivotGridStringId.FilterShowAll:
                    return "Бүгдийг харах";

                case PivotGridStringId.FilterShowBlanks:
                    return "Хоосон утгуудыг харах";

                case PivotGridStringId.FilterOk:
                    return "Шүүх";

                case PivotGridStringId.FilterCancel:
                    return "Болих";

                case PivotGridStringId.PopupMenuHideField:
                    return "Талбар нуух";

                case PivotGridStringId.PopupMenuMovetoBeginning:
                    return "Эхлэл рүү зөөх";

                case PivotGridStringId.PopupMenuMovetoEnd:
                    return "Төгсгөл рүү зөөх";

                case PivotGridStringId.PopupMenuMovetoLeft:
                    return "Зүүн тал руу зөөх";

                case PivotGridStringId.PopupMenuMovetoRight:
                    return "Баруун тал руу зөөх";
            }
            return id.ToString();
        }
    }
}
