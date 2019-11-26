using System;

namespace MFI.Application.ViewModels
{
    public class ViewBase
    {
        public DateTime CreateDate { get; set; }

        public string CreateDateFormated
        {
            get { return CreateDate.ToShortDateString(); }
        }
    }
}