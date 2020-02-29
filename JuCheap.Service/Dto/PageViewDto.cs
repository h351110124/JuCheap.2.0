namespace JuCheap.Service.Dto
{
    /// <summary>
    /// 浏览记录DTO
    /// </summary>
    public class PageViewDto : BaseDto
    {
        /// <summary>
        /// UserId
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// UserName
        /// </summary>
        public string User { get; set; }
        /// <summary>
        /// Url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 访问者IP
        /// </summary>
        public string IP { get; set; }
    }
}
