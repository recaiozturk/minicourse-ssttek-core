using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using MiniCourse.Repository.Users;
using MiniCourse.WebUI.Roles;
using System.Text;

namespace MiniCourse.WebUI.TagHelpers
{
    public class UserRoleNamesTagHelper(IRoleService roleService) : TagHelper
    {
        public string UserId { get; set; } = null!;


        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {

            var userRoles = await roleService.GetRolesByUserAsync(UserId);

            var stringBuilder = new StringBuilder();

            userRoles.Data.ToList().ForEach(x =>
            {
                stringBuilder.Append(@$"<span class='badge bg-secondary mx-1'>{x.Name.ToLower()}</span>");
            });

            output.Content.SetHtmlContent(stringBuilder.ToString());

        }
    }
}
