using RegWatcher.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegWatcher.Models.ViewModels
{
    public class CompanyModel
    {
        public int? CompanyId { get; set; }

        [Required(ErrorMessage = "Для организации должно быть указано полное наименование")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Для организации должно быть указано сокращенное наименование")]
        public string ShortName { get; set; }

        [Phone(ErrorMessage = "Телефонный номер не соотвествует международному стандрату")]
        public string Phone { get; set; }

        [EmailAddress(ErrorMessage = "Email адрес не валиден")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Для организации необходимо указать руководящее должностное лицо")]
        public PersonModel Person { get; set; }

        [Required(ErrorMessage = "Для организации необходимо указать организационно-правовую форму")]
        public int FormKindId { get; set; }

        [Required(ErrorMessage = "Для организации необходимо указать ИНН")]
        [StringLength(12)]
        public string Inn { get; set; }

        [StringLength(9)]
        public string Kpp { get; set; }

        [Required(ErrorMessage = "Для организации необходимо указать ОГРН")]
        [StringLength(15)]
        public string Ogrn { get; set; }

        [Required(ErrorMessage = "Для организации необходимо указать форму деятельности")]
        public string BusinessSubject { get; set; }

        [Required(ErrorMessage = "Для организации необходимо указать местонахождения")]
        public string Address { get; set; }

        public string Comment { get; set; }

        public DateTime? CreationTime { get; set; }
        public DateTime? UpdateTime { get; set; }

        public int? StepId { get; set; }

        public string UserId { get; set; }

        public Company GetCompany()
        {
            var company = new Company();
            company.Address = this.Address;
            company.BusinessSubject = this.BusinessSubject;
            company.Comment = this.Comment;
            company.Email = this.Email;
            company.FormKindId = this.FormKindId;
            company.FullName = this.FullName;
            company.Inn = this.Inn;
            company.Kpp = this.Kpp;
            company.Ogrn = this.Ogrn;
            company.ShortName = this.ShortName;
            if (!this.Person.PersonId.HasValue)
                company.Person = this.Person.GetPerson();
            else
                company.PersonId = this.Person.PersonId.Value;

            if (this.CompanyId.HasValue)
                company.CompanyId = this.CompanyId.Value;
            return company;
        }

        public CompanyModel()
        {
        }

        public CompanyModel(Company company, Person person)
        {
            CompanyId = company.CompanyId;
            Address = company.Address;
                BusinessSubject = company.BusinessSubject;
                Comment = company.Comment;
                Email = company.Email;
                FormKindId = company.FormKindId;
                FullName = company.FullName;
                Inn = company.Inn;
                Kpp = company.Kpp;
                Ogrn = company.Ogrn;
                
                Person = new PersonModel()
                {
                    Email = person.Email,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    PhoneNumber = person.PhoneNumber,
                    SecondName = person.SecondName,
                    PositionId = person.PositionId,
                    PersonId = person.PersonId
                };
            ShortName = company.ShortName;
            CreationTime = company.CreationTime;
            UpdateTime = company.CreationTime;
            UserId = company.UserId;
            StepId = (int)company.StepId;
        }
    }
}
