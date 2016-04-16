using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aiyecao.Core.Logging
{
    public interface ILogger
    {
        /// <summary>
        /// 记录调试信息
        /// </summary>
        /// <param name="log"></param>
        void WriteDebug(string log);
        /// <summary>
        /// 记录系统信息
        /// </summary>
        /// <param name="log"></param>
        void WriteInfo(string log);
        /// <summary>
        /// 记录警告信息
        /// </summary>
        /// <param name="log"></param>
        void WriteWarning(string log);
        /// <summary>
        /// 记录错误信息
        /// </summary>
        /// <param name="log"></param>
        void WriteError(string log);
        /// <summary>
        /// 记录致命信息
        /// </summary>
        /// <param name="log"></param>
        void WriteFatal(string log);
        /// <summary>
        /// 记录警告异常
        /// </summary>
        /// <param name="ex"></param>
        void WriteWarning(Exception ex);
        /// <summary>
        /// 记录系统异常
        /// </summary>
        /// <param name="ex"></param>
        void WriteError(Exception ex);
        /// <summary>
        /// 记录致命日志
        /// </summary>
        /// <param name="ex"></param>
        void WriteFatal(Exception ex);
        /// <summary>
        /// 记录致命日志并进行通知
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="isNotice"></param>
        void WriteFatal(Exception ex, bool isNotice);
    }
}
