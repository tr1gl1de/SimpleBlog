namespace EntityValidators.CustomValidators;

internal static class ValidationConsts
{
    #region UserConstatnts
    
    public const int UsernameMinLength = 3;
    public const int UsernameMaxLength = 30;
    
    public const int DisplaynameMinLength = 2;
    public const int DisplaynameMaxLength = 30;

    #endregion

    #region PostConstants

    public const int PostNameMinLength = 3; 
    public const int PostNameMaxLength = 30;
    
    public const int PostTagsMaxLength = 10;

    public const int PostTextMinLength = 3;
    public const int PostTextMaxLength = 350;

    #endregion

}