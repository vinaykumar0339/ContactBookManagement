namespace ContactBookManagement.Tests;

[TestClass]
public class ValidatorUnitTests
{
    [TestMethod]
    public void IsValidName_WhenNameIsShorterThan5Characters_ReturnsFalse()
    {
        // Arrange
        string name = "John";

        // Act
        bool result = Validator.IsValidName(name);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsValidName_WhenNameIs5Characters_ReturnsTrue()
    {
        // Arrange
        string name = "Alice";

        // Act
        bool result = Validator.IsValidName(name);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsValidName_WhenNameIsLongerThan5Characters_ReturnsTrue()
    {
        // Arrange
        string name = "Robert";

        // Act
        bool result = Validator.IsValidName(name);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsEmpty_WhenNameIsEmpty_ReturnsTrue()
    {
        // Arrange
        string name = "";

        // Act
        bool result = Validator.IsEmpty(name);

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsEmpty_WhenNameIsNotEmpty_ReturnsFalse()
    {
        // Arrange
        string name = "Alice";

        // Act
        bool result = Validator.IsEmpty(name);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsValidMobileNumber_WhenMobileNumberIsNull_ReturnsFalse()
    {
        // Arrange
        string mobileNumber = null;

        // Act
        bool result = Validator.IsValidMobileNumber(mobileNumber);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsValidMobileNumber_WhenMobileNumberIsEmpty_ReturnsFalse()
    {
        // Arrange
        string mobileNumber = "";

        // Act
        bool result = Validator.IsValidMobileNumber(mobileNumber);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsValidMobileNumber_WhenMobileNumberIsShorterThan9Digits_ReturnsFalse()
    {
        // Arrange
        string mobileNumber = "12345678";

        // Act
        bool result = Validator.IsValidMobileNumber(mobileNumber);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsValidMobileNumber_WhenMobileNumberIsLongerThan9Digits_ReturnsFalse()
    {
        // Arrange
        string mobileNumber = "1234567890";

        // Act
        bool result = Validator.IsValidMobileNumber(mobileNumber);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsValidMobileNumber_WhenMobileNumberStartsWithZero_ReturnsFalse()
    {
        // Arrange
        string mobileNumber = "012345678";

        // Act
        bool result = Validator.IsValidMobileNumber(mobileNumber);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsValidMobileNumber_WhenMobileNumberContainsNonDigitCharacters_ReturnsFalse()
    {
        // Arrange
        string mobileNumber = "12345678a";

        // Act
        bool result = Validator.IsValidMobileNumber(mobileNumber);

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsValidMobileNumber_WhenMobileNumberIsValid_ReturnsTrue()
    {
        // Arrange
        string mobileNumber = "123456789";

        // Act
        bool result = Validator.IsValidMobileNumber(mobileNumber);

        // Assert
        Assert.IsTrue(result);
    }
}