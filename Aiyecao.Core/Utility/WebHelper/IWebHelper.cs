using System.Web;

namespace Aiyecao.Core
{
    /// <summary>
    /// Represents a common helper
    /// </summary>
    public partial interface IWebHelper
    {
        /// <summary>
        /// ��ȡURL����
        /// </summary>
        /// <returns>URL referrer</returns>
        string GetUrlReferrer();

        /// <summary>
        /// ��ȡ����ip
        /// </summary>
        /// <returns>URL referrer</returns>
        string GetCurrentIpAddress();

        /// <summary>
        /// ��ȡһ��ֵ��ָʾ��ǰ�����Ƿ�ȫ
        /// </summary>
        /// <returns>true - secured, false - not secured</returns>
        bool IsCurrentConnectionSecured();
        
        /// <summary>
        /// ��ȡ����������������
        /// </summary>
        /// <param name="name">Name</param>
        /// <returns>Server variable</returns>
        string ServerVariables(string name);

        /// <summary>
        /// �ж���Դ�Ƿ��ǿɷ��ʵ�
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
        /// ������·��ӳ�䵽�������·��
        /// </summary>
        /// <param name="path">The path to map. E.g. "~/bin"</param>
        /// <returns>The physical path. E.g. "c:\inetpub\wwwroot\bin"</returns>
        string MapPath(string path);


        /// <summary>
        /// ��ѯ�ַ���
        /// </summary>
        /// <param name="url">Url to modify</param>
        /// <param name="queryStringModification">Query string modification</param>
        /// <param name="anchor">Anchor</param>
        /// <returns>New url</returns>
        string ModifyQueryString(string url, string queryStringModification, string anchor);

        /// <summary>
        /// ����ַɾ����ѯ�ַ���
        /// </summary>
        /// <param name="url">Url to modify</param>
        /// <param name="queryString">Query string to remove</param>
        /// <returns>New url</returns>
        string RemoveQueryString(string url, string queryString);
        
        /// <summary>
        /// ��ȡ��ѯ�ַ���ֵ������
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">Parameter name</param>
        /// <returns>Query string value</returns>
        T QueryString<T>(string name);

        /// <summary>
        /// ��������Ӧ�ó�����
        /// </summary>
        /// <param name="makeRedirect">һ��ֵ����ֵָʾ�Ƿ����������������½����ض���</param>
        /// <param name="redirectUrl">�ض��򵽵�ǰ��ҳ����ַ</param>
        void RestartAppDomain(bool makeRedirect = false, string redirectUrl = "");
        
        /// <summary>
        /// ��ȡһ��ֵ����ֵָʾ�Ƿ��û��ض����µ�λ��
        /// </summary>
        bool IsRequestBeingRedirected { get; }

        /// <summary>
        /// ��ȡ������һ��ֵ����ֵָʾ�Ƿ��û��ض���һ���µ�λ��ʹ�ú�
        /// </summary>
        bool IsPostBeingDone { get; set; }
    }
}
