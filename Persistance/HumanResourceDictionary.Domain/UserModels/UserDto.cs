using FluentValidation;
using HumanResourceDictionary.Domain.Constants;
using HumanResourceDictionary.Domain.DictionaryModels;

namespace HumanResourceDictionary.Domain.UserModels;

public record UserDto
{
    public int Id { get; set; }
    public string Firstname { get; set; } = default!;
    public string Lastname { get; set; } = default!;
    public int GenderId { get; set; }
    public string PersonalNumber { get; set; } = default!;
    public DateTime BirthDate { get; set; }

    public int CityId { get; set; }

    public string? AvatarUrl { get; set; }

    public GenderDto? Gender { get; set; } = null;
    public CityDto? City { get; set; } = null;
}

public class UserValidator : AbstractValidator<UserDto>
{
    public UserValidator()
    {
        // სახელი - სავალდებულო, მინიმუმ 2 და მაქსიმუმ 50 სიმბოლო, უნდა
        // შეიცავდეს მხოლოდ ქართული ან ლათინური ანბანის ასოებს, არ უნდა შეიცავდეს
        // ერთდროულად ლათინურ და ქართულ ასოებს
        RuleFor(user => user.Firstname)
            .NotEmpty().WithMessage(ErrorMessageConstants.FirstnameIsRequired)
            .Length(2, 50).WithMessage(ErrorMessageConstants.FirstnameRangeMustBe2To50Characters)
            .Matches(@"^[a-zA-Z]+$|^[ა-ჰ]+$").WithMessage(ErrorMessageConstants.FirstnameNotCombineDIffLanguages);

        // გვარი - სავალდებულო, მინიმუმ 2 და მაქსიმუმ 50 სიმბოლო, უნდა
        // შეიცავდეს მხოლოდ ქართული ან ლათინური ანბანის ასოებს, არ უნდა შეიცავდეს
        // ერთდროულად ლათინურ და ქართულ ასოებს
        RuleFor(user => user.Lastname)
            .NotEmpty().WithMessage(ErrorMessageConstants.LastnameIsRequired)
            .Length(2, 50).WithMessage(ErrorMessageConstants.LastnameRangeMustBe2To50Characters)
            .Matches(@"^[a-zA-Z]+$|^[ა-ჰ]+$").WithMessage(ErrorMessageConstants.LastnameNotCombineDIffLanguages);

        // პირადი ნომერი (ტექსტური, სავალდებულო, 11 ციფრი)
        RuleFor(user => user.PersonalNumber)
            .NotEmpty().WithMessage(ErrorMessageConstants.PersonalNumberIsRequired)
            .Length(11).WithMessage(ErrorMessageConstants.PersonalNumberRangeError);

        // დაბადების თარიღი (თარიღი, სავალდებულო, მინიმუმ 18 წლის)
        RuleFor(x => x.BirthDate)
            .Must(IsAtLeast18YearsOld)
            .WithMessage("Person must be at least 18 years old.");
    }


    private static bool IsAtLeast18YearsOld(DateTime birthDate)
    {
        var today = DateTime.Today;
        var age = today.Year - birthDate.Year;

        if (birthDate.Date > today.AddYears(-age))
        {
            age--;
        }

        return age >= 18;
    }
}