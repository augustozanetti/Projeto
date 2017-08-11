using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AZ.Projeto.Infra.CrossCutting.MvcFilters
{
    public class GlobalActionLogger : ActionFilterAttribute
    {

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //TRABALHAR DE FORMA ASYNC
            //LOG DE AUDITORIA 
            //TAL USUARIO FEZ TAL COISA IP TAL ETC..

            if(filterContext.Exception != null)
            {
                //MANIPULAR EX
                //INJETAR LIB DE TRATAMENTO DE ERRO
                // -> GRAVAR BD
                // EMAIL ADMIN

                //LOG4NET
                //ELMAH.IO
                //CUSTOM LOGGER

                //TRABALHAR DE FORMA ASYNC

                filterContext.ExceptionHandled = true;
                filterContext.Result = new HttpStatusCodeResult(500);

            }

            base.OnActionExecuted(filterContext);
        }
    }
}
