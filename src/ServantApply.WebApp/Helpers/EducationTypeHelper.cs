using Microsoft.AspNetCore.Mvc.Rendering;
using ServantApply.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServantApply.WebApp.Helpers
{
    public class EducationTypeHelper
    {
        public static List<SelectListItem> GetItems(int type = 0, bool showNull = false)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            if (showNull)
                list.Add(new SelectListItem { Text = "请选择", Value = "0"});
            foreach (EducationType item in Enum.GetValues(typeof(EducationType)))
            {
                list.Add(new SelectListItem { Text = item.GetDescription(), Value = item.GetValue().ToString(), Selected = type == item.GetValue() ? true : false });
            }
            return list;
        }
    }
}
