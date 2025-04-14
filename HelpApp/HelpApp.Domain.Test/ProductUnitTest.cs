using HelpApp.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace HelpApp.Domain.Test
{
    public class ProductUnitTest
    {
        #region Testes Positivos
        [Fact(DisplayName = "Create Product, with parameters Valid")]
        public void CreateProduct_WithValidParameters_ResultObjectValid()
        {
            Action action= () => new Product(1, "Product Name", "Preduct description", 9.99m, 99, "/img/productimage");
            action.Should().NotThrow<HelpApp.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product with Image is Empty ")]
        public void CreateProduct_WithImageIsEmpty_ResultObjectValid()
        {
            Action action = () => new Product(1, "Product Name", "Product description", 9.99m, 99, "");
            action.Should().NotThrow<HelpApp.Domain.Validation.DomainExceptionValidation>();
        }

        #endregion
        #region Testes Negativos


        [Fact(DisplayName = "Create Product With Negative Id")]
        public void CreateProduct_WithNegativeId_ResultObjectValid()
        {
            Action action = () => new Product(-1, "Product Name", "Preduct description", 9.99m, 99, "/img/productimage");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>("Invalid stock negative value.");
        }

        //Feitos por mim
        [Fact(DisplayName = "Create Product with Null Name")]
        public void CreateProduct_WithNullName_ResultObjectValid()
        {
            Action action = () => new Product(1, null, "Product description", 9.99m, 99, "/img/productimage");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>("Invalid name, name is required.");
        }

        [Fact(DisplayName = "Create Product with Empty Name")]
        public void CreateProduct_WithEmptyName_ResultObjectValid()
        {
            Action action = () => new Product(1, "", "Product description", 9.99m, 99, "/img/productimage");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>("Invalid name, name is required.");
        }

        [Fact(DisplayName = " Create Product With Name To Short")]
        public void CreateCategory_WithNameToShort_ResultObjectException()
        {
            Action action = () => new Product(1, "Ca", "Product description", 9.99m, 99, "/img/productimage");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name, too short, minimum 3 characters.");
        }

        [Fact(DisplayName = "Create Product with Invalid Description")]
        public void CreateProduct_WithInvalidDescription_ResultObjectValid()
        {
            Action action = () => new Product(1, "Product Name", null, 9.99m, 99, "/img/productimage");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>("Invalid description, name is required.");
        }

        [Fact(DisplayName = " Create Product With Description To Short")]
        public void CreateCategory_WithDescriptionToShort_ResultObjectException()
        {
            Action action = () => new Product(1, "Product Name", "ola", 9.99m, 99, "/img/productimage");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid description, too short, minimum 5 characters.");
        }

        [Fact(DisplayName = " Create Product With Negative Price")]
        public void CreateCategory_WithNegativePrice_ResultObjectException()
        {
            Action action = () => new Product(1, "Product Name", "Product description", -1.00m, 99, "/img/productimage");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid price negative value.");
        }

        [Fact(DisplayName = " Create Product With Negative Stock")]
        public void CreateCategory_WithNegativeStock_ResultObjectException()
        {
            Action action = () => new Product(1, "Product Name", "Product description", 9.99m, -99, "/img/productimage");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid stock negative value.");
        }

        [Fact(DisplayName = " Create Product With Invalid Image")]
        public void CreateCategory_WithInvalidImage_ResultObjectException()
        {
            Action action = () => new Product(1, "Product Name", "Product description", 9.99m, 99, "https://www.exemplo.com/img/foptoss/1234567890abcdef1234567890abcdef1234567890abcdef1234567890abcdef1234567890abcdef1234567890abcdef1234567890abcdef1234567890abcdef1234567890abcdef1234567890abcdef1234567890abcdef1234567890abcdef1234567890abcdef1234567890abcdef1234567890abcdef1234567890abcdef1234567890abcdef1234567890abcdef1234567890abcdef\r\n");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid image name, too long, maximum 250 characters.");
        }

        [Theory(DisplayName = "Create Product With Invalid Stock")]
        [InlineData(-5)]
        public void CreateProduct_InvalidStockValue_ExceptionDomainNegativeValue(int value)
        {
            Action action = () => new Product(1, "Product Name", "Product description", 9.99m, value, "/img/productimage");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid stock negative value.");
        }


        #endregion
    }
}
