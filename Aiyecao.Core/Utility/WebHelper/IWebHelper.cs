using System.Web;

namespace Aiyecao.Core
{
    /// <summary>
    /// Represents a common helper
    /// </summary>
    public partial interface IWebHelper
    {
        /// <summary>
        /// 获取URL链接
        /// </summary>
        /// <returns>URL referrer</returns>
        string GetUrlReferrer();

        /// <summary>
        /// 获取访问ip
        /// </summary>
        /// <returns>URL referrer</returns>
        string GetCurrentIpAddress();

        /// <summary>
        /// 获取一个值，指示当前连接是否安全
        /// </summary>
        /// <returns>true - secured, false - not secured</returns>
        bool IsCurrentConnectionSecured();
        
        /// <summary>
        /// 获取服务器变量的名称
        /// </summary>
        /// <param name="name">Name</param>
        /// <returns>Server variable</returns>
        string ServerVariables(string name);

        /// <summary>
        /// 判断资源是否是可访问的
        /// </summary>
        /// <param name="request">HTTP Request</param>
        /// <returns>True if the request targets a static resource file.</returns>
        /// <remarks>
        /// These are the file extensions considered to be static resources:
        /// .css
        ///	.gif
        /// .png 
        /// .jpg
        /// .jpeg
        /// .js
        /// .axd
        /// .ashx
        /// </remarks>
        bool IsStaticResource(HttpRequest request);
        
        /// <summary>
        /// 将虚拟路径映射到物理磁盘路径
        /// </summary>
        /// <param name="path">The path to map. E.g. "~/bin"</param>
        /// <returns>The physical path. E.g. "c:\inetpub\wwwroot\bin"</returns>
        string MapPath(string path);


        /// <summary>
        /// 查询字符串
        /// </summary>
        /// <param name="url">Url to modify</param>
        /// <param name="queryStringModification">Query string modification</param>
        /// <param name="anchor">Anchor</param>
        /// <returns>New url</returns>
        string ModifyQueryString(string url, string queryStringModification, string anchor);

        /// <summary>
        /// 从网址删除查询字符串
        /// </summary>
        /// <param name="url">Url to modify</param>
        /// <param name="queryString">Query string to remove</param>
        /// <returns>New url</returns>
        string RemoveQueryString(string url, string queryString);
        
        /// <summary>
        /// 获取查询字符串值的名称
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">Parameter name</param>
        /// <returns>Query string value</returns>
        T QueryString<T>(string name);

        /// <summary>
        /// 重新启动应用程序域
        /// </summary>
        /// <param name="makeRedirect">一个值，该值指示是否在重新启动后重新进行重定向</param>
        /// <param name="redirectUrl">重定向到当前网页的网址</param>
        void RestartAppDomain(bool makeRedirect = false, string redirectUrl = "");
        
        /// <summary>
        /// 获取一个值，该值指示是否将用户重定向到新的位置
        /// </summary>
        bool IsRequestBeingRedirected { get; }

        /// <summary>
        /// 获取或设置一个值，该值指示是否将用户重定向到一个新的位置使用后
        /// </summary>
        bool IsPostBeingDone { get; set; }
    }
}
