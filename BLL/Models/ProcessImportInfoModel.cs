using System.Collections.Generic;

namespace BLL.Models
{
    public class ProcessImportInfoModel
    {
        public ProcessImportInfoModel()
        {
            Items = new List<ProcessedItemModel>();
        }

        public int FilesCount { get; set; }

        public List<ProcessedItemModel> Items { get; set; }
    }
}