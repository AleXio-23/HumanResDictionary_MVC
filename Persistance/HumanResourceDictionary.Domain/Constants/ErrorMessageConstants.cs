namespace HumanResourceDictionary.Domain.Constants;

public static class ErrorMessageConstants
{
    public const string FirstnameIsRequired = "FIRSTNAME_IS_REQUIRED";
    public const string FirstnameRangeMustBe2To50Characters = "FIRSTNAME_RANGE_MUST_BE_2_TO_50_CHARACTERS";
    public const string FirstnameNotCombineDIffLanguages = "FIRSTNAME_NOT_COMBINE_DIFFERENT_LANGUAGE_CHARACTERS";

    public const string LastnameIsRequired = "LASTNAME_IS_REQUIRED";
    public const string LastnameRangeMustBe2To50Characters = "LASTNAME_RANGE_MUST_BE_2_TO_50_CHARACTERS";
    public const string LastnameNotCombineDIffLanguages = "LASTNAME_NOT_COMBINE_DIFFERENT_LANGUAGE_CHARACTERS";

    public const string PersonalNumberIsRequired = "PERSONAL_NUMBER_IS_REQUIRED";
    public const string PersonalNumberRangeError = "LASTNAME_RANGE_MUST_BE_2_TO_50_CHARACTERS";
    public const string PersonalNumberAlreadyExist = "PERSONAL_NUMBER_ALREADY_EXIST";
}