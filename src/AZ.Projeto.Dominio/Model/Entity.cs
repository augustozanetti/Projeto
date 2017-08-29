using System;
using DomainValidation.Validation;

namespace AZ.Projeto.Dominio.Model
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public abstract bool EhValido();
    }
}
