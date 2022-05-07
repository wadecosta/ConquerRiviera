using UnityEngine;
using System;


namespace TMPro
{
    /// <summary>
    /// EXample of a Custom Character Input Validator to only allow digits from 0 to 9.
    /// </summary>
    [Serializable]
    //[CreateAssetMenu(fileName = "InputValidator - Digits.asset", menuName = "TextMeshPro/Input Validators/Digits", order = 100)]
<<<<<<< HEAD
    public class TMPDigitValidator : TMP_InputValidator
=======
    public class TMP_DigitValidator : TMP_InputValidator
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
    {
        // Custom text input validation function
        public override char Validate(ref string text, ref int pos, char ch)
        {
            if (ch >= '0' && ch <= '9')
            {
                text += ch;
                pos += 1;
                return ch;
            }

            return (char)0;
        }
    }
}
