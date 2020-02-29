namespace JuCheap.Service.Dto
{
    /// <summary>
    /// 角色菜单关系DTO
    /// </summary>
    public class RoleMenuDto : BaseDto
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        public string RoleId { get; set; }

        /// <summary>
        /// 菜单ID
        /// </summary>
        public string MenuId { get; set; }
    }
}
