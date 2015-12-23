using APG.CodeHelper.DBTreeView;

namespace Kadr.KadrTreeView.NodeAction
{
    internal class VacationReportCaptionProvider : IActionCaptionProvider
    {
        #region Implementation of IActionCaptionProvider

        public string GetCaption(object userContext)
        {
            //return userContext?.ToString();
            var tv = (userContext as KadrTreeView);
            var root = tv?.SelectedObject as RootNodeObject;
            return $"Получить график отпусков {root?.Department?.DepartmentSmallName}...";
        }

        #endregion
    }
}