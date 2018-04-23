using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using MVCxGridViewDataBinding.Models;
using System.Web.UI;
using DevExpress.Web.ASPxGridView;
using System.Web.UI.HtmlControls;

namespace Q512251.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        List<MyModel> list;
        private List<MyModel> List
        {
            get
            {
                if (list == null)
                {
                    if (Session["list"] == null)
                        Session["list"] = list = MyModel.GetModelList();
                    else
                        list = Session["list"] as List<MyModel>;
                }
                return list;
            }
        }
        public ActionResult EditingUpdate(MyModel model)
        {

            if (ModelState.IsValid)
                MyModel.UpdateModel(List, model);
            return PartialView("_GridViewPartial", List);
        }
        public ActionResult EditingAddNew(MyModel model)
        {
            if (ModelState.IsValid)
                MyModel.InsertModel(List, model);
            return PartialView("_GridViewPartial", List);
        }

        public ActionResult EditingDelete(int modelID)
        {

            if (ModelState.IsValid)
                MyModel.DeleteModel(List, modelID);
            return PartialView("_GridViewPartial", List);
        }
     
        [ValidateInput(false)]
        public ActionResult GridViewPartial()
        {

            return PartialView("_GridViewPartial", List);
        }
    }
   
}
