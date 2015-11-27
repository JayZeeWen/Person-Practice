using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Data;

namespace test
{
    public class Tree
    {
        private DataTable Dt;
        private StringBuilder Str = new StringBuilder();
        private Function<DataRow, string> func;

        public Tree(DataTable dt, Function<DataRow, string> func)
        {
            this.Dt = dt;
            this.func = func;
        }
        public string Create(string Parent,string layer)
        {
            LoopCreateHtml(Parent,layer);
            return this.Str.ToString();
        }
        private void LoopCreateHtml(string Parent,string layer)
        {
            var drs = this.Dt.Select("layer='" + layer + "'" + " and p_id  ='" + Parent + "'");
            if (drs.Length > 0)
            {
                Str.Append("<ul>");
                foreach (DataRow dr in drs)
                {
                    Str.Append("<li>");
                    Str.Append(func(dr));
                    LoopCreateHtml(dr["ID"].ToString(),dr["layer"].ToString());
                    Str.Append("</li>");
                }
                Str.Append("</ul>");
            }
        }
    }

    public delegate T Function<T1, T>(T1 value);
    public delegate T Function<T1, T2, T>(T1 value, T2 value2);
    public delegate T Function<T1, T2, T3, T>(T1 value, T2 value2, T3 value3);
    public delegate T Function<T1, T2, T3, T4, T>(T1 value, T2 value2, T3 value3, T4 value4);
}


