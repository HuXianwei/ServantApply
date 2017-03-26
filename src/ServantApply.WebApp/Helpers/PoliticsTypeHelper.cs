using Microsoft.AspNetCore.Mvc.Rendering;
using ServantApply.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServantApply.WebApp.Helpers
{
    public class PoliticsTypeHelper
    {

        /// <summary>
        /// 获取政治面貌下拉
        /// </summary>
        public static List<SelectListItem> GetItems(int type=0,bool showNull=false)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            if (showNull)
            {
                list.Add(new SelectListItem { Text = "请选择", Value = "0" });
            }
            foreach (PoliticsType item in Enum.GetValues(typeof(PoliticsType)))
            {
                list.Add(new SelectListItem { Text=item.getDescription(),Value=item.getValue().ToString(),Selected=type==item.getValue()?true:false});
            }
            return list;
        }

    }
}
