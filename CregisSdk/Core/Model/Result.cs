namespace Cregis.Core.Model
{
    /// <summary>
    /// 统一返回结构
    /// author scottcheng
    /// version 1.0.0
    /// date 2023/11/17
    /// </summary>
    public class Result<T>
    {
        public string code{ get; set; }
        public string msg{ get; set; }
        public T data{ get; set; }
    }
}
