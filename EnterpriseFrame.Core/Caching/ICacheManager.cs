namespace EnterpriseFrame.Core.Caching
{
    /// <summary>
    /// ����ӿ�
    /// </summary>
    public interface ICacheManager
    {
        /// <summary>
        /// ��ȡ��������ָ����������ֵ
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The value associated with the specified key.</returns>
        T Get<T>(string key);

        /// <summary>
        /// ��ָ���ļ��Ͷ�����ӵ�������.
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="data">Data</param>
        /// <param name="cacheTime">Cache time</param>
        void Set(string key, object data, int cacheTime);

        /// <summary>
        /// ��ȡһ��ֵ����ֵָʾ������ָ����������ֵ
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>Result</returns>
        bool IsSet(string key);

        /// <summary>
        /// �ӻ������Ƴ�����ָ������ֵ
        /// </summary>
        /// <param name="key">/key</param>
        void Remove(string key);

        /// <summary>
        /// �ӻ������Ƴ�ƥ�������ֵ
        /// </summary>
        /// <param name="pattern">pattern</param>
        void RemoveByPattern(string pattern);

        /// <summary>
        /// ������л�������
        /// </summary>
        void Clear();
    }
}
