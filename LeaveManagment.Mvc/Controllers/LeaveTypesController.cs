using LeaveManagment.Mvc.Contratcs;
using LeaveManagment.Mvc.Models.LeaveTypes;
using LeaveManagment.Mvc.Services.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagment.Mvc.Controllers
{
    [Authorize]
    public class LeaveTypesController : Controller
    {
        private readonly ILeaveTypeService _leaveTypeService;

        public LeaveTypesController(ILeaveTypeService leaveTypeService)
        {
            _leaveTypeService = leaveTypeService;
        }
        // GET: LeaveTypesController
        public async Task<ActionResult> Index()
        {
            var leaveTypes = await _leaveTypeService.GetLeaveTypes();

            return View(leaveTypes);
        }

        // GET: LeaveTypesController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var leaveTypes = await _leaveTypeService.GetLeaveTypeDetails(id);
            return View(leaveTypes);
        }

        // GET: LeaveTypesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateLeaveTypeVM createLeaveTypeVM)
        {
            try
            {
                var response = await _leaveTypeService.CreateLeaveType(createLeaveTypeVM);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                else{
                    ModelState.AddModelError("", response.ValidationErrors);
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

            }          
            return View(createLeaveTypeVM);

        }

        // GET: LeaveTypesController/Edit/5
        public async Task< ActionResult> Edit(int id)
        {
            var result= await _leaveTypeService.GetLeaveTypeDetails(id);
            var updateLeaveType = new UpdateLeaveTypeVM {Id=result.Id,DefaultDay=result.DefaultDay,Name=result.Name };
            return View(updateLeaveType);
        }

        // POST: LeaveTypesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, UpdateLeaveTypeVM updateLeaveTypeVM)
        {
            try
            {
                var response = await _leaveTypeService.UpdateLeaveType(id, updateLeaveTypeVM);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", response.ValidationErrors);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

            }
            return View(updateLeaveTypeVM);
        }

        // GET: LeaveTypesController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var leaveTypes = await _leaveTypeService.GetLeaveTypeDetails(id);
            return View(leaveTypes);
        }

        // POST: LeaveTypesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, LeaveTypeVM leaveTypeVM)
        {
            try
            {
                var response = await _leaveTypeService.DeleteLeaveType(id);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", response.ValidationErrors);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

            }
            return View(leaveTypeVM);
        }
    }
}
