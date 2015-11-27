using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace test
{
    public partial class TreeTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 定义数据库连接
            SqlConnection CN = new SqlConnection();
            try
            {
                //初始化连接字符串
                CN.ConnectionString =
                "data source=.;initial catalog=ty_School;user id=sa;Password=123;";
                CN.Open();

                SqlDataAdapter adp = new SqlDataAdapter(@"select C_ID id ,'0' p_id ,1 layer,c_province_name name from t_province 
                                                         union all 
                                                        select C_ID id,c_province_id p_id,2 layer, c_city_name name from t_city
                                                        order by layer asc  ", CN);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                this.ViewState["ds"] = ds;
            }
            catch (Exception)
            {
                //̀跳转程序的公共错误处理页面
            }
            finally
            {
                CN.Close();
            }
            //topevery Tree
             DataSet ds2 = (DataSet)this.ViewState["ds"];
             AddTopeveryTree(ds2.Tables[0]);
           
            //调用递归函数，完成树形结构的生成
            //AddTree(0, (TreeNode)null);
        }

        //递归添加树的节点
        public void AddTree(int ParentID, TreeNode pNode)
        {
            DataSet ds = (DataSet)this.ViewState["ds"];
            DataView dvTree = new DataView(ds.Tables[0]);
            //过滤ParentID,得到当前的所有子节点
            dvTree.RowFilter = "[c_parent_id] = " + ParentID;

            foreach (DataRowView Row in dvTree)
            {
                TreeNode Node = new TreeNode();
                if (pNode == null)
                {    //添加根节点
                    Node.Text = Row["c_province_name"].ToString();
                    TreeView1.Nodes.Add(Node);
                    Node.Expanded = true;
                    AddTree(Int32.Parse(Row["c_id"].ToString()), Node);    //再次递归
                }
                else
                {   //̀添加当前节点的子节点
                    Node.Text = Row["c_province_name"].ToString();
                    pNode.ChildNodes.Add(Node);
                    Node.Expanded = true;
                    AddTree(Int32.Parse(Row["c_id"].ToString()), Node);     //再次递归
                }
            }
        }

        public void AddTopeveryTree(DataTable dt)
        {
            this.tree1.InnerHtml = new Tree(dt, this.BindTree).Create("0","1");
        }

        public string BindTree(DataRow dr)
        {
            return string.Format("<span class='folder'><a ids=\"{0}\" pid=\"{1}\" layer=\"{2}\" names=\"{3}\">{3}</a></span>", dr["id"], dr["p_id"], dr["layer"], dr["name"]);
        }
    }
}