namespace EnterpriseFrame.Core.Caching
{
    /// <summary>
    /// 缓存接口
    /// </summary>
    public interface ICacheManager
    {
        /// <summary>
        /// 获取或设置与指定键关联的值
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The value associated with the specified key.</returns>
        T Get<T>(string key);

        /// <summary>
        /// 将指定的键和对象添加到缓存中.
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="data">Data</param>
        /// <param name="cacheTime">Cache time</param>
        void Set(string key, object data, int cacheTime);

        /// <summary>
        /// 获取一个值，该值指示缓存与指定键关联的值
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>Result</returns>
        bool IsSet(string key);

        /// <summary>
        /// 从缓存中移除具有指定键的值
        /// </summary>
        /// <param name="key">/key</param>
        void Remove(string key);

        /// <summary>
        /// 从缓存中移除匹配正则的值
        /// </summary>
        /// <param name="pattern">pattern</param>
        void RemoveByPattern(string pattern);

        /// <summary>
        /// 清除所有缓存数据
        /// </summary>
        void Clear();
    }
}
