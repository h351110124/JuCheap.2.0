namespace JuCheap.Service.Dto
{
    /// <summary>
    /// 用户角色关系DTO
    /// </summary>
    public class UserRoleDto : BaseDto
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        public string RoleId { get; set; }
    }
}
