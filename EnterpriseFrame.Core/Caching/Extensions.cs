using System;

namespace EnterpriseFrame.Core.Caching
{
    /// <summary>
    /// Extensions
    /// </summary>
    public static class CacheExtensions
    {
        /// <summary>
        /// ��ȡ���棬��������acquire�Ľ�����뻺�棬Ĭ��ʱ��60����
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="cacheManager">Cache manager</param>
        /// <param name="key">Cache key</param>
        /// <param name="acquire">Function to load item if it's not in the cache yet</param>
        /// <returns>Cached item</returns>
        public static T Get<T>(this ICacheManager cacheManager, string key, Func<T> acquire)
        {
            return Get(cacheManager, key, 60, acquire);
        }

        /// <summary>
        /// ��ȡ����,��������ڻ����У�ִ�н��Ȼ������غͻ���
        /// </summary>
        /// <typeparam name="T">��������</typeparam>
        /// <param name="cacheManager">Cache manager</param>
        /// <param name="key">Cache key</param>
        /// <param name="cacheTime">����ʱ�� ��0����-��Ҫ����</param>
        /// <param name="acquire">û�л�����ִ�д˱��ʽ���û���</param>
        /// <returns>Cached item</returns>
        public static T Get<T>(this ICacheManager cacheManager, string key, int cacheTime, Func<T> acquire) 
        {
            if (cacheManager.IsSet(key))
            {
                return cacheManager.Get<T>(key);
            }
            else
            {
                var result = acquire();
                if (cacheTime > 0)
                    cacheManager.Set(key, result, cacheTime);
                return result;
            }
        }
    }
}
