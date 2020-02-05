using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Freelancer.Conrollers {
    public class SkillController : ControllerBase {
        public ActionResult<string> Get() {
            return "value";
        }
    }
}
