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
        /// <summary>
        /// 获取学历下拉
        /// </summary>
        /// <param name="type"></param>
        /// <param name="showNull"></param>
        /// <returns></returns>
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

        //public void test()
        //{
        //    GetItems(showNull: true);
        //}

        public static string GetEducation(int education)
        {
            switch (education)
            {
                case 1:return "中专";
                case 2:return "大专";
                case 3:return "本科";
                case 4:return "硕士";
                case 5:return "博士";
                default:return "";
            }
        }
    }
}
