using AjaxControlToolkit.HTMLEditor;
namespace MyControls
{
    public class CustomEditor : Editor
    {
        protected override void FillTopToolbar()
        {
            TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.Undo());
            TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.Redo());
            TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.HorizontalSeparator());
            TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.Bold());
            TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.Italic());
            TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.Underline());
            TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.StrikeThrough());
            TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.SubScript());
            TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.SuperScript());
            TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.HorizontalSeparator());
            TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.Ltr());
            TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.Rtl());
            TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.HorizontalSeparator());
            TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.RemoveStyles());
            TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.HorizontalSeparator());
            AjaxControlToolkit.HTMLEditor.ToolbarButton.FontName MyFontName = new AjaxControlToolkit.HTMLEditor.ToolbarButton.FontName();
   
            TopToolbar.Buttons.Add(MyFontName);
            string strFontText = string.Empty;
            string strFontValue = string.Empty;
            for (int i = 0; i < 8; i++)
            {
                switch (i)
                {
                    case 0:
                        strFontText = "Arial";
                        strFontValue = "arial,helvetica,sans-serif";
                        break;
                    case 1:
                        strFontText = "Courier New";
                        strFontValue = "courier new,courier,monospace";
                        break;
                    case 2:
                        strFontText = "Georgia";
                        strFontValue = "georgia,times new roman,times,serif";
                        break;
                    case 3:
                        strFontText = "Tahoma";
                        strFontValue = "tahoma,arial,helvetica,sans-serif";
                        break;
                    case 4:
                        strFontText = "Times New Roman";
                        strFontValue = "times new roman,times,serif";
                        break;
                    case 5:
                        strFontText = "Verdana";
                        strFontValue = "verdana,arial,helvetica,sans-serif";
                        break;
                    case 6:
                        strFontText = "Impact";
                        strFontValue = "impact";
                        break;
                    case 7:
                        strFontText = "WingDings";
                        strFontValue = "wingdings";
                        break;
                }
                AjaxControlToolkit.HTMLEditor.ToolbarButton.SelectOption fontnameOptions = new AjaxControlToolkit.HTMLEditor.ToolbarButton.SelectOption();
                fontnameOptions.Value = strFontValue;
                fontnameOptions.Text = strFontText;
                MyFontName.Options.Add(fontnameOptions);
            }
            /////////////////
            AjaxControlToolkit.HTMLEditor.ToolbarButton.MethodButton btn = new AjaxControlToolkit.HTMLEditor.ToolbarButton.MethodButton();
            btn.NormalSrc = "../images/aa.jpg";
            btn.Attributes.Add("title", "Symbol");
            btn.Attributes.Add("id", "new1");
            btn.Attributes.Add("onclick", "onclickbutton(this);");
           
            TopToolbar.Buttons.Add(btn);



            TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.HorizontalSeparator());
            AjaxControlToolkit.HTMLEditor.ToolbarButton.FontSize MyFontSize = new AjaxControlToolkit.HTMLEditor.ToolbarButton.FontSize();
            TopToolbar.Buttons.Add(MyFontSize);
            int count = 1;
            for (int i = 8; i <= 36; i++)
            {
                AjaxControlToolkit.HTMLEditor.ToolbarButton.SelectOption fontsizeOptions = new AjaxControlToolkit.HTMLEditor.ToolbarButton.SelectOption();
                fontsizeOptions.Value = "" + i + "pt";
                fontsizeOptions.Text = "" + count + " (" + i + " pt)";
                MyFontSize.Options.Add(fontsizeOptions);
                count++;
            }

            TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.HorizontalSeparator());
            TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.Cut());
            TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.PasteText());
            TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.PasteWord());
            TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.HorizontalSeparator());
            TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.DecreaseIndent());
            TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.IncreaseIndent());
            TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.HorizontalSeparator());
            TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.Paragraph());
            TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.JustifyLeft());
            TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.JustifyCenter());
            TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.JustifyRight());
            TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.JustifyFull());
            TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.RemoveAlignment());
            TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.HorizontalSeparator());
            TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.OrderedList());
            TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.BulletedList());
            TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.HorizontalSeparator());
            TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.InsertHR());
            TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.InsertLink());
            TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.RemoveLink());
            TopToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.InsertHR());
        }
        protected override void FillBottomToolbar()
        {
            BottomToolbar.Buttons.Add(new AjaxControlToolkit.HTMLEditor.ToolbarButton.DesignMode());
        }
        public AjaxControlToolkit.HTMLEditor.ToolbarButton.SelectOption option { get; set; }
        public System.Collections.ObjectModel.Collection<AjaxControlToolkit.HTMLEditor.ToolbarButton.SelectOption> options { get; set; }
    }
}