using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.ComponentModel.Design;

using System.Web;
using System.Web.UI;
using System.Web.UI.Design;
using System.Web.UI.WebControls;

namespace MSS
{
    class AutoSuggestMenuDesigner : ControlDesigner
    {
        public override String GetDesignTimeHtml()
        {
            AutoSuggestMenu menu = (AutoSuggestMenu)this.Component;
            menu.CssClass = null;
            
            HtmlTextWriter writer = new HtmlTextWriter(new StringWriter());
            menu.RenderBeginTag(writer);

            writer.WriteLine("[ AutoSuggestMenu ]");

            menu.RenderEndTag(writer);

            return writer.InnerWriter.ToString();
        }
    }
}
