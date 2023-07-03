# surfer-web-browser

## EasyTabs

- [Easytabs](https://github.com/lstratman/EasyTabs) used (locally) in this project. And updated for this project.

### What's changed?

- Disabled form starting **Maximized** state.
- Updated form **MinumumSize** to (500, 0)

## IconHelper

- Used IconHelper from [https://www.codeproject.com/Articles/2532/Obtaining-and-managing-file-and-folder-icons-using](https://www.codeproject.com/Articles/2532/Obtaining-and-managing-file-and-folder-icons-using) in this project.

## Create This Files

- Surfer/Utils/SecretsLocal content:
```
namespace Surfer.Utils
{
    public static partial class Secrets
    {
        static Secrets()
        {
            EncryptKey = "your-encrypt-key";
        }
    }
}
```