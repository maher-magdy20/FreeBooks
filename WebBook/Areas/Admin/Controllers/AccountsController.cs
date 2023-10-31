using infarstuructre.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebBook.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountsController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountsController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult Roles()
        {
            var model = new RolesViewModel
            {
                NewRole = new NewRole(),
                Roles = _roleManager.Roles.OrderBy(x => x.Name).ToList()
            };
            if (model!=null)
            {
                return View(model);
            }
            return View(null);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Roles(RolesViewModel model)
        {
            var role = new IdentityRole
            {
                Id = model.NewRole.Id,
                Name = model.NewRole.RoleName
            };
            if (!ModelState.IsValid) { 


                if (role.Id == null)
                {
                    role.Id = Guid.NewGuid().ToString();
                    var result = await _roleManager.CreateAsync(role);
                    if (result.Succeeded)
                    {
                        //var lst = new RolesViewModel
                        //{
                        //    NewRole = new NewRole(),
                        //    Roles = _roleManager.Roles.OrderBy(x => x.Name).ToList()
                        //};

                        HttpContext.Session.SetString("MsgType", "Success");
                        HttpContext.Session.SetString("titel", "تم الحفظ");
                        HttpContext.Session.SetString("msg", "تم حفظ مجموعة المستخدم بنجاح");


                        return RedirectToAction("Roles");
                    }
                    else
                    {
                        HttpContext.Session.SetString("MsgType", "error");
                        HttpContext.Session.SetString("titel", " لم يتم الحفظ");
                        HttpContext.Session.SetString("Msg", "لم يتم حفظ مجموعة المستخدم ");
                        return View(model);

                    }
                }
            }
            else
            {
                var RoleUpdate = await _roleManager.FindByIdAsync(model.NewRole.Id);
                RoleUpdate.Id = model.NewRole.Id;
                RoleUpdate.Name = model.NewRole.RoleName;
                var Result = await _roleManager.UpdateAsync(RoleUpdate);
                return RedirectToAction("Roles");

            }
            return View();
        }

        public async Task< IActionResult> DeleteRole(string id)
        {
            var role = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
           if(( await _roleManager.DeleteAsync(role)).Succeeded)
            {
                return RedirectToAction(nameof(Roles));
            }

            return RedirectToAction(nameof(Roles));
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
