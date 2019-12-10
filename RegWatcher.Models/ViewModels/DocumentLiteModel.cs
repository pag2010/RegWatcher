using RegWatcher.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegWatcher.Models.ViewModels
{
    public class DocumentLiteModel
    {
        public int DocumentId { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public DateTimeOffset? DeadLine { get; set; }
        public int DocumentTypeId { get; set; }
        public string FileName { get; set; }
        public string Number { get; set; }
        public UserLiteModel OwnerUser { get; set; }
        public UserLiteModel ResponsibleUser { get; set; }

        public DocumentLiteModel(Document document, string fileName, ApplicationUser ownerUser, ApplicationUser responsibleUser)
        {
            DocumentId = document.DocumentId;
            CreationDate = document.CreationDate;
            DeadLine = document.DeadLine;
            DocumentTypeId = (int)document.DocumentTypeId;
            FileName = fileName;
            Number = document.Number;
            OwnerUser = new UserLiteModel(ownerUser);
            ResponsibleUser = new UserLiteModel(responsibleUser);
        }
    }
}
