using DevExpress.XtraNavBar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBTZLibrary.MainForm
{
    public class CNavBarLocalizer : NavBarLocalizer
    {
        public override string GetLocalizedString(NavBarStringId id)
        {
            try
            {
                switch (id)
                {
                    case NavBarStringId.NavPaneChevronHint:
                        return "Цэс тохируулах";

                    case NavBarStringId.NavPaneMenuAddRemoveButtons:
                        return "Үндсэн цэсийг нэмэх, хасах";

                    case NavBarStringId.NavPaneMenuShowFewerButtons:
                        return "Үндсэн цэсний тоог хасах";

                    case NavBarStringId.NavPaneMenuShowMoreButtons:
                        return "Үндсэн цэсний тоог нэмэх";
                }
            }
            catch { }
            return id.ToString();
        }
    }
}
